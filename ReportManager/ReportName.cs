using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    /// <summary>
    /// 1 to 1 mapping to report's file name
    /// <para>WARNING! Changing one of these values will NOT automatically change the filename in the DB.</para>
    /// </summary>
    public enum ReportName
    {
        Unspecified = 0,

        // Client related
        Quote,
        PackingList,
        Invoices,
        Purchases,
        PurchasesMMS,
        Statement,

        /// <summary>
        /// All Transactions
        /// </summary>
        Transactions,

        // Model Maker Systems
        MMS_Quote,
        MMS_Support,

        // MMS Design
        MMSD_Bank,
        MMSD_Header,
        MMSD_Footer,
        MMSD_FinancialYear,
        VAT,
        Tiende,
        Tax,
        Clients,
    }

    public static class ReportNameExtensions
    {
        public static string FileExtension { get => ".repx"; }
        public static string TemplatesPath { get => AMS.Settings.Program.Directories.Templates + "Reports\\"; }

        public static string GetFilename(this ReportName Name) => TemplatesPath + Name + FileExtension;

        public static bool FileExists(this ReportName Name) => System.IO.File.Exists(Name.GetFilename());

        public static IEnumerable<string> GetNames() => Enum.GetNames(typeof(ReportName));

        public static ReportName GetName(string Name) => (ReportName)Enum.Parse(typeof(ReportName), Name);
    }
}