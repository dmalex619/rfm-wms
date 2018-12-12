namespace WMSSuitable
{
	partial class frmReportShiftsProductivity 
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
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.pnlFilter = new RFMBaseClasses.RFMPanel();
            this.lblMode = new RFMBaseClasses.RFMLabel();
            this.rfmPanel1 = new RFMBaseClasses.RFMPanel();
            this.optLoading = new RFMBaseClasses.RFMRadioButton();
            this.optPicking = new RFMBaseClasses.RFMRadioButton();
            this.dtpDateEnd = new RFMBaseClasses.RFMDateTimePicker();
            this.rfmLabel1 = new RFMBaseClasses.RFMLabel();
            this.dtpDateBeg = new RFMBaseClasses.RFMDateTimePicker();
            this.lblDateBeg = new RFMBaseClasses.RFMLabel();
            this.btnFilter = new RFMBaseClasses.RFMButton();
            this.lblGoods = new RFMBaseClasses.RFMLabel();
            this.pnlOpgInputsStarted = new RFMBaseClasses.RFMPanel();
            this.optWeighting = new RFMBaseClasses.RFMRadioButton();
            this.optNonWeighting = new RFMBaseClasses.RFMRadioButton();
            this.optAll = new RFMBaseClasses.RFMRadioButton();
            this.ucSelectRecordID_Owners = new RFMBaseClasses.RFMSelectRecordIDGrid();
            this.lblOwners = new RFMBaseClasses.RFMLabel();
            this.splitContainer = new RFMBaseClasses.RFMSplitContainer();
            this.dgvMajors = new RFMBaseClasses.RFMDataGridView();
            this.grcMajors_MajorName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcMajors_IsNight = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcMajors_ShiftsCount = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcMajors_AvgBoxesPerPickerPerHour = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcMajors_NettoIn = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcMajors_NettoOut = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvUsers = new RFMBaseClasses.RFMDataGridView();
            this.dgvUsers_PickingUserName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvUsers_IsNight = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.dgvUsers_ShiftsCount = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvUsers_AvgBoxesPerPickerPerHour = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.pnlFilter.SuspendLayout();
            this.rfmPanel1.SuspendLayout();
            this.pnlOpgInputsStarted.SuspendLayout();
            this.ucSelectRecordID_Owners.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMajors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(5, 425);
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
            this.btnExit.Location = new System.Drawing.Point(697, 426);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 30);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFilter.Controls.Add(this.lblMode);
            this.pnlFilter.Controls.Add(this.rfmPanel1);
            this.pnlFilter.Controls.Add(this.dtpDateEnd);
            this.pnlFilter.Controls.Add(this.rfmLabel1);
            this.pnlFilter.Controls.Add(this.dtpDateBeg);
            this.pnlFilter.Controls.Add(this.lblDateBeg);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.lblGoods);
            this.pnlFilter.Controls.Add(this.pnlOpgInputsStarted);
            this.pnlFilter.Controls.Add(this.ucSelectRecordID_Owners);
            this.pnlFilter.Controls.Add(this.lblOwners);
            this.pnlFilter.Location = new System.Drawing.Point(2, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(730, 100);
            this.pnlFilter.TabIndex = 14;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblMode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMode.Location = new System.Drawing.Point(5, 74);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(92, 14);
            this.lblMode.TabIndex = 34;
            this.lblMode.Text = "Метод расчета";
            // 
            // rfmPanel1
            // 
            this.rfmPanel1.Controls.Add(this.optLoading);
            this.rfmPanel1.Controls.Add(this.optPicking);
            this.rfmPanel1.Location = new System.Drawing.Point(135, 68);
            this.rfmPanel1.Name = "rfmPanel1";
            this.rfmPanel1.Size = new System.Drawing.Size(530, 26);
            this.rfmPanel1.TabIndex = 33;
            // 
            // optLoading
            // 
            this.optLoading.AutoSize = true;
            this.optLoading.Checked = true;
            this.optLoading.IsChanged = true;
            this.optLoading.Location = new System.Drawing.Point(100, 4);
            this.optLoading.Name = "optLoading";
            this.optLoading.Size = new System.Drawing.Size(288, 18);
            this.optLoading.TabIndex = 1;
            this.optLoading.TabStop = true;
            this.optLoading.Text = "по загрузке (отображает приходы и расходы)";
            this.optLoading.UseVisualStyleBackColor = true;
            // 
            // optPicking
            // 
            this.optPicking.AutoSize = true;
            this.optPicking.IsChanged = true;
            this.optPicking.Location = new System.Drawing.Point(3, 4);
            this.optPicking.Name = "optPicking";
            this.optPicking.Size = new System.Drawing.Size(88, 18);
            this.optPicking.TabIndex = 0;
            this.optPicking.Text = "по пикингу";
            this.optPicking.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "dd.MM.yyyy HH:mm ddd";
            this.dtpDateEnd.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtpDateEnd.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(135, 40);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(160, 22);
            this.dtpDateEnd.TabIndex = 32;
            // 
            // rfmLabel1
            // 
            this.rfmLabel1.AutoSize = true;
            this.rfmLabel1.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.rfmLabel1.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.rfmLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rfmLabel1.Location = new System.Drawing.Point(5, 44);
            this.rfmLabel1.Name = "rfmLabel1";
            this.rfmLabel1.Size = new System.Drawing.Size(122, 14);
            this.rfmLabel1.TabIndex = 31;
            this.rfmLabel1.Text = "Окончание периода";
            // 
            // dtpDateBeg
            // 
            this.dtpDateBeg.CustomFormat = "dd.MM.yyyy HH:mm ddd";
            this.dtpDateBeg.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtpDateBeg.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpDateBeg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateBeg.Location = new System.Drawing.Point(135, 10);
            this.dtpDateBeg.Name = "dtpDateBeg";
            this.dtpDateBeg.Size = new System.Drawing.Size(160, 22);
            this.dtpDateBeg.TabIndex = 30;
            // 
            // lblDateBeg
            // 
            this.lblDateBeg.AutoSize = true;
            this.lblDateBeg.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateBeg.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateBeg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateBeg.Location = new System.Drawing.Point(5, 14);
            this.lblDateBeg.Name = "lblDateBeg";
            this.lblDateBeg.Size = new System.Drawing.Size(100, 14);
            this.lblDateBeg.TabIndex = 29;
            this.lblDateBeg.Text = "Начало периода";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnFilter.Location = new System.Drawing.Point(690, 61);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(30, 30);
            this.btnFilter.TabIndex = 22;
            this.ttToolTip.SetToolTip(this.btnFilter, "Рассчитать отчет");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblGoods
            // 
            this.lblGoods.AutoSize = true;
            this.lblGoods.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoods.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoods.Location = new System.Drawing.Point(340, 44);
            this.lblGoods.Name = "lblGoods";
            this.lblGoods.Size = new System.Drawing.Size(49, 14);
            this.lblGoods.TabIndex = 21;
            this.lblGoods.Text = "Товары";
            // 
            // pnlOpgInputsStarted
            // 
            this.pnlOpgInputsStarted.Controls.Add(this.optWeighting);
            this.pnlOpgInputsStarted.Controls.Add(this.optNonWeighting);
            this.pnlOpgInputsStarted.Controls.Add(this.optAll);
            this.pnlOpgInputsStarted.Location = new System.Drawing.Point(415, 38);
            this.pnlOpgInputsStarted.Name = "pnlOpgInputsStarted";
            this.pnlOpgInputsStarted.Size = new System.Drawing.Size(250, 26);
            this.pnlOpgInputsStarted.TabIndex = 20;
            // 
            // optWeighting
            // 
            this.optWeighting.AutoSize = true;
            this.optWeighting.Location = new System.Drawing.Point(65, 4);
            this.optWeighting.Name = "optWeighting";
            this.optWeighting.Size = new System.Drawing.Size(72, 18);
            this.optWeighting.TabIndex = 1;
            this.optWeighting.Text = "весовые";
            this.optWeighting.UseVisualStyleBackColor = true;
            // 
            // optNonWeighting
            // 
            this.optNonWeighting.AutoSize = true;
            this.optNonWeighting.Checked = true;
            this.optNonWeighting.IsChanged = true;
            this.optNonWeighting.Location = new System.Drawing.Point(150, 4);
            this.optNonWeighting.Name = "optNonWeighting";
            this.optNonWeighting.Size = new System.Drawing.Size(95, 18);
            this.optNonWeighting.TabIndex = 2;
            this.optNonWeighting.TabStop = true;
            this.optNonWeighting.Text = "коробочные";
            this.optNonWeighting.UseVisualStyleBackColor = true;
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.IsChanged = true;
            this.optAll.Location = new System.Drawing.Point(3, 4);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(44, 18);
            this.optAll.TabIndex = 0;
            this.optAll.Text = "все";
            this.optAll.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_Owners
            // 
            // 
            // ucSelectRecordID_Owners.btnClear
            // 
            this.ucSelectRecordID_Owners.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Owners.BtnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.ucSelectRecordID_Owners.BtnClear.Location = new System.Drawing.Point(244, 0);
            this.ucSelectRecordID_Owners.BtnClear.Name = "btnClear";
            this.ucSelectRecordID_Owners.BtnClear.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Owners.BtnClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Owners.BtnClear, "Очистка выбора владельцев");
            this.ucSelectRecordID_Owners.BtnClear.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_Owners.btnSelect
            // 
            this.ucSelectRecordID_Owners.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Owners.BtnSelect.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.ucSelectRecordID_Owners.BtnSelect.Location = new System.Drawing.Point(218, 0);
            this.ucSelectRecordID_Owners.BtnSelect.Name = "btnSelect";
            this.ucSelectRecordID_Owners.BtnSelect.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Owners.BtnSelect.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Owners.BtnSelect, "Выбор владельцев");
            this.ucSelectRecordID_Owners.BtnSelect.UseVisualStyleBackColor = true;
            this.ucSelectRecordID_Owners.ExpSort = "Name";
            this.ucSelectRecordID_Owners.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ucSelectRecordID_Owners.IsActualOnly = true;
            this.ucSelectRecordID_Owners.IsSaveMark = true;
            this.ucSelectRecordID_Owners.IsUseMark = true;
            this.ucSelectRecordID_Owners.Location = new System.Drawing.Point(415, 9);
            this.ucSelectRecordID_Owners.MarkedCount = 0;
            this.ucSelectRecordID_Owners.Name = "ucSelectRecordID_Owners";
            this.ucSelectRecordID_Owners.Size = new System.Drawing.Size(271, 24);
            this.ucSelectRecordID_Owners.TabIndex = 19;
            this.ucSelectRecordID_Owners.TableColumnName = "Name";
            // 
            // ucSelectRecordID_Owners.txtData
            // 
            this.ucSelectRecordID_Owners.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Owners.TxtData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.ucSelectRecordID_Owners.TxtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.ucSelectRecordID_Owners.TxtData.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucSelectRecordID_Owners.TxtData.IsUserDraw = true;
            this.ucSelectRecordID_Owners.TxtData.Location = new System.Drawing.Point(0, 1);
            this.ucSelectRecordID_Owners.TxtData.MaxLength = 128;
            this.ucSelectRecordID_Owners.TxtData.Name = "txtData";
            this.ucSelectRecordID_Owners.TxtData.ReadOnly = true;
            this.ucSelectRecordID_Owners.TxtData.Size = new System.Drawing.Size(216, 22);
            this.ucSelectRecordID_Owners.TxtData.TabIndex = 0;
            this.ucSelectRecordID_Owners.СolumnsData.AddRange(new string[] {
            "Name, Сотрудник"});
            // 
            // lblOwners
            // 
            this.lblOwners.AutoSize = true;
            this.lblOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwners.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwners.Location = new System.Drawing.Point(340, 14);
            this.lblOwners.Name = "lblOwners";
            this.lblOwners.Size = new System.Drawing.Size(69, 14);
            this.lblOwners.TabIndex = 18;
            this.lblOwners.Text = "Владельцы";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(2, 105);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.splitContainer.Panel1.Controls.Add(this.dgvMajors);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvUsers);
            this.splitContainer.Size = new System.Drawing.Size(730, 315);
            this.splitContainer.SplitterDistance = 363;
            this.splitContainer.TabIndex = 15;
            // 
            // dgvMajors
            // 
            this.dgvMajors.AllowUserToAddRows = false;
            this.dgvMajors.AllowUserToDeleteRows = false;
            this.dgvMajors.AllowUserToOrderColumns = true;
            this.dgvMajors.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMajors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMajors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcMajors_MajorName,
            this.grcMajors_IsNight,
            this.grcMajors_ShiftsCount,
            this.grcMajors_AvgBoxesPerPickerPerHour,
            this.grcMajors_NettoIn,
            this.grcMajors_NettoOut});
            this.dgvMajors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMajors.IsConfigInclude = true;
            this.dgvMajors.IsMarkedAll = false;
            this.dgvMajors.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.dgvMajors.Location = new System.Drawing.Point(0, 0);
            this.dgvMajors.MultiSelect = false;
            this.dgvMajors.Name = "dgvMajors";
            this.dgvMajors.RangedWay = ' ';
            this.dgvMajors.RowHeadersWidth = 24;
            this.dgvMajors.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.dgvMajors.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.dgvMajors.Size = new System.Drawing.Size(363, 315);
            this.dgvMajors.TabIndex = 0;
            // 
            // grcMajors_MajorName
            // 
            this.grcMajors_MajorName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajors_MajorName.DataPropertyName = "MajorName";
            this.grcMajors_MajorName.HeaderText = "Старший смены";
            this.grcMajors_MajorName.Name = "grcMajors_MajorName";
            this.grcMajors_MajorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajors_MajorName.Width = 150;
            // 
            // grcMajors_IsNight
            // 
            this.grcMajors_IsNight.DataPropertyName = "IsNight";
            this.grcMajors_IsNight.HeaderText = "Ночь";
            this.grcMajors_IsNight.Name = "grcMajors_IsNight";
            this.grcMajors_IsNight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajors_IsNight.ToolTipText = "Признак дневной/ночной смены";
            this.grcMajors_IsNight.Width = 40;
            // 
            // grcMajors_ShiftsCount
            // 
            this.grcMajors_ShiftsCount.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajors_ShiftsCount.DataPropertyName = "ShiftsCount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.grcMajors_ShiftsCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.grcMajors_ShiftsCount.HeaderText = "Смен";
            this.grcMajors_ShiftsCount.Name = "grcMajors_ShiftsCount";
            this.grcMajors_ShiftsCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajors_ShiftsCount.ToolTipText = "Количество смен";
            this.grcMajors_ShiftsCount.Width = 50;
            // 
            // grcMajors_AvgBoxesPerPickerPerHour
            // 
            this.grcMajors_AvgBoxesPerPickerPerHour.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajors_AvgBoxesPerPickerPerHour.DataPropertyName = "AvgBoxesPerPickerPerHour";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.grcMajors_AvgBoxesPerPickerPerHour.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcMajors_AvgBoxesPerPickerPerHour.HeaderText = "Кор/ч.час";
            this.grcMajors_AvgBoxesPerPickerPerHour.Name = "grcMajors_AvgBoxesPerPickerPerHour";
            this.grcMajors_AvgBoxesPerPickerPerHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajors_AvgBoxesPerPickerPerHour.ToolTipText = "Производительность (коробок на человека в час)";
            this.grcMajors_AvgBoxesPerPickerPerHour.Width = 80;
            // 
            // grcMajors_NettoIn
            // 
            this.grcMajors_NettoIn.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajors_NettoIn.DataPropertyName = "NettoIn";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.grcMajors_NettoIn.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcMajors_NettoIn.HeaderText = "Приход";
            this.grcMajors_NettoIn.Name = "grcMajors_NettoIn";
            this.grcMajors_NettoIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajors_NettoIn.ToolTipText = "Нетто всех приходов";
            // 
            // grcMajors_NettoOut
            // 
            this.grcMajors_NettoOut.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajors_NettoOut.DataPropertyName = "NettoOut";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.grcMajors_NettoOut.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcMajors_NettoOut.HeaderText = "Отгрузка";
            this.grcMajors_NettoOut.Name = "grcMajors_NettoOut";
            this.grcMajors_NettoOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajors_NettoOut.ToolTipText = "Нетто всех отгрузок";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUsers_PickingUserName,
            this.dgvUsers_IsNight,
            this.dgvUsers_ShiftsCount,
            this.dgvUsers_AvgBoxesPerPickerPerHour});
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.IsConfigInclude = true;
            this.dgvUsers.IsMarkedAll = false;
            this.dgvUsers.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RangedWay = ' ';
            this.dgvUsers.RowHeadersWidth = 24;
            this.dgvUsers.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.dgvUsers.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.dgvUsers.Size = new System.Drawing.Size(363, 315);
            this.dgvUsers.TabIndex = 1;
            // 
            // dgvUsers_PickingUserName
            // 
            this.dgvUsers_PickingUserName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvUsers_PickingUserName.DataPropertyName = "PickingUserName";
            this.dgvUsers_PickingUserName.HeaderText = "Сотрудник";
            this.dgvUsers_PickingUserName.Name = "dgvUsers_PickingUserName";
            this.dgvUsers_PickingUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvUsers_PickingUserName.Width = 150;
            // 
            // dgvUsers_IsNight
            // 
            this.dgvUsers_IsNight.DataPropertyName = "IsNight";
            this.dgvUsers_IsNight.HeaderText = "Ночь";
            this.dgvUsers_IsNight.Name = "dgvUsers_IsNight";
            this.dgvUsers_IsNight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvUsers_IsNight.ToolTipText = "Признак дневной/ночной смены";
            this.dgvUsers_IsNight.Width = 40;
            // 
            // dgvUsers_ShiftsCount
            // 
            this.dgvUsers_ShiftsCount.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvUsers_ShiftsCount.DataPropertyName = "ShiftsCount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.dgvUsers_ShiftsCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsers_ShiftsCount.HeaderText = "Смен";
            this.dgvUsers_ShiftsCount.Name = "dgvUsers_ShiftsCount";
            this.dgvUsers_ShiftsCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvUsers_ShiftsCount.ToolTipText = "Количество смен";
            this.dgvUsers_ShiftsCount.Width = 50;
            // 
            // dgvUsers_AvgBoxesPerPickerPerHour
            // 
            this.dgvUsers_AvgBoxesPerPickerPerHour.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvUsers_AvgBoxesPerPickerPerHour.DataPropertyName = "AvgBoxesPerPickerPerHour";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = null;
            this.dgvUsers_AvgBoxesPerPickerPerHour.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUsers_AvgBoxesPerPickerPerHour.HeaderText = "Кор/ч.час";
            this.dgvUsers_AvgBoxesPerPickerPerHour.Name = "dgvUsers_AvgBoxesPerPickerPerHour";
            this.dgvUsers_AvgBoxesPerPickerPerHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvUsers_AvgBoxesPerPickerPerHour.ToolTipText = "Производительность (коробок на человека в час)";
            this.dgvUsers_AvgBoxesPerPickerPerHour.Width = 80;
            // 
            // frmReportShiftsProductivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.hpHelp.SetHelpKeyword(this, "802");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsAccessOn = true;
            this.Name = "frmReportShiftsProductivity";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчте о сменной производительности";
            this.Load += new System.EventHandler(this.frmShifts_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.rfmPanel1.ResumeLayout(false);
            this.rfmPanel1.PerformLayout();
            this.pnlOpgInputsStarted.ResumeLayout(false);
            this.pnlOpgInputsStarted.PerformLayout();
            this.ucSelectRecordID_Owners.ResumeLayout(false);
            this.ucSelectRecordID_Owners.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMajors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnExit;
        private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMPanel pnlFilter;
        private RFMBaseClasses.RFMSelectRecordIDGrid ucSelectRecordID_Owners;
        private RFMBaseClasses.RFMLabel lblOwners;
        private RFMBaseClasses.RFMPanel pnlOpgInputsStarted;
        private RFMBaseClasses.RFMRadioButton optWeighting;
        private RFMBaseClasses.RFMRadioButton optNonWeighting;
        private RFMBaseClasses.RFMRadioButton optAll;
        private RFMBaseClasses.RFMLabel lblGoods;
        private RFMBaseClasses.RFMButton btnFilter;
        private RFMBaseClasses.RFMDateTimePicker dtpDateEnd;
        private RFMBaseClasses.RFMLabel rfmLabel1;
        private RFMBaseClasses.RFMDateTimePicker dtpDateBeg;
        private RFMBaseClasses.RFMLabel lblDateBeg;
        private RFMBaseClasses.RFMSplitContainer splitContainer;
        private RFMBaseClasses.RFMDataGridView dgvMajors;
        private RFMBaseClasses.RFMLabel lblMode;
        private RFMBaseClasses.RFMPanel rfmPanel1;
        private RFMBaseClasses.RFMRadioButton optLoading;
        private RFMBaseClasses.RFMRadioButton optPicking;
        private RFMBaseClasses.RFMDataGridView dgvUsers;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvUsers_PickingUserName;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgvUsers_IsNight;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvUsers_ShiftsCount;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvUsers_AvgBoxesPerPickerPerHour;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajors_MajorName;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcMajors_IsNight;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajors_ShiftsCount;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajors_AvgBoxesPerPickerPerHour;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajors_NettoIn;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajors_NettoOut;
	}
}

