namespace WMSSuitable
{
	partial class frmTrafficsFramesForPickingCreate
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
            this.pnlData = new RFMBaseClasses.RFMPanel();
            this.lblBoxQnt = new RFMBaseClasses.RFMLabel();
            this.cboCellOutput = new RFMBaseClasses.RFMComboBox();
            this.chkForOutput = new RFMBaseClasses.RFMCheckBox();
            this.btnClear = new RFMBaseClasses.RFMButton();
            this.btnFilter = new RFMBaseClasses.RFMButton();
            this.dtpDateValid = new RFMBaseClasses.RFMDateTimePicker();
            this.lblDateValidMin = new RFMBaseClasses.RFMLabel();
            this.lblFramesCnt = new RFMBaseClasses.RFMLabel();
            this.btnOwnerClear = new RFMBaseClasses.RFMButton();
            this.cboOwner = new RFMBaseClasses.RFMComboBox();
            this.lblOwner = new RFMBaseClasses.RFMLabel();
            this.cboGoodState = new RFMBaseClasses.RFMComboBox();
            this.lblGoodState = new RFMBaseClasses.RFMLabel();
            this.btnPackings = new RFMBaseClasses.RFMButton();
            this.lblGoodNew = new RFMBaseClasses.RFMLabel();
            this.txtGood = new RFMBaseClasses.RFMTextBox();
            this.numFramesCnt = new RFMBaseClasses.RFMNumericUpDown();
            this.chkDateValidControl = new RFMBaseClasses.RFMCheckBox();
            this.btnGo = new RFMBaseClasses.RFMButton();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.lblNoteManual = new RFMBaseClasses.RFMLabel();
            this.txtNoteManual = new RFMBaseClasses.RFMTextBox();
            this.grcLockedImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
            this.grcFrameID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcCellAddess = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcFrameHeight = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcFrameWeight = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcFrameState = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcLocked = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcStoreZoneTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateLastOperation = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcCellBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcFrameBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFramesCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.lblBoxQnt);
            this.pnlData.Controls.Add(this.cboCellOutput);
            this.pnlData.Controls.Add(this.chkForOutput);
            this.pnlData.Controls.Add(this.btnClear);
            this.pnlData.Controls.Add(this.btnFilter);
            this.pnlData.Controls.Add(this.dtpDateValid);
            this.pnlData.Controls.Add(this.lblDateValidMin);
            this.pnlData.Controls.Add(this.lblFramesCnt);
            this.pnlData.Controls.Add(this.btnOwnerClear);
            this.pnlData.Controls.Add(this.cboOwner);
            this.pnlData.Controls.Add(this.lblOwner);
            this.pnlData.Controls.Add(this.cboGoodState);
            this.pnlData.Controls.Add(this.lblGoodState);
            this.pnlData.Controls.Add(this.btnPackings);
            this.pnlData.Controls.Add(this.lblGoodNew);
            this.pnlData.Controls.Add(this.txtGood);
            this.pnlData.Controls.Add(this.numFramesCnt);
            this.pnlData.Controls.Add(this.chkDateValidControl);
            this.pnlData.Location = new System.Drawing.Point(4, 4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(584, 121);
            this.pnlData.TabIndex = 0;
            // 
            // lblBoxQnt
            // 
            this.lblBoxQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblBoxQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBoxQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBoxQnt.Location = new System.Drawing.Point(134, 61);
            this.lblBoxQnt.Name = "lblBoxQnt";
            this.lblBoxQnt.Size = new System.Drawing.Size(102, 14);
            this.lblBoxQnt.TabIndex = 85;
            this.lblBoxQnt.Text = "#Box#";
            // 
            // cboCellOutput
            // 
            this.cboCellOutput.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboCellOutput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboCellOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCellOutput.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboCellOutput.Location = new System.Drawing.Point(150, 89);
            this.cboCellOutput.Name = "cboCellOutput";
            this.cboCellOutput.Size = new System.Drawing.Size(170, 22);
            this.cboCellOutput.TabIndex = 84;
            // 
            // chkForOutput
            // 
            this.chkForOutput.AutoSize = true;
            this.chkForOutput.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkForOutput.Location = new System.Drawing.Point(9, 91);
            this.chkForOutput.Name = "chkForOutput";
            this.chkForOutput.Size = new System.Drawing.Size(139, 18);
            this.chkForOutput.TabIndex = 83;
            this.chkForOutput.Text = "в ячейку отгрузки";
            this.chkForOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkForOutput.UseVisualStyleBackColor = true;
            this.chkForOutput.CheckedChanged += new System.EventHandler(this.chkForOutput_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnClear.Location = new System.Drawing.Point(546, 84);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 30);
            this.btnClear.TabIndex = 82;
            this.ttToolTip.SetToolTip(this.btnClear, "Очистить условия");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnFilter.Location = new System.Drawing.Point(506, 84);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(30, 30);
            this.btnFilter.TabIndex = 81;
            this.ttToolTip.SetToolTip(this.btnFilter, "Показать контейнеры");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpDateValid
            // 
            this.dtpDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateValid.CustomFormat = "dd.MM.yyyy";
            this.dtpDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtpDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpDateValid.Enabled = false;
            this.dtpDateValid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateValid.Location = new System.Drawing.Point(476, 57);
            this.dtpDateValid.Name = "dtpDateValid";
            this.dtpDateValid.Size = new System.Drawing.Size(100, 22);
            this.dtpDateValid.TabIndex = 80;
            // 
            // lblDateValidMin
            // 
            this.lblDateValidMin.AutoSize = true;
            this.lblDateValidMin.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateValidMin.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateValidMin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateValidMin.Location = new System.Drawing.Point(411, 61);
            this.lblDateValidMin.Name = "lblDateValidMin";
            this.lblDateValidMin.Size = new System.Drawing.Size(61, 14);
            this.lblDateValidMin.TabIndex = 79;
            this.lblDateValidMin.Text = "не менее";
            // 
            // lblFramesCnt
            // 
            this.lblFramesCnt.AutoSize = true;
            this.lblFramesCnt.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblFramesCnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFramesCnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFramesCnt.Location = new System.Drawing.Point(6, 61);
            this.lblFramesCnt.Name = "lblFramesCnt";
            this.lblFramesCnt.Size = new System.Drawing.Size(63, 14);
            this.lblFramesCnt.TabIndex = 78;
            this.lblFramesCnt.Text = "Поддонов";
            // 
            // btnOwnerClear
            // 
            this.btnOwnerClear.FlatAppearance.BorderSize = 0;
            this.btnOwnerClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOwnerClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnOwnerClear.Location = new System.Drawing.Point(252, 4);
            this.btnOwnerClear.Name = "btnOwnerClear";
            this.btnOwnerClear.Size = new System.Drawing.Size(25, 25);
            this.btnOwnerClear.TabIndex = 77;
            this.ttToolTip.SetToolTip(this.btnOwnerClear, "Очистить данные о хранителе");
            this.btnOwnerClear.UseVisualStyleBackColor = true;
            this.btnOwnerClear.Click += new System.EventHandler(this.btnOwnerClear_Click);
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
            this.cboOwner.Location = new System.Drawing.Point(80, 5);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(170, 22);
            this.cboOwner.TabIndex = 76;
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwner.Location = new System.Drawing.Point(6, 9);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(67, 14);
            this.lblOwner.TabIndex = 75;
            this.lblOwner.Text = "Хранитель";
            // 
            // cboGoodState
            // 
            this.cboGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoodState.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboGoodState.Location = new System.Drawing.Point(406, 5);
            this.cboGoodState.Name = "cboGoodState";
            this.cboGoodState.Size = new System.Drawing.Size(170, 22);
            this.cboGoodState.TabIndex = 74;
            // 
            // lblGoodState
            // 
            this.lblGoodState.AutoSize = true;
            this.lblGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodState.Location = new System.Drawing.Point(328, 9);
            this.lblGoodState.Name = "lblGoodState";
            this.lblGoodState.Size = new System.Drawing.Size(68, 14);
            this.lblGoodState.TabIndex = 73;
            this.lblGoodState.Text = "Состояние";
            // 
            // btnPackings
            // 
            this.btnPackings.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnPackings.Location = new System.Drawing.Point(49, 27);
            this.btnPackings.Name = "btnPackings";
            this.btnPackings.Size = new System.Drawing.Size(28, 28);
            this.btnPackings.TabIndex = 71;
            this.ttToolTip.SetToolTip(this.btnPackings, "Выбор товара");
            this.btnPackings.UseVisualStyleBackColor = true;
            this.btnPackings.Click += new System.EventHandler(this.btnPackings_Click);
            // 
            // lblGoodNew
            // 
            this.lblGoodNew.AutoSize = true;
            this.lblGoodNew.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodNew.Location = new System.Drawing.Point(6, 34);
            this.lblGoodNew.Name = "lblGoodNew";
            this.lblGoodNew.Size = new System.Drawing.Size(41, 14);
            this.lblGoodNew.TabIndex = 70;
            this.lblGoodNew.Text = "Товар";
            // 
            // txtGood
            // 
            this.txtGood.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGood.Enabled = false;
            this.txtGood.Location = new System.Drawing.Point(80, 31);
            this.txtGood.Name = "txtGood";
            this.txtGood.Size = new System.Drawing.Size(496, 22);
            this.txtGood.TabIndex = 72;
            // 
            // numFramesCnt
            // 
            this.numFramesCnt.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numFramesCnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numFramesCnt.InputMask = "##########";
            this.numFramesCnt.IsNull = false;
            this.numFramesCnt.Location = new System.Drawing.Point(80, 57);
            this.numFramesCnt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numFramesCnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numFramesCnt.Name = "numFramesCnt";
            this.numFramesCnt.RealPlaces = 10;
            this.numFramesCnt.Size = new System.Drawing.Size(51, 22);
            this.numFramesCnt.TabIndex = 18;
            this.numFramesCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numFramesCnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFramesCnt.ValueChanged += new System.EventHandler(this.numFramesCnt_ValueChanged);
            // 
            // chkDateValidControl
            // 
            this.chkDateValidControl.AutoSize = true;
            this.chkDateValidControl.Location = new System.Drawing.Point(241, 59);
            this.chkDateValidControl.Name = "chkDateValidControl";
            this.chkDateValidControl.Size = new System.Drawing.Size(169, 18);
            this.chkDateValidControl.TabIndex = 3;
            this.chkDateValidControl.Text = "с учетом срока годности";
            this.chkDateValidControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkDateValidControl.UseVisualStyleBackColor = true;
            this.chkDateValidControl.CheckedChanged += new System.EventHandler(this.chkDateValidControl_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
            this.btnGo.Location = new System.Drawing.Point(520, 388);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 30);
            this.btnGo.TabIndex = 1;
            this.btnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnGo, "Создать операцию транспортировки контейнера");
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(5, 389);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnCancel.Location = new System.Drawing.Point(557, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.grcLockedImage,
            this.grcFrameID,
            this.grcCellAddess,
            this.grcBoxQnt,
            this.grcDateValid,
            this.grcOwnerName,
            this.grcGoodStateName,
            this.grcFrameHeight,
            this.grcFrameWeight,
            this.grcFrameState,
            this.grcLocked,
            this.grcStoreZoneName,
            this.grcStoreZoneTypeName,
            this.grcDateLastOperation,
            this.grcCellBarCode,
            this.grcFrameBarCode,
            this.grcQnt});
            this.grdData.IsActualOnly = false;
            this.grdData.IsCheckerInclude = true;
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.LocateColumnName = "grcFrameBarCode";
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(4, 128);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(584, 229);
            this.grdData.TabIndex = 4;
            this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
            this.grdData.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdData_CurrentCellDirtyStateChanged);
            // 
            // lblNoteManual
            // 
            this.lblNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNoteManual.AutoSize = true;
            this.lblNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNoteManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNoteManual.Location = new System.Drawing.Point(4, 363);
            this.lblNoteManual.Name = "lblNoteManual";
            this.lblNoteManual.Size = new System.Drawing.Size(78, 14);
            this.lblNoteManual.TabIndex = 46;
            this.lblNoteManual.Text = "Примечание";
            // 
            // txtNoteManual
            // 
            this.txtNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNoteManual.Location = new System.Drawing.Point(83, 360);
            this.txtNoteManual.MaxLength = 250;
            this.txtNoteManual.Name = "txtNoteManual";
            this.txtNoteManual.Size = new System.Drawing.Size(505, 22);
            this.txtNoteManual.TabIndex = 45;
            // 
            // grcLockedImage
            // 
            this.grcLockedImage.HeaderText = "Блок.";
            this.grcLockedImage.Name = "grcLockedImage";
            this.grcLockedImage.ReadOnly = true;
            this.grcLockedImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcLockedImage.ToolTipText = "Контейнер блокирован";
            this.grcLockedImage.Width = 50;
            // 
            // grcFrameID
            // 
            this.grcFrameID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcFrameID.DataPropertyName = "FrameID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcFrameID.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcFrameID.HeaderText = "ID";
            this.grcFrameID.Name = "grcFrameID";
            this.grcFrameID.ReadOnly = true;
            this.grcFrameID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcFrameID.Width = 50;
            // 
            // grcCellAddess
            // 
            this.grcCellAddess.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcCellAddess.DataPropertyName = "Address";
            this.grcCellAddess.HeaderText = "Ячейка Адрес";
            this.grcCellAddess.Name = "grcCellAddess";
            this.grcCellAddess.ReadOnly = true;
            this.grcCellAddess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcBoxQnt
            // 
            this.grcBoxQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxQnt.DataPropertyName = "BoxQnt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N1";
            this.grcBoxQnt.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcBoxQnt.HeaderText = "Кор.";
            this.grcBoxQnt.Name = "grcBoxQnt";
            this.grcBoxQnt.ReadOnly = true;
            this.grcBoxQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxQnt.ToolTipText = "Количество на поддоне, коробок";
            this.grcBoxQnt.Width = 70;
            // 
            // grcDateValid
            // 
            this.grcDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateValid.DataPropertyName = "DateValid";
            dataGridViewCellStyle4.Format = "dd.MM.yyyy";
            this.grcDateValid.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcDateValid.HeaderText = "Срок годн.";
            this.grcDateValid.Name = "grcDateValid";
            this.grcDateValid.ReadOnly = true;
            this.grcDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateValid.ToolTipText = "Срок годности, до";
            this.grcDateValid.Width = 75;
            // 
            // grcOwnerName
            // 
            this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOwnerName.DataPropertyName = "OwnerName";
            this.grcOwnerName.HeaderText = "Хранитель";
            this.grcOwnerName.Name = "grcOwnerName";
            this.grcOwnerName.ReadOnly = true;
            this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcOwnerName.Width = 150;
            // 
            // grcGoodStateName
            // 
            this.grcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodStateName.DataPropertyName = "GoodStateName";
            this.grcGoodStateName.HeaderText = "Состояние товара";
            this.grcGoodStateName.Name = "grcGoodStateName";
            this.grcGoodStateName.ReadOnly = true;
            this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodStateName.Width = 150;
            // 
            // grcFrameHeight
            // 
            this.grcFrameHeight.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcFrameHeight.DataPropertyName = "FrameHeight";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.grcFrameHeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcFrameHeight.HeaderText = "Высота";
            this.grcFrameHeight.Name = "grcFrameHeight";
            this.grcFrameHeight.ReadOnly = true;
            this.grcFrameHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcFrameHeight.ToolTipText = "Высота контейнера, м";
            this.grcFrameHeight.Width = 80;
            // 
            // grcFrameWeight
            // 
            this.grcFrameWeight.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcFrameWeight.DataPropertyName = "FrameWeight";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.grcFrameWeight.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcFrameWeight.HeaderText = "Вес конт.";
            this.grcFrameWeight.Name = "grcFrameWeight";
            this.grcFrameWeight.ReadOnly = true;
            this.grcFrameWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcFrameWeight.ToolTipText = "Вес контейнера, кг";
            this.grcFrameWeight.Width = 80;
            // 
            // grcFrameState
            // 
            this.grcFrameState.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcFrameState.DataPropertyName = "FrameState";
            this.grcFrameState.HeaderText = "Сост.";
            this.grcFrameState.Name = "grcFrameState";
            this.grcFrameState.ReadOnly = true;
            this.grcFrameState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcFrameState.ToolTipText = "Состояние контейнера";
            this.grcFrameState.Width = 50;
            // 
            // grcLocked
            // 
            this.grcLocked.DataPropertyName = "Locked";
            this.grcLocked.HeaderText = "Locked";
            this.grcLocked.Name = "grcLocked";
            this.grcLocked.ReadOnly = true;
            this.grcLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcLocked.Visible = false;
            // 
            // grcStoreZoneName
            // 
            this.grcStoreZoneName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcStoreZoneName.DataPropertyName = "StoreZoneName";
            this.grcStoreZoneName.HeaderText = "Складская зона";
            this.grcStoreZoneName.Name = "grcStoreZoneName";
            this.grcStoreZoneName.ReadOnly = true;
            this.grcStoreZoneName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcStoreZoneTypeName
            // 
            this.grcStoreZoneTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcStoreZoneTypeName.DataPropertyName = "StoreZoneTypeName";
            this.grcStoreZoneTypeName.HeaderText = "Тип зоны";
            this.grcStoreZoneTypeName.Name = "grcStoreZoneTypeName";
            this.grcStoreZoneTypeName.ReadOnly = true;
            this.grcStoreZoneTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcDateLastOperation
            // 
            this.grcDateLastOperation.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateLastOperation.DataPropertyName = "DateLastOperation";
            this.grcDateLastOperation.HeaderText = "Посл.операция";
            this.grcDateLastOperation.Name = "grcDateLastOperation";
            this.grcDateLastOperation.ReadOnly = true;
            this.grcDateLastOperation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateLastOperation.ToolTipText = "Дата-время последней операции";
            this.grcDateLastOperation.Width = 110;
            // 
            // grcCellBarCode
            // 
            this.grcCellBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcCellBarCode.DataPropertyName = "CellBarCode";
            this.grcCellBarCode.HeaderText = "ШК ячейки";
            this.grcCellBarCode.Name = "grcCellBarCode";
            this.grcCellBarCode.ReadOnly = true;
            this.grcCellBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcCellBarCode.Width = 130;
            // 
            // grcFrameBarCode
            // 
            this.grcFrameBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcFrameBarCode.DataPropertyName = "FrameBarCode";
            this.grcFrameBarCode.HeaderText = "ШК контейнера";
            this.grcFrameBarCode.Name = "grcFrameBarCode";
            this.grcFrameBarCode.ReadOnly = true;
            this.grcFrameBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcFrameBarCode.ToolTipText = "Штрих-код контейнера";
            this.grcFrameBarCode.Width = 130;
            // 
            // grcQnt
            // 
            this.grcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQnt.DataPropertyName = "Qnt";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.grcQnt.DefaultCellStyle = dataGridViewCellStyle7;
            this.grcQnt.HeaderText = "Штук";
            this.grcQnt.Name = "grcQnt";
            this.grcQnt.ReadOnly = true;
            this.grcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQnt.ToolTipText = "Количество на поддоне, штук";
            this.grcQnt.Width = 80;
            // 
            // frmTrafficsFramesForPickingCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(592, 423);
            this.Controls.Add(this.lblNoteManual);
            this.Controls.Add(this.txtNoteManual);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGo);
            this.hpHelp.SetHelpKeyword(this, "411");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.Name = "frmTrafficsFramesForPickingCreate";
            this.hpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Создание транспортировок поддонов для подпитки пикинга";
            this.Load += new System.EventHandler(this.frmTrafficManual_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFramesCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private RFMBaseClasses.RFMButton btnGo;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMCheckBox chkDateValidControl;
		private RFMBaseClasses.RFMNumericUpDown numFramesCnt;
		private RFMBaseClasses.RFMLabel lblFramesCnt;
		private RFMBaseClasses.RFMButton btnOwnerClear;
		private RFMBaseClasses.RFMComboBox cboOwner;
		private RFMBaseClasses.RFMLabel lblOwner;
		private RFMBaseClasses.RFMComboBox cboGoodState;
		private RFMBaseClasses.RFMLabel lblGoodState;
		private RFMBaseClasses.RFMButton btnPackings;
		private RFMBaseClasses.RFMLabel lblGoodNew;
		private RFMBaseClasses.RFMTextBox txtGood;
		private RFMBaseClasses.RFMLabel lblDateValidMin;
		private RFMBaseClasses.RFMDateTimePicker dtpDateValid;
		private RFMBaseClasses.RFMButton btnClear;
		private RFMBaseClasses.RFMButton btnFilter;
        private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMComboBox cboCellOutput;
		private RFMBaseClasses.RFMCheckBox chkForOutput;
		private RFMBaseClasses.RFMLabel lblBoxQnt;
		private RFMBaseClasses.RFMLabel lblNoteManual;
		private RFMBaseClasses.RFMTextBox txtNoteManual;
        private RFMBaseClasses.RFMDataGridViewImageColumn grcLockedImage;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFrameID;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellAddess;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxQnt;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFrameHeight;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFrameWeight;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFrameState;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcLocked;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneTypeName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateLastOperation;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellBarCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFrameBarCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt;
	}
}