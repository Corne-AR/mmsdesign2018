using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.UserInterface.UserControls
{
    public partial class Footer : UserControl
    {
        private string FooterText 
        {
            get { return label1.Text; }
            set { label1.Text = value; } 
        }

        public Footer()
        {
            InitializeComponent();
            this.theme_Panel.BackColor = ThemeColors.Primary;
            this.label1.BackColor = ThemeColors.Menu;
            this.label1.ForeColor = ThemeColors.SubText;
            this.BackColor = ThemeColors.Menu;
            this.panel1.BackColor = ThemeColors.Menu;
            this.panel2.BackColor = ThemeColors.Menu;
            this.panel3.BackColor = ThemeColors.Menu;

            this.Dock = DockStyle.Bottom;
        }

        private void Footer_Load(object sender, EventArgs e)
        {
            UpdateFooterText("AMS");
        }

        public void UpdateFooterText(string Text)
        {
            FooterText = Text;
            label1.Update();
            AMS.StatusUpdate.UpdateArea(Text);
        }

        public void UpdateFooterColor(Color color)
        {
            this.label1.ForeColor = color;
        }

        public void ResetFooterColor()
        {
            this.label1.ForeColor = ThemeColors.SubText;
        }
    }
}
