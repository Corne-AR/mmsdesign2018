using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Utilities.Forms
{
    public static class State
    {
        public static void CenterSizePosition(Form Form)
        {
            Form.Size = new Size(Form.Size.Width, Screen.FromControl(Form).WorkingArea.Height);
            Form.Location = new Point(Screen.FromControl(Form).WorkingArea.Width / 2 - Form.Size.Width / 2, 0); 
        }
    }
}
