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
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (Form1.buttonWasPressed == true)
            {
                Start();
            }
            void Start()
            {
                Console.WriteLine(@"Attempting to read 'Rocksmith.ini'...");
                Console.WriteLine("\n");
                if (!Status.defaultpath.Contains("Rocksmith.ini"))
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
                        Status.defaultpath = b.FileName;
                        Start();
                        return; // Avoids loop that occurs if the user first selects a wrong file, then selects the correct one (the main method would run multiple times)
                    }
                }
                try
                {
                    string text = File.ReadAllText(Status.defaultpath);
                    if (text.Contains("ExclusiveMode=1"))
                    {
                        text = text.Replace("ExclusiveMode=1", "ExclusiveMode=0");
                        File.WriteAllText(Status.defaultpath, text);
                        MessageBox.Show("Exclusive Mode has been disabled. You should now be able to stream properly!", 
                            "Success!", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information, 
                            MessageBoxDefaultButton.Button1, 
                            MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                    }
                    else
                    {
                        text = text.Replace("ExclusiveMode=0", "ExclusiveMode=1");
                        File.WriteAllText(Status.defaultpath, text);
                        MessageBox.Show("Exclusive Mode has been enabled. Enjoy minimal latency!", 
                            "Success!", 
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
                        Status.defaultpath = b.FileName;
                        Start();
                        return;
                    }
                }
                Application.Exit();
            }
        }
    }
}
