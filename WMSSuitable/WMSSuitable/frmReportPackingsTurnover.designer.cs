namespace WMSSuitable
{
	partial class frmReportPackingsTurnover 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPackingsTurnover));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.pnlSelectConditions = new RFMBaseClasses.RFMPanel();
            this.numInBox = new RFMBaseClasses.RFMNumericUpDown();
            this.txtGoodStateName = new RFMBaseClasses.RFMTextBox();
            this.txtGoodAlias = new RFMBaseClasses.RFMTextBox();
            this.txtOwnerName = new RFMBaseClasses.RFMTextBox();
            this.lblInBox = new RFMBaseClasses.RFMLabel();
            this.lblGoodStateName = new RFMBaseClasses.RFMLabel();
            this.lblOwnerName = new RFMBaseClasses.RFMLabel();
            this.pnlTerms = new RFMBaseClasses.RFMPanel();
            this.btnFilter = new RFMBaseClasses.RFMButton();
            this.dtrDates = new RFMBaseClasses.RFMDateRange();
            this.lblQntBeg = new RFMBaseClasses.RFMLabel();
            this.numQntBeg = new RFMBaseClasses.RFMNumericUpDown();
            this.numQntEnd = new RFMBaseClasses.RFMNumericUpDown();
            this.lblQntEnd = new RFMBaseClasses.RFMLabel();
            this.grcTypeImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
            this.grcDateOper = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOperName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPartnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntPlus = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntMinus = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcNote = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOperType = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.pnlSelectConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInBox)).BeginInit();
            this.pnlTerms.SuspendLayout();
            this.dtrDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQntBeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntEnd)).BeginInit();
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
            this.grcTypeImage,
            this.grcDateOper,
            this.grcOperName,
            this.grcPartnerName,
            this.grcQntPlus,
            this.grcQntMinus,
            this.grcNote,
            this.grcBarCode,
            this.grcOperType,
            this.grcID});
            this.grdData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.IsStatusInclude = true;
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(5, 138);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.SystemColors.Control;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Black;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdData.Size = new System.Drawing.Size(542, 264);
            this.grdData.TabIndex = 1;
            this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
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
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(513, 437);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 30);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlSelectConditions
            // 
            this.pnlSelectConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSelectConditions.Controls.Add(this.numInBox);
            this.pnlSelectConditions.Controls.Add(this.txtGoodStateName);
            this.pnlSelectConditions.Controls.Add(this.txtGoodAlias);
            this.pnlSelectConditions.Controls.Add(this.txtOwnerName);
            this.pnlSelectConditions.Controls.Add(this.lblInBox);
            this.pnlSelectConditions.Controls.Add(this.lblGoodStateName);
            this.pnlSelectConditions.Controls.Add(this.lblOwnerName);
            this.pnlSelectConditions.Location = new System.Drawing.Point(5, 6);
            this.pnlSelectConditions.Name = "pnlSelectConditions";
            this.pnlSelectConditions.Size = new System.Drawing.Size(542, 57);
            this.pnlSelectConditions.TabIndex = 9;
            // 
            // numInBox
            // 
            this.numInBox.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numInBox.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numInBox.Enabled = false;
            this.numInBox.InputMask = "##########";
            this.numInBox.IsNull = false;
            this.numInBox.Location = new System.Drawing.Point(457, 3);
            this.numInBox.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numInBox.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numInBox.Name = "numInBox";
            this.numInBox.RealPlaces = 10;
            this.numInBox.Size = new System.Drawing.Size(78, 22);
            this.numInBox.TabIndex = 39;
            this.numInBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGoodStateName
            // 
            this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGoodStateName.Enabled = false;
            this.txtGoodStateName.Location = new System.Drawing.Point(411, 29);
            this.txtGoodStateName.Name = "txtGoodStateName";
            this.txtGoodStateName.Size = new System.Drawing.Size(124, 22);
            this.txtGoodStateName.TabIndex = 38;
            // 
            // txtGoodAlias
            // 
            this.txtGoodAlias.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtGoodAlias.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGoodAlias.Enabled = false;
            this.txtGoodAlias.Location = new System.Drawing.Point(3, 3);
            this.txtGoodAlias.Name = "txtGoodAlias";
            this.txtGoodAlias.Size = new System.Drawing.Size(409, 22);
            this.txtGoodAlias.TabIndex = 37;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwnerName.Enabled = false;
            this.txtOwnerName.Location = new System.Drawing.Point(142, 29);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(176, 22);
            this.txtOwnerName.TabIndex = 36;
            // 
            // lblInBox
            // 
            this.lblInBox.AutoSize = true;
            this.lblInBox.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInBox.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInBox.Location = new System.Drawing.Point(418, 6);
            this.lblInBox.Name = "lblInBox";
            this.lblInBox.Size = new System.Drawing.Size(41, 14);
            this.lblInBox.TabIndex = 31;
            this.lblInBox.Text = "в кор.";
            // 
            // lblGoodStateName
            // 
            this.lblGoodStateName.AutoSize = true;
            this.lblGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodStateName.Location = new System.Drawing.Point(337, 32);
            this.lblGoodStateName.Name = "lblGoodStateName";
            this.lblGoodStateName.Size = new System.Drawing.Size(68, 14);
            this.lblGoodStateName.TabIndex = 30;
            this.lblGoodStateName.Text = "Состояние";
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.AutoSize = true;
            this.lblOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwnerName.Location = new System.Drawing.Point(5, 32);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(134, 14);
            this.lblOwnerName.TabIndex = 28;
            this.lblOwnerName.Text = "Хранитель / владелец";
            // 
            // pnlTerms
            // 
            this.pnlTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTerms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTerms.Controls.Add(this.btnFilter);
            this.pnlTerms.Controls.Add(this.dtrDates);
            this.pnlTerms.Location = new System.Drawing.Point(5, 65);
            this.pnlTerms.Name = "pnlTerms";
            this.pnlTerms.Size = new System.Drawing.Size(542, 39);
            this.pnlTerms.TabIndex = 40;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnFilter.Location = new System.Drawing.Point(505, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(30, 30);
            this.btnFilter.TabIndex = 44;
            this.ttToolTip.SetToolTip(this.btnFilter, "Получить движение по товару");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtrDates
            // 
            this.dtrDates.BegValue = new System.DateTime(2007, 8, 16, 0, 0, 0, 0);
            // 
            // dtrDates.btnClear
            // 
            this.dtrDates.BtnСlear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dtrDates.BtnСlear.Image = ((System.Drawing.Image)(resources.GetObject("dtrDates.btnClear.Image")));
            this.dtrDates.BtnСlear.Location = new System.Drawing.Point(206, 4);
            this.dtrDates.BtnСlear.Name = "btnClear";
            this.dtrDates.BtnСlear.Size = new System.Drawing.Size(26, 24);
            this.dtrDates.BtnСlear.TabIndex = 3;
            this.dtrDates.BtnСlear.UseVisualStyleBackColor = true;
            // 
            // dtrDates.dtpBegDate
            // 
            this.dtrDates.DtpBegDate.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtrDates.DtpBegDate.CustomFormat = "dd.MM.yyyy";
            this.dtrDates.DtpBegDate.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtrDates.DtpBegDate.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtrDates.DtpBegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtrDates.DtpBegDate.Location = new System.Drawing.Point(4, 5);
            this.dtrDates.DtpBegDate.Name = "dtpBegDate";
            this.dtrDates.DtpBegDate.Size = new System.Drawing.Size(90, 22);
            this.dtrDates.DtpBegDate.TabIndex = 0;
            // 
            // dtrDates.dtpEndDate
            // 
            this.dtrDates.DtpEndDate.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtrDates.DtpEndDate.CustomFormat = "dd.MM.yyyy";
            this.dtrDates.DtpEndDate.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtrDates.DtpEndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtrDates.DtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtrDates.DtpEndDate.Location = new System.Drawing.Point(111, 5);
            this.dtrDates.DtpEndDate.Name = "dtpEndDate";
            this.dtrDates.DtpEndDate.Size = new System.Drawing.Size(90, 22);
            this.dtrDates.DtpEndDate.TabIndex = 2;
            this.dtrDates.EndValue = new System.DateTime(2007, 8, 16, 0, 0, 0, 0);
            this.dtrDates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // dtrDates.lblDelimiter
            // 
            this.dtrDates.LblDelimiter.AutoSize = true;
            this.dtrDates.LblDelimiter.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtrDates.LblDelimiter.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtrDates.LblDelimiter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtrDates.LblDelimiter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtrDates.LblDelimiter.Location = new System.Drawing.Point(97, 8);
            this.dtrDates.LblDelimiter.Name = "lblDelimiter";
            this.dtrDates.LblDelimiter.Size = new System.Drawing.Size(13, 16);
            this.dtrDates.LblDelimiter.TabIndex = 1;
            this.dtrDates.LblDelimiter.Text = ":";
            this.dtrDates.Location = new System.Drawing.Point(3, 2);
            this.dtrDates.Name = "dtrDates";
            this.dtrDates.Size = new System.Drawing.Size(238, 32);
            this.dtrDates.TabIndex = 43;
            // 
            // lblQntBeg
            // 
            this.lblQntBeg.AutoSize = true;
            this.lblQntBeg.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblQntBeg.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblQntBeg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQntBeg.Location = new System.Drawing.Point(12, 114);
            this.lblQntBeg.Name = "lblQntBeg";
            this.lblQntBeg.Size = new System.Drawing.Size(191, 14);
            this.lblQntBeg.TabIndex = 41;
            this.lblQntBeg.Text = "Количество на начало периода:";
            // 
            // numQntBeg
            // 
            this.numQntBeg.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numQntBeg.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numQntBeg.Enabled = false;
            this.numQntBeg.InputMask = "##########";
            this.numQntBeg.IsNull = false;
            this.numQntBeg.Location = new System.Drawing.Point(215, 110);
            this.numQntBeg.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numQntBeg.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numQntBeg.Name = "numQntBeg";
            this.numQntBeg.RealPlaces = 10;
            this.numQntBeg.Size = new System.Drawing.Size(110, 22);
            this.numQntBeg.TabIndex = 42;
            this.numQntBeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQntBeg.ThousandsSeparator = true;
            // 
            // numQntEnd
            // 
            this.numQntEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numQntEnd.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numQntEnd.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numQntEnd.Enabled = false;
            this.numQntEnd.InputMask = "##########";
            this.numQntEnd.IsNull = false;
            this.numQntEnd.Location = new System.Drawing.Point(215, 410);
            this.numQntEnd.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numQntEnd.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numQntEnd.Name = "numQntEnd";
            this.numQntEnd.RealPlaces = 10;
            this.numQntEnd.Size = new System.Drawing.Size(110, 22);
            this.numQntEnd.TabIndex = 44;
            this.numQntEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQntEnd.ThousandsSeparator = true;
            // 
            // lblQntEnd
            // 
            this.lblQntEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQntEnd.AutoSize = true;
            this.lblQntEnd.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblQntEnd.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblQntEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQntEnd.Location = new System.Drawing.Point(12, 412);
            this.lblQntEnd.Name = "lblQntEnd";
            this.lblQntEnd.Size = new System.Drawing.Size(185, 14);
            this.lblQntEnd.TabIndex = 43;
            this.lblQntEnd.Text = "Количество на конец периода:";
            // 
            // grcTypeImage
            // 
            this.grcTypeImage.HeaderText = "";
            this.grcTypeImage.Name = "grcTypeImage";
            this.grcTypeImage.ReadOnly = true;
            this.grcTypeImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcTypeImage.Width = 30;
            // 
            // grcDateOper
            // 
            this.grcDateOper.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateOper.DataPropertyName = "DateOper";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.grcDateOper.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcDateOper.HeaderText = "Дата";
            this.grcDateOper.Name = "grcDateOper";
            this.grcDateOper.ReadOnly = true;
            this.grcDateOper.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateOper.Width = 80;
            // 
            // grcOperName
            // 
            this.grcOperName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOperName.DataPropertyName = "OperName";
            this.grcOperName.HeaderText = "Операция";
            this.grcOperName.Name = "grcOperName";
            this.grcOperName.ReadOnly = true;
            this.grcOperName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcOperName.Width = 65;
            // 
            // grcPartnerName
            // 
            this.grcPartnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPartnerName.DataPropertyName = "PartnerName";
            this.grcPartnerName.HeaderText = "Контрагент";
            this.grcPartnerName.Name = "grcPartnerName";
            this.grcPartnerName.ReadOnly = true;
            this.grcPartnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPartnerName.Width = 250;
            // 
            // grcQntPlus
            // 
            this.grcQntPlus.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntPlus.DataPropertyName = "QntPlus";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.grcQntPlus.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcQntPlus.HeaderText = "Приход";
            this.grcQntPlus.Name = "grcQntPlus";
            this.grcQntPlus.ReadOnly = true;
            this.grcQntPlus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntPlus.ToolTipText = "Количество поступившего товара, штук";
            this.grcQntPlus.Width = 90;
            // 
            // grcQntMinus
            // 
            this.grcQntMinus.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntMinus.DataPropertyName = "QntMinus";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.grcQntMinus.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcQntMinus.HeaderText = "Расход";
            this.grcQntMinus.Name = "grcQntMinus";
            this.grcQntMinus.ReadOnly = true;
            this.grcQntMinus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntMinus.ToolTipText = "Количество израсходованного товара, штук";
            this.grcQntMinus.Width = 90;
            // 
            // grcNote
            // 
            this.grcNote.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcNote.DataPropertyName = "Note";
            this.grcNote.HeaderText = "Примечание";
            this.grcNote.Name = "grcNote";
            this.grcNote.ReadOnly = true;
            this.grcNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcNote.Width = 200;
            // 
            // grcBarCode
            // 
            this.grcBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBarCode.DataPropertyName = "BarCode";
            this.grcBarCode.HeaderText = "ШК операции";
            this.grcBarCode.Name = "grcBarCode";
            this.grcBarCode.ReadOnly = true;
            this.grcBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBarCode.ToolTipText = "Штрих-код операции";
            this.grcBarCode.Width = 130;
            // 
            // grcOperType
            // 
            this.grcOperType.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOperType.DataPropertyName = "OperType";
            this.grcOperType.HeaderText = "OperType";
            this.grcOperType.Name = "grcOperType";
            this.grcOperType.ReadOnly = true;
            this.grcOperType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcOperType.Visible = false;
            // 
            // grcID
            // 
            this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcID.DataPropertyName = "OperID";
            this.grcID.HeaderText = "ID";
            this.grcID.Name = "grcID";
            this.grcID.ReadOnly = true;
            this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcID.Width = 60;
            // 
            // frmReportPackingsTurnover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 473);
            this.Controls.Add(this.numQntEnd);
            this.Controls.Add(this.lblQntEnd);
            this.Controls.Add(this.numQntBeg);
            this.Controls.Add(this.lblQntBeg);
            this.Controls.Add(this.pnlTerms);
            this.Controls.Add(this.pnlSelectConditions);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grdData);
            this.hpHelp.SetHelpKeyword(this, "1023");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportPackingsTurnover";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Операции с товаром";
            this.Load += new System.EventHandler(this.frmReportPackingsTurnover_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.pnlSelectConditions.ResumeLayout(false);
            this.pnlSelectConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInBox)).EndInit();
            this.pnlTerms.ResumeLayout(false);
            this.dtrDates.ResumeLayout(false);
            this.dtrDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQntBeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQntEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlSelectConditions;
		private RFMBaseClasses.RFMNumericUpDown numInBox;
		private RFMBaseClasses.RFMTextBox txtGoodStateName;
		private RFMBaseClasses.RFMTextBox txtGoodAlias;
		private RFMBaseClasses.RFMTextBox txtOwnerName;
		private RFMBaseClasses.RFMLabel lblInBox;
		private RFMBaseClasses.RFMLabel lblGoodStateName;
		private RFMBaseClasses.RFMLabel lblOwnerName;
		private RFMBaseClasses.RFMPanel pnlTerms;
		private RFMBaseClasses.RFMDateRange dtrDates;
		private RFMBaseClasses.RFMButton btnFilter;
		private RFMBaseClasses.RFMLabel lblQntBeg;
		private RFMBaseClasses.RFMNumericUpDown numQntBeg;
		private RFMBaseClasses.RFMNumericUpDown numQntEnd;
        private RFMBaseClasses.RFMLabel lblQntEnd;
        private RFMBaseClasses.RFMDataGridViewImageColumn grcTypeImage;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateOper;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOperName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPartnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntPlus;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntMinus;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNote;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBarCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOperType;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;
	}
}

