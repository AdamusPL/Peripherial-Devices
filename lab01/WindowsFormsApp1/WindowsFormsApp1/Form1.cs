using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        FTDI myFtdiDevice;
        FTDI. FT_STATUS ftStatus = FTDI.FT_STATUS.FT_DEVICE_NOT_FOUND;
        UInt32 numBytesWritten = 0;
        byte[] fullstepArray = { 0b0110, 0b1010, 0b1001, 0b0101 };
        byte[] fullstepUpAndDown = { 0b01100000, 0b10100000, 0b10010000, 0b01010000};
        byte[] waveArray = { 0b0100, 0b0010, 0b1000, 0b0001 };
        byte[] waveUpAndDown = { 0b01000000, 0b00100000, 0b10000000, 0b00010000 };
        byte[] halfstepArray = { 0b0010, 0b1010, 0b1000, 0b1001, 0b0001, 0b0101, 0b0100, 0b0110 };
        byte[] halfstepUpAndDown = { 0b00100000, 0b10100000, 0b10000000, 0b10010000, 0b00010000, 0b01010000, 0b01000000, 0b01100000 };
        int index4 = 0;
        int index8 = 8;

        public Form1()
        {
            InitializeComponent();
        }

            public void move(int count, int direction, byte[] data, int speed, ref int  index)
            {
          
            Int32 bytesToWrite = 1;

                for (int j = 0; j < count; j++)
                {
                index += direction;

                if (direction == -1 && (index <0 || index > data.Length-1))
                    {
                        index = data.Length-1;
                    }
                    else
                    {
                        if (direction == 1 && (index > data.Length - 1 || index < 0))
                        {
                            index = 0;
                        }
                    }

              
                byte[] x = { data[index] };
                    myFtdiDevice.Write(x, bytesToWrite, ref numBytesWritten);
                    
                    Thread.Sleep(speed);
                }
            }

        public void openDevice()
        {
            richTextBox1.Clear();
            try
            {
                UInt32 ftdiDeviceCount = 0;
                myFtdiDevice = new FTDI();
                myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
                myFtdiDevice.GetDeviceList(ftdiDeviceList);
                ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);
                myFtdiDevice.SetBitMode(0xff, 1);
                richTextBox1.Text = "Otwarto urządzenie: " + ftdiDeviceList[0].SerialNumber;
            }
            catch
            {
                richTextBox1.Text += "Nie udało się otworzyć urządzenia";
            }

        }

        public void closeDevice()
        {
            richTextBox1.Clear();
            if(ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                try
                {
                    Int32 bytesToWrite = 1;
                    UInt32 bytesWritten = 0;
                    myFtdiDevice.Close();
                }

                catch
                {
                    richTextBox1.Text += "Nie udało się zamknąć urządzenia";
                }
            }
            else
            {
                richTextBox1.Text = "Brak podłączonych urządzeń";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string way = "Falowe";
            int count = 0;
            int speed = 0;
            try
            {
                way = comboBox1.Text;
                count = Convert.ToInt32(textBox1.Text);
                speed = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                richTextBox1.Text += "Nieprawidłowy format danych";
            }


            if (way == "Pełnokrokowe")
            {
                move(count, 1, fullstepArray, speed, ref index4);
            }

            else if(way == "Półkrokowe")
            {
                move(count, 1, halfstepArray, speed, ref index8);
            }

            else if(way == "Falowe")
            {
                move(count, 1, waveArray, speed, ref index4);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string way = "Falowe";
            int count = 0;
            int speed = 0;
            try
            {
                way = comboBox1.Text;
                count = Convert.ToInt32(textBox1.Text);
                speed = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                richTextBox1.Text += "Nieprawidłowy format danych";
            }
            

            if (way == "Pełnokrokowe")
            {
                move(count, -1, fullstepArray, speed, ref index4);
            }

            else if (way == "Półkrokowe")
            {
                move(count, -1, halfstepArray, speed, ref index8);
            }

            else if (way == "Falowe")
            {
                move(count, -1, waveArray, speed, ref index4);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openDevice();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            closeDevice();
        }

        private void button5_Click(object sender, EventArgs e) // lewo poziom
        {
            richTextBox1.Clear();
            string way = "Falowe";
            int count = 0;
            int speed = 0;
            try
            {
                way = comboBox1.Text;
                count = Convert.ToInt32(textBox1.Text);
                speed = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                richTextBox1.Text += "Nieprawidłowy format danych";
            }


            if (way == "Pełnokrokowe")
            {
                move(count, 1, fullstepUpAndDown, speed, ref index4);
            }

            else if (way == "Półkrokowe")
            {
                move(count, 1, halfstepUpAndDown, speed, ref index8);
            }

            else if (way == "Falowe")
            {
                move(count, 1, waveUpAndDown, speed, ref index4);
            }
        }

        private void button6_Click(object sender, EventArgs e) // prawo poziom
        {
            richTextBox1.Clear();
            string way = "Falowe";
            int count = 0;
            int speed = 0;
            try
            {
                way = comboBox1.Text;
                count = Convert.ToInt32(textBox1.Text);
                speed = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                richTextBox1.Text += "Nieprawidłowy format danych";
            }


            if (way == "Pełnokrokowe")
            {
                move(count, -1, fullstepUpAndDown, speed, ref index4);
            }

            else if (way == "Półkrokowe")
            {
                move(count, -1, halfstepUpAndDown, speed, ref index8);
            }

            else if (way == "Falowe")
            {
                move(count, -1, waveUpAndDown, speed, ref index4);
            }
        }
    }

    


}
