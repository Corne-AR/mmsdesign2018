using AMS.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Main;

namespace MMS_Design
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool started = false;
            SetAMSDefaults();
            bool amsStarted = AMS.AMS_Manager.StartUp();

            //AMS.Application.Start();

            //QuickBar.Forms.QuickBarForm quickBar;

            using (StartUp startUP = new StartUp())
            {
                startUP.ShowDialog();
                started = startUP.AMSStarted;
                if (startUP.DoUpdates) return;

                //quickBar = new QuickBar.Forms.QuickBarForm();
                //quickBar.Show();
            }


            if (started)
            {
                try
                {
                    Application.Run(new MainForm());
                    AMS.Suite.SuiteManager.SavePreferences();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        internal static void SetAMSDefaults()
        {
            Scheduling.WeekSelection = false;
            Scheduling.ScheduleDuration = new TimeSpan(1, 0, 0, 0);
            Users.Limit = 2;
            AMS.Settings.Program.Name = "MMS Design";
            AMS.Settings.Users.UseFastLogin = true;
            AMS.Settings.Security.Admin = new AMS.Data.Users.NetworkUser()
            {
                Username = "koos",
                Password = "boos"
            };
            Security.UseLicense = false;
            Security.UseEncryption = false;
        }
    }
}