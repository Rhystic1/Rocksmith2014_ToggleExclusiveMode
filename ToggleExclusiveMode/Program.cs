using System;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ToggleExclusiveMode
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            static void Start()
            {
                Console.WriteLine(@"Attempting to read 'Rocksmith.ini'...");
                Console.WriteLine("\n");
                string text = File.ReadAllText(@"C:\Program Files (x86)\Steam\steamapps\common\Rocksmith2014\Rocksmith.ini");
                if (text.Contains("ExclusiveMode=1"))
                {
                    // Console.WriteLine("Exclusive Mode was enabled. Disabling it... \n"); Commenting out as might be confusing for the UX
                    text = text.Replace("ExclusiveMode=1", "ExclusiveMode=0");
                    File.WriteAllText(@"C:\Program Files (x86)\Steam\steamapps\common\Rocksmith2014\Rocksmith.ini", text);
                    Console.WriteLine("Exclusive Mode has been disabled. You should now be able to stream properly! \n");
                }
                else
                {
                    // Console.WriteLine("Exclusive Mode was disabled. Enabling it... \n"); Commenting out as might be confusing for the UX
                    text = text.Replace("ExclusiveMode=0", "ExclusiveMode=1");
                    File.WriteAllText(@"C:\Program Files (x86)\Steam\steamapps\common\Rocksmith2014\Rocksmith.ini", text);
                    Console.WriteLine("Exclusive Mode has been enabled. Enjoy minimal latency! \n");
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
