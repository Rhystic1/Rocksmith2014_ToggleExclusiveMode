using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            GameCheck.CheckFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Toggle.Start();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Status.RetrieveStatus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LaunchGame.launchGame();
            Application.Exit();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GameCheck.ChangeFolder();
            GameCheck.CheckFile();
        }
    }
}
