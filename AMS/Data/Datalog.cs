using AMS.Data.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data
{
    [Serializable]
    public class Datalog
    {
        /// <summary>
        /// Used to associate to the parent, for example an id or account
        /// </summary>
        public string Reference { get; set; }
        public string Message { get; set; }
        public DataType DataType { get; set; } 
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        
        public Datalog()
        {
        }

        #region HashSet Identifier

        public override bool Equals(object obj)
        {
            var other = obj as Datalog;
            if (other == null)
            {
                return false;
            }
            if (Message == null) return false;
            return Message == other.Message;
        }

        public override int GetHashCode()
        {
            return (Message + UserName + Created.Ticks).GetHashCode();
        }

        #endregion
    }
}
