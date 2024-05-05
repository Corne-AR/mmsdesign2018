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
using AMS.Data.People;
using Data.Quotes;
using Data;
using Data.People;
using Data.Catalogs;

namespace UserInterface.Quotes.UserControls
{
    public partial class QuoteSummary : UserControl
    {
        // Variables

        private Data.Calculations.MaintenanceCalculator maintenance;

        private Quote quote;
        public Quote Quote
        {
            get { return quote; }
        }

        private bool showPriceInVat = false;
        private bool updating = false;

        System.Timers.Timer Timer = new System.Timers.Timer(2000) { AutoReset = false };
        private bool fxupdating;

        // Declare the ToolTip
        private ToolTip discountToolTip;
        private StringBuilder tooltipStringBuilder; // Add this variable

        // Constructors

        public QuoteSummary()
        {
            InitializeComponent();
            InitializeRightClickMenu(); // Call the method to set up the right-click menu

            // Initialize the StringBuilder for the tooltip
            InitializeCustomToolTip();

            // Initialize the ToolTip
            discountToolTip = new ToolTip();
            discountToolTip.SetToolTip(discount_TextBox, tooltipStringBuilder.ToString());

            // Set the AutoPopDelay for the tooltip
            discountToolTip.AutoPopDelay = 15000; // 3000 milliseconds = 3 seconds
            

        }
        private void InitializeCustomToolTip()
        {
            // Create a StringBuilder for the tooltip
            tooltipStringBuilder = new StringBuilder();
            tooltipStringBuilder.AppendLine("Module discount kan net op nuwe sagteware gebruik word tydens Black Friday.");
            tooltipStringBuilder.AppendLine("Upgrade points discount mag nie op enige modules gebruik word nie.");
            tooltipStringBuilder.AppendLine("Gebruik die discounts net vir berekeninge en as jy dit moet kombineer,");
            tooltipStringBuilder.AppendLine("of bou eerder 'n manual quote met die regte waardes.");
            tooltipStringBuilder.AppendLine("Regs-klik hier vir opsies.");
        }

        private void InitializeRightClickMenu()
        {
            // Create the context menu
            ContextMenuStrip rightClickMenu = new ContextMenuStrip();

            // Declare a variable x and y
            double x = 23.5293007769145; // Model Maker Black friday Modules en new software discount factor
            double y = 21.5864; // Model Maker Black friday Nr of points discount factor

            // Create menu items
            ToolStripMenuItem moduleDiscountItem = new ToolStripMenuItem($"{x:F1}..% Module Discount");
            moduleDiscountItem.Click += (s, e) => SetDiscount(discount_TextBox, x);

            ToolStripMenuItem pointUpgradesDiscountItem = new ToolStripMenuItem($"{y:F1}..% Point Upgrades Discount");
            pointUpgradesDiscountItem.Click += (s, e) => SetDiscount(discount_TextBox, y);

            ToolStripMenuItem noDiscountItem = new ToolStripMenuItem("No Discount");
            noDiscountItem.Click += (s, e) => SetDiscount(discount_TextBox, 0);

            // Add items to the context menu
            rightClickMenu.Items.Add(moduleDiscountItem);
            rightClickMenu.Items.Add(pointUpgradesDiscountItem);
            rightClickMenu.Items.Add(noDiscountItem);

            // Attach the context menu to the discount_TextBox
            discount_TextBox.ContextMenuStrip = rightClickMenu;
        }


        private void SetDiscount(TextBox discount_TextBox, double discountValue)
        {
            discount_TextBox.Text = discountValue.ToString();
        }


        // Loads

        private void Quote_Summary_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetControls(this, ThemeColors.ControlType.List);
            ThemeColors.SetControls(account_Textbox, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(tranactionNr_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(clientName_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(panel1, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(maint_Panel, ThemeColors.ControlType.Menu);

            productList_DataGridView.DefaultCellStyle.BackColor = ThemeColors.InputControl;
            productList_DataGridView.DefaultCellStyle.ForeColor = ThemeColors.InputText;

            productList_DataGridView.DefaultCellStyle.SelectionBackColor = productList_DataGridView.DefaultCellStyle.BackColor;
            productList_DataGridView.DefaultCellStyle.SelectionForeColor = productList_DataGridView.DefaultCellStyle.ForeColor;

            totals_DataGridView.DefaultCellStyle = productList_DataGridView.DefaultCellStyle;
            PriceInVat_Column.DefaultCellStyle.ForeColor = Color.Gray;

            #endregion

            fxupdating = true;

            txt_AbsaFx.Text = AMS_Script.ScriptManager.ABSAFx?.value.ToString();
            txt_ExportFx.Text = AMS_Script.ScriptManager.ExportFx?.value.ToString();
            Timer.Elapsed += FXTimer_Elapsed;

            fxupdating = false;
        }


        /// <summary>
        /// Main entry point for the summary of a quotation
        /// </summary>
        public void LoadQuote(Quote Quote)
        {
            updating = true;

            quote = Quote;

            #region Client Info

            if (quote.UseClient)
            {
                clientBindingSource.DataSource = quote.Client;
                currency_ComboBox.DataSource = AMS.Suite.SuiteManager.Profile.ForexList;

                // Fill Contacts
                contact_ComboBox.Items.Clear();
                if (!string.IsNullOrEmpty(quote.Contact)) contact_ComboBox.Items.Add(quote.Contact);
                if (!string.IsNullOrEmpty(quote.Email)) contact_ComboBox.Items.Add(quote.Email);
                contact_ComboBox.Items.Add(quote.Client.Name);

                foreach (var p in DMS.PeopleManager.GetDataList())
                    if (quote.Client.PeopleIDList != null && quote.Client.PeopleIDList.Contains(p.ID))
                        contact_ComboBox.Items.Add(p.DisplayName);

                contact_ComboBox.Text = quote.Contact;
                email_TextBox.Text = quote.Email;
            }

            #endregion

            // quote.UseMaintence = quote.MaintenanceType != MaintenanceType.Expired;
            maintenance = new Data.Calculations.MaintenanceCalculator();

            #region Defaults

            if (string.IsNullOrEmpty(quote.ID))
            {
                switch (quote.MaintenanceType)
                {
                    case MaintenanceType.New:

                        if (DateTime.Now.Day <= 15) quote.ExtendDate = DateTime.Now.AddMonths(13);
                        else quote.ExtendDate = DateTime.Now.AddMonths(14);

                        break;

                    case MaintenanceType.Expiring:

                        quote.ExtendDate = quote.Client.Expirydate.AddMonths(12);

                        break;

                    case MaintenanceType.Current:

                        quote.ExtendDate = quote.Client.Expirydate;

                        break;

                    case MaintenanceType.Expired:

                        break;
                }

                if (quote.ExtendDate > extended_DateTimePicker.MinDate) extended_DateTimePicker.Value = quote.ExtendDate;
            }

            #endregion

            if (Quote.ProgressType == ProgressType.New)
            {
                try { this.Quote.AbsaFx = Convert.ToDecimal(AMS_Script.ScriptManager.ABSAFx?.value.ToString()); }
                catch { }

                try { this.Quote.ExportFx = Convert.ToDecimal(AMS_Script.ScriptManager.ExportFx?.value.ToString()); }
                catch { }
            }

            lblAbsaFx.Text = this.Quote.AbsaFx.ToString();
            lblExportFx.Text = this.Quote.ExportFx.ToString();
            updating = false;

            SetControls();
            UpdateQuote();
        }

        // Methods

        public void UpdateQuote()
        {
            try
            {
                updating = true;

                if (contact_ComboBox.Text.Trim().Length > 0) quote.Contact = contact_ComboBox.Text;
                if (email_TextBox.Text.Trim().Length > 0) quote.Email = email_TextBox.Text;
                try { if (discount_TextBox.Text.Trim().ToString().Count() > 0) quote.Discount = Convert.ToDecimal(discount_TextBox.Text.ToString()); }
                catch { }
                if (addCost_TextBox.Text.Trim().ToString().Count() != 0) quote.AddtoCost = Convert.ToDecimal(addCost_TextBox.Text.ToString());

                quote.Itemized = itemized_CheckBox.Checked;
                quote.CODOnly = codOnly_checkBox.Checked;

                // Calculate and Summarize
                quote.Calculate();

                // Print out values
                var totalsList = new List<Data.Products.Product>();

                totalsList.Add(new Data.Products.Product()
                {
                    Description = "Sub-Total",
                    PriceExVat = quote.SubTotal
                });

                totalsList.Add(new Data.Products.Product()
                {
                    Description = "VAT",
                    PriceExVat = quote.VATTotal
                });

                if (quote.PaymentTerms == "COD")
                {
                    totalsList.Add(new Data.Products.Product()
                    {
                        Description = "COD Discount",
                        PriceExVat = quote.CODTotal
                    });
                    totalsList.Add(new Data.Products.Product()
                    {
                        Description = "Total Due",
                        PriceExVat = quote.Total
                    });
                }
                else
                {
                    totalsList.Add(new Data.Products.Product()
                    {
                        Description = "Total Due",
                        PriceExVat = quote.Total
                    });
                    totalsList.Add(new Data.Products.Product()
                    {
                        Description = "COD Discount",
                        PriceExVat = quote.CODTotal
                    });
                }

                itemList_BindingSource.DataSource = quote.Transaction.ItemList;
                totals_BindingSource.DataSource = totalsList;

                updating = false;

                UpdateMaintenance();
                SetControls();
            }
            catch { }
        }

        private void UpdateMaintenance()
        {
            updating = true;
            quote.ExtendMonths = 0;

            if (quote.UseMaintence)
            {
                quote.ExtendDate = extended_DateTimePicker.Value;
                maintenance.CalculationMaintenance(this.quote);
                if (maintenance.AddCurrentMaintenance) { AddCurrentMaintenace(); updating = true; }
                quote.ExtendMonths = maintenance.ExtendMonths;
            }

            extendMonths_TextBox.Text = quote.ExtendMonths.ToString();
            maintenance_CheckBox.Checked = quote.UseMaintence;

            extended_DateTimePicker.Visible = quote.UseMaintence;

            quote.ExtendDate = new DateTime(quote.ExtendDate.Year, quote.ExtendDate.Month, 1);
            if (quote.ExtendDate > extended_DateTimePicker.MinDate) extended_DateTimePicker.Value = quote.ExtendDate;

            if (quote.Client.HasSupport) maint_Panel.BackColor = AMS.ThemeColors.Green;
            if (quote.Client.Expirydate < DateTime.Now) maint_Panel.BackColor = AMS.ThemeColors.Blue;
            if (quote.Client.Expirydate < DateTime.Now.AddMonths(-1)) maint_Panel.BackColor = AMS.ThemeColors.Orange;
            if (!quote.Client.HasSupport && quote.Client.Expirydate < DateTime.Now.AddMonths(-3)) maint_Panel.BackColor = AMS.ThemeColors.Red;

            maintenance_CheckBox.BackColor = maint_Panel.BackColor;
            maintenance_CheckBox.ForeColor = Color.White;
            extendMonths_TextBox.BackColor = maint_Panel.BackColor;
            extendMonths_TextBox.ForeColor = Color.White;
            months_Label.BackColor = maint_Panel.BackColor;
            months_Label.ForeColor = Color.White;

            updating = false;
        }

        private void AddCurrentMaintenace()
        {
            updating = true;

            string catName = "Maintenance";
            var queryMaintCatalog = (from i in quote.QuoteCatalogList
                                     where i.Name == catName
                                     where i.ID == catName
                                     select i).FirstOrDefault();

            if (queryMaintCatalog == null)
            {
                queryMaintCatalog = new Data.Catalogs.Catalog();
                queryMaintCatalog.ID = catName;
                queryMaintCatalog.Name = catName;
                queryMaintCatalog.Itemized = true;

                quote.QuoteCatalogList.Add(queryMaintCatalog);
            }
            if (queryMaintCatalog.ItemList == null) queryMaintCatalog.ItemList = new List<Data.Catalogs.CatalogItem>();
            if (queryMaintCatalog.ItemList.Count == 0) queryMaintCatalog.ItemList.Add(new Data.Catalogs.CatalogItem());

            queryMaintCatalog.ItemList[0].Name = "Annual software subscription renewal valid until: " + string.Format("{0:MMMM yyyy}", extended_DateTimePicker.Value);
            queryMaintCatalog.ItemList[0].ListPrice = maintenance.CurrentMaintValue;
            queryMaintCatalog.ItemList[0].Selected = true;

            ((UserInterface.Quotes.Forms.QuoteForm)Parent).LoadCatalogList();

            updating = false;
        }

        private void SetControls()
        {
            updating = true;

            #region Contact details
            // Removing Events to prevent unwanted triggering of value change
            contact_ComboBox.SelectedIndexChanged -= UpdateQuoteDetails_Event;

            // Set Values
            contact_ComboBox.Text = quote.Contact;
            email_TextBox.Text = quote.Email;

            // Add events again for normal triggers
            contact_ComboBox.SelectedIndexChanged += UpdateQuoteDetails_Event;

            #endregion

            if (quote.PaymentTerms == "COD") cod_RadioButton.Checked = true;
            if (quote.PaymentTerms == "30Day") thirtyDay_RadioButton.Checked = true;

            currency_ComboBox.Text = quote.Currency;

            tranactionNr_Label.Text = quote.ID;
            itemized_CheckBox.Checked = quote.Itemized;
            codOnly_checkBox.Checked = quote.CODOnly;
            discount_TextBox.Text = quote.Discount.ToString();
            addCost_TextBox.Text = quote.AddtoCost.ToString();

            if (quote.ExtendDate > extended_DateTimePicker.MinDate) extended_DateTimePicker.Value = quote.ExtendDate;

            // thirtyDay_RadioButton.Enabled = !quote.Client.IsInternational;
            PriceInVat_Column.Visible = showPriceInVat;

            quoteInfo_Label.Text = string.Format("{0} - {1:dd MMM yyyy - hh:mm:ss}", "Totals", quote.QuoteDate);

            updating = false;
        }

        // Events

        private void UpdateMaintenance_Event(object sender, EventArgs e)
        {
            if (updating) return;

            quote.UseMaintence = maintenance_CheckBox.Checked;
            quote.ExtendDate = extended_DateTimePicker.Value;

            // Reset messages
            if (sender == maintenance_CheckBox && quote.UseMaintence) maintenance.ShowMessages = true;

            #region Expired Maintenance

            if (quote.UseMaintence && quote.MaintenanceType == MaintenanceType.Expired)
            {
                if (AMS.MessageBox_v2.Show("This client's maintenance has expired.\r\nEmail supplier(s) now for upgrade quote?\r\n\r\nTel: 012 665 0120", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    var list = Data.Transactions.Utilities.SupplierList(quote);

                    foreach (var i in list)
                    {
                        var mail = DMS.MailManager.NewMail(
                           i.Account,
                           true,
                           "Upgrade Quote",
                           null,
                           null,
                           Data.Communications.TemplateTypes.SupplierUpgrade);

                        DMS.MailManager.SendGeneralMail(mail);
                    }
                }

                // quote.UseMaintence = false; _Corne was hier
            }

            #endregion

            UpdateMaintenance();
        }

        private void UpdateQuote_Event(object sender, EventArgs e)
        {
            if (updating) return;
            UpdateQuote();
        }

        private void UpdateQuoteDetails_Event(object sender, EventArgs e)
        {
            if (updating) return;

            // Contact
            if (quote.Account != null)
            {
                email_TextBox.Text = "";

                string email = "";

                foreach (var id in quote.Client.PeopleIDList)
                {
                    var person = DMS.PeopleManager.GetData(qi => qi.ID == id);
                    if (person != null && person.DisplayName.Trim().ToUpper() == contact_ComboBox.Text.Trim().ToUpper())
                        email = person.Email;
                }

                if (email == null) email = quote.Client.Email;

                if (email != null && contact_ComboBox.SelectedIndex > 0) email_TextBox.Text = email.ToString().Trim();
                if (email_TextBox.Text.Count() < 6) email_TextBox.Text = DMS.ClientManager.GetData(i => i.Account == quote.Account).Email;

                quote.Contact = contact_ComboBox.Text;
                quote.Email = email_TextBox.Text;
            }

            // Check Settings for Quote
            quote.Currency = currency_ComboBox.Text;

            if (cod_RadioButton.Checked) quote.PaymentTerms = "COD";
            if (thirtyDay_RadioButton.Checked) quote.PaymentTerms = "30Day";

            UpdateQuote();
        }

        private void showPriceInVatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPriceInVat = !showPriceInVat;
            PriceInVat_Column.Visible = showPriceInVat;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.absa.co.za/indices/exchange-rates/");
        }

        private void txt_AbsaFx_TextChanged(object sender, EventArgs e)
        {
            if (fxupdating) return;
            try
            {
                var value = Convert.ToDecimal(txt_AbsaFx.Text);
                if (!Timer.Enabled) Timer.Start();
                else
                {
                    Timer.Stop();
                    Timer.Start();
                }

                quote.AbsaFx = value;
            }
            catch
            {

            }
        }

        private void txt_ExportFx_TextChanged(object sender, EventArgs e)
        {
            if (fxupdating) return;
            try
            {
                var value = Convert.ToDecimal(txt_ExportFx.Text);
                if (!Timer.Enabled) Timer.Start();
                else
                {
                    Timer.Stop();
                    Timer.Start();
                }

                quote.ExportFx = value;
            }
            catch { }
        }

        private void FXTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            fxupdating = true;
            var saved = false;

            this.Invoke((MethodInvoker)delegate
            {
                saved = AMS.MessageBox_v2.Show("Save FX?", MessageType.Question) == MessageOut.YesOk;

                if (saved)
                {
                    AMS_Script.ScriptManager.ABSAFx.value = Quote.AbsaFx;
                    AMS_Script.ScriptManager.ExportFx.value = Quote.ExportFx;

                    AMS_Script.ScriptManager.Save();
                }
                else
                {
                    txt_AbsaFx.Text = AMS_Script.ScriptManager.ABSAFx?.value.ToString();
                    txt_ExportFx.Text = AMS_Script.ScriptManager.ExportFx?.value.ToString();
                }
            });

            fxupdating = false;
        }

        private void showItemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productList_DataGridView.SelectedRows.Count < 1) return;

            var selectedItem = productList_DataGridView.SelectedRows[0].DataBoundItem as Data.Products.Product;

            if (selectedItem != null)
                MessageBox.Show(selectedItem.CalculationInfo);
        }

        // Add the new right-click event handler
        private void discount_TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Show context menu
                discount_TextBox.ContextMenuStrip.Show(discount_TextBox, e.Location);
            }
        }

        // Modify the existing MouseMove event handler for the tooltip
        private void discount_TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Show the dynamic tooltip
            discountToolTip.Show(tooltipStringBuilder.ToString(), discount_TextBox, e.Location);
        }
    }
}