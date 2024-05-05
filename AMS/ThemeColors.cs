using AMS.Suite;
using AMS.Suite.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS
{
    public static class ThemeColors
    {
        private static List<ThemeColorInfo> themeColors
        {
            get
            {
                if (!AMS_Manager.HasLoaded) return new List<ThemeColorInfo>();
                return SuiteManager.Profile.ThemeColorList;
            }
        }

        // Primary
        public static Color Primary
        {
            get
            {
                return GetColor(ControlName.Primary, Color.FromArgb(248, 146, 47));
            }
        }
        public static Color PrimaryText
        {
            get
            {
                return GetColor(ControlName.PrimaryText, Color.FromArgb(255, 255, 255));
            }
        }
        public static Color SubText
        {
            get
            {
                return GetColor(ControlName.SubText, Color.FromArgb(150, 150, 150));
            }
        }

        // Menu

        public static Color Menu
        {
            get
            {
                return GetColor(ControlName.Menu, Color.FromArgb(107, 107, 107));
            }
        }
        public static Color MenuText
        {
            get
            {
                return GetColor(ControlName.MenuText, Color.FromArgb(255, 255, 255));
            }
        }
        public static Color MenuBorder
        {
            get
            {
                return GetColor(ControlName.MenuBorder, Color.FromArgb(77, 77, 77));
            }
        }
        public static Color MenuBorderText
        {
            get
            {
                return GetColor(ControlName.MenuBorderText, Color.FromArgb(150, 150, 150));
            }
        }

        // Workspace

        public static Color WorkSpace
        {
            get
            {
                return GetColor(ControlName.WorkSpace, Color.FromArgb(240, 240, 240));
            }
        }
        public static Color InputText
        {
            get
            {
                return GetColor(ControlName.InputText, Color.FromArgb(0, 0, 0));
            }
        }
        public static Color InputControl
        {
            get
            {
                return GetColor(ControlName.InputControl, Color.FromArgb(255, 255, 255));
            }
        }
        public static Color SelectedControl
        {
            get
            {
                return GetColor(ControlName.SelectedControl, Color.FromArgb(120, 120, 220));
            }
        }
        public static Color ControlList
        {
            get
            {
                return GetColor(ControlName.ControlList, Color.FromArgb(150, 150, 150));
            }
        }
        public static Color UserControl
        {
            get
            {
                return GetColor(ControlName.UserControl, SystemColors.Control);
            }
        }
        public static Color ControlText
        {
            get
            {
                return GetColor(ControlName.ControlText, Color.FromArgb(80, 80, 80));
            }
        }
        
        public static Color ControlImportText
        {
            get
            {
                return GetColor(ControlName.ControlImportText, Color.FromArgb(20, 20, 20));
            }
        }

        public static Color UnsavedUserControl
        {
            get
            {
                return GetColor(ControlName.UnsavedUserControl, Color.FromArgb(250, 150, 150));
            }
        }
        public static Color SavedUserControl
        {
            get
            {
                return GetColor(ControlName.SavedUserControl, Color.FromArgb(150, 250, 150));
            }
        }
        
        public static Color InactiveControl
        {
            get
            {
                return GetColor(ControlName.InactiveControl, Color.FromArgb(50, 50, 50));
            }
        }
        public static Color InactiveControlText
        {
            get
            {
                return GetColor(ControlName.InactiveControlText, Color.FromArgb(100, 100, 100));
            }
        }

        // Status

        public static Color Search
        {
            get
            {
                return GetColor(ControlName.Search, Color.FromArgb(10, 146, 47));
            }
        }
        public static Color SearchText
        {
            get
            {
                return GetColor(ControlName.SearchText, Color.FromArgb(255, 255, 255));
            }
        }
        public static Color SearchMatch
        {
            get
            {
                return GetColor(ControlName.SearchMatch, Color.FromArgb(20, 156, 57));
            }
        }
        public static Color SearchMatchText
        {
            get
            {
                return GetColor(ControlName.SearchMatchText, Color.FromArgb(255, 255, 255));
            }
        }
        public static Color StatusText
        {
            get
            {
                return GetColor(ControlName.StatusText, Color.FromArgb(255, 255, 255));
            }
        }

        public static Color Red
        {
            get
            {
                return GetColor(ControlName.Red, Color.FromArgb(250, 30, 30));
            }
        }
        public static Color Yellow
        {
            get
            {
                return GetColor(ControlName.Yellow, Color.FromArgb(230, 220, 30));
            }
        }
        public static Color Blue
        {
            get
            {
                return GetColor(ControlName.Blue, Color.FromArgb(32, 91, 212));
            }
        }
        public static Color Pink
        {
            get
            {
                return GetColor(ControlName.Pink, Color.FromArgb(255, 102, 255));
            }
        }
        public static Color Green
        {
            get
            {
                return GetColor(ControlName.Green, Color.FromArgb(42, 212, 65));
            }
        }
        public static Color Orange
        {
            get
            {
                return GetColor(ControlName.Orange, Color.FromArgb(248, 146, 47));
            }
        }

        public static void SetControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.BackColor = ThemeColors.Menu;
                    c.ForeColor = ThemeColors.MenuText;
                    ((Button)c).FlatStyle = FlatStyle.Popup;
                }

                if (c.GetType() == typeof(Label)) c.ForeColor = ThemeColors.ControlText;
                if (c.GetType() == typeof(ComboBox)) c.ForeColor = ThemeColors.InputText;
                if (c.GetType() == typeof(ComboBox)) c.BackColor = ThemeColors.InputControl;
                if (c.GetType() == typeof(CheckBox)) c.ForeColor = ThemeColors.SubText;
                if (c.GetType() == typeof(CheckBox)) c.BackColor = ThemeColors.WorkSpace;
                if (c.GetType() == typeof(TextBox)) c.ForeColor = ThemeColors.InputText;
                if (c.GetType() == typeof(TextBox)) c.BackColor = ThemeColors.InputControl;
                if (c.GetType() == typeof(NumericUpDown)) c.ForeColor = ThemeColors.InputText;
                if (c.GetType() == typeof(NumericUpDown)) c.BackColor = ThemeColors.InputControl;
                if (c.GetType() == typeof(Panel)) c.BackColor = ThemeColors.WorkSpace;
                if (c.GetType() == typeof(Panel)) c.ForeColor = ThemeColors.ControlText;
                if (c.GetType() == typeof(FlowLayoutPanel)) c.BackColor = ThemeColors.ControlList;
                if (c.GetType() == typeof(FlowLayoutPanel)) c.ForeColor = ThemeColors.ControlText;
            }
        }

        public static void SetBorders(Form Form)
        {
            Form.Padding = new Padding(1);
            Form.Paint += Form_Paint;
        }

        private static void Form_Paint(object sender, PaintEventArgs e)
        {
            // using (Graphics gr = e.Graphics)
            {
                var p = new Pen(ThemeColors.Primary, 1);

                // Top Horizontal 
                e.Graphics.DrawLine(p, 0, 0, ((Form)sender).Width, 0);

                // Bottom Horizontal
                e.Graphics.DrawLine(p, 0, ((Form)sender).Height - 1, ((Form)sender).Width, ((Form)sender).Height - 1);

                // Left Vertical
                e.Graphics.DrawLine(p, 0, 0, 0, ((Form)sender).Height);

                // Right Vertical
                e.Graphics.DrawLine(p, ((Form)sender).Width - 1, 0, ((Form)sender).Width - 1, ((Form)sender).Height);
            }
        }

        public enum ControlType
        {
            Menu,
            Control,
            Input,
            Status,
            Workspace,
            List,
            MenuBorder,
            Primary
        }

        public static void SetControls(Control Control, ControlType controlType)
        {
            if (controlType == ControlType.Menu) Control.ForeColor = ThemeColors.MenuText;
            if (controlType == ControlType.Menu) Control.BackColor = ThemeColors.Menu;
            if (controlType == ControlType.MenuBorder) Control.ForeColor = ThemeColors.MenuBorderText;
            if (controlType == ControlType.MenuBorder) Control.BackColor = ThemeColors.MenuBorder;
            if (controlType == ControlType.List) Control.BackColor = ThemeColors.ControlList;
            if (controlType == ControlType.Input) Control.BackColor = ThemeColors.InputControl;
            if (controlType == ControlType.Input) Control.ForeColor = ThemeColors.InputText;
            if (controlType == ControlType.Primary) Control.BackColor = ThemeColors.Primary;
            if (controlType == ControlType.Primary) Control.ForeColor = ThemeColors.PrimaryText;

            if (Control.GetType() == typeof(Button)) ((Button)Control).FlatStyle = FlatStyle.Flat;
            if (Control.GetType() == typeof(Panel))
            {
                foreach (Control c in Control.Controls)
                {
                    SetControls(c, controlType);
                }
            }

            if (Control.GetType() == typeof(ToolStrip))
            {
                foreach (Control c in Control.Controls)
                {
                    SetControls(c, controlType);
                }
            }
        }

        /// <summary>
        /// Gets the Color from the colorList, else add a default color to list
        /// </summary>
        /// <param name="colorName">Which Enum Color</param>
        /// <param name="color">Default Color Value</param>
        /// <returns></returns>
        private static Color GetColor(ControlName colorName, Color color)
        {
            if (!AMS_Manager.HasLoaded) return color;

            // Get Color
            var query = (from i in themeColors
                         where i.Name == colorName
                         select i).FirstOrDefault();

            // Create New Color if needed
            if (query == null)
            {
                query = new ThemeColorInfo()
                    {
                        Name = colorName,
                        Color = color.ToArgb()
                    };

                themeColors.Add(query);
            }

            // Return Color
            return Color.FromArgb(query.Color);
        }
    }
}