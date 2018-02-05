using AMS;
using Data.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS_Certificate.Forms
{
    public partial class Course_Attendees : Form
    {
        public Course_Attendees()
        {
            InitializeComponent();

            #region ThemeColors

            this.footer1.UpdateFooterText("Course Attendees");
            panel1.BackColor = ThemeColors.Menu;

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.BackColor = ThemeColors.Menu;
                }
            }

            #endregion

            LoadCourse_Attendees();
        }

        public Course_Attendees(List<Attendee> AttendeeList)
        {
            InitializeComponent();

            #region ThemeColors

            this.footer1.UpdateFooterText("Course Attendees");
            panel1.BackColor = ThemeColors.Menu;

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.BackColor = ThemeColors.Menu;
                }
            }

            #endregion

            LoadCourse_Attendees();

            attendeeListBindingSource.DataSource = AttendeeList;
        }

        // Methods

        private void LoadCourse_Attendees()
        {
            attendeeListDataGridView.KeyDown += DataGridView_KeyDown;
        }

        private void PastClipboard()
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn c in attendeeListDataGridView.Columns)
                dt.Columns.Add(c.Name);
            try
            {
                foreach (DataRow row in AMS.Utilities.Controls.DatagridView.PasteClipboard(dt).Rows)
                {
                    Data.Schedule.Attendee attendee = new Data.Schedule.Attendee()
                    {
                        FullName = row.ItemArray[0].ToString(),
                        CPD = row.ItemArray[1].ToString(),
                        CourseDescription = row.ItemArray[2].ToString(),
                        DateOne = row.ItemArray[3].ToString(),
                        DateTwo = row.ItemArray[4].ToString()
                    };

                    attendee.FullName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(attendee.FullName.ToLower());

                    attendeeListBindingSource.Add(attendee);
                }
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show("Please only select the following columns from Excel\r\n\r\n" +
                    "FullName | CPD | CourseName | Date \r\n\r\n" +
                    "Date column needs to be in a system date format\r\n\r\n" +
                    ex.Message, AMS.MessageType.Error);
            }
        }

        // Events

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.V && (e.Control || e.Alt))
            {
                PastClipboard();
            }
        }
    
        private void ok_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PastClipboard();
        }
    }
}
