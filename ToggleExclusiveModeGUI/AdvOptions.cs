using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToggleExclusiveModeGUI
{
    public partial class AdvOptions : Form
    {
        public AdvOptions()
        {
            InitializeComponent();
            TopMost = true;

            // We read the actual .INI for the current settings
            ReadSettings readSettings = new ReadSettings();
            List<string> iniSettings = readSettings.ReadSettingsFile();

            // Now we generate the options for the user to pick from
            AdvOptionsArrays advOptionsArrays = new AdvOptionsArrays();

            string uLL, latBuff, buffSize;

            // We can now populate the list using the real INI
            GetExistingSettings(iniSettings, out uLL, out latBuff, out buffSize);
            ultraLowLatOpt.Text = uLL;
            latencyBuffOpt.Text = latBuff;
            bufferSizeOpt.Text = buffSize;

            CreateOptions(advOptionsArrays);
        }

        private void CreateOptions(AdvOptionsArrays advOptionsArrays)
        {
            latencyBuffOpt.Items.AddRange(advOptionsArrays.GenerateLatBuffArray());
            bufferSizeOpt.Items.AddRange(advOptionsArrays.GenerateMaxBufferSizeArray());
            ultraLowLatOpt.Items.AddRange(advOptionsArrays.GenerateUltraLowLatArray());
        }

        public static void GetExistingSettings(List<string> iniSettings, out string uLL, out string latBuff, out string buffSize)
        {
            string uLLraw = iniSettings.Find(x => x.Contains("Win32UltraLowLatencyMode")).ToString();
            uLL = uLLraw.Substring(uLLraw.IndexOf('=') + 1);
            string latBuffRaw = iniSettings.Find(x => x.Contains("LatencyBuffer")).ToString();
            latBuff = latBuffRaw.Substring(latBuffRaw.IndexOf('=') + 1);
            string buffSizeRaw = iniSettings.Find(x => x.Contains("MaxOutputBufferSize")).ToString();
            buffSize = buffSizeRaw.Substring(buffSizeRaw.IndexOf('=') + 1);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ultraLowLatOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // GetExistingSettings(iniSettings, out uLL, out latBuff, out buffSize);
            string newValue = ultraLowLatModeText.Text.ToString();
        }
    }
}
