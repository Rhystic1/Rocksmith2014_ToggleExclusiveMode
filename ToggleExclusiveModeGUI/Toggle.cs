using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToggleExclusiveModeGUI
{
    public class Toggle
    {
        public static void Start()
        {
            Console.WriteLine(@"Attempting to read 'Rocksmith.ini'...");
            Console.WriteLine("\n");
            GameCheck.LoadPreviousSaveDirectory();
            if (File.Exists(GameCheck.inipath)) {
                string text = File.ReadAllText(GameCheck.inipath);

                if (text.Contains("ExclusiveMode=1"))
                {
                    text = text.Replace("ExclusiveMode=1", "ExclusiveMode=0");
                    File.WriteAllText(GameCheck.inipath, text);
                    MessageBox.Show("Exclusive Mode has been disabled. You should now be able to stream properly!",
                        "Success!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                    RefreshForm.RefreshExclusivityMode();
                }
                else
                {
                    text = text.Replace("ExclusiveMode=0", "ExclusiveMode=1");
                    File.WriteAllText(GameCheck.inipath, text);
                    MessageBox.Show("Exclusive Mode has been enabled. Enjoy minimal latency!",
                        "Success!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                    RefreshForm.RefreshExclusivityMode();
                }
            }
            else
            {
                GameCheck.CheckFile();
                GameCheck.CheckGame();
            }
        }
    }
}
