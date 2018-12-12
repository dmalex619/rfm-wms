using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WMSSuitable
{
    /// <summary>
    ///  ласс дл€ пр€мой печати текста на заданный параллельный порт (LPT1).
    /// Ќеобходим дл€ принтеров Zebra
    /// </summary>
    public class ParallelPrinter
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(String lpFileName,
            UInt32 dwDesiredAccess, UInt32 dwShareMode,
            IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition,
            UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Boolean ReadFile(IntPtr hFile, string lpBuffer,
            UInt32 nNumberOfBytesToRead, out UInt32 nNumberOfReadedBytes, IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Boolean WriteFile(IntPtr fFile, string lpBuffer, UInt32 nNumberOfBytesToWrite,
            out UInt32 lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        static extern Boolean CloseHandle(IntPtr hHandle);

        const Int32 WIN32_INVALID_HANDLE_VALUE = -1;
        const UInt32 WIN32_FILE_FLAG_OVERLAPPED = 0x40000000;
        const UInt32 WIN32_OPEN_EXISTING = 3;
        const UInt32 WIN32_GENERIC_READ = 0x80000000;
        const UInt32 WIN32_GENERIC_WRITE = 0x40000000;

        /// <summary>
        /// —татический метод печати пр€мо на параллельный порт
        /// </summary>
        /// <param name="LPTPort">»м€ порта (например, LPT1)</param>
        /// <param name="TextToPrint">“екст дл€ печати</param>
        /// <returns>¬озвращает признак успешности печати</returns>
        public static bool PrintText(string LPTPort, string TextToPrint)
        {
            // дополнение имени порта
            if (!LPTPort.EndsWith(":")) LPTPort += ":";

            //открываем порт
            IntPtr hPort = CreateFile(LPTPort, WIN32_GENERIC_READ | WIN32_GENERIC_WRITE, 0,
                IntPtr.Zero, WIN32_OPEN_EXISTING, WIN32_FILE_FLAG_OVERLAPPED, IntPtr.Zero);
            if (hPort != (IntPtr)WIN32_INVALID_HANDLE_VALUE) //провер€ем на ошибку
            {
                //пишем/читаем данные порта, например
                uint _sent = 0;
                WriteFile(hPort, TextToPrint, (uint)TextToPrint.Length, out _sent, IntPtr.Zero); //записали в порт
                CloseHandle(hPort); //закрываем порт
                return true;
            }
            else return false;

        }
    }
}
