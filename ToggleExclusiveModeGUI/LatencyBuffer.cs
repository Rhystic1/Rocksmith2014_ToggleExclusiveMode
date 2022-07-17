using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToggleExclusiveModeGUI
{
    public class LatencyBuffer
    {
        public static void ChangeLatBuffer()
        {
            string text = File.ReadAllText(GameCheck.defaultpath);
            if (text.Contains("LatencyBuffer=")) // We want to look for the "LatencyBuffer" line in particular.
            {
                //text = text.Replace("LatencyBuffer=", "LatencyBuffer=" + buffer);
                File.WriteAllText(GameCheck.defaultpath, text);
            }
        }
    }
}
