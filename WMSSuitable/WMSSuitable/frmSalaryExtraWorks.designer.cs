namespace WMSSuitable
{
	partial class frmSalaryExtraWorks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalaryExtraWorks));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcList = new RFMBaseClasses.RFMTabControl();
            this.tabTerms = new RFMBaseClasses.RFMTabPage();
            this.cntTerms = new RFMBaseClasses.RFMPanel();
            this.lblOwner = new RFMBaseClasses.RFMLabel();
            this.ucSelectRecordID_Users = new RFMBaseClasses.RFMSelectRecordIDTree();
            this.btnWorkSelect = new RFMBaseClasses.RFMButton();
            this.lblWorkName = new RFMBaseClasses.RFMLabel();
            this.txtWorkName = new RFMBaseClasses.RFMTextBox();
            this.lblUser = new RFMBaseClasses.RFMLabel();
            this.dtrDates = new RFMBaseClasses.RFMDateRange();
            this.btnClearTerms = new RFMBaseClasses.RFMButton();
            this.lblDate = new RFMBaseClasses.RFMLabel();
            this.tabSalaryExtraWorks = new RFMBaseClasses.RFMTabPage();
            this.dgvExtraWorks = new RFMBaseClasses.RFMDataGridView();
            this.btnEdit = new RFMBaseClasses.RFMButton();
            this.btnService = new RFMBaseClasses.RFMButton();
            this.btnPrint = new RFMBaseClasses.RFMButton();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnDelete = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.btnAdd = new RFMBaseClasses.RFMButton();
            this.pnlOwners = new RFMBaseClasses.RFMPanel();
            this.txtOwnersChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnOwnersClear = new RFMBaseClasses.RFMButton();
            this.btnOwnersChoose = new RFMBaseClasses.RFMButton();
            this.dgvcDateWork = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcUserName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcBrigadeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcWorkName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcPrice = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcAmount = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcWayBills_Note = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcERPCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.dgvcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.tcList.SuspendLayout();
            this.tabTerms.SuspendLayout();
            this.cntTerms.SuspendLayout();
            this.ucSelectRecordID_Users.SuspendLayout();
            this.dtrDates.SuspendLayout();
            this.tabSalaryExtraWorks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraWorks)).BeginInit();
            this.pnlOwners.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcList
            // 
            this.tcList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcList.Controls.Add(this.tabTerms);
            this.tcList.Controls.Add(this.tabSalaryExtraWorks);
            this.tcList.Location = new System.Drawing.Point(1, 1);
            this.tcList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcList.Name = "tcList";
            this.tcList.SelectedIndex = 0;
            this.tcList.Size = new System.Drawing.Size(847, 555);
            this.tcList.TabIndex = 0;
            // 
            // tabTerms
            // 
            this.tabTerms.Controls.Add(this.cntTerms);
            this.tabTerms.IsFilterPage = true;
            this.tabTerms.Location = new System.Drawing.Point(4, 27);
            this.tabTerms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabTerms.Name = "tabTerms";
            this.tabTerms.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabTerms.Size = new System.Drawing.Size(839, 524);
            this.tabTerms.TabIndex = 0;
            this.tabTerms.Text = "Условия";
            this.tabTerms.UseVisualStyleBackColor = true;
            // 
            // cntTerms
            // 
            this.cntTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cntTerms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cntTerms.Controls.Add(this.pnlOwners);
            this.cntTerms.Controls.Add(this.lblOwner);
            this.cntTerms.Controls.Add(this.ucSelectRecordID_Users);
            this.cntTerms.Controls.Add(this.btnWorkSelect);
            this.cntTerms.Controls.Add(this.lblWorkName);
            this.cntTerms.Controls.Add(this.txtWorkName);
            this.cntTerms.Controls.Add(this.lblUser);
            this.cntTerms.Controls.Add(this.dtrDates);
            this.cntTerms.Controls.Add(this.btnClearTerms);
            this.cntTerms.Controls.Add(this.lblDate);
            this.cntTerms.Location = new System.Drawing.Point(0, 3);
            this.cntTerms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cntTerms.Name = "cntTerms";
            this.cntTerms.Size = new System.Drawing.Size(836, 516);
            this.cntTerms.TabIndex = 0;
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwner.Location = new System.Drawing.Point(10, 110);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(74, 18);
            this.lblOwner.TabIndex = 9;
            this.lblOwner.Text = "Владелец";
            // 
            // ucSelectRecordID_Users
            // 
            // 
            // ucSelectRecordID_Users.btnClear
            // 
            this.ucSelectRecordID_Users.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Users.BtnClear.Image = ((System.Drawing.Image)(resources.GetObject("ucSelectRecordID_Users.btnClear.Image")));
            this.ucSelectRecordID_Users.BtnClear.Location = new System.Drawing.Point(252, 3);
            this.ucSelectRecordID_Users.BtnClear.Name = "btnClear";
            this.ucSelectRecordID_Users.BtnClear.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Users.BtnClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Users.BtnClear, "Очистить выбор бригады/сотрудника");
            this.ucSelectRecordID_Users.BtnClear.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_Users.btnSelect
            // 
            this.ucSelectRecordID_Users.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Users.BtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("ucSelectRecordID_Users.btnSelect.Image")));
            this.ucSelectRecordID_Users.BtnSelect.Location = new System.Drawing.Point(226, 3);
            this.ucSelectRecordID_Users.BtnSelect.Name = "btnSelect";
            this.ucSelectRecordID_Users.BtnSelect.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Users.BtnSelect.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Users.BtnSelect, "Выбор бригады/сотрудника");
            this.ucSelectRecordID_Users.BtnSelect.UseVisualStyleBackColor = true;
            this.ucSelectRecordID_Users.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ucSelectRecordID_Users.IsSaveMark = true;
            this.ucSelectRecordID_Users.IsUseMark = true;
            this.ucSelectRecordID_Users.Location = new System.Drawing.Point(153, 50);
            this.ucSelectRecordID_Users.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSelectRecordID_Users.MarkedCount = 0;
            this.ucSelectRecordID_Users.Name = "ucSelectRecordID_Users";
            this.ucSelectRecordID_Users.Size = new System.Drawing.Size(315, 39);
            this.ucSelectRecordID_Users.TabIndex = 3;
            this.ucSelectRecordID_Users.TableColumnName = "Name";
            // 
            // ucSelectRecordID_Users.txtData
            // 
            this.ucSelectRecordID_Users.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Users.TxtData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.ucSelectRecordID_Users.TxtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.ucSelectRecordID_Users.TxtData.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucSelectRecordID_Users.TxtData.IsUserDraw = true;
            this.ucSelectRecordID_Users.TxtData.Location = new System.Drawing.Point(4, 4);
            this.ucSelectRecordID_Users.TxtData.Name = "txtData";
            this.ucSelectRecordID_Users.TxtData.ReadOnly = true;
            this.ucSelectRecordID_Users.TxtData.Size = new System.Drawing.Size(220, 26);
            this.ucSelectRecordID_Users.TxtData.TabIndex = 3;
            // 
            // btnWorkSelect
            // 
            this.btnWorkSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkSelect.FlatAppearance.BorderSize = 0;
            this.btnWorkSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkSelect.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnWorkSelect.Location = new System.Drawing.Point(413, 153);
            this.btnWorkSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWorkSelect.Name = "btnWorkSelect";
            this.btnWorkSelect.Size = new System.Drawing.Size(29, 32);
            this.btnWorkSelect.TabIndex = 6;
            this.ttToolTip.SetToolTip(this.btnWorkSelect, "Выбор из ранее введенных значений");
            this.btnWorkSelect.UseVisualStyleBackColor = true;
            this.btnWorkSelect.Click += new System.EventHandler(this.btnWorkSelect_Click);
            // 
            // lblWorkName
            // 
            this.lblWorkName.AutoSize = true;
            this.lblWorkName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblWorkName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblWorkName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWorkName.Location = new System.Drawing.Point(10, 160);
            this.lblWorkName.Name = "lblWorkName";
            this.lblWorkName.Size = new System.Drawing.Size(89, 18);
            this.lblWorkName.TabIndex = 4;
            this.lblWorkName.Text = "Назначение";
            // 
            // txtWorkName
            // 
            this.txtWorkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtWorkName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorkName.Location = new System.Drawing.Point(158, 156);
            this.txtWorkName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWorkName.MaxLength = 200;
            this.txtWorkName.Name = "txtWorkName";
            this.txtWorkName.Size = new System.Drawing.Size(251, 26);
            this.txtWorkName.TabIndex = 5;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Location = new System.Drawing.Point(10, 60);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(97, 18);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Исполнитель";
            // 
            // dtrDates
            // 
            this.dtrDates.BegValue = new System.DateTime(2007, 7, 31, 0, 0, 0, 0);
            // 
            // dtrDates.btnClear
            // 
            this.dtrDates.BtnСlear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dtrDates.BtnСlear.Image = ((System.Drawing.Image)(resources.GetObject("dtrDates.btnClear.Image")));
            this.dtrDates.BtnСlear.Location = new System.Drawing.Point(195, 4);
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
            this.dtrDates.DtpBegDate.Size = new System.Drawing.Size(91, 26);
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
            this.dtrDates.DtpEndDate.Size = new System.Drawing.Size(91, 26);
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
            this.dtrDates.LblDelimiter.Size = new System.Drawing.Size(16, 21);
            this.dtrDates.LblDelimiter.TabIndex = 1;
            this.dtrDates.LblDelimiter.Text = ":";
            this.dtrDates.Location = new System.Drawing.Point(158, 4);
            this.dtrDates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtrDates.Name = "dtrDates";
            this.dtrDates.Size = new System.Drawing.Size(254, 37);
            this.dtrDates.TabIndex = 1;
            // 
            // btnClearTerms
            // 
            this.btnClearTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTerms.FlatAppearance.BorderSize = 0;
            this.btnClearTerms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTerms.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnClearTerms.Location = new System.Drawing.Point(805, 481);
            this.btnClearTerms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearTerms.Name = "btnClearTerms";
            this.btnClearTerms.Size = new System.Drawing.Size(25, 28);
            this.btnClearTerms.TabIndex = 7;
            this.ttToolTip.SetToolTip(this.btnClearTerms, "Очистить условия");
            this.btnClearTerms.Click += new System.EventHandler(this.btnClearTerms_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDate.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Location = new System.Drawing.Point(10, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(110, 18);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата действия";
            // 
            // tabSalaryExtraWorks
            // 
            this.tabSalaryExtraWorks.Controls.Add(this.dgvExtraWorks);
            this.tabSalaryExtraWorks.Location = new System.Drawing.Point(4, 27);
            this.tabSalaryExtraWorks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSalaryExtraWorks.Name = "tabSalaryExtraWorks";
            this.tabSalaryExtraWorks.Size = new System.Drawing.Size(839, 524);
            this.tabSalaryExtraWorks.TabIndex = 1;
            this.tabSalaryExtraWorks.Text = "Дополнительные работы";
            this.tabSalaryExtraWorks.UseVisualStyleBackColor = true;
            // 
            // dgvExtraWorks
            // 
            this.dgvExtraWorks.AllowUserToAddRows = false;
            this.dgvExtraWorks.AllowUserToDeleteRows = false;
            this.dgvExtraWorks.AllowUserToOrderColumns = true;
            this.dgvExtraWorks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExtraWorks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvExtraWorks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExtraWorks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExtraWorks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExtraWorks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtraWorks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcDateWork,
            this.dgvcOwnerName,
            this.dgvcUserName,
            this.dgvcBrigadeName,
            this.dgvcWorkName,
            this.dgvcQnt,
            this.dgvcPrice,
            this.dgvcAmount,
            this.grcWayBills_Note,
            this.dgvcERPCode,
            this.dgvcID});
            this.dgvExtraWorks.IsCheckerInclude = true;
            this.dgvExtraWorks.IsConfigInclude = true;
            this.dgvExtraWorks.IsMarkedAll = false;
            this.dgvExtraWorks.IsStatusInclude = true;
            this.dgvExtraWorks.IsStatusShow = true;
            this.dgvExtraWorks.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.dgvExtraWorks.Location = new System.Drawing.Point(2, 4);
            this.dgvExtraWorks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvExtraWorks.MultiSelect = false;
            this.dgvExtraWorks.Name = "dgvExtraWorks";
            this.dgvExtraWorks.RangedWay = ' ';
            this.dgvExtraWorks.ReadOnly = true;
            this.dgvExtraWorks.RowHeadersWidth = 24;
            this.dgvExtraWorks.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExtraWorks.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.dgvExtraWorks.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.dgvExtraWorks.Size = new System.Drawing.Size(833, 514);
            this.dgvExtraWorks.StatusRowState = ((byte)(2));
            this.dgvExtraWorks.TabIndex = 16;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(578, 564);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(34, 39);
            this.btnEdit.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnEdit, "Редактирование");
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnService
            // 
            this.btnService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnService.Image = global::WMSSuitable.Properties.Resources.Service;
            this.btnService.Location = new System.Drawing.Point(750, 564);
            this.btnService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(34, 39);
            this.btnService.TabIndex = 5;
            this.ttToolTip.SetToolTip(this.btnService, "Дополнительно");
            this.btnService.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
            this.btnPrint.Location = new System.Drawing.Point(693, 564);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(34, 39);
            this.btnPrint.TabIndex = 4;
            this.ttToolTip.SetToolTip(this.btnPrint, "Печать");
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(6, 564);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(34, 39);
            this.btnHelp.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.btnHelp, "Помощь");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(635, 564);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(34, 39);
            this.btnDelete.TabIndex = 3;
            this.ttToolTip.SetToolTip(this.btnDelete, "Удаление");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnCancel.Location = new System.Drawing.Point(807, 564);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(34, 39);
            this.btnCancel.TabIndex = 6;
            this.ttToolTip.SetToolTip(this.btnCancel, "Выход");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(521, 564);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 39);
            this.btnAdd.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnAdd, "Добавление");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlOwners
            // 
            this.pnlOwners.Controls.Add(this.txtOwnersChoosen);
            this.pnlOwners.Controls.Add(this.btnOwnersClear);
            this.pnlOwners.Controls.Add(this.btnOwnersChoose);
            this.pnlOwners.Location = new System.Drawing.Point(156, 99);
            this.pnlOwners.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOwners.Name = "pnlOwners";
            this.pnlOwners.Size = new System.Drawing.Size(297, 39);
            this.pnlOwners.TabIndex = 14;
            // 
            // txtOwnersChoosen
            // 
            this.txtOwnersChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOwnersChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwnersChoosen.Enabled = false;
            this.txtOwnersChoosen.Location = new System.Drawing.Point(1, 5);
            this.txtOwnersChoosen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOwnersChoosen.Name = "txtOwnersChoosen";
            this.txtOwnersChoosen.OldValue = "";
            this.txtOwnersChoosen.Size = new System.Drawing.Size(228, 26);
            this.txtOwnersChoosen.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.txtOwnersChoosen, "Выбранные владельцы");
            // 
            // btnOwnersClear
            // 
            this.btnOwnersClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnOwnersClear.Location = new System.Drawing.Point(264, 4);
            this.btnOwnersClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOwnersClear.Name = "btnOwnersClear";
            this.btnOwnersClear.Size = new System.Drawing.Size(30, 31);
            this.btnOwnersClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnOwnersClear, "Очистить выбор владельцев");
            this.btnOwnersClear.UseVisualStyleBackColor = true;
            this.btnOwnersClear.Click += new System.EventHandler(this.btnOwnersClear_Click);
            // 
            // btnOwnersChoose
            // 
            this.btnOwnersChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnOwnersChoose.Location = new System.Drawing.Point(232, 4);
            this.btnOwnersChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOwnersChoose.Name = "btnOwnersChoose";
            this.btnOwnersChoose.Size = new System.Drawing.Size(30, 31);
            this.btnOwnersChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnOwnersChoose, "Выбор владельцев");
            this.btnOwnersChoose.UseVisualStyleBackColor = true;
            this.btnOwnersChoose.Click += new System.EventHandler(this.btnOwnersChoose_Click);
            // 
            // dgvcDateWork
            // 
            this.dgvcDateWork.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcDateWork.DataPropertyName = "DateWork";
            dataGridViewCellStyle2.Format = "dd.MM.yyyy";
            this.dgvcDateWork.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcDateWork.HeaderText = "Дата";
            this.dgvcDateWork.Name = "dgvcDateWork";
            this.dgvcDateWork.ReadOnly = true;
            this.dgvcDateWork.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcDateWork.ToolTipText = "Дата выполнения работ";
            this.dgvcDateWork.Width = 80;
            // 
            // dgvcOwnerName
            // 
            this.dgvcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcOwnerName.DataPropertyName = "OwnerName";
            this.dgvcOwnerName.HeaderText = "Владелец";
            this.dgvcOwnerName.Name = "dgvcOwnerName";
            this.dgvcOwnerName.ReadOnly = true;
            this.dgvcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcOwnerName.Width = 150;
            // 
            // dgvcUserName
            // 
            this.dgvcUserName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcUserName.DataPropertyName = "UserName";
            this.dgvcUserName.HeaderText = "Исполнитель";
            this.dgvcUserName.Name = "dgvcUserName";
            this.dgvcUserName.ReadOnly = true;
            this.dgvcUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcUserName.Width = 200;
            // 
            // dgvcBrigadeName
            // 
            this.dgvcBrigadeName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcBrigadeName.DataPropertyName = "BrigadeName";
            this.dgvcBrigadeName.HeaderText = "Бригада";
            this.dgvcBrigadeName.Name = "dgvcBrigadeName";
            this.dgvcBrigadeName.ReadOnly = true;
            this.dgvcBrigadeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcBrigadeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvcWorkName
            // 
            this.dgvcWorkName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcWorkName.DataPropertyName = "WorkName";
            this.dgvcWorkName.HeaderText = "Работа";
            this.dgvcWorkName.Name = "dgvcWorkName";
            this.dgvcWorkName.ReadOnly = true;
            this.dgvcWorkName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcWorkName.ToolTipText = "Название работы";
            this.dgvcWorkName.Width = 200;
            // 
            // dgvcQnt
            // 
            this.dgvcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcQnt.DataPropertyName = "Qnt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvcQnt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcQnt.HeaderText = "Кол-во";
            this.dgvcQnt.Name = "dgvcQnt";
            this.dgvcQnt.ReadOnly = true;
            this.dgvcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcQnt.ToolTipText = "Количество";
            this.dgvcQnt.Width = 60;
            // 
            // dgvcPrice
            // 
            this.dgvcPrice.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcPrice.DataPropertyName = "Price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.dgvcPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvcPrice.HeaderText = "Тариф";
            this.dgvcPrice.Name = "dgvcPrice";
            this.dgvcPrice.ReadOnly = true;
            this.dgvcPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcPrice.ToolTipText = "Тариф (стоимость за единицу работ)";
            this.dgvcPrice.Width = 60;
            // 
            // dgvcAmount
            // 
            this.dgvcAmount.AgrType = RFMBaseClasses.EnumAgregate.Sum;
            this.dgvcAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dgvcAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvcAmount.HeaderText = "Стоимость";
            this.dgvcAmount.Name = "dgvcAmount";
            this.dgvcAmount.ReadOnly = true;
            this.dgvcAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcAmount.Width = 80;
            // 
            // grcWayBills_Note
            // 
            this.grcWayBills_Note.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcWayBills_Note.DataPropertyName = "Note";
            this.grcWayBills_Note.HeaderText = "Примечание";
            this.grcWayBills_Note.Name = "grcWayBills_Note";
            this.grcWayBills_Note.ReadOnly = true;
            this.grcWayBills_Note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcWayBills_Note.Width = 200;
            // 
            // dgvcERPCode
            // 
            this.dgvcERPCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcERPCode.DataPropertyName = "ERPCode";
            this.dgvcERPCode.HeaderText = "ERPCode";
            this.dgvcERPCode.Name = "dgvcERPCode";
            this.dgvcERPCode.ReadOnly = true;
            this.dgvcERPCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcERPCode.ToolTipText = "Код в host-системе";
            this.dgvcERPCode.Width = 80;
            // 
            // dgvcID
            // 
            this.dgvcID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.dgvcID.DataPropertyName = "ID";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvcID.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            this.dgvcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcID.ToolTipText = "Код записи";
            this.dgvcID.Width = 50;
            // 
            // frmSalaryExtraWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 609);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnService);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tcList);
            this.hpHelp.SetHelpKeyword(this, "102");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.hpHelp.SetHelpString(this, "");
            this.IsAccessOn = true;
            this.IsWaitLoading = true;
            this.LastGrid = this.dgvExtraWorks;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MinimumSize = new System.Drawing.Size(855, 631);
            this.Name = "frmSalaryExtraWorks";
            this.hpHelp.SetShowHelp(this, true);
            this.Text = "Дополнительные внутрискладские работы";
            this.Load += new System.EventHandler(this.frmSalaryExtraWorks_Load);
            this.tcList.ResumeLayout(false);
            this.tabTerms.ResumeLayout(false);
            this.cntTerms.ResumeLayout(false);
            this.cntTerms.PerformLayout();
            this.ucSelectRecordID_Users.ResumeLayout(false);
            this.ucSelectRecordID_Users.PerformLayout();
            this.dtrDates.ResumeLayout(false);
            this.dtrDates.PerformLayout();
            this.tabSalaryExtraWorks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtraWorks)).EndInit();
            this.pnlOwners.ResumeLayout(false);
            this.pnlOwners.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMTabControl tcList;
        private RFMBaseClasses.RFMTabPage tabTerms;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnAdd;
        private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMButton btnPrint;
		private RFMBaseClasses.RFMButton btnService;
		private RFMBaseClasses.RFMButton btnClearTerms;
		private RFMBaseClasses.RFMPanel cntTerms;
		private RFMBaseClasses.RFMLabel lblDate;
		private RFMBaseClasses.RFMDateRange dtrDates;
		private RFMBaseClasses.RFMLabel lblUser;
		private RFMBaseClasses.RFMTabPage tabSalaryExtraWorks;
		private RFMBaseClasses.RFMDataGridView dgvExtraWorks;
		private RFMBaseClasses.RFMButton btnWorkSelect;
		private RFMBaseClasses.RFMLabel lblWorkName;
		private RFMBaseClasses.RFMTextBox txtWorkName;
		private RFMBaseClasses.RFMSelectRecordIDTree ucSelectRecordID_Users;
        private RFMBaseClasses.RFMLabel lblOwner;
        private RFMBaseClasses.RFMPanel pnlOwners;
        private RFMBaseClasses.RFMTextBox txtOwnersChoosen;
        private RFMBaseClasses.RFMButton btnOwnersClear;
        private RFMBaseClasses.RFMButton btnOwnersChoose;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcDateWork;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcOwnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcUserName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcBrigadeName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcWorkName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcQnt;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcPrice;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcAmount;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcWayBills_Note;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcERPCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcID;
    }
}