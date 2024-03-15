using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pady
{
    class EmulacjaMyszy
    {

        private float mouseX = 0, mouseY = 0;
        Joystick joystick;
        bool joystickInUse = false;

        public EmulacjaMyszy(Joystick joystick)
        {
            this.joystick = joystick;
        }

        public void InitializeEmulation()
        {
            uint flags = (uint)(MouseEventFlags.ABSOLUTE | MouseEventFlags.MOVE); // flagi umożliwiające śledzenie ruchu myszy(MOVE) oraz
            //ustawienie flagi Absolute powoduje że współrzędne myszy przekazywane w zdarzeniach są wartościami bezwzględnymi
            //mysz jest śledzona w zakresie całego ekranu, nie tylko aplikacji
            int inputOffset = 32767;   // input offset = 32767 (pozycja joysticka jest reprezentowana przez 16 bitową liczbę
            //gdzie wartość 32767 jest wartością środkową, musi zostać odjęta od odczytanej wartości wychylenia drążka, aby w pozycji neutralnej dać 0)
            while (true)
            {
               
                int x = joystick.GetCurrentState().X - inputOffset;  
                int y = joystick.GetCurrentState().Y - inputOffset;
                //wyliczenie przesunięcia na osiach x i y
                float xOffset = (float)x / inputOffset;  
                float yOffset = (float)y / inputOffset;

                if ((xOffset < 0.25 && yOffset < 0.25)&&(xOffset> -0.25 && yOffset > -0.25)) //ponieważ drążki są analogowe w pozycji neutralnej
                    //odczytana wartość jest bliska 0, ale niekoniecznie równa stąd zaokrąglenie aby podczas emulacji kursor nie poruszł się
                    //gdy drążek jest w pozycji neutralnej
                {
                    xOffset = 0;
                    yOffset = 0;
                }
                else
                {
                    xOffset *= 2;
                    yOffset *= 2;
                }

                                
                mouseX += xOffset; 
                mouseY += yOffset; 
                
                if (joystick.GetCurrentState().Buttons[0])  
                {
                    flags |= (uint)MouseEventFlags.LEFTDOWN; //lewy przycisk myszy wciśnięty
                                                             
                    if (joystickInUse) 
                        mouse_event(flags, (uint)mouseX, (uint)mouseY, 0, 0);

                }
                else 
                {
                    flags |= (uint)MouseEventFlags.LEFTUP; //lewy przycisk myszy zwolniony
                    if (joystickInUse) 
                        mouse_event(flags, (uint)mouseX, (uint)mouseY, 0, 0);
                    
                    flags = (uint)(MouseEventFlags.ABSOLUTE | MouseEventFlags.MOVE);
                    if (joystickInUse) 
                        mouse_event(flags, (uint)mouseX, (uint)mouseY, 0, 0);
                    
                }
                
               
                if (joystick.GetCurrentState().Buttons[2])// przcyisk uruchamia emulację myszy
                {  
                    joystickInUse = !joystickInUse;  
                    
                }

                if (joystick.GetCurrentState().Buttons[3])
                {
                    break;
                }

                if (joystickInUse) 
                    mouse_event(flags, (uint)mouseX, (uint)mouseY, 0, 0);

            }
            
        }

        [Flags]  // definicja flag
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,  // wcisniety lewy przycisk myszy
            LEFTUP = 0x00000004,
            MOVE = 0x00000001,  // poruszenie myszka
            ABSOLUTE = 0x00008000,  // odczytywanie wartości bezwzględnych
        }

        [DllImport("user32.dll")]  //dll używany do importu funkcji mouse_event używanej do obsługi zdarzenia myszy
                                   
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
    }
}
