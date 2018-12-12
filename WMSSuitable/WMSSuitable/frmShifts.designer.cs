namespace WMSSuitable
{
	partial class frmShifts 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShifts));
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.btnEdit = new RFMBaseClasses.RFMButton();
            this.btnDelete = new RFMBaseClasses.RFMButton();
            this.btnAdd = new RFMBaseClasses.RFMButton();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.grcDateBeg = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateEnd = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcMajorName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcIsNight = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcDuration = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcNote = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.pnlFilter = new RFMBaseClasses.RFMPanel();
            this.btnFilter = new RFMBaseClasses.RFMButton();
            this.lblShifts = new RFMBaseClasses.RFMLabel();
            this.pnlOpgInputsStarted = new RFMBaseClasses.RFMPanel();
            this.optNight = new RFMBaseClasses.RFMRadioButton();
            this.optDay = new RFMBaseClasses.RFMRadioButton();
            this.optAll = new RFMBaseClasses.RFMRadioButton();
            this.ucSelectRecordID_Majors = new RFMBaseClasses.RFMSelectRecordIDGrid();
            this.lblMajors = new RFMBaseClasses.RFMLabel();
            this.dtrDates = new RFMBaseClasses.RFMDateRange();
            this.lblDateInterval = new RFMBaseClasses.RFMLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlOpgInputsStarted.SuspendLayout();
            this.ucSelectRecordID_Majors.SuspendLayout();
            this.dtrDates.SuspendLayout();
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
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
            this.btnEdit.IsAccessOn = true;
            this.btnEdit.Location = new System.Drawing.Point(597, 426);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 30);
            this.btnEdit.TabIndex = 11;
            this.ttToolTip.SetToolTip(this.btnEdit, "Редактирование");
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
            this.btnDelete.IsAccessOn = true;
            this.btnDelete.Location = new System.Drawing.Point(647, 426);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 30);
            this.btnDelete.TabIndex = 12;
            this.ttToolTip.SetToolTip(this.btnDelete, "Удаление");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
            this.btnAdd.IsAccessOn = true;
            this.btnAdd.Location = new System.Drawing.Point(547, 426);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 10;
            this.ttToolTip.SetToolTip(this.btnAdd, "Добавление");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.grcDateBeg,
            this.grcDateEnd,
            this.grcMajorName,
            this.grcIsNight,
            this.grcDuration,
            this.grcNote,
            this.grcID});
            this.grdData.IsCheckerInclude = true;
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.IsStatusInclude = true;
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(2, 105);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(730, 315);
            this.grdData.TabIndex = 13;
            // 
            // grcDateBeg
            // 
            this.grcDateBeg.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateBeg.DataPropertyName = "DateBeg";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy HH:mm ddd";
            this.grcDateBeg.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcDateBeg.HeaderText = "Начало";
            this.grcDateBeg.Name = "grcDateBeg";
            this.grcDateBeg.ReadOnly = true;
            this.grcDateBeg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateBeg.ToolTipText = "Дата-время начала смены";
            this.grcDateBeg.Width = 140;
            // 
            // grcDateEnd
            // 
            this.grcDateEnd.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateEnd.DataPropertyName = "DateEnd";
            dataGridViewCellStyle3.Format = "dd.MM.yyyy HH:mm ddd";
            dataGridViewCellStyle3.NullValue = null;
            this.grcDateEnd.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcDateEnd.HeaderText = "Окончание";
            this.grcDateEnd.Name = "grcDateEnd";
            this.grcDateEnd.ReadOnly = true;
            this.grcDateEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateEnd.ToolTipText = "Дата-время окончания смены";
            this.grcDateEnd.Width = 140;
            // 
            // grcMajorName
            // 
            this.grcMajorName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajorName.DataPropertyName = "MajorName";
            this.grcMajorName.HeaderText = "Старший";
            this.grcMajorName.Name = "grcMajorName";
            this.grcMajorName.ReadOnly = true;
            this.grcMajorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajorName.ToolTipText = "Старший сотрудник в смене";
            this.grcMajorName.Width = 150;
            // 
            // grcIsNight
            // 
            this.grcIsNight.DataPropertyName = "IsNight";
            this.grcIsNight.HeaderText = "Ночь";
            this.grcIsNight.Name = "grcIsNight";
            this.grcIsNight.ReadOnly = true;
            this.grcIsNight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcIsNight.ToolTipText = "Признак дневной/ночной смены";
            this.grcIsNight.Width = 50;
            // 
            // grcDuration
            // 
            this.grcDuration.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDuration.DataPropertyName = "Duration";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcDuration.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcDuration.HeaderText = "Прод.";
            this.grcDuration.Name = "grcDuration";
            this.grcDuration.ReadOnly = true;
            this.grcDuration.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDuration.ToolTipText = "Продолжительность смены, ч";
            this.grcDuration.Width = 50;
            // 
            // grcNote
            // 
            this.grcNote.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcNote.DataPropertyName = "Note";
            this.grcNote.FillWeight = 150F;
            this.grcNote.HeaderText = "Примечание";
            this.grcNote.Name = "grcNote";
            this.grcNote.ReadOnly = true;
            this.grcNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcNote.Width = 200;
            // 
            // grcID
            // 
            this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcID.DataPropertyName = "ID";
            this.grcID.HeaderText = "ID";
            this.grcID.Name = "grcID";
            this.grcID.ReadOnly = true;
            this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.lblShifts);
            this.pnlFilter.Controls.Add(this.pnlOpgInputsStarted);
            this.pnlFilter.Controls.Add(this.ucSelectRecordID_Majors);
            this.pnlFilter.Controls.Add(this.lblMajors);
            this.pnlFilter.Controls.Add(this.dtrDates);
            this.pnlFilter.Controls.Add(this.lblDateInterval);
            this.pnlFilter.Location = new System.Drawing.Point(2, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(730, 100);
            this.pnlFilter.TabIndex = 14;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnFilter.Location = new System.Drawing.Point(690, 61);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(30, 30);
            this.btnFilter.TabIndex = 22;
            this.ttToolTip.SetToolTip(this.btnFilter, "Показать товары, соответствующие условиям (<F5>)");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblShifts
            // 
            this.lblShifts.AutoSize = true;
            this.lblShifts.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblShifts.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblShifts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShifts.Location = new System.Drawing.Point(10, 71);
            this.lblShifts.Name = "lblShifts";
            this.lblShifts.Size = new System.Drawing.Size(44, 14);
            this.lblShifts.TabIndex = 21;
            this.lblShifts.Text = "Смены";
            // 
            // pnlOpgInputsStarted
            // 
            this.pnlOpgInputsStarted.Controls.Add(this.optNight);
            this.pnlOpgInputsStarted.Controls.Add(this.optDay);
            this.pnlOpgInputsStarted.Controls.Add(this.optAll);
            this.pnlOpgInputsStarted.Location = new System.Drawing.Point(100, 65);
            this.pnlOpgInputsStarted.Name = "pnlOpgInputsStarted";
            this.pnlOpgInputsStarted.Size = new System.Drawing.Size(220, 26);
            this.pnlOpgInputsStarted.TabIndex = 20;
            // 
            // optNight
            // 
            this.optNight.AutoSize = true;
            this.optNight.Location = new System.Drawing.Point(60, 4);
            this.optNight.Name = "optNight";
            this.optNight.Size = new System.Drawing.Size(68, 18);
            this.optNight.TabIndex = 1;
            this.optNight.Text = "ночные";
            this.optNight.UseVisualStyleBackColor = true;
            // 
            // optDay
            // 
            this.optDay.AutoSize = true;
            this.optDay.Location = new System.Drawing.Point(140, 4);
            this.optDay.Name = "optDay";
            this.optDay.Size = new System.Drawing.Size(74, 18);
            this.optDay.TabIndex = 2;
            this.optDay.Text = "дневные";
            this.optDay.UseVisualStyleBackColor = true;
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.IsChanged = true;
            this.optAll.Location = new System.Drawing.Point(3, 4);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(44, 18);
            this.optAll.TabIndex = 0;
            this.optAll.TabStop = true;
            this.optAll.Text = "все";
            this.optAll.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_Majors
            // 
            // 
            // ucSelectRecordID_Majors.btnClear
            // 
            this.ucSelectRecordID_Majors.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Majors.BtnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.ucSelectRecordID_Majors.BtnClear.Location = new System.Drawing.Point(244, 0);
            this.ucSelectRecordID_Majors.BtnClear.Name = "btnClear";
            this.ucSelectRecordID_Majors.BtnClear.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Majors.BtnClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Majors.BtnClear, "Очистка выбора сотрудников");
            this.ucSelectRecordID_Majors.BtnClear.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_Majors.btnSelect
            // 
            this.ucSelectRecordID_Majors.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Majors.BtnSelect.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.ucSelectRecordID_Majors.BtnSelect.Location = new System.Drawing.Point(218, 0);
            this.ucSelectRecordID_Majors.BtnSelect.Name = "btnSelect";
            this.ucSelectRecordID_Majors.BtnSelect.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Majors.BtnSelect.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Majors.BtnSelect, "Выбор сотрудников");
            this.ucSelectRecordID_Majors.BtnSelect.UseVisualStyleBackColor = true;
            this.ucSelectRecordID_Majors.ExpSort = "Name";
            this.ucSelectRecordID_Majors.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ucSelectRecordID_Majors.IsActualOnly = true;
            this.ucSelectRecordID_Majors.IsSaveMark = true;
            this.ucSelectRecordID_Majors.IsUseMark = true;
            this.ucSelectRecordID_Majors.Location = new System.Drawing.Point(100, 37);
            this.ucSelectRecordID_Majors.MarkedCount = 0;
            this.ucSelectRecordID_Majors.Name = "ucSelectRecordID_Majors";
            this.ucSelectRecordID_Majors.Size = new System.Drawing.Size(271, 24);
            this.ucSelectRecordID_Majors.TabIndex = 19;
            this.ucSelectRecordID_Majors.TableColumnName = "Name";
            // 
            // ucSelectRecordID_Majors.txtData
            // 
            this.ucSelectRecordID_Majors.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Majors.TxtData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.ucSelectRecordID_Majors.TxtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.ucSelectRecordID_Majors.TxtData.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucSelectRecordID_Majors.TxtData.IsUserDraw = true;
            this.ucSelectRecordID_Majors.TxtData.Location = new System.Drawing.Point(0, 1);
            this.ucSelectRecordID_Majors.TxtData.MaxLength = 128;
            this.ucSelectRecordID_Majors.TxtData.Name = "txtData";
            this.ucSelectRecordID_Majors.TxtData.ReadOnly = true;
            this.ucSelectRecordID_Majors.TxtData.Size = new System.Drawing.Size(216, 22);
            this.ucSelectRecordID_Majors.TxtData.TabIndex = 0;
            this.ucSelectRecordID_Majors.СolumnsData.AddRange(new string[] {
            "Name, Сотрудник"});
            // 
            // lblMajors
            // 
            this.lblMajors.AutoSize = true;
            this.lblMajors.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblMajors.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMajors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMajors.Location = new System.Drawing.Point(10, 42);
            this.lblMajors.Name = "lblMajors";
            this.lblMajors.Size = new System.Drawing.Size(87, 14);
            this.lblMajors.TabIndex = 18;
            this.lblMajors.Text = "Старшие смен";
            // 
            // dtrDates
            // 
            this.dtrDates.BegValue = new System.DateTime(2007, 7, 31, 0, 0, 0, 0);
            // 
            // dtrDates.btnClear
            // 
            this.dtrDates.BtnСlear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dtrDates.BtnСlear.Image = ((System.Drawing.Image)(resources.GetObject("dtrDates.btnClear.Image")));
            this.dtrDates.BtnСlear.Location = new System.Drawing.Point(193, 4);
            this.dtrDates.BtnСlear.Name = "btnClear";
            this.dtrDates.BtnСlear.Size = new System.Drawing.Size(24, 22);
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
            this.dtrDates.DtpBegDate.Location = new System.Drawing.Point(0, 4);
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
            this.dtrDates.DtpEndDate.Location = new System.Drawing.Point(101, 4);
            this.dtrDates.DtpEndDate.Name = "dtpEndDate";
            this.dtrDates.DtpEndDate.Size = new System.Drawing.Size(90, 22);
            this.dtrDates.DtpEndDate.TabIndex = 2;
            this.dtrDates.EndValue = new System.DateTime(2007, 7, 31, 0, 0, 0, 0);
            this.dtrDates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // dtrDates.lblDelimiter
            // 
            this.dtrDates.LblDelimiter.AutoSize = true;
            this.dtrDates.LblDelimiter.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtrDates.LblDelimiter.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtrDates.LblDelimiter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtrDates.LblDelimiter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtrDates.LblDelimiter.Location = new System.Drawing.Point(90, 7);
            this.dtrDates.LblDelimiter.Name = "lblDelimiter";
            this.dtrDates.LblDelimiter.Size = new System.Drawing.Size(13, 16);
            this.dtrDates.LblDelimiter.TabIndex = 1;
            this.dtrDates.LblDelimiter.Text = ":";
            this.dtrDates.Location = new System.Drawing.Point(100, 5);
            this.dtrDates.Name = "dtrDates";
            this.dtrDates.Size = new System.Drawing.Size(222, 29);
            this.dtrDates.TabIndex = 5;
            // 
            // lblDateInterval
            // 
            this.lblDateInterval.AutoSize = true;
            this.lblDateInterval.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateInterval.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateInterval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateInterval.Location = new System.Drawing.Point(10, 13);
            this.lblDateInterval.Name = "lblDateInterval";
            this.lblDateInterval.Size = new System.Drawing.Size(84, 14);
            this.lblDateInterval.TabIndex = 4;
            this.lblDateInterval.Text = "Интервал дат";
            // 
            // frmShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.hpHelp.SetHelpKeyword(this, "802");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsAccessOn = true;
            this.Name = "frmShifts";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал смен";
            this.Load += new System.EventHandler(this.frmShifts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlOpgInputsStarted.ResumeLayout(false);
            this.pnlOpgInputsStarted.PerformLayout();
            this.ucSelectRecordID_Majors.ResumeLayout(false);
            this.ucSelectRecordID_Majors.PerformLayout();
            this.dtrDates.ResumeLayout(false);
            this.dtrDates.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnAdd;
        private RFMBaseClasses.RFMDataGridView grdData;
        private RFMBaseClasses.RFMPanel pnlFilter;
        private RFMBaseClasses.RFMDateRange dtrDates;
        private RFMBaseClasses.RFMLabel lblDateInterval;
        private RFMBaseClasses.RFMSelectRecordIDGrid ucSelectRecordID_Majors;
        private RFMBaseClasses.RFMLabel lblMajors;
        private RFMBaseClasses.RFMPanel pnlOpgInputsStarted;
        private RFMBaseClasses.RFMRadioButton optNight;
        private RFMBaseClasses.RFMRadioButton optDay;
        private RFMBaseClasses.RFMRadioButton optAll;
        private RFMBaseClasses.RFMLabel lblShifts;
        private RFMBaseClasses.RFMButton btnFilter;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateBeg;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateEnd;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajorName;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcIsNight;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDuration;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNote;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;
	}
}

