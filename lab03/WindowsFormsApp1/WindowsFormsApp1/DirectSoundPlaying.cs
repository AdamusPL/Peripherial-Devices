using SlimDX.DirectSound;
using SlimDX.Multimedia;
using System.IO;
using System.Threading;
using System;
using WindowsFormsApp1;

public class DirectSoundPlaying
{
    public IntPtr Handle { get; private set; }

    public void PlaySound(string audioFile, DirectSound ds, WaveHeader waveHeader)
    {
        WaveFormat format = new WaveFormat();
        format.BitsPerSample = (short)waveHeader.bitsPerSample;
        format.BlockAlignment = (short)waveHeader.blockAlignment;
        format.Channels = (short)waveHeader.channels;
        format.FormatTag = (WaveFormatTag)waveHeader.audioFormat;
        format.SamplesPerSecond = (int)waveHeader.samplesPerSec;
        format.AverageBytesPerSecond = format.SamplesPerSecond * format.BlockAlignment;

        SoundBufferDescription desc = new SoundBufferDescription();
        desc.Format = format;
        desc.Flags = BufferFlags.GlobalFocus;
        desc.SizeInBytes = 8 * format.AverageBytesPerSecond;

        PrimarySoundBuffer pBuffer = new PrimarySoundBuffer(ds, desc);

        SoundBufferDescription desc2 = new SoundBufferDescription();
        desc2.Format = format;
        desc2.Flags = BufferFlags.GlobalFocus | BufferFlags.ControlPositionNotify | BufferFlags.GetCurrentPosition2;
        desc2.SizeInBytes = 8 * format.AverageBytesPerSecond;

        SecondarySoundBuffer sBuffer1 = new SecondarySoundBuffer(ds, desc2);

        NotificationPosition[] notifications = new NotificationPosition[2];
        notifications[0].Offset = desc2.SizeInBytes / 2 + 1;
        notifications[1].Offset = desc2.SizeInBytes - 1; ;

        notifications[0].Event = new AutoResetEvent(false);
        notifications[1].Event = new AutoResetEvent(false);
        sBuffer1.SetNotificationPositions(notifications);

        byte[] bytes1 = new byte[desc2.SizeInBytes / 2];
        byte[] bytes2 = new byte[desc2.SizeInBytes];

        Stream stream = File.Open(audioFile, FileMode.Open);

        Thread fillBuffer = new Thread(() =>
        {
            int readNumber = 1;
            int bytesRead;

            bytesRead = stream.Read(bytes2, 0, desc2.SizeInBytes);
            sBuffer1.Write<byte>(bytes2, 0, LockFlags.None);
            sBuffer1.Play(0, PlayFlags.Looping);
            while (true)
            {
                if (bytesRead == 0) { break; }
                notifications[0].Event.WaitOne();
                bytesRead = stream.Read(bytes1, 0, bytes1.Length);
                sBuffer1.Write<byte>(bytes1, 0, LockFlags.None);

                if (bytesRead == 0) { break; }
                notifications[1].Event.WaitOne();
                bytesRead = stream.Read(bytes1, 0, bytes1.Length);
                sBuffer1.Write<byte>(bytes1, desc2.SizeInBytes / 2, LockFlags.None);
            }
            stream.Close();
            stream.Dispose();
        });
        fillBuffer.Start();
    }
}