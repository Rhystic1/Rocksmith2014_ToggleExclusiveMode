using System;
using System.IO;

namespace ToggleExclusiveModeGUI
{
    public class ReadSettings
    {
        public string[] ReadSettingsFile()
        {
            try
            {
                GameCheck.CheckFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Settings file not found.");
            }
            string text = GameCheck.defaultpath;
            string[] advancedSettings = File.ReadAllLines(text);
            foreach (string s in advancedSettings)
            {
                // DEBUG
                // Console.WriteLine(s);
            }
            return advancedSettings;
        }
    }
}
