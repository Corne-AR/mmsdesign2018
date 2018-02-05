using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Catalogs
{
    /// <summary>
    /// Stores Exchange Rates and Type
    /// </summary>
    public class ExchangeFactor : AMS.Data.DataClass
    {
        public decimal USD { get; set; }
        public decimal EURO { get; set; }
        public decimal GBP { get; set; }
        public ExchangeFactorTypes Type { get; set; }
    }

    /// <summary>
    /// Exchange Factor Types
    /// </summary>
    public enum ExchangeFactorTypes
    {
        ModelMakerSystems,
        GPS
    }
}
