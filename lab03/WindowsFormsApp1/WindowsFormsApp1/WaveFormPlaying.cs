using NAudio.Wave;
using SlimDX.Direct3D9;
using SlimDX.XACT3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static WindowsFormsApp1.WaveFormPlaying;

namespace WindowsFormsApp1
{
    internal class WaveFormPlaying
    {
        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string sound, IntPtr hmod, uint flags);

        public void PlayWithPlaySound(string filepath)
        {
            bool success = false;

            Task.Run(() =>
            {
                success = PlaySound(filepath, IntPtr.Zero, 0);
            }
            );

            if (!success)
            {

                Console.WriteLine("Error playing sound");
            }
        }

        [DllImport("winmm.dll")]
        public static extern int waveOutWrite(IntPtr hWaveOut, IntPtr lpWaveHdr, uint uSize);

        [DllImport("winmm.dll")]
        public static extern int waveOutOpen(out IntPtr hWaveOut, uint uDeviceID, WaveFormat lpFormat, IntPtr dwCallback, IntPtr dwInstance, uint dwFlags);

        [StructLayout(LayoutKind.Sequential)]
        public class WaveFormat
        {
            public short wFormatTag;
            public short nChannels;
            public int nSamplesPerSec;
            public int nAvgBytesPerSec;
            public short nBlockAlign;
            public short wBitsPerSample;
            public short cbSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class WAVEHDR
        {
            public IntPtr lpData;
            public uint dwBufferLength;
            public uint dwBytesRecorded;
            public IntPtr dwUser;
            public uint dwFlags;
            public uint dwLoops;
            public IntPtr lpNext;
            public IntPtr reserved;
        }

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern int waveOutPrepareHeader(IntPtr hWaveOut, WAVEHDR hWaveHdr, int uSize);

        public void PlayWithWaveOutwrite(string filePath, WaveHeader waveHeader)
        {

            WaveFormat format = new WaveFormat();
            format.wFormatTag = (short)waveHeader.audioFormat; // WAVE_FORMAT_PCM
            format.nChannels = (short)waveHeader.channels; // Stereo
            format.nSamplesPerSec = (int)waveHeader.samplesPerSec; // Sample rate
            format.nAvgBytesPerSec = format.nSamplesPerSec * format.nChannels * 2; // Bytes per second
            format.nBlockAlign = (short)(format.nChannels * 2);
            format.wBitsPerSample = (short)waveHeader.bitsPerSample;
            format.cbSize = 0;

            IntPtr hWaveOut;

            waveOutOpen(out hWaveOut, 0, format, IntPtr.Zero, IntPtr.Zero, 0);
            WAVEHDR waveHdr = new WAVEHDR();
            waveHdr.dwBufferLength = waveHeader.blockAlignment;
            waveHdr.lpData = Marshal.AllocHGlobal((int)waveHdr.dwBufferLength);

            waveHdr.dwBufferLength = (uint)waveHdr.lpData;

            waveHdr.dwFlags = 0;
            waveHdr.dwLoops = 0;

            waveOutPrepareHeader(hWaveOut, waveHdr, Marshal.SizeOf(typeof(WAVEHDR)));

            waveOutWrite(hWaveOut, waveHdr.lpData, (uint)Marshal.SizeOf(typeof(WAVEHDR)));
        }

    }
}
