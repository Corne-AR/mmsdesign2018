using Data.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Calculations
{
    public class QuoteCalculator
    {
        private Quotes.Quote quote;

        private List<Catalogs.Catalog> catalogList;
        public List<Catalogs.Catalog> CatalogList { get { return catalogList; } }

        private List<Catalogs.Catalog> catalogExpandList;
        private List<Catalogs.Catalog> catalogProcessedList;

        private decimal totalValue;
        public decimal TotalValue { get { return totalValue; } }

        private decimal totalCODValue;
        public decimal TotalCODValue { get { return totalCODValue; } }

        private decimal totalMaintenanceValue;
        public decimal TotalMaintenanceValue { get { return totalMaintenanceValue; } }

        private decimal totalCODMaintenanceValue;
        public decimal TotalCODMaintenanceValue { get { return totalCODMaintenanceValue; } }

        public decimal VatRateFaktor { get; private set; }

        // Constructors

        public QuoteCalculator(Quotes.Quote quote)
        {
            this.quote = quote;
            if (this.quote == null) this.quote = new Quotes.Quote();
            catalogList = this.quote.QuoteCatalogList;

            Calculate();
        }

        // Methods

        private void Calculate()
        {
            // Do checks
            if (catalogExpandList == null) catalogExpandList = new List<Catalog>();
            if (catalogProcessedList == null) catalogProcessedList = new List<Catalog>();

            totalValue = 0;
            totalCODValue = 0;
            totalMaintenanceValue = 0;
            totalCODMaintenanceValue = 0;

            #region Go through each catalog and separate the child (count) catalogs from the parents

            foreach (var catalogParent in catalogList)
            {
                int count = catalogParent.Count;
                if (count < 1) count = 1;
                while (count > 0)
                {
                    count--;

                    var newCatalog = (Catalog)catalogParent.Clone();
                    newCatalog.ID = AMS.Data.Keys.UniqueKey.NewShortCode();
                    newCatalog.ParentID = catalogParent.ID;

                    var hasSelected = newCatalog.ItemList.Where(i => i.Selected).FirstOrDefault() != null;
                    if (hasSelected) catalogExpandList.Add(newCatalog);
                }
            }

            #endregion

            // The Catalog Expand List contains all catalogs, inc children
            // Make in memory a history list, to check against for rules to apply on bulk
            // Go through each product item. and check the rules before applying the final value

            // TODO: Sort by price to calculate most expensive 1st.

            catalogList = new List<Catalog>(); // Clear the original catalog list, to use as an output with new calculated items

            foreach (var catalog in catalogExpandList)
            {
                catalogProcessedList.Add(catalog);
                catalogList.Add(CalculateCatalog(catalog)); // Add the new calculated catalog to output list
            }

            #region Add maintenance

            if (totalCODMaintenanceValue < DMS.MinMaintenanceValue / DMS.VatRateValue)
            {
                var client = DMS.ClientManager.GetData(i => i.Account == quote.Client.Account);

                decimal clientMaint = quote.Client.GetMMSMaintenanceValue(1);

                if (totalCODMaintenanceValue + clientMaint < DMS.MinMaintenanceValue / DMS.VatRateValue)
                {
                    totalCODMaintenanceValue = DMS.MinMaintenanceValue / DMS.VatRateValue;
                }
            }

            #endregion

            // 6 Add VAT
            string defaultCurrency = AMS.Suite.SuiteManager.Profile.ForexList[0].ToString();
            bool international = (!quote.Client.IsInternational && quote.Currency != defaultCurrency);

            if (international)
            {
                //foreach (var cat in catalogList)
                //    foreach (var i in cat.ItemList)
                //        i.ListPrice *= 1.14m;
            }

            // 7 Add to Cost, typical for Courier
            if (quote.AddtoCost != 0)
            {
                decimal amountToAdd = (decimal)quote.AddtoCost / totalValue;

                if (amountToAdd != 0)
                    foreach (var cat in catalogList)
                        foreach (var i in cat.ItemList) i.ListPrice = i.ListPrice * amountToAdd + i.ListPrice;

                totalValue = totalValue * amountToAdd + totalValue;
                totalCODValue = totalCODValue * amountToAdd + totalCODValue;
            }
        }

        // Catalog Calculations

        private Catalog CalculateCatalog(Catalog catalog)
        {
            Catalog newCatalog = (Catalog)catalog.Clone();
            newCatalog.ItemList = new List<CatalogItem>();

            catalog.TotalValue = 0;
            catalog.CODValue = 0;
            decimal discount = quote.Discount + catalog.Discount;

            foreach (var item in catalog.ItemList)
            {
                #region Rules of MMS Design Pricelist

                // 1a. Remove VAT if needed (Best to do all calculation excluding VAT)
                // 1b. International or not, currency
                // 2. Specials before Bulk-discount
                // 3.1 Bulk
                // 3.2 Maintenance (note: calculated with Bulk-discount .. ex: 100% *8/100.....60% *8/100)
                // 4. During SPECIALS: stolen & maintenance = normal price
                // 5. Stolen has no maintenance
                // 5.1. Stolen with maintenance = 20% discount + Normal COD Discount
                // 5.2 Stolen without = 10% discount + Normal COD Discount
                // 5. COD or 30 Days

                #endregion

                var newItem = (CatalogItem)item.Clone();
                newItem.ListPrice = 0m;

                // Each item will represent a module
                if (item.Selected && item.RetailPrice != 0)
                {
                    decimal itemValue = 0;
                    newItem.CalculationInfo += $"{item.RetailPrice:00} : Initial Value\n";

                    // 1a. Remove VAT if needed (Best to do all calculation excluding VAT)
                    if (catalog.PriceIncludeVAT)
                    {
                        //VatRateFaktor = 1 - DMS.VatRateValue + 1; //Koos was ook hier vir lyn hier onder
                        //itemValue = item.RetailPrice * VatRateFaktor; //Koos was hier Julie 2019 was eers: itemValue = item.RetailPrice / DMS.VatRateValue
                        itemValue = item.RetailPrice / DMS.VatRateValue;
                        newItem.CalculationInfo += $"{itemValue:#.00} : Removed VAT\n";
                    }
                    else itemValue = item.RetailPrice;

                    // 3.1 Does not have Bulk.. basically do nothing about it
                    if (catalog.Discount <= 0 && item.BulkDiscount)
                    {
                        var bdisc = BulkDiscount(catalog.Name, item, itemValue);
                        if (itemValue != bdisc)
                        {
                            itemValue = bdisc;
                            newItem.CalculationInfo += $"{itemValue:#.00} : Bulk Discount\n";
                        }
                        // if (hasBulkdiscount) catalog.HasBulkdiscount = true;  // This will show Invoice has bulkdiscount
                    }
                    // 3.2 Maintenance
                    if (item.Maintenance)
                    {
                        CalculateMaintenance(catalog, item, itemValue);
                        newItem.CalculationInfo += $"Maintenace Calulated\n";
                    }
                    // 4. During SPECIALS: stolen = normal price
                    if (discount > 0 && !catalog.UseStolen && item.GlobalDiscount)
                    {
                        itemValue = (100 - discount) / 100 * itemValue;
                        newItem.CalculationInfo += $"{itemValue:#.00} : During SPECIALS: stolen = normal price\n";
                    }
                    // 5.1. Stolen with maintenance = 20% discount + Normal COD Discount
                    if (catalog.UseStolen && quote.Client.HasSupport)
                    {
                        itemValue = itemValue * 0.8m;
                        newItem.CalculationInfo += $"{itemValue:#.00} :  Stolen with maintenance = 20% discount + Normal COD Discount\n";
                    }

                    // 5.2 Stolen without = 10% discount + Normal COD Discount
                    if (catalog.UseStolen && !quote.Client.HasSupport)
                    {
                        itemValue = itemValue * 0.9m;
                        newItem.CalculationInfo += $"{itemValue:#.00} :  Stolen without = 10% discount + Normal COD Discount\n";
                    }

                    // Finally add Quote's value up
                    if (item.COD)
                    {
                        catalog.CODValue += itemValue * DMS.CODFactor;
                        totalCODValue += itemValue * DMS.CODFactor;
                        newItem.CalculationInfo += $"{itemValue * DMS.CODFactor:#.00} : Added to COD Total at {DMS.CODFactor} Rate\n";
                    }
                    else
                    {
                        catalog.CODValue += itemValue;
                        totalCODValue += itemValue;
                        newItem.CalculationInfo += $"{itemValue:#.00} : Added to COD Total with no Rate adjustment\n";
                    }

                    totalValue += itemValue;
                    catalog.TotalValue += itemValue;

                    //Apply international, and Namibia
                    if (quote.Client.IsInternational)
                    {
                        totalValue = totalCODValue; //Julie Specil comment hierdie dalk uit as waardes nie optel nie
                        catalog.TotalValue = totalCODValue; //Julie Specil comment hierdie dalk uit as waardes nie optel nie
                        //    totalMaintenanceValue = 0;

                        //    if (quote.Currency != "ZAR")
                        //    {
                        //        totalCODValue = TotalCODValue * 1.14m;
                        //        totalCODMaintenanceValue = TotalCODMaintenanceValue * 1.14m;
                        //    }



                        if (quote.Currency != "ZAR")
                        {
                            totalCODValue = TotalCODValue;
                            totalCODMaintenanceValue = TotalCODMaintenanceValue;
                            totalValue = totalCODValue;
                            totalMaintenanceValue = totalCODMaintenanceValue;
                        }
                        else
                        {
                            totalCODValue = TotalCODValue;
                            totalCODMaintenanceValue = TotalCODMaintenanceValue;
                            totalValue = totalCODValue;
                            totalMaintenanceValue = totalCODMaintenanceValue;
                        }
                    }

                    // Finally add back to newCatalog after all calculations
                    newItem.CatalogDefaultScript = "";
                    newItem.Forex = new Forex();
                    newItem.RetailScript = "";
                    newItem.ListPrice = itemValue;
                    newItem.CalculationInfo += $"{itemValue:#.00} : Final Value\n";

                    if (quote.PaymentTerms == "COD" && item.COD) newItem.ListPrice = itemValue * DMS.CODFactor;
                }
                newCatalog.ItemList.Add(newItem);
            }

            newCatalog.CODValue = catalog.CODValue;

        //Julie 2019 Koos was hier. haal al die lyne onder hierdie een uit met comments tot by //\\tot hier//\\
            //if (quote.Client.IsInternational)
            //{
            //    //Client is International - therfore COD amount apply and TotalValue must be set to equal CODValue
            //    newCatalog.TotalValue = catalog.CODValue;
            //}
            //else
            //{
               newCatalog.TotalValue = catalog.TotalValue;  //comment alles uit behalwe hierdie lyn, hy is nodig koos
            //}
         //\\tot hier//\\
            
            newCatalog.MaintenanceValue = catalog.MaintenanceValue;

            return newCatalog;
        }

        private decimal BulkDiscount(string CatalogName, CatalogItem item, decimal value)
        {
            // 1. Check if part of of history List
            var queryHistoryList = (from i in catalogProcessedList
                                    where i.Name == CatalogName
                                    select i).ToList();

            int count = 0;

            foreach (var catalog in queryHistoryList)
            {
                foreach (var i in catalog.ItemList)
                {
                    if (i.Selected && i.Name == item.Name) count++;
                }
            }

            if (count == 1) return value;
            if (count == 2) value = value * 0.8m;
            if (count == 3) value = value * 0.7m;
            if (count >= 4) value = value * 0.6m;
            // hasBulkdiscount = (count > 1);

            return value;
        }

        private void CalculateMaintenance(Catalog Catalog, CatalogItem item, decimal itemValue)
        {
            // 5. Stolen has no maintenance
            if (Catalog.UseStolen) return;

            totalMaintenanceValue += itemValue * DMS.MaintenanceFactor;
            if (item.COD) totalCODMaintenanceValue += (itemValue * DMS.MaintenanceFactor) * DMS.CODFactor;
            else totalCODMaintenanceValue += totalMaintenanceValue;
        }
    }
}