using AMS.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utilities
{
    public static class ProgramUtilities
    {
        public static bool CheckForUpdate(bool ShowNotFound, string FileName)
        {
            var file = new FileInfo(AMS.Settings.Program.Directories.RootData + FileName); //"MMS Design Installer.msi");

            bool hasUpdate = (UserManager.LocalData.UpdateDate == null || UserManager.LocalData.UpdateDate < new DateTime(2000, 1, 1) ||
                file.LastWriteTime > UserManager.LocalData.UpdateDate);

            string message = "There is an update available\r\n\r\n" +
                "New Update - " + string.Format("{0:dd MMMM yyyy}", file.LastWriteTime) + "\r\n" +
                "Last update - " + string.Format("{0:dd MMMM yyyy}", UserManager.LocalData.UpdateDate);

            if (hasUpdate && file.Exists)
            {
                UserManager.LocalData.UpdateDate = file.LastWriteTime;
                UserManager.SaveLocalData();
                System.Diagnostics.Process.Start(file.FullName);
            }
            else
            {
                hasUpdate = false;
                if (ShowNotFound) AMS.MessageBox_v2.Show("No updates found.", 1500);
            }

            return hasUpdate;
        }
    }
}
