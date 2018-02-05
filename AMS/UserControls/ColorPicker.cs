using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.UserControls
{
    public partial class ColorPicker : UserControl
    {
        public Color Color = ThemeColors.SubText;

        public ColorPicker()
        {
            InitializeComponent();
        }

        public ColorPicker(Color Color)
        {
            InitializeComponent();
            this.Color = Color;
        }


        private void pickColor_Button_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color;
            colorDialog1.ShowDialog();
            Color = colorDialog1.Color;

            this.BackColor = Color;
        }

        public void SetColor(System.Drawing.Color Color)
        {
            this.Color = Color;
            this.BackColor = Color;
            this.BackColor = Color;
        }

        public void SetColorFromHex(string HexString)
        {
            this.Color = (Color)(new ColorConverter().ConvertFromString(HexString));
            this.BackColor = Color;
            this.BackColor = Color;
        }
    }
}
