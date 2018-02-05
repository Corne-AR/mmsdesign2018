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
    public partial class StatusStrip : UserControl
    {
        public StatusStrip()
        {
            InitializeComponent();

            //statusStrip_Panel.BackColor = ThemeColors.Primary;
            this.BackColor = ThemeColors.Primary;
            area_statusStrip.BackColor = ThemeColors.Primary;
            seactionOne_StatusStrip.BackColor = ThemeColors.Primary;
            dataInfo_StatusStrip.BackColor = ThemeColors.Primary;

            //statusStrip_Panel.ForeColor = ThemeColors.PrimaryText;
            this.ForeColor = ThemeColors.PrimaryText;
            area_statusStrip.ForeColor = ThemeColors.PrimaryText;
            seactionOne_StatusStrip.ForeColor = ThemeColors.PrimaryText;
            dataInfo_StatusStrip.ForeColor = ThemeColors.PrimaryText;

            top_Panel.BackColor = ThemeColors.MenuBorder;

            this.Dock = DockStyle.Bottom;

            if (AMS.Settings.Program.WorkMode == WorkMode.Demo) AMS_ToolStripStatusLabel.Text = "DEMO";

            string spacer = "       ";

            this.area_statusStrip.Items.Add(StatusUpdate.Area);
            this.area_statusStrip.Items.Add(new ToolStripStatusLabel()
            {
                Text = spacer + spacer + spacer,
                BackColor = ThemeColors.Primary,
                ForeColor = ThemeColors.PrimaryText
            });

            this.seactionOne_StatusStrip.Items.Add(StatusUpdate.SelectionHeaderOne);
            this.seactionOne_StatusStrip.Items.Add(StatusUpdate.SelectionOne);
            this.seactionOne_StatusStrip.Items.Add(new ToolStripStatusLabel()
            {
                Text = spacer,
                BackColor = ThemeColors.Primary,
                ForeColor = ThemeColors.PrimaryText
            });
            this.seactionOne_StatusStrip.Items.Add(StatusUpdate.SelectionHeaderTwo);
            this.seactionOne_StatusStrip.Items.Add(StatusUpdate.SelectionTwo);
            this.seactionOne_StatusStrip.Items.Add(new ToolStripStatusLabel()
            {
                Text = spacer,
                BackColor = ThemeColors.Primary,
                ForeColor = ThemeColors.PrimaryText
            });

            this.dataInfo_StatusStrip.Items.Add(StatusUpdate.DataInfo);
        }
    }
}