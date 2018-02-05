using AMS.Data.Scheduling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Scheduling.Forms
{
    public partial class Recur_Editor : Form
    {
        // Variables

        public Recur Recur;

        // Constructors

        public Recur_Editor()
        {
            InitializeComponent();

            footer1.UpdateFooterText("Recur");
        }

        public Recur_Editor(Recur Recur)
        {
            InitializeComponent();

            footer1.UpdateFooterText("Recur");

            this.Recur = Recur;
        }

        // Load

        private void Recur_Editor_Load(object sender, EventArgs e)
        {
            #region Theme colors

            this.BackColor = ThemeColors.WorkSpace;
            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(this.panel1.Controls);
            ThemeColors.SetControls(this.panel2.Controls);
            ThemeColors.SetControls(this.panel3.Controls);
            ThemeColors.SetControls(this.panel4.Controls);

            ThemeColors.SetControls(startDateTime_Label, AMS.ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(recurring_Label, AMS.ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(type_Label, AMS.ThemeColors.ControlType.Menu);

            ThemeColors.SetBorders(this);
            header1.UseControls(this, false, false, true);

            #endregion

            #region AMS Defaults

            daily_RadioButton.Visible = AMS.Settings.Scheduling.Recur.UseDaily;
            weekly_RadioButton.Visible = AMS.Settings.Scheduling.Recur.UseWeekly;
            monthly_RadioButton.Visible = AMS.Settings.Scheduling.Recur.UseMonthly;
            yearly_RadioButton.Visible = AMS.Settings.Scheduling.Recur.UseYearly;

            if (Recur == null)
            {
                if (AMS.Settings.Scheduling.Recur.RecurType == RecurType.Daily) daily_RadioButton.Select();
                if (AMS.Settings.Scheduling.Recur.RecurType == RecurType.Weekly) weekly_RadioButton.Select();
                if (AMS.Settings.Scheduling.Recur.RecurType == RecurType.Monthly) monthly_RadioButton.Select();
                if (AMS.Settings.Scheduling.Recur.RecurType == RecurType.Yearly) yearly_RadioButton.Select();
            }
            #endregion

            if (Recur == null)
            {
                Recur = new Recur();
                Recur.RecurDate = DateTime.Now;
            }

            recurBindingSource.DataSource = Recur;

            if (Recur.RecurType == RecurType.Daily) daily_RadioButton.Checked = true;
            if (Recur.RecurType == RecurType.Weekly) weekly_RadioButton.Checked = true;
            if (Recur.RecurType == RecurType.Monthly) monthly_RadioButton.Checked = true;
            if (Recur.RecurType == RecurType.Yearly) yearly_RadioButton.Checked = true;

            if (Recur.RecurDate > new DateTime(1900, 1, 1)) startDateTimeMonthCalendar.SetDate(Recur.RecurDate);

            CheckRadioButtons();
        }

        // Methods

        private void CheckRadioButtons()
        {
            daily_Panel.Visible = false;
            weekly_Panel.Visible = false;
            monthly_Panel.Visible = false;
            yearly_Panel.Visible = false;

            if (daily_RadioButton.Checked)
            {
                daily_Panel.Visible = true;
                Recur.RecurType = RecurType.Daily;
            }

            if (weekly_RadioButton.Checked)
            {
                weekly_Panel.Visible = true;
                Recur.RecurType = RecurType.Weekly;
            }

            if (monthly_RadioButton.Checked)
            {
                monthly_Panel.Visible = true;
                Recur.RecurType = RecurType.Monthly;
            }

            if (yearly_RadioButton.Checked)
            {
                yearly_Panel.Visible = true;
                Recur.RecurType = RecurType.Yearly;
            }
        }

        // Events

        private void StartDateTimeMonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            startDateTimeMonthCalendar.DateSelected -= StartDateTimeMonthCalendar_DateSelected;

            // Select the whole week for a duration

            var monday = startDateTimeMonthCalendar.SelectionStart;

            if (AMS.Settings.Scheduling.WeekSelection)
            {
                while (monday.DayOfWeek != DayOfWeek.Sunday)
                {
                    monday = monday.AddDays(-1);
                }
            }

            startDateTimeMonthCalendar.SelectionStart = monday;
            startDateTimeMonthCalendar.SelectionEnd = monday.AddTicks(AMS.Settings.Scheduling.ScheduleDuration.Ticks);

            startDateTimeMonthCalendar.DateSelected += StartDateTimeMonthCalendar_DateSelected;
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (daily_RadioButton.Checked) Recur.RecurType = RecurType.Daily;
            if (weekly_RadioButton.Checked) Recur.RecurType = RecurType.Weekly;
            if (monthly_RadioButton.Checked) Recur.RecurType = RecurType.Monthly;
            if (yearly_RadioButton.Checked) Recur.RecurType = RecurType.Yearly;

            this.Close();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            CheckRadioButtons();
        }

        private void EveryNthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                everyFollowingNthNumericUpDown.Enabled = false;
                everyFollowingNthNumericUpDown1.Enabled = false;
                everyFollowingNthNumericUpDown2.Enabled = false;
                everyFollowingNthNumericUpDown3.Enabled = false;

                everyNthCheckBox.ForeColor = ThemeColors.ControlText;
                everyNthCheckBox1.ForeColor = ThemeColors.ControlText;
                everyNthCheckBox2.ForeColor = ThemeColors.ControlText;
                everyNthCheckBox3.ForeColor = ThemeColors.ControlText;

            }
            else
            {
                everyFollowingNthNumericUpDown.Enabled = true;
                everyFollowingNthNumericUpDown1.Enabled = true;
                everyFollowingNthNumericUpDown2.Enabled = true;
                everyFollowingNthNumericUpDown3.Enabled = true;

                everyNthCheckBox.ForeColor = ThemeColors.SubText;
                everyNthCheckBox1.ForeColor = ThemeColors.SubText;
                everyNthCheckBox2.ForeColor = ThemeColors.SubText;
                everyNthCheckBox3.ForeColor = ThemeColors.SubText;
            }
        }
    }
}
