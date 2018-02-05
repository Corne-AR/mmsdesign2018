using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using Data.People;
using Data;
using System.Collections.ObjectModel;
using System.Windows.Forms.Integration;
using ReportManager.MVVM;

namespace ReportManager.Views
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

        public bool DoSend { get => (grid.DataContext as SendMailViewModel).DoSend; }

        private SendMailWindow(Data.Communications.Mail Mail)
        {
            InitializeComponent();
            // Enabling WinForm interactions to WPF
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/d1599565-5559-4712-a00f-160391bc82aa/cannot-type-into-wpf-controls-when-window-opened-from-win-forms-app?forum=wpf
            ElementHost.EnableModelessKeyboardInterop(this);

            var vm = (grid.DataContext as SendMailViewModel);
            vm.Mail = Mail;
            vm.CloseWindow = this.Close;

            if (!string.IsNullOrEmpty(Mail?.MailTo))
                listBox.SelectedItems.Add(Mail.MailTo);
        }
    }

    public class SendMailViewModel : ViewModel
    {
        public Data.Communications.Mail Mail { get { return GetValue<Data.Communications.Mail>(); } set { SetValue(value); UpdateEmails(); } }

        public Client Client { get { return Mail?.Client; } }

        public List<object> SelectedEmails { get => GetValue<List<object>>(); set => SetValue(value); }
        public ObservableCollection<string> Emails { get; } = new ObservableCollection<string>();

        internal Action CloseWindow { get; set; }

        public bool DoSend { get; set; } = false;

        public ICommand SendCommand { get { return DelegateCommand.Create(Send); } }

        private void Send()
        {
            SelectedEmails = new List<object>();
            Mail.MailTo = SelectedEmails.BuildString("; ");

            DoSend = true;
            CloseWindow();
        }

        private void AddEmail(string Value)
        {
            if (string.IsNullOrEmpty(Value)) return;

            if (!Emails.Contains(x => x.Trim().ToLower() == Value.Trim().ToLower()))
                Emails.Add(Value);
        }

        private void UpdateEmails()
        {
            AddEmail(Mail?.MailTo);
            AddEmail(Client?.Email);
            Client?.GetPeople.ForEach(x => AddEmail(x.Email));

            RaisePropertiesChanged();
        }
    }
}
