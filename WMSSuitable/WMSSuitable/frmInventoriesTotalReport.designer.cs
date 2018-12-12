namespace WMSSuitable
{
	partial class frmInventoriesTotalReport
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.grdData = new RFMBaseClasses.RFMDataGridView();
			this.pnlPackings = new RFMBaseClasses.RFMPanel();
			this.txtPackingsChoosen = new RFMBaseClasses.RFMTextBox();
			this.btnPackingsClear = new RFMBaseClasses.RFMButton();
			this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
			this.lblPackings = new RFMBaseClasses.RFMLabel();
			this.pnlTerms = new RFMBaseClasses.RFMPanel();
			this.chkDiffOnly = new RFMBaseClasses.RFMCheckBox();
			this.btnRestore = new RFMBaseClasses.RFMButton();
			this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcArticul = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxDiff = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcPackingActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcQntWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQntConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQntDiff = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.pnlPackings.SuspendLayout();
			this.pnlTerms.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 388);
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
			this.btnExit.Location = new System.Drawing.Point(704, 388);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 7;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.grcInBox,
            this.grcArticul,
            this.grcGoodBarCode,
            this.grcBoxWished,
            this.grcBoxConfirmed,
            this.grcBoxDiff,
            this.grcGoodStateName,
            this.grcOwnerName,
            this.grcWeighting,
            this.grcGoodGroupName,
            this.grcGoodBrandName,
            this.grcGoodActual,
            this.grcPackingActual,
            this.grcQntWished,
            this.grcQntConfirmed,
            this.grcQntDiff,
            this.grcGoodName});
			this.grdData.IsConfigInclude = true;
			this.grdData.IsMarkedAll = false;
			this.grdData.IsStatusInclude = true;
			this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdData.Location = new System.Drawing.Point(3, 44);
			this.grdData.MultiSelect = false;
			this.grdData.Name = "grdData";
			this.grdData.RangedWay = ' ';
			this.grdData.ReadOnly = true;
			this.grdData.RowHeadersWidth = 24;
			this.grdData.Size = new System.Drawing.Size(736, 339);
			this.grdData.TabIndex = 9;
			this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
			// 
			// pnlPackings
			// 
			this.pnlPackings.Controls.Add(this.txtPackingsChoosen);
			this.pnlPackings.Controls.Add(this.btnPackingsClear);
			this.pnlPackings.Controls.Add(this.btnPackingsChoose);
			this.pnlPackings.Location = new System.Drawing.Point(58, 2);
			this.pnlPackings.Name = "pnlPackings";
			this.pnlPackings.Size = new System.Drawing.Size(366, 30);
			this.pnlPackings.TabIndex = 23;
			// 
			// txtPackingsChoosen
			// 
			this.txtPackingsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPackingsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackingsChoosen.Enabled = false;
			this.txtPackingsChoosen.Location = new System.Drawing.Point(2, 4);
			this.txtPackingsChoosen.Name = "txtPackingsChoosen";
			this.txtPackingsChoosen.OldValue = "";
			this.txtPackingsChoosen.Size = new System.Drawing.Size(306, 22);
			this.txtPackingsChoosen.TabIndex = 0;
			this.ttToolTip.SetToolTip(this.txtPackingsChoosen, "Выбранные товары");
			// 
			// btnPackingsClear
			// 
			this.btnPackingsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnPackingsClear.Location = new System.Drawing.Point(338, 3);
			this.btnPackingsClear.Name = "btnPackingsClear";
			this.btnPackingsClear.Size = new System.Drawing.Size(26, 24);
			this.btnPackingsClear.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.btnPackingsClear, "Очистить выбор товаров");
			this.btnPackingsClear.UseVisualStyleBackColor = true;
			this.btnPackingsClear.Click += new System.EventHandler(this.btnPackingsClear_Click);
			// 
			// btnPackingsChoose
			// 
			this.btnPackingsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackingsChoose.Location = new System.Drawing.Point(310, 3);
			this.btnPackingsChoose.Name = "btnPackingsChoose";
			this.btnPackingsChoose.Size = new System.Drawing.Size(26, 24);
			this.btnPackingsChoose.TabIndex = 1;
			this.ttToolTip.SetToolTip(this.btnPackingsChoose, "Выбор товаров");
			this.btnPackingsChoose.UseVisualStyleBackColor = true;
			this.btnPackingsChoose.Click += new System.EventHandler(this.btnPackingsChoose_Click);
			// 
			// lblPackings
			// 
			this.lblPackings.AutoSize = true;
			this.lblPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPackings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPackings.Location = new System.Drawing.Point(3, 10);
			this.lblPackings.Name = "lblPackings";
			this.lblPackings.Size = new System.Drawing.Size(49, 14);
			this.lblPackings.TabIndex = 22;
			this.lblPackings.Text = "Товары";
			// 
			// pnlTerms
			// 
			this.pnlTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlTerms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlTerms.Controls.Add(this.chkDiffOnly);
			this.pnlTerms.Controls.Add(this.btnRestore);
			this.pnlTerms.Controls.Add(this.lblPackings);
			this.pnlTerms.Controls.Add(this.pnlPackings);
			this.pnlTerms.Location = new System.Drawing.Point(3, 4);
			this.pnlTerms.Name = "pnlTerms";
			this.pnlTerms.Size = new System.Drawing.Size(736, 37);
			this.pnlTerms.TabIndex = 24;
			// 
			// chkDiffOnly
			// 
			this.chkDiffOnly.AutoSize = true;
			this.chkDiffOnly.Location = new System.Drawing.Point(502, 9);
			this.chkDiffOnly.Name = "chkDiffOnly";
			this.chkDiffOnly.Size = new System.Drawing.Size(146, 18);
			this.chkDiffOnly.TabIndex = 25;
			this.chkDiffOnly.Text = "только расхождения";
			this.chkDiffOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkDiffOnly.UseVisualStyleBackColor = true;
			// 
			// btnRestore
			// 
			this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRestore.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnRestore.Location = new System.Drawing.Point(699, 2);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.Size = new System.Drawing.Size(32, 30);
			this.btnRestore.TabIndex = 24;
			this.ttToolTip.SetToolTip(this.btnRestore, "Вывести список товаров");
			this.btnRestore.UseVisualStyleBackColor = true;
			this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
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
			this.grcInBox.Width = 50;
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
			this.grcGoodBarCode.HeaderText = "Штрих-код";
			this.grcGoodBarCode.Name = "grcGoodBarCode";
			this.grcGoodBarCode.ReadOnly = true;
			this.grcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodBarCode.ToolTipText = "Штрих-код товара";
			this.grcGoodBarCode.Width = 120;
			// 
			// grcBoxWished
			// 
			this.grcBoxWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxWished.DataPropertyName = "BoxWished";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N1";
			this.grcBoxWished.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcBoxWished.HeaderText = "Кор.До";
			this.grcBoxWished.Name = "grcBoxWished";
			this.grcBoxWished.ReadOnly = true;
			this.grcBoxWished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcBoxWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxWished.ToolTipText = "Количество коробок до ревизии";
			this.grcBoxWished.Width = 80;
			// 
			// grcBoxConfirmed
			// 
			this.grcBoxConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxConfirmed.DataPropertyName = "BoxConfirmed";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N1";
			this.grcBoxConfirmed.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcBoxConfirmed.HeaderText = "Кор.Факт";
			this.grcBoxConfirmed.Name = "grcBoxConfirmed";
			this.grcBoxConfirmed.ReadOnly = true;
			this.grcBoxConfirmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcBoxConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxConfirmed.ToolTipText = "Количество коробок фактическое";
			this.grcBoxConfirmed.Width = 80;
			// 
			// grcBoxDiff
			// 
			this.grcBoxDiff.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxDiff.DataPropertyName = "BoxDiff";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N1";
			this.grcBoxDiff.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcBoxDiff.HeaderText = "Кор.РАЗН.";
			this.grcBoxDiff.Name = "grcBoxDiff";
			this.grcBoxDiff.ReadOnly = true;
			this.grcBoxDiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxDiff.ToolTipText = "Разница в количестве коробок (Факт - До)";
			this.grcBoxDiff.Width = 80;
			// 
			// grcGoodStateName
			// 
			this.grcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodStateName.DataPropertyName = "GoodStateName";
			this.grcGoodStateName.HeaderText = "Состояние";
			this.grcGoodStateName.Name = "grcGoodStateName";
			this.grcGoodStateName.ReadOnly = true;
			this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcOwnerName
			// 
			this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcOwnerName.DataPropertyName = "OwnerName";
			this.grcOwnerName.HeaderText = "Хранитель";
			this.grcOwnerName.Name = "grcOwnerName";
			this.grcOwnerName.ReadOnly = true;
			this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
			// grcGoodActual
			// 
			this.grcGoodActual.DataPropertyName = "GoodActual";
			this.grcGoodActual.HeaderText = "Акт.Товар";
			this.grcGoodActual.Name = "grcGoodActual";
			this.grcGoodActual.ReadOnly = true;
			this.grcGoodActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodActual.ToolTipText = "Товар актуален?";
			this.grcGoodActual.Width = 60;
			// 
			// grcPackingActual
			// 
			this.grcPackingActual.DataPropertyName = "PackingActual";
			this.grcPackingActual.HeaderText = "Акт.Упак.";
			this.grcPackingActual.Name = "grcPackingActual";
			this.grcPackingActual.ReadOnly = true;
			this.grcPackingActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingActual.ToolTipText = "Упаковка актуальна?";
			this.grcPackingActual.Width = 60;
			// 
			// grcQntWished
			// 
			this.grcQntWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQntWished.DataPropertyName = "QntWished";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N0";
			this.grcQntWished.DefaultCellStyle = dataGridViewCellStyle6;
			this.grcQntWished.HeaderText = "Штук До";
			this.grcQntWished.Name = "grcQntWished";
			this.grcQntWished.ReadOnly = true;
			this.grcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQntWished.ToolTipText = "Количество штук/кг до ревизии";
			this.grcQntWished.Width = 90;
			// 
			// grcQntConfirmed
			// 
			this.grcQntConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQntConfirmed.DataPropertyName = "QntConfirmed";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N0";
			this.grcQntConfirmed.DefaultCellStyle = dataGridViewCellStyle7;
			this.grcQntConfirmed.HeaderText = "Штук Факт";
			this.grcQntConfirmed.Name = "grcQntConfirmed";
			this.grcQntConfirmed.ReadOnly = true;
			this.grcQntConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQntConfirmed.ToolTipText = "Количество штук/кг фактическое";
			this.grcQntConfirmed.Width = 90;
			// 
			// grcQntDiff
			// 
			this.grcQntDiff.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQntDiff.DataPropertyName = "QntDiff";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "N0";
			this.grcQntDiff.DefaultCellStyle = dataGridViewCellStyle8;
			this.grcQntDiff.HeaderText = "Штук РАЗН.";
			this.grcQntDiff.Name = "grcQntDiff";
			this.grcQntDiff.ReadOnly = true;
			this.grcQntDiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQntDiff.ToolTipText = "Разница в количестве штук/кг (Факт - До)";
			this.grcQntDiff.Width = 90;
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
			// frmInventoriesTotalReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 423);
			this.Controls.Add(this.pnlTerms);
			this.Controls.Add(this.grdData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.hpHelp.SetHelpKeyword(this, "221");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MinimizeBox = false;
			this.Name = "frmInventoriesTotalReport";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Товары в ревизиях";
			this.Load += new System.EventHandler(this.frmInventoriesTotalReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.pnlPackings.ResumeLayout(false);
			this.pnlPackings.PerformLayout();
			this.pnlTerms.ResumeLayout(false);
			this.pnlTerms.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMPanel pnlPackings;
		private RFMBaseClasses.RFMTextBox txtPackingsChoosen;
		private RFMBaseClasses.RFMButton btnPackingsClear;
		private RFMBaseClasses.RFMButton btnPackingsChoose;
		private RFMBaseClasses.RFMLabel lblPackings;
		private RFMBaseClasses.RFMPanel pnlTerms;
		private RFMBaseClasses.RFMButton btnRestore;
		private RFMBaseClasses.RFMCheckBox chkDiffOnly;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcArticul;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxDiff;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBrandName;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcGoodActual;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcPackingActual;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntDiff;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodName;
	}
}

