using System;
using System.Collections.Generic;
using System.Windows.Input;
using Data.People;
using System.Collections.ObjectModel;
using Reporting.MVVM;

namespace Reporting.Views
{
    public class SendMailViewModel : ViewModel
    {
        public Data.Communications.Mail Mail { get { return GetValue<Data.Communications.Mail>(); } set { SetValue(value); UpdateEmails(); } }

        public Client Client { get { return Mail?.Client; } }

        public List<object> SelectedEmails { get => GetValue<List<object>>(); set => SetValue(value); }
        public ObservableCollection<string> Emails { get; } = new ObservableCollection<string>();

        internal Action CloseWindow { get; set; }

        public bool DoSend { get; set; } = false;

        public ICommand SendCommand { get { return DelegateCommand.Create(Send, () => SelectedEmails?.Count >= 1); } }

        private void Send()
        {
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
