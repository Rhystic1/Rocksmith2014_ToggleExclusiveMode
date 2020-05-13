using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToggleExclusiveModeGUI
{
    public class RefreshForm
    {
        public static Form RefreshTheForm = new Form1();
        public static void RefreshExclusivityMode()
        {
            if (RefreshTheForm == null)
            {
                RefreshTheForm.FormClosed += ResetForm;
                RefreshTheForm = Form.ActiveForm;
            }

            if (Form.ActiveForm != RefreshTheForm)  // First Run 
            {
                Program.mainForm.Visible = false;
                RefreshTheForm.Show();
            }
            else // 2nd, 3rd, 4th, etc
            {
                RefreshTheForm.Close();
                RefreshTheForm = new Form1(); // Moving this breaks it for some reason
                RefreshTheForm.Show();
            }
              
        }
        public static void ResetForm(object sender, FormClosedEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosed Event");
            RefreshTheForm = null;
        }
    }
}
