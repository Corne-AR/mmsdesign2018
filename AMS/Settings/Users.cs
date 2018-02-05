using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Settings
{
    public static class Users
    {
        /// <summary>
        /// If limit > 1 then AMS will automatically go into Network Mode with Network Users
        /// </summary>
        public static int Limit = 1;

        /// <summary>
        /// Saving UserKP increment data inside NetworkUserProfile
        /// </summary>
        public static bool UserPk = true;
        public static bool UseFastLogin = false;

        public static class Roles
        {
            public static bool Administartors = true;
            public static bool Commerce = true;
            public static bool Clients = true;
            public static bool Management = true;
        }
    }
}