using AMS;
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
    public partial class PersonEditor : Form
    {
        private Person person;
        public Person Person
        {
            get { return person; }
        }

        // Constructors

        public PersonEditor(Person Person)
        {
            InitializeComponent();

            this.person = Person;
        }

        // Load

        private void PersonEditor_Load(object sender, EventArgs e)
        {
            header1.UseControls(this, false, false, true);
            ThemeColors.SetBorders(this);
           Data.DMS.PeopleManager.OnSaved_Event += personel_Editor_Basic1_CloseEvent;
           Data.DMS.PeopleManager.OnSaveCanceled_Event += personel_Editor_Basic1_CloseEvent;
            personel_Editor_Basic1.SetPerson(person, EditMode.Edit);
        }

        #region Drop Shadow

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


        // Methods

        // Events

        void personel_Editor_Basic1_CloseEvent(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personel_Editor_Basic1_Load(object sender, EventArgs e)
        {

        }
    }
}
