using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using AdHocDesktop.Core;

namespace AdHocDesktop.User
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread] // for video grabber
        static void Main()
        {
            try
            {
                //ImageUtil.CreateBitmapHeader(240, 180, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                
                FirewallUtil.AuthroizeEntryAssembly();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UserMainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally 
            {
                Environment.Exit(0);
            }
        }
    }
}