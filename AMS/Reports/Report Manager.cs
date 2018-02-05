using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Reports
{
    public static class Report_Manager
    {
        public static List<string> HeaderImageList
        {
            get
            {
                if (!Directory.Exists(AMS.Settings.Program.Directories.Headers)) Directory.CreateDirectory(AMS.Settings.Program.Directories.Headers);
                List<string> list = Directory.GetFiles(AMS.Settings.Program.Directories.Headers, "*.jpg", SearchOption.AllDirectories).ToList();
                if (list.Count == 0) list.Add("");
                return list;
            }
        }

        public static List<string> FooterText
        {
            get
            {
                if (!Directory.Exists(AMS.Settings.Program.Directories.Footers)) Directory.CreateDirectory(AMS.Settings.Program.Directories.Footers);
                List<string> footerText = new List<string>();
                string[] files = Directory.GetFiles(AMS.Settings.Program.Directories.Footers, "*.htm", SearchOption.AllDirectories);

                foreach (string i in files)
                {
                    string file = IO.Text.Read(i);
                    footerText.Add(file);
                }
                if (footerText.Count == 0) footerText.Add("");
                return footerText;
            }
        }

        #region Terms & Conditions

        public static List<ReportData> Terms
        {
            get
            {
                var list = new List<ReportData>();

                if (!Directory.Exists(AMS.Settings.Program.Directories.Terms)) Directory.CreateDirectory(AMS.Settings.Program.Directories.Terms);

                string[] files = Directory.GetFiles(AMS.Settings.Program.Directories.Terms, "*.htm", SearchOption.AllDirectories);

                foreach (string i in files)
                {
                    ReportData report = new ReportData();
                    FileInfo file = new FileInfo(i);
                    report.Data = IO.Text.Read(i);
                    report.File.SetFile(file.Name.Substring(0, file.Name.Length - file.Extension.Count()), file.DirectoryName, Data.DataType.Htm);

                    list.Add(report);
                }

                return list;
            }
        }

        public static ReportData GetTerms(string TermsName)
        {
            ReportData terms = (from i in Terms
                                where i.File.Name == TermsName
                                select i).FirstOrDefault();

            return terms;
        }

        public static void EditTerms(string TermsName)
        {
            var queryTerms = (from i in AMS.Reports.Report_Manager.Terms
                              where i.File.Name == TermsName
                              select i).FirstOrDefault();

            if (queryTerms == null)
            {
                queryTerms = new AMS.Reports.ReportData();

                if (AMS.MessageBox_v2.Show("Would you like to add another Terms & Conditions?\r\nEnter file name below.", MessageType.QuestionInput) == MessageOut.YesOk)
                {
                    queryTerms.File.SetFile(AMS.MessageBox_v2.MessageValue, AMS.Settings.Program.Directories.Terms,Data.DataType.Htm);
                    
                    queryTerms.Data = "";

                    AMS.IO.Text.Write(new List<string>(), queryTerms.File.FullName);
                }
                else
                {
                    return;
                }
            }

            System.Diagnostics.Process.Start(AMS.Users.UserManager.LocalData.GeLocationWord, "\"" + queryTerms.File.FullName + "\"");
        }

        #endregion

        public static List<string> BankingDetails
        {
            get
            {
                if (!Directory.Exists(AMS.Settings.Program.Directories.Templates)) Directory.CreateDirectory(AMS.Settings.Program.Directories.Templates);

                List<string> bankingDetails = new List<string>();
                string[] files = Directory.GetFiles(AMS.Settings.Program.Directories.Templates, "Banking Details.htm", SearchOption.AllDirectories);

                foreach (string i in files)
                {
                    string file = IO.Text.Read(i);
                    bankingDetails.Add(file);
                }
                if (bankingDetails.Count == 0) bankingDetails.Add("");
                return bankingDetails;
            }
        }
    }
}