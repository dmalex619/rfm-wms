namespace WMSSuitable
{
	partial class frmOutputsLoaders
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnGridSave = new RFMBaseClasses.RFMButton();
			this.btnGridUndo = new RFMBaseClasses.RFMButton();
			this.btnDelete = new RFMBaseClasses.RFMButton();
			this.btnEdit = new RFMBaseClasses.RFMButton();
			this.btnAdd = new RFMBaseClasses.RFMButton();
			this.bsCellsContents = new RFMBaseClasses.RFMBindingSource();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.numCoefficientLoad = new RFMBaseClasses.RFMNumericUpDown();
			this.pnlDataChange = new RFMBaseClasses.RFMPanel();
			this.chkOutlayOnly = new RFMBaseClasses.RFMCheckBox();
			this.cboBrigade = new RFMBaseClasses.RFMComboBox();
			this.txtTabNumber = new RFMBaseClasses.RFMTextBox();
			this.btnStoreZoneClear = new RFMBaseClasses.RFMButton();
			this.cboStoreZone = new RFMBaseClasses.RFMComboBox();
			this.lblStoreZone = new RFMBaseClasses.RFMLabel();
			this.cboUser = new RFMBaseClasses.RFMComboBox();
			this.lblUser = new RFMBaseClasses.RFMLabel();
			this.grdData = new RFMBaseClasses.RFMDataGridView();
			this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcUserName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBrigadeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.CoefficientLoad = new RFMBaseClasses.RFMLabel();
			this.pnlSelectConditions = new RFMBaseClasses.RFMPanel();
			this.txtOutputTypeName = new RFMBaseClasses.RFMTextBox();
			this.txtCellAdress = new RFMBaseClasses.RFMTextBox();
			this.txtGoodStateName = new RFMBaseClasses.RFMTextBox();
			this.txtPartnerName = new RFMBaseClasses.RFMTextBox();
			this.txtOwnerName = new RFMBaseClasses.RFMTextBox();
			this.txtErpCode = new RFMBaseClasses.RFMTextBox();
			this.txtOutputBarCode = new RFMBaseClasses.RFMTextBox();
			this.txtDateOutput = new RFMBaseClasses.RFMTextBox();
			this.lblCellAddress = new RFMBaseClasses.RFMLabel();
			this.lblGoodStateName = new RFMBaseClasses.RFMLabel();
			this.lblPartnerName = new RFMBaseClasses.RFMLabel();
			this.lblOwnerName = new RFMBaseClasses.RFMLabel();
			this.lblOutputTypeName = new RFMBaseClasses.RFMLabel();
			this.lblOutputBarCode = new RFMBaseClasses.RFMLabel();
			this.lblDateOutput = new RFMBaseClasses.RFMLabel();
			this.lblOutputID = new RFMBaseClasses.RFMLabel();
			this.txtID = new RFMBaseClasses.RFMTextBox();
			this.numPalletsFactQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.lblPalletsFactQnt = new RFMBaseClasses.RFMLabel();
			this.txtValidateTabNumber = new RFMBaseClasses.RFMTextBox();
			this.cboValidateUser = new RFMBaseClasses.RFMComboBox();
			this.lblValidateUser = new RFMBaseClasses.RFMLabel();
			this.btnValidateUserClear = new RFMBaseClasses.RFMButton();
			((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).BeginInit();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCoefficientLoad)).BeginInit();
			this.pnlDataChange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.pnlSelectConditions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPalletsFactQnt)).BeginInit();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 388);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(535, 388);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(495, 388);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnGridSave
			// 
			this.btnGridSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnGridSave.Location = new System.Drawing.Point(531, 261);
			this.btnGridSave.Name = "btnGridSave";
			this.btnGridSave.Size = new System.Drawing.Size(30, 30);
			this.btnGridSave.TabIndex = 8;
			this.btnGridSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridSave, "Сохранить временные изменения");
			this.btnGridSave.UseVisualStyleBackColor = true;
			this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
			// 
			// btnGridUndo
			// 
			this.btnGridUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridUndo.Image = global::WMSSuitable.Properties.Resources.UnDo;
			this.btnGridUndo.Location = new System.Drawing.Point(491, 261);
			this.btnGridUndo.Name = "btnGridUndo";
			this.btnGridUndo.Size = new System.Drawing.Size(30, 30);
			this.btnGridUndo.TabIndex = 7;
			this.btnGridUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridUndo, "Отказаться от изменений");
			this.btnGridUndo.UseVisualStyleBackColor = true;
			this.btnGridUndo.Click += new System.EventHandler(this.btnGridUndo_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
			this.btnDelete.Location = new System.Drawing.Point(531, 224);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 30);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnDelete, "Удалить");
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(491, 224);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 5;
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnEdit, "Изменить");
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
			this.btnAdd.Location = new System.Drawing.Point(451, 224);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(30, 30);
			this.btnAdd.TabIndex = 4;
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnAdd, "Добавить");
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.btnValidateUserClear);
			this.pnlData.Controls.Add(this.txtValidateTabNumber);
			this.pnlData.Controls.Add(this.cboValidateUser);
			this.pnlData.Controls.Add(this.lblValidateUser);
			this.pnlData.Controls.Add(this.numPalletsFactQnt);
			this.pnlData.Controls.Add(this.lblPalletsFactQnt);
			this.pnlData.Controls.Add(this.numCoefficientLoad);
			this.pnlData.Controls.Add(this.btnGridSave);
			this.pnlData.Controls.Add(this.btnGridUndo);
			this.pnlData.Controls.Add(this.pnlDataChange);
			this.pnlData.Controls.Add(this.btnDelete);
			this.pnlData.Controls.Add(this.btnEdit);
			this.pnlData.Controls.Add(this.btnAdd);
			this.pnlData.Controls.Add(this.grdData);
			this.pnlData.Controls.Add(this.CoefficientLoad);
			this.pnlData.Location = new System.Drawing.Point(2, 83);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(568, 298);
			this.pnlData.TabIndex = 4;
			// 
			// numCoefficientLoad
			// 
			this.numCoefficientLoad.DecimalPlaces = 1;
			this.numCoefficientLoad.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numCoefficientLoad.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numCoefficientLoad.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.numCoefficientLoad.IsNull = false;
			this.numCoefficientLoad.Location = new System.Drawing.Point(212, 4);
			this.numCoefficientLoad.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numCoefficientLoad.Name = "numCoefficientLoad";
			this.numCoefficientLoad.Size = new System.Drawing.Size(50, 22);
			this.numCoefficientLoad.TabIndex = 2;
			this.numCoefficientLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// pnlDataChange
			// 
			this.pnlDataChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlDataChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDataChange.Controls.Add(this.chkOutlayOnly);
			this.pnlDataChange.Controls.Add(this.cboBrigade);
			this.pnlDataChange.Controls.Add(this.txtTabNumber);
			this.pnlDataChange.Controls.Add(this.btnStoreZoneClear);
			this.pnlDataChange.Controls.Add(this.cboStoreZone);
			this.pnlDataChange.Controls.Add(this.lblStoreZone);
			this.pnlDataChange.Controls.Add(this.cboUser);
			this.pnlDataChange.Controls.Add(this.lblUser);
			this.pnlDataChange.Location = new System.Drawing.Point(3, 224);
			this.pnlDataChange.Name = "pnlDataChange";
			this.pnlDataChange.Size = new System.Drawing.Size(441, 67);
			this.pnlDataChange.TabIndex = 3;
			// 
			// chkOutlayOnly
			// 
			this.chkOutlayOnly.AutoSize = true;
			this.chkOutlayOnly.Checked = true;
			this.chkOutlayOnly.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOutlayOnly.Location = new System.Drawing.Point(302, 7);
			this.chkOutlayOnly.Name = "chkOutlayOnly";
			this.chkOutlayOnly.Size = new System.Drawing.Size(130, 18);
			this.chkOutlayOnly.TabIndex = 8;
			this.chkOutlayOnly.Text = "только из расхода";
			this.chkOutlayOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkOutlayOnly.UseVisualStyleBackColor = true;
			this.chkOutlayOnly.CheckedChanged += new System.EventHandler(this.chkOutlayOnly_CheckedChanged);
			// 
			// cboBrigade
			// 
			this.cboBrigade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboBrigade.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboBrigade.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboBrigade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBrigade.Enabled = false;
			this.cboBrigade.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboBrigade.Location = new System.Drawing.Point(302, 37);
			this.cboBrigade.Name = "cboBrigade";
			this.cboBrigade.Size = new System.Drawing.Size(132, 22);
			this.cboBrigade.TabIndex = 7;
			// 
			// txtTabNumber
			// 
			this.txtTabNumber.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtTabNumber.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTabNumber.Location = new System.Drawing.Point(72, 37);
			this.txtTabNumber.MaxLength = 3;
			this.txtTabNumber.Name = "txtTabNumber";
			this.txtTabNumber.Size = new System.Drawing.Size(36, 22);
			this.txtTabNumber.TabIndex = 5;
			this.ttToolTip.SetToolTip(this.txtTabNumber, "Табельный номер сотрудника (3 знака)");
			this.txtTabNumber.TextChanged += new System.EventHandler(this.txtTabNumber_TextChanged);
			// 
			// btnStoreZoneClear
			// 
			this.btnStoreZoneClear.FlatAppearance.BorderSize = 0;
			this.btnStoreZoneClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStoreZoneClear.Image = global::WMSSuitable.Properties.Resources.Paint;
			this.btnStoreZoneClear.Location = new System.Drawing.Point(79, 4);
			this.btnStoreZoneClear.Name = "btnStoreZoneClear";
			this.btnStoreZoneClear.Size = new System.Drawing.Size(25, 25);
			this.btnStoreZoneClear.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.btnStoreZoneClear, "Для всех зон");
			this.btnStoreZoneClear.UseVisualStyleBackColor = true;
			this.btnStoreZoneClear.Click += new System.EventHandler(this.btnStoreZoneClear_Click);
			// 
			// cboStoreZone
			// 
			this.cboStoreZone.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoreZone.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoreZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoreZone.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoreZone.Location = new System.Drawing.Point(111, 6);
			this.cboStoreZone.Name = "cboStoreZone";
			this.cboStoreZone.Size = new System.Drawing.Size(188, 22);
			this.cboStoreZone.TabIndex = 3;
			// 
			// lblStoreZone
			// 
			this.lblStoreZone.AutoSize = true;
			this.lblStoreZone.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoreZone.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoreZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoreZone.Location = new System.Drawing.Point(3, 9);
			this.lblStoreZone.Name = "lblStoreZone";
			this.lblStoreZone.Size = new System.Drawing.Size(33, 14);
			this.lblStoreZone.TabIndex = 1;
			this.lblStoreZone.Text = "Зона";
			// 
			// cboUser
			// 
			this.cboUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboUser.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboUser.Location = new System.Drawing.Point(111, 37);
			this.cboUser.Name = "cboUser";
			this.cboUser.Size = new System.Drawing.Size(188, 22);
			this.cboUser.TabIndex = 6;
			this.cboUser.SelectedIndexChanged += new System.EventHandler(this.cboUser_SelectedIndexChanged);
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblUser.Location = new System.Drawing.Point(3, 41);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(67, 14);
			this.lblUser.TabIndex = 4;
			this.lblUser.Text = "Сотрудник";
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
			this.grdData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcStoreZoneName,
            this.grcUserName,
            this.grcBrigadeName,
            this.grcID});
			this.grdData.IsConfigInclude = true;
			this.grdData.IsMarkedAll = false;
			this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdData.Location = new System.Drawing.Point(3, 55);
			this.grdData.MultiSelect = false;
			this.grdData.Name = "grdData";
			this.grdData.RangedWay = ' ';
			this.grdData.ReadOnly = true;
			this.grdData.RowHeadersWidth = 24;
			this.grdData.Size = new System.Drawing.Size(558, 164);
			this.grdData.TabIndex = 0;
			this.grdData.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_RowEnter);
			// 
			// grcStoreZoneName
			// 
			this.grcStoreZoneName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneName.DataPropertyName = "StoreZoneName";
			this.grcStoreZoneName.HeaderText = "Зона";
			this.grcStoreZoneName.Name = "grcStoreZoneName";
			this.grcStoreZoneName.ReadOnly = true;
			this.grcStoreZoneName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcStoreZoneName.Width = 120;
			// 
			// grcUserName
			// 
			this.grcUserName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcUserName.DataPropertyName = "UserName";
			this.grcUserName.HeaderText = "Сотрудник";
			this.grcUserName.Name = "grcUserName";
			this.grcUserName.ReadOnly = true;
			this.grcUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcUserName.Width = 120;
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
			// grcID
			// 
			this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcID.DataPropertyName = "ID";
			this.grcID.HeaderText = "ID";
			this.grcID.Name = "grcID";
			this.grcID.ReadOnly = true;
			this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcID.Visible = false;
			this.grcID.Width = 40;
			// 
			// CoefficientLoad
			// 
			this.CoefficientLoad.AutoSize = true;
			this.CoefficientLoad.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.CoefficientLoad.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.CoefficientLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CoefficientLoad.Location = new System.Drawing.Point(2, 8);
			this.CoefficientLoad.Name = "CoefficientLoad";
			this.CoefficientLoad.Size = new System.Drawing.Size(206, 14);
			this.CoefficientLoad.TabIndex = 1;
			this.CoefficientLoad.Text = "Коэффициент сложности загрузки";
			// 
			// pnlSelectConditions
			// 
			this.pnlSelectConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSelectConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSelectConditions.Controls.Add(this.txtOutputTypeName);
			this.pnlSelectConditions.Controls.Add(this.txtCellAdress);
			this.pnlSelectConditions.Controls.Add(this.txtGoodStateName);
			this.pnlSelectConditions.Controls.Add(this.txtPartnerName);
			this.pnlSelectConditions.Controls.Add(this.txtOwnerName);
			this.pnlSelectConditions.Controls.Add(this.txtErpCode);
			this.pnlSelectConditions.Controls.Add(this.txtOutputBarCode);
			this.pnlSelectConditions.Controls.Add(this.txtDateOutput);
			this.pnlSelectConditions.Controls.Add(this.lblCellAddress);
			this.pnlSelectConditions.Controls.Add(this.lblGoodStateName);
			this.pnlSelectConditions.Controls.Add(this.lblPartnerName);
			this.pnlSelectConditions.Controls.Add(this.lblOwnerName);
			this.pnlSelectConditions.Controls.Add(this.lblOutputTypeName);
			this.pnlSelectConditions.Controls.Add(this.lblOutputBarCode);
			this.pnlSelectConditions.Controls.Add(this.lblDateOutput);
			this.pnlSelectConditions.Controls.Add(this.lblOutputID);
			this.pnlSelectConditions.Controls.Add(this.txtID);
			this.pnlSelectConditions.Location = new System.Drawing.Point(2, 3);
			this.pnlSelectConditions.Name = "pnlSelectConditions";
			this.pnlSelectConditions.Size = new System.Drawing.Size(568, 77);
			this.pnlSelectConditions.TabIndex = 0;
			// 
			// txtOutputTypeName
			// 
			this.txtOutputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOutputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOutputTypeName.Enabled = false;
			this.txtOutputTypeName.Location = new System.Drawing.Point(248, 49);
			this.txtOutputTypeName.Name = "txtOutputTypeName";
			this.txtOutputTypeName.Size = new System.Drawing.Size(130, 22);
			this.txtOutputTypeName.TabIndex = 14;
			// 
			// txtCellAdress
			// 
			this.txtCellAdress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellAdress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellAdress.Enabled = false;
			this.txtCellAdress.Location = new System.Drawing.Point(431, 49);
			this.txtCellAdress.Name = "txtCellAdress";
			this.txtCellAdress.Size = new System.Drawing.Size(130, 22);
			this.txtCellAdress.TabIndex = 16;
			// 
			// txtGoodStateName
			// 
			this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodStateName.Enabled = false;
			this.txtGoodStateName.Location = new System.Drawing.Point(76, 49);
			this.txtGoodStateName.Name = "txtGoodStateName";
			this.txtGoodStateName.Size = new System.Drawing.Size(130, 22);
			this.txtGoodStateName.TabIndex = 12;
			// 
			// txtPartnerName
			// 
			this.txtPartnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPartnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPartnerName.Enabled = false;
			this.txtPartnerName.Location = new System.Drawing.Point(289, 26);
			this.txtPartnerName.Name = "txtPartnerName";
			this.txtPartnerName.Size = new System.Drawing.Size(272, 22);
			this.txtPartnerName.TabIndex = 10;
			// 
			// txtOwnerName
			// 
			this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwnerName.Enabled = false;
			this.txtOwnerName.Location = new System.Drawing.Point(76, 26);
			this.txtOwnerName.Name = "txtOwnerName";
			this.txtOwnerName.Size = new System.Drawing.Size(130, 22);
			this.txtOwnerName.TabIndex = 8;
			// 
			// txtErpCode
			// 
			this.txtErpCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtErpCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtErpCode.Enabled = false;
			this.txtErpCode.Location = new System.Drawing.Point(76, 3);
			this.txtErpCode.Name = "txtErpCode";
			this.txtErpCode.Size = new System.Drawing.Size(130, 22);
			this.txtErpCode.TabIndex = 2;
			// 
			// txtOutputBarCode
			// 
			this.txtOutputBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOutputBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOutputBarCode.Enabled = false;
			this.txtOutputBarCode.Location = new System.Drawing.Point(431, 3);
			this.txtOutputBarCode.Name = "txtOutputBarCode";
			this.txtOutputBarCode.Size = new System.Drawing.Size(130, 22);
			this.txtOutputBarCode.TabIndex = 6;
			// 
			// txtDateOutput
			// 
			this.txtDateOutput.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtDateOutput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDateOutput.Enabled = false;
			this.txtDateOutput.Location = new System.Drawing.Point(248, 3);
			this.txtDateOutput.Name = "txtDateOutput";
			this.txtDateOutput.Size = new System.Drawing.Size(90, 22);
			this.txtDateOutput.TabIndex = 4;
			// 
			// lblCellAddress
			// 
			this.lblCellAddress.AutoSize = true;
			this.lblCellAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellAddress.Location = new System.Drawing.Point(382, 53);
			this.lblCellAddress.Name = "lblCellAddress";
			this.lblCellAddress.Size = new System.Drawing.Size(47, 14);
			this.lblCellAddress.TabIndex = 15;
			this.lblCellAddress.Text = "Ячейка";
			// 
			// lblGoodStateName
			// 
			this.lblGoodStateName.AutoSize = true;
			this.lblGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodStateName.Location = new System.Drawing.Point(2, 53);
			this.lblGoodStateName.Name = "lblGoodStateName";
			this.lblGoodStateName.Size = new System.Drawing.Size(68, 14);
			this.lblGoodStateName.TabIndex = 11;
			this.lblGoodStateName.Text = "Состояние";
			// 
			// lblPartnerName
			// 
			this.lblPartnerName.AutoSize = true;
			this.lblPartnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPartnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPartnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPartnerName.Location = new System.Drawing.Point(213, 29);
			this.lblPartnerName.Name = "lblPartnerName";
			this.lblPartnerName.Size = new System.Drawing.Size(74, 14);
			this.lblPartnerName.TabIndex = 9;
			this.lblPartnerName.Text = "Получатель";
			// 
			// lblOwnerName
			// 
			this.lblOwnerName.AutoSize = true;
			this.lblOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwnerName.Location = new System.Drawing.Point(2, 29);
			this.lblOwnerName.Name = "lblOwnerName";
			this.lblOwnerName.Size = new System.Drawing.Size(62, 14);
			this.lblOwnerName.TabIndex = 7;
			this.lblOwnerName.Text = "Владелец";
			// 
			// lblOutputTypeName
			// 
			this.lblOutputTypeName.AutoSize = true;
			this.lblOutputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOutputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOutputTypeName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOutputTypeName.Location = new System.Drawing.Point(213, 53);
			this.lblOutputTypeName.Name = "lblOutputTypeName";
			this.lblOutputTypeName.Size = new System.Drawing.Size(29, 14);
			this.lblOutputTypeName.TabIndex = 13;
			this.lblOutputTypeName.Text = "Тип";
			// 
			// lblOutputBarCode
			// 
			this.lblOutputBarCode.AutoSize = true;
			this.lblOutputBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOutputBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOutputBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOutputBarCode.Location = new System.Drawing.Point(356, 6);
			this.lblOutputBarCode.Name = "lblOutputBarCode";
			this.lblOutputBarCode.Size = new System.Drawing.Size(73, 14);
			this.lblOutputBarCode.TabIndex = 5;
			this.lblOutputBarCode.Text = "ШК расхода";
			// 
			// lblDateOutput
			// 
			this.lblDateOutput.AutoSize = true;
			this.lblDateOutput.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateOutput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateOutput.Location = new System.Drawing.Point(213, 6);
			this.lblDateOutput.Name = "lblDateOutput";
			this.lblDateOutput.Size = new System.Drawing.Size(33, 14);
			this.lblDateOutput.TabIndex = 3;
			this.lblDateOutput.Text = "Дата";
			// 
			// lblOutputID
			// 
			this.lblOutputID.AutoSize = true;
			this.lblOutputID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOutputID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOutputID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOutputID.Location = new System.Drawing.Point(2, 6);
			this.lblOutputID.Name = "lblOutputID";
			this.lblOutputID.Size = new System.Drawing.Size(28, 14);
			this.lblOutputID.TabIndex = 0;
			this.lblOutputID.Text = "Код";
			// 
			// txtID
			// 
			this.txtID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtID.Enabled = false;
			this.txtID.Location = new System.Drawing.Point(30, 3);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(45, 22);
			this.txtID.TabIndex = 1;
			// 
			// numPalletsFactQnt
			// 
			this.numPalletsFactQnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numPalletsFactQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numPalletsFactQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numPalletsFactQnt.IsNull = false;
			this.numPalletsFactQnt.Location = new System.Drawing.Point(510, 4);
			this.numPalletsFactQnt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.numPalletsFactQnt.Name = "numPalletsFactQnt";
			this.numPalletsFactQnt.Size = new System.Drawing.Size(50, 22);
			this.numPalletsFactQnt.TabIndex = 10;
			this.numPalletsFactQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPalletsFactQnt
			// 
			this.lblPalletsFactQnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPalletsFactQnt.AutoSize = true;
			this.lblPalletsFactQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPalletsFactQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPalletsFactQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletsFactQnt.Location = new System.Drawing.Point(377, 8);
			this.lblPalletsFactQnt.Name = "lblPalletsFactQnt";
			this.lblPalletsFactQnt.Size = new System.Drawing.Size(130, 14);
			this.lblPalletsFactQnt.TabIndex = 9;
			this.lblPalletsFactQnt.Text = "Отгружено поддонов";
			// 
			// txtValidateTabNumber
			// 
			this.txtValidateTabNumber.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtValidateTabNumber.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtValidateTabNumber.Location = new System.Drawing.Point(212, 29);
			this.txtValidateTabNumber.MaxLength = 3;
			this.txtValidateTabNumber.Name = "txtValidateTabNumber";
			this.txtValidateTabNumber.Size = new System.Drawing.Size(36, 22);
			this.txtValidateTabNumber.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.txtValidateTabNumber, "Табельный номер сотрудника (3 знака)");
			this.txtValidateTabNumber.TextChanged += new System.EventHandler(this.txtValidateTabNumber_TextChanged);
			// 
			// cboValidateUser
			// 
			this.cboValidateUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboValidateUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboValidateUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboValidateUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboValidateUser.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboValidateUser.Location = new System.Drawing.Point(251, 29);
			this.cboValidateUser.Name = "cboValidateUser";
			this.cboValidateUser.Size = new System.Drawing.Size(187, 22);
			this.cboValidateUser.TabIndex = 13;
			// 
			// lblValidateUser
			// 
			this.lblValidateUser.AutoSize = true;
			this.lblValidateUser.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblValidateUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblValidateUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblValidateUser.Location = new System.Drawing.Point(2, 33);
			this.lblValidateUser.Name = "lblValidateUser";
			this.lblValidateUser.Size = new System.Drawing.Size(151, 14);
			this.lblValidateUser.TabIndex = 11;
			this.lblValidateUser.Text = "Проверяющий сотрудник";
			// 
			// btnValidateUserClear
			// 
			this.btnValidateUserClear.FlatAppearance.BorderSize = 0;
			this.btnValidateUserClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnValidateUserClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnValidateUserClear.Location = new System.Drawing.Point(438, 27);
			this.btnValidateUserClear.Name = "btnValidateUserClear";
			this.btnValidateUserClear.Size = new System.Drawing.Size(25, 25);
			this.btnValidateUserClear.TabIndex = 14;
			this.ttToolTip.SetToolTip(this.btnValidateUserClear, "Очистить данные о проверяющем сотруднике");
			this.btnValidateUserClear.UseVisualStyleBackColor = true;
			this.btnValidateUserClear.Click += new System.EventHandler(this.btnValidateUserClear_Click);
			// 
			// frmOutputsLoaders
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 423);
			this.Controls.Add(this.pnlSelectConditions);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "533");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmOutputsLoaders";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Сотрудники, выполнявшие загрузку машины";
			this.Load += new System.EventHandler(this.frmOutputsLoaders_Load);
			((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).EndInit();
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCoefficientLoad)).EndInit();
			this.pnlDataChange.ResumeLayout(false);
			this.pnlDataChange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.pnlSelectConditions.ResumeLayout(false);
			this.pnlSelectConditions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPalletsFactQnt)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMBindingSource bsCellsContents;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMButton btnGridSave;
		private RFMBaseClasses.RFMButton btnGridUndo;
		private RFMBaseClasses.RFMPanel pnlDataChange;
		private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMButton btnAdd;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMComboBox cboUser;
		private RFMBaseClasses.RFMLabel lblUser;
		private RFMBaseClasses.RFMButton btnStoreZoneClear;
		private RFMBaseClasses.RFMComboBox cboStoreZone;
		private RFMBaseClasses.RFMLabel lblStoreZone;
		private RFMBaseClasses.RFMPanel pnlSelectConditions;
		private RFMBaseClasses.RFMTextBox txtOutputTypeName;
		private RFMBaseClasses.RFMTextBox txtCellAdress;
		private RFMBaseClasses.RFMTextBox txtGoodStateName;
		private RFMBaseClasses.RFMTextBox txtPartnerName;
		private RFMBaseClasses.RFMTextBox txtOwnerName;
		private RFMBaseClasses.RFMTextBox txtErpCode;
		private RFMBaseClasses.RFMTextBox txtOutputBarCode;
		private RFMBaseClasses.RFMTextBox txtDateOutput;
		private RFMBaseClasses.RFMLabel lblCellAddress;
		private RFMBaseClasses.RFMLabel lblGoodStateName;
		private RFMBaseClasses.RFMLabel lblPartnerName;
		private RFMBaseClasses.RFMLabel lblOwnerName;
		private RFMBaseClasses.RFMLabel lblOutputTypeName;
		private RFMBaseClasses.RFMLabel lblOutputBarCode;
		private RFMBaseClasses.RFMLabel lblDateOutput;
		private RFMBaseClasses.RFMLabel lblOutputID;
		private RFMBaseClasses.RFMTextBox txtID;
		private RFMBaseClasses.RFMTextBox txtTabNumber;
		private RFMBaseClasses.RFMComboBox cboBrigade;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcUserName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBrigadeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;
		private RFMBaseClasses.RFMCheckBox chkOutlayOnly;
		private RFMBaseClasses.RFMLabel CoefficientLoad;
		private RFMBaseClasses.RFMNumericUpDown numCoefficientLoad;
		private RFMBaseClasses.RFMNumericUpDown numPalletsFactQnt;
		private RFMBaseClasses.RFMLabel lblPalletsFactQnt;
		private RFMBaseClasses.RFMTextBox txtValidateTabNumber;
		private RFMBaseClasses.RFMComboBox cboValidateUser;
		private RFMBaseClasses.RFMLabel lblValidateUser;
		private RFMBaseClasses.RFMButton btnValidateUserClear;
	}
}