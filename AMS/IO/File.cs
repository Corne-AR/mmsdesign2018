using AMS.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.IO
{
    public static class File
    {
        public static string[] GetAllFiles(string Location, DataType FileExtension)
        {
            if (Directory.Exists(Location))
            {
                string[] files = (Directory.GetFiles(Location, "*." + FileExtension, SearchOption.AllDirectories));
                return files.Where(i => !i.ToLower().Contains("conflicted")).ToArray();
            }
            else
            {
                AMS.StatusUpdate.UpdateArea("Location: '" + Location + "' not found!");
                return new string[0];
            }
        }

        public static string[] GetAllFiles(string Location, string FileExtension)
        {
            if (Directory.Exists(Location))
            {
                string[] files = (Directory.GetFiles(Location, "*." + FileExtension, SearchOption.AllDirectories));
                return files;
            }
            else
            {
                AMS.StatusUpdate.UpdateArea("Location: '" + Location + "' not found!");
                return new string[0];
            }
        }

        public static List<FileInfo> SearchForFile(string RootFolder, string FolderName, string FileName)
        {
            AMS.MessageBox_v2.ShowProcess("Searching for '" + FileName + "' from '" + RootFolder + "'");
            AMS.StatusUpdate.UpdateArea("Searching for '" + FileName + "' from '" + RootFolder + "'");

            if (Directory.Exists(RootFolder))
            {
                List<FileInfo> fileList = new List<FileInfo>();

                // List of directories
                string[] directories = Directory.GetDirectories(RootFolder);

                foreach (var dir in directories)
                    if (dir.Contains(FolderName))
                    {
                        string[] files = (Directory.GetFiles(dir, FileName, SearchOption.AllDirectories));
                        foreach (var file in files)
                            fileList.Add(new FileInfo(file));
                    }

                AMS.MessageBox_v2.EndProcess();
                return fileList;
            }
            else
            {
                AMS.StatusUpdate.UpdateArea("Location: '" + RootFolder + "' not found!");
                AMS.MessageBox_v2.EndProcess();
                return null;
            }
        }
    }
}