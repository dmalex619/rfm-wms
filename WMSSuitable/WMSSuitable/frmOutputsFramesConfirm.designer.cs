namespace WMSSuitable
{
	partial class frmOutputsFramesConfirm
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
			this.dgvOutputFramesShipment = new RFMBaseClasses.RFMDataGridView();
			this.cboHeavers = new RFMBaseClasses.RFMComboBox();
			this.btnSelect = new RFMBaseClasses.RFMButton();
			this.pnlSelectConditions = new RFMBaseClasses.RFMPanel();
			this.pnlH = new RFMBaseClasses.RFMPanel();
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
			this.chkUnConfirmed = new RFMBaseClasses.RFMCheckBox();
			this.lblHeavers = new RFMBaseClasses.RFMLabel();
			this.txtID = new RFMBaseClasses.RFMTextBox();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnUnCheckAll = new RFMBaseClasses.RFMButton();
			this.btnCheckAll = new RFMBaseClasses.RFMButton();
			this.dgrcCheck = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.dgrcFrameID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcFrameBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcCellSourceAdress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputFramesShipment)).BeginInit();
			this.pnlSelectConditions.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvOutputFramesShipment
			// 
			this.dgvOutputFramesShipment.AllowUserToAddRows = false;
			this.dgvOutputFramesShipment.AllowUserToDeleteRows = false;
			this.dgvOutputFramesShipment.AllowUserToOrderColumns = true;
			this.dgvOutputFramesShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvOutputFramesShipment.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvOutputFramesShipment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvOutputFramesShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOutputFramesShipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgrcCheck,
            this.dgrcFrameID,
            this.dgrcFrameBarCode,
            this.dgrcCellSourceAdress,
            this.dgrcID});
			this.dgvOutputFramesShipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvOutputFramesShipment.IsConfigInclude = true;
			this.dgvOutputFramesShipment.IsMarkedAll = false;
			this.dgvOutputFramesShipment.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvOutputFramesShipment.Location = new System.Drawing.Point(5, 134);
			this.dgvOutputFramesShipment.MultiSelect = false;
			this.dgvOutputFramesShipment.Name = "dgvOutputFramesShipment";
			this.dgvOutputFramesShipment.RangedWay = ' ';
			this.dgvOutputFramesShipment.ReadOnly = true;
			this.dgvOutputFramesShipment.RowHeadersWidth = 24;
			this.dgvOutputFramesShipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvOutputFramesShipment.Size = new System.Drawing.Size(552, 245);
			this.dgvOutputFramesShipment.TabIndex = 1;
			this.dgvOutputFramesShipment.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvOutputFramesShipment_CellPainting);
			this.dgvOutputFramesShipment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOutputFramesShipment_CellFormatting);
			this.dgvOutputFramesShipment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutputFramesShipment_CellEndEdit);
			// 
			// cboHeavers
			// 
			this.cboHeavers.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboHeavers.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboHeavers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboHeavers.FormattingEnabled = true;
			this.cboHeavers.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboHeavers.Location = new System.Drawing.Point(42, 88);
			this.cboHeavers.Name = "cboHeavers";
			this.cboHeavers.Size = new System.Drawing.Size(168, 22);
			this.cboHeavers.TabIndex = 3;
			this.ttToolTip.SetToolTip(this.cboHeavers, "Оператор погрузочной техники");
			// 
			// btnSelect
			// 
			this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelect.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnSelect.Location = new System.Drawing.Point(511, 83);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(32, 30);
			this.btnSelect.TabIndex = 4;
			this.ttToolTip.SetToolTip(this.btnSelect, "Обновить список транспортировок");
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// pnlSelectConditions
			// 
			this.pnlSelectConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSelectConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSelectConditions.Controls.Add(this.pnlH);
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
			this.pnlSelectConditions.Controls.Add(this.chkUnConfirmed);
			this.pnlSelectConditions.Controls.Add(this.lblHeavers);
			this.pnlSelectConditions.Controls.Add(this.btnSelect);
			this.pnlSelectConditions.Controls.Add(this.cboHeavers);
			this.pnlSelectConditions.Controls.Add(this.txtID);
			this.pnlSelectConditions.Location = new System.Drawing.Point(5, 6);
			this.pnlSelectConditions.Name = "pnlSelectConditions";
			this.pnlSelectConditions.Size = new System.Drawing.Size(552, 122);
			this.pnlSelectConditions.TabIndex = 5;
			// 
			// pnlH
			// 
			this.pnlH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlH.Location = new System.Drawing.Point(4, 75);
			this.pnlH.Name = "pnlH";
			this.pnlH.Size = new System.Drawing.Size(540, 4);
			this.pnlH.TabIndex = 24;
			// 
			// txtOutputTypeName
			// 
			this.txtOutputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOutputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOutputTypeName.Enabled = false;
			this.txtOutputTypeName.Location = new System.Drawing.Point(248, 50);
			this.txtOutputTypeName.Name = "txtOutputTypeName";
			this.txtOutputTypeName.Size = new System.Drawing.Size(114, 22);
			this.txtOutputTypeName.TabIndex = 23;
			this.ttToolTip.SetToolTip(this.txtOutputTypeName, "Тип расхода");
			// 
			// txtCellAdress
			// 
			this.txtCellAdress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellAdress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellAdress.Enabled = false;
			this.txtCellAdress.Location = new System.Drawing.Point(420, 50);
			this.txtCellAdress.Name = "txtCellAdress";
			this.txtCellAdress.Size = new System.Drawing.Size(123, 22);
			this.txtCellAdress.TabIndex = 22;
			this.ttToolTip.SetToolTip(this.txtCellAdress, "Адрес ячейки отгрузки");
			// 
			// txtGoodStateName
			// 
			this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodStateName.Enabled = false;
			this.txtGoodStateName.Location = new System.Drawing.Point(86, 50);
			this.txtGoodStateName.Name = "txtGoodStateName";
			this.txtGoodStateName.Size = new System.Drawing.Size(124, 22);
			this.txtGoodStateName.TabIndex = 21;
			// 
			// txtPartnerName
			// 
			this.txtPartnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPartnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPartnerName.Enabled = false;
			this.txtPartnerName.Location = new System.Drawing.Point(291, 26);
			this.txtPartnerName.Name = "txtPartnerName";
			this.txtPartnerName.Size = new System.Drawing.Size(253, 22);
			this.txtPartnerName.TabIndex = 20;
			// 
			// txtOwnerName
			// 
			this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwnerName.Enabled = false;
			this.txtOwnerName.Location = new System.Drawing.Point(86, 26);
			this.txtOwnerName.Name = "txtOwnerName";
			this.txtOwnerName.Size = new System.Drawing.Size(124, 22);
			this.txtOwnerName.TabIndex = 19;
			// 
			// txtErpCode
			// 
			this.txtErpCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtErpCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtErpCode.Enabled = false;
			this.txtErpCode.Location = new System.Drawing.Point(86, 3);
			this.txtErpCode.Name = "txtErpCode";
			this.txtErpCode.Size = new System.Drawing.Size(124, 22);
			this.txtErpCode.TabIndex = 18;
			this.ttToolTip.SetToolTip(this.txtErpCode, "Код расхода в учетной системе");
			// 
			// txtOutputBarCode
			// 
			this.txtOutputBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOutputBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOutputBarCode.Enabled = false;
			this.txtOutputBarCode.Location = new System.Drawing.Point(394, 3);
			this.txtOutputBarCode.Name = "txtOutputBarCode";
			this.txtOutputBarCode.Size = new System.Drawing.Size(150, 22);
			this.txtOutputBarCode.TabIndex = 17;
			this.ttToolTip.SetToolTip(this.txtOutputBarCode, "Штрих-код расхода");
			// 
			// txtDateOutput
			// 
			this.txtDateOutput.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtDateOutput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDateOutput.Enabled = false;
			this.txtDateOutput.Location = new System.Drawing.Point(248, 3);
			this.txtDateOutput.Name = "txtDateOutput";
			this.txtDateOutput.Size = new System.Drawing.Size(114, 22);
			this.txtDateOutput.TabIndex = 16;
			this.ttToolTip.SetToolTip(this.txtDateOutput, "Дата расхода");
			// 
			// lblCellAddress
			// 
			this.lblCellAddress.AutoSize = true;
			this.lblCellAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellAddress.Location = new System.Drawing.Point(368, 53);
			this.lblCellAddress.Name = "lblCellAddress";
			this.lblCellAddress.Size = new System.Drawing.Size(47, 14);
			this.lblCellAddress.TabIndex = 14;
			this.lblCellAddress.Text = "Ячейка";
			// 
			// lblGoodStateName
			// 
			this.lblGoodStateName.AutoSize = true;
			this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodStateName.Location = new System.Drawing.Point(4, 53);
			this.lblGoodStateName.Name = "lblGoodStateName";
			this.lblGoodStateName.Size = new System.Drawing.Size(68, 14);
			this.lblGoodStateName.TabIndex = 13;
			this.lblGoodStateName.Text = "Состояние";
			// 
			// lblPartnerName
			// 
			this.lblPartnerName.AutoSize = true;
			this.lblPartnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPartnerName.Location = new System.Drawing.Point(215, 29);
			this.lblPartnerName.Name = "lblPartnerName";
			this.lblPartnerName.Size = new System.Drawing.Size(74, 14);
			this.lblPartnerName.TabIndex = 12;
			this.lblPartnerName.Text = "Получатель";
			// 
			// lblOwnerName
			// 
			this.lblOwnerName.AutoSize = true;
			this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwnerName.Location = new System.Drawing.Point(4, 29);
			this.lblOwnerName.Name = "lblOwnerName";
			this.lblOwnerName.Size = new System.Drawing.Size(62, 14);
			this.lblOwnerName.TabIndex = 11;
			this.lblOwnerName.Text = "Владелец";
			// 
			// lblOutputTypeName
			// 
			this.lblOutputTypeName.AutoSize = true;
			this.lblOutputTypeName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOutputTypeName.Location = new System.Drawing.Point(215, 53);
			this.lblOutputTypeName.Name = "lblOutputTypeName";
			this.lblOutputTypeName.Size = new System.Drawing.Size(29, 14);
			this.lblOutputTypeName.TabIndex = 10;
			this.lblOutputTypeName.Text = "Тип";
			// 
			// lblOutputBarCode
			// 
			this.lblOutputBarCode.AutoSize = true;
			this.lblOutputBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOutputBarCode.Location = new System.Drawing.Point(368, 6);
			this.lblOutputBarCode.Name = "lblOutputBarCode";
			this.lblOutputBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblOutputBarCode.TabIndex = 9;
			this.lblOutputBarCode.Text = "ШК";
			// 
			// lblDateOutput
			// 
			this.lblDateOutput.AutoSize = true;
			this.lblDateOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateOutput.Location = new System.Drawing.Point(215, 6);
			this.lblDateOutput.Name = "lblDateOutput";
			this.lblDateOutput.Size = new System.Drawing.Size(33, 14);
			this.lblDateOutput.TabIndex = 8;
			this.lblDateOutput.Text = "Дата";
			// 
			// lblOutputID
			// 
			this.lblOutputID.AutoSize = true;
			this.lblOutputID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOutputID.Location = new System.Drawing.Point(4, 6);
			this.lblOutputID.Name = "lblOutputID";
			this.lblOutputID.Size = new System.Drawing.Size(28, 14);
			this.lblOutputID.TabIndex = 7;
			this.lblOutputID.Text = "Код";
			// 
			// chkUnConfirmed
			// 
			this.chkUnConfirmed.AutoSize = true;
			this.chkUnConfirmed.Checked = true;
			this.chkUnConfirmed.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUnConfirmed.Location = new System.Drawing.Point(249, 90);
			this.chkUnConfirmed.Name = "chkUnConfirmed";
			this.chkUnConfirmed.Size = new System.Drawing.Size(187, 18);
			this.chkUnConfirmed.TabIndex = 6;
			this.chkUnConfirmed.Text = "только неподтвержденные ";
			this.chkUnConfirmed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkUnConfirmed.UseVisualStyleBackColor = true;
			// 
			// lblHeavers
			// 
			this.lblHeavers.AutoSize = true;
			this.lblHeavers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblHeavers.Location = new System.Drawing.Point(5, 91);
			this.lblHeavers.Name = "lblHeavers";
			this.lblHeavers.Size = new System.Drawing.Size(36, 14);
			this.lblHeavers.TabIndex = 0;
			this.lblHeavers.Text = "ОПТ:";
			this.ttToolTip.SetToolTip(this.lblHeavers, "Оператор погрузочной техники");
			// 
			// txtID
			// 
			this.txtID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtID.Enabled = false;
			this.txtID.Location = new System.Drawing.Point(34, 3);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(51, 22);
			this.txtID.TabIndex = 15;
			this.ttToolTip.SetToolTip(this.txtID, "Код расхода");
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(473, 387);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(32, 30);
			this.btnSave.TabIndex = 6;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnExit.Location = new System.Drawing.Point(523, 387);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 7;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(8, 387);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(32, 30);
			this.btnHelp.TabIndex = 8;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnUnCheckAll
			// 
			this.btnUnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUnCheckAll.Image = global::WMSSuitable.Properties.Resources.CheckBox_No;
			this.btnUnCheckAll.Location = new System.Drawing.Point(143, 387);
			this.btnUnCheckAll.Name = "btnUnCheckAll";
			this.btnUnCheckAll.Size = new System.Drawing.Size(32, 30);
			this.btnUnCheckAll.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.btnUnCheckAll, "Снять все отметки");
			this.btnUnCheckAll.UseVisualStyleBackColor = true;
			this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
			// 
			// btnCheckAll
			// 
			this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCheckAll.Image = global::WMSSuitable.Properties.Resources.CheckBox_Green;
			this.btnCheckAll.Location = new System.Drawing.Point(108, 387);
			this.btnCheckAll.Name = "btnCheckAll";
			this.btnCheckAll.Size = new System.Drawing.Size(32, 30);
			this.btnCheckAll.TabIndex = 11;
			this.ttToolTip.SetToolTip(this.btnCheckAll, "Отметить все записи");
			this.btnCheckAll.UseVisualStyleBackColor = true;
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			// 
			// dgrcCheck
			// 
			this.dgrcCheck.DataPropertyName = "Checked";
			this.dgrcCheck.HeaderText = "";
			this.dgrcCheck.Name = "dgrcCheck";
			this.dgrcCheck.ReadOnly = true;
			this.dgrcCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcCheck.Width = 25;
			// 
			// dgrcFrameID
			// 
			this.dgrcFrameID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcFrameID.DataPropertyName = "FrameID";
			this.dgrcFrameID.HeaderText = "Контейнер";
			this.dgrcFrameID.Name = "dgrcFrameID";
			this.dgrcFrameID.ReadOnly = true;
			this.dgrcFrameID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcFrameID.Width = 80;
			// 
			// dgrcFrameBarCode
			// 
			this.dgrcFrameBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcFrameBarCode.DataPropertyName = "FrameBarCode";
			this.dgrcFrameBarCode.HeaderText = "ШК контейнера";
			this.dgrcFrameBarCode.Name = "dgrcFrameBarCode";
			this.dgrcFrameBarCode.ReadOnly = true;
			this.dgrcFrameBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcFrameBarCode.Width = 160;
			// 
			// dgrcCellSourceAdress
			// 
			this.dgrcCellSourceAdress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcCellSourceAdress.DataPropertyName = "CellSourceAddress";
			this.dgrcCellSourceAdress.HeaderText = "Ячейка-источник";
			this.dgrcCellSourceAdress.Name = "dgrcCellSourceAdress";
			this.dgrcCellSourceAdress.ReadOnly = true;
			this.dgrcCellSourceAdress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcCellSourceAdress.Width = 160;
			// 
			// dgrcID
			// 
			this.dgrcID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcID.DataPropertyName = "TrafficID";
			this.dgrcID.HeaderText = "ID";
			this.dgrcID.Name = "dgrcID";
			this.dgrcID.ReadOnly = true;
			this.dgrcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcID.Width = 70;
			// 
			// frmOutputsFramesConfirm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(562, 423);
			this.Controls.Add(this.btnUnCheckAll);
			this.Controls.Add(this.btnCheckAll);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlSelectConditions);
			this.Controls.Add(this.dgvOutputFramesShipment);
			this.hpHelp.SetHelpKeyword(this, "231");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOutputsFramesConfirm";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Подтверждение транспортировок поддонов";
			this.Load += new System.EventHandler(this.frmOutputEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputFramesShipment)).EndInit();
			this.pnlSelectConditions.ResumeLayout(false);
			this.pnlSelectConditions.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMDataGridView dgvOutputFramesShipment;
		private RFMBaseClasses.RFMComboBox cboHeavers;
		private RFMBaseClasses.RFMButton btnSelect;
		private RFMBaseClasses.RFMPanel pnlSelectConditions;
		private RFMBaseClasses.RFMLabel lblHeavers;
		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMCheckBox chkUnConfirmed;
		private RFMBaseClasses.RFMLabel lblPartnerName;
		private RFMBaseClasses.RFMLabel lblOwnerName;
		private RFMBaseClasses.RFMLabel lblOutputTypeName;
		private RFMBaseClasses.RFMLabel lblOutputBarCode;
		private RFMBaseClasses.RFMLabel lblDateOutput;
		private RFMBaseClasses.RFMLabel lblOutputID;
		private RFMBaseClasses.RFMLabel lblCellAddress;
		private RFMBaseClasses.RFMLabel lblGoodStateName;
		private RFMBaseClasses.RFMTextBox txtDateOutput;
		private RFMBaseClasses.RFMTextBox txtID;
		private RFMBaseClasses.RFMTextBox txtPartnerName;
		private RFMBaseClasses.RFMTextBox txtOwnerName;
		private RFMBaseClasses.RFMTextBox txtErpCode;
		private RFMBaseClasses.RFMTextBox txtOutputBarCode;
		private RFMBaseClasses.RFMTextBox txtOutputTypeName;
		private RFMBaseClasses.RFMTextBox txtCellAdress;
		private RFMBaseClasses.RFMTextBox txtGoodStateName;
		private RFMBaseClasses.RFMPanel pnlH;
		private RFMBaseClasses.RFMButton btnUnCheckAll;
		private RFMBaseClasses.RFMButton btnCheckAll;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgrcCheck;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcFrameID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcFrameBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcCellSourceAdress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcID;
	}
}

