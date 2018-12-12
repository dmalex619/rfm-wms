namespace WMSSuitable
{
	partial class frmPackingsNotFixed
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.btnFix = new RFMBaseClasses.RFMButton();
			this.grdData = new RFMBaseClasses.RFMDataGridView();
			this.chkPackingsActual = new RFMBaseClasses.RFMCheckBox();
			this.lblActual = new RFMBaseClasses.RFMLabel();
			this.chkGoodsActual = new RFMBaseClasses.RFMCheckBox();
			this.chkCellsFreeOnly = new RFMBaseClasses.RFMCheckBox();
			this.btnRestore = new RFMBaseClasses.RFMButton();
			this.pnlCombo = new RFMBaseClasses.RFMPanel();
			this.btnOwnerClear = new RFMBaseClasses.RFMButton();
			this.cboGoodState = new RFMBaseClasses.RFMComboBox();
			this.cboOwner = new RFMBaseClasses.RFMComboBox();
			this.lblGoodState = new RFMBaseClasses.RFMLabel();
			this.lblOwner = new RFMBaseClasses.RFMLabel();
			this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcArticul = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcTemperatureMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grcAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcBoxInPal = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxInRow = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPackingBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPalletTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcRetention = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcPackingActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcGoodName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPackingID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPackingErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.pnlCombo.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 338);
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
			this.btnExit.Location = new System.Drawing.Point(704, 338);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 7;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnFix
			// 
			this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFix.Image = global::WMSSuitable.Properties.Resources.Flag;
			this.btnFix.Location = new System.Drawing.Point(654, 338);
			this.btnFix.Name = "btnFix";
			this.btnFix.Size = new System.Drawing.Size(32, 30);
			this.btnFix.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.btnFix, "Задать ячейку пикинга");
			this.btnFix.UseVisualStyleBackColor = true;
			this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
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
			this.grdData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
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
            this.grcGoodAlias,
            this.grcArticul,
            this.grcGoodBarCode,
            this.grcInBox,
            this.grcTemperatureMode,
            this.grcAddress,
            this.grcStoreZoneName,
            this.grcWeighting,
            this.grcBoxInPal,
            this.grcBoxInRow,
            this.grcPackingBarCode,
            this.grcPalletTypeName,
            this.grcGoodGroupName,
            this.grcGoodBrandName,
            this.grcRetention,
            this.grcGoodActual,
            this.grcPackingActual,
            this.grcGoodName,
            this.grcGoodID,
            this.grcPackingID,
            this.grcGoodErpCode,
            this.grcPackingErpCode});
			this.grdData.IsConfigInclude = true;
			this.grdData.IsMarkedAll = false;
			this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdData.Location = new System.Drawing.Point(4, 62);
			this.grdData.MultiSelect = false;
			this.grdData.Name = "grdData";
			this.grdData.RangedWay = ' ';
			this.grdData.ReadOnly = true;
			this.grdData.RowHeadersWidth = 24;
			this.grdData.Size = new System.Drawing.Size(734, 270);
			this.grdData.TabIndex = 9;
			this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
			// 
			// chkPackingsActual
			// 
			this.chkPackingsActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkPackingsActual.AutoSize = true;
			this.chkPackingsActual.IsChanged = true;
			this.chkPackingsActual.Location = new System.Drawing.Point(592, 5);
			this.chkPackingsActual.Name = "chkPackingsActual";
			this.chkPackingsActual.Size = new System.Drawing.Size(77, 18);
			this.chkPackingsActual.TabIndex = 20;
			this.chkPackingsActual.Text = "упаковки";
			this.chkPackingsActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkPackingsActual.UseVisualStyleBackColor = true;
			// 
			// lblActual
			// 
			this.lblActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblActual.AutoSize = true;
			this.lblActual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblActual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblActual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblActual.Location = new System.Drawing.Point(394, 7);
			this.lblActual.Name = "lblActual";
			this.lblActual.Size = new System.Drawing.Size(121, 14);
			this.lblActual.TabIndex = 18;
			this.lblActual.Text = "Только актуальные:";
			// 
			// chkGoodsActual
			// 
			this.chkGoodsActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkGoodsActual.AutoSize = true;
			this.chkGoodsActual.IsChanged = true;
			this.chkGoodsActual.Location = new System.Drawing.Point(521, 5);
			this.chkGoodsActual.Name = "chkGoodsActual";
			this.chkGoodsActual.Size = new System.Drawing.Size(66, 18);
			this.chkGoodsActual.TabIndex = 19;
			this.chkGoodsActual.Text = "товары";
			this.chkGoodsActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkGoodsActual.UseVisualStyleBackColor = true;
			// 
			// chkCellsFreeOnly
			// 
			this.chkCellsFreeOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkCellsFreeOnly.AutoSize = true;
			this.chkCellsFreeOnly.Checked = true;
			this.chkCellsFreeOnly.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCellsFreeOnly.IsChanged = true;
			this.chkCellsFreeOnly.Location = new System.Drawing.Point(427, 345);
			this.chkCellsFreeOnly.Name = "chkCellsFreeOnly";
			this.chkCellsFreeOnly.Size = new System.Drawing.Size(209, 18);
			this.chkCellsFreeOnly.TabIndex = 21;
			this.chkCellsFreeOnly.Text = "только незакрепленные ячейки";
			this.chkCellsFreeOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkCellsFreeOnly.UseVisualStyleBackColor = true;
			// 
			// btnRestore
			// 
			this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRestore.FlatAppearance.BorderSize = 0;
			this.btnRestore.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnRestore.Location = new System.Drawing.Point(696, 21);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.Size = new System.Drawing.Size(32, 30);
			this.btnRestore.TabIndex = 22;
			this.ttToolTip.SetToolTip(this.btnRestore, "Показать таблицу");
			this.btnRestore.UseVisualStyleBackColor = true;
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
			// 
			// pnlCombo
			// 
			this.pnlCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlCombo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlCombo.Controls.Add(this.btnOwnerClear);
			this.pnlCombo.Controls.Add(this.btnRestore);
			this.pnlCombo.Controls.Add(this.cboGoodState);
			this.pnlCombo.Controls.Add(this.cboOwner);
			this.pnlCombo.Controls.Add(this.chkPackingsActual);
			this.pnlCombo.Controls.Add(this.lblGoodState);
			this.pnlCombo.Controls.Add(this.lblActual);
			this.pnlCombo.Controls.Add(this.chkGoodsActual);
			this.pnlCombo.Controls.Add(this.lblOwner);
			this.pnlCombo.Location = new System.Drawing.Point(4, 4);
			this.pnlCombo.Name = "pnlCombo";
			this.pnlCombo.Size = new System.Drawing.Size(734, 56);
			this.pnlCombo.TabIndex = 23;
			// 
			// btnOwnerClear
			// 
			this.btnOwnerClear.FlatAppearance.BorderSize = 0;
			this.btnOwnerClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOwnerClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnOwnerClear.Location = new System.Drawing.Point(300, 27);
			this.btnOwnerClear.Name = "btnOwnerClear";
			this.btnOwnerClear.Size = new System.Drawing.Size(25, 25);
			this.btnOwnerClear.TabIndex = 31;
			this.ttToolTip.SetToolTip(this.btnOwnerClear, "Очистить данные о хранителе");
			this.btnOwnerClear.UseVisualStyleBackColor = true;
			this.btnOwnerClear.Click += new System.EventHandler(this.btnOwnerClear_Click);
			// 
			// cboGoodState
			// 
			this.cboGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGoodState.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGoodState.Location = new System.Drawing.Point(79, 3);
			this.cboGoodState.Name = "cboGoodState";
			this.cboGoodState.Size = new System.Drawing.Size(220, 22);
			this.cboGoodState.TabIndex = 30;
			// 
			// cboOwner
			// 
			this.cboOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOwner.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboOwner.Location = new System.Drawing.Point(79, 28);
			this.cboOwner.Name = "cboOwner";
			this.cboOwner.Size = new System.Drawing.Size(220, 22);
			this.cboOwner.TabIndex = 29;
			// 
			// lblGoodState
			// 
			this.lblGoodState.AutoSize = true;
			this.lblGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodState.Location = new System.Drawing.Point(5, 7);
			this.lblGoodState.Name = "lblGoodState";
			this.lblGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblGoodState.TabIndex = 28;
			this.lblGoodState.Text = "Состояние";
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwner.Location = new System.Drawing.Point(5, 32);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(67, 14);
			this.lblOwner.TabIndex = 27;
			this.lblOwner.Text = "Хранитель";
			// 
			// grcGoodAlias
			// 
			this.grcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodAlias.DataPropertyName = "GoodAlias";
			this.grcGoodAlias.HeaderText = "Товар";
			this.grcGoodAlias.Name = "grcGoodAlias";
			this.grcGoodAlias.ReadOnly = true;
			this.grcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodAlias.Width = 250;
			// 
			// grcArticul
			// 
			this.grcArticul.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcArticul.DataPropertyName = "Articul";
			this.grcArticul.HeaderText = "Артикул";
			this.grcArticul.Name = "grcArticul";
			this.grcArticul.ReadOnly = true;
			this.grcArticul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcGoodBarCode
			// 
			this.grcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodBarCode.DataPropertyName = "GoodBarCode";
			this.grcGoodBarCode.HeaderText = "Штрих-код Товар";
			this.grcGoodBarCode.Name = "grcGoodBarCode";
			this.grcGoodBarCode.ReadOnly = true;
			this.grcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodBarCode.ToolTipText = "Штрих-код товара";
			this.grcGoodBarCode.Width = 120;
			// 
			// grcInBox
			// 
			this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcInBox.DataPropertyName = "InBox";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N0";
			this.grcInBox.DefaultCellStyle = dataGridViewCellStyle2;
			this.grcInBox.HeaderText = "В кор.";
			this.grcInBox.Name = "grcInBox";
			this.grcInBox.ReadOnly = true;
			this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcInBox.ToolTipText = "Штук/кг в коробке";
			this.grcInBox.Width = 60;
			// 
			// grcTemperatureMode
			// 
			this.grcTemperatureMode.DataPropertyName = "TemperatureMode";
			this.grcTemperatureMode.HeaderText = "Т";
			this.grcTemperatureMode.Name = "grcTemperatureMode";
			this.grcTemperatureMode.ReadOnly = true;
			this.grcTemperatureMode.ToolTipText = "Температурный режим";
			this.grcTemperatureMode.Width = 25;
			// 
			// grcAddress
			// 
			this.grcAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcAddress.DataPropertyName = "Address";
			this.grcAddress.HeaderText = "Адрес";
			this.grcAddress.Name = "grcAddress";
			this.grcAddress.ReadOnly = true;
			this.grcAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcAddress.ToolTipText = "Адрес ячейки пикинга";
			this.grcAddress.Width = 80;
			// 
			// grcStoreZoneName
			// 
			this.grcStoreZoneName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneName.DataPropertyName = "StoreZoneName";
			this.grcStoreZoneName.HeaderText = "Зона";
			this.grcStoreZoneName.Name = "grcStoreZoneName";
			this.grcStoreZoneName.ReadOnly = true;
			this.grcStoreZoneName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcStoreZoneName.ToolTipText = "Зона пикинга";
			// 
			// grcWeighting
			// 
			this.grcWeighting.DataPropertyName = "Weighting";
			this.grcWeighting.HeaderText = "Вес?";
			this.grcWeighting.Name = "grcWeighting";
			this.grcWeighting.ReadOnly = true;
			this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcWeighting.ToolTipText = "Весовой товар?";
			this.grcWeighting.Width = 40;
			// 
			// grcBoxInPal
			// 
			this.grcBoxInPal.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxInPal.DataPropertyName = "BoxInPal";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N0";
			dataGridViewCellStyle3.NullValue = null;
			this.grcBoxInPal.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcBoxInPal.HeaderText = "Кор. на пал.";
			this.grcBoxInPal.Name = "grcBoxInPal";
			this.grcBoxInPal.ReadOnly = true;
			this.grcBoxInPal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxInPal.ToolTipText = "Коробок на паллете";
			this.grcBoxInPal.Width = 60;
			// 
			// grcBoxInRow
			// 
			this.grcBoxInRow.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxInRow.DataPropertyName = "BoxInRow";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N0";
			this.grcBoxInRow.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcBoxInRow.HeaderText = "Кор. в ряде";
			this.grcBoxInRow.Name = "grcBoxInRow";
			this.grcBoxInRow.ReadOnly = true;
			this.grcBoxInRow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxInRow.ToolTipText = "Коробок в ряде";
			this.grcBoxInRow.Width = 60;
			// 
			// grcPackingBarCode
			// 
			this.grcPackingBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPackingBarCode.DataPropertyName = "PackingBarCode";
			this.grcPackingBarCode.HeaderText = "Штрих-код Упаковка";
			this.grcPackingBarCode.Name = "grcPackingBarCode";
			this.grcPackingBarCode.ReadOnly = true;
			this.grcPackingBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingBarCode.ToolTipText = "Штрих-код упаковки";
			this.grcPackingBarCode.Width = 120;
			// 
			// grcPalletTypeName
			// 
			this.grcPalletTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPalletTypeName.DataPropertyName = "PalletTypeName";
			this.grcPalletTypeName.HeaderText = "Тип поддона";
			this.grcPalletTypeName.Name = "grcPalletTypeName";
			this.grcPalletTypeName.ReadOnly = true;
			this.grcPalletTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPalletTypeName.ToolTipText = "Тип поддона";
			// 
			// grcGoodGroupName
			// 
			this.grcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodGroupName.DataPropertyName = "GoodGroupName";
			this.grcGoodGroupName.HeaderText = "Товарная группа";
			this.grcGoodGroupName.Name = "grcGoodGroupName";
			this.grcGoodGroupName.ReadOnly = true;
			this.grcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodGroupName.Width = 200;
			// 
			// grcGoodBrandName
			// 
			this.grcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodBrandName.DataPropertyName = "GoodBrandName";
			this.grcGoodBrandName.HeaderText = "Товарный бренд";
			this.grcGoodBrandName.Name = "grcGoodBrandName";
			this.grcGoodBrandName.ReadOnly = true;
			this.grcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodBrandName.Width = 200;
			// 
			// grcRetention
			// 
			this.grcRetention.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcRetention.DataPropertyName = "Retention";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.grcRetention.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcRetention.HeaderText = "Срок годн.";
			this.grcRetention.Name = "grcRetention";
			this.grcRetention.ReadOnly = true;
			this.grcRetention.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcRetention.ToolTipText = "Срок годности, дней";
			this.grcRetention.Width = 70;
			// 
			// grcGoodActual
			// 
			this.grcGoodActual.DataPropertyName = "GoodActual";
			this.grcGoodActual.HeaderText = "Акт. Товар";
			this.grcGoodActual.Name = "grcGoodActual";
			this.grcGoodActual.ReadOnly = true;
			this.grcGoodActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodActual.ToolTipText = "Товар актуален?";
			this.grcGoodActual.Width = 50;
			// 
			// grcPackingActual
			// 
			this.grcPackingActual.DataPropertyName = "PackingActual";
			this.grcPackingActual.HeaderText = "Акт. Упаковка";
			this.grcPackingActual.Name = "grcPackingActual";
			this.grcPackingActual.ReadOnly = true;
			this.grcPackingActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingActual.ToolTipText = "Упаковка актуальна?";
			this.grcPackingActual.Width = 50;
			// 
			// grcGoodName
			// 
			this.grcGoodName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodName.DataPropertyName = "GoodName";
			this.grcGoodName.HeaderText = "Товар (полное название)";
			this.grcGoodName.Name = "grcGoodName";
			this.grcGoodName.ReadOnly = true;
			this.grcGoodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodName.Width = 250;
			// 
			// grcGoodID
			// 
			this.grcGoodID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodID.DataPropertyName = "GoodID";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.grcGoodID.DefaultCellStyle = dataGridViewCellStyle6;
			this.grcGoodID.HeaderText = "ID товара";
			this.grcGoodID.Name = "grcGoodID";
			this.grcGoodID.ReadOnly = true;
			this.grcGoodID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodID.ToolTipText = "Код товара (GoodID)";
			this.grcGoodID.Width = 60;
			// 
			// grcPackingID
			// 
			this.grcPackingID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPackingID.DataPropertyName = "PackingID";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.grcPackingID.DefaultCellStyle = dataGridViewCellStyle7;
			this.grcPackingID.HeaderText = "ID упаковки";
			this.grcPackingID.Name = "grcPackingID";
			this.grcPackingID.ReadOnly = true;
			this.grcPackingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingID.ToolTipText = "Код упаковки (PackingID)";
			this.grcPackingID.Width = 60;
			// 
			// grcGoodErpCode
			// 
			this.grcGoodErpCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodErpCode.DataPropertyName = "GoodErpCode";
			this.grcGoodErpCode.HeaderText = "ErpCode товара";
			this.grcGoodErpCode.Name = "grcGoodErpCode";
			this.grcGoodErpCode.ReadOnly = true;
			this.grcGoodErpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodErpCode.ToolTipText = "Код товара в учетной системе";
			// 
			// grcPackingErpCode
			// 
			this.grcPackingErpCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPackingErpCode.DataPropertyName = "PackingErpCode";
			this.grcPackingErpCode.HeaderText = "ErpCode упаковки";
			this.grcPackingErpCode.Name = "grcPackingErpCode";
			this.grcPackingErpCode.ReadOnly = true;
			this.grcPackingErpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingErpCode.ToolTipText = "Код упаковки в учетной системе";
			// 
			// frmPackingsNotFixed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 373);
			this.Controls.Add(this.pnlCombo);
			this.Controls.Add(this.grdData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.chkCellsFreeOnly);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnFix);
			this.hpHelp.SetHelpKeyword(this, "221");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MinimizeBox = false;
			this.Name = "frmPackingsNotFixed";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Товары, не имеющие фиксированного закрепления за ячейками пикинга";
			this.Load += new System.EventHandler(this.frmPackingsNotFixed_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.pnlCombo.ResumeLayout(false);
			this.pnlCombo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RFMBaseClasses.RFMButton btnFix;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMCheckBox chkPackingsActual;
		private RFMBaseClasses.RFMLabel lblActual;
		private RFMBaseClasses.RFMCheckBox chkGoodsActual;
		private RFMBaseClasses.RFMCheckBox chkCellsFreeOnly;
		private RFMBaseClasses.RFMButton btnRestore;
		private RFMBaseClasses.RFMPanel pnlCombo;
		private RFMBaseClasses.RFMButton btnOwnerClear;
		private RFMBaseClasses.RFMComboBox cboGoodState;
		private RFMBaseClasses.RFMComboBox cboOwner;
		private RFMBaseClasses.RFMLabel lblGoodState;
		private RFMBaseClasses.RFMLabel lblOwner;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcArticul;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private System.Windows.Forms.DataGridViewTextBoxColumn grcTemperatureMode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxInPal;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxInRow;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalletTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBrandName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcRetention;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcGoodActual;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcPackingActual;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodErpCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingErpCode;
	}
}

