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
using Data.People;

namespace UserInterface.People.UserControls
{
    public partial class Person_Name : UserControl
    {
        public Person Person;

        public Person_Name()
        {
            InitializeComponent();

            Person = new Person();
        }

        public Person_Name(Person Person)
        {
            InitializeComponent();

            this.Person = Person;

            fullName_label.Text = Person.FirstName + " " + Person.LastName;
        }

        public Person_Name(string ID)
        {
            InitializeComponent();

            this.Person = Data.DMS.PeopleManager.GetData(i => i.ID == ID);

            fullName_label.Text = Person.FirstName + " " + Person.LastName;
        }

        public Person_Name(Person Person, EventHandler FullName_ClickEvent)
        {
            InitializeComponent();

            this.Person = Person;

            fullName_label.Text = Person.FirstName + " " + Person.LastName;

            this.Click += FullName_ClickEvent;
        }

        private void Person_Name_Load(object sender, EventArgs e)
        {
        }
    }
}
