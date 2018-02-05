using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.People
{
    public enum MaintenanceType
    {
        /// <summary>
        /// Never had Maintenance
        /// </summary>
        New,
        /// <summary>
        /// An Current Maintenance
        /// </summary>
        Current,
        /// <summary>
        /// Maintenance has expired
        /// </summary>
        Expired,
        Expiring
    }
}
