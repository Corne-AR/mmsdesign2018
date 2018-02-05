using AMS;
using Data;
using Data.Catalogs;
using ReportManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Catalogs.Forms
{
    public partial class Commerce_Manager : Form
    {

        // Constructors

        public Commerce_Manager()
        {
            InitializeComponent();

            this.footer1.UpdateFooterText("Catalog");
        }

        #region Drop Shadow

        private const int CS_DROPSHADOW = 0x20000;
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

        // Load

        private void Commerce_Manager_Load(object sender, EventArgs e)
        {
            header1.UseControls(this, true, false, true);

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(menuStrip1, ThemeColors.ControlType.Menu);

            #region Window Properties

            int maxHeight = Screen.FromControl(this).WorkingArea.Height - 70;
            int maxWidth = Screen.FromControl(this).WorkingArea.Width - 100;

            this.Size = new Size(maxWidth, maxHeight);
            this.Location = new Point(Screen.FromControl(this).WorkingArea.Width / 2 - this.Size.Width / 2, Screen.FromControl(this).WorkingArea.Height / 2 - this.Size.Height / 2);

            #endregion

            cboxReport.Items.AddRange(ReportManager.ReportNameExtensions.GetNames().ToArray());
            cboxReport.SelectedIndex = 0;
            cboxReport.SelectedIndexChanged += CboxReport_SelectedIndexChanged;

            LoadCatalogGroups();
        }


        // Methods

        private void LoadCatalogGroups()
        {
            group_ComboBox.Items.Clear();
            group_ComboBox.Items.Add("- Unsorted - ");

            foreach (var i in DMS.CatalogGroupManager.CatalogGroup)
            {
                group_ComboBox.Items.Add(i.ToString());
            }

            LoadCatalogs();
        }

        private void LoadCatalogs()
        {
            string filter = "";
            if (group_ComboBox.SelectedItem != null) filter = group_ComboBox.SelectedItem.ToString();

            catalog_ComboBox.Items.Clear();
            catalog_ComboBox.Items.Add("");

            Data.DMS.CatalogManager.LoadData();

            foreach (var i in Data.DMS.CatalogManager.GetDataList())
            {
                bool add;
                bool hasValidGroup = ((from qi in DMS.CatalogGroupManager.CatalogGroup
                                       where qi == i.CatalogGroup
                                       select qi).FirstOrDefault()) != null;

                add = (!hasValidGroup && filter == group_ComboBox.Items[0].ToString());

                if (!add) add = (i.CatalogGroup != null && filter.Trim() == i.CatalogGroup.Trim());

                if (add) catalog_ComboBox.Items.Add(i.Name);

            }
        }

        // Events

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCatalog_Click(object sender, EventArgs e)
        {
            goto GetCatalog;

            GetCatalog:
            {
                if (AMS.MessageBox_v2.Show("Enter Catalog Name", AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
                {
                    string newCataName = AMS.MessageBox_v2.MessageValue;
                    var queryExisting = DMS.CatalogManager.GetData(i => i.Name == newCataName);

                    if (queryExisting != null)
                    {
                        AMS.MessageBox_v2.Show(newCataName + " already exist\r\nPlease use an unique name for the catalog");
                        goto GetCatalog;
                    }

                    var newCatalog = new Catalog() { Name = newCataName };
                    newCatalog.Save();
                }
            }

            LoadCatalogGroups();
        }

        private void AddGroup_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Enter new Group Name", AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
            {
                DMS.CatalogGroupManager.AddGroup(AMS.MessageBox_v2.MessageValue);
            }

            LoadCatalogGroups();
        }

        private void RemoveCatalog_Click(object sender, EventArgs e)
        {
            var cata = Data.DMS.CatalogManager.GetData(i => i.Name == catalog_ComboBox.Text);

            Data.DMS.CatalogManager.Delete("Are you sure you want to remove " + cata.Name + "?", cata);
            LoadCatalogGroups();
        }

        private void RenameCatalog_Click(object sender, EventArgs e)
        {
            var cata = Data.DMS.CatalogManager.GetData(i => i.Name == catalog_ComboBox.Text);

            if (cata != null && AMS.MessageBox_v2.Show("Please enter new name for '" + cata.Name + "'", AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
            {
                cata.Name = AMS.MessageBox_v2.MessageValue;
                cata.Save();
            }

            LoadCatalogGroups();
            catalogUC.LoadCatalog(null);
        }

        private void LoadCatalogs_Event(object sender, EventArgs e)
        {
            LoadCatalogGroups();
        }

        private void ScriptEditor_Event(object sender, EventArgs e)
        {
            while (exchangeFactorToolStripMenuItem.DropDownItems.Count > 0)
                exchangeFactorToolStripMenuItem.DropDownItems.RemoveAt(exchangeFactorToolStripMenuItem.DropDownItems.Count - 1);

            exchangeFactorToolStripMenuItem.DropDownItems.Add("Add Script");
            exchangeFactorToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

            foreach (var i in AMS_Script.ScriptManager.GetScriptList())
                exchangeFactorToolStripMenuItem.DropDownItems.Add(i.Name);

            int nr = 0;
            foreach (var i in exchangeFactorToolStripMenuItem.DropDownItems)
            {
                if (nr != 1) ((ToolStripMenuItem)i).Click += ScriptItem_Click;
                nr++;
            }
        }

        private void ScriptItem_Click(object sender, EventArgs e)
        {
            string text = ((ToolStripMenuItem)sender).Text;
            var script = AMS_Script.ScriptManager.GetScript(text);
            if (script == null || text == exchangeFactorToolStripMenuItem.DropDownItems[0].Text)
                script = new AMS_Script.Script.aScript();

            if (script != null)
            {
                catalogUC.LoadCatalog(null);
                AMS_Script.ScriptManager.EditScript(script);
                catalogUC.LoadData();
            }
        }

        private void SelectCatalog_Event(object sender, EventArgs e)
        {
            var cata = (from i in Data.DMS.CatalogManager.GetDataList()
                        where i.Name == catalog_ComboBox.Text
                        select i).FirstOrDefault();

            catalogUC.LoadCatalog(cata);
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            catalogUC.SaveCatalog();
            AMS.MessageBox_v2.Show("Catalog Saved.", 1000);
        }

        private void paste_Button_Click(object sender, EventArgs e)
        {
            catalogUC.PasteCatalog(0, false);
        }

        private void copy_Button_Click(object sender, EventArgs e)
        {
            catalogUC.CopyCatalog(true);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show("Enter item's price in the List Price field to calculate mark-up or other formulas.\r\n" +
                "Use either the default Retail Script or an individual item's Retail Script to calculate the Retail Price.\r\n\r\n" +
                "A Forex Script will be calculated from the item's Retail Price.\r\n" +
                "Note: Selecting a Forex will only preview the Retail Price changes.");
        }

        private void facktorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AMS_Script.ScriptManager.EditFactors();
        }

        private void group_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCatalogs();

            cboxReport.SelectedIndexChanged -= CboxReport_SelectedIndexChanged;
            cboxReport.SelectedIndex = 0;

            var group = group_ComboBox.SelectedItem?.ToString();
            if (group == null)
            {
                cboxReport.SelectedIndexChanged += CboxReport_SelectedIndexChanged;
                return;
            }

            if (DMS.CatalogGroupManager.GroupReport.ContainsKey(group))
            {
                var value = DMS.CatalogGroupManager.GroupReport[group];
                var name = ReportManager.ReportNameExtensions.GetName(value);
                cboxReport.SelectedIndex = (int)name;
            }

            cboxReport.SelectedIndexChanged += CboxReport_SelectedIndexChanged;
        }

        private void RenameGroup_Click(object sender, EventArgs e)
        {
            string group = group_ComboBox.Text;


            if (!string.IsNullOrEmpty(group) && AMS.MessageBox_v2.Show("Please enter new name for catalog group '" + group + "'", AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
            {
                DMS.CatalogGroupManager.RenameGroup(group, AMS.MessageBox_v2.MessageValue);
            }

            LoadCatalogGroups();
            catalogUC.LoadCatalog(null);
        }

        private void CboxReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var group = group_ComboBox.SelectedItem?.ToString();
                if (group == null) return;

                var name = ReportManager.ReportNameExtensions.GetName(cboxReport.SelectedItem.ToString());

                if (!Data.DMS.CatalogGroupManager.GroupReport.ContainsKey(group) || DMS.CatalogGroupManager.GroupReport[group] != name.ToString())
                {
                    DMS.CatalogGroupManager.GroupReport[group] = name.ToString();
                    DMS.CatalogGroupManager.SaveReportMapping();
                }
            }
            catch (Exception ex)
            {
                MessageBox_v2.Show(ex.ToString());
            }

        }
    }
}
