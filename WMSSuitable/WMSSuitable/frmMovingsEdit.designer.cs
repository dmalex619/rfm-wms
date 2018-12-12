namespace WMSSuitable
{
	partial class frmMovingsEdit
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tmrShow = new System.Windows.Forms.Timer(this.components);
			this.dgvMovingsGoods = new RFMBaseClasses.RFMDataGridView();
			this.dgrcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcBoxWished = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.dgrcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcQntWished = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.dgrcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.dgrcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellTargetAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneTargetName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.pnlSelectConditions = new RFMBaseClasses.RFMPanel();
			this.chkNotInOutputs = new RFMBaseClasses.RFMCheckBox();
			this.btnGridClear = new RFMBaseClasses.RFMButton();
			this.btnOutputsErpCodes = new RFMBaseClasses.RFMButton();
			this.lblOutputs = new RFMBaseClasses.RFMLabel();
			this.pnlOutputs = new RFMBaseClasses.RFMPanel();
			this.txtOutputsChoosen = new RFMBaseClasses.RFMTextBox();
			this.btnOutputsClear = new RFMBaseClasses.RFMButton();
			this.btnOutputsChoose = new RFMBaseClasses.RFMButton();
			this.lblGoodsStatesNew = new RFMBaseClasses.RFMLabel();
			this.cboGoodStateNew = new RFMBaseClasses.RFMComboBox();
			this.lblNote = new RFMBaseClasses.RFMLabel();
			this.lblGoods = new RFMBaseClasses.RFMLabel();
			this.pnlTarget = new RFMBaseClasses.RFMPanel();
			this.cboCellTargetAddress = new RFMBaseClasses.RFMComboBox();
			this.lblCellTargetAddress = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesTypesTarget = new RFMBaseClasses.RFMComboBox();
			this.lblStoreZoneTarget = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesTarget = new RFMBaseClasses.RFMComboBox();
			this.txtNote = new RFMBaseClasses.RFMTextBox();
			this.btnGoodsFill = new RFMBaseClasses.RFMButton();
			this.pnlSource = new RFMBaseClasses.RFMPanel();
			this.cboCellSourceAddress = new RFMBaseClasses.RFMComboBox();
			this.lblCellSourceAddress = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesTypesSource = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesSource = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesSource = new RFMBaseClasses.RFMComboBox();
			this.lblCellSource = new RFMBaseClasses.RFMLabel();
			this.pnlOpgMovingsTypes = new RFMBaseClasses.RFMPanel();
			this.optToPicking = new RFMBaseClasses.RFMRadioButton();
			this.optToOneCell = new RFMBaseClasses.RFMRadioButton();
			this.lblGoodsStates = new RFMBaseClasses.RFMLabel();
			this.cboGoodState = new RFMBaseClasses.RFMComboBox();
			this.txtID = new RFMBaseClasses.RFMTextBox();
			this.dtpDateMoving = new RFMBaseClasses.RFMDateTimePicker();
			this.lblMovingsTypes = new RFMBaseClasses.RFMLabel();
			this.lblOwners = new RFMBaseClasses.RFMLabel();
			this.cboOwners = new RFMBaseClasses.RFMComboBox();
			this.cboMovingsTypes = new RFMBaseClasses.RFMComboBox();
			this.pnlGoods = new RFMBaseClasses.RFMPanel();
			this.txtPackingsChoosen = new RFMBaseClasses.RFMTextBox();
			this.btnPackingsClear = new RFMBaseClasses.RFMButton();
			this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
			this.btnMovingAll = new RFMBaseClasses.RFMButton();
			this.btnMovingNull = new RFMBaseClasses.RFMButton();
			((System.ComponentModel.ISupportInitialize)(this.dgvMovingsGoods)).BeginInit();
			this.pnlSelectConditions.SuspendLayout();
			this.pnlOutputs.SuspendLayout();
			this.pnlTarget.SuspendLayout();
			this.pnlSource.SuspendLayout();
			this.pnlOpgMovingsTypes.SuspendLayout();
			this.pnlGoods.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrShow
			// 
			this.tmrShow.Interval = 1000;
			// 
			// dgvMovingsGoods
			// 
			this.dgvMovingsGoods.AllowUserToAddRows = false;
			this.dgvMovingsGoods.AllowUserToDeleteRows = false;
			this.dgvMovingsGoods.AllowUserToOrderColumns = true;
			this.dgvMovingsGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvMovingsGoods.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvMovingsGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvMovingsGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvMovingsGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMovingsGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgrcGoodAlias,
            this.dgrcInBox,
            this.dgrcBox,
            this.dgrcBoxWished,
            this.dgrcQnt,
            this.dgrcQntWished,
            this.dgrcWeighting,
            this.dgrcGoodBarCode,
            this.dgrcGoodGroupName,
            this.dgrcGoodBrandName,
            this.grcCellTargetAddress,
            this.grcStoreZoneTargetName,
            this.dgrcID});
			this.dgvMovingsGoods.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvMovingsGoods.IsConfigInclude = true;
			this.dgvMovingsGoods.IsMarkedAll = false;
			this.dgvMovingsGoods.IsStatusInclude = true;
			this.dgvMovingsGoods.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvMovingsGoods.Location = new System.Drawing.Point(3, 236);
			this.dgvMovingsGoods.MultiSelect = false;
			this.dgvMovingsGoods.Name = "dgvMovingsGoods";
			this.dgvMovingsGoods.RangedWay = ' ';
			this.dgvMovingsGoods.RowHeadersWidth = 24;
			this.dgvMovingsGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvMovingsGoods.Size = new System.Drawing.Size(736, 198);
			this.dgvMovingsGoods.TabIndex = 1;
			this.dgvMovingsGoods.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMovingsGoods_CellBeginEdit);
			this.dgvMovingsGoods.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovingsGoods_CellValidated);
			this.dgvMovingsGoods.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMovingsGoods_CellFormatting);
			this.dgvMovingsGoods.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovingsGoods_CellEndEdit);
			// 
			// dgrcGoodAlias
			// 
			this.dgrcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcGoodAlias.DataPropertyName = "GoodAlias";
			this.dgrcGoodAlias.HeaderText = "Товар";
			this.dgrcGoodAlias.Name = "dgrcGoodAlias";
			this.dgrcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcGoodAlias.Width = 250;
			// 
			// dgrcInBox
			// 
			this.dgrcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcInBox.DataPropertyName = "InBox";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "0";
			this.dgrcInBox.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgrcInBox.HeaderText = "В кор.";
			this.dgrcInBox.Name = "dgrcInBox";
			this.dgrcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcInBox.ToolTipText = "Штук/кг в коробке";
			this.dgrcInBox.Width = 50;
			// 
			// dgrcBox
			// 
			this.dgrcBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcBox.DataPropertyName = "Box";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N1";
			this.dgrcBox.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgrcBox.HeaderText = "Есть кор.";
			this.dgrcBox.Name = "dgrcBox";
			this.dgrcBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgrcBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcBox.ToolTipText = "Имеется в ячейке коробок";
			this.dgrcBox.Width = 80;
			// 
			// dgrcBoxWished
			// 
			this.dgrcBoxWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcBoxWished.DataPropertyName = "BoxWished";
			this.dgrcBoxWished.DecimalPlaces = 1;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N1";
			this.dgrcBoxWished.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgrcBoxWished.HeaderText = "Заказ кор.";
			this.dgrcBoxWished.Name = "dgrcBoxWished";
			this.dgrcBoxWished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgrcBoxWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcBoxWished.ToolTipText = "Заказано коробок";
			this.dgrcBoxWished.Width = 80;
			// 
			// dgrcQnt
			// 
			this.dgrcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcQnt.DataPropertyName = "Qnt";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N0";
			this.dgrcQnt.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgrcQnt.HeaderText = "Есть штук";
			this.dgrcQnt.Name = "dgrcQnt";
			this.dgrcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcQnt.ToolTipText = "Имеется в ячейке штук";
			this.dgrcQnt.Width = 90;
			// 
			// dgrcQntWished
			// 
			this.dgrcQntWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcQntWished.DataPropertyName = "QntWished";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N0";
			this.dgrcQntWished.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgrcQntWished.HeaderText = "Заказ шт.";
			this.dgrcQntWished.Name = "dgrcQntWished";
			this.dgrcQntWished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgrcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcQntWished.ToolTipText = "Заказано шт.";
			this.dgrcQntWished.Width = 90;
			// 
			// dgrcWeighting
			// 
			this.dgrcWeighting.DataPropertyName = "Weighting";
			this.dgrcWeighting.HeaderText = "Вес?";
			this.dgrcWeighting.Name = "dgrcWeighting";
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
			this.dgrcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcGoodGroupName.Width = 150;
			// 
			// dgrcGoodBrandName
			// 
			this.dgrcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcGoodBrandName.DataPropertyName = "GoodBrandName";
			this.dgrcGoodBrandName.HeaderText = "Товарный бренд";
			this.dgrcGoodBrandName.Name = "dgrcGoodBrandName";
			this.dgrcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcGoodBrandName.Width = 150;
			// 
			// grcCellTargetAddress
			// 
			this.grcCellTargetAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellTargetAddress.DataPropertyName = "CellTargetAddress";
			this.grcCellTargetAddress.HeaderText = "В ячейку";
			this.grcCellTargetAddress.Name = "grcCellTargetAddress";
			this.grcCellTargetAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellTargetAddress.ToolTipText = "Адрес целевой ячейки";
			// 
			// grcStoreZoneTargetName
			// 
			this.grcStoreZoneTargetName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneTargetName.DataPropertyName = "StoreZoneTargetName";
			this.grcStoreZoneTargetName.HeaderText = "В зону";
			this.grcStoreZoneTargetName.Name = "grcStoreZoneTargetName";
			this.grcStoreZoneTargetName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcStoreZoneTargetName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// dgrcID
			// 
			this.dgrcID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcID.DataPropertyName = "MovingGoodID";
			this.dgrcID.HeaderText = "ID";
			this.dgrcID.Name = "dgrcID";
			this.dgrcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcID.Visible = false;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(5, 439);
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
			this.btnExit.Location = new System.Drawing.Point(705, 439);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 7;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(655, 439);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(32, 30);
			this.btnSave.TabIndex = 6;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlSelectConditions
			// 
			this.pnlSelectConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSelectConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSelectConditions.Controls.Add(this.chkNotInOutputs);
			this.pnlSelectConditions.Controls.Add(this.btnGridClear);
			this.pnlSelectConditions.Controls.Add(this.btnOutputsErpCodes);
			this.pnlSelectConditions.Controls.Add(this.lblOutputs);
			this.pnlSelectConditions.Controls.Add(this.pnlOutputs);
			this.pnlSelectConditions.Controls.Add(this.lblGoodsStatesNew);
			this.pnlSelectConditions.Controls.Add(this.cboGoodStateNew);
			this.pnlSelectConditions.Controls.Add(this.lblNote);
			this.pnlSelectConditions.Controls.Add(this.lblGoods);
			this.pnlSelectConditions.Controls.Add(this.pnlTarget);
			this.pnlSelectConditions.Controls.Add(this.txtNote);
			this.pnlSelectConditions.Controls.Add(this.btnGoodsFill);
			this.pnlSelectConditions.Controls.Add(this.pnlSource);
			this.pnlSelectConditions.Controls.Add(this.lblCellSource);
			this.pnlSelectConditions.Controls.Add(this.pnlOpgMovingsTypes);
			this.pnlSelectConditions.Controls.Add(this.lblGoodsStates);
			this.pnlSelectConditions.Controls.Add(this.cboGoodState);
			this.pnlSelectConditions.Controls.Add(this.txtID);
			this.pnlSelectConditions.Controls.Add(this.dtpDateMoving);
			this.pnlSelectConditions.Controls.Add(this.lblMovingsTypes);
			this.pnlSelectConditions.Controls.Add(this.lblOwners);
			this.pnlSelectConditions.Controls.Add(this.cboOwners);
			this.pnlSelectConditions.Controls.Add(this.cboMovingsTypes);
			this.pnlSelectConditions.Controls.Add(this.pnlGoods);
			this.pnlSelectConditions.Location = new System.Drawing.Point(3, 5);
			this.pnlSelectConditions.Name = "pnlSelectConditions";
			this.pnlSelectConditions.Size = new System.Drawing.Size(736, 228);
			this.pnlSelectConditions.TabIndex = 0;
			// 
			// chkNotInOutputs
			// 
			this.chkNotInOutputs.AutoSize = true;
			this.chkNotInOutputs.Location = new System.Drawing.Point(444, 58);
			this.chkNotInOutputs.Name = "chkNotInOutputs";
			this.chkNotInOutputs.Size = new System.Drawing.Size(252, 18);
			this.chkNotInOutputs.TabIndex = 12;
			this.chkNotInOutputs.Text = "только товары, не входящие в расходы";
			this.chkNotInOutputs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkNotInOutputs.UseVisualStyleBackColor = true;
			this.chkNotInOutputs.CheckedChanged += new System.EventHandler(this.chkNotInOutputs_CheckedChanged);
			// 
			// btnGridClear
			// 
			this.btnGridClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridClear.Image = global::WMSSuitable.Properties.Resources.Paint;
			this.btnGridClear.Location = new System.Drawing.Point(697, 192);
			this.btnGridClear.Name = "btnGridClear";
			this.btnGridClear.Size = new System.Drawing.Size(32, 30);
			this.btnGridClear.TabIndex = 23;
			this.ttToolTip.SetToolTip(this.btnGridClear, "Очистить всю таблицу");
			this.btnGridClear.UseVisualStyleBackColor = true;
			this.btnGridClear.Click += new System.EventHandler(this.btnGridClear_Click);
			// 
			// btnOutputsErpCodes
			// 
			this.btnOutputsErpCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputsErpCodes.Image = global::WMSSuitable.Properties.Resources.Note;
			this.btnOutputsErpCodes.Location = new System.Drawing.Point(703, 78);
			this.btnOutputsErpCodes.Name = "btnOutputsErpCodes";
			this.btnOutputsErpCodes.Size = new System.Drawing.Size(26, 24);
			this.btnOutputsErpCodes.TabIndex = 15;
			this.ttToolTip.SetToolTip(this.btnOutputsErpCodes, "Выбрать расходы по ERP-кодам");
			this.btnOutputsErpCodes.UseVisualStyleBackColor = true;
			this.btnOutputsErpCodes.Click += new System.EventHandler(this.btnOutputsErpCodes_Click);
			// 
			// lblOutputs
			// 
			this.lblOutputs.AutoSize = true;
			this.lblOutputs.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOutputs.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOutputs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOutputs.Location = new System.Drawing.Point(387, 83);
			this.lblOutputs.Name = "lblOutputs";
			this.lblOutputs.Size = new System.Drawing.Size(54, 14);
			this.lblOutputs.TabIndex = 13;
			this.lblOutputs.Text = "Расходы";
			// 
			// pnlOutputs
			// 
			this.pnlOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlOutputs.Controls.Add(this.txtOutputsChoosen);
			this.pnlOutputs.Controls.Add(this.btnOutputsClear);
			this.pnlOutputs.Controls.Add(this.btnOutputsChoose);
			this.pnlOutputs.Location = new System.Drawing.Point(441, 77);
			this.pnlOutputs.Name = "pnlOutputs";
			this.pnlOutputs.Size = new System.Drawing.Size(262, 26);
			this.pnlOutputs.TabIndex = 14;
			// 
			// txtOutputsChoosen
			// 
			this.txtOutputsChoosen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutputsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOutputsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOutputsChoosen.Enabled = false;
			this.txtOutputsChoosen.Location = new System.Drawing.Point(2, 2);
			this.txtOutputsChoosen.Name = "txtOutputsChoosen";
			this.txtOutputsChoosen.OldValue = "";
			this.txtOutputsChoosen.Size = new System.Drawing.Size(202, 22);
			this.txtOutputsChoosen.TabIndex = 24;
			this.ttToolTip.SetToolTip(this.txtOutputsChoosen, "Выбранные расходы");
			// 
			// btnOutputsClear
			// 
			this.btnOutputsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnOutputsClear.Location = new System.Drawing.Point(234, 1);
			this.btnOutputsClear.Name = "btnOutputsClear";
			this.btnOutputsClear.Size = new System.Drawing.Size(26, 24);
			this.btnOutputsClear.TabIndex = 26;
			this.ttToolTip.SetToolTip(this.btnOutputsClear, "Очистить выбор расходов");
			this.btnOutputsClear.UseVisualStyleBackColor = true;
			this.btnOutputsClear.Click += new System.EventHandler(this.btnOutputsClear_Click);
			// 
			// btnOutputsChoose
			// 
			this.btnOutputsChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnOutputsChoose.Location = new System.Drawing.Point(206, 1);
			this.btnOutputsChoose.Name = "btnOutputsChoose";
			this.btnOutputsChoose.Size = new System.Drawing.Size(26, 24);
			this.btnOutputsChoose.TabIndex = 25;
			this.ttToolTip.SetToolTip(this.btnOutputsChoose, "Выбор расходов");
			this.btnOutputsChoose.UseVisualStyleBackColor = true;
			this.btnOutputsChoose.Click += new System.EventHandler(this.btnOutputsChoose_Click);
			// 
			// lblGoodsStatesNew
			// 
			this.lblGoodsStatesNew.AutoSize = true;
			this.lblGoodsStatesNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodsStatesNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodsStatesNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodsStatesNew.Location = new System.Drawing.Point(3, 115);
			this.lblGoodsStatesNew.Name = "lblGoodsStatesNew";
			this.lblGoodsStatesNew.Size = new System.Drawing.Size(106, 14);
			this.lblGoodsStatesNew.TabIndex = 8;
			this.lblGoodsStatesNew.Text = "Новое состояние";
			// 
			// cboGoodStateNew
			// 
			this.cboGoodStateNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGoodStateNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGoodStateNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGoodStateNew.FormattingEnabled = true;
			this.cboGoodStateNew.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGoodStateNew.Location = new System.Drawing.Point(114, 111);
			this.cboGoodStateNew.Name = "cboGoodStateNew";
			this.cboGoodStateNew.Size = new System.Drawing.Size(209, 22);
			this.cboGoodStateNew.TabIndex = 9;
			// 
			// lblNote
			// 
			this.lblNote.AutoSize = true;
			this.lblNote.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNote.Location = new System.Drawing.Point(3, 203);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new System.Drawing.Size(78, 14);
			this.lblNote.TabIndex = 20;
			this.lblNote.Text = "Примечание";
			// 
			// lblGoods
			// 
			this.lblGoods.AutoSize = true;
			this.lblGoods.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoods.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoods.Location = new System.Drawing.Point(3, 159);
			this.lblGoods.Name = "lblGoods";
			this.lblGoods.Size = new System.Drawing.Size(49, 14);
			this.lblGoods.TabIndex = 10;
			this.lblGoods.Text = "Товары";
			// 
			// pnlTarget
			// 
			this.pnlTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlTarget.Controls.Add(this.cboCellTargetAddress);
			this.pnlTarget.Controls.Add(this.lblCellTargetAddress);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTypesTarget);
			this.pnlTarget.Controls.Add(this.lblStoreZoneTarget);
			this.pnlTarget.Controls.Add(this.cboStoresZonesTarget);
			this.pnlTarget.Location = new System.Drawing.Point(390, 124);
			this.pnlTarget.Name = "pnlTarget";
			this.pnlTarget.Size = new System.Drawing.Size(340, 52);
			this.pnlTarget.TabIndex = 19;
			// 
			// cboCellTargetAddress
			// 
			this.cboCellTargetAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCellTargetAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCellTargetAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellTargetAddress.FormattingEnabled = true;
			this.cboCellTargetAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCellTargetAddress.Location = new System.Drawing.Point(52, 25);
			this.cboCellTargetAddress.Name = "cboCellTargetAddress";
			this.cboCellTargetAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellTargetAddress.TabIndex = 4;
			// 
			// lblCellTargetAddress
			// 
			this.lblCellTargetAddress.AutoSize = true;
			this.lblCellTargetAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellTargetAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellTargetAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellTargetAddress.Location = new System.Drawing.Point(3, 28);
			this.lblCellTargetAddress.Name = "lblCellTargetAddress";
			this.lblCellTargetAddress.Size = new System.Drawing.Size(47, 14);
			this.lblCellTargetAddress.TabIndex = 3;
			this.lblCellTargetAddress.Text = "Ячейка";
			// 
			// cboStoresZonesTypesTarget
			// 
			this.cboStoresZonesTypesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTypesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTypesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesTarget.Enabled = false;
			this.cboStoresZonesTypesTarget.FormattingEnabled = true;
			this.cboStoresZonesTypesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesTarget.Location = new System.Drawing.Point(214, 2);
			this.cboStoresZonesTypesTarget.Name = "cboStoresZonesTypesTarget";
			this.cboStoresZonesTypesTarget.Size = new System.Drawing.Size(120, 22);
			this.cboStoresZonesTypesTarget.TabIndex = 2;
			// 
			// lblStoreZoneTarget
			// 
			this.lblStoreZoneTarget.AutoSize = true;
			this.lblStoreZoneTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoreZoneTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoreZoneTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoreZoneTarget.Location = new System.Drawing.Point(3, 5);
			this.lblStoreZoneTarget.Name = "lblStoreZoneTarget";
			this.lblStoreZoneTarget.Size = new System.Drawing.Size(33, 14);
			this.lblStoreZoneTarget.TabIndex = 0;
			this.lblStoreZoneTarget.Text = "Зона";
			// 
			// cboStoresZonesTarget
			// 
			this.cboStoresZonesTarget.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTarget.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTarget.FormattingEnabled = true;
			this.cboStoresZonesTarget.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTarget.Location = new System.Drawing.Point(52, 2);
			this.cboStoresZonesTarget.Name = "cboStoresZonesTarget";
			this.cboStoresZonesTarget.Size = new System.Drawing.Size(160, 22);
			this.cboStoresZonesTarget.TabIndex = 1;
			this.cboStoresZonesTarget.SelectedIndexChanged += new System.EventHandler(this.cboStoresZonesTarget_SelectedIndexChanged);
			// 
			// txtNote
			// 
			this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNote.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNote.Location = new System.Drawing.Point(85, 200);
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new System.Drawing.Size(518, 22);
			this.txtNote.TabIndex = 21;
			// 
			// btnGoodsFill
			// 
			this.btnGoodsFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGoodsFill.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnGoodsFill.Location = new System.Drawing.Point(657, 192);
			this.btnGoodsFill.Name = "btnGoodsFill";
			this.btnGoodsFill.Size = new System.Drawing.Size(32, 30);
			this.btnGoodsFill.TabIndex = 20;
			this.ttToolTip.SetToolTip(this.btnGoodsFill, "Показать товары в исходной ячейке");
			this.btnGoodsFill.UseVisualStyleBackColor = true;
			this.btnGoodsFill.Click += new System.EventHandler(this.btnGoodsFill_Click);
			// 
			// pnlSource
			// 
			this.pnlSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSource.Controls.Add(this.cboCellSourceAddress);
			this.pnlSource.Controls.Add(this.lblCellSourceAddress);
			this.pnlSource.Controls.Add(this.cboStoresZonesTypesSource);
			this.pnlSource.Controls.Add(this.lblStoresZonesSource);
			this.pnlSource.Controls.Add(this.cboStoresZonesSource);
			this.pnlSource.Location = new System.Drawing.Point(389, 3);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(340, 52);
			this.pnlSource.TabIndex = 11;
			// 
			// cboCellSourceAddress
			// 
			this.cboCellSourceAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCellSourceAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCellSourceAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellSourceAddress.FormattingEnabled = true;
			this.cboCellSourceAddress.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCellSourceAddress.Location = new System.Drawing.Point(52, 25);
			this.cboCellSourceAddress.Name = "cboCellSourceAddress";
			this.cboCellSourceAddress.Size = new System.Drawing.Size(160, 22);
			this.cboCellSourceAddress.TabIndex = 4;
			// 
			// lblCellSourceAddress
			// 
			this.lblCellSourceAddress.AutoSize = true;
			this.lblCellSourceAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellSourceAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellSourceAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellSourceAddress.Location = new System.Drawing.Point(3, 28);
			this.lblCellSourceAddress.Name = "lblCellSourceAddress";
			this.lblCellSourceAddress.Size = new System.Drawing.Size(47, 14);
			this.lblCellSourceAddress.TabIndex = 3;
			this.lblCellSourceAddress.Text = "Ячейка";
			// 
			// cboStoresZonesTypesSource
			// 
			this.cboStoresZonesTypesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTypesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTypesSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesSource.Enabled = false;
			this.cboStoresZonesTypesSource.FormattingEnabled = true;
			this.cboStoresZonesTypesSource.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesSource.Location = new System.Drawing.Point(214, 2);
			this.cboStoresZonesTypesSource.Name = "cboStoresZonesTypesSource";
			this.cboStoresZonesTypesSource.Size = new System.Drawing.Size(120, 22);
			this.cboStoresZonesTypesSource.TabIndex = 2;
			// 
			// lblStoresZonesSource
			// 
			this.lblStoresZonesSource.AutoSize = true;
			this.lblStoresZonesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoresZonesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoresZonesSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesSource.Location = new System.Drawing.Point(3, 5);
			this.lblStoresZonesSource.Name = "lblStoresZonesSource";
			this.lblStoresZonesSource.Size = new System.Drawing.Size(33, 14);
			this.lblStoresZonesSource.TabIndex = 0;
			this.lblStoresZonesSource.Text = "Зона";
			// 
			// cboStoresZonesSource
			// 
			this.cboStoresZonesSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesSource.FormattingEnabled = true;
			this.cboStoresZonesSource.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesSource.Location = new System.Drawing.Point(52, 2);
			this.cboStoresZonesSource.Name = "cboStoresZonesSource";
			this.cboStoresZonesSource.Size = new System.Drawing.Size(160, 22);
			this.cboStoresZonesSource.TabIndex = 1;
			this.cboStoresZonesSource.SelectedIndexChanged += new System.EventHandler(this.cboStoresZonesSource_SelectedIndexChanged);
			// 
			// lblCellSource
			// 
			this.lblCellSource.AutoSize = true;
			this.lblCellSource.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellSource.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellSource.Location = new System.Drawing.Point(340, 9);
			this.lblCellSource.Name = "lblCellSource";
			this.lblCellSource.Size = new System.Drawing.Size(51, 14);
			this.lblCellSource.TabIndex = 10;
			this.lblCellSource.Text = "Откуда:";
			// 
			// pnlOpgMovingsTypes
			// 
			this.pnlOpgMovingsTypes.Controls.Add(this.optToPicking);
			this.pnlOpgMovingsTypes.Controls.Add(this.optToOneCell);
			this.pnlOpgMovingsTypes.Location = new System.Drawing.Point(330, 105);
			this.pnlOpgMovingsTypes.Name = "pnlOpgMovingsTypes";
			this.pnlOpgMovingsTypes.Size = new System.Drawing.Size(137, 92);
			this.pnlOpgMovingsTypes.TabIndex = 16;
			// 
			// optToPicking
			// 
			this.optToPicking.AutoSize = true;
			this.optToPicking.Location = new System.Drawing.Point(9, 73);
			this.optToPicking.Name = "optToPicking";
			this.optToPicking.Size = new System.Drawing.Size(125, 18);
			this.optToPicking.TabIndex = 2;
			this.optToPicking.Text = "в ячейки пикинга";
			this.optToPicking.UseVisualStyleBackColor = true;
			this.optToPicking.CheckedChanged += new System.EventHandler(this.optToOneCell_CheckedChanged);
			// 
			// optToOneCell
			// 
			this.optToOneCell.AutoSize = true;
			this.optToOneCell.Checked = true;
			this.optToOneCell.IsChanged = true;
			this.optToOneCell.Location = new System.Drawing.Point(9, 0);
			this.optToOneCell.Name = "optToOneCell";
			this.optToOneCell.Size = new System.Drawing.Size(106, 18);
			this.optToOneCell.TabIndex = 0;
			this.optToOneCell.TabStop = true;
			this.optToOneCell.Text = "в одну ячейку";
			this.optToOneCell.UseVisualStyleBackColor = true;
			this.optToOneCell.CheckedChanged += new System.EventHandler(this.optToOneCell_CheckedChanged);
			// 
			// lblGoodsStates
			// 
			this.lblGoodsStates.AutoSize = true;
			this.lblGoodsStates.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodsStates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodsStates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodsStates.Location = new System.Drawing.Point(3, 88);
			this.lblGoodsStates.Name = "lblGoodsStates";
			this.lblGoodsStates.Size = new System.Drawing.Size(110, 14);
			this.lblGoodsStates.TabIndex = 6;
			this.lblGoodsStates.Text = "Состояние товара";
			// 
			// cboGoodState
			// 
			this.cboGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGoodState.FormattingEnabled = true;
			this.cboGoodState.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGoodState.Location = new System.Drawing.Point(114, 84);
			this.cboGoodState.Name = "cboGoodState";
			this.cboGoodState.Size = new System.Drawing.Size(209, 22);
			this.cboGoodState.TabIndex = 7;
			// 
			// txtID
			// 
			this.txtID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtID.Location = new System.Drawing.Point(3, 3);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(105, 22);
			this.txtID.TabIndex = 0;
			// 
			// dtpDateMoving
			// 
			this.dtpDateMoving.CustomFormat = "dd.MM.yyyy";
			this.dtpDateMoving.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.dtpDateMoving.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.dtpDateMoving.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDateMoving.Location = new System.Drawing.Point(114, 3);
			this.dtpDateMoving.Name = "dtpDateMoving";
			this.dtpDateMoving.Size = new System.Drawing.Size(96, 22);
			this.dtpDateMoving.TabIndex = 1;
			// 
			// lblMovingsTypes
			// 
			this.lblMovingsTypes.AutoSize = true;
			this.lblMovingsTypes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblMovingsTypes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblMovingsTypes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMovingsTypes.Location = new System.Drawing.Point(3, 34);
			this.lblMovingsTypes.Name = "lblMovingsTypes";
			this.lblMovingsTypes.Size = new System.Drawing.Size(29, 14);
			this.lblMovingsTypes.TabIndex = 2;
			this.lblMovingsTypes.Text = "Тип";
			// 
			// lblOwners
			// 
			this.lblOwners.AutoSize = true;
			this.lblOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwners.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwners.Location = new System.Drawing.Point(3, 61);
			this.lblOwners.Name = "lblOwners";
			this.lblOwners.Size = new System.Drawing.Size(62, 14);
			this.lblOwners.TabIndex = 4;
			this.lblOwners.Text = "Владелец";
			// 
			// cboOwners
			// 
			this.cboOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOwners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOwners.FormattingEnabled = true;
			this.cboOwners.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboOwners.Location = new System.Drawing.Point(114, 57);
			this.cboOwners.Name = "cboOwners";
			this.cboOwners.Size = new System.Drawing.Size(209, 22);
			this.cboOwners.TabIndex = 5;
			// 
			// cboMovingsTypes
			// 
			this.cboMovingsTypes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboMovingsTypes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboMovingsTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMovingsTypes.FormattingEnabled = true;
			this.cboMovingsTypes.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboMovingsTypes.Location = new System.Drawing.Point(114, 30);
			this.cboMovingsTypes.Name = "cboMovingsTypes";
			this.cboMovingsTypes.Size = new System.Drawing.Size(209, 22);
			this.cboMovingsTypes.TabIndex = 3;
			this.cboMovingsTypes.SelectedIndexChanged += new System.EventHandler(this.cboMovingsTypes_SelectedIndexChanged);
			// 
			// pnlGoods
			// 
			this.pnlGoods.Controls.Add(this.txtPackingsChoosen);
			this.pnlGoods.Controls.Add(this.btnPackingsClear);
			this.pnlGoods.Controls.Add(this.btnPackingsChoose);
			this.pnlGoods.Location = new System.Drawing.Point(2, 171);
			this.pnlGoods.Name = "pnlGoods";
			this.pnlGoods.Size = new System.Drawing.Size(322, 29);
			this.pnlGoods.TabIndex = 12;
			// 
			// txtPackingsChoosen
			// 
			this.txtPackingsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPackingsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackingsChoosen.Enabled = false;
			this.txtPackingsChoosen.Location = new System.Drawing.Point(2, 3);
			this.txtPackingsChoosen.Name = "txtPackingsChoosen";
			this.txtPackingsChoosen.OldValue = "";
			this.txtPackingsChoosen.Size = new System.Drawing.Size(264, 22);
			this.txtPackingsChoosen.TabIndex = 0;
			this.ttToolTip.SetToolTip(this.txtPackingsChoosen, "Выбранные товары");
			// 
			// btnPackingsClear
			// 
			this.btnPackingsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnPackingsClear.Location = new System.Drawing.Point(295, 2);
			this.btnPackingsClear.Name = "btnPackingsClear";
			this.btnPackingsClear.Size = new System.Drawing.Size(26, 24);
			this.btnPackingsClear.TabIndex = 26;
			this.ttToolTip.SetToolTip(this.btnPackingsClear, "Очистить выбор товаров");
			this.btnPackingsClear.UseVisualStyleBackColor = true;
			this.btnPackingsClear.Click += new System.EventHandler(this.btnPackingsClear_Click);
			// 
			// btnPackingsChoose
			// 
			this.btnPackingsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackingsChoose.Location = new System.Drawing.Point(268, 2);
			this.btnPackingsChoose.Name = "btnPackingsChoose";
			this.btnPackingsChoose.Size = new System.Drawing.Size(26, 24);
			this.btnPackingsChoose.TabIndex = 25;
			this.ttToolTip.SetToolTip(this.btnPackingsChoose, "Выбор товаров");
			this.btnPackingsChoose.UseVisualStyleBackColor = true;
			this.btnPackingsChoose.Click += new System.EventHandler(this.btnPackingsChoose_Click);
			// 
			// btnMovingAll
			// 
			this.btnMovingAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnMovingAll.Image = global::WMSSuitable.Properties.Resources.CheckBox_Green;
			this.btnMovingAll.Location = new System.Drawing.Point(299, 439);
			this.btnMovingAll.Name = "btnMovingAll";
			this.btnMovingAll.Size = new System.Drawing.Size(32, 30);
			this.btnMovingAll.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.btnMovingAll, "Выбрать все товары полностью");
			this.btnMovingAll.UseVisualStyleBackColor = true;
			this.btnMovingAll.Click += new System.EventHandler(this.btnMovingAll_Click);
			// 
			// btnMovingNull
			// 
			this.btnMovingNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnMovingNull.Image = global::WMSSuitable.Properties.Resources.CheckBox_No;
			this.btnMovingNull.Location = new System.Drawing.Point(339, 439);
			this.btnMovingNull.Name = "btnMovingNull";
			this.btnMovingNull.Size = new System.Drawing.Size(32, 30);
			this.btnMovingNull.TabIndex = 13;
			this.ttToolTip.SetToolTip(this.btnMovingNull, "Очистить выбранное количество товара");
			this.btnMovingNull.UseVisualStyleBackColor = true;
			this.btnMovingNull.Click += new System.EventHandler(this.btnMovingNull_Click);
			// 
			// frmMovingsEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 473);
			this.Controls.Add(this.btnMovingNull);
			this.Controls.Add(this.btnMovingAll);
			this.Controls.Add(this.pnlSelectConditions);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dgvMovingsGoods);
			this.hpHelp.SetHelpKeyword(this, "221");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MinimizeBox = false;
			this.Name = "frmMovingsEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Внутрискладское перемещение";
			this.Load += new System.EventHandler(this.frmMovingsEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvMovingsGoods)).EndInit();
			this.pnlSelectConditions.ResumeLayout(false);
			this.pnlSelectConditions.PerformLayout();
			this.pnlOutputs.ResumeLayout(false);
			this.pnlOutputs.PerformLayout();
			this.pnlTarget.ResumeLayout(false);
			this.pnlTarget.PerformLayout();
			this.pnlSource.ResumeLayout(false);
			this.pnlSource.PerformLayout();
			this.pnlOpgMovingsTypes.ResumeLayout(false);
			this.pnlOpgMovingsTypes.PerformLayout();
			this.pnlGoods.ResumeLayout(false);
			this.pnlGoods.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer tmrShow;
		private RFMBaseClasses.RFMDataGridView dgvMovingsGoods;
		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlSelectConditions;
		private RFMBaseClasses.RFMLabel lblGoodsStates;
		private RFMBaseClasses.RFMComboBox cboGoodState;
		private RFMBaseClasses.RFMTextBox txtID;
		private RFMBaseClasses.RFMDateTimePicker dtpDateMoving;
		private RFMBaseClasses.RFMLabel lblMovingsTypes;
		private RFMBaseClasses.RFMLabel lblOwners;
		private RFMBaseClasses.RFMComboBox cboOwners;
		private RFMBaseClasses.RFMComboBox cboMovingsTypes;
		private RFMBaseClasses.RFMPanel pnlOpgMovingsTypes;
		private RFMBaseClasses.RFMRadioButton optToPicking;
		private RFMBaseClasses.RFMRadioButton optToOneCell;
		private RFMBaseClasses.RFMLabel lblCellSource;
		private RFMBaseClasses.RFMPanel pnlSource;
		private RFMBaseClasses.RFMComboBox cboCellSourceAddress;
		private RFMBaseClasses.RFMLabel lblCellSourceAddress;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesSource;
		private RFMBaseClasses.RFMLabel lblStoresZonesSource;
		private RFMBaseClasses.RFMComboBox cboStoresZonesSource;
		private RFMBaseClasses.RFMButton btnMovingAll;
		private RFMBaseClasses.RFMButton btnMovingNull;
		private RFMBaseClasses.RFMButton btnGoodsFill;
		private RFMBaseClasses.RFMTextBox txtNote;
		private RFMBaseClasses.RFMPanel pnlTarget;
		private RFMBaseClasses.RFMComboBox cboCellTargetAddress;
		private RFMBaseClasses.RFMLabel lblCellTargetAddress;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesTarget;
		private RFMBaseClasses.RFMLabel lblStoreZoneTarget;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTarget;
		private RFMBaseClasses.RFMLabel lblNote;
		private RFMBaseClasses.RFMPanel pnlGoods;
		private RFMBaseClasses.RFMTextBox txtPackingsChoosen;
		private RFMBaseClasses.RFMButton btnPackingsClear;
		private RFMBaseClasses.RFMButton btnPackingsChoose;
		private RFMBaseClasses.RFMLabel lblGoods;
		private RFMBaseClasses.RFMLabel lblGoodsStatesNew;
		private RFMBaseClasses.RFMComboBox cboGoodStateNew;
		private RFMBaseClasses.RFMLabel lblOutputs;
		private RFMBaseClasses.RFMPanel pnlOutputs;
		private RFMBaseClasses.RFMTextBox txtOutputsChoosen;
		private RFMBaseClasses.RFMButton btnOutputsClear;
		private RFMBaseClasses.RFMButton btnOutputsChoose;
		private RFMBaseClasses.RFMButton btnOutputsErpCodes;
		private RFMBaseClasses.RFMButton btnGridClear;
		private RFMBaseClasses.RFMCheckBox chkNotInOutputs;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn dgrcBoxWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn dgrcQntWished;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgrcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodBrandName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellTargetAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneTargetName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcID;
	}
}

