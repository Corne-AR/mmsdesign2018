using AMS;
using UserInterface.Transactions;
using Data;
using Data.Catalogs;
using Data.People;
using Data.Quotes;
using Data.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Quotes.Forms
{
    public partial class QuoteForm : Form
    {
        // Variables

        Quote quote;
        bool loading = false;
        string filterCatalog;

        public Catalog SelectedCatalog { get; private set; }

        // Constructors

        public QuoteForm()
        {
            InitializeComponent();
            if (quote == null) quote = new Quote();
            quote.UseClient = false;
            quote.UseMaintence = true;
            quote.ExtendMonths = 12;
        }

        public QuoteForm(Client Client)
        {
            InitializeComponent();
            if (quote == null) quote = new Quote();
            quote.UseClient = true;
            quote.Account = Client.Account;
        }

        public QuoteForm(Quote Quote)
        {
            InitializeComponent();
            this.quote = Quote;
        }

        public QuoteForm(string QuoteID)
        {
            InitializeComponent();

            var quote = DMS.QuoteManager.GetData(i => i.ID == QuoteID);
            if (quote == null) quote = new Quote();
            this.quote = quote;
        }

        public QuoteForm(Transaction Transaction)
        {
            InitializeComponent();

            var quote = DMS.QuoteManager.GetData(i => i.ID == Transaction.ID);
            if (quote == null) quote = new Quote();
            this.quote = quote;
        }

        // Load

        private void Quotes_Load(object sender, EventArgs e)
        {
            #region Theme

            header1.UseControls(this, true, true, true);

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(utiliteis_FlowLayoutPanel.Controls);
            ThemeColors.SetControls(cataGroupButtons_Panel, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(catalogButtons_Panel, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(spacers_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(spacerTerms_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(spacerTotals_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(status_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetBorders(this);

            #endregion

            if (quote == null) return;
            loading = true;

            #region Window Properties

            if (!string.IsNullOrEmpty(quote.ID)) this.Text = quote.ID;
            else this.Text = "New Quote";

            int maxHeight = 1000;
            if (Screen.FromControl(this).WorkingArea.Height < 1000) maxHeight = Screen.FromControl(this).WorkingArea.Height;
            this.Size = new Size(this.Size.Width, maxHeight - 20);
            this.Location = new Point(Screen.FromControl(this).WorkingArea.Width / 2 - this.Size.Width / 2, Screen.FromControl(this).WorkingArea.Height / 2 - this.Size.Height / 2);

            Bitmap b = UserInterface.Properties.Resources.Q;
            this.Icon = Icon.FromHandle(b.GetHicon());

            if (!quote.UseClient)
            {
                proceed_Button.Enabled = false;
                btnReport.Enabled = false;
            }

            #endregion

            quoteBindingSource.DataSource = quote;

            // Set Defaults
            if (string.IsNullOrEmpty(quote.Contact) && quote.Client != null && quote.Client.Account != null)
                quote.Contact = quote.Client.GetMainContact.DisplayName;

            if (string.IsNullOrEmpty(quote.Email) && quote.Client != null && quote.Client.Account != null)
                quote.Contact = quote.Client.GetMainContact.DisplayName;

            LoadCatalogButtons();

            // Tooltip
            toolTip1.SetToolTip(reload_Button, "Reloads all current data into quote.\r\nReplacing old client info and old catalogs");

            loading = false;

            quote_Summary.LoadQuote(quote);     // Send quote to the summary control
            LoadCatalogList();                  // Load any Catalogs in an existing quote
            SetButtons();
        }

        #region Drop Shadow

        private const int CS_DROPSHADOW = 0x20000;
        private string p;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        #endregion

        // Methods

        /// <summary>
        /// Loads buttons for each catalog group. Note will check the filterCatalog to refine buttons
        /// </summary>
        private void LoadCatalogButtons()
        {
            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(group_FlowLayoutPanel);
            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(catalogList_FlowLayoutPanel);

            foreach (var i in DMS.CatalogGroupManager.CatalogGroup)
            {
                bool add = false;

                if (!string.IsNullOrEmpty(filterCatalog))
                {
                    var catalogList = DMS.CatalogManager.GetDataList(qi => qi.CatalogGroup == i).ToList();

                    if (catalogList != null)
                    {
                        foreach (var catalog in catalogList)
                        {
                            var hasCataItem = (from ci in catalog.ItemList
                                               where
                                               (ci.Content != null && ci.Content.ToLower().Contains(filterCatalog.ToLower())) ||
                                               (ci.Description != null && ci.Description.ToLower().Contains(filterCatalog.ToLower())) ||
                                               (ci.Name != null && ci.Name.ToLower().Contains(filterCatalog.ToLower())) ||
                                               (ci.RetailPrice.ToString().ToLower().Contains(filterCatalog.ToLower())) ||
                                               (ci.ListPrice.ToString().ToLower().Contains(filterCatalog.ToLower()))
                                               select ci).FirstOrDefault();

                            if (hasCataItem == null) add = true;
                        }
                    }
                }
                else
                {
                    add = true;
                }

                if (add)
                {
                    Button button = new Button();
                    button.AutoSize = true;
                    button.FlatStyle = FlatStyle.Popup;
                    ThemeColors.SetControls(button, ThemeColors.ControlType.Menu);
                    button.Click += ViewGroup_Click;
                    button.Text = i.ToString();

                    group_FlowLayoutPanel.Controls.Add(button);
                }
            }
        }

        public void RefreshCatalogList()
        {
            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(catalogList_FlowLayoutPanel);

            // Check list of catalogs in quote, and make sure they have buttons, else remove them from the list
            foreach (var catalog in quote.QuoteCatalogList)
            {
                UserControls.CatalogName cataNameUC = new UserInterface.Quotes.UserControls.CatalogName(catalog);
                cataNameUC.Size = new System.Drawing.Size(catalogList_FlowLayoutPanel.Width - 3, 26);

                cataNameUC.Click += Catalog_Click;                      // Loads Product List
                cataNameUC.Remove_Button.Click += RemoveCatalog_Event;  // Remove from CatalogList
                cataNameUC.Duplicate_Button.Click += DuplicateCatalog_Event;
                cataNameUC.ContextMenuStrip = catalog_ContextMenuStrip;

                catalogList_FlowLayoutPanel.Controls.Add(cataNameUC);
            }

            catalogList_FlowLayoutPanel.Update();
            System.Windows.Forms.Application.DoEvents();
        }

        public void LoadCatalogList()
        {
            // Check list of catalogs in quote, and make sure they have buttons, else remove them from the list
            foreach (var catalog in quote.QuoteCatalogList)
            {
                bool add = true;

                foreach (Control c in catalogList_FlowLayoutPanel.Controls)
                {
                    var uc = ((UserInterface.Quotes.UserControls.CatalogName)c);
                    if (uc.Catalog == catalog) add = false;
                }

                if (add)
                {
                    UserControls.CatalogName cataNameUC = new UserInterface.Quotes.UserControls.CatalogName(catalog);
                    cataNameUC.Size = new System.Drawing.Size(catalogList_FlowLayoutPanel.Width - 3, 26);

                    cataNameUC.Click += Catalog_Click;                      // Loads Product List
                    cataNameUC.Remove_Button.Click += RemoveCatalog_Event;  // Remove from CatalogList
                    cataNameUC.Duplicate_Button.Click += DuplicateCatalog_Event;
                    cataNameUC.ContextMenuStrip = catalog_ContextMenuStrip;

                    catalogList_FlowLayoutPanel.Controls.Add(cataNameUC);
                }
            }

            // Remove unwanted controls
            foreach (Control c in catalogList_FlowLayoutPanel.Controls)
            {
                var uc = ((UserInterface.Quotes.UserControls.CatalogName)c);

                var queryList = (from i in quote.QuoteCatalogList
                                 where i == uc.Catalog
                                 select i).FirstOrDefault();

                if (queryList == null)
                {
                    catalogList_FlowLayoutPanel.Controls.Remove(c);
                    c.Dispose();
                }
            }

            catalogList_FlowLayoutPanel.Update();
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// This is for a time based update
        /// </summary>
        public void UpdateQuote()
        {
            calc_Timer.Start();
        }

        /// <summary>
        /// Do updates now
        /// </summary>
        private void DoUpdates()
        {
            quote_Summary.UpdateQuote();

            quote.Contact = quote_Summary.Quote.Contact;
            quote.Email = quote_Summary.Quote.Email;
            status_Label.Text = string.Format("Status: {0}\r\nQuote Date: {1:dd MMM yyyy - hh:mm:ss}", quote.ProgressType, quote.QuoteDate);

            // Set Button Flags
            SetButtons();

            if (!string.IsNullOrEmpty(quote.ID)) this.Text = quote.ID;
            else this.Text = "New Quote";
        }

        private void SetButtons()
        {
            bool colorSave = (quote.Metadata.Created < new DateTime(1900, 1, 1));
            bool colorMail = (quote.Metadata.EmailDate < new DateTime(1900, 1, 1)); ;
            bool colorProceed = !colorMail && quote.ProgressType != ProgressType.Finalized;
            bool colorClose = quote.ProgressType == ProgressType.Finalized;

            if (colorSave) ThemeColors.SetControls(save_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(save_Button, ThemeColors.ControlType.Menu);
            save_Button.Enabled = quote.ProgressType == ProgressType.New;

            if (colorMail) ThemeColors.SetControls(btnReport, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(btnReport, ThemeColors.ControlType.Menu);

            if (colorProceed) ThemeColors.SetControls(proceed_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(proceed_Button, ThemeColors.ControlType.Menu);

            if (colorClose) ThemeColors.SetControls(close_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(close_Button, ThemeColors.ControlType.Menu);

            ThemeColors.SetControls(reload_Button, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(setToClient_Button, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(newQuote_Button, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(utilites_Button, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(updateQuote_Button, ThemeColors.ControlType.Menu);
        }

        private void Proceed()
        {
            // 1. Check if Finalized
            // 2. Reset code fields and get defaults
            // 3. Confirmation Form for Update/Create products
            // 4. Update client's maintenance
            // 5. Do final quote update using new client updates and save
            // 6. Open the transaction form with quoted client

            // Check if Finalized
            if (quote.ProgressType == ProgressType.Finalized)
            {
                AMS.MessageBox_v2.Show("Quote has already been processed on the " + string.Format("{0:dd MMMM yyyy}", quote.Metadata.Modified) + " by " + quote.Metadata.UserName + "\r\nExisting quotation");
                this.Close();
                return;
            }

            // Reset code fields and get defaults
            bool saved = false;
            bool hasMaintenance = false;
            var client = DMS.ClientManager.GetData(i => i.Account == quote.Account);

            quote_Summary.UpdateQuote();
            quote.Contact = quote_Summary.Quote.Contact;
            quote.Email = quote_Summary.Quote.Email;

            this.Hide();

            // Update/Create products
            if (quote.CaluclatedCatalogList.Where(i => !i.NonProduct).Count() > 0)
            {
                // Workaround for Saved quotes //

                int index = 0;
                foreach (var cat in quote.CaluclatedCatalogList)
                {
                    var catelog = quote.QuoteCatalogList[index];
                    cat.ProductName = catelog.ProductName;

                    index++;
                }

                //////////////////////////////

                using (QuoteConfirmation f = new QuoteConfirmation(quote))
                {
                    f.ShowDialog();
                    saved = f.Saved;
                    hasMaintenance = f.HasMaintenance;
                }
            }
            else
            {
                saved = AMS.MessageBox_v2.Show("There were no products in this quote.\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk;
            }

            // Proceed if all is excepted
            if (saved)
            {
                // Update client's maintenance
                if (hasMaintenance && quote.MaintenanceType != MaintenanceType.Current && quote.UseMaintence)
                {
                    client.Expirydate = quote.ExtendDate;
                    client.Save(string.Format("Quote " + quote.ID + " - Maintenance set from {0:MMM yyyy} to {1:MMM yyyy}", quote.Client.Expirydate, quote.ExtendDate), true, true);
                }

                // Set finalized
                if (quote.ProgressType == ProgressType.New) quote.QuoteDate = DateTime.Now;
                quote.ProgressType = ProgressType.Finalized;

                // Do final quote update using new client updates and save
                DoUpdates();
                quote.Save("Updating Quote", true, false, ProgressType.Finalized);

                // Open the transaction form with quoted client
                this.Close();
                DMS.ClientManager.SetCurrent(i => i.Account == quote.Account);
                quote.Transaction.ID = null;
                using (UserInterface.Transactions.Forms.TransactionForm f = new Transactions.Forms.TransactionForm(quote.ID))
                    f.ShowDialog();
            }
            else
            {
                this.Show();
            }
        }

        private void LoadCatalog(Catalog cata)
        {
            catalogUC.LoadCatalog(cata, quote);
            SelectedCatalog = cata;
        }

        // Events

        #region ---------- Catalog ----------

        private void AddCatalogToQuote_Click(object sender, EventArgs e)
        {
            group_FlowLayoutPanel.Enabled = false;

            // Adds Catalog to Quote CataLogList
            Catalog cata = (Catalog)DMS.CatalogManager.GetData(i => i.Name == ((Button)sender).Text).Clone();
            cata.ID = AMS.Data.Keys.UniqueKey.NewShortCode();
            quote.AddToCatalog(cata);

            // Finally Load CataLogList
            LoadCatalogList();

            foreach (UserControls.CatalogName uc in catalogList_FlowLayoutPanel.Controls)
                uc.SetUnSelected();

            ((UserControls.CatalogName)catalogList_FlowLayoutPanel.Controls[catalogList_FlowLayoutPanel.Controls.Count - 1]).SetSelected();
            LoadCatalog(cata);

            // check if catalog has maintenance item
            var maintItems = cata.ItemList.Where(i => i.Maintenance).FirstOrDefault();
            if (maintItems != null) quote.UseMaintence = true;
        }


        private void Catalog_Click(object sender, EventArgs e)
        {
            // Using the Catalog within the user control as the Loaded Product List
            var catalog = ((UserControls.CatalogName)sender).Catalog;
            LoadCatalog(catalog);

            foreach (UserControls.CatalogName uc in catalogList_FlowLayoutPanel.Controls)
            {
                uc.SetUnSelected();
                ((UserControls.CatalogName)sender).SetSelected();
            }
        }

        private void DuplicateCatalog_Event(object sender, EventArgs e)
        {
            UserControls.CatalogName cataUC = (UserControls.CatalogName)((Button)sender).Parent;
            quote.QuoteCatalogList.Add((Catalog)cataUC.Catalog.Clone());

            // Finally Load
            LoadCatalogList();
        }

        private void RemoveCatalog_Event(object sender, EventArgs e)
        {
            UserControls.CatalogName cataUC = (UserControls.CatalogName)((Button)sender).Parent;
            quote.QuoteCatalogList.Remove(cataUC.Catalog);

            if (quote.QuoteCatalogList.Count == 0) group_FlowLayoutPanel.Enabled = true;

            // Finally Load
            LoadCatalogList();
        }

        #endregion

        #region ---------- Form ----------

        private void ViewGroup_Click(object sender, EventArgs e)
        {
            string GroupName = ((Button)sender).Text;

            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(cataButtons_FlowLayoutPanel);
            foreach (var i in DMS.CatalogManager.GetDataList(qi => qi.CatalogGroup == GroupName))
            {
                bool add = true;

                if (!string.IsNullOrEmpty(filterCatalog))
                {
                    var hasCataItem = (from ci in i.ItemList
                                       where
                                       (ci.Content != null && ci.Content.ToLower().Contains(filterCatalog.ToLower())) ||
                                       (ci.Description != null && ci.Description.ToLower().Contains(filterCatalog.ToLower())) ||
                                       (ci.Name != null && ci.Name.ToLower().Contains(filterCatalog.ToLower())) ||
                                       (ci.RetailPrice.ToString().ToLower().Contains(filterCatalog.ToLower())) ||
                                       (ci.ListPrice.ToString().ToLower().Contains(filterCatalog.ToLower()))
                                       select ci).FirstOrDefault();

                    if (hasCataItem == null) add = false;
                }

                if (add)
                {
                    Button b = new Button();
                    b.AutoSize = true;
                    b.FlatStyle = FlatStyle.Popup;
                    ThemeColors.SetControls(b, ThemeColors.ControlType.Menu);
                    b.Click += AddCatalogToQuote_Click;
                    b.Text = i.Name;

                    cataButtons_FlowLayoutPanel.Controls.Add(b);
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proceed_Click(object sender, EventArgs e)
        {
            Proceed();
        }

        private void updateQuote_Button_Click(object sender, EventArgs e)
        {
            DoUpdates();
            catalogUC.UpdateCatalog();
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            DoUpdates();
            if (quote.ProgressType != ProgressType.Finalized)
                quote.Save("Updating Quote", true, false, quote.ProgressType);
        }

        private void UpdateCatalog_Click(object sender, EventArgs e)
        {
            calc_Timer.Stop();
            DoUpdates();
        }

        #endregion

        private void MoveItemUp_Click(object sender, EventArgs e)
        {
            if (quote.QuoteCatalogList == null || quote.QuoteCatalogList.Count < 2) return;
            var catalog = ((UserInterface.Quotes.UserControls.CatalogName)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Catalog;

            var newList = new List<Catalog>();
            foreach (var i in quote.QuoteCatalogList)
                newList.Add(i);

            int idx = newList.IndexOf(catalog);
            if (idx - 1 <= 0) return;

            Catalog moveitem = newList[idx];
            newList.Remove(moveitem);
            newList.Insert(idx - 1, moveitem);

            quote.SetQuoteList(newList);
            RefreshCatalogList();
        }

        private void MoveItemDown_Click(object sender, EventArgs e)
        {
            if (quote.QuoteCatalogList == null || quote.QuoteCatalogList.Count < 2) return;
            var catalog = ((UserInterface.Quotes.UserControls.CatalogName)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Catalog;

            var newList = new List<Catalog>();
            foreach (var i in quote.QuoteCatalogList)
                newList.Add(i);

            int idx = newList.IndexOf(catalog);
            if (idx + 1 >= quote.QuoteCatalogList.Count) return;


            Catalog moveitem = newList[idx];
            newList.Remove(moveitem);
            newList.Insert(idx + 1, moveitem);

            quote.SetQuoteList(newList);
            RefreshCatalogList();
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshCatalogList();
        }

        private void reload_Button_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.ShowProcess("Reloading Data");

            if (quote.QuoteDate < DateTime.Now.AddDays(-30)) quote.ID = null;

            //try
            //{
            //    quote.QuoteClient = DMS.ClientManager.GetData(i => i.Account == quote.Account);
            //}
            //catch (Exception ex) { AMS.MessageBox_v2.Show("Cannot update client.\r\n\r\n" + ex.Message, AMS.MessageType.Error); }

            try
            {
                foreach (var cat in quote.QuoteCatalogList)
                {
                    AMS.MessageBox_v2.ShowProcess("Reloading Data\r\n" + cat.Name);

                    var catalog = DMS.CatalogManager.GetData(qi => qi.Name == cat.Name);
                    if (catalog != null)
                    {
                        foreach (var item in cat.ItemList)
                        {
                            var queryItem = (from i in catalog.ItemList
                                             where i.Name == item.Name
                                             select i).FirstOrDefault();

                            if (queryItem != null)
                            {
                                item.BulkDiscount = queryItem.BulkDiscount;
                                item.CatalogDefaultScript = queryItem.CatalogDefaultScript;
                                item.CatalogID = queryItem.CatalogID;
                                item.COD = queryItem.COD;
                                item.Code = queryItem.Code;
                                item.Content = queryItem.Content;
                                item.Description = queryItem.Description;
                                item.Forex = queryItem.Forex;
                                item.GlobalDiscount = queryItem.GlobalDiscount;
                                item.ID = queryItem.ID;
                                item.ListPrice = queryItem.ListPrice;
                                item.Maintenance = queryItem.Maintenance;
                                item.Name = queryItem.Name;
                                item.PartNr = queryItem.PartNr;
                                item.RetailScript = queryItem.RetailScript;
                                item.Stolen = queryItem.Stolen;
                                item.SupplierID = queryItem.SupplierID;
                                item.Version = queryItem.Version;
                            }
                        }
                    }
                    else
                    {
                        AMS.MessageBox_v2.Show("Catalog '" + cat.Name + "' not found!\r\nIt is recommended to delete the catalog from the quote");
                    }
                }
                quote.ResetCalcuation();
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show("Unable to update catalogs.\r\n\r\n" + ex.Message, MessageType.Error); }

            DoUpdates();
            quote_Summary.LoadQuote(quote);

            AMS.MessageBox_v2.EndProcess();
        }

        private void ViewQuotedRetailScript_Click(object sender, EventArgs e)
        {
            var catalog = ((UserInterface.Quotes.UserControls.CatalogName)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Catalog;
            catalog.ViewQuotedRetailScript();
        }

        private void ViewQuotedForexScript_Click(object sender, EventArgs e)
        {
            var catalog = ((UserInterface.Quotes.UserControls.CatalogName)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Catalog;
            catalog.ViewQuotedForex();
        }

        private void utilites_Button_Click(object sender, EventArgs e)
        {
            utiliteis_FlowLayoutPanel.Visible = !utiliteis_FlowLayoutPanel.Visible;
            setToClient_Button.Text = "Set to " + DMS.ClientManager.CurrentData.Name;
        }

        private void setToClient_Button_Click(object sender, EventArgs e)
        {
            quote.SetNewClient(DMS.ClientManager.CurrentData);
            quote_Summary.LoadQuote(quote);
            UpdateQuote();
        }

        private void newQuote_Button_Click(object sender, EventArgs e)
        {
            if (quote.DuplicateQuote() != null) this.Close();
        }

        private void cataSearch_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                filterCatalog = cataSearch_TextBox.Text;
                LoadCatalogButtons();
            }
        }

        private void cataSearchClear_Button_Click(object sender, EventArgs e)
        {
            filterCatalog = null;
            cataSearch_TextBox.Text = "";
            LoadCatalogButtons();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    quote.Save("Saving as PriceList", true, true, ProgressType.New);
        //    ReportManager.Manager.ShowPricelist(quote.ID);
        //}

        private void SelectAll_Button_Click(object sender, EventArgs e)
        {
            foreach (var i in SelectedCatalog.ItemList) i.Selected = true;
        }

        private void btnCustomCOD_Click(object sender, EventArgs e)
        {
            var value = "";
            try
            {
                if (AMS.MessageBox_v2.Show("Custom COD", quote.CustomCOD.ToString()) == MessageOut.YesOk)
                {
                    value = AMS.MessageBox_v2.MessageValue.Trim().Replace(" ", "").Replace("r", "").Replace("R", "");
                    quote.CustomCOD = Convert.ToDecimal(value);
                }
            }
            catch { AMS.MessageBox_v2.Show($"Could not covert value: {value}"); }
        }

        private void Report_Click(object sender, EventArgs e)
        {
            DoUpdates();

            if (quote.ProgressType != ProgressType.Finalized)
                quote.Save("Updating Quote", true, false, quote.ProgressType);

            this.Hide();
            // Make PDF and Email
            if (ReportManager.QuoteReport(quote.ID))
            {
                quote.Save("Mailing Quote", true, true, ProgressType.Mailed);
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void catalog_ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void catalogUC_Load(object sender, EventArgs e)
        {

        }

        private void quoteBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}