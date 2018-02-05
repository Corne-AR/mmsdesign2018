using AMS;
using AMS.Data.People;
using System;
using System.Collections;
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
    public partial class Select_People : Form
    {
        private string account;

        private HashSet<string> peopleIDList;
        public HashSet<string> PeopleIDList { get { return peopleIDList; } }
        private HashSet<string> oldPeopleIDList;

        private HashSet<PeopleCheckList> oldPeopleCheckList;

        // Constructors

        public Select_People(HashSet<string> PeopleIDList)
        {
            InitializeComponent();

            this.peopleIDList = PeopleIDList;
            this.oldPeopleIDList = PeopleIDList;
        }

        // Load

        private void Select_People_Load(object sender, EventArgs e)
        {
            #region Combox Filter

            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            comboBox1.Items.Add("");
            List<string> roleList = new List<string>();

            foreach (var i in Data.DMS.PeopleManager.GetDataList())
            {
                bool add = true;

                foreach (var ri in roleList)
                    if (ri == i.Role)
                        add = false;

                if (add) roleList.Add(i.Role);
            }

            foreach (string i in roleList)
            {
                if (i != null) comboBox1.Items.Add(i);
            }

            #endregion

            if (Data.DMS.PeopleManager == null) return;

            if (peopleIDList == null) peopleIDList = new HashSet<string>();
            oldPeopleCheckList = new HashSet<PeopleCheckList>();

            // The list that came from constructor should contain 'checked' people. So, I am adding them here by default as checked
            foreach (var id in peopleIDList)
            {
                var p = new PeopleCheckList();

                p.ID = id;
                p.Checked = true;

                oldPeopleCheckList.Add(p);
            }

            LoadPeople();
        }

        // Methods

        private void LoadPeople()
        {
            HashSet<PeopleCheckList> peopleCheckList = new HashSet<PeopleCheckList>();
            people_CheckedListBox.Items.Clear();

            // Make everyone in the Checklist as checked in the display list
            foreach (var p in Data.DMS.PeopleManager.GetDataList())
            {
                PeopleCheckList person = new PeopleCheckList();
                person.ID = p.ID;

                if (oldPeopleCheckList != null)
                {
                    var queryPeopleCheckList = (from i in oldPeopleCheckList
                                                where i != null && i.PersonInfo != null && (i.PersonInfo == p.DisplayName + " - " + p.ContactNumber + " - " + p.Email)
                                                select i).FirstOrDefault();

                    person.Checked = (queryPeopleCheckList != null);
                }
             
                peopleCheckList.Add(person);
            }

            // Finally add items to display list
            people_CheckedListBox.Items.Clear();
            foreach (var p in peopleCheckList)
                if(p.PersonInfo != null) people_CheckedListBox.Items.Add(p.PersonInfo, p.Checked);
        }

        private bool SaveIdList()
        {
            var saveList = new HashSet<PeopleCheckList>();
            peopleIDList = new HashSet<string>();

            // Get people for the display list
            foreach (var pi in people_CheckedListBox.CheckedItems)
            {
                var person = Data.DMS.PeopleManager.GetData(i => i.DisplayName + " - " + i.ContactNumber + " - " + i.Email == pi.ToString());
                var p = new PeopleCheckList();

                p.ID = person.ID;
                p.Checked = true;

                saveList.Add(p);
            }

            foreach (var i in saveList)
                peopleIDList.Add(i.ID);

            return true;
        }

        // Events

        private void Search_Event(object sender, EventArgs e)
        {
            string search = comboBox1.Text.ToLower();

            int index = people_CheckedListBox.FindString(search, -1);
            people_CheckedListBox.TopIndex = index;
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            peopleIDList = oldPeopleIDList;
            this.Close();
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            if (SaveIdList())
                this.Close();
        }

        private void addPerson_Button_Click(object sender, EventArgs e)
        {
            using (Forms.PersonEditor f = new PersonEditor(new Data.People.Person()))
            {
                f.ShowDialog();
                comboBox1.Text = f.Person.DisplayName;
                oldPeopleCheckList.Add(new PeopleCheckList()
                {
                    Checked = true,
                    ID = f.Person.ID
                });

                string search = comboBox1.Text.ToLower();

                int index = people_CheckedListBox.FindString(search, -1);
                people_CheckedListBox.TopIndex = index;
            }

            LoadPeople();
        }

        private class PeopleCheckList
        {
            public bool Checked { get; set; }
            public string PersonInfo
            {
                get
                {
                    var p = Data.DMS.PeopleManager.GetData(i => i.ID == ID);
                    if (p == null) return null;
                    return p.DisplayName + " - " + p.ContactNumber + " - " + p.Email;
                }
            }
            public string ID { get; set; }
            public string HashID { get { return ID + ""; } }

            public override bool Equals(object obj)
            {
                var other = obj as PeopleCheckList;
                if (other == null)
                {
                    return false;
                }
                return HashID == other.HashID;
            }

            public override int GetHashCode()
            {
                return (HashID).GetHashCode();
            }

        }
    }
}