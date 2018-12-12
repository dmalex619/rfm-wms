namespace WMSSuitable
{
	partial class frmShiftsAdd
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
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.btnSave = new RFMBaseClasses.RFMButton();
            this.pnlData = new RFMBaseClasses.RFMPanel();
            this.btnGo = new RFMBaseClasses.RFMButton();
            this.chkIfShift3Exits = new RFMBaseClasses.RFMCheckBox();
            this.dtpDateEnd = new RFMBaseClasses.RFMDateTimePicker();
            this.rfmLabel1 = new RFMBaseClasses.RFMLabel();
            this.numShift3Hours = new RFMBaseClasses.RFMNumericUpDown();
            this.numShift2Hours = new RFMBaseClasses.RFMNumericUpDown();
            this.numShift1Hours = new RFMBaseClasses.RFMNumericUpDown();
            this.lblShift1Hours = new RFMBaseClasses.RFMLabel();
            this.lblShift3Hours = new RFMBaseClasses.RFMLabel();
            this.lblShift2Hours = new RFMBaseClasses.RFMLabel();
            this.dtpDateBeg = new RFMBaseClasses.RFMDateTimePicker();
            this.lblDateBeg = new RFMBaseClasses.RFMLabel();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.grcDateBeg = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateEnd = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcMajorID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcMajorName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcIsNight = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcNote = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShift3Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShift2Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShift1Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(7, 375);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 30);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(545, 375);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 30);
            this.btnExit.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnExit, "Отказ");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(495, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 30);
            this.btnSave.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnSave, "Сохранить");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.btnGo);
            this.pnlData.Controls.Add(this.chkIfShift3Exits);
            this.pnlData.Controls.Add(this.dtpDateEnd);
            this.pnlData.Controls.Add(this.rfmLabel1);
            this.pnlData.Controls.Add(this.numShift3Hours);
            this.pnlData.Controls.Add(this.numShift2Hours);
            this.pnlData.Controls.Add(this.numShift1Hours);
            this.pnlData.Controls.Add(this.lblShift1Hours);
            this.pnlData.Controls.Add(this.lblShift3Hours);
            this.pnlData.Controls.Add(this.lblShift2Hours);
            this.pnlData.Controls.Add(this.dtpDateBeg);
            this.pnlData.Controls.Add(this.lblDateBeg);
            this.pnlData.Location = new System.Drawing.Point(4, 4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(575, 90);
            this.pnlData.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnGo.Location = new System.Drawing.Point(535, 50);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 30);
            this.btnGo.TabIndex = 30;
            this.ttToolTip.SetToolTip(this.btnGo, "Заполнить журнал смен");
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // chkIfShift3Exits
            // 
            this.chkIfShift3Exits.AutoSize = true;
            this.chkIfShift3Exits.Location = new System.Drawing.Point(8, 58);
            this.chkIfShift3Exits.Name = "chkIfShift3Exits";
            this.chkIfShift3Exits.Size = new System.Drawing.Size(145, 18);
            this.chkIfShift3Exits.TabIndex = 29;
            this.chkIfShift3Exits.Text = "Трехсменная работа";
            this.chkIfShift3Exits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkIfShift3Exits.UseVisualStyleBackColor = true;
            this.chkIfShift3Exits.CheckedChanged += new System.EventHandler(this.chkIfShift3Exits_CheckedChanged);
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "dd.MM.yyyy HH:mm ddd";
            this.dtpDateEnd.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtpDateEnd.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(405, 5);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(160, 22);
            this.dtpDateEnd.TabIndex = 28;
            // 
            // rfmLabel1
            // 
            this.rfmLabel1.AutoSize = true;
            this.rfmLabel1.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.rfmLabel1.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.rfmLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rfmLabel1.Location = new System.Drawing.Point(275, 8);
            this.rfmLabel1.Name = "rfmLabel1";
            this.rfmLabel1.Size = new System.Drawing.Size(122, 14);
            this.rfmLabel1.TabIndex = 27;
            this.rfmLabel1.Text = "Окончание периода";
            // 
            // numShift3Hours
            // 
            this.numShift3Hours.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numShift3Hours.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numShift3Hours.InputMask = "##";
            this.numShift3Hours.IsNull = false;
            this.numShift3Hours.Location = new System.Drawing.Point(385, 57);
            this.numShift3Hours.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.numShift3Hours.Name = "numShift3Hours";
            this.numShift3Hours.RealPlaces = 2;
            this.numShift3Hours.Size = new System.Drawing.Size(60, 22);
            this.numShift3Hours.TabIndex = 26;
            this.numShift3Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numShift3Hours.Visible = false;
            this.numShift3Hours.ValueChanged += new System.EventHandler(this.numShift3Hours_ValueChanged);
            // 
            // numShift2Hours
            // 
            this.numShift2Hours.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numShift2Hours.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numShift2Hours.InputMask = "##";
            this.numShift2Hours.IsNull = false;
            this.numShift2Hours.Location = new System.Drawing.Point(280, 57);
            this.numShift2Hours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numShift2Hours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShift2Hours.Name = "numShift2Hours";
            this.numShift2Hours.RealPlaces = 2;
            this.numShift2Hours.Size = new System.Drawing.Size(60, 22);
            this.numShift2Hours.TabIndex = 24;
            this.numShift2Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numShift2Hours.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numShift2Hours.ValueChanged += new System.EventHandler(this.numShift2Hours_ValueChanged);
            // 
            // numShift1Hours
            // 
            this.numShift1Hours.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numShift1Hours.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numShift1Hours.InputMask = "##";
            this.numShift1Hours.IsNull = false;
            this.numShift1Hours.Location = new System.Drawing.Point(180, 57);
            this.numShift1Hours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numShift1Hours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShift1Hours.Name = "numShift1Hours";
            this.numShift1Hours.RealPlaces = 2;
            this.numShift1Hours.Size = new System.Drawing.Size(60, 22);
            this.numShift1Hours.TabIndex = 22;
            this.numShift1Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numShift1Hours.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numShift1Hours.ValueChanged += new System.EventHandler(this.numShift1Hours_ValueChanged);
            // 
            // lblShift1Hours
            // 
            this.lblShift1Hours.AutoSize = true;
            this.lblShift1Hours.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblShift1Hours.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblShift1Hours.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShift1Hours.Location = new System.Drawing.Point(180, 40);
            this.lblShift1Hours.Name = "lblShift1Hours";
            this.lblShift1Hours.Size = new System.Drawing.Size(53, 14);
            this.lblShift1Hours.TabIndex = 21;
            this.lblShift1Hours.Text = "Смена 1";
            // 
            // lblShift3Hours
            // 
            this.lblShift3Hours.AutoSize = true;
            this.lblShift3Hours.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblShift3Hours.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblShift3Hours.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShift3Hours.Location = new System.Drawing.Point(385, 40);
            this.lblShift3Hours.Name = "lblShift3Hours";
            this.lblShift3Hours.Size = new System.Drawing.Size(53, 14);
            this.lblShift3Hours.TabIndex = 25;
            this.lblShift3Hours.Text = "Смена 3";
            this.lblShift3Hours.Visible = false;
            // 
            // lblShift2Hours
            // 
            this.lblShift2Hours.AutoSize = true;
            this.lblShift2Hours.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblShift2Hours.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblShift2Hours.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShift2Hours.Location = new System.Drawing.Point(280, 40);
            this.lblShift2Hours.Name = "lblShift2Hours";
            this.lblShift2Hours.Size = new System.Drawing.Size(53, 14);
            this.lblShift2Hours.TabIndex = 23;
            this.lblShift2Hours.Text = "Смена 2";
            // 
            // dtpDateBeg
            // 
            this.dtpDateBeg.CustomFormat = "dd.MM.yyyy HH:mm ddd";
            this.dtpDateBeg.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtpDateBeg.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpDateBeg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateBeg.Location = new System.Drawing.Point(105, 5);
            this.dtpDateBeg.Name = "dtpDateBeg";
            this.dtpDateBeg.Size = new System.Drawing.Size(160, 22);
            this.dtpDateBeg.TabIndex = 1;
            // 
            // lblDateBeg
            // 
            this.lblDateBeg.AutoSize = true;
            this.lblDateBeg.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateBeg.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateBeg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateBeg.Location = new System.Drawing.Point(5, 8);
            this.lblDateBeg.Name = "lblDateBeg";
            this.lblDateBeg.Size = new System.Drawing.Size(100, 14);
            this.lblDateBeg.TabIndex = 0;
            this.lblDateBeg.Text = "Начало периода";
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
            this.grcMajorID,
            this.grcMajorName,
            this.grcIsNight,
            this.grcNote,
            this.grcID});
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(5, 95);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(574, 275);
            this.grdData.TabIndex = 14;
            this.grdData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellEndEdit);
            // 
            // grcDateBeg
            // 
            this.grcDateBeg.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateBeg.DataPropertyName = "DateBeg";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy HH:mm ddd";
            dataGridViewCellStyle2.NullValue = null;
            this.grcDateBeg.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcDateBeg.HeaderText = "Начало";
            this.grcDateBeg.Name = "grcDateBeg";
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
            this.grcDateEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateEnd.ToolTipText = "Дата-время окончания смены";
            this.grcDateEnd.Width = 140;
            // 
            // grcMajorID
            // 
            this.grcMajorID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajorID.DataPropertyName = "MajorID";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.grcMajorID.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcMajorID.HeaderText = "Код";
            this.grcMajorID.Name = "grcMajorID";
            this.grcMajorID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcMajorID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcMajorID.ToolTipText = "Код старшего сотрудника в смене";
            this.grcMajorID.Width = 50;
            // 
            // grcMajorName
            // 
            this.grcMajorName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcMajorName.DataPropertyName = "MajorName";
            this.grcMajorName.HeaderText = "Старший (ФИО)";
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
            this.grcIsNight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcIsNight.ToolTipText = "Признак дневной/ночной смены";
            this.grcIsNight.Width = 50;
            // 
            // grcNote
            // 
            this.grcNote.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcNote.DataPropertyName = "Note";
            this.grcNote.FillWeight = 150F;
            this.grcNote.HeaderText = "Примечание";
            this.grcNote.Name = "grcNote";
            this.grcNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcNote.Width = 200;
            // 
            // grcID
            // 
            this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcID.DataPropertyName = "ID";
            this.grcID.HeaderText = "ID";
            this.grcID.Name = "grcID";
            this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcID.Visible = false;
            // 
            // frmShiftsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.hpHelp.SetHelpKeyword(this, "");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "frmShiftsAdd";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заполнение журнала смен";
            this.Load += new System.EventHandler(this.frmShihtsAdd_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numShift3Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShift2Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShift1Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMPanel pnlData;
        private RFMBaseClasses.RFMLabel lblDateBeg;
        private RFMBaseClasses.RFMDateTimePicker dtpDateBeg;
		private RFMBaseClasses.RFMNumericUpDown numShift3Hours;
		private RFMBaseClasses.RFMNumericUpDown numShift2Hours;
		private RFMBaseClasses.RFMNumericUpDown numShift1Hours;
		private RFMBaseClasses.RFMLabel lblShift1Hours;
		private RFMBaseClasses.RFMLabel lblShift3Hours;
        private RFMBaseClasses.RFMLabel lblShift2Hours;
        private RFMBaseClasses.RFMDateTimePicker dtpDateEnd;
        private RFMBaseClasses.RFMLabel rfmLabel1;
        private RFMBaseClasses.RFMCheckBox chkIfShift3Exits;
        private RFMBaseClasses.RFMButton btnGo;
        private RFMBaseClasses.RFMDataGridView grdData;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateBeg;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateEnd;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajorID;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMajorName;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcIsNight;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNote;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;

	}
}

