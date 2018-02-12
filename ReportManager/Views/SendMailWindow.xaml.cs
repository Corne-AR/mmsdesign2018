using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using Data;
using System.Windows.Forms.Integration;

namespace Reporting.Views
{
    /// <summary>
    /// Interaction logic for SendMailWindow.xaml
    /// </summary>
    public partial class SendMailWindow : DXWindow
    {
        public static bool Show(Data.Communications.Mail Mail)
        {
            var win = new SendMailWindow(Mail);
            win.ShowDialog();
            return win.DoSend;
        }

        public bool DoSend { get => viewmodel.DoSend; }

        private SendMailWindow(Data.Communications.Mail Mail)
        {
            InitializeComponent();
            // Enabling WinForm interactions to WPF
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/d1599565-5559-4712-a00f-160391bc82aa/cannot-type-into-wpf-controls-when-window-opened-from-win-forms-app?forum=wpf
            ElementHost.EnableModelessKeyboardInterop(this);

            viewmodel.Mail = Mail;
            viewmodel.CloseWindow = this.Close;

            if (!string.IsNullOrEmpty(Mail?.MailTo))
                listBox.SelectedItems.Add(Mail.MailTo);
        }
    }
}
