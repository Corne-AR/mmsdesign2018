namespace AMS.Scheduling.Forms
{
    partial class Recur_Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label everyFollowingNthLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            this.startDateTime_Label = new System.Windows.Forms.Label();
            this.type_Label = new System.Windows.Forms.Label();
            this.recurring_Label = new System.Windows.Forms.Label();
            this.startDateTimeMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.recurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.type_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.daily_RadioButton = new System.Windows.Forms.RadioButton();
            this.weekly_RadioButton = new System.Windows.Forms.RadioButton();
            this.monthly_RadioButton = new System.Windows.Forms.RadioButton();
            this.yearly_RadioButton = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.recuring_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.daily_Panel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.everyNthCheckBox = new System.Windows.Forms.CheckBox();
            this.everyFollowingNthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.weekly_Panel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.everyNthCheckBox3 = new System.Windows.Forms.CheckBox();
            this.everyFollowingNthNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.monthly_Panel = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.everyNthCheckBox1 = new System.Windows.Forms.CheckBox();
            this.everyFollowingNthNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.yearly_Panel = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.everyNthCheckBox2 = new System.Windows.Forms.CheckBox();
            this.everyFollowingNthNumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ok_button = new System.Windows.Forms.Button();
            this.footer1 = new AMS.UserInterface.UserControls.Footer();
            this.header1 = new AMS.UserInterface.UserControls.Header();
            everyFollowingNthLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recurBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.type_FlowLayoutPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.recuring_FlowLayoutPanel.SuspendLayout();
            this.daily_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown)).BeginInit();
            this.weekly_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown2)).BeginInit();
            this.monthly_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown1)).BeginInit();
            this.yearly_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // everyFollowingNthLabel
            // 
            everyFollowingNthLabel.AutoSize = true;
            everyFollowingNthLabel.Location = new System.Drawing.Point(3, 38);
            everyFollowingNthLabel.Name = "everyFollowingNthLabel";
            everyFollowingNthLabel.Size = new System.Drawing.Size(34, 13);
            everyFollowingNthLabel.TabIndex = 1;
            everyFollowingNthLabel.Text = "Every";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(91, 38);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(40, 13);
            label3.TabIndex = 3;
            label3.Text = "(s) Day";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(91, 38);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(50, 13);
            label4.TabIndex = 5;
            label4.Text = "(s) Week";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 38);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(34, 13);
            label5.TabIndex = 4;
            label5.Text = "Every";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(91, 38);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 13);
            label6.TabIndex = 8;
            label6.Text = "(s) Year";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 38);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(34, 13);
            label7.TabIndex = 7;
            label7.Text = "Every";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(91, 38);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(51, 13);
            label8.TabIndex = 8;
            label8.Text = "(s) Month";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(3, 38);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(34, 13);
            label9.TabIndex = 7;
            label9.Text = "Every";
            // 
            // startDateTime_Label
            // 
            this.startDateTime_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.startDateTime_Label.Location = new System.Drawing.Point(0, 0);
            this.startDateTime_Label.Name = "startDateTime_Label";
            this.startDateTime_Label.Size = new System.Drawing.Size(255, 20);
            this.startDateTime_Label.TabIndex = 5;
            this.startDateTime_Label.Text = "Starting Date";
            this.startDateTime_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // type_Label
            // 
            this.type_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.type_Label.Location = new System.Drawing.Point(0, 0);
            this.type_Label.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.type_Label.Name = "type_Label";
            this.type_Label.Size = new System.Drawing.Size(74, 20);
            this.type_Label.TabIndex = 7;
            this.type_Label.Text = "Type";
            this.type_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recurring_Label
            // 
            this.recurring_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.recurring_Label.Location = new System.Drawing.Point(0, 0);
            this.recurring_Label.Name = "recurring_Label";
            this.recurring_Label.Size = new System.Drawing.Size(220, 20);
            this.recurring_Label.TabIndex = 7;
            this.recurring_Label.Text = "Recurring";
            this.recurring_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startDateTimeMonthCalendar
            // 
            this.startDateTimeMonthCalendar.DataBindings.Add(new System.Windows.Forms.Binding("SelectionRange", this.recurBindingSource, "RecurDate", true));
            this.startDateTimeMonthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.startDateTimeMonthCalendar.Location = new System.Drawing.Point(3, 23);
            this.startDateTimeMonthCalendar.Margin = new System.Windows.Forms.Padding(3);
            this.startDateTimeMonthCalendar.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.startDateTimeMonthCalendar.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.startDateTimeMonthCalendar.Name = "startDateTimeMonthCalendar";
            this.startDateTimeMonthCalendar.ShowTodayCircle = false;
            this.startDateTimeMonthCalendar.ShowWeekNumbers = true;
            this.startDateTimeMonthCalendar.TabIndex = 4;
            this.startDateTimeMonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.StartDateTimeMonthCalendar_DateSelected);
            // 
            // recurBindingSource
            // 
            this.recurBindingSource.DataSource = typeof(AMS.Data.Scheduling.Recur);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 200);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.type_FlowLayoutPanel);
            this.panel2.Controls.Add(this.type_Label);
            this.panel2.Location = new System.Drawing.Point(270, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(74, 188);
            this.panel2.TabIndex = 7;
            // 
            // type_FlowLayoutPanel
            // 
            this.type_FlowLayoutPanel.AutoSize = true;
            this.type_FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.type_FlowLayoutPanel.Controls.Add(this.daily_RadioButton);
            this.type_FlowLayoutPanel.Controls.Add(this.weekly_RadioButton);
            this.type_FlowLayoutPanel.Controls.Add(this.monthly_RadioButton);
            this.type_FlowLayoutPanel.Controls.Add(this.yearly_RadioButton);
            this.type_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.type_FlowLayoutPanel.Location = new System.Drawing.Point(3, 26);
            this.type_FlowLayoutPanel.Name = "type_FlowLayoutPanel";
            this.type_FlowLayoutPanel.Size = new System.Drawing.Size(68, 92);
            this.type_FlowLayoutPanel.TabIndex = 9;
            // 
            // daily_RadioButton
            // 
            this.daily_RadioButton.AutoSize = true;
            this.daily_RadioButton.Location = new System.Drawing.Point(3, 3);
            this.daily_RadioButton.Name = "daily_RadioButton";
            this.daily_RadioButton.Size = new System.Drawing.Size(48, 17);
            this.daily_RadioButton.TabIndex = 9;
            this.daily_RadioButton.TabStop = true;
            this.daily_RadioButton.Text = "Daily";
            this.daily_RadioButton.UseVisualStyleBackColor = true;
            this.daily_RadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // weekly_RadioButton
            // 
            this.weekly_RadioButton.AutoSize = true;
            this.weekly_RadioButton.Location = new System.Drawing.Point(3, 26);
            this.weekly_RadioButton.Name = "weekly_RadioButton";
            this.weekly_RadioButton.Size = new System.Drawing.Size(61, 17);
            this.weekly_RadioButton.TabIndex = 8;
            this.weekly_RadioButton.TabStop = true;
            this.weekly_RadioButton.Text = "Weekly";
            this.weekly_RadioButton.UseVisualStyleBackColor = true;
            this.weekly_RadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // monthly_RadioButton
            // 
            this.monthly_RadioButton.AutoSize = true;
            this.monthly_RadioButton.Location = new System.Drawing.Point(3, 49);
            this.monthly_RadioButton.Name = "monthly_RadioButton";
            this.monthly_RadioButton.Size = new System.Drawing.Size(62, 17);
            this.monthly_RadioButton.TabIndex = 10;
            this.monthly_RadioButton.TabStop = true;
            this.monthly_RadioButton.Text = "Monthly";
            this.monthly_RadioButton.UseVisualStyleBackColor = true;
            this.monthly_RadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // yearly_RadioButton
            // 
            this.yearly_RadioButton.AutoSize = true;
            this.yearly_RadioButton.Location = new System.Drawing.Point(3, 72);
            this.yearly_RadioButton.Name = "yearly_RadioButton";
            this.yearly_RadioButton.Size = new System.Drawing.Size(54, 17);
            this.yearly_RadioButton.TabIndex = 11;
            this.yearly_RadioButton.TabStop = true;
            this.yearly_RadioButton.Text = "Yearly";
            this.yearly_RadioButton.UseVisualStyleBackColor = true;
            this.yearly_RadioButton.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.recuring_FlowLayoutPanel);
            this.panel3.Controls.Add(this.recurring_Label);
            this.panel3.Location = new System.Drawing.Point(353, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 188);
            this.panel3.TabIndex = 8;
            // 
            // recuring_FlowLayoutPanel
            // 
            this.recuring_FlowLayoutPanel.AutoScroll = true;
            this.recuring_FlowLayoutPanel.Controls.Add(this.daily_Panel);
            this.recuring_FlowLayoutPanel.Controls.Add(this.weekly_Panel);
            this.recuring_FlowLayoutPanel.Controls.Add(this.monthly_Panel);
            this.recuring_FlowLayoutPanel.Controls.Add(this.yearly_Panel);
            this.recuring_FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recuring_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.recuring_FlowLayoutPanel.Location = new System.Drawing.Point(0, 20);
            this.recuring_FlowLayoutPanel.Name = "recuring_FlowLayoutPanel";
            this.recuring_FlowLayoutPanel.Size = new System.Drawing.Size(220, 168);
            this.recuring_FlowLayoutPanel.TabIndex = 10;
            this.recuring_FlowLayoutPanel.WrapContents = false;
            // 
            // daily_Panel
            // 
            this.daily_Panel.AutoSize = true;
            this.daily_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.daily_Panel.Controls.Add(this.panel5);
            this.daily_Panel.Controls.Add(this.everyNthCheckBox);
            this.daily_Panel.Controls.Add(label3);
            this.daily_Panel.Controls.Add(this.everyFollowingNthNumericUpDown);
            this.daily_Panel.Controls.Add(everyFollowingNthLabel);
            this.daily_Panel.Location = new System.Drawing.Point(3, 3);
            this.daily_Panel.Name = "daily_Panel";
            this.daily_Panel.Size = new System.Drawing.Size(214, 59);
            this.daily_Panel.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Location = new System.Drawing.Point(30, 29);
            this.panel5.Margin = new System.Windows.Forms.Padding(30, 6, 30, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(154, 3);
            this.panel5.TabIndex = 4;
            // 
            // everyNthCheckBox
            // 
            this.everyNthCheckBox.AutoSize = true;
            this.everyNthCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.recurBindingSource, "Every", true));
            this.everyNthCheckBox.Location = new System.Drawing.Point(3, 3);
            this.everyNthCheckBox.Name = "everyNthCheckBox";
            this.everyNthCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.everyNthCheckBox.Size = new System.Drawing.Size(49, 17);
            this.everyNthCheckBox.TabIndex = 1;
            this.everyNthCheckBox.Text = "Daily";
            this.everyNthCheckBox.UseVisualStyleBackColor = true;
            this.everyNthCheckBox.CheckedChanged += new System.EventHandler(this.EveryNthCheckBox_CheckedChanged);
            // 
            // everyFollowingNthNumericUpDown
            // 
            this.everyFollowingNthNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.recurBindingSource, "EveryFollowingNth", true));
            this.everyFollowingNthNumericUpDown.Location = new System.Drawing.Point(43, 36);
            this.everyFollowingNthNumericUpDown.Name = "everyFollowingNthNumericUpDown";
            this.everyFollowingNthNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.everyFollowingNthNumericUpDown.TabIndex = 2;
            this.everyFollowingNthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // weekly_Panel
            // 
            this.weekly_Panel.AutoSize = true;
            this.weekly_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.weekly_Panel.Controls.Add(this.panel6);
            this.weekly_Panel.Controls.Add(this.everyNthCheckBox3);
            this.weekly_Panel.Controls.Add(label4);
            this.weekly_Panel.Controls.Add(this.everyFollowingNthNumericUpDown2);
            this.weekly_Panel.Controls.Add(label5);
            this.weekly_Panel.Location = new System.Drawing.Point(3, 68);
            this.weekly_Panel.Name = "weekly_Panel";
            this.weekly_Panel.Size = new System.Drawing.Size(214, 59);
            this.weekly_Panel.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel6.Location = new System.Drawing.Point(30, 29);
            this.panel6.Margin = new System.Windows.Forms.Padding(30, 6, 30, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(154, 3);
            this.panel6.TabIndex = 6;
            // 
            // everyNthCheckBox3
            // 
            this.everyNthCheckBox3.AutoSize = true;
            this.everyNthCheckBox3.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.recurBindingSource, "Every", true));
            this.everyNthCheckBox3.Location = new System.Drawing.Point(3, 3);
            this.everyNthCheckBox3.Name = "everyNthCheckBox3";
            this.everyNthCheckBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.everyNthCheckBox3.Size = new System.Drawing.Size(62, 17);
            this.everyNthCheckBox3.TabIndex = 1;
            this.everyNthCheckBox3.Text = "Weekly";
            this.everyNthCheckBox3.UseVisualStyleBackColor = true;
            this.everyNthCheckBox3.CheckedChanged += new System.EventHandler(this.EveryNthCheckBox_CheckedChanged);
            // 
            // everyFollowingNthNumericUpDown2
            // 
            this.everyFollowingNthNumericUpDown2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.recurBindingSource, "EveryFollowingNth", true));
            this.everyFollowingNthNumericUpDown2.Location = new System.Drawing.Point(43, 36);
            this.everyFollowingNthNumericUpDown2.Name = "everyFollowingNthNumericUpDown2";
            this.everyFollowingNthNumericUpDown2.Size = new System.Drawing.Size(42, 20);
            this.everyFollowingNthNumericUpDown2.TabIndex = 2;
            this.everyFollowingNthNumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // monthly_Panel
            // 
            this.monthly_Panel.AutoSize = true;
            this.monthly_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.monthly_Panel.Controls.Add(this.panel9);
            this.monthly_Panel.Controls.Add(this.everyNthCheckBox1);
            this.monthly_Panel.Controls.Add(label8);
            this.monthly_Panel.Controls.Add(this.everyFollowingNthNumericUpDown1);
            this.monthly_Panel.Controls.Add(label9);
            this.monthly_Panel.Location = new System.Drawing.Point(3, 133);
            this.monthly_Panel.Name = "monthly_Panel";
            this.monthly_Panel.Size = new System.Drawing.Size(214, 59);
            this.monthly_Panel.TabIndex = 15;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel9.Location = new System.Drawing.Point(30, 29);
            this.panel9.Margin = new System.Windows.Forms.Padding(30, 6, 30, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(154, 3);
            this.panel9.TabIndex = 9;
            // 
            // everyNthCheckBox1
            // 
            this.everyNthCheckBox1.AutoSize = true;
            this.everyNthCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.recurBindingSource, "Every", true));
            this.everyNthCheckBox1.Location = new System.Drawing.Point(3, 3);
            this.everyNthCheckBox1.Name = "everyNthCheckBox1";
            this.everyNthCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.everyNthCheckBox1.Size = new System.Drawing.Size(63, 17);
            this.everyNthCheckBox1.TabIndex = 1;
            this.everyNthCheckBox1.Text = "Monthly";
            this.everyNthCheckBox1.UseVisualStyleBackColor = true;
            this.everyNthCheckBox1.CheckedChanged += new System.EventHandler(this.EveryNthCheckBox_CheckedChanged);
            // 
            // everyFollowingNthNumericUpDown1
            // 
            this.everyFollowingNthNumericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.recurBindingSource, "EveryFollowingNth", true));
            this.everyFollowingNthNumericUpDown1.Location = new System.Drawing.Point(43, 36);
            this.everyFollowingNthNumericUpDown1.Name = "everyFollowingNthNumericUpDown1";
            this.everyFollowingNthNumericUpDown1.Size = new System.Drawing.Size(42, 20);
            this.everyFollowingNthNumericUpDown1.TabIndex = 2;
            this.everyFollowingNthNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yearly_Panel
            // 
            this.yearly_Panel.AutoSize = true;
            this.yearly_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.yearly_Panel.Controls.Add(this.panel8);
            this.yearly_Panel.Controls.Add(this.everyNthCheckBox2);
            this.yearly_Panel.Controls.Add(label6);
            this.yearly_Panel.Controls.Add(this.everyFollowingNthNumericUpDown3);
            this.yearly_Panel.Controls.Add(label7);
            this.yearly_Panel.Location = new System.Drawing.Point(3, 198);
            this.yearly_Panel.Name = "yearly_Panel";
            this.yearly_Panel.Size = new System.Drawing.Size(214, 59);
            this.yearly_Panel.TabIndex = 16;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel8.Location = new System.Drawing.Point(30, 29);
            this.panel8.Margin = new System.Windows.Forms.Padding(30, 6, 30, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(154, 3);
            this.panel8.TabIndex = 9;
            // 
            // everyNthCheckBox2
            // 
            this.everyNthCheckBox2.AutoSize = true;
            this.everyNthCheckBox2.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.recurBindingSource, "Every", true));
            this.everyNthCheckBox2.Location = new System.Drawing.Point(3, 3);
            this.everyNthCheckBox2.Name = "everyNthCheckBox2";
            this.everyNthCheckBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.everyNthCheckBox2.Size = new System.Drawing.Size(55, 17);
            this.everyNthCheckBox2.TabIndex = 1;
            this.everyNthCheckBox2.Text = "Yearly";
            this.everyNthCheckBox2.UseVisualStyleBackColor = true;
            this.everyNthCheckBox2.CheckedChanged += new System.EventHandler(this.EveryNthCheckBox_CheckedChanged);
            // 
            // everyFollowingNthNumericUpDown3
            // 
            this.everyFollowingNthNumericUpDown3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.recurBindingSource, "EveryFollowingNth", true));
            this.everyFollowingNthNumericUpDown3.Location = new System.Drawing.Point(46, 36);
            this.everyFollowingNthNumericUpDown3.Name = "everyFollowingNthNumericUpDown3";
            this.everyFollowingNthNumericUpDown3.Size = new System.Drawing.Size(42, 20);
            this.everyFollowingNthNumericUpDown3.TabIndex = 2;
            this.everyFollowingNthNumericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.startDateTime_Label);
            this.panel1.Controls.Add(this.startDateTimeMonthCalendar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 188);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ok_button);
            this.panel4.Location = new System.Drawing.Point(11, 236);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(579, 50);
            this.panel4.TabIndex = 7;
            // 
            // ok_button
            // 
            this.ok_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ok_button.Location = new System.Drawing.Point(237, 14);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 0;
            this.ok_button.Text = "Ok";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // footer1
            // 
            this.footer1.AutoSize = true;
            this.footer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.footer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 302);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(600, 56);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.AutoSize = true;
            this.header1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.header1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(600, 33);
            this.header1.TabIndex = 0;
            // 
            // Recur_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 358);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Recur_Editor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recur";
            this.Load += new System.EventHandler(this.Recur_Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recurBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.type_FlowLayoutPanel.ResumeLayout(false);
            this.type_FlowLayoutPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.recuring_FlowLayoutPanel.ResumeLayout(false);
            this.recuring_FlowLayoutPanel.PerformLayout();
            this.daily_Panel.ResumeLayout(false);
            this.daily_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown)).EndInit();
            this.weekly_Panel.ResumeLayout(false);
            this.weekly_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown2)).EndInit();
            this.monthly_Panel.ResumeLayout(false);
            this.monthly_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown1)).EndInit();
            this.yearly_Panel.ResumeLayout(false);
            this.yearly_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.everyFollowingNthNumericUpDown3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar startDateTimeMonthCalendar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel type_FlowLayoutPanel;
        private System.Windows.Forms.RadioButton daily_RadioButton;
        private System.Windows.Forms.RadioButton weekly_RadioButton;
        private System.Windows.Forms.RadioButton monthly_RadioButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.FlowLayoutPanel recuring_FlowLayoutPanel;
        private UserInterface.UserControls.Header header1;
        private UserInterface.UserControls.Footer footer1;
        private System.Windows.Forms.RadioButton yearly_RadioButton;
        private System.Windows.Forms.CheckBox everyNthCheckBox;
        private System.Windows.Forms.BindingSource recurBindingSource;
        private System.Windows.Forms.CheckBox everyNthCheckBox3;
        private System.Windows.Forms.CheckBox everyNthCheckBox1;
        private System.Windows.Forms.CheckBox everyNthCheckBox2;
        private System.Windows.Forms.NumericUpDown everyFollowingNthNumericUpDown;
        private System.Windows.Forms.NumericUpDown everyFollowingNthNumericUpDown2;
        private System.Windows.Forms.NumericUpDown everyFollowingNthNumericUpDown1;
        private System.Windows.Forms.NumericUpDown everyFollowingNthNumericUpDown3;
        private System.Windows.Forms.Panel daily_Panel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel weekly_Panel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel monthly_Panel;
        private System.Windows.Forms.Panel yearly_Panel;
        private System.Windows.Forms.Label startDateTime_Label;
        private System.Windows.Forms.Label type_Label;
        private System.Windows.Forms.Label recurring_Label;
    }
}