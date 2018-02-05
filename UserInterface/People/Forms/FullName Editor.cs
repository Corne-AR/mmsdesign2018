using AMS.Data.People;
using Data.People;
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
    public partial class FullName_Editor : Form
    {
        Person oldPerson;
        Person Person;

        public FullName_Editor(Person Person)
        {
            InitializeComponent();

            Person = new Person();

            this.Person = Person;
            this.oldPerson = Person;

            personBindingSource.DataSource = this.Person;

            if (this.Person.Title == "" || this.Person.Title == null)
                Person.Title = "Mr.";

            footer1.UpdateFooterText("Full Name");
        }

        private void ok_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            Person = oldPerson;
            this.Close();
        }
    }
}
