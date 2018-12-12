namespace WMSSuitable 
{
	partial class frmSysLook 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysLook));
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnRefresh = new RFMBaseClasses.RFMButton();
            this.btnCopy = new RFMBaseClasses.RFMButton();
            this.btnAdd = new RFMBaseClasses.RFMButton();
            this.btnEdit = new RFMBaseClasses.RFMButton();
            this.btnDelete = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.grdTableData = new RFMBaseClasses.RFMDataGridView();
            this.cboTables = new RFMBaseClasses.RFMComboBox();
            this.lblTables = new RFMBaseClasses.RFMLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdTableData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(7, 439);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 8;
            this.ttToolTip.SetToolTip(this.btnHelp, "Помощь");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(426, 5);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnRefresh, "Обновить таблицу");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(555, 439);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(30, 30);
            this.btnCopy.TabIndex = 14;
            this.ttToolTip.SetToolTip(this.btnCopy, "Копировать запись");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(505, 439);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnAdd, "Добавить запись");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(605, 439);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 30);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = " ";
            this.ttToolTip.SetToolTip(this.btnEdit, "Редактировать запись");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(655, 439);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 30);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = " ";
            this.ttToolTip.SetToolTip(this.btnDelete, "Удалить запись");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(705, 439);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = " ";
            this.ttToolTip.SetToolTip(this.btnExit, "Выход");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grdTableData
            // 
            this.grdTableData.AllowUserToAddRows = false;
            this.grdTableData.AllowUserToDeleteRows = false;
            this.grdTableData.AllowUserToOrderColumns = true;
            this.grdTableData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTableData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdTableData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdTableData.IsConfigInclude = true;
            this.grdTableData.IsMarkedAll = false;
            this.grdTableData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdTableData.Location = new System.Drawing.Point(7, 41);
            this.grdTableData.MultiSelect = false;
            this.grdTableData.Name = "grdTableData";
            this.grdTableData.RangedWay = ' ';
            this.grdTableData.ReadOnly = true;
            this.grdTableData.RowHeadersWidth = 24;
            this.grdTableData.Size = new System.Drawing.Size(728, 388);
            this.grdTableData.TabIndex = 12;
            // 
            // cboTables
            // 
            this.cboTables.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboTables.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTables.FormattingEnabled = true;
            this.cboTables.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboTables.Location = new System.Drawing.Point(67, 9);
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size(350, 22);
            this.cboTables.TabIndex = 10;
            this.cboTables.SelectedIndexChanged += new System.EventHandler(this.cboTables_SelectedIndexChanged);
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblTables.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTables.Location = new System.Drawing.Point(6, 13);
            this.lblTables.Margin = new System.Windows.Forms.Padding(0);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(55, 14);
            this.lblTables.TabIndex = 9;
            this.lblTables.Text = "Таблица";
            // 
            // frmSysLook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 473);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grdTableData);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboTables);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.btnHelp);
            this.hpHelp.SetHelpKeyword(this, "2092");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "frmSysLook";
            this.hpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Таблицы";
            this.Load += new System.EventHandler(this.frmSysLook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTableData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RFMBaseClasses.RFMButton btnHelp;
		public RFMBaseClasses.RFMDataGridView grdTableData;
		internal RFMBaseClasses.RFMButton btnRefresh;
		internal RFMBaseClasses.RFMComboBox cboTables;
		internal RFMBaseClasses.RFMLabel lblTables;
		internal RFMBaseClasses.RFMButton btnCopy;
		internal RFMBaseClasses.RFMButton btnAdd;
		private RFMBaseClasses.RFMButton btnEdit;
		internal RFMBaseClasses.RFMButton btnDelete;
		internal RFMBaseClasses.RFMButton btnExit;

	}
}