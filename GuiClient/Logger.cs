using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuiClient
{
    class Logger
    {
        private static System.IO.StreamWriter streamWriter;            
        protected static string LogName
        {
            get
            {
                return System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"LongAccess\GuiLog.txt");
            }
        }
        private static object locker = new object();
        public static void WriteLine(string text)
        {
            lock (locker)
            {
                if (streamWriter == null)
                {
                    Setup();
                }
                streamWriter.WriteLine(text);
            }
        }
        private static void Setup()
        {
            streamWriter = new System.IO.StreamWriter(LogName, false);
            streamWriter.AutoFlush = true;
        }

    }
}
