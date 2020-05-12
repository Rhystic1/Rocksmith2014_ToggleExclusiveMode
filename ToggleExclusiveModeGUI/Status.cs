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
        public static string defaultpath = @"C:\Program Files (x86)\Steam\steamapps\common\Rocksmith2014\Rocksmith.ini";
        public static void RetrieveStatus()
        {
            Console.WriteLine(@"Attempting to read 'Rocksmith.ini'...");
            Console.WriteLine("\n");
            if (!defaultpath.Contains("Rocksmith.ini"))
            {
                MessageBox.Show("Invalid file selected. Please select your Rocksmith.ini file contained inside your Rocksmith 2014 installation folder.",
                    "Invalid selection!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                OpenFileDialog b = new OpenFileDialog();
                if (b.ShowDialog() == DialogResult.OK)
                {
                    defaultpath = b.FileName;
                    RetrieveStatus();
                    return; // Avoids loop that occurs if the user first selects a wrong file, then selects the correct one (the main method would run multiple times)
                }
            }
            try
            {
                string text = File.ReadAllText(defaultpath);
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
            catch (DirectoryNotFoundException) // If the file is not detected at its default location, the program will prompt the user and restart.
            {
                MessageBox.Show("Directory not found. Please navigate to the game folder and select the Rocksmith.ini file.",
                    "Folder not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                OpenFileDialog b = new OpenFileDialog();

                if (b.ShowDialog() == DialogResult.OK)
                {
                    defaultpath = b.FileName;
                    RetrieveStatus();
                    return;
                }
            }
        }
    }
}
