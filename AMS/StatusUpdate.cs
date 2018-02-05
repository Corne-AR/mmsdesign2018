using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS
{
    public static class StatusUpdate
    {
        public static ToolStripStatusLabel Area = new ToolStripStatusLabel();
        public static ToolStripStatusLabel SelectionOne = new ToolStripStatusLabel();
        public static ToolStripStatusLabel SelectionHeaderOne = new ToolStripStatusLabel()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Right,
            BorderStyle = Border3DStyle.Bump
        };

        public static ToolStripStatusLabel SelectionTwo = new ToolStripStatusLabel();
        public static ToolStripStatusLabel SelectionHeaderTwo = new ToolStripStatusLabel()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Right,
            BorderStyle = Border3DStyle.Bump
        };

        public static ToolStripStatusLabel DataInfo = new ToolStripStatusLabel();
        public static ToolStripProgressBar ProgressBar = new ToolStripProgressBar();

        public static StringBuilder Log = new StringBuilder();
        
        // DevTools.DevToolsForm DevTools;

        public static void UpdateArea(string area)
        {
            // ClearArea();

            Log.AppendLine(DateTime.Now + " -1- " + area);
            // Area.Text = area;
            //AMS_Wpf.StatusBar.StatusUpdate.UpdateArea(area);
            //if (DevTools.inDevMode)
            //    DevTools.StatusUpdates(UpdateString);
        }

        public static void UpdateSelectionOne(string header, string selection)
        {
            Log.AppendLine(DateTime.Now + " -1- " + header + ": " + selection);
            SelectionOne.Text = selection;
            SelectionHeaderOne.Text = header;
            //AMS_Wpf.StatusBar.StatusUpdate.UpdateSelectionOne(header, selection);
            //if (DevTools.inDevMode)
            //    DevTools.StatusUpdates(UpdateString);
        }

        public static void UpdateSelectionTwo(string header, string selection)
        {
            Log.AppendLine(DateTime.Now + " -1- " + header + ": " + selection);
            SelectionTwo.Text = selection;
            SelectionHeaderTwo.Text = header;
            //AMS_Wpf.StatusBar.StatusUpdate.UpdateSelectionTwo(header, selection);
         
            //if (DevTools.inDevMode)
            //    DevTools.StatusUpdates(UpdateString);
        }

        public static void UpdateDataCount(string dataInfo)
        {
            Log.AppendLine(DateTime.Now + " -1- " + dataInfo);
            DataInfo.Text = dataInfo.ToString();
            //AMS_Wpf.StatusBar.StatusUpdate.UpdateData("", dataInfo);
         

            //if (DevTools.inDevMode)
            //    DevTools.StatusUpdates(UpdateString);
        }

        internal static void ClearArea()
        {
            if (Area.Text.Trim() != "") Area.Text = "";
            else return;
        }

        internal static void ClearSelectionOne()
        {
            if (SelectionOne.Text.Trim() != "") SelectionOne.Text = "";
            else return;
        }

        internal static void ClearDataInfo()
        {
            if (DataInfo.Text.Trim() != "") DataInfo.Text = "";
            else return;
        }

        /// <summary>
        /// Adds Increment Progress to Progress Bar
        /// </summary>
        /// <param name="Steps">Increment Amount</param>
        public static void AddtoProgressBar(int Steps)
        {
            if (ProgressBar.Value < 90) ProgressBar.Visible = true;

            System.Windows.Forms.Application.DoEvents();
            ProgressBar.Increment(100 / Steps);
            System.Threading.Thread.Sleep(100);

            if (ProgressBar.Value >= 100) ProgressBar.Visible = false;
        }

        public static void Clear()
        {
            //AMS_Wpf.StatusBar.StatusUpdate.Clear();
        }
    }
}
