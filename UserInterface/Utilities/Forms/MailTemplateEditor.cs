using AMS;
using Data;
using Data.Communications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Utilities.Forms
{
    public partial class MailTemplateEditor : Form
    {
        MailTemplate template;
        bool updating = false;

        public MailTemplateEditor()
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

        private void MailTemplateEditor_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(toolStrip1, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(panel2, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(label1, ThemeColors.ControlType.MenuBorder);
            
            #endregion

            header1.UseControls(this, false, true, false);

            toolStripComboBox1.Items.AddRange(Enum.GetNames(typeof(TemplateTypes)));
        }

        // Methods

        private void SetPreview()
        {
            TemplateTypes tempType = (TemplateTypes)Enum.Parse(typeof(TemplateTypes), template.Name, true);
            var mail = DMS.MailManager.NewMail(DMS.ClientManager.GetDataList()[0].Account, true, "Some Subject", "PROGRAM GENERATED CONTENT", null, tempType);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Email: " + mail.MailTo);
            sb.AppendLine("Subject: " + mail.Subject);
            sb.AppendLine();
            sb.AppendLine(mail.Body);

            preview_Label.Text = sb.ToString();
        }

        // Events

        private void save_Buttons_Click(object sender, EventArgs e)
        {
            DMS.MailManager.SaveTemplates();
            SetPreview();
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadTemplate_Event(object sender, EventArgs e)
        {
            template = DMS.MailManager.GetTemplate(toolStripComboBox1.Text);

            mailTemplateBindingSource.DataSource = template;
            SetPreview();
        }
    }
}
