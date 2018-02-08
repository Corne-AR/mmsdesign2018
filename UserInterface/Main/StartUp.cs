using AMS;
using AMS.Data.People;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Main
{
    public partial class StartUp : Form
    {
        public bool AMSStarted = AMS.AMS_Manager.HasLoaded;
        public bool DoUpdates = false;

        public StartUp()
        {
            InitializeComponent();
            ThemeColors.SetBorders(this);

            dbLoation_textBox.BackColor = footer1.BackColor;
            dbLoation_textBox.ForeColor = AMS.ThemeColors.Primary;
            dbLoation_textBox.Text = AMS.Settings.Program.Directories.RootData;

            version_TextBox.Text = $"Version {AMS.Settings.Program.Version}";
            version_TextBox.BackColor = footer1.BackColor;
            version_TextBox.ForeColor = AMS.ThemeColors.Primary;
        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            // this.pictureBox1.BackgroundImage = global::UserInterface.Properties.Resources.mail;

            if (AMS.TemplateManager.SplashScreenList.Count > 0)
            {
                var r = new System.Random((int)DateTime.Now.Ticks);
                int nr = r.Next(0, AMS.TemplateManager.SplashScreenList.Count);
                this.pictureBox1.BackgroundImage = new Bitmap(AMS.TemplateManager.SplashScreenList[nr]);

                title_Label.Visible = false;
            }
            else
            {
                this.pictureBox1.Visible = false;
                title_Label.Visible = true;
            }
        }

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

        private void StartUp_Shown(object sender, EventArgs e)
        {
            LoadProgram();
        }

        private void LoadProgram()
        {
            System.Windows.Forms.Application.DoEvents();
            Status("Starting " + AMS.Settings.Program.Name + "...");

            // Setting Defaults

            if (AMSStarted)
            {

                ///////////////////////////////////

                Status("Checking for Update...");
                DoUpdates = Data.Utilities.ProgramUtilities.CheckForUpdate(false, "MMSDesign.Installer.msi");
                if (DoUpdates) { this.Close(); return; };

                Status("Loading People...");
                AMSStarted = DMS.PeopleManager.LoadData();

                Status("Loading Clients...");
                AMSStarted = DMS.ClientManager.LoadData();

                Status("Loading Products...");
                AMSStarted = DMS.ProductManager.LoadData();

                Status("Loading Transactions...");
                AMSStarted = DMS.TransactionManager.LoadData();
                AMSStarted = DMS.QuoteManager.LoadData();

                Status("Loading Accounts...");
                DMS.AccountsManager.GetReceiptData();

                Status("Checking for Data Updates...");
                Updates.CheckforUpdates();

                Status("Loading Report Manager...");
                ReportManager.StartUp();

                // Set Default Data
                if (AMS.Suite.SuiteManager.Preferences.ClientManager.LastAccount != null) DMS.ClientManager.SetCurrent(i => i.Account == AMS.Suite.SuiteManager.Preferences.ClientManager.LastAccount);
            }

            System.Windows.Forms.Application.DoEvents();
            timer1.Start();
        }

        private void Status(string status)
        {
            footer1.UpdateFooterText(status);
            System.Threading.Thread.Sleep(250);
            System.Windows.Forms.Application.DoEvents();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
    }
}
