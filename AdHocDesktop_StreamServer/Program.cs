using System;
using System.Collections.Generic;
using System.Windows.Forms;

using AdHocDesktop.Core;

namespace AdHocDesktop.StreamServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FirewallUtil.AuthroizeEntryAssembly();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StreamServerMainForm());
        }
    }
}