using AMS.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Data.Keys
{
    public static class UserPKManager
    {
        public static string NewUserPK(KeyType PK)
        {
            return NewUserPK(PK, null);
        }

        public static string NewUserPK(KeyType PK, string Subfix)
        {
            if (!AMS.Settings.Users.UserPk)
                return null;

            if (Subfix == null) Subfix = "";

            System.Windows.Forms.Application.DoEvents();
            int pkNumber = 0;
            string prefix = UserManager.CurrentUser.Prefix;

            switch (PK)
            {
                case KeyType.Account:
                    pkNumber = UserManager.CurrentUser.UserPK.Account + 1;
                    prefix = "A" + prefix + Subfix;
                    break;
                case KeyType.Receipt:
                    pkNumber = UserManager.CurrentUser.UserPK.Receipt + 1;
                    prefix = "R" + prefix + Subfix;
                    break;
                case KeyType.Invoice:
                    pkNumber = UserManager.CurrentUser.UserPK.Invoice + 1;
                    prefix = "I" + prefix + Subfix;
                    break;
                case KeyType.Proforma:
                    pkNumber = UserManager.CurrentUser.UserPK.Proforma + 1;
                    prefix = "P" + prefix + Subfix;
                    break;
                case KeyType.PurchaseOrder:
                    pkNumber = UserManager.CurrentUser.UserPK.PurchaseOrder + 1;
                    prefix = "PO" + prefix + Subfix;
                    break;
                case KeyType.Quote:
                    pkNumber = UserManager.CurrentUser.UserPK.Quote + 1;
                    prefix = "Q" + prefix + Subfix;
                    break;
                case KeyType.Task:
                    pkNumber = UserManager.CurrentUser.UserPK.Task + 1;
                    prefix = "T" + prefix + Subfix;
                    break;
                case KeyType.CustomProduct:
                    pkNumber = UserManager.CurrentUser.UserPK.CustomProduct + 1;
                    prefix = "CP" + prefix + Subfix;
                    break;
                case KeyType.Person:
                    pkNumber = UserManager.CurrentUser.UserPK.Person + 1;
                    prefix = "PN" + prefix + Subfix;
                    break;
            }

            string newPk = (prefix + string.Format("{0:0000}", pkNumber)).ToUpper();
            return newPk;
        }

        public static void UpdatePk(KeyType PK, string PKID)
        {
            UpdatePk(PK, PKID, null);
        }

        public static void UpdatePk(KeyType PK, string PKID, string Subfix)
        {
            if (PKID == NewUserPK(PK, Subfix).ToString())
            {
                switch (PK)
                {
                    case KeyType.Account:
                        UserManager.CurrentUser.UserPK.Account++;
                        break;
                    case KeyType.Receipt:
                        UserManager.CurrentUser.UserPK.Receipt++;
                        break;
                    case KeyType.Invoice:
                        UserManager.CurrentUser.UserPK.Invoice++;
                        break;
                    case KeyType.Proforma:
                        UserManager.CurrentUser.UserPK.Proforma++;
                        break;
                    case KeyType.PurchaseOrder:
                        UserManager.CurrentUser.UserPK.PurchaseOrder++;
                        break;
                    case KeyType.Quote:
                        UserManager.CurrentUser.UserPK.Quote++;
                        break;
                    case KeyType.Task:
                        UserManager.CurrentUser.UserPK.Task++;
                        break;
                    case KeyType.CustomProduct:
                        UserManager.CurrentUser.UserPK.CustomProduct++;
                        break;
                    case KeyType.Person:
                        UserManager.CurrentUser.UserPK.Person++;
                        break;
                }
                UserManager.SaveCurrentUser();
            }
        }

        public static int CurrentPk(KeyType PK)
        {
            int value = 0;

            switch (PK)
            {
                case KeyType.Task:
                    value = UserManager.CurrentUser.UserPK.Task;
                    break;
            }

            return value;
        }

        public static void SetPk(KeyType PK, int Value)
        {
            int value = Value;

            switch (PK)
            {
                case KeyType.Task:
                    UserManager.CurrentUser.UserPK.Task = value;
                    break;
            }
            UserManager.SaveCurrentUser();
        }
    }
}
