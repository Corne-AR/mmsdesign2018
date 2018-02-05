using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Utilities
{
    public class Data
    {
        internal static void CleanTemp()
        {
            processDirectory(AMS.Settings.Program.Directories.RootData + "\\Temp\\");
        }

        private static void processDirectory(string startLocation)
        {
            if (!Directory.Exists(startLocation)) return;

            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                processDirectory(directory);
                processFiles(directory);

                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }

        private static void processFiles(string directory)
        {
            foreach (var f in Directory.GetFiles(directory))
            {
                FileInfo file = new FileInfo(f);
                if (file.CreationTime < DateTime.Now.AddDays(-14)) File.Delete(file.FullName);
            }
        }
    }
}
