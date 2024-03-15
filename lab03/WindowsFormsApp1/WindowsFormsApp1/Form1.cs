using System;
using System.Windows.Forms;
using System.IO;
using SlimDX.DirectSound;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            isRecorded = false;
            recording = new Recording();

            for (int deviceId = 0; deviceId < WaveIn.DeviceCount; deviceId++)
            {
                var deviceInfo = WaveIn.GetCapabilities(deviceId);
                comboBox1.Items.Add(deviceInfo.ProductName);

            }

        }

        string filepath;
        WaveHeader header;
        bool isRecorded;
        Recording recording;
        MMDeviceEnumerator enumerator;
        MMDeviceCollection devices;
        string outputFileName = "glos.wav";
        WasapiLoopbackCapture capture;
        WaveFileWriter writer;
        WaveIn wave;

        private void axPlay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = filepath;
        }

        private void dsPlay_Click(object sender, EventArgs e)
        {
            DirectSoundPlaying directSoundPlaying = new DirectSoundPlaying();

            DirectSound ds = new DirectSound(Guid.Empty);
            ds.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);

            directSoundPlaying.PlaySound(filepath, ds, header);

        }

        private void chooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //process of opening file
            openFileDialog.Filter = @"Wave File (*wav)|*.wav";

            if (openFileDialog.ShowDialog() != DialogResult)
            {
                filepath = openFileDialog.InitialDirectory + openFileDialog.FileName;
                filename.Text = Path.GetFileName(openFileDialog.FileName);

            }

            header = new WaveHeader(); //printing header
            headerLabel.Text = header.GetInfo(filepath);
        }

        private void wfPlay_Click(object sender, EventArgs e)
        {
            WaveFormPlaying waveFormPlaying = new WaveFormPlaying();
            waveFormPlaying.PlayWithPlaySound(filepath);
        }

        private void playWithWOW_Click(object sender, EventArgs e)
        {
            WaveFormPlaying waveFormPlaying = new WaveFormPlaying();
            waveFormPlaying.PlayWithWaveOutwrite(filepath, header);
        }

        private void Wave_RecordingStopped(object sender, StoppedEventArgs e)
        {
            writer.Dispose();
        }

        private void Wave_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            if (!isRecorded)
            {

                wave = new WaveIn();
                wave.WaveFormat = new NAudio.Wave.WaveFormat(44100, 1);
                wave.DeviceNumber = comboBox1.SelectedIndex;
                wave.DataAvailable += Wave_DataAvailable;
                wave.RecordingStopped += Wave_RecordingStopped;
                writer = new WaveFileWriter(outputFileName, wave.WaveFormat);
                wave.StartRecording();

                isRecorded = !isRecorded;
            }

            else
            {
                wave.StopRecording();
                isRecorded = !isRecorded;
            }
        }
    }
}
