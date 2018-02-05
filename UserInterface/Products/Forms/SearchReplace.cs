using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Products.Forms
{
    public partial class SearchReplace : Form
    {

        public SearchReplace()
        {
            InitializeComponent();

            var list = Data.DMS.ProductManager.DataList
                .Select(i => i.CatalogName)
                .Distinct()
                .ToList();

            NameComboBox.Items.AddRange(list.ToArray());
            NameComboBox.TextChanged += (s, e) =>
            {
                var count = Data.DMS.ProductManager.DataList.Where(i => i.CatalogName == NameComboBox.Text).Count();
                infoLabel.Text = count.ToString();
                progressBar.Maximum = count;
                progressBar.Value = 0;
            };
            WriteToDiskCheckBox.Checked = false;

            btnReplace.Click += Replace_Click;
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewNameTextBox.Text))
            {
                AMS.MessageBox_v2.Show("Please enter a new name.", AMS.MessageType.Error);
                return;
            }

            var name = NameComboBox.Text;
            var newName = NewNameTextBox.Text;
            var count = Data.DMS.ProductManager.DataList.Where(i => i.CatalogName == name).Count();
            progressBar.Value = 0;

            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                AMS.Data.GobalManager.SuspendEvents();
                AMS.Data.GobalManager.SuspendControls();

                foreach (var p in Data.DMS.ProductManager.DataList.Where(i => i.CatalogName == name))
                {
                    this.Invoke(new Action(() =>
                    {
                        progressBar.Value++;
                        infoLabel.Text = $"{progressBar.Value}/{progressBar.Maximum}";
                    }));
                    p.CatalogName = newName;
                    if (WriteToDiskCheckBox.Checked)
                        p.Save($"Updating Catalog Name. Old '{name}' - New '{newName}'", true, true);
                    else
                        System.Threading.Thread.Sleep(1);
                }
            }).ContinueWith((x) =>
            {
                this.Invoke(new Action(() =>
                {
                    infoLabel.Text = $"Done.\r\nUpdated {count} Products.";

                    AMS.Data.GobalManager.ResumeControls();
                    AMS.Data.GobalManager.ResumeEvents();
                }));
            });
        }
    }
}