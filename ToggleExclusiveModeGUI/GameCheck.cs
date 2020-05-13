using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToggleExclusiveModeGUI.Properties;

namespace ToggleExclusiveModeGUI
{

    public class GameCheck
    {
        public static string defaultinipath = @"C:\Program Files (x86)\Steam\steamapps\common\Rocksmith2014\Rocksmith.ini";
        public static string defaultgamepath = @"C:\Program Files (x86)\Steam\steamapps\common\Rocksmith2014\Rocksmith2014.exe";
        public static string inipath;
        public static string gamepath;

        public static void LoadPreviousSaveDirectory()
        {
            SaveDirectory.IsValidSaveDirectory(SaveDirectory.settingsFile);
            if (!SaveDirectory.IsValidSaveDirectory(SaveDirectory.settingsFile))
            {
                CheckFile();
                CheckGame();
                SaveDirectory.CreateSaveDirectory(inipath, gamepath);
            }
        }

        public static void CheckDefaultLocations()
        {
            if (File.Exists(defaultinipath) & File.Exists(defaultgamepath))
            {
                inipath = defaultinipath;
                gamepath = defaultgamepath;
            }
        }
        public static void CheckFile()
        {
            if (!File.Exists(inipath) & !File.Exists(inipath + "\\Rocksmith.ini"))
            {
                MessageBox.Show("This folder doesn't have a Rocksmith settings file in it!",
                    "Invalid Settings",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                FolderBrowserDialog b = new FolderBrowserDialog();
                if (b.ShowDialog() == DialogResult.OK)
                {
                    inipath = b.SelectedPath + "\\Rocksmith.ini";
                    CheckFile();
                    return; // Avoids loop that occurs if the user first selects a wrong file, then selects the correct one (the main method would run multiple times)
                }
            }
            try
            {
                if (File.Exists("Rocksmith.ini"))
                {
                    string text = File.ReadAllText(inipath);
                }
            }
            catch (DirectoryNotFoundException) // If the file is not detected at its default location, the program will prompt the user and restart.
            {
                MessageBox.Show("Please select your Rocksmith 2014 installation folder.",
                    "Install folder not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                FolderBrowserDialog b = new FolderBrowserDialog();

                if (b.ShowDialog() == DialogResult.OK)
                {
                    inipath = b.SelectedPath + "\\Rocksmith.ini";
                    CheckFile();
                    return;
                }
            }
        }
        public static void CheckGame()
        {
            if (!File.Exists(gamepath) & !File.Exists(inipath.Substring(0, inipath.Length - 14) + "\\Rocksmith2014.exe"))
            {
                MessageBox.Show("Please select your Rocksmith 2014 installation folder.",
                    "Invalid Executable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                FolderBrowserDialog b = new FolderBrowserDialog();
                if (b.ShowDialog() == DialogResult.OK)
                {
                    gamepath = b.SelectedPath + "\\Rocksmith2014.exe";
                    CheckGame();
                    return; // Avoids loop that occurs if the user first selects a wrong file, then selects the correct one (the main method would run multiple times)
                }
            } else
            {
                if (File.Exists(inipath.Substring(0, inipath.Length - 14) + "\\Rocksmith2014.exe"))
                {
                    gamepath = inipath.Substring(0, inipath.Length - 14) + "\\Rocksmith2014.exe";
                }
            }
            try
            {
                File.Exists(gamepath);
            }
            catch (DirectoryNotFoundException) // If the file is not detected at its default location, the program will prompt the user and restart.
            {
                MessageBox.Show("Your Rocksmith 2014 launcher can't be found",
                    "Install folder not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                FolderBrowserDialog b = new FolderBrowserDialog();

                if (b.ShowDialog() == DialogResult.OK)
                {
                    gamepath = b.SelectedPath + "\\Rocksmith2014.exe";
                    CheckGame();
                    return;
                }
            }
        }
    }
}
