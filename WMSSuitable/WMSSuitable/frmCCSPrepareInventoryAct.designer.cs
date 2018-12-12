namespace WMSSuitable
{
	partial class frmCCSPrepareInventoryAct 
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
            this.btnSave = new RFMBaseClasses.RFMButton();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.pnlFilter = new RFMBaseClasses.RFMPanel();
            this.lblHosts = new RFMBaseClasses.RFMLabel();
            this.ucSelectRecordID_Hosts = new RFMBaseClasses.RFMSelectRecordIDGrid();
            this.cboOwners = new RFMBaseClasses.RFMComboBox();
            this.lblEmptyOwner = new RFMBaseClasses.RFMLabel();
            this.pnlGoodsStates = new RFMBaseClasses.RFMPanel();
            this.txtGoodsStatesChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnGoodsStatesClear = new RFMBaseClasses.RFMButton();
            this.btnGoodsStatesChoose = new RFMBaseClasses.RFMButton();
            this.pnlPackings = new RFMBaseClasses.RFMPanel();
            this.txtPackingsChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnPackingsClear = new RFMBaseClasses.RFMButton();
            this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
            this.btnFilter = new RFMBaseClasses.RFMButton();
            this.lblGoodsStates = new RFMBaseClasses.RFMLabel();
            this.lblGoods = new RFMBaseClasses.RFMLabel();
            this.btnSelect = new RFMBaseClasses.RFMButton();
            this.btnClear = new RFMBaseClasses.RFMButton();
            this.txtData = new RFMBaseClasses.RFMTextBox();
            this.grcHostName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxes = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcCost = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcCostAmount = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.ucSelectRecordID_Hosts.SuspendLayout();
            this.pnlGoodsStates.SuspendLayout();
            this.pnlPackings.SuspendLayout();
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(647, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 30);
            this.btnSave.TabIndex = 12;
            this.ttToolTip.SetToolTip(this.btnSave, "Сохранить акт(ы)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.grcHostName,
            this.grcOwnerName,
            this.grcGoodStateName,
            this.grcGoodGroupName,
            this.grcGoodName,
            this.grcInBox,
            this.grcQnt,
            this.grcBoxes,
            this.grcCost,
            this.grcCostAmount});
            this.grdData.IsCheckerInclude = true;
            this.grdData.IsCheckerShow = true;
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
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
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(730, 315);
            this.grdData.TabIndex = 13;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFilter.Controls.Add(this.lblHosts);
            this.pnlFilter.Controls.Add(this.ucSelectRecordID_Hosts);
            this.pnlFilter.Controls.Add(this.cboOwners);
            this.pnlFilter.Controls.Add(this.lblEmptyOwner);
            this.pnlFilter.Controls.Add(this.pnlGoodsStates);
            this.pnlFilter.Controls.Add(this.pnlPackings);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.lblGoodsStates);
            this.pnlFilter.Controls.Add(this.lblGoods);
            this.pnlFilter.Location = new System.Drawing.Point(2, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(730, 100);
            this.pnlFilter.TabIndex = 14;
            // 
            // lblHosts
            // 
            this.lblHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHosts.AutoSize = true;
            this.lblHosts.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblHosts.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblHosts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHosts.Location = new System.Drawing.Point(430, 14);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(41, 14);
            this.lblHosts.TabIndex = 32;
            this.lblHosts.Text = "Хосты";
            // 
            // ucSelectRecordID_Hosts
            // 
            this.ucSelectRecordID_Hosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ucSelectRecordID_Hosts.btnClear
            // 
            this.ucSelectRecordID_Hosts.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Hosts.BtnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.ucSelectRecordID_Hosts.BtnClear.Location = new System.Drawing.Point(225, 0);
            this.ucSelectRecordID_Hosts.BtnClear.Name = "btnClear";
            this.ucSelectRecordID_Hosts.BtnClear.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Hosts.BtnClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Hosts.BtnClear, "Очистка выбора хостов");
            this.ucSelectRecordID_Hosts.BtnClear.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_Hosts.btnSelect
            // 
            this.ucSelectRecordID_Hosts.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Hosts.BtnSelect.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.ucSelectRecordID_Hosts.BtnSelect.Location = new System.Drawing.Point(199, 0);
            this.ucSelectRecordID_Hosts.BtnSelect.Name = "btnSelect";
            this.ucSelectRecordID_Hosts.BtnSelect.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_Hosts.BtnSelect.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_Hosts.BtnSelect, "Выбор хостов");
            this.ucSelectRecordID_Hosts.BtnSelect.UseVisualStyleBackColor = true;
            this.ucSelectRecordID_Hosts.ExpSort = "Name";
            this.ucSelectRecordID_Hosts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ucSelectRecordID_Hosts.IsActualOnly = true;
            this.ucSelectRecordID_Hosts.IsSaveMark = true;
            this.ucSelectRecordID_Hosts.IsUseMark = true;
            this.ucSelectRecordID_Hosts.Location = new System.Drawing.Point(475, 9);
            this.ucSelectRecordID_Hosts.MarkedCount = 0;
            this.ucSelectRecordID_Hosts.Name = "ucSelectRecordID_Hosts";
            this.ucSelectRecordID_Hosts.Size = new System.Drawing.Size(252, 24);
            this.ucSelectRecordID_Hosts.TabIndex = 33;
            this.ucSelectRecordID_Hosts.TableColumnName = "Name";
            // 
            // ucSelectRecordID_Hosts.txtData
            // 
            this.ucSelectRecordID_Hosts.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Hosts.TxtData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.ucSelectRecordID_Hosts.TxtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.ucSelectRecordID_Hosts.TxtData.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucSelectRecordID_Hosts.TxtData.IsUserDraw = true;
            this.ucSelectRecordID_Hosts.TxtData.Location = new System.Drawing.Point(0, 1);
            this.ucSelectRecordID_Hosts.TxtData.MaxLength = 128;
            this.ucSelectRecordID_Hosts.TxtData.Name = "txtData";
            this.ucSelectRecordID_Hosts.TxtData.ReadOnly = true;
            this.ucSelectRecordID_Hosts.TxtData.Size = new System.Drawing.Size(197, 22);
            this.ucSelectRecordID_Hosts.TxtData.TabIndex = 0;
            this.ucSelectRecordID_Hosts.СolumnsData.AddRange(new string[] {
            "Name, Хост"});
            // 
            // cboOwners
            // 
            this.cboOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboOwners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwners.FormattingEnabled = true;
            this.cboOwners.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboOwners.Location = new System.Drawing.Point(130, 70);
            this.cboOwners.Name = "cboOwners";
            this.cboOwners.OldValue = -1;
            this.cboOwners.Size = new System.Drawing.Size(275, 22);
            this.cboOwners.TabIndex = 26;
            // 
            // lblEmptyOwner
            // 
            this.lblEmptyOwner.AutoSize = true;
            this.lblEmptyOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblEmptyOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblEmptyOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmptyOwner.Location = new System.Drawing.Point(5, 74);
            this.lblEmptyOwner.Name = "lblEmptyOwner";
            this.lblEmptyOwner.Size = new System.Drawing.Size(118, 14);
            this.lblEmptyOwner.TabIndex = 25;
            this.lblEmptyOwner.Text = "Пустой владелец =";
            // 
            // pnlGoodsStates
            // 
            this.pnlGoodsStates.Controls.Add(this.txtGoodsStatesChoosen);
            this.pnlGoodsStates.Controls.Add(this.btnGoodsStatesClear);
            this.pnlGoodsStates.Controls.Add(this.btnGoodsStatesChoose);
            this.pnlGoodsStates.Location = new System.Drawing.Point(130, 5);
            this.pnlGoodsStates.Name = "pnlGoodsStates";
            this.pnlGoodsStates.Size = new System.Drawing.Size(278, 30);
            this.pnlGoodsStates.TabIndex = 24;
            // 
            // txtGoodsStatesChoosen
            // 
            this.txtGoodsStatesChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtGoodsStatesChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGoodsStatesChoosen.Enabled = false;
            this.txtGoodsStatesChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtGoodsStatesChoosen.Name = "txtGoodsStatesChoosen";
            this.txtGoodsStatesChoosen.OldValue = "";
            this.txtGoodsStatesChoosen.Size = new System.Drawing.Size(218, 22);
            this.txtGoodsStatesChoosen.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.txtGoodsStatesChoosen, "Выбранные состояния товаров");
            // 
            // btnGoodsStatesClear
            // 
            this.btnGoodsStatesClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnGoodsStatesClear.Location = new System.Drawing.Point(249, 3);
            this.btnGoodsStatesClear.Name = "btnGoodsStatesClear";
            this.btnGoodsStatesClear.Size = new System.Drawing.Size(26, 24);
            this.btnGoodsStatesClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnGoodsStatesClear, "Очистить выбор состояний товаров");
            this.btnGoodsStatesClear.UseVisualStyleBackColor = true;
            this.btnGoodsStatesClear.Click += new System.EventHandler(this.btnGoodsStatesClear_Click);
            // 
            // btnGoodsStatesChoose
            // 
            this.btnGoodsStatesChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnGoodsStatesChoose.Location = new System.Drawing.Point(221, 3);
            this.btnGoodsStatesChoose.Name = "btnGoodsStatesChoose";
            this.btnGoodsStatesChoose.Size = new System.Drawing.Size(26, 24);
            this.btnGoodsStatesChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnGoodsStatesChoose, "Выбор состояний товаров");
            this.btnGoodsStatesChoose.UseVisualStyleBackColor = true;
            this.btnGoodsStatesChoose.Click += new System.EventHandler(this.btnGoodsStatesChoose_Click);
            // 
            // pnlPackings
            // 
            this.pnlPackings.Controls.Add(this.txtPackingsChoosen);
            this.pnlPackings.Controls.Add(this.btnPackingsClear);
            this.pnlPackings.Controls.Add(this.btnPackingsChoose);
            this.pnlPackings.Location = new System.Drawing.Point(130, 35);
            this.pnlPackings.Name = "pnlPackings";
            this.pnlPackings.Size = new System.Drawing.Size(278, 30);
            this.pnlPackings.TabIndex = 23;
            // 
            // txtPackingsChoosen
            // 
            this.txtPackingsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtPackingsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPackingsChoosen.Enabled = false;
            this.txtPackingsChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtPackingsChoosen.Name = "txtPackingsChoosen";
            this.txtPackingsChoosen.OldValue = "";
            this.txtPackingsChoosen.Size = new System.Drawing.Size(218, 22);
            this.txtPackingsChoosen.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.txtPackingsChoosen, "Контекст названия поставщика");
            // 
            // btnPackingsClear
            // 
            this.btnPackingsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnPackingsClear.Location = new System.Drawing.Point(249, 3);
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
            this.btnPackingsChoose.Location = new System.Drawing.Point(221, 3);
            this.btnPackingsChoose.Name = "btnPackingsChoose";
            this.btnPackingsChoose.Size = new System.Drawing.Size(26, 24);
            this.btnPackingsChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnPackingsChoose, "Выбор товаров");
            this.btnPackingsChoose.UseVisualStyleBackColor = true;
            this.btnPackingsChoose.Click += new System.EventHandler(this.btnPackingsChoose_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnFilter.Location = new System.Drawing.Point(690, 60);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(30, 30);
            this.btnFilter.TabIndex = 22;
            this.ttToolTip.SetToolTip(this.btnFilter, "Показать товары, соответствующие условиям (<F5>)");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblGoodsStates
            // 
            this.lblGoodsStates.AutoSize = true;
            this.lblGoodsStates.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodsStates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodsStates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodsStates.Location = new System.Drawing.Point(5, 14);
            this.lblGoodsStates.Name = "lblGoodsStates";
            this.lblGoodsStates.Size = new System.Drawing.Size(117, 14);
            this.lblGoodsStates.TabIndex = 18;
            this.lblGoodsStates.Text = "Состояния товаров";
            // 
            // lblGoods
            // 
            this.lblGoods.AutoSize = true;
            this.lblGoods.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoods.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoods.Location = new System.Drawing.Point(5, 44);
            this.lblGoods.Name = "lblGoods";
            this.lblGoods.Size = new System.Drawing.Size(49, 14);
            this.lblGoods.TabIndex = 4;
            this.lblGoods.Text = "Товары";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnSelect.Location = new System.Drawing.Point(218, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(24, 24);
            this.btnSelect.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnSelect, "Выбор сотрудников");
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnClear.Location = new System.Drawing.Point(244, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnClear, "Очистка выбора сотрудников");
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtData.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtData.IsUserDraw = true;
            this.txtData.Location = new System.Drawing.Point(0, 1);
            this.txtData.MaxLength = 128;
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(216, 22);
            this.txtData.TabIndex = 0;
            // 
            // grcHostName
            // 
            this.grcHostName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcHostName.DataPropertyName = "HostName";
            this.grcHostName.HeaderText = "Хост";
            this.grcHostName.Name = "grcHostName";
            this.grcHostName.ReadOnly = true;
            this.grcHostName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcHostName.Width = 150;
            // 
            // grcOwnerName
            // 
            this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOwnerName.DataPropertyName = "OwnerName";
            this.grcOwnerName.FillWeight = 150F;
            this.grcOwnerName.HeaderText = "Владелец";
            this.grcOwnerName.Name = "grcOwnerName";
            this.grcOwnerName.ReadOnly = true;
            this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcOwnerName.Width = 150;
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
            // grcGoodGroupName
            // 
            this.grcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodGroupName.DataPropertyName = "GoodGroupName";
            this.grcGoodGroupName.HeaderText = "Группа";
            this.grcGoodGroupName.Name = "grcGoodGroupName";
            this.grcGoodGroupName.ReadOnly = true;
            this.grcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodGroupName.Width = 250;
            // 
            // grcGoodName
            // 
            this.grcGoodName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodName.DataPropertyName = "GoodName";
            this.grcGoodName.HeaderText = "Товар";
            this.grcGoodName.Name = "grcGoodName";
            this.grcGoodName.ReadOnly = true;
            this.grcGoodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodName.Width = 250;
            // 
            // grcInBox
            // 
            this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcInBox.DataPropertyName = "InBox";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            this.grcInBox.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcInBox.HeaderText = "В кор.";
            this.grcInBox.Name = "grcInBox";
            this.grcInBox.ReadOnly = true;
            this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcInBox.Width = 60;
            // 
            // grcQnt
            // 
            this.grcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQnt.DataPropertyName = "Qnt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            this.grcQnt.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcQnt.HeaderText = "Штук (кг)";
            this.grcQnt.Name = "grcQnt";
            this.grcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQnt.Width = 80;
            // 
            // grcBoxes
            // 
            this.grcBoxes.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxes.DataPropertyName = "Boxes";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N1";
            this.grcBoxes.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcBoxes.HeaderText = "Кор.";
            this.grcBoxes.Name = "grcBoxes";
            this.grcBoxes.ReadOnly = true;
            this.grcBoxes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxes.Width = 60;
            // 
            // grcCost
            // 
            this.grcCost.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcCost.DataPropertyName = "Cost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.grcCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcCost.HeaderText = "Себестоимость";
            this.grcCost.Name = "grcCost";
            this.grcCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcCostAmount
            // 
            this.grcCostAmount.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcCostAmount.DataPropertyName = "CostAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.grcCostAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcCostAmount.HeaderText = "Сумма";
            this.grcCostAmount.Name = "grcCostAmount";
            this.grcCostAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcCostAmount.ToolTipText = "Сумма себестоимостей";
            this.grcCostAmount.Width = 120;
            // 
            // frmCCSPrepareInventoryAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.hpHelp.SetHelpKeyword(this, "802");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsAccessOn = true;
            this.IsModalMode = true;
            this.Name = "frmCCSPrepareInventoryAct";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подготовка списка товаров для актирования";
            this.Load += new System.EventHandler(this.frmShifts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ucSelectRecordID_Hosts.ResumeLayout(false);
            this.ucSelectRecordID_Hosts.PerformLayout();
            this.pnlGoodsStates.ResumeLayout(false);
            this.pnlGoodsStates.PerformLayout();
            this.pnlPackings.ResumeLayout(false);
            this.pnlPackings.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnExit;
        private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMDataGridView grdData;
        private RFMBaseClasses.RFMPanel pnlFilter;
        private RFMBaseClasses.RFMLabel lblGoods;
        private RFMBaseClasses.RFMLabel lblGoodsStates;
        private RFMBaseClasses.RFMButton btnFilter;
        private RFMBaseClasses.RFMPanel pnlPackings;
        private RFMBaseClasses.RFMTextBox txtPackingsChoosen;
        private RFMBaseClasses.RFMButton btnPackingsClear;
        private RFMBaseClasses.RFMButton btnPackingsChoose;
        private RFMBaseClasses.RFMButton btnSelect;
        private RFMBaseClasses.RFMButton btnClear;
        private RFMBaseClasses.RFMTextBox txtData;
        private RFMBaseClasses.RFMPanel pnlGoodsStates;
        private RFMBaseClasses.RFMTextBox txtGoodsStatesChoosen;
        private RFMBaseClasses.RFMButton btnGoodsStatesClear;
        private RFMBaseClasses.RFMButton btnGoodsStatesChoose;
        private RFMBaseClasses.RFMLabel lblEmptyOwner;
        private RFMBaseClasses.RFMComboBox cboOwners;
        private RFMBaseClasses.RFMLabel lblHosts;
        private RFMBaseClasses.RFMSelectRecordIDGrid ucSelectRecordID_Hosts;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcHostName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxes;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCost;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCostAmount;
	}
}

