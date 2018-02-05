using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Reports
{
    [Serializable]
    public class ReportData
    {
        public Data.IO.aFile File { get; set; }
        public string Data { get; set; }

        public ReportData()
        {
            File = new Data.IO.aFile();
        }

        #region HashSet Identifier

        public override bool Equals(object obj)
        {
            var other = obj as ReportData;
            if (other == null)
            {
                return false;
            }
            if (Data == null) return false;
            return Data == other.Data;
        }

        public override int GetHashCode()
        {
            return (Data).GetHashCode();
        }

        #endregion
    }
}
