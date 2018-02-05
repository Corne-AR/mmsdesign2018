using AMS;
using Data.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS_Certificate.Forms
{
    public partial class Certificates : Form
    {
        // Variables
        string seachDirectory = @"C:\";
        public List<Attendee> AttendeeList;
        public Course Course;

        //private bool refreshToolTip = false;
        private Timer timer = new Timer();
        
        private Point preview_TargetPoint = new Point();
        private Point fullName_TargetPoint = new Point(1275, 1650);
        private Point discirption_TargetPoint = new Point(1275, 2350);
        private Point instructor_TargetPoint = new Point(700, 3240);
        private Point cpd_TargetPoint = new Point(1275, 2510); //{X=1274,Y=2509}
        private Point dateOne_TargetPoint = new Point(970, 2820);
        private Point dateTwo_TargetPoint = new Point(1600, 2820);

        private Font font = new Font("Palatino Linotype", 42, FontStyle.Bold);

        private bool snapEnabled = true;
        public bool drawBoundingBox = true;
        // Constructors

        public Certificates()
        {
            InitializeComponent();

            #region ThemeColors

            footer1.UpdateFooterText("Certificates");
            this.panel1.BackColor = ThemeColors.Menu;
            this.panel1.ForeColor = ThemeColors.MenuText;

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.BackColor = ThemeColors.Menu;
                }
            }

            #endregion

            // bug fix, force load
            Certificates_Load();
        }

        public Certificates(Course Course)
        {
            InitializeComponent();

            #region ThemeColors

            footer1.UpdateFooterText("Certificates");
            this.panel1.BackColor = ThemeColors.Menu;
            this.panel1.ForeColor = ThemeColors.MenuText;

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.BackColor = ThemeColors.Menu;
                }
            }

            #endregion

            this.Course = Course;
        }

        // Load
        private void Certificates_Load()
        {
            preview_PictureBox.Size = new Size(950, 1344);
            if (Course == null) Course = new Course();

            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            //toolTip.SetToolTip(preview_PictureBox, "Coords");

            snap_CheckBox.Checked = snapEnabled;

            CheckSnap();
        }

        // Methods

        #region ---------- Preview Image & Snap ----------

        private void CheckSnap()
        {
            if (snapEnabled)
            {
                snapHLine_panel.Visible = true;
                snapHControl_Panel.Visible = true;
                snapHLine_Label.Visible = true;
                coords_Label.ForeColor = Color.Green;

            }
            else
            {
                snapHLine_panel.Visible = false;
                snapHControl_Panel.Visible = false;
                snapHLine_Label.Visible = false;
                coords_Label.ForeColor = Color.Black;
            }
        }

        private Point SnapPreviewTargetPoint(Point p)
        {
            var zoom = preview_PictureBox.Width / preview_PictureBox.Image.PhysicalDimension.Width;

            int x = (p.X);
            int y = (p.Y);
            int offset = 25;

            if (snapEnabled)
            {
                // snap x
                if (p.X < (preview_PictureBox.Size.Width / 2) + offset && p.X > (preview_PictureBox.Size.Width / 2) - offset)
                {
                    x = preview_PictureBox.Size.Width / 2;
                    previewHSnap_Panel.Visible = true;
                    previewHSnap_Panel.Location = new Point(x, 0);
                    previewHSnap_Panel.Size = new Size(3, preview_PictureBox.Size.Height);
                }
                else
                {
                    previewHSnap_Panel.Visible = false;
                }

                // Snap y to snapHLine
                if (Cursor.Position.Y < snapHLine_panel.Location.Y + 80 + offset && Cursor.Position.Y > snapHLine_panel.Location.Y + 80 - offset)
                {
                    y = (int)(-1 * preview_PictureBox.Location.Y + snapHLine_panel.Location.Y - 20); // 80 for screen ofset fix

                    snapHLine_panel.BackColor = AMS.ThemeColors.Primary;
                    snapHLine_Label.BackColor = AMS.ThemeColors.Primary;
                    snapHLine_Label.Text = y.ToString();
                    coords_Label.ForeColor = AMS.ThemeColors.Primary;
                }
                else
                {
                    snapHLine_panel.BackColor = AMS.ThemeColors.Green;
                    snapHLine_Label.BackColor = AMS.ThemeColors.Green;
                    snapHLine_Label.Text = snapHLine_panel.Location.Y.ToString();
                    coords_Label.ForeColor = AMS.ThemeColors.Green;
                }
            }
            else
            {
                previewHSnap_Panel.Visible = false;
            }
            x = (int)(x / zoom);
            y = (int)(y / zoom);
            coords_Label.Text = x + ":" + y;
            return new Point(x, y);
        }

        // Move Snap panels
        private void snapHControl_Panel_Click(object sender, EventArgs e)
        {
            snapHLine_panel.Location = new Point(220, Cursor.Position.Y - 80);  // the 80 is screen offset fix
            snapHLine_Label.Location = new Point(snapHLine_Label.Location.X, snapHLine_panel.Location.Y + 9);
            snapHLine_Label.Text = snapHLine_panel.Location.Y.ToString();
        }

        private void SnapEnabled_Event(object sender, EventArgs e)
        {
            snapEnabled = snap_CheckBox.Checked;
            CheckSnap();
        }

        private void Timer_Tick(object sender, EventArgs e) //The timer is to control the tooltip, it shouldn't redraw on each mouse move.
        {
            timer.Stop();
            //refreshToolTip = true;
        }

        private void Preview_PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Start();
            preview_TargetPoint = SnapPreviewTargetPoint(e.Location);

            //if (refreshToolTip)
            //    toolTip.Show(preview_TargetPoint.X  + ":" + preview_TargetPoint.Y, this, Cursor.Position.X + 10, Cursor.Position.Y);
            
            //refreshToolTip = false;
        }
        
        #endregion

        #region ---------- Certificate Preview ----------

        private void UpdateImages(string FileName)
        {
            this.preview_PictureBox.Image = new Bitmap(FileName);
            this.smallPreview_PictureBox.Image = new Bitmap(FileName);
        }

        private void WriteTextOnImage(string Text, Point Point, int FontSize)
        {
            Bitmap bmp = new Bitmap(preview_PictureBox.Image);
            Graphics gr = Graphics.FromImage(bmp);

            FontSize = FontSize * 7;

            Font newFont = new System.Drawing.Font(font.Name, (float)(FontSize), font.Style);

            int textWidth = (int)gr.MeasureString(Text, newFont).Width;
            int textHeight = (int)gr.MeasureString(Text, newFont).Height;

            
            if ((float)(textWidth / preview_PictureBox.Image.PhysicalDimension.Width) > 0.7f)
            {
                bool keepshrinking = true;

                while (keepshrinking)
                {
                    FontSize -= 2;
                    newFont = new System.Drawing.Font(font.Name, (float)(FontSize), font.Style);
                    
                    textWidth = (int)gr.MeasureString(Text, newFont).Width;
                    textHeight = (int)gr.MeasureString(Text, newFont).Height;

                    if ((float)(textWidth / preview_PictureBox.Image.PhysicalDimension.Width) < 0.7f) keepshrinking = false;
                }
            }

            textWidth = (int)gr.MeasureString(Text, newFont).Width;
            textHeight = (int)gr.MeasureString(Text, newFont).Height;

            int newX = Point.X;// -(textWidth / 2);
            int newY = Point.Y - textHeight;
            
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            
            #region Bounding Box

            if (drawBoundingBox)
            {
                // Top Horizontal 
                int lineX = newX - (textWidth / 2);
                int lineY = newY;

                gr.DrawLine(new Pen(Color.Red), new Point(lineX, lineY), new Point(lineX + textWidth, lineY));

                // Bottom Horizontal
                lineY += textHeight;
                gr.DrawLine(new Pen(Color.Red), new Point(lineX, lineY), new Point(lineX + textWidth, lineY));

                // Left Vertical
                gr.DrawLine(new Pen(Color.Red), new Point(lineX, lineY), new Point(lineX, lineY - textHeight));

                // Left Vertical
                gr.DrawLine(new Pen(Color.Red), new Point(lineX + textWidth, lineY), new Point(lineX + textWidth, lineY - textHeight));
            }

            #endregion

            gr.DrawString(Text, newFont, Brushes.Black, new Point(newX, newY), sf);
            preview_PictureBox.Image = bmp;
        }

        private void DrawPreview()
        {
            drawBoundingBox = true;

            preview_PictureBox.Image = global::AMS_Certificate.Properties.Resources.Model_Maker_Certificate;

            WriteTextOnImage("Full Name Here", fullName_TargetPoint, (int)(fullName_NumericUpDown.Value));
            WriteTextOnImage("Certificate Description\r\nLine Two", discirption_TargetPoint, (int)(discirption_NumericUpDown.Value));
            WriteTextOnImage("CC-9201", cpd_TargetPoint, (int)(cpd_NumericUpDown.Value));
            WriteTextOnImage("26th", dateOne_TargetPoint, (int)(dateOne_NumericUpDown.Value));
            WriteTextOnImage("January 2013", dateTwo_TargetPoint, (int)(dateTwo_NumericUpDown.Value));
            WriteTextOnImage("Instructor", instructor_TargetPoint, (int)(instructor_NumericUpDown.Value));

            if (Course.AttendeeList.Count > 0)
            {
                preview_PictureBox.Image = global::AMS_Certificate.Properties.Resources.Model_Maker_Certificate;

                WriteTextOnImage(Course.AttendeeList[0].FullName, fullName_TargetPoint, (int)(fullName_NumericUpDown.Value));
                WriteTextOnImage(Course.AttendeeList[0].CourseDescription, discirption_TargetPoint, (int)(discirption_NumericUpDown.Value ));
                WriteTextOnImage(Course.AttendeeList[0].CPD, cpd_TargetPoint, (int)(cpd_NumericUpDown.Value));
                WriteTextOnImage(Course.AttendeeList[0].DateOne, dateOne_TargetPoint, (int)(dateOne_NumericUpDown.Value));
                WriteTextOnImage(Course.AttendeeList[0].DateTwo, dateTwo_TargetPoint, (int)(dateTwo_NumericUpDown.Value));
                WriteTextOnImage(Instructor_TextBox.Text, instructor_TargetPoint, (int)(instructor_NumericUpDown.Value));
            }

            drawBoundingBox = false;
        }

        // Right Click Menu

        private void Preview_Click(object sender, EventArgs e)
        {
            DrawPreview();
        }

        private void FullNamePreview_Click(object sender, EventArgs e)
        {
            fullName_TargetPoint = preview_TargetPoint;
            DrawPreview();
        }

        private void DescriptionPreview_Click(object sender, EventArgs e)
        {
            discirption_TargetPoint = preview_TargetPoint;
            DrawPreview();
        }

        private void CpdPreview_Click(object sender, EventArgs e)
        {
            cpd_TargetPoint = preview_TargetPoint;
            DrawPreview();
        }

        private void DayPreview_Click(object sender, EventArgs e)
        {
            dateOne_TargetPoint = preview_TargetPoint;
            DrawPreview();
        }

        private void MonthYearPreview_Click(object sender, EventArgs e)
        {
            dateTwo_TargetPoint = preview_TargetPoint;
            DrawPreview();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            instructor_TargetPoint = preview_TargetPoint;
            DrawPreview();
        }

        #endregion

        // Events

        private void browse_Button_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = seachDirectory;
     
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                seachDirectory = new FileInfo(openFileDialog1.FileName).DirectoryName;
                UpdateImages(openFileDialog1.FileName);
            }
        }

        private void attendees_Button_Click(object sender, EventArgs e)
        {
            using (Forms.Course_Attendees f = new Course_Attendees(Course.AttendeeList))
            {
                f.ShowDialog();
            }
        }

        private void font_button_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = font;
            fontDialog1.ShowDialog();
            font = fontDialog1.Font;
        }

        private void print_Button_Click(object sender, EventArgs e)
        {
            drawBoundingBox = false;

            foreach (var i in Course.AttendeeList)
            {
                preview_PictureBox.Image = global::AMS_Certificate.Properties.Resources.Model_Maker_Certificate;

                var zoom = preview_PictureBox.Width / preview_PictureBox.Image.PhysicalDimension.Width;

                WriteTextOnImage(i.FullName, fullName_TargetPoint, (int)(fullName_NumericUpDown.Value));
                WriteTextOnImage(i.CourseDescription, discirption_TargetPoint, (int)(discirption_NumericUpDown.Value));
                WriteTextOnImage(i.CPD, cpd_TargetPoint, (int)(cpd_NumericUpDown.Value));
                WriteTextOnImage(i.DateOne, dateOne_TargetPoint, (int)(dateOne_NumericUpDown.Value));
                WriteTextOnImage(i.DateTwo, dateTwo_TargetPoint, (int)(dateTwo_NumericUpDown.Value));
                WriteTextOnImage(Instructor_TextBox.Text, instructor_TargetPoint, (int)(instructor_NumericUpDown.Value));

                System.Windows.Forms.Application.DoEvents();

                var certificate = preview_PictureBox.Image;

                if (i.Metadata.Created.Year < 1900) i.Metadata.Created = DateTime.Now;

                string fileName = AMS.Settings.Program.Directories.Certificates + i.FullName + " - " + string.Format("{0: dd MMM yyyy}", i.Metadata.Created) + " - " + ".jpg"; //@"C:\Temp\image " + AMS.Data.UniqueKey.NewShortCode() + ".jpg";
                FileInfo file = new FileInfo(fileName);
                if(!Directory.Exists(file.DirectoryName)) Directory.CreateDirectory(file.DirectoryName);
                certificate.Save(fileName, ImageFormat.Jpeg);
            }

            System.Diagnostics.Process.Start(AMS.Settings.Program.Directories.Certificates);
        }
    }
}
