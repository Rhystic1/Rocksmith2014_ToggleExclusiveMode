using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ToggleExclusiveModeGUI
{
    class SaveDirectory
    {
        public static string settingsFile = "RocksmithLocation.ini";
        public static void CreateSaveDirectory(string rocksmithINILocation, string rocksmithEXELocation)
        {
            GameCheck.CheckFile();
            File.WriteAllText(@settingsFile, "inipath=" + rocksmithINILocation + "\n");
            GameCheck.CheckGame();
            File.WriteAllText(@settingsFile, File.ReadAllText(@settingsFile) + "gamepath=" + rocksmithEXELocation + "\n");
        }
        public static bool IsValidSaveDirectory(string SaveDirectory)
        {
            if (File.Exists(@settingsFile))
            {
                if (File.ReadAllText(@SaveDirectory).Contains("inipath=") & File.ReadAllText(@SaveDirectory).Contains("gamepath="))
                {
                    foreach (string line in File.ReadAllLines(@SaveDirectory))
                    {
                        if (line.Contains("inipath="))
                        {
                            GameCheck.inipath = line.Substring(8, line.Length - 8);
                        }
                        if (line.Contains("gamepath="))
                        {
                            GameCheck.gamepath = line.Substring(9, line.Length - 9);
                        }
                    } 
                }
                return true;
            }
            return false;
        }
    }
}
