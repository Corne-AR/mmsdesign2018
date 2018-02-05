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
    public partial class Header : UserControl
    {
        Form parent;
        public Header()
        {
            InitializeComponent();

            this.BackColor = ThemeColors.Menu;
            this.theme_Panel.BackColor = ThemeColors.Primary;
            this.panel1.BackColor = ThemeColors.Menu;
            this.panel2.BackColor = ThemeColors.Menu;
            this.panel3.BackColor = ThemeColors.Menu;
            this.close_Label.ForeColor = ThemeColors.SubText;
            this.minimize_Label.ForeColor = ThemeColors.SubText;
            this.maximize_Label.ForeColor = ThemeColors.SubText;
            this.Dock = DockStyle.Top;
        }

        public void UseControls(Form parent, bool useMaximize, bool useMinimize, bool useClose)
        {
            this.parent = parent;
            close_Label.Visible = useClose;
            maximize_Label.Visible = useMaximize;
            minimize_Label.Visible = useMinimize;
        }

        private Point MouseDownLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Parent.Left = e.X + this.Parent.Left - MouseDownLocation.X;
                this.Parent.Top = e.Y + this.Parent.Top - MouseDownLocation.Y;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            parent.Close();
        }

        private void Minimize_click(object sender, EventArgs e)
        {
            parent.WindowState = FormWindowState.Minimized;
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            if (parent.WindowState != FormWindowState.Maximized) parent.WindowState = FormWindowState.Maximized;
            else parent.WindowState = FormWindowState.Normal;
        }
    }
}
