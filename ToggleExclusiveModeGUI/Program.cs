using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToggleExclusiveModeGUI
    {
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                string defaultpath = @"C:\Programm Files (x86)\Steam\steamapps\common\Rocksmith2014\Rocksmith.ini";
                Start();
                void Start()
                {
                    Console.WriteLine(@"Attempting to read 'Rocksmith.ini'...");
                    Console.WriteLine("\n");
                try
                {
                    string text = File.ReadAllText(defaultpath);
                    if (text.Contains("ExclusiveMode=1"))
                    {
                        // Console.WriteLine("Exclusive Mode was enabled. Disabling it... \n"); Commenting out as might be confusing for the UX
                        text = text.Replace("ExclusiveMode=1", "ExclusiveMode=0");
                        File.WriteAllText(defaultpath, text);
                        Console.WriteLine("Exclusive Mode has been disabled. You should now be able to stream properly! \n");
                    }
                    else
                    {
                        // Console.WriteLine("Exclusive Mode was disabled. Enabling it... \n"); Commenting out as might be confusing for the UX
                        text = text.Replace("ExclusiveMode=0", "ExclusiveMode=1");
                        File.WriteAllText(defaultpath, text);
                        Console.WriteLine("Exclusive Mode has been enabled. Enjoy minimal latency! \n");
                    }
                }

                catch (DirectoryNotFoundException) // If the file is not detected at its default location, the program will prompt the user and restart.
                {
                    Form1.textBox1 += "Directory not found. Please navigate to the game folder and select the Rocksmith.ini file." + " \r\n";
                    OpenFileDialog b = new OpenFileDialog();

                    if (b.ShowDialog() == DialogResult.OK)
                    {
                        defaultpath = b.FileName;
                        Start();
                    }
                }

                Console.WriteLine("Made a mistake? Press R to restart and invert the selection.");
                Console.WriteLine("Press any other key to exit.");
                ConsoleKeyInfo selection = Console.ReadKey();
                if (selection.Key == ConsoleKey.R)
                    {
                        Console.Clear();
                        Start();
                    }
                    else
                    {
                    }
                }

            }

        }
    }
