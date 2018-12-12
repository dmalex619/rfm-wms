namespace WMSSuitable
{
	partial class frmUsers 
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grdData = new RFMBaseClasses.RFMDataGridView();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.btnPrint = new RFMBaseClasses.RFMButton();
			this.btnEdit = new RFMBaseClasses.RFMButton();
			this.btnDelete = new RFMBaseClasses.RFMButton();
			this.btnAdd = new RFMBaseClasses.RFMButton();
			this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBrigadeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcLocPath = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcNetPath = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcHostName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcIsAdmin = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcPassword = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.SuspendLayout();
			// 
			// grdData
			// 
			this.grdData.AllowUserToAddRows = false;
			this.grdData.AllowUserToDeleteRows = false;
			this.grdData.AllowUserToOrderColumns = true;
			this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdData.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcID,
            this.grcName,
            this.grcBrigadeName,
            this.grcAlias,
            this.grcLocPath,
            this.grcNetPath,
            this.grcHostName,
            this.grcIsAdmin,
            this.grcActual,
            this.grcPassword,
            this.grcErpCode});
			this.grdData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grdData.IsCheckerInclude = true;
			this.grdData.IsConfigInclude = true;
			this.grdData.IsMarkedAll = false;
			this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdData.Location = new System.Drawing.Point(4, 5);
			this.grdData.MultiSelect = false;
			this.grdData.Name = "grdData";
			this.grdData.RangedWay = ' ';
			this.grdData.ReadOnly = true;
			this.grdData.RowHeadersWidth = 24;
			this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
			this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
			this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.grdData.Size = new System.Drawing.Size(632, 376);
			this.grdData.TabIndex = 1;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(5, 387);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(32, 30);
			this.btnHelp.TabIndex = 8;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnExit.Location = new System.Drawing.Point(605, 388);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 7;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
			this.btnPrint.Location = new System.Drawing.Point(555, 388);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(32, 30);
			this.btnPrint.TabIndex = 9;
			this.ttToolTip.SetToolTip(this.btnPrint, "Печать беджей");
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnEdit.IsAccessOn = true;
			this.btnEdit.Location = new System.Drawing.Point(455, 388);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 11;
			this.ttToolTip.SetToolTip(this.btnEdit, "Редактирование");
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
			this.btnDelete.IsAccessOn = true;
			this.btnDelete.Location = new System.Drawing.Point(505, 388);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 30);
			this.btnDelete.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.btnDelete, "Удаление");
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
			this.btnAdd.IsAccessOn = true;
			this.btnAdd.Location = new System.Drawing.Point(405, 388);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(30, 30);
			this.btnAdd.TabIndex = 10;
			this.ttToolTip.SetToolTip(this.btnAdd, "Добавление");
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// grcID
			// 
			this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcID.DataPropertyName = "ID";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.NullValue = null;
			this.grcID.DefaultCellStyle = dataGridViewCellStyle2;
			this.grcID.HeaderText = "ID";
			this.grcID.Name = "grcID";
			this.grcID.ReadOnly = true;
			this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcID.Width = 40;
			// 
			// grcName
			// 
			this.grcName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcName.DataPropertyName = "Name";
			this.grcName.HeaderText = "ФИО";
			this.grcName.Name = "grcName";
			this.grcName.ReadOnly = true;
			this.grcName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcName.Width = 200;
			// 
			// grcBrigadeName
			// 
			this.grcBrigadeName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBrigadeName.DataPropertyName = "BrigadeName";
			this.grcBrigadeName.HeaderText = "Бригада";
			this.grcBrigadeName.Name = "grcBrigadeName";
			this.grcBrigadeName.ReadOnly = true;
			this.grcBrigadeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcAlias
			// 
			this.grcAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcAlias.DataPropertyName = "Alias";
			this.grcAlias.HeaderText = "Сетевое имя";
			this.grcAlias.Name = "grcAlias";
			this.grcAlias.ReadOnly = true;
			this.grcAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcLocPath
			// 
			this.grcLocPath.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcLocPath.DataPropertyName = "LocPath";
			this.grcLocPath.HeaderText = "Локальный каталог";
			this.grcLocPath.Name = "grcLocPath";
			this.grcLocPath.ReadOnly = true;
			this.grcLocPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcLocPath.Width = 150;
			// 
			// grcNetPath
			// 
			this.grcNetPath.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcNetPath.DataPropertyName = "NetPath";
			this.grcNetPath.HeaderText = "Сетевой каталог";
			this.grcNetPath.Name = "grcNetPath";
			this.grcNetPath.ReadOnly = true;
			this.grcNetPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcNetPath.Width = 150;
			// 
			// grcHostName
			// 
			this.grcHostName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcHostName.DataPropertyName = "HostName";
			this.grcHostName.HeaderText = "Хост";
			this.grcHostName.Name = "grcHostName";
			this.grcHostName.ReadOnly = true;
			this.grcHostName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcIsAdmin
			// 
			this.grcIsAdmin.DataPropertyName = "IsAdmin";
			this.grcIsAdmin.HeaderText = "Адм.?";
			this.grcIsAdmin.Name = "grcIsAdmin";
			this.grcIsAdmin.ReadOnly = true;
			this.grcIsAdmin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcIsAdmin.ToolTipText = "Администратор?";
			this.grcIsAdmin.Width = 50;
			// 
			// grcActual
			// 
			this.grcActual.DataPropertyName = "Actual";
			this.grcActual.HeaderText = "Акт.?";
			this.grcActual.Name = "grcActual";
			this.grcActual.ReadOnly = true;
			this.grcActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcActual.ToolTipText = "Актуально?";
			this.grcActual.Width = 50;
			// 
			// grcPassword
			// 
			this.grcPassword.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPassword.DataPropertyName = "Password";
			this.grcPassword.HeaderText = "Пароль";
			this.grcPassword.Name = "grcPassword";
			this.grcPassword.ReadOnly = true;
			this.grcPassword.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcPassword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPassword.Width = 80;
			// 
			// grcErpCode
			// 
			this.grcErpCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcErpCode.DataPropertyName = "ERPCode";
			this.grcErpCode.HeaderText = "ERPCode";
			this.grcErpCode.Name = "grcErpCode";
			this.grcErpCode.ReadOnly = true;
			this.grcErpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// frmUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 423);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.grdData);
			this.hpHelp.SetHelpKeyword(this, "802");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsAccessOn = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUsers";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Пользователи";
			this.Load += new System.EventHandler(this.frmUsers_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMButton btnPrint;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnAdd;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBrigadeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcLocPath;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNetPath;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcHostName;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcIsAdmin;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcActual;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPassword;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcErpCode;
	}
}

