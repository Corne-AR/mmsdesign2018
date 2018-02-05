using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMS;
using AMS.Data.Communications;
using Data;

namespace UserInterface.Utilities.UserControls
{
    public partial class RightPanel : UserControl
    {
        /*
            try
            {
                string cmd = "";
                string arg = "";
                System.Diagnostics.Process.Start(cmd, arg);
            }
            catch (Exception ex) { AMS.MessageBox.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageBox.MessageType.Error); }
        */

        public RightPanel()
        {
            InitializeComponent();
        }

        // Load

        private void RightPanel_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            splitContainer1.Panel2.BackColor = ThemeColors.Menu;
            splitContainer1.Panel2.ForeColor = ThemeColors.MenuText;

            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c.GetType() == typeof(Button)) ThemeColors.SetControls(c, ThemeColors.ControlType.Menu);
                if (c.GetType() == typeof(Panel)) c.BackColor = ThemeColors.MenuText;
            }

            discs_Label.ForeColor = ThemeColors.Primary;
            documents_Label.ForeColor = ThemeColors.Primary;
            discs_PictureBox.ForeColor = ThemeColors.Primary;
            splitContainer1.Panel1.BackColor = ThemeColors.MenuBorder;
            splitContainer1.Panel1.ForeColor = ThemeColors.MenuBorderText;

            #endregion

            // Startup with defaults
            if (AMS.Suite.SuiteManager.Preferences == null) return;

            ToggleDocuments();
            ToggleISO();

            splitContainer1.Panel2Collapsed = !AMS.Suite.SuiteManager.Preferences.General.HideRightPanel;
            CheckCollapsed();
        }

        // Methods

        private void CheckCollapsed()
        {
            bool collapsed = splitContainer1.Panel2Collapsed;
            int height = this.Height;

            if (collapsed) // unclasped
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Size = new Size(120, height);
                splitContainer1.SplitterDistance = 20;
                label1.Text = "4";
            }
            else // Collapse
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Size = new Size(15, height);
                splitContainer1.SplitterDistance = 1;
                label1.Text = "3";
            }

            if (AMS.Suite.SuiteManager.Preferences != null) AMS.Suite.SuiteManager.Preferences.General.HideRightPanel = splitContainer1.Panel2Collapsed;
        }

        private void ToggleDocuments()
        {
            letters_Button.Visible = !letters_Button.Visible;
            labe3x8_Button.Visible = !labe3x8_Button.Visible;
            fax_Button.Visible = !fax_Button.Visible;
            invoiceExport_Button.Visible = !invoiceExport_Button.Visible;
            repairsLetter_button.Visible = !repairsLetter_button.Visible;
            purchaseOrderExport_Button.Visible = !purchaseOrderExport_Button.Visible;
        }

        private void ToggleISO()
        {
            images_Label.Visible = !images_Label.Visible;
            imageMM_Button.Visible = !imageMM_Button.Visible;
            imageMMDVD_Button.Visible = !imageMMDVD_Button.Visible;
            burnMM_Button.Visible = !burnMM_Button.Visible;
            burnMMDVD_Button.Visible = !burnMMDVD_Button.Visible;
        }

        // Events

        #region Documents

        private void ToggleDocuments_Click(object sender, EventArgs e)
        {
            ToggleDocuments();
        }

        // Buttons

        private void Document_Click(object sender, EventArgs e)
        {
            try
            {
                string runCommand = AMS.Users.UserManager.LocalData.GeLocationWord;
                string arguments = "/t\"" + AMS.Settings.Program.Directories.RootData + "Templates\\" + "Letterhead.dotx\"";

                // C:\Word Folder\winword.exe /ttemplate name
                System.Diagnostics.Process.Start(runCommand, arguments);
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error);
            }
        }

        private void RepairsLetter_button_Click(object sender, EventArgs e)
        {
            try
            {
                string runCommand = AMS.Users.UserManager.LocalData.GeLocationWord;
                string arguments = "/t\"" + AMS.Settings.Program.Directories.RootData + "Templates\\" + "RepairInstructions.dotx\"";

                // C:\Word Folder\winword.exe /ttemplate name
                System.Diagnostics.Process.Start(runCommand, arguments);
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error);
            }
        }

        private void Labe3x8_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = AMS.Users.UserManager.LocalData.GeLocationWord;
                string arg = "/t\"" + AMS.Settings.Program.Directories.RootData + "Templates\\" + "Labels 3x8.dotx\"";
                System.Diagnostics.Process.Start(cmd, arg);
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); }
        }

        private void Fax_Button_Click(object sender, EventArgs e)
        {
            string currentfax = "";

            if (DMS.ClientManager.CurrentData != null && DMS.ClientManager.CurrentData.ID != null && DMS.ClientManager.CurrentData.Fax != null) currentfax = DMS.ClientManager.CurrentData.Fax;

            if (currentfax != "")
            {
                try
                {
                    currentfax = currentfax.Trim();
                    currentfax = currentfax.Replace("-", "").Replace(" ", "");
                    var last7 = currentfax.Substring(currentfax.Length - 7);
                    var front2 = currentfax.Substring(currentfax.Length - 9, 2);

                    currentfax = "27." + front2 + "." + last7;
                }
                catch { }
            }
            if (AMS.MessageBox_v2.Show("Please enter the fax number below.\r\nAn email to fax will be created.\r\n\r\nex: 27.86.6541033@faxwhiz.co.za\r\n\r\nnote: @faxwhiz.co.za will be added automatically", currentfax) == AMS.MessageOut.YesOk)
            {
                var mail = new Mail
                {
                    MailTo = AMS.MessageBox_v2.MessageValue + @"@faxwhiz.co.za"
                };
                AMS.Communications.MailManager.SendMail(mail);
            }
        }

        private void InvoiceExport_Event(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;
            startDate = new DateTime(startDate.Year, startDate.Month, 1);

            AMS.Utilities.Forms.DatePicker dp = new AMS.Utilities.Forms.DatePicker("Start Date", startDate);
            dp.ShowDialog();
            startDate = dp.DateTimeValue;

            dp = new AMS.Utilities.Forms.DatePicker("End Date", endDate);
            dp.ShowDialog();
            endDate = dp.DateTimeValue;

            var transacionList = DMS.TransactionManager.GetDataList(i => i.TransactionDate >= startDate && i.TransactionDate <= endDate && (i.Type == Data.Transactions.TransactionType.Invoice || i.Type == Data.Transactions.TransactionType.CreditNote));

            StringBuilder sb = new StringBuilder();
            var stringList = new List<string>();

            string header = "ID\tTransaction Date\tTotal\tCurrency\tForex\tTerms\tInc VAT\tClient Vat Nr\tClient Name\tVoid";
            stringList.Add(header);

            sb.Append(header);
            sb.AppendLine();
            foreach (var item in transacionList)
            {
                if (item != null)
                {
                    StringBuilder line = new StringBuilder();

                    line.Append(("" + item.ID).Trim() + "\t");
                    line.Append(("" + item.TransactionDate).Trim() + "\t");
                    line.Append(("" + item.Total).Trim() + "\t");
                    line.Append(("" + item.Currency).Trim() + "\t");
                    line.Append(("" + item.Forex).Trim() + "\t");
                    line.Append(("" + item.PaymentTerms).Trim() + "\t");
                    line.Append(item.UseVat + "\t");
                    line.Append(item.Client.VatNr + "\t");
                    line.Append(item.Client.Name + "\t");
                    line.Append(item.IsVoid + "\t");

                    stringList.Add(line.ToString());
                    sb.Append(line.ToString());
                    sb.AppendLine();
                }
            }
            string dataString = sb.ToString();
            Clipboard.SetText(dataString);

            string fileName = AMS.Suite.SuiteManager.Profile.CompanyName + " Invoice List - " + string.Format("{0:dd MMM yy} to {1:dd MMM yy}", startDate, endDate) + ".txt";
            string path = AMS.Suite.SuiteManager.Preferences.General.InvoiceListPath;
            if (path == null) path = AMS.Settings.Program.Directories.RootData;

            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = fileName,
                InitialDirectory = path
            };
            sfd.ShowDialog();

            System.IO.FileInfo file = new System.IO.FileInfo(sfd.FileName);

            AMS.IO.Text.Write(stringList, sfd.FileName);
            AMS.Suite.SuiteManager.Preferences.General.InvoiceListPath = file.DirectoryName;
        }

        private void PurchaseOrderExport_Button_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;
            startDate = new DateTime(startDate.Year, startDate.Month, 1);

            AMS.Utilities.Forms.DatePicker dp = new AMS.Utilities.Forms.DatePicker("Start Date", startDate);
            dp.ShowDialog();
            startDate = dp.DateTimeValue;

            dp = new AMS.Utilities.Forms.DatePicker("End Date", endDate);
            dp.ShowDialog();
            endDate = dp.DateTimeValue;

            var transacionList = DMS.TransactionManager.GetDataList(i => i.TransactionDate >= startDate && i.TransactionDate <= endDate && (i.Type == Data.Transactions.TransactionType.PurchaseOrder));

            StringBuilder sb = new StringBuilder();
            var stringList = new List<string>();

            string header = "ID\tTransaction Date\tTotal\tCurrency\tForex\tTerms\tInc VAT\tClient Vat Nr\tClient Name\tVoid";
            stringList.Add(header);

            sb.Append(header);
            sb.AppendLine();
            foreach (var item in transacionList)
            {
                if (item != null)
                {
                    StringBuilder line = new StringBuilder();

                    line.Append(("" + item.ID).Trim() + "\t");
                    line.Append(("" + item.TransactionDate).Trim() + "\t");
                    line.Append(("" + item.Total).Trim() + "\t");
                    line.Append(("" + item.Currency).Trim() + "\t");
                    line.Append(("" + item.Forex).Trim() + "\t");
                    line.Append(("" + item.PaymentTerms).Trim() + "\t");
                    line.Append(item.UseVat + "\t");
                    line.Append(item.Client.VatNr + "\t");
                    line.Append(item.Client.Name + "\t");
                    line.Append(item.IsVoid + "\t");
                    line.Append(item.LinkedIDList.BuildString(", ") + "\t");

                    stringList.Add(line.ToString());
                    sb.Append(line.ToString());
                    sb.AppendLine();
                }
            }
            string dataString = sb.ToString();
            Clipboard.SetText(dataString);

            string fileName = AMS.Suite.SuiteManager.Profile.CompanyName + " PurchaseOrder List - " + string.Format("{0:dd MMM yy} to {1:dd MMM yy}", startDate, endDate) + ".txt";
            string path = AMS.Suite.SuiteManager.Preferences.General.InvoiceListPath;
            if (path == null) path = AMS.Settings.Program.Directories.RootData;

            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = fileName,
                InitialDirectory = path
            };
            sfd.ShowDialog();

            System.IO.FileInfo file = new System.IO.FileInfo(sfd.FileName);

            AMS.IO.Text.Write(stringList, sfd.FileName);
            AMS.Suite.SuiteManager.Preferences.General.InvoiceListPath = file.DirectoryName;
        }

        #endregion

        #region Burn Images

        private void ToggleISO_Click(object sender, EventArgs e)
        {
            ToggleISO();
        }

        private void DiscSettings_Click(object sender, EventArgs e)
        {

        }

        // Buttons

        private void BurnMM_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = @"C:\Program Files (x86)\ImgBurn\ImgBurn.exe";
                string arg = "/MODE WRITE /VERIFY /CLOSE /EJECT /START /SRC \"" + AMS.Settings.Program.Directories.LocalData + "\\Disc\\Model Maker Systems.iso\"";
                System.Diagnostics.Process.Start(cmd, arg);
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); }
        }

        private void BurnMMDVD_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = @"C:\Program Files (x86)\ImgBurn\ImgBurn.exe";
                string arg = "/MODE WRITE /VERIFY /CLOSE /EJECT /START /SRC \"" + AMS.Settings.Program.Directories.LocalData + "\\Disc\\MM Intro DVD.iso\"";
                System.Diagnostics.Process.Start(cmd, arg);
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); }
        }

        private void ImageMM_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string drive = AMS.Settings.Program.DiscDrive;
                string cmd = @"C:\Program Files (x86)\ImgBurn\ImgBurn.exe";
                string arg = "/MODE BUILD /BUILDINPUTMODE  STANDARD /BUILDOUTPUTMODE IMAGEFILE /FILESYSTEM \"ISO9660 + Joliet\" /VOLUMELABEL_JOLIET \"Model Maker\" /OVERWRITE YES/CLOSE /EJECT /START /SRC " + drive + " /DEST \"" + AMS.Settings.Program.Directories.LocalData + "\\Disc\\Model Maker Systems.iso\"";
                System.Diagnostics.Process.Start(cmd, arg);
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); }
        }

        private void ImageMMDVD_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string drive = AMS.Settings.Program.DiscDrive;
                string cmd = @"C:\Program Files (x86)\ImgBurn\ImgBurn.exe";
                string arg = "/MODE BUILD /BUILDINPUTMODE  STANDARD /BUILDOUTPUTMODE IMAGEFILE /FILESYSTEM \"ISO9660 + Joliet\" /VOLUMELABEL_JOLIET \"Model Maker\" /OVERWRITE YES/CLOSE /EJECT /START /SRC " + drive + " /DEST \"" + AMS.Settings.Program.Directories.LocalData + "\\Disc\\MM Intro DVD.iso\"";
                System.Diagnostics.Process.Start(cmd, arg);
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); }

        }

        #endregion

        private void OpenClose_Event(object sender, EventArgs e)
        {
            CheckCollapsed();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void VATReport_Btn_Click(object sender, EventArgs e)
        {
            // ReportManager.ReportName is a unique Name
            // Ctrl + . and Enter to create new Name

            // Option 1:
            //ReportManager.NEWReporter.Preview(ReportManager.ReportName.VAT, DMS.TransactionManager, x =>
            //    x.Type == Data.Transactions.TransactionType.Invoice ||
            //    x.Type == Data.Transactions.TransactionType.CancellationOrder ||
            //    x.Type == Data.Transactions.TransactionType.PurchaseOrder ||
            //    x.Type == Data.Transactions.TransactionType.CreditNote);


            // Option 2:
            var data = DMS.TransactionManager.GetDataList(x =>
            x.Type == Data.Transactions.TransactionType.Invoice ||
            x.Type == Data.Transactions.TransactionType.CancellationOrder ||
            x.Type == Data.Transactions.TransactionType.PurchaseOrder ||
            x.Type == Data.Transactions.TransactionType.CreditNote);

            ReportManager.NEWReporter.Preview(ReportManager.ReportName.VAT, data);
        }

        private void TiendeReport_Btn_Click(object sender, EventArgs e)
        {
            var data = DMS.TransactionManager.GetDataList(x =>
            x.Type == Data.Transactions.TransactionType.Invoice ||
            x.Type == Data.Transactions.TransactionType.CancellationOrder ||
            x.Type == Data.Transactions.TransactionType.PurchaseOrder ||
            x.Type == Data.Transactions.TransactionType.CreditNote);

            ReportManager.NEWReporter.Preview(ReportManager.ReportName.Tiende, data);
        }

        private void TaxReport_Btn_Click(object sender, EventArgs e)
        {
            var data = DMS.TransactionManager.GetDataList(x =>
            x.Type == Data.Transactions.TransactionType.Invoice ||
            x.Type == Data.Transactions.TransactionType.CancellationOrder ||
            x.Type == Data.Transactions.TransactionType.PurchaseOrder ||
            x.Type == Data.Transactions.TransactionType.CreditNote);

            ReportManager.NEWReporter.Preview(ReportManager.ReportName.Tax, data);
        }

        private void ClientsReport_Btn_Click(object sender, EventArgs e)
        {
            ReportManager.NEWReporter.Preview(ReportManager.ReportName.Clients, DMS.ClientManager, x => true);
        }
    }
}