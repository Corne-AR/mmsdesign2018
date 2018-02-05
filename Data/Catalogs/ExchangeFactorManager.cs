using AMS.Data.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Catalogs
{
    /// <summary>
    /// Manages the Exchange Rate and Type Data
    /// </summary>
    public static class ExchangeFactorManager
    {
        private static aFile FileName = new aFile("Exchange Factors", AMS.Settings.Program.Directories.Commerce, AMS.Data.DataType.Xml);

        /// <summary>
        /// Gets Exchange Factors
        /// </summary>
        /// <returns>List of ExchangeFactors to use in a DataGridView</returns>
        public static List<ExchangeFactor> GetExchangeFactors()
        {
            List<ExchangeFactor> exchangeFactors = new List<ExchangeFactor>();
            exchangeFactors = (List<ExchangeFactor>)AMS.IO.XML_v1.Reader<List<ExchangeFactor>>(FileName.FullName);

            if (exchangeFactors == null)
            {
                exchangeFactors = new List<ExchangeFactor>();

                foreach (var i in Enum.GetValues(typeof(ExchangeFactorTypes)))
                {
                    exchangeFactors.Add(new ExchangeFactor() { Type = (ExchangeFactorTypes)i });
                }
            }

            return exchangeFactors;
        }

        public static void Save(List<ExchangeFactor> exchangeFactors)
        {
            AMS.IO.XML_v1.Writter<List<ExchangeFactor>>(exchangeFactors, FileName, "", true);
        }
    }
}
