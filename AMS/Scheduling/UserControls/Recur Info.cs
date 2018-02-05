using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMS.Data.Scheduling;

namespace AMS.Scheduling.UserControls
{
    public partial class Recur_Info : UserControl
    {
        // Variables

        public Recur Recur = new Recur();

        // Constructors

        public Recur_Info()
        {
            InitializeComponent();
        }

        // Load

        private void Recur_Info_Load(object sender, EventArgs e)
        {

            this.BackColor = ThemeColors.WorkSpace;
            ThemeColors.SetControls(this.Controls);
            Recur.RecurDate = DateTime.Now;
            recurBindingSource.DataSource = Recur;
            UpdateRecurInfo();

            activeCheckBox.CheckedChanged += activeCheckBox_CheckedChanged;
        }

        // Methods

        public void LoadRecur(Recur Recur)
        {
            this.Recur = Recur;
            recurBindingSource.DataSource = this.Recur;
            UpdateRecurInfo();
        }

        private void UpdateRecurInfo()
        {
            if (Recur.Active)
            {
                info_Label.Text =
                    string.Format("Starting: {0:dd MMM yyyy}", Recur.RecurDate) + "\r\n" +
                    string.Format("Next Date: {0:dd MMM yyyy}", Recur.GetNextDate()) + "\r\n" +
                    "Recurring: " + Recur.RecurType.ToString();
            }
            else
            {
                info_Label.Text = "No Recurrence";
                info_Label.ForeColor = ThemeColors.SubText;
            }

            info_Label.Update();
        }

        // Events

        private void recur_Button_Click(object sender, EventArgs e)
        {
            using (Forms.Recur_Editor recurForm = new Forms.Recur_Editor(Recur))
            {
                recurForm.ShowDialog();
                Recur = recurForm.Recur;
            }

            UpdateRecurInfo();
        }

        private void activeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            activeCheckBox.CheckedChanged -= activeCheckBox_CheckedChanged;

            Recur.Active = !Recur.Active;
            UpdateRecurInfo();

            activeCheckBox.CheckedChanged += activeCheckBox_CheckedChanged;
        }
    }
}
