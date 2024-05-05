using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Communications
{
    public partial class MailManger
    {
        /// <summary>
        /// Create New Mail with Options
        /// </summary>
        /// <param name="Account">Specify which account this is related to</param>
        /// <param name="MainContact">Use Main Contact. If false it will be empty</param>
        /// <param name="Subject">Email Subject</param>
        /// <param name="Content">Program generated content</param>
        /// <param name="Attachments">Files to include on mail</param>
        /// <param name="TemplateType">which template to use</param>
        /// <returns>Data.Communications.Mail</returns>
        public Data.Communications.Mail NewMail(string Account, bool MainContact, string Subject, string Content, string Attachments, TemplateTypes TemplateType)
        {
            var client = DMS.ClientManager.GetData(i => i.Account == Account);
            var mail = new AMS.Data.Communications.Mail();

            string contact;
            string email;
            

            if (MainContact && client.GetMainContact != null && !string.IsNullOrEmpty(client.GetMainContact.FirstName))
            {
                contact = client.GetMainContact.FirstName;
                email = client.GetMainContact.Email;
               
            }
            else
            {
                contact = client.Name;
                email = client.Email;
               
            }

            return NewMail(Account, contact, email, Subject, Content, Attachments, TemplateType);
        }

        /// <summary>
        /// Used in Transaction Emails, Since the Report Manager will generate the subject, content and the attachments
        /// </summary>
        /// <param name="Account">Specify which account this is related to</param>
        /// <param name="Contact">Custom Contact</param>
        /// <param name="Email">Custom Email</param>
        /// <param name="TemplateType">which template to use</param>
        /// <returns>Data.Communications.Mail</returns>
        public Data.Communications.Mail OLDNewMail(string Account, string Contact, string Email, TemplateTypes TemplateType)
        {
            return NewMail(Account, Contact, Email, null, null, null, TemplateType);
        }

        // var mail = DMS.MailManager.NewMail(trans.Account, trans.Contact, trans.Email, subject, ttype);


        //public Data.Communications.Mail NewMail(string Account, string Contact, string Email, string Subject, string subjectWithClientName, TemplateTypes TemplateType)
        //{
    
       //     return NewMail(Account, Contact, Email, Subject, null, null, TemplateType);
        //}

        public Data.Communications.Mail NewMail(string Account, string Contact, string Email, string Subject, string subjectWithClientName, TemplateTypes TemplateType)
        {
            if (subjectWithClientName != null && subjectWithClientName.Contains("PurchaseOrder"))
            {
                // If subjectWithClientName contains "PurchaseOrder"
                return NewMail(Account, Contact, Email, subjectWithClientName, null, null, TemplateType);
            }
            else
            {
                // If subjectWithClientName does not contain "PurchaseOrder"
                return NewMail(Account, Contact, Email, Subject, null, null, TemplateType);
            }
        }


        /// <summary>
        /// Create New Mail with Options
        /// </summary>
        /// <param name="Account">Specify which account this is related to</param>
        /// <param name="Contact">Custom Contact</param>
        /// <param name="Email">Custom Email</param>
        /// <param name="Subject">Email Subject</param>
        /// <param name="Content">Program generated content</param>
        /// <param name="Attachments">Files to include on mail</param>
        /// <param name="TemplateType">which template to use</param>
        /// <returns>Data.Communications.Mail</returns>
        public Data.Communications.Mail NewMail(string Account, string Contact, string Email, string Subject, string Content, string Attachments, TemplateTypes TemplateType)
        {
            var mail = new Data.Communications.Mail();
            var client = DMS.ClientManager.GetData(i => i.Account == Account);
            if (client == null) client = new People.Client();
            if (string.IsNullOrEmpty(Contact)) Contact = client.Name;
            if (string.IsNullOrEmpty(Email)) Contact = client.Email;

            mail.Account = Account;
            mail.MailTo = Email;
            mail.Body = TemplateContext(Account, Contact, Content, TemplateType);
            mail.Contact = Contact;
            mail.Subject = Subject;
            mail.Attachment = Attachments;

            return mail;
        }

        // Template Context

        public string TemplateContext(string Account, string Contact, string Content, TemplateTypes TemplateType)
        {
            #region Check for template
            var client = DMS.ClientManager.GetData(i => i.Account == Account);
           if (client.LanguageAfr) TemplateType = (TemplateTypes)Enum.Parse(typeof(TemplateTypes), TemplateType.ToString() + "Afr");
            //if (client.LanguageAfr) TemplateType = (TemplateTypes)Enum.Parse(typeof(TemplateTypes), TemplateType.ToString());
            #endregion

            StringBuilder body = new StringBuilder();
            var template = GetTemplate(TemplateType.ToString());

            string greeting = template.Greeting;
            string signature = "";

            if (!string.IsNullOrEmpty(Contact))
            {
                // Get 1st Name
                var contact = DMS.PeopleManager.GetData(i => ("" + i.DisplayName).Trim() == ("" + Contact).Trim());

                if (contact != null)
                    greeting += " " + contact.FirstName;
                else
                    greeting += " " + Contact;
            }

            // REPLACE SIGNATURE HERE ONE DAY

            if (template.AddSignature) signature = AMS.Users.UserManager.CurrentUser.FirstName + " " + AMS.Users.UserManager.CurrentUser.LastName + "\r\n" +
                  AMS.Suite.SuiteManager.Profile.CompanyName + "\r\n" + AMS.Suite.SuiteManager.Profile.CompanyContactNr;

            if (!string.IsNullOrEmpty(greeting))
            {
                body.AppendLine(greeting.Trim());
                body.AppendLine();
            }
            if (!string.IsNullOrEmpty(template.ContentTop)) body.AppendLine(template.ContentTop);
            if (!string.IsNullOrEmpty(Content)) body.AppendLine(Content.Trim());
            if (!string.IsNullOrEmpty(template.ContentBottom)) body.AppendLine(template.ContentBottom);
            if (!string.IsNullOrEmpty(signature))
            {
                body.AppendLine();
                body.AppendLine(signature.Trim());
            }

            return body.ToString();
        }

        // Methods

        public void SendGeneralMail(string Account, string Contact, string Email, string Subject = null)
        {
            var mail = NewMail(Account, Contact, Email, Subject, null, null, TemplateTypes.General);

            mail.Subject = AMS.Suite.SuiteManager.Profile.CompanyName;

            AMS.Communications.MailManager.SendMail(mail);
        }

        public void SendGeneralMail(Data.Communications.Mail Mail)
        {
            AMS.Communications.MailManager.SendMail(Mail);
        }
    }
}
