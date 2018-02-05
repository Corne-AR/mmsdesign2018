using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMS.Data.People;
using AMS;
using AMS.Data;
using Data.People;

namespace UserInterface.People.UserControls
{
    public partial class Personel_Editor_Basic : UserControl
    {
        AMS.EditMode editMode = new AMS.EditMode();
        public Person Person { get { return person; } }
        private Person person;
        private Person OldPerson;
        string oldRole = "";
        Timer timer = new Timer();

        public event EventHandler CloseEvent;

        // Constructor

        public Personel_Editor_Basic()
        {
            InitializeComponent();
        }

        // Load

        private void Personnel_Editor_Basic_Load(object sender, EventArgs e)
        {
            #region Theme Colors

            nickNameStatus_Label.ForeColor = AMS.ThemeColors.SubText;

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(panel1, ThemeColors.ControlType.Menu);

            #endregion

            if (person == null) person = new Person();
            if (OldPerson == null) OldPerson = new Data.People.Person();

            timer = new Timer();
            timer.Interval = 800;
            timer.Tick += timer_Tick;

            this.newSave_Button.Click += CloseEvent;         // Use to close an Form if used part as an Editor
            this.editCancel_Button.Click += CloseEvent;     // Use to close an Form if used part as an Editor

            personBindingSource.DataSource = this.person;

            editMode = AMS.EditMode.Normal;
            CheckEditMode();
        }

        // Methods

        public void SetPerson(Person Person)
        {
            this.person = Person;
            this.OldPerson = Person;
            oldRole = Person.Role;
            UpdatePerson(this.person);
        }

        public void SetPerson(Person Person, EditMode EditMode)
        {
            editMode = EditMode;
            SetPerson(Person);
            CheckEditMode();
        }

        /// <summary>
        /// Main Loading Poit for Person Data from People Class
        /// </summary>
        /// <param name="Person">People Data Class</param>
        public void UpdatePerson(Person Person)
        {
            if (Person == null) Person = new Person();

            this.person = Person;
            this.OldPerson = Person;

            personBindingSource.DataSource = this.person;

            // Set Nickname
            if (this.person.DisplayNickName) nickNameStatus_Label.Visible = true;
            else nickNameStatus_Label.Visible = false;

            string text = "";

            if (this.person.DisplayNickName)
                text = this.person.NickName;
            else
                text = this.person.FirstName + " " + this.person.LastName;

            fullName_TextBox.Text = text.Trim();

            if (this.person.DisplayNickName) nickNameStatus_Label.Visible = true;
            else nickNameStatus_Label.Visible = false;

            SetControls();
        }

        private void CheckContractor()
        {
            personBindingSource.DataSource = person;

            if (person.Role == "Contractor" && (person.CertificateNr == null || person.CertificateNr == ""))
            {
                if (AMS.MessageBox_v2.Show("Please enter '" + person.DisplayName + "' certificate number.", person.CertificateNr) == AMS.MessageOut.YesOk)
                {
                    if (AMS.MessageBox_v2.MessageValue != null && AMS.MessageBox_v2.MessageValue.Count() > 0) person.CertificateNr = AMS.MessageBox_v2.MessageValue;
                }
            }

        }

        private void CheckEditMode()
        {
            bool readOnly = true;

            CheckContractor();

            switch (editMode)
            {
                case AMS.EditMode.Normal:
                    newSave_Button.Text = "New";
                    editCancel_Button.Text = "Edit";
                    readOnly = true;
                    break;
                case AMS.EditMode.New:
                    fullName_TextBox.Text = "";
                    newSave_Button.Text = "Save";
                    editCancel_Button.Text = "Cancel";
                    readOnly = false;
                    break;
                case AMS.EditMode.Edit:
                    newSave_Button.Text = "Save";
                    editCancel_Button.Text = "Cancel";
                    readOnly = false;
                    break;
            }

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox)) ((TextBox)c).ReadOnly = readOnly;
                if (readOnly && c.GetType() == typeof(ComboBox)) ((ComboBox)c).Enabled = readOnly;
                // else if (tb.GetType() == typeof(ComboBox)) ((ComboBox)tb).DropDownStyle = ComboBoxStyle.DropDown;

                if (c.GetType() != typeof(Button))
                {
                    if (editMode == AMS.EditMode.Normal) c.ForeColor = ThemeColors.ControlText;
                    if (editMode == AMS.EditMode.Edit) c.ForeColor = ThemeColors.Red;
                    if (editMode == AMS.EditMode.New) c.ForeColor = ThemeColors.Green;
                }
            }

            SetControls();
        }

        private void SetControls()
        {
            remove_Button.Enabled = (editMode == EditMode.New) || (person != null && person.ID != null);
            editCancel_Button.Enabled = (editMode == EditMode.New) || (person != null && person.ID != null);
        }

        #region Full Name Edit
        // FullName Edit
        private void fullName_button_Click(object sender, EventArgs e)
        {
            using (UserInterface.People.Forms.FullName_Editor f = new Forms.FullName_Editor(person))
                f.ShowDialog();

            UpdatePerson(person);
        }

        // FullName Update
        private void fullName_TextBox_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                person.FirstName = "";
                person.LastName = "";

                if (string.IsNullOrEmpty(fullName_TextBox.Text))
                {
                    timer.Stop();
                    return;
                }

                var value = fullName_TextBox.Text?.ToString().Split('<');
                string name = null;

                if (value?.Length > 1)
                {
                    if (string.IsNullOrEmpty(person.Email))
                    {
                        var evalue = value[1].Split('>');
                        person.Email = evalue[0];
                    }
                    name = value[0];
                }
                else name = fullName_TextBox.Text?.ToString();

                // String groups separated by ' ' 
                var fullname = name?.Split(' ');
                if (fullname.Count() > 0)
                {
                    if (person.DisplayNickName == false)
                    {
                        person.FirstName = fullname[0];
                        if (fullname.Count() > 1)
                        {
                            for (int i = 1; i < fullname.Count(); i++)
                            {
                                person.LastName += fullname[i] + " ";
                            }
                        }
                    }
                    person.FirstName = person.FirstName?.Trim();
                    person.LastName = person.LastName?.Trim();

                    if (person.DisplayNickName) person.NickName = fullName_TextBox.Text;
                }
                
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.ToString());
            }

            personBindingSource.ResetBindings(false);
            fullName_TextBox.TextAlignChanged -= fullName_TextBox_TextChanged;
            fullName_TextBox.Text = person.DisplayName;
            fullName_TextBox.TextAlignChanged += fullName_TextBox_TextChanged;

            timer.Stop();
        }

        #endregion

        // Events

        private void NewSave_Click(object sender, EventArgs e)
        {
            if (newSave_Button.Text == "New")
            {
                editMode = EditMode.New;
                Data.DMS.PeopleManager.SetCurrent(OldPerson);
                person = new Person();
            }

            if (newSave_Button.Text == "Save")
            {
                person.FirstName = person.FirstName.Trim();
                person.LastName = person.LastName.Trim();
                CheckContractor();
                person.Save();
                editMode = EditMode.Normal;

                person = Data.DMS.PeopleManager.GetData(i => i.ID == person.ID);
                personBindingSource.DataSource = person;
            }

            CheckEditMode();
        }

        private void EditCancel_Click(object sender, EventArgs e)
        {
            if (editCancel_Button.Text == "Edit")
            {
                Data.DMS.PeopleManager.SetCurrent(OldPerson);
                person = OldPerson;
                editMode = EditMode.Edit;
            }

            if (editCancel_Button.Text == "Cancel")
            {
                Data.DMS.PeopleManager.SaveCancel();
                person = OldPerson;
                editMode = EditMode.Normal;
            }

            CheckEditMode();
        }

        private void remove_Button_Click(object sender, EventArgs e)
        {
            if (Data.DMS.PeopleManager.Delete("Are you sure you want to remove " + person.DisplayName + "?", person))
                person = new Data.People.Person();

            SetPerson(person);
        }

        private void close_Button_Click(object sender, EventArgs e)
        {

        }
    }
}