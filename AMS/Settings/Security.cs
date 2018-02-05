using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Settings
{
    public static class Security
    {
        /// <summary>
        /// Needs a 24-bit key
        /// </summary>
        public static string SecurityKey = "ASSETMANAGEMENTSTUDIO013"; // 24-bit AAECAwQFBgcICQoLDA0ODw11
        public static bool UseHashing = false;
        public static bool UseLicense = true;
        public static bool UseEncryption = true;

        public static Data.Users.NetworkUser Admin { get; set; }
    }
}
