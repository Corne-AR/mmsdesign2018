using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    [Serializable]
    public class ReceiptAllocation
    {
        public string TransactionID { get; set; }
        public string ReceiptID { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrencyAdjustment { get; set; }

        public Receipt Receipt
        {
            get
            {
                if (string.IsNullOrEmpty(ReceiptID)) return null;
                var receipt = DMS.AccountsManager.ReceiptList.Where(i => i.ID == ReceiptID).FirstOrDefault();
                return receipt;
            }
        }

        public Transactions.Transaction Transaction
        {
            get
            {
                if (string.IsNullOrEmpty(TransactionID)) return null;
                var trans = DMS.TransactionManager.GetData(i => i.ID == TransactionID);
                return trans;
            }
        }

        #region HashSet Identifier

        private string IdentifierString { get { return TransactionID + ReceiptID; } }


        public override bool Equals(object obj)
        {
            var other = obj as ReceiptAllocation;
            if (other == null)
            {
                return false;
            }
            if (IdentifierString == null) return false;
            return IdentifierString == other.IdentifierString;
        }

        public override int GetHashCode()
        {
            return (IdentifierString).GetHashCode();
        }

        #endregion
    }
}
