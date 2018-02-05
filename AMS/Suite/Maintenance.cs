using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite
{
    public static class Maintenance
    {
        public static void DeletePreferences()
        {
            DeleteFile(AMS.Suite.SuiteManager.preferencesFile.FullName);
            DeleteFile(AMS.Users.UserManager.localDataFileName.FullName);
        }

        private static void DeleteFile(string FileName)
        {
            try { File.Delete(FileName); }
            catch { }
        }
    }
}
