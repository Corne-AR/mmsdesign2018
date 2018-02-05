using AMS;
using AMS.Data.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.People.Forms
{
    public partial class PeopleManager : Form
    {
        List<Data.People.Person> peopleList;

        public PeopleManager()
        {
            InitializeComponent();

            footer1.UpdateFooterText("People");
        }

        // Load

        private void PeopleManager_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            this.BackColor = ThemeColors.WorkSpace;
            this.panel3.BackColor = ThemeColors.Menu;

            AMS.ThemeColors.SetControls(panel4, ThemeColors.ControlType.Menu);
            label2.BackColor = ThemeColors.Primary;
            label2.ForeColor = ThemeColors.PrimaryText;

            #endregion

            Data.DMS.PeopleManager.OnLoad_Event += PeopleLoad_Event;
            Data.DMS.PeopleManager.OnSaved_Event += PeopleLoad_Event;

            peopleList = new List<Data.People.Person>();

            UpdatePeopleList("All");
        }

        private void PeopleForm_Enter(object sender, EventArgs e)
        {
        }

        // Methods

        private void UpdatePeopleList(string filter)
        {
            Data.DMS.PeopleManager.OnLoad_Event -= PeopleLoad_Event;

            #region Filter ComboBox

            filter_comboBox.Items.Clear();

            foreach (var i in Data.DMS.PeopleManager.GetDataList())
            {
                bool add = true;

                foreach (var ci in filter_comboBox.Items)
                    if (i.Role != null && ci.ToString().Trim() == i.Role.Trim())
                        add = false;

                if (add && i.Role != null && i.Role.Trim() != "")
                    filter_comboBox.Items.Add(i.Role.Trim().ToString());
            }

            #endregion

            peopleList = Data.DMS.PeopleManager.GetDataList();
            if (filter.ToLower() == "firstname") peopleList = (from i in peopleList
                                                               orderby i.FirstName ascending
                                                               select i).ToList();
            if (filter.ToLower() == "lastname") peopleList = (from i in peopleList
                                                               orderby i.LastName ascending
                                                               select i).ToList();

            if (peopleList == null) peopleList = new List<Data.People.Person>();
            dataGridView1.DataSource = peopleList;
            Data.DMS.PeopleManager.OnLoad_Event += PeopleLoad_Event;
        }

        // Events
        
        private void PeopleLoad_Event(object sender, EventArgs e)
        {
            UpdatePeopleList("");
        }

        private void Person_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                string filter = "";

                if (e.ColumnIndex == 1) filter = "firstname";
                if (e.ColumnIndex == 2) filter = "lastname";

                UpdatePeopleList(filter);
                return;
            }

            string value = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();

            var person = Data.DMS.PeopleManager.GetData(i => i.ID == value);

            Data.DMS.PeopleManager.SetCurrent(person);

            personel_Editor_Basic1.UpdatePerson(person);
            if (person != null && person.DisplayName != null) filter_comboBox.Items.Add(person.DisplayName);
        }

        private void filter_comboBox_TextChanged(object sender, EventArgs e)
        {
            if (filter_comboBox.Text.Trim() == "") peopleList = Data.DMS.PeopleManager.GetDataList();
            else peopleList = Data.DMS.PeopleManager.GetDataList(i => 
                i.LastName.ToLower().Contains(filter_comboBox.Text.ToLower()) ||
                i.FirstName.ToLower().Contains(filter_comboBox.Text.ToLower()) || 
                i.DisplayName.ToLower().Contains(filter_comboBox.Text.ToLower())
                );

            dataGridView1.DataSource = peopleList;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            filter_comboBox.Text = "";
        }

        private void saveAll_Button_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("WARNING, this will re-save every person data\r\nWould you like to continue", MessageType.Warning) == MessageOut.YesOk)
            {
                AMS.Data.GobalManager.SuspendControls();
                AMS.Data.GobalManager.SuspendEvents();

                int nr = 0;
                int count = Data.DMS.PeopleManager.GetDataList().Count;

                foreach (var i in Data.DMS.PeopleManager.GetDataList())
                {
                    AMS.MessageBox_v2.ShowProcess("Saving " + count + " People\r\n"+ i.DisplayName, nr, count);
                    nr++;
                    i.Save(true);
                }

                AMS.MessageBox_v2.EndProcess();

                AMS.Data.GobalManager.ResumeControls();
                AMS.Data.GobalManager.ResumeEvents();
            }
        }
    }
}
