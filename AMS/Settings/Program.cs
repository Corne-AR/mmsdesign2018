using AMS.Data.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Settings
{
    public static class Program
    {
        public static string Name = "AMS";
        public static WorkMode WorkMode = AMS.WorkMode.Demo;
        public static int DemoLimit = 5;
        public static bool CheckUpdateAtStartUp = false;
        public static string UpdateURL = null;
        public static AMS.Data.IO.Directories Directories = new AMS.Data.IO.Directories("Data\\");
        public static AMS.Data.IO.Directories Archives = new AMS.Data.IO.Directories("Archives\\");
        public static string DiscDrive = "D:";

        public static string Version
        {
            get
            {
                var version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
                var versionString = version.Major + "." + version.Minor + "." + version.Build;

                return versionString;
            }
        }

        public static void SetDataRootDirectory()
        {
            if (AMS.Users.UserManager.LocalData.DirectoryRootData == null) AMS.Users.UserManager.LocalData.DirectoryRootData = @"C:\AMS\";

            var msgBox = AMS.MessageBox_v2.Show("Use '" + Settings.Program.Directories.RootData + "' as Data location for " + Settings.Program.Name + "?", MessageType.Question);

            if (msgBox == MessageOut.YesOk)
            {
            }
            else
            {
                using (System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    folderDialog.Description = Settings.Program.Name + " Data Location";
                    folderDialog.ShowNewFolderButton = true;
                    folderDialog.SelectedPath = AMS.Users.UserManager.LocalData.DirectoryRootData;
                    folderDialog.ShowDialog();

                    Directories.RootData = folderDialog.SelectedPath + "\\";
                }

                SetDataRootDirectory();
            }

            AMS.Users.UserManager.LocalData.DirectoryRootData = Directories.RootData;
            AMS.Users.UserManager.SaveLocalData();
        }
    }
}