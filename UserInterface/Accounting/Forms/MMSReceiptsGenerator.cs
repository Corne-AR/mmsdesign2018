using Data.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Accounting.Forms
{
    public partial class MMSReceiptsGenerator : Form, IDisposable
    {
        private decimal amount;
        private DateTime date;
        private string nr;

        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        IntPtr nextClipboardViewer;

        public MMSReceiptsGenerator()
        {
            InitializeComponent();
            this.Load += (s, e) => txtInput.Text = Clipboard.GetText(TextDataFormat.Text);
            btnCreate.Click += BtnCreate_Click;
            txtInput.TextChanged += TxtInput_TextChanged;

            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)
                        this.Handle);

            this.FormClosed += (s, e) => ChangeClipboardChain(this.Handle, nextClipboardViewer);
        }

        private void AddReceipt()
        {
            var receipt = new Receipt();

            //receipt.Account = "AS001";
            receipt.Description = $"MMS {nr}";
            receipt.Amount = amount;
            receipt.ReceiptDate = date;

            Data.DMS.AccountsManager.AddReceipt(receipt);
        }

        private void TxtInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var input = txtInput.Text.Split('\n');
                nr = input[8].Split(':')[1].Trim();
                amount = Convert.ToDecimal(input[input.Count() - 2]);
                date = Convert.ToDateTime(input[7].Split(':')[1].Trim());
                txtOutput.Text = $"{date}, MMS {nr}, {amount}";

                AddReceipt();
            }
            catch { }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            AddReceipt();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    txtInput.Text = Clipboard.GetText(TextDataFormat.Text);
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                    m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void MMSReceiptsGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            AMS.MessageBox_v2.Show("Remember to assign receipt nr's to the receipts by clicking on the 'Receipt' button. This will also save the receipts permanently. 'Reload/Cancel' to restart if there are errors. Press 'Process' button to continue.", AMS.MessageType.Normal);
        }
    }
}
/*
MODEL MAKER SYSTEMS CC.
P.O.Box 8047
CENTURION
0046 Tel. (012) 665-0121
Fax. (012) 665-0129
TAX INVOICE
VAT Reg. no. 4350102887
DATE : 17/08/2016
Invoice no. : 29534
To: MMS DESIGN
P.O Box 3311
DURBANVILLE
Tel.(086) 111-2783
VAT no. 4600198727
Account no. : 50
Order no. :POC3958
Qty/Hoev Description / Beskrywing Secr.key Cost
1
1
Model Maker DTM software - Modules 1,2,6 (9000)
Model Maker Systems support subscription - until Oct. 2017
2016:35 - Willem Marais
2016:35 4464.80
255.14
Co. Reg. nr. CK89/04426/23
7551
Bank details :
Bank : NEDBANK (Centurion branch)
Bank code : 198765(00) or 162145
Acc. no. : 1621 099431
Sub-Total R 4719.94
14 % VAT R 660.79
Nett. Total R
Payment terms : COD
5380.73
Please use payment reference : 50
*/
