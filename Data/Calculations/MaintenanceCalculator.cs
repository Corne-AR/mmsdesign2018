using Data.Catalogs;
using Data.People;
using Data.Quotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Calculations
{
    public class MaintenanceCalculator
    {
        private Quote quote;
        public bool ShowMessages;
        public bool AddCurrentMaintenance;
        public decimal CurrentMaintValue;

        private int extendMonths;
        public int ExtendMonths { get { return extendMonths; } }

        private DateTime extendedDate;
        private int quoteMonths;
        public DateTime ExtendedDate { get { if (extendedDate < DateTime.Now) extendedDate = DateTime.Now; return extendedDate; } }

        // Constructors

        public MaintenanceCalculator()
        {
            ShowMessages = true;
            AddCurrentMaintenance = false;
            CurrentMaintValue = 0m;
        }

        // Methods

        public void CalculationMaintenance(Quote Quote)
        {
            quote = Quote;
            if (quote == null || quote.Account == null) return;

            // Set Defaults
            extendedDate = quote.ExtendDate;
            quoteMonths = quote.ExtendDate.Month - quote.QuoteDate.Month + (quote.ExtendDate.Year - quote.QuoteDate.Year) * 12;

            // Finally do calculations for new Maintenance date
            var maintType = quote.Client.GetMaintenanceType();
            if (maintType == MaintenanceType.New) NewMaintenance();
            if (maintType == MaintenanceType.Current) CurrentMaintenance();
            if (maintType == MaintenanceType.Expiring) ExpiringMaintenance();
            if (maintType == MaintenanceType.Expired) ExpiredMaintenance();
        }
        
        private void NewMaintenance()
        {
            extendMonths = 0;
            extendMonths = quoteMonths;

            if (DateTime.Now.Day <= 15)
            {
                extendMonths -= 1;
            }
            else
            {
                extendMonths -= 2;
            }
        }

        private void CurrentMaintenance()
        {
            extendMonths = quoteMonths;

            if (DateTime.Now.Day < 16) extendMonths -= 1;
            else extendMonths -= 2;
        }

        private void ExpiringMaintenance()
        {
            extendMonths = quoteMonths;

            // quoteMonths == 1 || quoteMonths == 0 || quoteMonths == -1 || quoteMonths == -2
            if (quoteMonths == 13) extendMonths = 11;
            if (quoteMonths == 12) extendMonths = 10;
            if (quoteMonths == 11) extendMonths = 9;
            if (quoteMonths == 10) extendMonths = 8;
            if (DateTime.Now.Day < 16) extendMonths++;

            // extendedDate = extendedDate.AddMonths(extendMonths);

            if (ShowMessages && AMS.MessageBox_v2.Show("Add clients current outstanding maintenance to this quote?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                //// Get a list of products from Account with same Expiry Date
                //var productList = Data.DMS.ProductManager.GetDataList(i => i.Account == quote.Account &&
                //    new DateTime(i.ExpiryDate.Year, i.ExpiryDate.Month, 1) == new DateTime(quote.Client.Expirydate.Year, quote.Client.Expirydate.Month, 1));

                //// Get all of the client products' values
                //decimal productListValue = 0;
                //foreach (var product in productList)
                //    productListValue += product.PriceExVat;

                //// Apply rules
                //decimal maintValue = productListValue * Data.DMS.MaintenanceFactor;

                //if (maintValue > 25000) maintValue = maintValue * 0.7m;
                //else if (maintValue > 20000) maintValue = maintValue * 0.75m;
                //else if (maintValue > 15000) maintValue = maintValue * 0.8m;
                //else if (maintValue > 10000) maintValue = maintValue * 0.85m;
                //else if (maintValue > 5000) maintValue = maintValue * 0.9m;

                //CurrentMaintValue = maintValue;

                CurrentMaintValue = this.quote.Client.GetMMSMaintenanceValue(1);
                AddCurrentMaintenance = true;
            }

            ShowMessages = false;

            // Exiting Method
            return;
        }

        private void ExpiredMaintenance()
        {
        }
    }
}