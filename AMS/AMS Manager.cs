using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AMS
{
    public static partial class AMS_Manager
    {
        public static bool InDevMode = false;

        public static bool HasLoaded = false;
        // StartUp

        public static bool StartUp()
        {
            System.Windows.Forms.Application.DoEvents();

            bool hasLoaded = true;
      
            // Determine Local or Network WorkMode
            if (AMS.Settings.Users.Limit == 0) AMS.Settings.Program.WorkMode = AMS.WorkMode.Demo;
            if (AMS.Settings.Users.Limit == 1) AMS.Settings.Program.WorkMode = AMS.WorkMode.Local;
            if (AMS.Settings.Users.Limit > 1) AMS.Settings.Program.WorkMode = AMS.WorkMode.Network;

            // 1. Load/Create Company or Personal Profile
            if (!Users.UserManager.StartUp()) { return false; }
            System.Windows.Forms.Application.DoEvents();

            // Load Profile
            AMS.Suite.SuiteManager.LoadProfile();

            // 2. Check Program License
            if (Settings.Security.UseLicense) hasLoaded = Security.AMS_Security.StartUp();
            System.Windows.Forms.Application.DoEvents();

            // Loading LocalPreferences
            AMS.Suite.SuiteManager.LoadPrefernces();

            if (Settings.Program.WorkMode == WorkMode.Demo) Settings.Program.Name = Settings.Program.Name + " DEMO";
            System.Windows.Forms.Application.DoEvents();

            AMS.Utilities.Data.CleanTemp();

            HasLoaded = hasLoaded;
            return HasLoaded;
        }
    }
}