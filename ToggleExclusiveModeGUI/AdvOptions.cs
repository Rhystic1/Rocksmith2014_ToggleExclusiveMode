using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string[] advSettings = readSettings.ReadSettingsFile();

            // Now we generate the options for the user to pick from
            AdvOptionsArrays advOptionsArrays = new AdvOptionsArrays();
            string[] maxBuffSizeOptions = advOptionsArrays.GenerateMaxBufferSizeArray();
            string[] latBuffOptions = advOptionsArrays.GenerateLatBuffArray();
            string[] ultraLowOptions = advOptionsArrays.GenerateUltraLowLatArray();

            // DEBUG
            //foreach (string s in advSettings)
            //{
            //    Console.WriteLine(s);
            //}
            // END DEBUG
            latencyBuffOpt.DataSource = latBuffOptions;
            bufferSizeOpt.DataSource = maxBuffSizeOptions;
            ultraLowLatOpt.DataSource = ultraLowOptions;
        }

        private void latencyBuffOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int buffer;
            //buffer = latencyBuffOpt.SelectedIndex;
            //LatencyBuffer.ChangeLatBuffer();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
