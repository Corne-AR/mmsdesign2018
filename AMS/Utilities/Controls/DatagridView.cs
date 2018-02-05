using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Utilities.Controls
{
    public static class DatagridView
    {
        public static DataTable PasteClipboard(DataTable dt)
        {
            // 1. Get Clipboard Text
            // 2. Split into lines based on return enter
            // 3. for each line: Break the line up in tabs

            string clipboard = Clipboard.GetText();
            string[] lines = clipboard.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] cells = line.Split('\t');
                object[] cellValues = new object[dt.Columns.Count];

                for (int i = 0; i < cells.GetLength(0); ++i)
                    cellValues[i] = cells[i];

                if (cellValues.Length != 0) dt.Rows.Add(cellValues);
            }
            return dt;
        }


        public static void PopulateComboBox(DataGridView dgv, string Name, List<string> NameList)
        {
            if (NameList == null || NameList.Count == 0) return;
            try
            {
                ((DataGridViewComboBoxColumn)dgv.Columns[Name]).Items.Clear();

                foreach (var i in NameList)
                    ((DataGridViewComboBoxColumn)dgv.Columns[Name]).Items.Add(i.ToString());
            }
            catch { }
        }


    }
}
