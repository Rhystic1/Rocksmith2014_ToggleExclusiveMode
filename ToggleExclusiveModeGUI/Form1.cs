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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TopMost = true;
        }

        public void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        public void Form1_Load(object sender, EventArgs e)
        {
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Toggle.Start();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Status.RetrieveStatus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            LaunchGame.LaunchRocksmith2014();
            Application.Exit();
        }
    }
}
