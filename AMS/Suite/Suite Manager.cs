using AMS.Data;
using AMS.Data.IO;
using AMS.Suite.Data;
using AMS.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite
{
    public static class SuiteManager
    {
        // Less irritation to user on failed save
        private static bool failed = false;

        public static LocalPreferences Preferences;
        internal static aFile preferencesFile;

        /// <summary>
        /// Company specific data Profile
        /// </summary>
        public static Profile Profile { get; set; } = new Profile();
        internal static aFile profileFileName;


        public static void LoadPrefernces()
        {
            // Preferences
            Preferences = new LocalPreferences();
            preferencesFile = new aFile("LocalPreferences", AMS.Settings.Program.Directories.LocalData, DataType.Xml);

            try
            {
                Preferences = (LocalPreferences)AMS.IO.XML_v1.Reader < LocalPreferences>(preferencesFile.FullName, false);
            }
            catch { Preferences = null; } // will fail if on 1st run for example

            if (Preferences == null) Preferences = new LocalPreferences(); 
        }

        public static bool LoadProfile()
        {
            // Profile
            Profile = new Profile();
            profileFileName = new aFile( "AMS Profile", AMS.Settings.Program.Directories.Data,AMS.Data.DataType.Xml);

            try
            {
                Profile = (Profile)AMS.IO.XML_v1.Reader<Profile>(profileFileName.FullName, false);
            }
            catch { Profile = null; } // will fail if on 1st run for example

            if (Profile == null) Profile = new Profile();
            if (Profile.ForexList == null) Profile.ForexList = new List<string>();
            if (Profile.ForexList.Count == 0) Profile.ForexList.Add("ZAR");

            return true;
        }

        public static void SaveProfile()
        {
            try
            {
                AMS.IO.XML_v1.Writter<Profile>(Profile, profileFileName, "", true, false);
                Profile = (Profile)AMS.IO.XML_v1.Reader<Profile>(profileFileName.FullName, false);

                failed = false;
            }
            catch (Exception ex)
            {
                if (!failed)
                {
                    failed = true;
                    MessageBox_v2.Show("Cannot Save Profile\r\n" + ex.Message, MessageType.Error);
                }
            }
        }

        public static void SavePreferences()
        {
            try
            {
                AMS.IO.XML_v1.Writter<LocalPreferences>(Preferences, preferencesFile, "", true, false);
                Preferences = (LocalPreferences)AMS.IO.XML_v1.Reader<LocalPreferences>(preferencesFile.FullName, false);

                failed = false;
            }
            catch (Exception ex)
            {
                if (!failed)
                {
                    failed = true;
                    MessageBox_v2.Show("Cannot Save Local Preferences\r\n" + ex.Message, MessageType.Error);
                }
            }
        }

        public static string PreferencesFileName { get { return preferencesFile.FullName; } }
    }
}
