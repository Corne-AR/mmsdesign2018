using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Utilities.Forms
{
    public partial class DatePicker : Form
    {
        public DateTime DateTimeValue;

        private DateTime newDateTime;
        private DateTime oldDateTime;

        string note;

        //public DatePicker()
        //{
        //    InitializeComponent();
        //}

        public DatePicker(string Note, DateTime OriginalDateTime)
        {
            InitializeComponent();

            oldDateTime = OriginalDateTime;
            DateTimeValue = OriginalDateTime;
            newDateTime = OriginalDateTime;

            note = Note;
        }

        // Load

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

        private void DatePicker_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            header1.UseControls(this, false, false, true);

            #endregion

            footer1.UpdateFooterText(note);

            SetLabels();
        }

        // Methods

        private void SetLabels()
        {
            oldDate_Label.Text = string.Format("{0:dd MMMM yyyy}", oldDateTime);
            newDate_Label.Text = string.Format("{0:dd MMMM yyyy}", newDateTime);
        }

        // Events

        private void Ok_Event(object sender, EventArgs e)
        {
            DateTimeValue = newDateTime;
            this.Close();
        }

        private void Cancel_Event(object sender, EventArgs e)
        {
            DateTimeValue = oldDateTime;
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            newDateTime = monthCalendar1.SelectionStart;
            SetLabels();
        }
    }
}
