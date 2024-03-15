using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace Skan
{
    public partial class Form1 : Form
    {
        DeviceManager deviceManager = new DeviceManager();
        DeviceInfo firstDevice = null;
        WIA.Device device;
        int resolution;
        int width_pixel; 
        int height_pixel; 
        int brightness = 0;
        int contrast = 0;
        int rotate = 0;
        int color_mode = 1;  // 1 - Kolor, 2 - Szary, 4 - Czarno-Biały 
        ImageFile imageFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
                {
                    listBox1.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                    firstDevice = deviceManager.DeviceInfos[i];
                }
            }
            //listBoxList.SelectedIndex = 0;
            //listBoxList.SetSelected(0, true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Kolor") color_mode = 1;
            if (comboBox1.Text == "Czarno-bialy") color_mode = 4;
            if (comboBox1.Text == "Szary") color_mode = 2;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var device = firstDevice.Connect();
            var scannerItem = device.Items[1];

            string tekst = textBox1.Text;
            int res = int.Parse(tekst);
            resolution = res;


            string tekstX = textBox2.Text;
            double hX = double.Parse(tekstX);
            height_pixel = (int)hX*resolution;

            string tekstY = textBox3.Text;
            double hY = double.Parse(tekstY);
            width_pixel = (int)hY*resolution;

            //width_pixel = (int)(21 / 2.54 * resolution);
            //height_pixel = (int)(29.7 / 2.54 * resolution);
            //if (resolution > 600) resolution = 600;
            //if (resolution < 50) resolution = 50;
            //width_pixel = (int)(8.25* resolution);
            //height_pixel = (int)(11.65* resolution);

            AdjustScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, brightness, contrast, color_mode, rotate);
            string format_C = comboBox2.Text;
            string format = "";
            string format_end = "";
            ImageFormat format1 = ImageFormat.Jpeg;
            if (format_C == "JPEG")
            {
                format = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";//JPEG
                format_end = "jpeg";
                format1 = ImageFormat.Jpeg;
            }
            else if (format_C == "PNG")
            {
                format = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";//PNG
                format_end = "png";
                format1 = ImageFormat.Png;
            }
            else if (format_C == "TIFF")
            {
                format = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";//TIFF
                format_end = "tiff";
                format1 = ImageFormat.Tiff;
            }
            else if (format_C == "BMP")
            {
                format = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";//BMP
                format_end = "bmp";
                format1 = ImageFormat.Bmp;
            }

            imageFile = (ImageFile)scannerItem.Transfer(format);

            string path = "C:\\Users\\lab\\Desktop\\testy." + format_end;

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            imageFile.SaveFile(path);
            Bitmap bt = (Bitmap)Bitmap.FromFile(path);
            if (rotate == 90 || rotate == -270)
            {
                bt.RotateFlip(RotateFlipType.Rotate90FlipNone);
                bt.Save(path);
            }
            else if (rotate == 180 || rotate==-180)
            {
                bt.RotateFlip(RotateFlipType.Rotate180FlipNone);
                bt.Save(path);
            }
            else if(rotate == 270 || rotate == -90)
            {
                bt.RotateFlip(RotateFlipType.Rotate270FlipNone);
                bt.Save(path);
            }
            
            
            MessageBox.Show("Obraz został zapisany do pliku.");
            pictureBox1.ImageLocation = path;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private static void AdjustScannerSettings(IItem scannerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel, int scanWidthPixels, int scanHeightPixels, int brightness, int contrast, int color_mode, int rotate)
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";

            

            SetWIAProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightness);
            SetWIAProperty(scannerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrast);
            SetWIAProperty(scannerItem.Properties, WIA_SCAN_COLOR_MODE, color_mode);

            
            
        }
        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // string tekst = textBox1.Text;
            //int res = int.Parse(tekst);
            //resolution = res;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotate = int.Parse(comboBox3.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
