using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReportManager.Views
{
    /// <summary>
    /// Interaction logic for ReportDesigner.xaml
    /// </summary>
    public partial class ReportDesigner : DevExpress.Xpf.Ribbon.DXRibbonWindow
    {
        public XtraReport Report { get; }

        public ReportDesigner(ReportName ReportName, XtraReport Report)
        {
            InitializeComponent();

            // Enabling WinForm interactions to WPF
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/d1599565-5559-4712-a00f-160391bc82aa/cannot-type-into-wpf-controls-when-window-opened-from-win-forms-app?forum=wpf
            ElementHost.EnableModelessKeyboardInterop(this);

            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = $"{AMS.Settings.Program.Directories.Templates}Reports";
            this.Loaded += (s, e) => designer.ReportStorage = new ReportStorage(ReportName);

            designer.OpenDocument(Report);
            this.Report = Report;
        }
    }
}
