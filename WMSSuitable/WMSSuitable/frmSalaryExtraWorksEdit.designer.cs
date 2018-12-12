namespace WMSSuitable
{
	partial class frmSalaryExtraWorksEdit
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
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.btnSave = new RFMBaseClasses.RFMButton();
            this.txtNote = new RFMBaseClasses.RFMTextBox();
            this.lblNote = new RFMBaseClasses.RFMLabel();
            this.lblDateWork = new RFMBaseClasses.RFMLabel();
            this.lblUser = new RFMBaseClasses.RFMLabel();
            this.pnlData = new RFMBaseClasses.RFMPanel();
            this.lblOwners = new RFMBaseClasses.RFMLabel();
            this.cboOwners = new RFMBaseClasses.RFMComboBox();
            this.lblAmount = new RFMBaseClasses.RFMLabel();
            this.lblTarif = new RFMBaseClasses.RFMLabel();
            this.lblQnt = new RFMBaseClasses.RFMLabel();
            this.numAmount = new RFMBaseClasses.RFMNumericUpDown();
            this.numTarif = new RFMBaseClasses.RFMNumericUpDown();
            this.numQnt = new RFMBaseClasses.RFMNumericUpDown();
            this.txtTabNumber = new RFMBaseClasses.RFMTextBox();
            this.btnExtraWorkSelect = new RFMBaseClasses.RFMButton();
            this.lblExtraWork = new RFMBaseClasses.RFMLabel();
            this.txtExtraWork = new RFMBaseClasses.RFMTextBox();
            this.dtpDateExtraWork = new RFMBaseClasses.RFMDateTimePicker();
            this.cboUsers = new RFMBaseClasses.RFMComboBox();
            this.lblDelimiter = new RFMBaseClasses.RFMLabel();
            this.nudHours = new RFMBaseClasses.RFMNumericUpDown();
            this.nudMinutes = new RFMBaseClasses.RFMNumericUpDown();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(6, 218);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(37, 39);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(634, 218);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 39);
            this.btnExit.TabIndex = 3;
            this.ttToolTip.SetToolTip(this.btnExit, "Отказ");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(586, 218);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(37, 39);
            this.btnSave.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnSave, "Сохранить");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNote
            // 
            this.txtNote.AcceptsReturn = true;
            this.txtNote.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNote.Location = new System.Drawing.Point(130, 117);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNote.MaxLength = 200;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(530, 26);
            this.txtNote.TabIndex = 15;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNote.AutoSize = true;
            this.lblNote.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNote.Location = new System.Drawing.Point(6, 121);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(92, 18);
            this.lblNote.TabIndex = 14;
            this.lblNote.Text = "Примечание";
            // 
            // lblDateWork
            // 
            this.lblDateWork.AutoSize = true;
            this.lblDateWork.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateWork.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateWork.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateWork.Location = new System.Drawing.Point(6, 12);
            this.lblDateWork.Name = "lblDateWork";
            this.lblDateWork.Size = new System.Drawing.Size(129, 18);
            this.lblDateWork.TabIndex = 0;
            this.lblDateWork.Text = "Дата выполнения";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Location = new System.Drawing.Point(263, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(97, 18);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Исполнитель";
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.lblOwners);
            this.pnlData.Controls.Add(this.cboOwners);
            this.pnlData.Controls.Add(this.lblAmount);
            this.pnlData.Controls.Add(this.lblTarif);
            this.pnlData.Controls.Add(this.lblQnt);
            this.pnlData.Controls.Add(this.numAmount);
            this.pnlData.Controls.Add(this.numTarif);
            this.pnlData.Controls.Add(this.numQnt);
            this.pnlData.Controls.Add(this.txtTabNumber);
            this.pnlData.Controls.Add(this.btnExtraWorkSelect);
            this.pnlData.Controls.Add(this.lblExtraWork);
            this.pnlData.Controls.Add(this.txtExtraWork);
            this.pnlData.Controls.Add(this.dtpDateExtraWork);
            this.pnlData.Controls.Add(this.cboUsers);
            this.pnlData.Controls.Add(this.lblUser);
            this.pnlData.Controls.Add(this.lblDateWork);
            this.pnlData.Controls.Add(this.lblNote);
            this.pnlData.Controls.Add(this.txtNote);
            this.pnlData.Location = new System.Drawing.Point(3, 6);
            this.pnlData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(669, 203);
            this.pnlData.TabIndex = 0;
            // 
            // lblOwners
            // 
            this.lblOwners.AutoSize = true;
            this.lblOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwners.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwners.Location = new System.Drawing.Point(6, 164);
            this.lblOwners.Name = "lblOwners";
            this.lblOwners.Size = new System.Drawing.Size(74, 18);
            this.lblOwners.TabIndex = 16;
            this.lblOwners.Text = "Владелец";
            // 
            // cboOwners
            // 
            this.cboOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboOwners.FormattingEnabled = true;
            this.cboOwners.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboOwners.Location = new System.Drawing.Point(130, 160);
            this.cboOwners.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboOwners.Name = "cboOwners";
            this.cboOwners.Size = new System.Drawing.Size(529, 26);
            this.cboOwners.TabIndex = 17;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblAmount.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAmount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAmount.Location = new System.Drawing.Point(466, 85);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(82, 18);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.Text = "Стоимость";
            // 
            // lblTarif
            // 
            this.lblTarif.AutoSize = true;
            this.lblTarif.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblTarif.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTarif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTarif.Location = new System.Drawing.Point(277, 85);
            this.lblTarif.Name = "lblTarif";
            this.lblTarif.Size = new System.Drawing.Size(54, 18);
            this.lblTarif.TabIndex = 10;
            this.lblTarif.Text = "Тариф";
            // 
            // lblQnt
            // 
            this.lblQnt.AutoSize = true;
            this.lblQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQnt.Location = new System.Drawing.Point(6, 85);
            this.lblQnt.Name = "lblQnt";
            this.lblQnt.Size = new System.Drawing.Size(88, 18);
            this.lblQnt.TabIndex = 8;
            this.lblQnt.Text = "Количество";
            // 
            // numAmount
            // 
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numAmount.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numAmount.Enabled = false;
            this.numAmount.InputMask = "#########0.00";
            this.numAmount.IsNull = false;
            this.numAmount.IsUserDraw = true;
            this.numAmount.Location = new System.Drawing.Point(546, 80);
            this.numAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numAmount.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numAmount.Name = "numAmount";
            this.numAmount.RealPlaces = 10;
            this.numAmount.Size = new System.Drawing.Size(114, 26);
            this.numAmount.TabIndex = 13;
            this.numAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numTarif
            // 
            this.numTarif.DecimalPlaces = 2;
            this.numTarif.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numTarif.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numTarif.InputMask = "#####0.00";
            this.numTarif.IsNull = false;
            this.numTarif.Location = new System.Drawing.Point(331, 80);
            this.numTarif.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numTarif.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numTarif.Name = "numTarif";
            this.numTarif.RealPlaces = 6;
            this.numTarif.Size = new System.Drawing.Size(114, 26);
            this.numTarif.TabIndex = 11;
            this.numTarif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTarif.Validated += new System.EventHandler(this.numQnt_Validated);
            // 
            // numQnt
            // 
            this.numQnt.DecimalPlaces = 1;
            this.numQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numQnt.InputMask = "######0.0";
            this.numQnt.IsNull = false;
            this.numQnt.Location = new System.Drawing.Point(130, 80);
            this.numQnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numQnt.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQnt.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numQnt.Name = "numQnt";
            this.numQnt.RealPlaces = 7;
            this.numQnt.Size = new System.Drawing.Size(114, 26);
            this.numQnt.TabIndex = 9;
            this.numQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQnt.Validated += new System.EventHandler(this.numQnt_Validated);
            // 
            // txtTabNumber
            // 
            this.txtTabNumber.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtTabNumber.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTabNumber.Location = new System.Drawing.Point(360, 6);
            this.txtTabNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTabNumber.MaxLength = 3;
            this.txtTabNumber.Name = "txtTabNumber";
            this.txtTabNumber.Size = new System.Drawing.Size(41, 26);
            this.txtTabNumber.TabIndex = 3;
            this.ttToolTip.SetToolTip(this.txtTabNumber, "Табельный номер");
            this.txtTabNumber.TextChanged += new System.EventHandler(this.txtTabNumber_TextChanged);
            // 
            // btnExtraWorkSelect
            // 
            this.btnExtraWorkSelect.FlatAppearance.BorderSize = 0;
            this.btnExtraWorkSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtraWorkSelect.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnExtraWorkSelect.Location = new System.Drawing.Point(630, 40);
            this.btnExtraWorkSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExtraWorkSelect.Name = "btnExtraWorkSelect";
            this.btnExtraWorkSelect.Size = new System.Drawing.Size(29, 32);
            this.btnExtraWorkSelect.TabIndex = 7;
            this.ttToolTip.SetToolTip(this.btnExtraWorkSelect, "Выбрать из ранее введенных значений");
            this.btnExtraWorkSelect.UseVisualStyleBackColor = true;
            this.btnExtraWorkSelect.Click += new System.EventHandler(this.btnExtraWorkSelect_Click);
            // 
            // lblExtraWork
            // 
            this.lblExtraWork.AutoSize = true;
            this.lblExtraWork.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblExtraWork.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblExtraWork.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExtraWork.Location = new System.Drawing.Point(6, 48);
            this.lblExtraWork.Name = "lblExtraWork";
            this.lblExtraWork.Size = new System.Drawing.Size(92, 18);
            this.lblExtraWork.TabIndex = 5;
            this.lblExtraWork.Text = "Доп. работа";
            // 
            // txtExtraWork
            // 
            this.txtExtraWork.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtExtraWork.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExtraWork.Location = new System.Drawing.Point(130, 42);
            this.txtExtraWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExtraWork.MaxLength = 200;
            this.txtExtraWork.Name = "txtExtraWork";
            this.txtExtraWork.Size = new System.Drawing.Size(494, 26);
            this.txtExtraWork.TabIndex = 6;
            // 
            // dtpDateExtraWork
            // 
            this.dtpDateExtraWork.CustomFormat = "dd.MM.yyyy";
            this.dtpDateExtraWork.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtpDateExtraWork.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtpDateExtraWork.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateExtraWork.Location = new System.Drawing.Point(130, 6);
            this.dtpDateExtraWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDateExtraWork.Name = "dtpDateExtraWork";
            this.dtpDateExtraWork.Size = new System.Drawing.Size(109, 26);
            this.dtpDateExtraWork.TabIndex = 1;
            // 
            // cboUsers
            // 
            this.cboUsers.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboUsers.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboUsers.Location = new System.Drawing.Point(405, 6);
            this.cboUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(255, 26);
            this.cboUsers.TabIndex = 4;
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDelimiter.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDelimiter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDelimiter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDelimiter.Location = new System.Drawing.Point(35, 3);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(13, 16);
            this.lblDelimiter.TabIndex = 1;
            // 
            // nudHours
            // 
            this.nudHours.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.nudHours.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.nudHours.InputMask = "###";
            this.nudHours.IsNull = false;
            this.nudHours.Location = new System.Drawing.Point(0, 0);
            this.nudHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudHours.Name = "nudHours";
            this.nudHours.RealPlaces = 3;
            this.nudHours.Size = new System.Drawing.Size(38, 26);
            this.nudHours.TabIndex = 0;
            this.nudHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudMinutes
            // 
            this.nudMinutes.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.nudMinutes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.nudMinutes.InputMask = "###";
            this.nudMinutes.IsNull = false;
            this.nudMinutes.Location = new System.Drawing.Point(44, 0);
            this.nudMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudMinutes.Name = "nudMinutes";
            this.nudMinutes.RealPlaces = 3;
            this.nudMinutes.Size = new System.Drawing.Size(38, 26);
            this.nudMinutes.TabIndex = 2;
            this.nudMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmSalaryExtraWorksEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 263);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.hpHelp.SetHelpKeyword(this, "");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsAccessOn = true;
            this.IsModalMode = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSalaryExtraWorksEdit";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительная внутрискладская работа";
            this.Load += new System.EventHandler(this.frmSalaryExtraWorksEdit_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTarif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMTextBox txtNote;
		private RFMBaseClasses.RFMLabel lblNote;
		private RFMBaseClasses.RFMLabel lblDateWork;
		private RFMBaseClasses.RFMLabel lblUser;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMComboBox cboUsers;
		private RFMBaseClasses.RFMDateTimePicker dtpDateExtraWork;
		private RFMBaseClasses.RFMLabel lblExtraWork;
		private RFMBaseClasses.RFMTextBox txtExtraWork;
		private RFMBaseClasses.RFMButton btnExtraWorkSelect;
		private RFMBaseClasses.RFMLabel lblDelimiter;
		private RFMBaseClasses.RFMNumericUpDown nudHours;
		private RFMBaseClasses.RFMNumericUpDown nudMinutes;
		private RFMBaseClasses.RFMTextBox txtTabNumber;
		private RFMBaseClasses.RFMLabel lblQnt;
		private RFMBaseClasses.RFMNumericUpDown numAmount;
		private RFMBaseClasses.RFMNumericUpDown numTarif;
		private RFMBaseClasses.RFMNumericUpDown numQnt;
		private RFMBaseClasses.RFMLabel lblAmount;
		private RFMBaseClasses.RFMLabel lblTarif;
        private RFMBaseClasses.RFMLabel lblOwners;
        private RFMBaseClasses.RFMComboBox cboOwners;
    }
}

