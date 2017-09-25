using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsolePrintApp
{
    public class PhotoPrinter : Printer
    {
        private const int GenericRead = unchecked((int)0x80000000);
        private const int GenericWrite = 0x40000000;
        private const int FileShareRead = 1;
        private const int FileShareWrite = 2;
        private const int InvalidHandleValue = -1;
        private const int OpenExisting = 3;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(
            string lpFileName,
            int dwDesiredAccess,
            int dwShareMode,
            IntPtr lpSecurityAttributes,
            int dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetCurrentConsoleFont(
            IntPtr hConsoleOutput,
            bool bMaximumWindow,
            [Out][MarshalAs(UnmanagedType.LPStruct)]ConsoleFontInfo lpConsoleCurrentFont);

        [StructLayout(LayoutKind.Sequential)]
        internal class ConsoleFontInfo
        {
            internal int nFont;
            internal Coord dwFontSize;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct Coord
        {
            [FieldOffset(0)]
            internal short X;
            [FieldOffset(2)]
            internal short Y;
        }

        public override void Print(string str)
        {
            Console.WriteLine($"It's print by {nameof(PhotoPrinter)}:");
            base.Print(str);
        }

        public void Print(string path, int xAxis, int yAxis)
        {
            Point location = new Point(xAxis, yAxis);
            Size imageSize = new Size(20, 10);

            Console.SetCursorPosition(location.X - 1, location.Y);
            Console.Write(">");
            Console.SetCursorPosition(location.X + imageSize.Width, location.Y);
            Console.Write("<");
            Console.SetCursorPosition(location.X - 1, location.Y + imageSize.Height - 1);
            Console.Write(">");
            Console.SetCursorPosition(location.X + imageSize.Width, location.Y + imageSize.Height - 1);
            Console.WriteLine("<");
            
            using (Graphics g = Graphics.FromHwnd(GetConsoleWindow()))
            {
                using (Image image = Image.FromFile(path))
                {
                    Size fontSize = GetConsoleFontSize();

                    Rectangle imageRect = new Rectangle(
                        location.X * fontSize.Width,
                        location.Y * fontSize.Height,
                        imageSize.Width * fontSize.Width,
                        imageSize.Height * fontSize.Height);
                    g.DrawImage(image, imageRect);
                }
            }
        }

        private static Size GetConsoleFontSize()
        {
            // getting the console out buffer handle
            IntPtr outHandle = CreateFile("CONOUT$", GenericRead | GenericWrite,
                FileShareRead | FileShareWrite,
                IntPtr.Zero,
                OpenExisting,
                0,
                IntPtr.Zero);
            int errorCode = Marshal.GetLastWin32Error();
            if (outHandle.ToInt32() == InvalidHandleValue)
            {
                throw new IOException("Unable to open CONOUT$", errorCode);
            }

            ConsoleFontInfo cfi = new ConsoleFontInfo();
            if (!GetCurrentConsoleFont(outHandle, false, cfi))
            {
                throw new InvalidOperationException("Unable to get font information.");
            }

            return new Size(cfi.dwFontSize.X, cfi.dwFontSize.Y);
        }
    }
}
