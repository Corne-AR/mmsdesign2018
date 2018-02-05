using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite.Data
{
    /// <summary>
    /// Storing Local Program Preferences
    /// </summary>
    [Serializable]
    public class LocalPreferences
    {
        public ClientManager ClientManager { get; set; }
        public General General { get; set; }

        public LocalPreferences()
        {
            ClientManager = new ClientManager();
            General = new General();
        }

        public int CourseSelectSize { get; set; }
    }
}
