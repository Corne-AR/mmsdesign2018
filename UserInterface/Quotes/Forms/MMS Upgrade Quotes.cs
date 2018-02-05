using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.People.Forms
{
    public partial class MMS_Upgrade_Quotes : Form
    {
        public MMS_Upgrade_Quotes()
        {
            InitializeComponent();

            this.Load += (s, e) => pasteTB.Text = Clipboard.GetText(TextDataFormat.Text);
            submitBT.Click += SubmitBT_Click;
        }

        private void SubmitBT_Click(object sender, EventArgs e)
        {
            try
            {
                var items = new List<Data.Catalogs.CatalogItem>();

                // Get Clipboard data

                var value = pasteTB.Text;
                var lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                int linenr = 0;

                foreach (var l in lines)
                {
                    linenr++;

                    if (!string.IsNullOrEmpty(l.Trim()))
                    {
                        var item = new Data.Catalogs.CatalogItem();

                        var newl = l.Replace("US$", "Æ").Trim();

                        // Back
                        int nrR = 0;

                        foreach (var c in newl.Reverse())
                        {
                            nrR++;
                            if (c == 'R' || c == 'Æ')
                            {
                                nrR = newl.Length - nrR;
                                break;
                            }
                        }

                        // Front
                        var front = newl.Split(new string[] { ". " }, StringSplitOptions.None)?[0];

                        try { item.ListPrice = Convert.ToDecimal(newl.Substring(nrR + 1)); }
                        catch { throw new Exception($"Koos het vergeet om die laaste prys te copy!\r\n\r\n{newl}\r\nLine Number: {linenr}"); }

                        try { item.Name = newl.Substring(front.Length + 2, nrR - 3); }
                        catch { throw new Exception($"Onthou die bullet nr.... Koos!!\r\n\r\n{newl}\r\nLine Number: {linenr}"); }

                        item.Selected = true;

                        items.Add(item);
                    }
                }

                // Crate Quote and Form

                var q = new Data.Quotes.Quote();
                q.Currency = value.Contains("US$") ? "USD" : "ZAR";
                q.SetNewClient(Data.DMS.ClientManager.CurrentData);

                var cat = (Data.Catalogs.Catalog)Data.DMS.CatalogManager.GetData(i => i.Name == "MM No Products").Clone();
                cat.ItemList.AddRange(items);
                cat.PriceIncludeVAT = !value.Contains("US$");// Data.DMS.ClientManager.CurrentData.IsInternational;

                q.AddToCatalog(cat);

                this.Hide();

                var qform = new Quotes.Forms.QuoteForm(q);
                qform.ShowDialog();

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
