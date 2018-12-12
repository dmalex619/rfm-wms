namespace WMSSuitable
{
	partial class frmCellsReorder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellsReorder));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.cntCells = new RFMBaseClasses.RFMSplitContainer();
			this.chkCellsActual = new RFMBaseClasses.RFMCheckBox();
			this.uctZones = new RFMBaseClasses.RFMSelectRecordIDGridEx();
			this.trvCells = new RFMBaseClasses.RFMTreeView();
			this.btnGrid = new RFMBaseClasses.RFMButton();
			this.dgvCells = new RFMBaseClasses.RFMDataGridView();
			this.grcIsRankChanged = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcCellStateImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcLockedImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcRank = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcFixedPackingAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcFixedOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcFixedGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcState = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcCBuilding = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCLine = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCRack = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCLevel = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCPlace = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcMaxWeight = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellWidth = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellHeight = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPalletTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcTemperatureMode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcLocked = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcBufferAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcHasCellContent = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcMaxPalletQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneMaxPalletQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcForFrames = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcIsForFrames = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcStoreZoneTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.btnMax = new RFMBaseClasses.RFMButton();
			this.btnMin = new RFMBaseClasses.RFMButton();
			this.btnPlus = new RFMBaseClasses.RFMButton();
			this.btnMinus = new RFMBaseClasses.RFMButton();
			this.nudRank = new RFMBaseClasses.RFMNumericUpDown();
			this.btnEqual = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnAddressContextMark = new RFMBaseClasses.RFMButton();
			this.txtAddress = new RFMBaseClasses.RFMTextBox();
			this.lblAddressContext = new RFMBaseClasses.RFMLabel();
			this.chkClearMarkers = new RFMBaseClasses.RFMCheckBox();
			this.lblRank = new RFMBaseClasses.RFMLabel();
			this.cntCells.Panel1.SuspendLayout();
			this.cntCells.Panel2.SuspendLayout();
			this.cntCells.SuspendLayout();
			this.uctZones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCells)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRank)).BeginInit();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(9, 407);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(32, 30);
			this.btnHelp.TabIndex = 0;
			this.ttToolTip.SetToolTip(this.btnHelp, "Помощь");
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnExit.Location = new System.Drawing.Point(704, 407);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 13;
			this.ttToolTip.SetToolTip(this.btnExit, "Выйти без сохранения");
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// cntCells
			// 
			this.cntCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cntCells.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.cntCells.Location = new System.Drawing.Point(4, 5);
			this.cntCells.Name = "cntCells";
			// 
			// cntCells.Panel1
			// 
			this.cntCells.Panel1.Controls.Add(this.chkCellsActual);
			this.cntCells.Panel1.Controls.Add(this.uctZones);
			this.cntCells.Panel1.Controls.Add(this.trvCells);
			this.cntCells.Panel1.Controls.Add(this.btnGrid);
			// 
			// cntCells.Panel2
			// 
			this.cntCells.Panel2.Controls.Add(this.dgvCells);
			this.cntCells.Size = new System.Drawing.Size(736, 378);
			this.cntCells.SplitterDistance = 186;
			this.cntCells.TabIndex = 16;
			// 
			// chkCellsActual
			// 
			this.chkCellsActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCellsActual.AutoSize = true;
			this.chkCellsActual.Checked = true;
			this.chkCellsActual.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCellsActual.IsChanged = true;
			this.chkCellsActual.Location = new System.Drawing.Point(4, 349);
			this.chkCellsActual.Name = "chkCellsActual";
			this.chkCellsActual.Size = new System.Drawing.Size(136, 18);
			this.chkCellsActual.TabIndex = 2;
			this.chkCellsActual.Text = "Только актуальные";
			this.chkCellsActual.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.chkCellsActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkCellsActual.UseVisualStyleBackColor = true;
			this.chkCellsActual.CheckedChanged += new System.EventHandler(this.chkCellsActual_CheckedChanged);
			// 
			// uctZones
			// 
			this.uctZones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// uctZones.btnClear
			// 
			this.uctZones.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.uctZones.BtnClear.Image = ((System.Drawing.Image)(resources.GetObject("uctZones.btnClear.Image")));
			this.uctZones.BtnClear.Location = new System.Drawing.Point(155, 4);
			this.uctZones.BtnClear.Name = "btnClear";
			this.uctZones.BtnClear.Size = new System.Drawing.Size(24, 22);
			this.uctZones.BtnClear.TabIndex = 2;
			this.uctZones.BtnClear.UseVisualStyleBackColor = true;
			// 
			// uctZones.btnSelect
			// 
			this.uctZones.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.uctZones.BtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("uctZones.btnSelect.Image")));
			this.uctZones.BtnSelect.Location = new System.Drawing.Point(129, 4);
			this.uctZones.BtnSelect.Name = "btnSelect";
			this.uctZones.BtnSelect.Size = new System.Drawing.Size(24, 22);
			this.uctZones.BtnSelect.TabIndex = 1;
			this.uctZones.BtnSelect.UseVisualStyleBackColor = true;
			this.uctZones.ColumnInfo.Add(((RFMBaseClasses.SourceField)(resources.GetObject("uctZones.ColumnInfo"))));
			this.uctZones.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.uctZones.IsSaveMark = true;
			this.uctZones.IsUseMark = true;
			this.uctZones.Location = new System.Drawing.Point(0, 0);
			this.uctZones.MarkedCount = 0;
			this.uctZones.Name = "uctZones";
			this.uctZones.Size = new System.Drawing.Size(180, 30);
			this.uctZones.TabIndex = 0;
			this.uctZones.TableColumnName = "Name";
			// 
			// uctZones.txtData
			// 
			this.uctZones.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.uctZones.TxtData.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.uctZones.TxtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.uctZones.TxtData.Font = new System.Drawing.Font("Tahoma", 9F);
			this.uctZones.TxtData.IsUserDraw = true;
			this.uctZones.TxtData.Location = new System.Drawing.Point(4, 4);
			this.uctZones.TxtData.Name = "txtData";
			this.uctZones.TxtData.ReadOnly = true;
			this.uctZones.TxtData.Size = new System.Drawing.Size(123, 22);
			this.uctZones.TxtData.TabIndex = 3;
			// 
			// trvCells
			// 
			this.trvCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.trvCells.CheckBoxes = true;
			this.trvCells.FullRowSelect = true;
			this.trvCells.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1)),
        ((object)(((byte)(0))))};
			this.trvCells.Location = new System.Drawing.Point(4, 30);
			this.trvCells.Name = "trvCells";
			this.trvCells.Size = new System.Drawing.Size(176, 310);
			this.trvCells.TabIndex = 1;
			// 
			// btnGrid
			// 
			this.btnGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGrid.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnGrid.Location = new System.Drawing.Point(148, 342);
			this.btnGrid.Name = "btnGrid";
			this.btnGrid.Size = new System.Drawing.Size(32, 30);
			this.btnGrid.TabIndex = 3;
			this.ttToolTip.SetToolTip(this.btnGrid, "Получить список ячеек");
			this.btnGrid.UseVisualStyleBackColor = true;
			this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
			// 
			// dgvCells
			// 
			this.dgvCells.AllowUserToAddRows = false;
			this.dgvCells.AllowUserToDeleteRows = false;
			this.dgvCells.AllowUserToOrderColumns = true;
			this.dgvCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCells.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvCells.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvCells.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcIsRankChanged,
            this.grcCellStateImage,
            this.grcLockedImage,
            this.grcAddress,
            this.grcRank,
            this.grcStoreZoneName,
            this.grcFixedPackingAlias,
            this.grcFixedOwnerName,
            this.grcFixedGoodStateName,
            this.grcState,
            this.grcActual,
            this.grcCBuilding,
            this.grcCLine,
            this.grcCRack,
            this.grcCLevel,
            this.grcCPlace,
            this.grcMaxWeight,
            this.grcCellWidth,
            this.grcCellHeight,
            this.grcPalletTypeName,
            this.grcTemperatureMode,
            this.grcLocked,
            this.grcBufferAddress,
            this.grcErpCode,
            this.grcHasCellContent,
            this.grcMaxPalletQnt,
            this.grcStoreZoneMaxPalletQnt,
            this.grcForFrames,
            this.grcIsForFrames,
            this.grcStoreZoneTypeName,
            this.grcID});
			this.dgvCells.IsCheckerInclude = true;
			this.dgvCells.IsCheckerShow = true;
			this.dgvCells.IsConfigInclude = true;
			this.dgvCells.IsMarkedAll = false;
			this.dgvCells.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvCells.Location = new System.Drawing.Point(-1, -1);
			this.dgvCells.MultiSelect = false;
			this.dgvCells.Name = "dgvCells";
			this.dgvCells.RangedWay = ' ';
			this.dgvCells.RowHeadersWidth = 24;
			this.dgvCells.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvCells.SelectedRowBorderColor = System.Drawing.SystemColors.Control;
			this.dgvCells.SelectedRowForeColor = System.Drawing.Color.Black;
			this.dgvCells.Size = new System.Drawing.Size(543, 375);
			this.dgvCells.TabIndex = 0;
			this.dgvCells.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCells_CellFormatting);
			this.dgvCells.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCells_CurrentCellDirtyStateChanged);
			// 
			// grcIsRankChanged
			// 
			this.grcIsRankChanged.HeaderText = "Ред.";
			this.grcIsRankChanged.Name = "grcIsRankChanged";
			this.grcIsRankChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcIsRankChanged.ToolTipText = "Ранг ячейки изменен?";
			this.grcIsRankChanged.Width = 38;
			// 
			// grcCellStateImage
			// 
			this.grcCellStateImage.HeaderText = "";
			this.grcCellStateImage.Name = "grcCellStateImage";
			this.grcCellStateImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellStateImage.ToolTipText = "Ячейка заполнена?";
			this.grcCellStateImage.Width = 30;
			// 
			// grcLockedImage
			// 
			this.grcLockedImage.DataPropertyName = "Locked";
			this.grcLockedImage.HeaderText = "Блок.";
			this.grcLockedImage.Name = "grcLockedImage";
			this.grcLockedImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcLockedImage.ToolTipText = "Ячейка блокирована?";
			this.grcLockedImage.Width = 45;
			// 
			// grcAddress
			// 
			this.grcAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcAddress.DataPropertyName = "Address";
			this.grcAddress.HeaderText = "Адрес";
			this.grcAddress.Name = "grcAddress";
			this.grcAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcAddress.Width = 77;
			// 
			// grcRank
			// 
			this.grcRank.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcRank.DataPropertyName = "Rank";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Pink;
			this.grcRank.DefaultCellStyle = dataGridViewCellStyle2;
			this.grcRank.HeaderText = "Ранг";
			this.grcRank.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.grcRank.Name = "grcRank";
			this.grcRank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcRank.Width = 50;
			// 
			// grcStoreZoneName
			// 
			this.grcStoreZoneName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneName.DataPropertyName = "StoreZoneName";
			this.grcStoreZoneName.HeaderText = "Складская зона";
			this.grcStoreZoneName.Name = "grcStoreZoneName";
			this.grcStoreZoneName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcFixedPackingAlias
			// 
			this.grcFixedPackingAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcFixedPackingAlias.DataPropertyName = "PackingAlias";
			this.grcFixedPackingAlias.HeaderText = "Товар (фикс.)";
			this.grcFixedPackingAlias.Name = "grcFixedPackingAlias";
			this.grcFixedPackingAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFixedPackingAlias.ToolTipText = "Товар фиксированный";
			this.grcFixedPackingAlias.Width = 150;
			// 
			// grcFixedOwnerName
			// 
			this.grcFixedOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcFixedOwnerName.DataPropertyName = "FixedOwnerName";
			this.grcFixedOwnerName.HeaderText = "Хранитель (фикс.)";
			this.grcFixedOwnerName.Name = "grcFixedOwnerName";
			this.grcFixedOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFixedOwnerName.ToolTipText = "Хранитель фиксированный";
			this.grcFixedOwnerName.Width = 150;
			// 
			// grcFixedGoodStateName
			// 
			this.grcFixedGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcFixedGoodStateName.DataPropertyName = "FixedGoodStateName";
			this.grcFixedGoodStateName.HeaderText = "Состояние товара (фикс.)";
			this.grcFixedGoodStateName.Name = "grcFixedGoodStateName";
			this.grcFixedGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFixedGoodStateName.ToolTipText = "Состояние товара (фиксированное)";
			this.grcFixedGoodStateName.Width = 150;
			// 
			// grcState
			// 
			this.grcState.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcState.DataPropertyName = "State";
			this.grcState.HeaderText = "Состояние ячейки";
			this.grcState.Name = "grcState";
			this.grcState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcState.Width = 40;
			// 
			// grcActual
			// 
			this.grcActual.DataPropertyName = "Actual";
			this.grcActual.HeaderText = "Акт.";
			this.grcActual.Name = "grcActual";
			this.grcActual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcActual.ToolTipText = "Актуально?";
			this.grcActual.Width = 30;
			// 
			// grcCBuilding
			// 
			this.grcCBuilding.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCBuilding.DataPropertyName = "CBuilding";
			this.grcCBuilding.HeaderText = "Адрес: Здание";
			this.grcCBuilding.Name = "grcCBuilding";
			this.grcCBuilding.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCBuilding.Width = 60;
			// 
			// grcCLine
			// 
			this.grcCLine.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCLine.DataPropertyName = "CLine";
			this.grcCLine.HeaderText = "Адрес: Линия";
			this.grcCLine.Name = "grcCLine";
			this.grcCLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCLine.Width = 60;
			// 
			// grcCRack
			// 
			this.grcCRack.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCRack.DataPropertyName = "CRack";
			this.grcCRack.HeaderText = "Адрес: Стояк";
			this.grcCRack.Name = "grcCRack";
			this.grcCRack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCRack.Width = 60;
			// 
			// grcCLevel
			// 
			this.grcCLevel.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCLevel.DataPropertyName = "CLevel";
			this.grcCLevel.HeaderText = "Адрес: Уровень";
			this.grcCLevel.Name = "grcCLevel";
			this.grcCLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCLevel.Width = 60;
			// 
			// grcCPlace
			// 
			this.grcCPlace.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCPlace.DataPropertyName = "CPlace";
			this.grcCPlace.HeaderText = "Адрес: Ячейка";
			this.grcCPlace.Name = "grcCPlace";
			this.grcCPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCPlace.Width = 60;
			// 
			// grcMaxWeight
			// 
			this.grcMaxWeight.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcMaxWeight.DataPropertyName = "MaxWeight";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N0";
			dataGridViewCellStyle3.NullValue = null;
			this.grcMaxWeight.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcMaxWeight.HeaderText = "Макс.вес, кг";
			this.grcMaxWeight.Name = "grcMaxWeight";
			this.grcMaxWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcMaxWeight.ToolTipText = "Максимальная грузоподъемность ячейки, кг";
			this.grcMaxWeight.Width = 60;
			// 
			// grcCellWidth
			// 
			this.grcCellWidth.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellWidth.DataPropertyName = "CellWidth";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N3";
			dataGridViewCellStyle4.NullValue = null;
			this.grcCellWidth.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcCellWidth.HeaderText = "Ширина, м";
			this.grcCellWidth.Name = "grcCellWidth";
			this.grcCellWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellWidth.ToolTipText = "Ширина ячейки, м";
			this.grcCellWidth.Width = 60;
			// 
			// grcCellHeight
			// 
			this.grcCellHeight.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellHeight.DataPropertyName = "CellHeight";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N3";
			dataGridViewCellStyle5.NullValue = null;
			this.grcCellHeight.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcCellHeight.HeaderText = "Высота, м";
			this.grcCellHeight.Name = "grcCellHeight";
			this.grcCellHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellHeight.ToolTipText = "Высота ячейки, м";
			this.grcCellHeight.Width = 60;
			// 
			// grcPalletTypeName
			// 
			this.grcPalletTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPalletTypeName.DataPropertyName = "PalletTypeName";
			this.grcPalletTypeName.HeaderText = "Тип поддона";
			this.grcPalletTypeName.Name = "grcPalletTypeName";
			this.grcPalletTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPalletTypeName.Width = 80;
			// 
			// grcTemperatureMode
			// 
			this.grcTemperatureMode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcTemperatureMode.DataPropertyName = "TemperatureMode";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grcTemperatureMode.DefaultCellStyle = dataGridViewCellStyle6;
			this.grcTemperatureMode.HeaderText = "Т";
			this.grcTemperatureMode.Name = "grcTemperatureMode";
			this.grcTemperatureMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcTemperatureMode.ToolTipText = "Температурный режим";
			this.grcTemperatureMode.Width = 25;
			// 
			// grcLocked
			// 
			this.grcLocked.DataPropertyName = "Locked";
			this.grcLocked.HeaderText = "Блок.";
			this.grcLocked.Name = "grcLocked";
			this.grcLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.grcLocked.ToolTipText = "Ячейка блокирована?";
			this.grcLocked.Visible = false;
			this.grcLocked.Width = 30;
			// 
			// grcBufferAddress
			// 
			this.grcBufferAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBufferAddress.DataPropertyName = "BufferAddress";
			this.grcBufferAddress.HeaderText = "Буф.ячейка";
			this.grcBufferAddress.Name = "grcBufferAddress";
			this.grcBufferAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBufferAddress.Width = 80;
			// 
			// grcErpCode
			// 
			this.grcErpCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcErpCode.DataPropertyName = "ErpCode";
			this.grcErpCode.HeaderText = "ERPCode";
			this.grcErpCode.Name = "grcErpCode";
			this.grcErpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcErpCode.ToolTipText = "Код в учетной системе";
			// 
			// grcHasCellContent
			// 
			this.grcHasCellContent.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcHasCellContent.DataPropertyName = "HasCellContent";
			this.grcHasCellContent.HeaderText = "HasCellContent";
			this.grcHasCellContent.Name = "grcHasCellContent";
			this.grcHasCellContent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcHasCellContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcHasCellContent.Visible = false;
			// 
			// grcMaxPalletQnt
			// 
			this.grcMaxPalletQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcMaxPalletQnt.DataPropertyName = "MaxPalletQnt";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N2";
			this.grcMaxPalletQnt.DefaultCellStyle = dataGridViewCellStyle7;
			this.grcMaxPalletQnt.HeaderText = "Max пал. ячейка";
			this.grcMaxPalletQnt.Name = "grcMaxPalletQnt";
			this.grcMaxPalletQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcMaxPalletQnt.ToolTipText = "Максимальное число поддонов (паллет) в ячейке";
			this.grcMaxPalletQnt.Width = 80;
			// 
			// grcStoreZoneMaxPalletQnt
			// 
			this.grcStoreZoneMaxPalletQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneMaxPalletQnt.DataPropertyName = "StoreZoneMaxPalletQnt";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "N2";
			this.grcStoreZoneMaxPalletQnt.DefaultCellStyle = dataGridViewCellStyle8;
			this.grcStoreZoneMaxPalletQnt.HeaderText = "Max пал. зона";
			this.grcStoreZoneMaxPalletQnt.Name = "grcStoreZoneMaxPalletQnt";
			this.grcStoreZoneMaxPalletQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcStoreZoneMaxPalletQnt.ToolTipText = "Максимальное число поддонов (паллет) в ячейке складской зоны";
			this.grcStoreZoneMaxPalletQnt.Width = 80;
			// 
			// grcForFrames
			// 
			this.grcForFrames.DataPropertyName = "ForFrames";
			this.grcForFrames.HeaderText = "Конт.?";
			this.grcForFrames.Name = "grcForFrames";
			this.grcForFrames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcForFrames.ToolTipText = "Ячейка для контейнеров?";
			this.grcForFrames.Width = 40;
			// 
			// grcIsForFrames
			// 
			this.grcIsForFrames.DataPropertyName = "ForFrames";
			this.grcIsForFrames.HeaderText = "IsForFrames";
			this.grcIsForFrames.Name = "grcIsForFrames";
			this.grcIsForFrames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcIsForFrames.Visible = false;
			// 
			// grcStoreZoneTypeName
			// 
			this.grcStoreZoneTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneTypeName.DataPropertyName = "StoreZoneTypeName";
			this.grcStoreZoneTypeName.HeaderText = "Тип зоны";
			this.grcStoreZoneTypeName.Name = "grcStoreZoneTypeName";
			this.grcStoreZoneTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcID
			// 
			this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcID.DataPropertyName = "ID";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.grcID.DefaultCellStyle = dataGridViewCellStyle9;
			this.grcID.HeaderText = "ID";
			this.grcID.Name = "grcID";
			this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcID.ToolTipText = "Код записи";
			this.grcID.Width = 50;
			// 
			// btnMax
			// 
			this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMax.Image = global::WMSSuitable.Properties.Resources.Bottom_T;
			this.btnMax.Location = new System.Drawing.Point(488, 407);
			this.btnMax.Name = "btnMax";
			this.btnMax.Size = new System.Drawing.Size(32, 30);
			this.btnMax.TabIndex = 8;
			this.ttToolTip.SetToolTip(this.btnMax, "Сделать равным максимальному из отмеченных / из таблицы");
			this.btnMax.UseVisualStyleBackColor = true;
			this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
			// 
			// btnMin
			// 
			this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMin.Image = global::WMSSuitable.Properties.Resources.Bottom_B;
			this.btnMin.Location = new System.Drawing.Point(526, 407);
			this.btnMin.Name = "btnMin";
			this.btnMin.Size = new System.Drawing.Size(32, 30);
			this.btnMin.TabIndex = 9;
			this.ttToolTip.SetToolTip(this.btnMin, "Сделать равным минимальному из отмеченных / из таблицы");
			this.btnMin.UseVisualStyleBackColor = true;
			this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
			// 
			// btnPlus
			// 
			this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPlus.Image = global::WMSSuitable.Properties.Resources.Plus;
			this.btnPlus.Location = new System.Drawing.Point(564, 407);
			this.btnPlus.Name = "btnPlus";
			this.btnPlus.Size = new System.Drawing.Size(32, 30);
			this.btnPlus.TabIndex = 10;
			this.ttToolTip.SetToolTip(this.btnPlus, "Увеличить на 1 для всех отмеченных / для текущей ячейки");
			this.btnPlus.UseVisualStyleBackColor = true;
			this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
			// 
			// btnMinus
			// 
			this.btnMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMinus.Image = global::WMSSuitable.Properties.Resources.Minus;
			this.btnMinus.Location = new System.Drawing.Point(602, 407);
			this.btnMinus.Name = "btnMinus";
			this.btnMinus.Size = new System.Drawing.Size(32, 30);
			this.btnMinus.TabIndex = 11;
			this.ttToolTip.SetToolTip(this.btnMinus, "Уменьшить на 1 для всех отмеченных / для текущей ячейки");
			this.btnMinus.UseVisualStyleBackColor = true;
			this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
			// 
			// nudRank
			// 
			this.nudRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nudRank.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.nudRank.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.nudRank.InputMask = "######";
			this.nudRank.IsNull = false;
			this.nudRank.Location = new System.Drawing.Point(373, 411);
			this.nudRank.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.nudRank.Name = "nudRank";
			this.nudRank.RealPlaces = 6;
			this.nudRank.Size = new System.Drawing.Size(61, 22);
			this.nudRank.TabIndex = 6;
			this.nudRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnEqual
			// 
			this.btnEqual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEqual.Image = global::WMSSuitable.Properties.Resources.Equal;
			this.btnEqual.Location = new System.Drawing.Point(450, 407);
			this.btnEqual.Name = "btnEqual";
			this.btnEqual.Size = new System.Drawing.Size(32, 30);
			this.btnEqual.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.btnEqual, "Установить для всех отмеченных / для текущей ячейки");
			this.btnEqual.UseVisualStyleBackColor = true;
			this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(666, 407);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(32, 30);
			this.btnSave.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.btnSave, "Сохранить изменения");
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnAddressContextMark
			// 
			this.btnAddressContextMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddressContextMark.Image = global::WMSSuitable.Properties.Resources.Check;
			this.btnAddressContextMark.Location = new System.Drawing.Point(288, 407);
			this.btnAddressContextMark.Name = "btnAddressContextMark";
			this.btnAddressContextMark.Size = new System.Drawing.Size(32, 30);
			this.btnAddressContextMark.TabIndex = 3;
			this.ttToolTip.SetToolTip(this.btnAddressContextMark, "Отметить по маске адреса");
			this.btnAddressContextMark.UseVisualStyleBackColor = true;
			this.btnAddressContextMark.Click += new System.EventHandler(this.btnAddressContextMark_Click);
			// 
			// txtAddress
			// 
			this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAddress.Location = new System.Drawing.Point(195, 411);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(90, 22);
			this.txtAddress.TabIndex = 2;
			// 
			// lblAddressContext
			// 
			this.lblAddressContext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblAddressContext.AutoSize = true;
			this.lblAddressContext.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblAddressContext.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblAddressContext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAddressContext.Location = new System.Drawing.Point(76, 415);
			this.lblAddressContext.Name = "lblAddressContext";
			this.lblAddressContext.Size = new System.Drawing.Size(117, 14);
			this.lblAddressContext.TabIndex = 1;
			this.lblAddressContext.Text = "Отметить по маске";
			// 
			// chkClearMarkers
			// 
			this.chkClearMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkClearMarkers.AutoSize = true;
			this.chkClearMarkers.IsChanged = true;
			this.chkClearMarkers.Location = new System.Drawing.Point(10, 387);
			this.chkClearMarkers.Name = "chkClearMarkers";
			this.chkClearMarkers.Size = new System.Drawing.Size(285, 18);
			this.chkClearMarkers.TabIndex = 5;
			this.chkClearMarkers.Text = "Снимать отметки после массовых изменений";
			this.chkClearMarkers.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.chkClearMarkers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkClearMarkers.UseVisualStyleBackColor = true;
			// 
			// lblRank
			// 
			this.lblRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRank.AutoSize = true;
			this.lblRank.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblRank.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRank.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblRank.Location = new System.Drawing.Point(347, 389);
			this.lblRank.Name = "lblRank";
			this.lblRank.Size = new System.Drawing.Size(104, 14);
			this.lblRank.TabIndex = 4;
			this.lblRank.Text = "Установить ранг:";
			// 
			// frmCellsReorder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(744, 444);
			this.Controls.Add(this.lblRank);
			this.Controls.Add(this.chkClearMarkers);
			this.Controls.Add(this.lblAddressContext);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.btnAddressContextMark);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnEqual);
			this.Controls.Add(this.nudRank);
			this.Controls.Add(this.btnMinus);
			this.Controls.Add(this.btnPlus);
			this.Controls.Add(this.btnMin);
			this.Controls.Add(this.btnMax);
			this.Controls.Add(this.cntCells);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Name = "frmCellsReorder";
			this.Text = "Порядок обхода ячеек";
			this.Load += new System.EventHandler(this.frmCellsReorder_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCellsReorder_KeyDown);
			this.cntCells.Panel1.ResumeLayout(false);
			this.cntCells.Panel1.PerformLayout();
			this.cntCells.Panel2.ResumeLayout(false);
			this.cntCells.ResumeLayout(false);
			this.uctZones.ResumeLayout(false);
			this.uctZones.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCells)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRank)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMSplitContainer cntCells;
		private RFMBaseClasses.RFMTreeView trvCells;
		private RFMBaseClasses.RFMButton btnGrid;
		private RFMBaseClasses.RFMSelectRecordIDGridEx uctZones;
		private RFMBaseClasses.RFMButton btnMax;
		private RFMBaseClasses.RFMButton btnMin;
		private RFMBaseClasses.RFMButton btnPlus;
		private RFMBaseClasses.RFMButton btnMinus;
		private RFMBaseClasses.RFMNumericUpDown nudRank;
		private RFMBaseClasses.RFMButton btnEqual;
		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMCheckBox chkCellsActual;
		private RFMBaseClasses.RFMDataGridView dgvCells;
		private RFMBaseClasses.RFMButton btnAddressContextMark;
		private RFMBaseClasses.RFMTextBox txtAddress;
		private RFMBaseClasses.RFMLabel lblAddressContext;
		private RFMBaseClasses.RFMCheckBox chkClearMarkers;
		private RFMBaseClasses.RFMLabel lblRank;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcIsRankChanged;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcCellStateImage;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcLockedImage;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn grcRank;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFixedPackingAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFixedOwnerName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFixedGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcState;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcActual;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCBuilding;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCLine;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCRack;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCLevel;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCPlace;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMaxWeight;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellWidth;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellHeight;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalletTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcTemperatureMode;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcLocked;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBufferAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcErpCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcHasCellContent;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMaxPalletQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneMaxPalletQnt;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcForFrames;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcIsForFrames;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;
	}
}