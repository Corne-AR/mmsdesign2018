using AMS.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Users.Forms
{
    public partial class Login : Form
    {
        public bool Logged = false;
        private NetworkUser user = new NetworkUser();

        public Login()
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

        private void Login_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);
            this.BackColor = ThemeColors.WorkSpace;
            ThemeColors.SetControls(this.Controls);

            #endregion

            header1.UseControls(this, false, true, true);
            fastLoginCheckBox.Visible = AMS.Settings.Users.UseFastLogin;

            if (UserManager.LocalData.FastLogin)
            {
                user.Username = UserManager.LocalData.UserName;
                user.Password = UserManager.LocalData.Password;

                userNameTextBox.Text = user.Username;
                password_maskedTextBox.Text = user.Password;

                userNameTextBox.Update();
                password_maskedTextBox.Update();

                fastLoginCheckBox.Checked = UserManager.LocalData.FastLogin;
            }
        }

        private void Logon_Click(object sender, EventArgs e)
        {
            user.Username = userNameTextBox.Text;
            user.Password = password_maskedTextBox.Text;

            if (UserManager.CheckUserNamePassword(user, true))
            {
                Logged = true;

                UserManager.LocalData.UserName = user.Username;
                UserManager.LocalData.Password = user.Password;
                UserManager.LocalData.FastLogin = fastLoginCheckBox.Checked;
                UserManager.SaveLocalData();

                this.Close();
            }
            else
            {
                AMS.MessageBox_v2.Show("Login Error\r\n\r\nPlease check your username and password");
            }
        }
    }
}
