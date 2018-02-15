using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using Data;
using Data.Communications;
using Reporting;

public static class ReportManager
{
    public static void StartUp()
    {
        // Anything to start?
    }

    // Reports

    public static bool QuoteReport(string ID)
    {
        ReportName reportname;
        Data.Catalogs.Catalog cat;
        string refname = ReportName.Unspecified.ToString(); // Each Catalog Group should have a refernced Report Name

        try
        {
            var quote = DMS.QuoteManager.GetData(x => x.ID == ID);
            quote.PaymentTerms = "30Day";
            cat = quote.QuoteCatalogList[0];

            try
            {
                var current = DMS.CatalogManager.GetData(x => x.Name == cat.Name);
                cat = current ?? cat;
                if (cat?.Name == null) throw new Exception("There is something wrong with the quoted catalog.");

                try { refname = DMS.CatalogGroupManager.GroupReport[cat.CatalogGroup]; }
                catch { throw new Exception($"Could not determine which Report Template to use for {cat.CatalogGroup}. Please double check in the Catalog Manager"); }
                if (string.IsNullOrEmpty(refname)) throw new Exception($"Unable to find group for {cat.CatalogGroup}");

                reportname = (ReportName)Enum.Parse(typeof(ReportName), refname);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var subject = $"{AMS.Suite.SuiteManager.Profile.CompanyName} {reportname.ToString().ToSpaceAfterCapital()} {ID}";
            var mail = DMS.MailManager.NewMail(quote.Account, quote.Contact, quote.Email, subject, TemplateTypes.Quote);
            var mailed = MailReport(quote, reportname, mail);
            if (mailed)
            {
                quote.Metadata.EmailDate = DateTime.Now;
                quote.Save("Quote " + quote.ID + " Emailed to " + quote.Contact + " - " + quote.Email, true, true, quote.ProgressType);
            }

            return mailed;

        }
        catch (Exception ex)
        {
            AMS.MessageBox_v2.Show(ex.ToString());
            return false;
        }
    }

    public static bool StatementReport(string Account)
    {
        try
        {
            var client = DMS.ClientManager.GetData(i => i.Account == Account);
            var statement = new Data.Reports.Statement(client);

            var mail = DMS.MailManager.NewMail(Account, client.Name, client.Email, $"{client.Name} Statement", TemplateTypes.Statement);
            var mailed = MailReport(statement, ReportName.Statement, mail); // SendMail(StatementViewer.ReportViewer, StatementViewer.Mail, ReportMail);

            if (mailed)
            {
                client.Metadata.EmailDate = DateTime.Now;
                client.Save("Statement Emailed.", true, true);
            }

            return mailed;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }

    public static bool MaintenanceQuoteReport(Data.People.Client Client)
    {
        try
        {
            Data.Quotes.Quote quote = new Data.Quotes.Quote();
            Data.Catalogs.Catalog catalog = new Data.Catalogs.Catalog();
            var cataItem = new Data.Catalogs.CatalogItem();
            var cataDiscountItem = new Data.Catalogs.CatalogItem();

            var productList = DMS.ProductManager.GetDataList(
                i => i.Account == Client.Account &&
                i.ExpiryDate.AddMonths(2) >= Client.Expirydate &&
                (i.CatalogName == "Model Maker" ||
                 i.CatalogName == "Pipe Maker" ||
                 i.CatalogName == "Road Maker" ||
                 i.CatalogName == "Survey Maker")).ToList();

            productList = productList

                .OrderBy(i => i.Name).ToList()
                .OrderBy(i => i.CatalogName).ToList();

            foreach (var i in productList)
                cataItem.Content += i.CatalogName + " " + i.Name + "\r\n";

            cataItem.Name = string.Format("One Year MMS Software Subscription Renewal {0:MMM yyyy} - {1:MMM yyyy}", Client.Expirydate.AddMonths(1), Client.Expirydate.AddYears(1));
            cataItem.ListPrice = Client.GetMMSMaintenanceValue(1);
            cataItem.Selected = true;

            cataDiscountItem.Name = "Bulk Discount";
            // cataDiscountItem.ListPrice = -Client.BulkDiscount;
            cataDiscountItem.Selected = cataDiscountItem.ListPrice != 0;

            catalog.ItemList.Add(cataItem);
            catalog.ItemList.Add(cataDiscountItem);
            catalog.Itemized = true;
            catalog.CODOnly = true;
            catalog.PriceIncludeVAT = true;

            quote.SetNewClient(Client);
            quote.AddToCatalog(catalog);
            quote.Save("Generated Maintenance Renewal Quote", true, true, Data.Quotes.ProgressType.New);

            return QuoteReport(quote.ID);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }

    public static bool PackageReport(Data.Quotes.Quote quote)
    {
        try
        {
            var mail = DMS.MailManager.NewMail(quote.Account, quote.Contact, quote.Email, $"{quote.ID} Packing List", TemplateTypes.General);
            var mailed = MailReport(quote, ReportName.PackingList, mail);

            if (mailed)
            {
                quote.Metadata.EmailDate = DateTime.Now;
                quote.Save("Packing List " + quote.ID + " Emailed to " + quote.Contact + " - " + quote.Email, true, true, quote.ProgressType);
            }

            return mailed;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }

    public static bool TransactionReport(Data.Transactions.Transaction trans)
    {
        try
        {
            TemplateTypes ttype;
            ReportName rname;

            switch (trans.Type)
            {
                case Data.Transactions.TransactionType.CreditNote:
                case Data.Transactions.TransactionType.Invoice:
                case Data.Transactions.TransactionType.Proforma:
                case Data.Transactions.TransactionType.CancellationOrder:
                    ttype = TemplateTypes.Invoice;
                    rname = ReportName.Invoices;
                    break;

                case Data.Transactions.TransactionType.PurchaseOrder:
                    ttype = TemplateTypes.PurchaseOrder;
                    rname = ReportName.Purchases;
                    break;

                default: throw new Exception($"TODO: Unsure which Templates to use with {trans.Type}");
            }

            var subject = $"{trans.Type} {trans.ID}";
            var mail = DMS.MailManager.NewMail(trans.Account, trans.Contact, trans.Email, subject, ttype);
            var mailed = MailReport(trans, rname, mail);

            if (mailed)
            {
                trans.Metadata.EmailDate = DateTime.Now;
                trans.Save($"{trans.Type} {trans.ID} Emailed to {trans.Contact} - {trans.Email}", true, true);
            }

            return mailed;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }

    #region Generic

    /// <summary>
    /// Reports where no data binding is required.
    /// </summary>
    /// <param name="Name">The name.</param>
    public static void Preview(ReportName Name) => Reporting.Views.ReportWindow.ShowReport(Name, null);

    public static void Preview<T>(ReportName Name, T DataSource) => Reporting.Views.ReportWindow.ShowReport(Name, DataSource, null);

    public static void Preview<T>(ReportName Name, AMS.Data.DataManager<T> Manager, Func<T, bool> Predicate = null)
        where T : AMS.Data.DataClass
    {
        if (Predicate != null) Reporting.Views.ReportWindow.ShowReport(Name, Manager.GetDataList(Predicate), null);
        else Reporting.Views.ReportWindow.ShowReport(Name, Manager.GetDataList(), null);
    }
    public static bool MailReport(object DataSource, ReportName ReportName, Data.Communications.Mail Mail)
    {
        try
        {
            return Reporting.Views.ReportWindow.ShowReport(
                  ReportName,
                  DataSource,
                  Mail);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }

    #endregion

    //private static ReportName GetReportName(this TransactionType Type)
    //{
    //    switch (Type)
    //    {
    //        case TransactionType.PurchaseOrder:
    //        case TransactionType.CancellationOrder:
    //            return ReportName.Purchases;

    //        case TransactionType.CreditNote:
    //        case TransactionType.Invoice:
    //        case TransactionType.Proforma:
    //            return ReportName.Invoices;

    //        case TransactionType.Statement:
    //            return ReportName.Statement;

    //        case TransactionType.Quote:
    //            return ReportName.Quote;
    //    }

    //    throw new NotImplementedException();

    //}

    //private static TemplateTypes GetTemplateType(this TransactionType Type)
    //{
    //    switch (Type)
    //    {
    //        case TransactionType.CancellationOrder: return TemplateTypes.PurchaseOrder;
    //        case TransactionType.CreditNote: return TemplateTypes.CreditNote;
    //        case TransactionType.Invoice: return TemplateTypes.Invoice;
    //        case TransactionType.Proforma: return TemplateTypes.Proforma;
    //        case TransactionType.PurchaseOrder: return TemplateTypes.PurchaseOrder;
    //        case TransactionType.Quote: return TemplateTypes.Quote;
    //        case TransactionType.Statement: return TemplateTypes.Statement;
    //    }

    //    throw new NotImplementedException();
    //}

    /// <summary>
    /// Not 100% sure why this is needed. Saw it in an example or forum topic
    /// </summary>
    /// <param name="Report">The report.</param>
    /// <returns></returns>
    public static XtraReport CloneReport(this XtraReport Report)
    {
        using (var stream = new System.IO.MemoryStream())
        {
            Report.SaveLayoutToXml(stream);
            stream.Position = 0;
            return XtraReport.FromStream(stream, true);
        }
    }
}
