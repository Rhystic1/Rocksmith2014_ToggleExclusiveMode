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
            TopMost = false;

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

        private void UltraLowLatOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadSettings readSettings = new ReadSettings();
            List<string> iniSettings = readSettings.ReadSettingsFile();
            string uLLOldValue = iniSettings.Find(x => x.Contains("Win32UltraLowLatencyMode")).ToString();
            string uLLNewValue = ultraLowLatOpt.Text.ToString();
            try
            {
                string text = File.ReadAllText(GameCheck.defaultpath);
                string combinedNew = "Win32UltraLowLatencyMode=" + uLLNewValue;
                string text2 = text.Replace(uLLOldValue, combinedNew);
                File.WriteAllText(GameCheck.defaultpath, text2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to find, read or write the INI file.");
            }
        }

        private void LatencyBuffOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadSettings readSettings = new ReadSettings();
            List<string> iniSettings = readSettings.ReadSettingsFile();
            string latBuffOldValue = iniSettings.Find(x => x.Contains("LatencyBuffer")).ToString();
            string latBuffNewValue = latencyBuffOpt.Text.ToString();
            try
            {
                string text = File.ReadAllText(GameCheck.defaultpath);
                string combinedNew = "LatencyBuffer=" + latBuffNewValue;
                string text2 = text.Replace(latBuffOldValue, combinedNew);
                File.WriteAllText(GameCheck.defaultpath, text2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to find, read or write the INI file.");
            }
        }

        private void BufferSizeOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadSettings readSettings = new ReadSettings();
            List<string> iniSettings = readSettings.ReadSettingsFile();
            string buffSizeOldValue = iniSettings.Find(x => x.Contains("MaxOutputBufferSize")).ToString();
            string buffSizeNewValue = bufferSizeOpt.Text.ToString();
            try
            {
                string text = File.ReadAllText(GameCheck.defaultpath);
                string combinedNew = "MaxOutputBufferSize=" + buffSizeNewValue;
                string text2 = text.Replace(buffSizeOldValue, combinedNew);
                File.WriteAllText(GameCheck.defaultpath, text2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to find, read or write the INI file.");
            }
    }
}
