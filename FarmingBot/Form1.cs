using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//InteropServices is what allows us to use DllImport        

namespace FarmingBot
{

    public partial class Form1 : Form
    {
        int times = 1;
        DateTime cooldown;
        DateTime sectime;
        sealed class Win32
        {

            Color col;
            [DllImport("user32.dll")]
            static extern IntPtr GetDC(IntPtr hwnd);

            [DllImport("user32.dll")]
            static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

            [DllImport("gdi32.dll")]
            static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

            static public System.Drawing.Color GetPixelColor(int x, int y)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                uint pixel = GetPixel(hdc, x, y);
                ReleaseDC(IntPtr.Zero, hdc);
                Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                             (int)(pixel & 0x0000FF00) >> 8,
                             (int)(pixel & 0x00FF0000) >> 16);

                return color;

            }
        }
        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendInput(int nInputs, ref INPUT pInputs,
                                           int cbSize);
        //mouse event constants
        bool star = true;
        const int MOUSEEVENTF_LEFTDOWN = 2;
        const int MOUSEEVENTF_LEFTUP = 4;
        //input type constant
        const int INPUT_MOUSE = 0;

        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        public struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        };

        public class Keyboard
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

            const int KEY_DOWN_EVENT = 0x0001; //Key down flag
            const int KEY_UP_EVENT = 0x0002; //Key up flag

            public static void HoldKey(byte key, double duration)
            {
                int totalDuration = 0;
                var startTime = DateTime.UtcNow;
                while (DateTime.UtcNow - startTime < TimeSpan.FromSeconds(duration))
                {
                    keybd_event(key, 0, KEY_DOWN_EVENT, 0);









                }
                keybd_event(key, 0, KEY_UP_EVENT, 0);


            }

        }
        //FindWindow
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName);

        //hWnd to make it easier
        IntPtr hWnd = FindWindow(
            null,
            "MapleStory");

        //PostMessage
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]

        static extern bool PostMessage(
        IntPtr hWnd,

        uint Msg,
        int wParam,
        int lParam);
        //Define WM_KEYDOWN
        const int WM_KEYDOWN = 0x100;

        public Form1()
        {

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            FindWindow(null, "MapleStory");

            /* null would be where the Window Class would be.
             * Which is MapleStoryClass for MS. But apparently the class
             * when the 'play screen' is up isnt' MapleStoryClass,
             * and I like opening my stuff at the play screen.
             * So I just used the Window Name instead.
             */
        }

        private void clicknpc()
        {  //set cursor position to memorized location
            Cursor.Position = new Point(860, 305);
            //set up the INPUT struct and fill it for the mouse down
            INPUT i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi.dx = 0;
            i.mi.dy = 0;
            i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            i.mi.dwExtraInfo = IntPtr.Zero;
            i.mi.mouseData = 0;
            i.mi.time = 0;
            //send the input 
            SendInput(1, ref i, Marshal.SizeOf(i));
            //set the INPUT for mouse up and send it
            i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref i, Marshal.SizeOf(i));
        }
        private void accetparty()
        {  //set cursor position to memorized location
            Cursor.Position = new Point(584, 691);
            //set up the INPUT struct and fill it for the mouse down
            INPUT i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi.dx = 0;
            i.mi.dy = 0;
            i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            i.mi.dwExtraInfo = IntPtr.Zero;
            i.mi.mouseData = 0;
            i.mi.time = 0;
            //send the input 
            SendInput(1, ref i, Marshal.SizeOf(i));
            //set the INPUT for mouse up and send it
            i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref i, Marshal.SizeOf(i));
        }
        private void clickrepeat()
        {  //set cursor position to memorized location
            Cursor.Position = new Point(1122, 436);
            //set up the INPUT struct and fill it for the mouse down
            INPUT i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi.dx = 0;
            i.mi.dy = 0;
            i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            i.mi.dwExtraInfo = IntPtr.Zero;
            i.mi.mouseData = 0;
            i.mi.time = 0;
            //send the input 
            SendInput(1, ref i, Marshal.SizeOf(i));
            //set the INPUT for mouse up and send it
            i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref i, Marshal.SizeOf(i));
        }
        private void clickMaple()
        {  //set cursor position to memorized location
            Cursor.Position = new Point(350, 150);
            //set up the INPUT struct and fill it for the mouse down
            INPUT i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi.dx = 0;
            i.mi.dy = 0;
            i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            i.mi.dwExtraInfo = IntPtr.Zero;
            i.mi.mouseData = 0;
            i.mi.time = 0;
            //send the input 
            SendInput(1, ref i, Marshal.SizeOf(i));
            //set the INPUT for mouse up and send it
            i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref i, Marshal.SizeOf(i));
        }
        private void clickrepeat2()
        {  //set cursor position to memorized location
            Cursor.Position = new Point(1094, 453);
            //set up the INPUT struct and fill it for the mouse down
            INPUT i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi.dx = 0;
            i.mi.dy = 0;
            i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            i.mi.dwExtraInfo = IntPtr.Zero;
            i.mi.mouseData = 0;
            i.mi.time = 0;
            //send the input 
            SendInput(1, ref i, Marshal.SizeOf(i));
            //set the INPUT for mouse up and send it
            i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref i, Marshal.SizeOf(i));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int mone = 1;
            System.Threading.Thread.Sleep(2000);
      
            var startTime = DateTime.UtcNow;
            var startTime1 = DateTime.UtcNow;
      
            while (true)
            {

                System.Threading.Thread.Sleep(2000);
                clickrepeat();
                clickrepeat();

               


            


                System.Threading.Thread.Sleep(3000);
                if (Win32.GetPixelColor(616, 341).ToString() == "Color [A=255, R=221, G=221, B=221]")
                {
              
                    Process.Start("Shutdown", "-s -t 1");

                }
                while (Win32.GetPixelColor(1260, 968).ToString() == "Color [A=255, R=255, G=255, B=255]")
                {

                    if (Win32.GetPixelColor(101, 113).ToString() == "Color [A=255, R=255, G=221, B=68]" || Win32.GetPixelColor(92, 113).ToString() == "Color [A=255, R=255, G=221, B=68]")
                    {
                        Keyboard.HoldKey((byte)Keys.Right, 2);
                    }


                    while (Win32.GetPixelColor(939, 750).ToString() == "Color [A=255, R=255, G=255, B=255]")
                    {
                        PostMessage(hWnd, WM_KEYDOWN, 0x2D, 0x1520001);
                        System.Threading.Thread.Sleep(50);

                        


                    }



                }


                clickMaple();
                System.Threading.Thread.Sleep(1000);
                if (DateTime.UtcNow - startTime >= TimeSpan.FromMinutes(40))
                {

                    PostMessage(hWnd, WM_KEYDOWN, 0x77, 0x420001);
                    startTime = DateTime.UtcNow;
                }
                if (DateTime.UtcNow - startTime1 >= TimeSpan.FromMinutes(122))
                {
                    System.Threading.Thread.Sleep(2000);
                    PostMessage(hWnd, WM_KEYDOWN, 0x73, 0x3e0001);
                    startTime1 = DateTime.UtcNow;
                }

                System.Threading.Thread.Sleep(500);
                PostMessage(hWnd, WM_KEYDOWN, 0x2E, 0x1530001);
                System.Threading.Thread.Sleep(500);
                PostMessage(hWnd, WM_KEYDOWN, 0x2E, 0x1530001);
                System.Threading.Thread.Sleep(500);
                PostMessage(hWnd, WM_KEYDOWN, 0x2E, 0x1530001);
                System.Threading.Thread.Sleep(500);

                if (mone % 2 == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    PostMessage(hWnd, WM_KEYDOWN, 0x44, 0x200001);
                    System.Threading.Thread.Sleep(1000);
                    PostMessage(hWnd, WM_KEYDOWN, 0x41, 0x1e0001);
                    System.Threading.Thread.Sleep(1000);
                    PostMessage(hWnd, WM_KEYDOWN, 0x76, 0x410001);
                    System.Threading.Thread.Sleep(1000);
                    PostMessage(hWnd, WM_KEYDOWN, 0x75, 0x400001);

                }


                mone++;
            }
        }
    }
}
