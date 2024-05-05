using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite.Data
{
    [Serializable]
    public class ThemeColorInfo
    {
        public ControlName Name { get; set; }
        public int Color { get; set; }
    }

    public enum ControlName
    {
        Primary,
        Menu,
        MenuText,
        MenuBorder,
        MenuBorderText,
        SubText,
        SavedUserControl,
        UnsavedUserControl,
        ControlImportText,
        ControlText,
        UserControl,
        ControlList,
        SelectedControl,
        InputControl,
        InputText,
        WorkSpace,
        StatusText,
        Red,
        Blue,
        Pink,
        Green,
        Orange,
        Yellow,
        InactiveControlText,
        InactiveControl,
        PrimaryText,
        Search,
        SearchText,
        SearchMatchText,
        SearchMatch,
    }
}
