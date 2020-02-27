using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Collections;

namespace AMS.Communications
{
    public static class MailManager
    {
        public static void SendMail(string Name, string EmailAddress)
        {
            string email = "mailto:" + EmailAddress + "?subject=" + Name + "\"";
            System.Diagnostics.Process.Start(email);
        }

        public static void SendMail(AMS.Data.Communications.Mail Mail)
        {
            // c:\program files\microsoft office\office12\outlook.exe" /c ipm.note /m someone@gmail.com /a "c:\logs\logfile.txt"

            try
            {
                string mailTo = "";
                string subject = "";
                string body = "";
                string attachment = "";

                if (Mail.MailTo != null) mailTo = Decode(Mail.MailTo);
                if (Mail.Subject != null) subject = Decode(Mail.Subject);
                if (Mail.Body != null) body = Decode(Mail.Body);
                if (Mail.Attachment != null) attachment = Mail.Attachment;

                string arguments = "/c ipm.note /m " + mailTo;
                if (subject != "") arguments += "?&subject=" + subject;
                if (body != "") arguments += "&body=" + body;
                if (!string.IsNullOrEmpty(Mail.Attachment)) arguments += " /a \"" + attachment + "\"";

                string runCommand = AMS.Users.UserManager.LocalData.GetLocationOutlook;
                // System.Diagnostics.Process.Start(runCommand, arguments);
                //string test = "mailto:" + Mail.MailTo + "?subject=" + subject + "&body=" + body + @"&attachment=" + "\"" + attachment + "\"";
                //System.Diagnostics.Process.Start(test);

                System.Diagnostics.Process.Start(runCommand, arguments);
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, MessageType.Error);
            }

            return;
        }

        private static string Decode(string InputString)
        {
            return Uri.EscapeDataString(InputString).ToString();
            //return InputString.Replace(";", "%3B").Replace("+", "%2B").Replace(".", "%2E").Replace(" ", "%20").Replace("\r\n", "%0A").ToString();
        }

        public static void SendGmail(AMS.Data.Communications.Mail Mail)
        {
            throw new NotImplementedException();

            //// Create a message and set up the recipients.
            //MailMessage message = new MailMessage(Mail.MailFrom, Mail.MailTo, Mail.Subject, Mail.Body);

            //// Add the file attachment to this e-mail message.
            //message.Attachments.Add(new Attachment(Mail.Attachment));

            ////Send the message.
            //SmtpClient client = new SmtpClient
            //{
            //    Host = Mail.Server,
            //    Port = Mail.ServerPort,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(Mail.Login, Mail.Password)
            //};

            //try { client.Send(message); }
            //catch (Exception ex) { AMS.MessageBox_v2.Show("Error Trying to Send the Mail\r\n\r\n" + ex.ToString(), MessageType.Error); }
        }
    }
}
