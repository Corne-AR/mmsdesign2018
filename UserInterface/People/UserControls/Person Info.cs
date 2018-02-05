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
using Data.People;

namespace UserInterface.People.UserControls
{
    public partial class Person_Info : UserControl
    {
        Person person = new Person();

        public Person_Info()
        {
            InitializeComponent();
        }

        public Person_Info(Person Person)
        {
            InitializeComponent();
            LoadPerson(Person);
        }

        // Load

        private void Person_Info_Load(object sender, EventArgs e)
        {
            #region Theme Colors

            this.BackColor = ThemeColors.ControlList;
            ThemeColors.SetControls(this.Controls);

            #endregion

            SetColors();
        }

        // Methods
        private void LoadPerson(Person person)
        {
            this.person = person;
            personBindingSource.DataSource = this.person;

            if (person.DisplayNickName)
                name_Label.Text = person.NickName;
            else
            {
                string name = "";
                if (person.Title != null && person.Title != "") name = person.Title + " ";
                name_Label.Text = name + person.FirstName + " " + person.LastName;
            }

            SetColors();
        }

        private void SetColors()
        {
            person_ToolStripMenuItem.Text = person.DisplayName;
            person_ToolStripMenuItem.BackColor = ThemeColors.Primary;
            person_ToolStripMenuItem.ForeColor = ThemeColors.PrimaryText;

            if (person.ID == Data.DMS.ClientManager.CurrentData.MainPersonID)
            {
                this.BackColor = ThemeColors.MenuBorder;
                this.ForeColor = ThemeColors.MenuBorderText;
                name_Label.ForeColor = ThemeColors.MenuBorderText;
                contactNumber_Label1.ForeColor = ThemeColors.MenuBorderText;
            }

            if (person.ID == Data.DMS.ClientManager.CurrentData.AccountantID)
            {
                this.BackColor = ThemeColors.Menu;
                this.ForeColor = ThemeColors.MenuText;
                name_Label.ForeColor = ThemeColors.MenuText;
                contactNumber_Label1.ForeColor = ThemeColors.MenuText;
            }
        }

        // Events

        private void DeleteFromDB_Click(object sender, EventArgs e)
        {
            Data.DMS.PeopleManager.Delete("Are you sure you want to remove " + person.DisplayName + "?", person);
        }

        private void RemoveFromList_Click(object sender, EventArgs e)
        {
            var client = Data.DMS.ClientManager.CurrentData;
            client.PeopleIDList.Remove(person.ID);
            if (client.MainPersonID == person.ID) client.MainPersonID = null;
            if (client.AccountantID == person.ID) client.AccountantID = null;
            client.Save("Removed " + person.DisplayName, false, false);
        }

        private void Email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Data.DMS.MailManager.SendGeneralMail(Data.DMS.ClientManager.CurrentData.Account, person.DisplayName, email_LinkLabel.Text);
        }

        private void RemoveMainPerson_Click(object sender, EventArgs e)
        {
            Data.DMS.ClientManager.CurrentData.MainPersonID = null;
            Data.DMS.ClientManager.CurrentData.Save(person.DisplayName + "was removed as Main Contact", false, true);
        }

        private void SetMainContact_Click(object sender, EventArgs e)
        {
            Data.DMS.ClientManager.CurrentData.MainPersonID = this.person.ID;
            Data.DMS.ClientManager.CurrentData.Save("Main Contact set as " + person.DisplayName, false, true);
        }

        private void SetPurchaseOrderContact_Click(object sender, EventArgs e)
        {
            Data.DMS.ClientManager.CurrentData.PurchaseOrderContactID = this.person.ID;
            Data.DMS.ClientManager.CurrentData.Save("Purchase Order Contact set as " + person.DisplayName, false, true);
        }

        private void EditPerson_Click(object sender, EventArgs e)
        {
            using (Forms.PersonEditor f = new Forms.PersonEditor(person))
            {
                f.ShowDialog();
                person = f.Person;
            }
        }

        private void SetAccountant_Click(object sender, EventArgs e)
        {
            Data.DMS.ClientManager.CurrentData.AccountantID = this.person.ID;
            Data.DMS.ClientManager.CurrentData.Save("Accountant set as " + person.DisplayName, false, true);
        }

        private void RemoveAccountatnt_click(object sender, EventArgs e)
        {

            Data.DMS.ClientManager.CurrentData.AccountantID = null;
            Data.DMS.ClientManager.CurrentData.Save(person.DisplayName + "was removed as Accountant", false, true);
        }

        private void RemovePOContact_Click(object sender, EventArgs e)
        {
            Data.DMS.ClientManager.CurrentData.PurchaseOrderContactID = null;
            Data.DMS.ClientManager.CurrentData.Save(person.DisplayName + "was removed as PO Contact", false, true);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            removePurchaseOrderContact_ToolStripMenuItem.Visible = Data.DMS.ClientManager.CurrentData.Catagory == "Supplier";
            setPurchaseOrderContact_ToolStripMenuItem.Visible = Data.DMS.ClientManager.CurrentData.Catagory == "Supplier";
        }
    }
}