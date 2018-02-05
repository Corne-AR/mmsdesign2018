using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite.Data
{
    /// <summary>
    /// Stores Local data unrelated to the "Network" Data
    /// ex: saving login info for fast access
    /// </summary>
    [Serializable]
    public class LocalData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DirectoryRootData { get; set; }
        public bool FastLogin { get; set; }

        public string LocalKey { get; set; }

        /// <summary>
        /// READONLY, use Get rather
        /// </summary>
        public string LocationWord { get; set; }

        /// <summary>
        /// READONLY, use Get rather
        /// </summary>
        public string LocationOutlook { get; set; }
        public string GetLocationOutlook
        {
            get
            {
                if (LocationOutlook == null || LocationOutlook == "")
                {
                    LocationOutlook = GetProgramFile("outlook.exe");
                    AMS.Users.UserManager.SaveLocalData();
                }
                return LocationOutlook;
            }
        }
        public string GeLocationWord
        {
            get
            {
                if (LocationWord == null || LocationWord == "")
                {
                    LocationWord = GetProgramFile("winword.exe");
                    AMS.Users.UserManager.SaveLocalData();
                }
                return LocationWord;
            }
        }

        // Methods

        private string GetProgramFile(string FileName)
        {
            var files = AMS.IO.File.SearchForFile(@"C:\Program Files\", "Office", FileName);
            if (files == null || files.Count == 0) files = AMS.IO.File.SearchForFile(@"C:\Program Files (x86)\", "Office", FileName);
            if (files == null) files = new List<System.IO.FileInfo>();

            string file = (from i in files
                           orderby i.CreationTime descending
                           select i.FullName).FirstOrDefault();

            if (AMS.MessageBox_v2.Show("Please confirm location for your default '" + FileName.ToUpper() + "'\r\n\r\n" + file, MessageType.Question) == MessageOut.YesOk)
            {
            }
            else
            {
                System.Windows.Forms.OpenFileDialog f = new System.Windows.Forms.OpenFileDialog();
                f.DefaultExt = ".exe";
                f.InitialDirectory = "C:\\";
                f.ShowDialog();

                file = f.FileName;
            }

            return file;
        }

        public DateTime UpdateDate { get; set; }
    }
}