namespace UserInterface.Transactions.UserControls
{
    partial class ItemListEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.productListBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.productListBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.productListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productList_DataGridView = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceInVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceExVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingNavigator)).BeginInit();
            this.productListBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productList_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // productListBindingNavigatorSaveItem
            // 
            this.productListBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productListBindingNavigatorSaveItem.Enabled = false;
            this.productListBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("productListBindingNavigatorSaveItem.Image")));
            this.productListBindingNavigatorSaveItem.Name = "productListBindingNavigatorSaveItem";
            this.productListBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.productListBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // productListBindingNavigator
            // 
            this.productListBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.productListBindingNavigator.BindingSource = this.productListBindingSource;
            this.productListBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.productListBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.productListBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.productListBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.productListBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.productListBindingNavigatorSaveItem});
            this.productListBindingNavigator.Location = new System.Drawing.Point(0, 205);
            this.productListBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.productListBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.productListBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.productListBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.productListBindingNavigator.Name = "productListBindingNavigator";
            this.productListBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.productListBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.productListBindingNavigator.Size = new System.Drawing.Size(914, 25);
            this.productListBindingNavigator.TabIndex = 0;
            this.productListBindingNavigator.Text = "bindingNavigator1";
            // 
            // productListBindingSource
            // 
            this.productListBindingSource.AllowNew = true;
            this.productListBindingSource.DataSource = typeof(Data.Products.Product);
            // 
            // productList_DataGridView
            // 
            this.productList_DataGridView.AutoGenerateColumns = false;
            this.productList_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.productList_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productList_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productList_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.ProductName,
            this.PriceInVat,
            this.PriceExVat,
            this.Discount,
            this.ItemTotal,
            this.SupplierID});
            this.productList_DataGridView.DataSource = this.productListBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productList_DataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.productList_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productList_DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.productList_DataGridView.Location = new System.Drawing.Point(0, 0);
            this.productList_DataGridView.Name = "productList_DataGridView";
            this.productList_DataGridView.RowHeadersWidth = 25;
            this.productList_DataGridView.Size = new System.Drawing.Size(914, 205);
            this.productList_DataGridView.TabIndex = 1;
            this.productList_DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellValueChanged);
            this.productList_DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.productListDataGridView_DataError);
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductName.DataPropertyName = "Name";
            this.ProductName.HeaderText = "Product";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 69;
            // 
            // PriceInVat
            // 
            this.PriceInVat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PriceInVat.DataPropertyName = "PriceInVat";
            this.PriceInVat.HeaderText = "PriceInVat";
            this.PriceInVat.Name = "PriceInVat";
            this.PriceInVat.Width = 81;
            // 
            // PriceExVat
            // 
            this.PriceExVat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PriceExVat.DataPropertyName = "PriceExVat";
            this.PriceExVat.HeaderText = "PriceExVat";
            this.PriceExVat.Name = "PriceExVat";
            this.PriceExVat.Width = 84;
            // 
            // Discount
            // 
            this.Discount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.Width = 74;
            // 
            // ItemTotal
            // 
            this.ItemTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemTotal.DataPropertyName = "ItemTotal";
            this.ItemTotal.HeaderText = "ItemTotal";
            this.ItemTotal.Name = "ItemTotal";
            this.ItemTotal.ReadOnly = true;
            this.ItemTotal.Width = 76;
            // 
            // SupplierID
            // 
            this.SupplierID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SupplierID.DataPropertyName = "SupplierID";
            this.SupplierID.HeaderText = "SupplierID";
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SupplierID.Width = 81;
            // 
            // ItemListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.productList_DataGridView);
            this.Controls.Add(this.productListBindingNavigator);
            this.Name = "ItemListEditor";
            this.Size = new System.Drawing.Size(914, 230);
            this.Load += new System.EventHandler(this.TransactionItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingNavigator)).EndInit();
            this.productListBindingNavigator.ResumeLayout(false);
            this.productListBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productList_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton productListBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingNavigator productListBindingNavigator;
        private System.Windows.Forms.DataGridView productList_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource productListBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceInVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceExVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemTotal;
        private System.Windows.Forms.DataGridViewComboBoxColumn SupplierID;
    }
}
