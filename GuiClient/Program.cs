using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Windows.Forms;

namespace GuiClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // arguments array has 1 or 2 entries. We need the second to get the file name and path of the double-clicked file.
            // only 1 entry: user executed the executable and arguments[0] contains the .exe's name (including path).
            // 2 entries: 1st entry as above, 2nd entry contains the double-clicked file's name (including path).
            string[] arguments = Environment.GetCommandLineArgs();

            if (arguments.Length > 1 )
                Application.Run(new MainForm(arguments[1]));
            else
                Application.Run(new MainForm());
        }
    }
}
