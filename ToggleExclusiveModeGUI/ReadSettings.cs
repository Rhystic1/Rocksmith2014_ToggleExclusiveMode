using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToggleExclusiveModeGUI
{
    public class ReadSettings
    {
        public List<string> ReadSettingsFile()
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
            List<string> rawINISettings = File.ReadAllLines(text).ToList();
            string[] unwantedStringsArray = { "[Audio]", "[Renderer.Win32]", "[Net]" };
            List<string> unwantedStrings = new List<string>();
            unwantedStrings.AddRange(unwantedStringsArray);
            rawINISettings.RemoveAll(unwantedStrings.Contains);

            return rawINISettings;
        }
    }
}
