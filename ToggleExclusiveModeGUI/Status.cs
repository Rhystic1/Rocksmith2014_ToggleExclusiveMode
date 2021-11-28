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
    public class Status // Logic to check the status of Exclusive Mode without actually changing it.
    {
        public static bool RetrieveStatus()
        {
            bool exModeStatus;
            GameCheck.CheckFile(); // We make sure that the file exists
            string text = File.ReadAllText(GameCheck.defaultpath);
            if (text.Contains("ExclusiveMode=1"))
            {
                exModeStatus = true;
            }
            else
            {
                exModeStatus = false;
            }
            return exModeStatus;
        }
    }
}