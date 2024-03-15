using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pady
{
    public partial class Test : Form
    {
        float x, y = 0;
        private System.Threading.Thread myThread;
        private Joystick joystick;
        public Test()
        {
            InitializeComponent();
        }
        public void addJoystick(Joystick joystick)
        {
            this.joystick = joystick;
        }

        public static Test MakeTest()
        {
            Test test = null;
            System.Threading.Thread thread = new System.Threading.Thread(() => {
                test = new Test();
                test.ShowDialog();
                });
            thread.Start();
            while(test == null)
            {
                System.Threading.Thread.Sleep(10);
            }
            test.myThread = thread;
            return test;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //poniżej wyświetlenie informacji o wciśniętych przyciskach
            richTextBox1.Clear();
            richTextBox1.Text += "Wcisnieto: ";
            for (int i = 0; i < joystick.GetCurrentState().Buttons.Count();i++)
            {
                if (joystick.GetCurrentState().Buttons[i]) {
                    richTextBox1.Text += i.ToString() + " ";
                }
            }
            //poniżej odczytanie pozycji drążka
            int inputOffset = 32767;
            textBox1.Text = String.Format("{0}%", (float)joystick.GetCurrentState().X / inputOffset);
            textBox3.Text = String.Format("{0}%", (float)joystick.GetCurrentState().Y / inputOffset);
            textBox4.Text = String.Format("{0}%", (float)joystick.GetCurrentState().Z / inputOffset);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       
    }
}
