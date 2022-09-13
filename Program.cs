using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace BadmintonApp2
{
    class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(30);

                for (int i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    // replace -32767 with 32769 for windows 10.
                    if (keyState == 1 || keyState == -32767)
                    {
                        Console.WriteLine((char)i);
                        break;
                    }
                }
            }
        }
    }
}
