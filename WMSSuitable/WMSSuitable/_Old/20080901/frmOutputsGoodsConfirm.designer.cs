namespace WMSSuitable
{
	partial class frmOutputsGoodsConfirm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOutputGoodsShipment = new RFMBaseClasses.RFMDataGridView();
            this.dgrcCheck = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.dgrcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcBoxWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcBoxConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcQntWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcQntConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.dgrcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcCellSourceAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcStoreZoneSourceName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgrcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.cboStoresZones = new RFMBaseClasses.RFMComboBox();
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
            this.txtID = new RFMBaseClasses.RFMTextBox();
            this.chkUnConfirmed = new RFMBaseClasses.RFMCheckBox();
            this.lblStoresZones = new RFMBaseClasses.RFMLabel();
            this.lblHeavers = new RFMBaseClasses.RFMLabel();
            this.btnSave = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnCheckAll = new RFMBaseClasses.RFMButton();
            this.btnUnCheckAll = new RFMBaseClasses.RFMButton();
            this.chkMinusAllowed = new RFMBaseClasses.RFMCheckBox();
            this.lblStrikeBoxesData = new RFMBaseClasses.RFMLabel();
            this.lblStrikePositionsData = new RFMBaseClasses.RFMLabel();
            this.lblStrikeBoxes = new RFMBaseClasses.RFMLabel();
            this.lblStrikePositions = new RFMBaseClasses.RFMLabel();
            this.lblStrikes = new RFMBaseClasses.RFMLabel();
            this.lblMinusAllowed = new RFMBaseClasses.RFMLabel();
            this.txtTabNumber = new RFMBaseClasses.RFMTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputGoodsShipment)).BeginInit();
            this.pnlSelectConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOutputGoodsShipment
            // 
            this.dgvOutputGoodsShipment.AllowUserToAddRows = false;
            this.dgvOutputGoodsShipment.AllowUserToDeleteRows = false;
            this.dgvOutputGoodsShipment.AllowUserToOrderColumns = true;
            this.dgvOutputGoodsShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutputGoodsShipment.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOutputGoodsShipment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOutputGoodsShipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOutputGoodsShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputGoodsShipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgrcCheck,
            this.dgrcGoodAlias,
            this.dgrcInBox,
            this.dgrcBoxWished,
            this.dgrcBoxConfirmed,
            this.dgrcQntWished,
            this.dgrcQntConfirmed,
            this.dgrcDateValid,
            this.dgrcWeighting,
            this.dgrcGoodBarCode,
            this.dgrcGoodGroupName,
            this.dgrcGoodBrandName,
            this.dgrcCellSourceAddress,
            this.dgrcStoreZoneSourceName,
            this.dgrcID});
            this.dgvOutputGoodsShipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOutputGoodsShipment.IsConfigInclude = true;
            this.dgvOutputGoodsShipment.IsMarkedAll = false;
            this.dgvOutputGoodsShipment.IsStatusInclude = true;
            this.dgvOutputGoodsShipment.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.dgvOutputGoodsShipment.Location = new System.Drawing.Point(3, 124);
            this.dgvOutputGoodsShipment.MultiSelect = false;
            this.dgvOutputGoodsShipment.Name = "dgvOutputGoodsShipment";
            this.dgvOutputGoodsShipment.RangedWay = ' ';
            this.dgvOutputGoodsShipment.ReadOnly = true;
            this.dgvOutputGoodsShipment.RowHeadersWidth = 24;
            this.dgvOutputGoodsShipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOutputGoodsShipment.Size = new System.Drawing.Size(735, 307);
            this.dgvOutputGoodsShipment.TabIndex = 1;
            this.dgvOutputGoodsShipment.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutputGoodsShipment_CellValidated);
            this.dgvOutputGoodsShipment.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvOutputGoodsShipment_CellPainting);
            this.dgvOutputGoodsShipment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOutputGoodsShipment_CellFormatting);
            this.dgvOutputGoodsShipment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutputGoodsShipment_CellEndEdit);
            this.dgvOutputGoodsShipment.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOutputGoodsShipment_EditingControlShowing);
            this.dgvOutputGoodsShipment.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutputGoodsShipment_CellEnter);
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
            // dgrcGoodAlias
            // 
            this.dgrcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcGoodAlias.DataPropertyName = "GoodAlias";
            this.dgrcGoodAlias.HeaderText = "Товар";
            this.dgrcGoodAlias.Name = "dgrcGoodAlias";
            this.dgrcGoodAlias.ReadOnly = true;
            this.dgrcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcGoodAlias.Width = 250;
            // 
            // dgrcInBox
            // 
            this.dgrcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcInBox.DataPropertyName = "InBox";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            this.dgrcInBox.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgrcInBox.HeaderText = "В кор.";
            this.dgrcInBox.Name = "dgrcInBox";
            this.dgrcInBox.ReadOnly = true;
            this.dgrcInBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcInBox.ToolTipText = "Штук/кг в коробке";
            this.dgrcInBox.Width = 50;
            // 
            // dgrcBoxWished
            // 
            this.dgrcBoxWished.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcBoxWished.DataPropertyName = "BoxWished";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N1";
            this.dgrcBoxWished.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgrcBoxWished.HeaderText = "Заказ кор.";
            this.dgrcBoxWished.Name = "dgrcBoxWished";
            this.dgrcBoxWished.ReadOnly = true;
            this.dgrcBoxWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcBoxWished.ToolTipText = "Заказано коробок";
            this.dgrcBoxWished.Width = 80;
            // 
            // dgrcBoxConfirmed
            // 
            this.dgrcBoxConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcBoxConfirmed.DataPropertyName = "ForBoxConfirmed";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N1";
            this.dgrcBoxConfirmed.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgrcBoxConfirmed.HeaderText = "Факт кор.";
            this.dgrcBoxConfirmed.Name = "dgrcBoxConfirmed";
            this.dgrcBoxConfirmed.ReadOnly = true;
            this.dgrcBoxConfirmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrcBoxConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcBoxConfirmed.ToolTipText = "Фактически подобрано коробок";
            this.dgrcBoxConfirmed.Width = 80;
            // 
            // dgrcQntWished
            // 
            this.dgrcQntWished.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcQntWished.DataPropertyName = "QntWished";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N0";
            this.dgrcQntWished.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgrcQntWished.HeaderText = "Заказ шт.";
            this.dgrcQntWished.Name = "dgrcQntWished";
            this.dgrcQntWished.ReadOnly = true;
            this.dgrcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcQntWished.ToolTipText = "Заказано шт.";
            this.dgrcQntWished.Width = 90;
            // 
            // dgrcQntConfirmed
            // 
            this.dgrcQntConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcQntConfirmed.DataPropertyName = "ForQntConfirmed";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            this.dgrcQntConfirmed.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgrcQntConfirmed.HeaderText = "Факт штук";
            this.dgrcQntConfirmed.Name = "dgrcQntConfirmed";
            this.dgrcQntConfirmed.ReadOnly = true;
            this.dgrcQntConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcQntConfirmed.ToolTipText = "Фактически подобрано штук";
            this.dgrcQntConfirmed.Width = 90;
            // 
            // dgrcDateValid
            // 
            this.dgrcDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcDateValid.DataPropertyName = "DateValid";
            this.dgrcDateValid.HeaderText = "Срок годн.";
            this.dgrcDateValid.Name = "dgrcDateValid";
            this.dgrcDateValid.ReadOnly = true;
            this.dgrcDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcDateValid.ToolTipText = "Заказанный срок годности товара, не менее";
            this.dgrcDateValid.Width = 80;
            // 
            // dgrcWeighting
            // 
            this.dgrcWeighting.DataPropertyName = "Weighting";
            this.dgrcWeighting.HeaderText = "Вес?";
            this.dgrcWeighting.Name = "dgrcWeighting";
            this.dgrcWeighting.ReadOnly = true;
            this.dgrcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcWeighting.ToolTipText = "Весовой товар?";
            this.dgrcWeighting.Width = 40;
            // 
            // dgrcGoodBarCode
            // 
            this.dgrcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcGoodBarCode.DataPropertyName = "GoodBarCode";
            this.dgrcGoodBarCode.HeaderText = "ШК товара";
            this.dgrcGoodBarCode.Name = "dgrcGoodBarCode";
            this.dgrcGoodBarCode.ReadOnly = true;
            this.dgrcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcGoodBarCode.ToolTipText = "Штрих-код товара";
            this.dgrcGoodBarCode.Width = 130;
            // 
            // dgrcGoodGroupName
            // 
            this.dgrcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcGoodGroupName.DataPropertyName = "GoodGroupName";
            this.dgrcGoodGroupName.HeaderText = "Товарная группа";
            this.dgrcGoodGroupName.Name = "dgrcGoodGroupName";
            this.dgrcGoodGroupName.ReadOnly = true;
            this.dgrcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcGoodGroupName.Width = 150;
            // 
            // dgrcGoodBrandName
            // 
            this.dgrcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcGoodBrandName.DataPropertyName = "GoodBrandName";
            this.dgrcGoodBrandName.HeaderText = "Товарный бренд";
            this.dgrcGoodBrandName.Name = "dgrcGoodBrandName";
            this.dgrcGoodBrandName.ReadOnly = true;
            this.dgrcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgrcCellSourceAddress
            // 
            this.dgrcCellSourceAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcCellSourceAddress.DataPropertyName = "CellSourceAddress";
            this.dgrcCellSourceAddress.HeaderText = "Ячейка-источник";
            this.dgrcCellSourceAddress.Name = "dgrcCellSourceAddress";
            this.dgrcCellSourceAddress.ReadOnly = true;
            this.dgrcCellSourceAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcCellSourceAddress.ToolTipText = "Адрес ячейки-источника";
            // 
            // dgrcStoreZoneSourceName
            // 
            this.dgrcStoreZoneSourceName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcStoreZoneSourceName.DataPropertyName = "StoreZoneSourceName";
            this.dgrcStoreZoneSourceName.HeaderText = "Зона-источник";
            this.dgrcStoreZoneSourceName.Name = "dgrcStoreZoneSourceName";
            this.dgrcStoreZoneSourceName.ReadOnly = true;
            this.dgrcStoreZoneSourceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgrcID
            // 
            this.dgrcID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgrcID.DataPropertyName = "TrafficID";
            this.dgrcID.HeaderText = "ID";
            this.dgrcID.Name = "dgrcID";
            this.dgrcID.ReadOnly = true;
            this.dgrcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgrcID.Width = 40;
            // 
            // cboStoresZones
            // 
            this.cboStoresZones.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboStoresZones.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboStoresZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStoresZones.FormattingEnabled = true;
            this.cboStoresZones.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboStoresZones.Location = new System.Drawing.Point(89, 87);
            this.cboStoresZones.Name = "cboStoresZones";
            this.cboStoresZones.Size = new System.Drawing.Size(160, 22);
            this.cboStoresZones.TabIndex = 1;
            this.cboStoresZones.SelectedIndexChanged += new System.EventHandler(this.cboStoresZones_SelectedIndexChanged);
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
            this.cboHeavers.Location = new System.Drawing.Point(337, 87);
            this.cboHeavers.Name = "cboHeavers";
            this.cboHeavers.Size = new System.Drawing.Size(160, 22);
            this.cboHeavers.TabIndex = 4;
            this.ttToolTip.SetToolTip(this.cboHeavers, "Оператор погрузочной техники");
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Image = global::WMSSuitable.Properties.Resources.Go;
            this.btnSelect.Location = new System.Drawing.Point(697, 81);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(32, 30);
            this.btnSelect.TabIndex = 6;
            this.ttToolTip.SetToolTip(this.btnSelect, "Обновить список перемещений");
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pnlSelectConditions
            // 
            this.pnlSelectConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSelectConditions.Controls.Add(this.txtTabNumber);
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
            this.pnlSelectConditions.Controls.Add(this.txtID);
            this.pnlSelectConditions.Controls.Add(this.chkUnConfirmed);
            this.pnlSelectConditions.Controls.Add(this.lblStoresZones);
            this.pnlSelectConditions.Controls.Add(this.lblHeavers);
            this.pnlSelectConditions.Controls.Add(this.cboStoresZones);
            this.pnlSelectConditions.Controls.Add(this.btnSelect);
            this.pnlSelectConditions.Controls.Add(this.cboHeavers);
            this.pnlSelectConditions.Location = new System.Drawing.Point(3, 5);
            this.pnlSelectConditions.Name = "pnlSelectConditions";
            this.pnlSelectConditions.Size = new System.Drawing.Size(735, 117);
            this.pnlSelectConditions.TabIndex = 5;
            // 
            // pnlH
            // 
            this.pnlH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlH.Location = new System.Drawing.Point(1, 74);
            this.pnlH.Name = "pnlH";
            this.pnlH.Size = new System.Drawing.Size(730, 4);
            this.pnlH.TabIndex = 41;
            // 
            // txtOutputTypeName
            // 
            this.txtOutputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOutputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOutputTypeName.Enabled = false;
            this.txtOutputTypeName.Location = new System.Drawing.Point(301, 49);
            this.txtOutputTypeName.Name = "txtOutputTypeName";
            this.txtOutputTypeName.Size = new System.Drawing.Size(145, 22);
            this.txtOutputTypeName.TabIndex = 40;
            this.ttToolTip.SetToolTip(this.txtOutputTypeName, "Тип расхода");
            // 
            // txtCellAdress
            // 
            this.txtCellAdress.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtCellAdress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCellAdress.Enabled = false;
            this.txtCellAdress.Location = new System.Drawing.Point(568, 49);
            this.txtCellAdress.Name = "txtCellAdress";
            this.txtCellAdress.Size = new System.Drawing.Size(160, 22);
            this.txtCellAdress.TabIndex = 39;
            this.ttToolTip.SetToolTip(this.txtCellAdress, "Адрес ячейки отгрузки");
            // 
            // txtGoodStateName
            // 
            this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGoodStateName.Enabled = false;
            this.txtGoodStateName.Location = new System.Drawing.Point(90, 49);
            this.txtGoodStateName.Name = "txtGoodStateName";
            this.txtGoodStateName.Size = new System.Drawing.Size(142, 22);
            this.txtGoodStateName.TabIndex = 38;
            // 
            // txtPartnerName
            // 
            this.txtPartnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtPartnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPartnerName.Enabled = false;
            this.txtPartnerName.Location = new System.Drawing.Point(341, 26);
            this.txtPartnerName.Name = "txtPartnerName";
            this.txtPartnerName.Size = new System.Drawing.Size(387, 22);
            this.txtPartnerName.TabIndex = 37;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwnerName.Enabled = false;
            this.txtOwnerName.Location = new System.Drawing.Point(90, 26);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(142, 22);
            this.txtOwnerName.TabIndex = 36;
            // 
            // txtErpCode
            // 
            this.txtErpCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtErpCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtErpCode.Enabled = false;
            this.txtErpCode.Location = new System.Drawing.Point(90, 3);
            this.txtErpCode.Name = "txtErpCode";
            this.txtErpCode.Size = new System.Drawing.Size(142, 22);
            this.txtErpCode.TabIndex = 35;
            this.ttToolTip.SetToolTip(this.txtErpCode, "Код расхода в учетной системе");
            // 
            // txtOutputBarCode
            // 
            this.txtOutputBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOutputBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOutputBarCode.Enabled = false;
            this.txtOutputBarCode.Location = new System.Drawing.Point(568, 3);
            this.txtOutputBarCode.Name = "txtOutputBarCode";
            this.txtOutputBarCode.Size = new System.Drawing.Size(160, 22);
            this.txtOutputBarCode.TabIndex = 34;
            this.ttToolTip.SetToolTip(this.txtOutputBarCode, "Штрих-код расхода");
            // 
            // txtDateOutput
            // 
            this.txtDateOutput.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtDateOutput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateOutput.Enabled = false;
            this.txtDateOutput.Location = new System.Drawing.Point(301, 3);
            this.txtDateOutput.Name = "txtDateOutput";
            this.txtDateOutput.Size = new System.Drawing.Size(100, 22);
            this.txtDateOutput.TabIndex = 33;
            this.ttToolTip.SetToolTip(this.txtDateOutput, "Дата расхода");
            // 
            // lblCellAddress
            // 
            this.lblCellAddress.AutoSize = true;
            this.lblCellAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCellAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCellAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCellAddress.Location = new System.Drawing.Point(462, 53);
            this.lblCellAddress.Name = "lblCellAddress";
            this.lblCellAddress.Size = new System.Drawing.Size(100, 14);
            this.lblCellAddress.TabIndex = 31;
            this.lblCellAddress.Text = "Ячейка отгрузки";
            // 
            // lblGoodStateName
            // 
            this.lblGoodStateName.AutoSize = true;
            this.lblGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodStateName.Location = new System.Drawing.Point(3, 53);
            this.lblGoodStateName.Name = "lblGoodStateName";
            this.lblGoodStateName.Size = new System.Drawing.Size(68, 14);
            this.lblGoodStateName.TabIndex = 30;
            this.lblGoodStateName.Text = "Состояние";
            // 
            // lblPartnerName
            // 
            this.lblPartnerName.AutoSize = true;
            this.lblPartnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblPartnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPartnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPartnerName.Location = new System.Drawing.Point(264, 29);
            this.lblPartnerName.Name = "lblPartnerName";
            this.lblPartnerName.Size = new System.Drawing.Size(74, 14);
            this.lblPartnerName.TabIndex = 29;
            this.lblPartnerName.Text = "Получатель";
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.AutoSize = true;
            this.lblOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwnerName.Location = new System.Drawing.Point(3, 29);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(62, 14);
            this.lblOwnerName.TabIndex = 28;
            this.lblOwnerName.Text = "Владелец";
            // 
            // lblOutputTypeName
            // 
            this.lblOutputTypeName.AutoSize = true;
            this.lblOutputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOutputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutputTypeName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutputTypeName.Location = new System.Drawing.Point(264, 53);
            this.lblOutputTypeName.Name = "lblOutputTypeName";
            this.lblOutputTypeName.Size = new System.Drawing.Size(29, 14);
            this.lblOutputTypeName.TabIndex = 27;
            this.lblOutputTypeName.Text = "Тип";
            // 
            // lblOutputBarCode
            // 
            this.lblOutputBarCode.AutoSize = true;
            this.lblOutputBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOutputBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutputBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutputBarCode.Location = new System.Drawing.Point(489, 6);
            this.lblOutputBarCode.Name = "lblOutputBarCode";
            this.lblOutputBarCode.Size = new System.Drawing.Size(73, 14);
            this.lblOutputBarCode.TabIndex = 26;
            this.lblOutputBarCode.Text = "ШК расхода";
            // 
            // lblDateOutput
            // 
            this.lblDateOutput.AutoSize = true;
            this.lblDateOutput.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateOutput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateOutput.Location = new System.Drawing.Point(264, 6);
            this.lblDateOutput.Name = "lblDateOutput";
            this.lblDateOutput.Size = new System.Drawing.Size(33, 14);
            this.lblDateOutput.TabIndex = 25;
            this.lblDateOutput.Text = "Дата";
            // 
            // lblOutputID
            // 
            this.lblOutputID.AutoSize = true;
            this.lblOutputID.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOutputID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutputID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutputID.Location = new System.Drawing.Point(3, 6);
            this.lblOutputID.Name = "lblOutputID";
            this.lblOutputID.Size = new System.Drawing.Size(28, 14);
            this.lblOutputID.TabIndex = 24;
            this.lblOutputID.Text = "Код";
            // 
            // txtID
            // 
            this.txtID.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(38, 3);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(51, 22);
            this.txtID.TabIndex = 32;
            this.ttToolTip.SetToolTip(this.txtID, "Код расхода");
            // 
            // chkUnConfirmed
            // 
            this.chkUnConfirmed.AutoSize = true;
            this.chkUnConfirmed.Checked = true;
            this.chkUnConfirmed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnConfirmed.Location = new System.Drawing.Point(509, 89);
            this.chkUnConfirmed.Name = "chkUnConfirmed";
            this.chkUnConfirmed.Size = new System.Drawing.Size(187, 18);
            this.chkUnConfirmed.TabIndex = 5;
            this.chkUnConfirmed.Text = "только неподтвержденные ";
            this.chkUnConfirmed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkUnConfirmed.UseVisualStyleBackColor = true;
            // 
            // lblStoresZones
            // 
            this.lblStoresZones.AutoSize = true;
            this.lblStoresZones.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStoresZones.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStoresZones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStoresZones.Location = new System.Drawing.Point(3, 90);
            this.lblStoresZones.Name = "lblStoresZones";
            this.lblStoresZones.Size = new System.Drawing.Size(86, 14);
            this.lblStoresZones.TabIndex = 0;
            this.lblStoresZones.Text = "Зона пикинга:";
            // 
            // lblHeavers
            // 
            this.lblHeavers.AutoSize = true;
            this.lblHeavers.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblHeavers.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblHeavers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeavers.Location = new System.Drawing.Point(264, 90);
            this.lblHeavers.Name = "lblHeavers";
            this.lblHeavers.Size = new System.Drawing.Size(36, 14);
            this.lblHeavers.TabIndex = 2;
            this.lblHeavers.Text = "ОПТ:";
            this.ttToolTip.SetToolTip(this.lblHeavers, "Оператор погрузочной техники");
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(653, 437);
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
            this.btnExit.Location = new System.Drawing.Point(703, 437);
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
            this.btnHelp.Location = new System.Drawing.Point(7, 437);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 30);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckAll.Image = global::WMSSuitable.Properties.Resources.CheckBox_Green;
            this.btnCheckAll.Location = new System.Drawing.Point(67, 437);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(32, 30);
            this.btnCheckAll.TabIndex = 9;
            this.ttToolTip.SetToolTip(this.btnCheckAll, "Отметить все записи");
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnCheckAll.Image = global::WMSSuitable.Properties.Resources.CheckBox_No;
            this.btnUnCheckAll.Location = new System.Drawing.Point(102, 437);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(32, 30);
            this.btnUnCheckAll.TabIndex = 10;
            this.ttToolTip.SetToolTip(this.btnUnCheckAll, "Снять все отметки");
            this.btnUnCheckAll.UseVisualStyleBackColor = true;
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // chkMinusAllowed
            // 
            this.chkMinusAllowed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMinusAllowed.AutoSize = true;
            this.chkMinusAllowed.Location = new System.Drawing.Point(429, 437);
            this.chkMinusAllowed.Name = "chkMinusAllowed";
            this.chkMinusAllowed.Size = new System.Drawing.Size(212, 18);
            this.chkMinusAllowed.TabIndex = 42;
            this.chkMinusAllowed.Text = "выполнять даже при получении";
            this.chkMinusAllowed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkMinusAllowed.UseVisualStyleBackColor = true;
            this.chkMinusAllowed.Visible = false;
            // 
            // lblStrikeBoxesData
            // 
            this.lblStrikeBoxesData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrikeBoxesData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStrikeBoxesData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStrikeBoxesData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStrikeBoxesData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStrikeBoxesData.Location = new System.Drawing.Point(342, 445);
            this.lblStrikeBoxesData.Name = "lblStrikeBoxesData";
            this.lblStrikeBoxesData.Size = new System.Drawing.Size(64, 14);
            this.lblStrikeBoxesData.TabIndex = 47;
            this.lblStrikeBoxesData.Text = "#";
            // 
            // lblStrikePositionsData
            // 
            this.lblStrikePositionsData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrikePositionsData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStrikePositionsData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStrikePositionsData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStrikePositionsData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStrikePositionsData.Location = new System.Drawing.Point(272, 445);
            this.lblStrikePositionsData.Name = "lblStrikePositionsData";
            this.lblStrikePositionsData.Size = new System.Drawing.Size(38, 14);
            this.lblStrikePositionsData.TabIndex = 46;
            this.lblStrikePositionsData.Text = "#";
            // 
            // lblStrikeBoxes
            // 
            this.lblStrikeBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrikeBoxes.AutoSize = true;
            this.lblStrikeBoxes.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStrikeBoxes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStrikeBoxes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStrikeBoxes.Location = new System.Drawing.Point(310, 445);
            this.lblStrikeBoxes.Name = "lblStrikeBoxes";
            this.lblStrikeBoxes.Size = new System.Drawing.Size(31, 14);
            this.lblStrikeBoxes.TabIndex = 45;
            this.lblStrikeBoxes.Text = "кор.";
            // 
            // lblStrikePositions
            // 
            this.lblStrikePositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrikePositions.AutoSize = true;
            this.lblStrikePositions.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStrikePositions.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStrikePositions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStrikePositions.Location = new System.Drawing.Point(231, 445);
            this.lblStrikePositions.Name = "lblStrikePositions";
            this.lblStrikePositions.Size = new System.Drawing.Size(39, 14);
            this.lblStrikePositions.TabIndex = 44;
            this.lblStrikePositions.Text = "строк";
            // 
            // lblStrikes
            // 
            this.lblStrikes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrikes.AutoSize = true;
            this.lblStrikes.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStrikes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStrikes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStrikes.Location = new System.Drawing.Point(150, 445);
            this.lblStrikes.Name = "lblStrikes";
            this.lblStrikes.Size = new System.Drawing.Size(79, 14);
            this.lblStrikes.TabIndex = 43;
            this.lblStrikes.Text = "Вычеркнуто:";
            // 
            // lblMinusAllowed
            // 
            this.lblMinusAllowed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinusAllowed.AutoSize = true;
            this.lblMinusAllowed.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblMinusAllowed.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMinusAllowed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMinusAllowed.Location = new System.Drawing.Point(447, 453);
            this.lblMinusAllowed.Name = "lblMinusAllowed";
            this.lblMinusAllowed.Size = new System.Drawing.Size(148, 14);
            this.lblMinusAllowed.TabIndex = 48;
            this.lblMinusAllowed.Text = "отрицательных остатков";
            this.lblMinusAllowed.Visible = false;
            // 
            // txtTabNumber
            // 
            this.txtTabNumber.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtTabNumber.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTabNumber.Location = new System.Drawing.Point(301, 87);
            this.txtTabNumber.Name = "txtTabNumber";
            this.txtTabNumber.Size = new System.Drawing.Size(35, 22);
            this.txtTabNumber.TabIndex = 3;
            this.ttToolTip.SetToolTip(this.txtTabNumber, "Тип расхода");
            this.txtTabNumber.TextChanged += new System.EventHandler(this.txtTabNumber_TextChanged);
            // 
            // frmOutputsGoodsConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 473);
            this.Controls.Add(this.lblMinusAllowed);
            this.Controls.Add(this.lblStrikeBoxesData);
            this.Controls.Add(this.lblStrikePositionsData);
            this.Controls.Add(this.lblStrikeBoxes);
            this.Controls.Add(this.lblStrikePositions);
            this.Controls.Add(this.lblStrikes);
            this.Controls.Add(this.chkMinusAllowed);
            this.Controls.Add(this.btnUnCheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlSelectConditions);
            this.Controls.Add(this.dgvOutputGoodsShipment);
            this.hpHelp.SetHelpKeyword(this, "232");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.MinimizeBox = false;
            this.Name = "frmOutputsGoodsConfirm";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подтверждение перемещений коробок/штук";
            this.Load += new System.EventHandler(this.frmOutputEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputGoodsShipment)).EndInit();
            this.pnlSelectConditions.ResumeLayout(false);
            this.pnlSelectConditions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RFMBaseClasses.RFMDataGridView dgvOutputGoodsShipment;
		private RFMBaseClasses.RFMComboBox cboStoresZones;
		private RFMBaseClasses.RFMComboBox cboHeavers;
		private RFMBaseClasses.RFMButton btnSelect;
		private RFMBaseClasses.RFMPanel pnlSelectConditions;
		private RFMBaseClasses.RFMLabel lblHeavers;
		private RFMBaseClasses.RFMLabel lblStoresZones;
		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMCheckBox chkUnConfirmed;
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
		private RFMBaseClasses.RFMPanel pnlH;
		private RFMBaseClasses.RFMButton btnCheckAll;
		private RFMBaseClasses.RFMButton btnUnCheckAll;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgrcCheck;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcBoxWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcBoxConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcQntWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcQntConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcDateValid;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgrcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodBrandName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcCellSourceAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcStoreZoneSourceName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcID;
		private RFMBaseClasses.RFMCheckBox chkMinusAllowed;
		private RFMBaseClasses.RFMLabel lblStrikeBoxesData;
		private RFMBaseClasses.RFMLabel lblStrikePositionsData;
		private RFMBaseClasses.RFMLabel lblStrikeBoxes;
		private RFMBaseClasses.RFMLabel lblStrikePositions;
		private RFMBaseClasses.RFMLabel lblStrikes;
		private RFMBaseClasses.RFMLabel lblMinusAllowed;
        private RFMBaseClasses.RFMTextBox txtTabNumber;
	}
}

