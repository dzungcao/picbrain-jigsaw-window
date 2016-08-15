
using Gecko;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JigsawApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Xpcom.Initialize("Firefox");

                var geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };

                Form f = new Form1();

                f.Controls.Add(geckoWebBrowser);

                geckoWebBrowser.Navigate("http://local.picbrain.info/windowapp");

                Application.Run(f);
            }
            catch (Exception ex)
            {
                File.WriteAllText("error_log.txt", DateTime.Now.ToString() + ": ERROR MESSAGE-----\n");
                File.WriteAllText("error_log.txt", ex.Message);
                File.WriteAllText("error_log.txt", DateTime.Now.ToString() + ": STACK TRACE-----\n");
                File.WriteAllText("error_log.txt", ex.StackTrace);
                File.WriteAllText("error_log.txt", "\n");
                MessageBox.Show("We encounter a problem and the app will close, please visit http://picbrain.info/support for more information","Warning");
            }
        }
    }
}
