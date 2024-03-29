﻿using System;
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
    public class GameCheck // Logic that allows the program to search for and confirm the game path
    {
        public static string defaultpath = Settings.Default.defaultpath;
        public static string defaultgamepath = Settings.Default.defaultgamepath;
        public static void CheckFile()
        {
            if (!defaultpath.Contains("Rocksmith.ini")) // If we don't find the Rocksmith.ini file, then we're in the wrong folder
            {
                MessageBox.Show("Unable to detect the settings file. Please select your Rocksmith.ini file contained inside your Rocksmith 2014 installation folder.",
                    "Invalid selection!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                ChangeFolder();
            }
            try
            {
                string text = File.ReadAllText(defaultpath);
            }
            catch (DirectoryNotFoundException) // If the file is not detected at its default location, the program will prompt the user and restart.
            {
                MessageBox.Show("Directory not found. Please navigate to the game folder and select the Rocksmith.ini file.",
                    "Folder not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                ChangeFolder();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Please navigate to the game folder and select the Rocksmith.ini file.",
                "Folder not found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                ChangeFolder();
            }
        }

        public static void ChangeFolder()
        {
            OpenFileDialog b = new OpenFileDialog(); // We prompt the user for the correct folder and rerun the logic
            b.Filter = "Rocksmith INI (*.ini)|Rocksmith.ini";
            if (b.ShowDialog() == DialogResult.OK)
            {
                defaultpath = b.FileName; // Changing the path from default to the new one that the user selected.
                Settings.Default.defaultpath = b.FileName; // Overwrites the default settings to persistent storage.
                Settings.Default.Save();
                Settings.Default.Upgrade();
                return; // Avoids loop that occurs if the user first selects a wrong file, then selects the correct one (the main method would run multiple times)
            }
            else
            {
                MessageBox.Show("You need to specify a valid Rocksmith.ini file to continue. Make sure that you have Rocksmith 2014 Remastered installed, and that you have launched the game at least once. This program will now terminate.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                Application.Exit();
                return;
            }
        }
    }
}
