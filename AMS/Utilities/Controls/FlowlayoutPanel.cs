using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Utilities.Controls
{
    public static class FlowlayoutPanel
    {
        public static System.Drawing.Size ResizePanel(FlowLayoutPanel FlowLayoutPanel, Control UserControl)
        {
            int width = FlowLayoutPanel.Size.Width - 9;
            int height = UserControl.Size.Height;

            if (FlowLayoutPanel.VerticalScroll.Visible)
                width -= 27;

            return new System.Drawing.Size(width, height);
        }

        public static void CleanUp(FlowLayoutPanel FlowLayoutPanel)
        {
            while (FlowLayoutPanel.Controls.Count > 0)
            {
                var c = FlowLayoutPanel.Controls[0];
                FlowLayoutPanel.Controls.Remove(c);
                c.Dispose();
            }
        }
    }
}
