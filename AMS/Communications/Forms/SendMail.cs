using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Communications.Forms
{
    public partial class SendMail : Form
    {
        public SendMail()
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

        private void SendMail_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            this.footer1.UpdateFooterText("Mail");
            ThemeColors.SetBorders(this);

            #endregion
        }
    }
}
