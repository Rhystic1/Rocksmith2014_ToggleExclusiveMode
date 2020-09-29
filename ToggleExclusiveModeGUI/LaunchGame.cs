using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToggleExclusiveModeGUI
{
    public class LaunchGame
    {
        public static void launchGame()
        {
            GameCheck.CheckGame();
            System.Diagnostics.Process.Start("steam://run/221680"); // Tells Steam to launch the game regardless of path
        }
    }
}
