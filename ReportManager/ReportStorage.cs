using DevExpress.Xpf.Reports.UserDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;

namespace ReportManager
{
    internal class ReportStorage : IReportStorage
    {
        public ReportName ReportName { get; }

        public ReportStorage(ReportName ReportName)
        {
            this.ReportName = ReportName;
        }

        public bool CanCreateNew() => false;
        public XtraReport CreateNew() => new DefaultReport();
        public XtraReport CreateNewSubreport()
        {
            return new DefaultReport();
        }
        public bool CanOpen() => true;
        public string Open(IReportDesignerUI designer)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ReportName.ToString();
            dlg.DefaultExt = ReportNameExtensions.FileExtension;
            dlg.Filter = $"Report Template | *{dlg.DefaultExt}";
            dlg.InitialDirectory = ReportNameExtensions.TemplatesPath;

            if (dlg.ShowDialog() == true) return (dlg.FileName);
            else return null;
        }
        public XtraReport Load(string reportID, IReportSerializer designerReportSerializer)
        {
            var report = new DefaultReport();
            report.LoadLayout(reportID);
            return report;
        }

        public string Save(string reportID, IReportProvider reportProvider, bool saveAs, string reportTitle, IReportDesignerUI designer)
        {
            var report = reportProvider.GetReport();

            if (saveAs)
            {
                var dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = ReportName.ToString();
                dlg.DefaultExt = ReportNameExtensions.FileExtension;
                dlg.Filter = $"Report Template | *{dlg.DefaultExt}";
                dlg.InitialDirectory = ReportNameExtensions.TemplatesPath;

                if (dlg.ShowDialog() == true)
                    report.SaveLayout(dlg.FileName);
            }
            else
            {
                report.SaveLayout(ReportName.GetFilename());
            }

            return ReportName.ToString();
            // return reportID;
        }

        public string GetErrorMessage(Exception exception) => exception.ToString();
    }
}
