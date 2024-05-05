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
    public partial class TabControl : UserControl
    {
        Form BaseForm;
        public List<Form> FormList;

        public TabControl()
        {
            InitializeComponent();

            tabControl_flowLayoutPanel.BackColor = ThemeColors.Menu;
            label1.BackColor = ThemeColors.Primary;
            label1.ForeColor = ThemeColors.PrimaryText;
            panel1.BackColor = ThemeColors.Primary;
            this.ForeColor = ThemeColors.MenuText;

            this.Dock = DockStyle.Top;
        }

        /// <summary>
        /// Base form
        /// </summary>
        /// <param name="BaseForm">ex: this</param>
        /// <param name="FormList">List of Forms ex:List<Form> formList = new List<Form>();</Form></param>
        public void AddMdiForms(Form BaseForm, List<Form> FormList)
        {
            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(tabControl_flowLayoutPanel);

            this.BaseForm = BaseForm;
            this.FormList = FormList;

            foreach (Form f in FormList)
            {
                if (!BaseForm.IsMdiContainer)
                    BaseForm.IsMdiContainer = true;

                BaseForm.FormClosing += BaseForm_FormClosing;

                f.MdiParent = BaseForm;
                f.FormClosing += f_FormClosing;

                Label l = new Label();

                l.Text = f.Text;
                l.TextAlign = ContentAlignment.MiddleLeft;
                l.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                l.Padding = new System.Windows.Forms.Padding(0);

                int charWidth = TextRenderer.MeasureText(l.Text.ToString(), l.Font).Width;

                l.Size = new System.Drawing.Size(charWidth, 23);

                l.Click += l_Click;

                tabControl_flowLayoutPanel.Controls.Add(l);
            }
        }
    
        // Methods

        public void LoadTab()
        {
            
            FormList[AMS.Suite.SuiteManager.Preferences.General.MainTab].Show();

            FormList[AMS.Suite.SuiteManager.Preferences.General.MainTab].Hide(); //Hierdie doen ek om seker te maak die Accounting tab laai maximized, 
            //so dit wil voorkom as ons hom eers hide en dan weer show, dan kry windos tyd om die window te maximize
            FormList[AMS.Suite.SuiteManager.Preferences.General.MainTab].Show();
            FormList[AMS.Suite.SuiteManager.Preferences.General.MainTab].WindowState = FormWindowState.Maximized;
            StatusUpdate.UpdateArea(FormList[AMS.Suite.SuiteManager.Preferences.General.MainTab].Text);
        }

        private void SetTabColor(Control tab)
        {
            if (BaseForm == null || BaseForm.ActiveMdiChild == null) return;

            if (tab.Text == BaseForm.ActiveMdiChild.Text)
            {
                tab.BackColor = ThemeColors.Primary;
                tab.ForeColor = ThemeColors.PrimaryText;
            }
            else
            {
                tab.BackColor = tabControl_flowLayoutPanel.BackColor;
                tab.ForeColor = ThemeColors.SubText;
            }
        }

        public void SetTabColors()
        {
            if (BaseForm == null || BaseForm.ActiveMdiChild == null) return;

            foreach (Control tab in tabControl_flowLayoutPanel.Controls)
                SetTabColor(tab);
        }

        // Events
        void l_Paint(object sender, PaintEventArgs e)
        {
            SetTabColor((Label)sender);
        }

        void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in FormList)
                f.Close();
            e.Cancel = false;
        }

        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f = (Form)sender;

            f.Hide();
            e.Cancel = true;
        }

        void l_Click(object sender, EventArgs e)
        {
            Label l = (Label)sender;

            var f = (from i in FormList
                     where i.Text == l.Text
                     select i).FirstOrDefault();

            if (f == null) f = FormList[0];
            if (f == null) return;

            #region Select and Hide

            BaseForm.SuspendLayout();
            f.SuspendLayout();
         
            if (BaseForm.ActiveMdiChild == f)
            {
            //    f.Hide(); //Sit hide af om te keer dat hy tyd mors om weer te laai as jy hom dalk wil view 
            }
            else
            {
                if (f.Visible == false)
                {
                    f.Show();
                    f.Select();
                }
                else
                {
                    f.Select();
                }
            }

            f.ResumeLayout();
            BaseForm.ResumeLayout();
         
            #endregion

            SetTabColors();

            AMS.Suite.SuiteManager.Preferences.General.MainTab = FormList.IndexOf(f);
            StatusUpdate.UpdateArea(f.Text);
        }
    }
}