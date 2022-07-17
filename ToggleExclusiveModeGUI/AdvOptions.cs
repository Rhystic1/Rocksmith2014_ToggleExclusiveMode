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

            // We can now populate the list using the real INI
            GetExistingSettings(iniSettings, out string uLL, out string latBuff, out string buffSize);
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

        public static string[] GetExistingSettings(List<string> iniSettings, out string uLL, out string latBuff, out string buffSize)
        {
            string uLLraw = iniSettings.Find(x => x.Contains("Win32UltraLowLatencyMode")).ToString();
            uLL = uLLraw.Substring(uLLraw.IndexOf('=') + 1);
            string latBuffRaw = iniSettings.Find(x => x.Contains("LatencyBuffer")).ToString();
            latBuff = latBuffRaw.Substring(latBuffRaw.IndexOf('=') + 1);
            string buffSizeRaw = iniSettings.Find(x => x.Contains("MaxOutputBufferSize")).ToString();
            buffSize = buffSizeRaw.Substring(buffSizeRaw.IndexOf('=') + 1);

            string[] settingsRaw = { uLLraw, latBuffRaw, buffSizeRaw };

            return settingsRaw;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CompareSettings(out string uLLNewValue, out string uLLOldValue, out string latBuffNewValue, out string latBuffOldValue, out string buffSizeNewValue, out string buffSizeOldValue)
        {
            ReadSettings readSettings = new ReadSettings();
            List<string> iniSettings = readSettings.ReadSettingsFile();
            GetExistingSettings(iniSettings, out string uLL, out string latBuff, out string buffSize);

            uLLNewValue = ultraLowLatModeText.Text.ToString();
            uLLOldValue = GetExistingSettings(iniSettings, out uLL, out latBuff, out buffSize).Contains(uLL).ToString();

            latBuffNewValue = latencyBuffText.Text.ToString();
            latBuffOldValue = GetExistingSettings(iniSettings, out uLL, out latBuff, out buffSize).Contains(latBuff).ToString();

            buffSizeNewValue = bufferSizeText.Text.ToString();
            buffSizeOldValue = GetExistingSettings(iniSettings, out uLL, out latBuff, out buffSize).Contains(buffSize).ToString();
        }
        private void ultraLowLatOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompareSettings(out string uLLOldValue, out string uLLNewValue, out string latBuffNewValue, out string latBuffOldValue, out string buffSizeNewValue, out string buffSizeOldValue);

            string text = File.ReadAllText(GameCheck.defaultpath);
            text.Replace(uLLOldValue, uLLNewValue);
            File.WriteAllText(GameCheck.defaultpath, text);
        }

        private void latencyBuffOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompareSettings(out string uLLOldValue, out string uLLNewValue, out string latBuffNewValue, out string latBuffOldValue, out string buffSizeNewValue, out string buffSizeOldValue);

            string text = File.ReadAllText(GameCheck.defaultpath);
            text.Replace(latBuffOldValue, latBuffNewValue);
            File.WriteAllText(GameCheck.defaultpath, text);
        }

        private void bufferSizeOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompareSettings(out string uLLOldValue, out string uLLNewValue, out string latBuffNewValue, out string latBuffOldValue, out string buffSizeNewValue, out string buffSizeOldValue);

            string text = File.ReadAllText(GameCheck.defaultpath);
            text.Replace(buffSizeOldValue, buffSizeNewValue);
            File.WriteAllText(GameCheck.defaultpath, text);
        }
    }
}
