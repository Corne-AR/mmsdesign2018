using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Security.Forms
{
    public partial class Activation : Form
    {
        public Activation()
        {
            InitializeComponent();
        }

        #region DropShadow

        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion

        private void Activation_Load(object sender, EventArgs e)
        {
            requestCode_TextBox.Text = AMS_Security.ReadSecurityKey;

            ThemeColors.SetBorders(this);
        }

        private void activate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                AMS.Users.UserManager.LocalData.LocalKey = activateCode_TextBox.Text;
                string decyrpt = Security.Encryption.Decrypt(AMS.Users.UserManager.LocalData.LocalKey);

                if (decyrpt == AMS_Security.ReadSecurityKey)
                {
                    AMS.Users.UserManager.SaveLocalData();
                    AMS.MessageBox_v2.Show("Thank you for activating '" + AMS.Settings.Program.Name + "'\r\nPlease wait.", 2000);
                    this.Close();
                }
            }
            catch
            {
                AMS.MessageBox_v2.Show("Invalid activation code, please check for correct input");
            }
        }

        private void demo_Button_Click(object sender, EventArgs e)
        {
            AMS.Settings.Program.WorkMode = WorkMode.Demo;
            this.Close();
        }
    }
}
