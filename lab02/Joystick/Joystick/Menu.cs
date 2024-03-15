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
using SharpDX.DirectInput;

namespace Pady
{
    public partial class Menu : Form    //Menu pozwala na wybór opcji
    {
        SharpDX.DirectInput.DirectInput directInput = new SharpDX.DirectInput.DirectInput();
        List<DeviceInstance> deviceList = new List<DeviceInstance>();  //stworzenie listy urządzeń
        public Menu()
        {
            
            InitializeComponent();

            var joysticks = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AttachedOnly);
            var gamepads = directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AttachedOnly);
            //poniżej wyświetlanie podłączonych urządeń
            foreach(DeviceInstance instance in joysticks)
            {
                deviceList.Add(instance);
                listBox1.Items.Add(instance.InstanceName);
            }

            foreach (DeviceInstance instance in gamepads)
            { 
                deviceList.Add(instance);
                listBox1.Items.Add(instance.InstanceName);
            }
        }

        private void button1_Click(object sender, EventArgs e)  //Uruchamia osobne okno pozwalające na odczytywanie stanu (wciśnięte przyciski,potencjomerty,pozycja drążka)
        {
            this.Hide();
            int chosenControler = listBox1.SelectedIndex;
            Joystick joystick = new Joystick(directInput, deviceList.ElementAt(chosenControler).InstanceGuid);
            joystick.Acquire();
            
            Test test = Test.MakeTest();
            test.addJoystick(joystick);
           // testPada testPada = new testPada(test, joystick);
            //testPada.Input();
            this.Show();
           

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            test.Enabled = true;
            emulacja.Enabled = true;
            rysowanie.Enabled = true;
        }

        private void emulacja_Click(object sender, EventArgs e)     //zdublowanie działania myszy
        {
            this.Hide();
            int chosenControler = listBox1.SelectedIndex;
            Joystick joystick = new Joystick(directInput, deviceList.ElementAt(chosenControler).InstanceGuid);
            joystick.Acquire();
           
            EmulacjaMyszy emulacja = new EmulacjaMyszy(joystick);
            new Thread(new ThreadStart(emulacja.InitializeEmulation)).Start();
           
            this.Show();
        }

        private void rysowanie_Click(object sender, EventArgs e)    //uruchamia okno pozwalające na rysowanie w nim
        {
            
            Paint paint = new Paint();
            paint.Show();
           
        }
    }
}
