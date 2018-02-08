using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security;
using System.Windows.Interop;
using System.Windows.Forms.Integration;

using DevExpress;
using DevExpress.Xpf;
using DevExpress.Xpf.Core;
using DevExpress.XtraReports.UI;

namespace Reporting.Views
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : DevExpress.Xpf.Ribbon.DXRibbonWindow
    {
        private static ReportWindow win;
        public static bool ShowReport(ReportName Name, Data.Communications.Mail Mail)
        {
            try
            {
                if (win == null || !win.IsLoaded) win = new ReportWindow(Name);
                win.Mail = Mail;
                win.LoadReport();
                win.Loaded += (s, e) => win.Focus();
                win.ShowDialog();

                return win.MailSend;
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.ToString());
            }

            return false;
        }

        public static bool ShowReport<T>(ReportName Name, T DataSource, Data.Communications.Mail Mail)
        {
            try
            {
                if (win == null || !win.IsLoaded) win = new ReportWindow(Name);
                win.Mail = Mail;
                win.LoadReport<T>(DataSource, Name.ToString());
                win.Loaded += (s, e) => win.Focus();
                win.ShowDialog();

                return win.MailSend;
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.ToString());
            }

            return false;
        }

        public bool MailSend { get; private set; }

        public XtraReport Report;

        public ReportName ReportName { get; }

        public Data.Communications.Mail Mail { get => _Mail; set { _Mail = value; btnSendMail.IsEnabled = value != null; } }
        private Data.Communications.Mail _Mail;

        private ReportWindow(ReportName Name)
        {
            InitializeComponent();

            // Enabling WinForm interactions to WPF
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/d1599565-5559-4712-a00f-160391bc82aa/cannot-type-into-wpf-controls-when-window-opened-from-win-forms-app?forum=wpf
            ElementHost.EnableModelessKeyboardInterop(this);

            btnDesigner.ItemClick += (s, e) => OpenDesigner();
            btnSendMail.ItemClick += (s, e) => SendMail();
            btnSendMail.IsEnabled = false;

            this.ReportName = Name;
        }

        public void LoadReport()
        {
            Report = new DefaultReport();

            if (ReportName.FileExists())
                Report.LoadLayout(ReportName.GetFilename());

            UpdateSubReports();

            reportcontrol.DocumentSource = Report;
            Report.CreateDocument();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DataSource">Actual Data</param>
        /// <param name="Name">Name for Report's Fields panel.</param>
        public void LoadReport<T>(T DataSource, string Name)
        {
            Report = new DefaultReport();
            if (ReportName.FileExists())
            {
                Report.LoadLayout(ReportName.GetFilename());
                Report.ComponentStorage.Clear();
            }
            var ods = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource
            {
                DataSource = DataSource,
                Name = Name
            };

            Report.DataSource = ods;

            UpdateSubReports();

            reportcontrol.DocumentSource = Report;
            Report.CreateDocument();
        }

        private void OpenDesigner()
        {
            try
            {
                Report.StopPageBuilding();
                var win = new ReportDesigner(ReportName, Report);
                win.ShowDialog();

                win.Close();

                UpdateSubReports();

                var newReport = Report.CloneReport();
                newReport.DataSource = Report.DataSource;
                newReport.StopPageBuilding();
                newReport.CreateDocument();
                reportcontrol.DocumentSource = newReport;
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.ToString());
            }
        }

        private void SendMail()
        {
            if (SendMailWindow.Show(Mail))
            {
                string path = $"{AMS.Settings.Program.Directories.Clients}{Mail.Account}\\Documents\\";
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                //var name = $"{path}{DateTime.Now:yy-MM-dd} {Mail.Subject}";
                var name = $"{Mail.Subject}";
                var filename = $"{path}{name}.pdf";

                Report.ExportToPdf(filename);

                Mail.Attachment = filename;
                AMS.Communications.MailManager.SendMail(Mail);

                MailSend = true;
            }
        }

        private void UpdateSubReports()
        {
            foreach (var r in Report.AllControls<XRSubreport>())
                UpdateSubReport(r);
        }
        private void UpdateSubReport(XRSubreport Report)
        {
            var path = ReportNameExtensions.TemplatesPath;
            var filename = System.IO.Path.GetFileName(Report.ReportSourceUrl);

            if (!filename.EndsWith(ReportNameExtensions.FileExtension))
                filename += ReportNameExtensions.FileExtension;

            Report.ReportSourceUrl = $"{path}{filename}";

            foreach (var r in Report.AllControls<XRSubreport>())
                UpdateSubReport(r);
        }
    }
}
