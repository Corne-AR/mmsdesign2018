using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Utilities.Controls
{
    public static class General
    {
        public static Control GetTopParent(Control theControl)
        {
            if (theControl == null) return null;

            Control rControl = null;

            if (theControl.Parent != null)
            {
                if (theControl.Parent.GetType() == typeof(System.Windows.Forms.Form))
                {
                    rControl = theControl.Parent;
                }
                else
                {
                    rControl = GetTopParent(theControl.Parent);
                }
            }
            else
            {
                rControl = null;
            }
            return rControl;
        }
    }
}
