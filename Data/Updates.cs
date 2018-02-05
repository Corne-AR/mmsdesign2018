using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Updates
    {
        public static void CheckforUpdates()
        {
            // Can add dates to dataclass for version control
            // If a file's updateDate is older than required, run this update below

            AMS.Data.GobalManager.SuspendEvents();

            // Update28May2014_1600PM();
            // Update10Jun2015();

            AMS.Data.GobalManager.ResumeEvents();
        }

        [ConditionalAttribute("DEBUG")]
        private static void Update28May2014_1600PM()
        {
            // do check if data was applied or not
            int nr = 0;
            int count = DMS.QuoteManager.GetDataList().Count;

            AMS.MessageBox_v2.ShowProcess("Doing updates", nr, count);

            foreach (var quote in DMS.QuoteManager.GetDataList())
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Doing updates to " + quote.ID, nr, count);
                //quote.ProgressType = Quotes.ProgressType.New;

                //if (quote.IsMailed)
                //    quote.ProgressType = Quotes.ProgressType.Mailed;

                //if (quote.Finalized == true)
                //    quote.ProgressType = Quotes.ProgressType.Finalized;

                //quote.Save("", true, false);
            }

            AMS.MessageBox_v2.EndProcess();
        }

        private static void Update10Jun2015()
        {
            var receipts = DMS.AccountsManager.GetReceiptData();

            var sb = new StringBuilder();

            foreach (var recipt in receipts)
            {
                // Check for wrong links

                var problemcheck = recipt.ReceiptAllocationList.Where(x => x.ReceiptID != null && x.ReceiptID != recipt.ID).FirstOrDefault();
                if (problemcheck != null)
                    throw new Exception("PROBLEM!!!!");

                // Check for missing allocations

                var fixList = recipt.ReceiptAllocationList.Where(x => x.ReceiptID == null).ToList();

                if (fixList != null)
                {
                    foreach (var allocation in fixList)
                    {
                        allocation.ReceiptID = recipt.ID;
                        sb.AppendFormat("Receipt {0} - Invoice {1}", recipt.ID, allocation.TransactionID);
                        sb.AppendLine();
                    }
                }
            }

            if (AMS.MessageBox_v2.Show("The following receipt allocations had problems\r\n" + sb.ToString(), AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                DMS.AccountsManager.SaveReceipts();
            else
                DMS.AccountsManager.GetReceiptData();
        }
    }
}
