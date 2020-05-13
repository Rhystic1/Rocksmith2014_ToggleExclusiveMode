using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToggleExclusiveModeGUI
{
    public class Status
    {
        public static void RetrieveStatus()
        {
            Console.WriteLine(@"Attempting to read 'Rocksmith.ini'...");
            Console.WriteLine("\n");
            GameCheck.LoadPreviousSaveDirectory();
            if (File.Exists(GameCheck.inipath)) {
                string text = File.ReadAllText(GameCheck.inipath);
                if (text.Contains("ExclusiveMode=1"))
                {
                    MessageBox.Show("Exclusive Mode is currently enabled.",
                        "Exclusive Mode Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                }
                else
                {
                    MessageBox.Show("Exclusive Mode is currently disabled.",
                        "Exclusive Mode Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                }
            }
        }
    }
}