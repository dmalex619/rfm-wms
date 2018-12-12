namespace WMSSuitable
{
	partial class frmAuditActs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditActs));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcList = new RFMBaseClasses.RFMTabControl();
            this.tabTerms = new RFMBaseClasses.RFMTabPage();
            this.cntTerms = new RFMBaseClasses.RFMPanel();
            this.lblHosts = new RFMBaseClasses.RFMLabel();
            this.ucSelectRecordID_Hosts = new RFMBaseClasses.RFMSelectRecordIDGrid();
            this.chkShowSelectedGoodsOnly = new RFMBaseClasses.RFMCheckBox();
            this.pnlGoodsStates = new RFMBaseClasses.RFMPanel();
            this.txtGoodsStatesChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnGoodsStatesClear = new RFMBaseClasses.RFMButton();
            this.btnGoodsStatesChoose = new RFMBaseClasses.RFMButton();
            this.pnlOwners = new RFMBaseClasses.RFMPanel();
            this.txtOwnersChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnOwnersClear = new RFMBaseClasses.RFMButton();
            this.btnOwnersChoose = new RFMBaseClasses.RFMButton();
            this.lblOwners = new RFMBaseClasses.RFMLabel();
            this.lblGoodsStates = new RFMBaseClasses.RFMLabel();
            this.pnlPackings = new RFMBaseClasses.RFMPanel();
            this.txtPackingsChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnPackingsClear = new RFMBaseClasses.RFMButton();
            this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
            this.lblPackings = new RFMBaseClasses.RFMLabel();
            this.dtrDates = new RFMBaseClasses.RFMDateRange();
            this.btnClearTerms = new RFMBaseClasses.RFMButton();
            this.lblDateAudit = new RFMBaseClasses.RFMLabel();
            this.tabData = new RFMBaseClasses.RFMTabPage();
            this.cntGrids = new RFMBaseClasses.RFMSplitContainer();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.tcAuditActs = new RFMBaseClasses.RFMTabControl();
            this.tabAuditActsGoods = new RFMBaseClasses.RFMTabPage();
            this.grdAuditActsGoods = new RFMBaseClasses.RFMDataGridView();
            this.grcResultImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
            this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPalConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxInPal = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodERPCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcAuditActGoodID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.mnuPrint = new RFMBaseClasses.RFMContextMenuStrip();
            this.btnService = new RFMBaseClasses.RFMButton();
            this.btnPrint = new RFMBaseClasses.RFMButton();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnDelete = new RFMBaseClasses.RFMButton();
            this.btnAdd = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.btnEdit = new RFMBaseClasses.RFMButton();
            this.btnConfirm = new RFMBaseClasses.RFMButton();
            this.mnuService = new RFMBaseClasses.RFMContextMenuStrip();
            this.tmrRestore = new RFMBaseClasses.RFMTimer();
            this.grcIsConfirmedImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
            this.grcIsConfirmed = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcDateAudit = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcNote = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateConfirm = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.tcList.SuspendLayout();
            this.tabTerms.SuspendLayout();
            this.cntTerms.SuspendLayout();
            this.ucSelectRecordID_Hosts.SuspendLayout();
            this.pnlGoodsStates.SuspendLayout();
            this.pnlOwners.SuspendLayout();
            this.pnlPackings.SuspendLayout();
            this.dtrDates.SuspendLayout();
            this.tabData.SuspendLayout();
            this.cntGrids.Panel1.SuspendLayout();
            this.cntGrids.Panel2.SuspendLayout();
            this.cntGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tcAuditActs.SuspendLayout();
            this.tabAuditActsGoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditActsGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // tcList
            // 
            this.tcList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcList.Controls.Add(this.tabTerms);
            this.tcList.Controls.Add(this.tabData);
            this.tcList.Location = new System.Drawing.Point(1, 1);
            this.tcList.Name = "tcList";
            this.tcList.SelectedIndex = 0;
            this.tcList.Size = new System.Drawing.Size(741, 429);
            this.tcList.TabIndex = 0;
            // 
            // tabTerms
            // 
            this.tabTerms.Controls.Add(this.cntTerms);
            this.tabTerms.IsFilterPage = true;
            this.tabTerms.Location = new System.Drawing.Point(4, 23);
            this.tabTerms.Name = "tabTerms";
            this.tabTerms.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerms.Size = new System.Drawing.Size(733, 402);
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
            this.cntTerms.Controls.Add(this.lblHosts);
            this.cntTerms.Controls.Add(this.ucSelectRecordID_Hosts);
            this.cntTerms.Controls.Add(this.chkShowSelectedGoodsOnly);
            this.cntTerms.Controls.Add(this.pnlGoodsStates);
            this.cntTerms.Controls.Add(this.pnlOwners);
            this.cntTerms.Controls.Add(this.lblOwners);
            this.cntTerms.Controls.Add(this.lblGoodsStates);
            this.cntTerms.Controls.Add(this.pnlPackings);
            this.cntTerms.Controls.Add(this.lblPackings);
            this.cntTerms.Controls.Add(this.dtrDates);
            this.cntTerms.Controls.Add(this.btnClearTerms);
            this.cntTerms.Controls.Add(this.lblDateAudit);
            this.cntTerms.Location = new System.Drawing.Point(0, 2);
            this.cntTerms.Name = "cntTerms";
            this.cntTerms.Size = new System.Drawing.Size(732, 399);
            this.cntTerms.TabIndex = 0;
            this.cntTerms.Paint += new System.Windows.Forms.PaintEventHandler(this.cntTerms_Paint);
            // 
            // lblHosts
            // 
            this.lblHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHosts.AutoSize = true;
            this.lblHosts.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblHosts.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblHosts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHosts.Location = new System.Drawing.Point(447, 355);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(41, 14);
            this.lblHosts.TabIndex = 8;
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
            this.ucSelectRecordID_Hosts.BtnClear.Location = new System.Drawing.Point(206, 0);
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
            this.ucSelectRecordID_Hosts.BtnSelect.Location = new System.Drawing.Point(180, 0);
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
            this.ucSelectRecordID_Hosts.Location = new System.Drawing.Point(448, 370);
            this.ucSelectRecordID_Hosts.MarkedCount = 0;
            this.ucSelectRecordID_Hosts.Name = "ucSelectRecordID_Hosts";
            this.ucSelectRecordID_Hosts.Size = new System.Drawing.Size(233, 24);
            this.ucSelectRecordID_Hosts.TabIndex = 9;
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
            this.ucSelectRecordID_Hosts.TxtData.Size = new System.Drawing.Size(178, 22);
            this.ucSelectRecordID_Hosts.TxtData.TabIndex = 0;
            this.ucSelectRecordID_Hosts.СolumnsData.AddRange(new string[] {
            "Name, Хост"});
            // 
            // chkShowSelectedGoodsOnly
            // 
            this.chkShowSelectedGoodsOnly.AutoSize = true;
            this.chkShowSelectedGoodsOnly.Location = new System.Drawing.Point(135, 177);
            this.chkShowSelectedGoodsOnly.Name = "chkShowSelectedGoodsOnly";
            this.chkShowSelectedGoodsOnly.Size = new System.Drawing.Size(182, 18);
            this.chkShowSelectedGoodsOnly.TabIndex = 7;
            this.chkShowSelectedGoodsOnly.Text = "только отобранные товары";
            this.chkShowSelectedGoodsOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowSelectedGoodsOnly.UseVisualStyleBackColor = true;
            // 
            // pnlGoodsStates
            // 
            this.pnlGoodsStates.Controls.Add(this.txtGoodsStatesChoosen);
            this.pnlGoodsStates.Controls.Add(this.btnGoodsStatesClear);
            this.pnlGoodsStates.Controls.Add(this.btnGoodsStatesChoose);
            this.pnlGoodsStates.Location = new System.Drawing.Point(134, 48);
            this.pnlGoodsStates.Name = "pnlGoodsStates";
            this.pnlGoodsStates.Size = new System.Drawing.Size(278, 30);
            this.pnlGoodsStates.TabIndex = 3;
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
            // pnlOwners
            // 
            this.pnlOwners.Controls.Add(this.txtOwnersChoosen);
            this.pnlOwners.Controls.Add(this.btnOwnersClear);
            this.pnlOwners.Controls.Add(this.btnOwnersChoose);
            this.pnlOwners.Location = new System.Drawing.Point(134, 98);
            this.pnlOwners.Name = "pnlOwners";
            this.pnlOwners.Size = new System.Drawing.Size(278, 30);
            this.pnlOwners.TabIndex = 5;
            // 
            // txtOwnersChoosen
            // 
            this.txtOwnersChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOwnersChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwnersChoosen.Enabled = false;
            this.txtOwnersChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtOwnersChoosen.Name = "txtOwnersChoosen";
            this.txtOwnersChoosen.OldValue = "";
            this.txtOwnersChoosen.Size = new System.Drawing.Size(218, 22);
            this.txtOwnersChoosen.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.txtOwnersChoosen, "Контекст названия поставщика");
            // 
            // btnOwnersClear
            // 
            this.btnOwnersClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnOwnersClear.Location = new System.Drawing.Point(249, 3);
            this.btnOwnersClear.Name = "btnOwnersClear";
            this.btnOwnersClear.Size = new System.Drawing.Size(26, 24);
            this.btnOwnersClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnOwnersClear, "Очистить выбор владельцев");
            this.btnOwnersClear.UseVisualStyleBackColor = true;
            this.btnOwnersClear.Click += new System.EventHandler(this.btnOwnersClear_Click);
            // 
            // btnOwnersChoose
            // 
            this.btnOwnersChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnOwnersChoose.Location = new System.Drawing.Point(221, 3);
            this.btnOwnersChoose.Name = "btnOwnersChoose";
            this.btnOwnersChoose.Size = new System.Drawing.Size(26, 24);
            this.btnOwnersChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnOwnersChoose, "Выбор владельцев");
            this.btnOwnersChoose.UseVisualStyleBackColor = true;
            this.btnOwnersChoose.Click += new System.EventHandler(this.btnOwnersChoose_Click);
            // 
            // lblOwners
            // 
            this.lblOwners.AutoSize = true;
            this.lblOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwners.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwners.Location = new System.Drawing.Point(7, 105);
            this.lblOwners.Name = "lblOwners";
            this.lblOwners.Size = new System.Drawing.Size(62, 14);
            this.lblOwners.TabIndex = 4;
            this.lblOwners.Text = "Владелец";
            // 
            // lblGoodsStates
            // 
            this.lblGoodsStates.AutoSize = true;
            this.lblGoodsStates.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodsStates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodsStates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodsStates.Location = new System.Drawing.Point(7, 56);
            this.lblGoodsStates.Name = "lblGoodsStates";
            this.lblGoodsStates.Size = new System.Drawing.Size(110, 14);
            this.lblGoodsStates.TabIndex = 2;
            this.lblGoodsStates.Text = "Состояние товара";
            // 
            // pnlPackings
            // 
            this.pnlPackings.Controls.Add(this.txtPackingsChoosen);
            this.pnlPackings.Controls.Add(this.btnPackingsClear);
            this.pnlPackings.Controls.Add(this.btnPackingsChoose);
            this.pnlPackings.Location = new System.Drawing.Point(134, 148);
            this.pnlPackings.Name = "pnlPackings";
            this.pnlPackings.Size = new System.Drawing.Size(278, 30);
            this.pnlPackings.TabIndex = 6;
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
            // lblPackings
            // 
            this.lblPackings.AutoSize = true;
            this.lblPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPackings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPackings.Location = new System.Drawing.Point(7, 155);
            this.lblPackings.Name = "lblPackings";
            this.lblPackings.Size = new System.Drawing.Size(49, 14);
            this.lblPackings.TabIndex = 6;
            this.lblPackings.Text = "Товары";
            // 
            // dtrDates
            // 
            this.dtrDates.BegValue = new System.DateTime(2007, 7, 31, 0, 0, 0, 0);
            // 
            // dtrDates.btnClear
            // 
            this.dtrDates.BtnСlear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dtrDates.BtnСlear.Image = ((System.Drawing.Image)(resources.GetObject("dtrDates.btnClear.Image")));
            this.dtrDates.BtnСlear.Location = new System.Drawing.Point(194, 4);
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
            this.dtrDates.DtpBegDate.Size = new System.Drawing.Size(91, 22);
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
            this.dtrDates.DtpEndDate.Size = new System.Drawing.Size(91, 22);
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
            this.dtrDates.Location = new System.Drawing.Point(135, 6);
            this.dtrDates.Name = "dtrDates";
            this.dtrDates.Size = new System.Drawing.Size(222, 29);
            this.dtrDates.TabIndex = 1;
            // 
            // btnClearTerms
            // 
            this.btnClearTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTerms.FlatAppearance.BorderSize = 0;
            this.btnClearTerms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTerms.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnClearTerms.Location = new System.Drawing.Point(704, 371);
            this.btnClearTerms.Name = "btnClearTerms";
            this.btnClearTerms.Size = new System.Drawing.Size(22, 22);
            this.btnClearTerms.TabIndex = 10;
            this.ttToolTip.SetToolTip(this.btnClearTerms, "Очистить условия");
            this.btnClearTerms.Click += new System.EventHandler(this.btnClearTerms_Click);
            // 
            // lblDateAudit
            // 
            this.lblDateAudit.AutoSize = true;
            this.lblDateAudit.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateAudit.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateAudit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateAudit.Location = new System.Drawing.Point(7, 14);
            this.lblDateAudit.Name = "lblDateAudit";
            this.lblDateAudit.Size = new System.Drawing.Size(61, 14);
            this.lblDateAudit.TabIndex = 0;
            this.lblDateAudit.Text = "Дата акта";
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.cntGrids);
            this.tabData.Location = new System.Drawing.Point(4, 23);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(733, 402);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Акты";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // cntGrids
            // 
            this.cntGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cntGrids.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cntGrids.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cntGrids.Location = new System.Drawing.Point(0, 2);
            this.cntGrids.Name = "cntGrids";
            this.cntGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // cntGrids.Panel1
            // 
            this.cntGrids.Panel1.Controls.Add(this.grdData);
            // 
            // cntGrids.Panel2
            // 
            this.cntGrids.Panel2.Controls.Add(this.tcAuditActs);
            this.cntGrids.Size = new System.Drawing.Size(732, 399);
            this.cntGrids.SplitterDistance = 266;
            this.cntGrids.SplitterWidth = 2;
            this.cntGrids.TabIndex = 0;
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
            this.grcIsConfirmedImage,
            this.grcIsConfirmed,
            this.grcDateAudit,
            this.grcOwnerName,
            this.grcGoodStateName,
            this.grcNote,
            this.grcDateConfirm,
            this.grcErpCode,
            this.grcID});
            this.grdData.IsCheckerInclude = true;
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.IsStatusInclude = true;
            this.grdData.IsStatusShow = true;
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(728, 262);
            this.grdData.StatusRowState = ((byte)(2));
            this.grdData.TabIndex = 11;
            this.grdData.CurrentRowChanged += new RFMBaseClasses.RFMDataGridView.CurrentRowChangedEventHandler(this.grdData_CurrentRowChanged);
            this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
            // 
            // tcAuditActs
            // 
            this.tcAuditActs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcAuditActs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcAuditActs.Controls.Add(this.tabAuditActsGoods);
            this.tcAuditActs.ItemSize = new System.Drawing.Size(120, 18);
            this.tcAuditActs.Location = new System.Drawing.Point(0, 0);
            this.tcAuditActs.Multiline = true;
            this.tcAuditActs.Name = "tcAuditActs";
            this.tcAuditActs.SelectedIndex = 0;
            this.tcAuditActs.Size = new System.Drawing.Size(728, 126);
            this.tcAuditActs.TabIndex = 0;
            // 
            // tabAuditActsGoods
            // 
            this.tabAuditActsGoods.Controls.Add(this.grdAuditActsGoods);
            this.tabAuditActsGoods.Location = new System.Drawing.Point(4, 4);
            this.tabAuditActsGoods.Name = "tabAuditActsGoods";
            this.tabAuditActsGoods.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuditActsGoods.Size = new System.Drawing.Size(720, 100);
            this.tabAuditActsGoods.TabIndex = 0;
            this.tabAuditActsGoods.Text = "Товары";
            this.tabAuditActsGoods.UseVisualStyleBackColor = true;
            // 
            // grdAuditActsGoods
            // 
            this.grdAuditActsGoods.AllowUserToAddRows = false;
            this.grdAuditActsGoods.AllowUserToDeleteRows = false;
            this.grdAuditActsGoods.AllowUserToOrderColumns = true;
            this.grdAuditActsGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAuditActsGoods.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdAuditActsGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdAuditActsGoods.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAuditActsGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdAuditActsGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAuditActsGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcResultImage,
            this.grcGoodAlias,
            this.grcInBox,
            this.grcBoxConfirmed,
            this.grcPalConfirmed,
            this.grcQntConfirmed,
            this.grcBoxInPal,
            this.grcWeighting,
            this.grcGoodBarCode,
            this.grcGoodERPCode,
            this.grcGoodGroupName,
            this.grcGoodBrandName,
            this.grcAuditActGoodID});
            this.grdAuditActsGoods.IsConfigInclude = true;
            this.grdAuditActsGoods.IsMarkedAll = false;
            this.grdAuditActsGoods.IsStatusInclude = true;
            this.grdAuditActsGoods.IsStatusShow = true;
            this.grdAuditActsGoods.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdAuditActsGoods.Location = new System.Drawing.Point(0, 0);
            this.grdAuditActsGoods.MultiSelect = false;
            this.grdAuditActsGoods.Name = "grdAuditActsGoods";
            this.grdAuditActsGoods.RangedWay = ' ';
            this.grdAuditActsGoods.ReadOnly = true;
            this.grdAuditActsGoods.RowHeadersWidth = 24;
            this.grdAuditActsGoods.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdAuditActsGoods.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdAuditActsGoods.Size = new System.Drawing.Size(718, 97);
            this.grdAuditActsGoods.StatusRowState = ((byte)(2));
            this.grdAuditActsGoods.TabIndex = 14;
            this.grdAuditActsGoods.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdAuditActsGoods_CellFormatting);
            // 
            // grcResultImage
            // 
            this.grcResultImage.FillWeight = 20F;
            this.grcResultImage.HeaderText = "";
            this.grcResultImage.Name = "grcResultImage";
            this.grcResultImage.ReadOnly = true;
            this.grcResultImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grcResultImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcResultImage.ToolTipText = "\"+\" - оприходование товара, \"-\" - списание товара";
            this.grcResultImage.Width = 30;
            // 
            // grcGoodAlias
            // 
            this.grcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodAlias.DataPropertyName = "GoodAlias";
            this.grcGoodAlias.HeaderText = "Товар";
            this.grcGoodAlias.Name = "grcGoodAlias";
            this.grcGoodAlias.ReadOnly = true;
            this.grcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodAlias.ToolTipText = "Товар";
            this.grcGoodAlias.Width = 250;
            // 
            // grcInBox
            // 
            this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcInBox.DataPropertyName = "InBox";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.grcInBox.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcInBox.HeaderText = "В кор.";
            this.grcInBox.Name = "grcInBox";
            this.grcInBox.ReadOnly = true;
            this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcInBox.ToolTipText = "Штук/кг в коробке";
            this.grcInBox.Width = 50;
            // 
            // grcBoxConfirmed
            // 
            this.grcBoxConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxConfirmed.DataPropertyName = "BoxConfirmed";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N1";
            this.grcBoxConfirmed.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcBoxConfirmed.HeaderText = "Кор.";
            this.grcBoxConfirmed.Name = "grcBoxConfirmed";
            this.grcBoxConfirmed.ReadOnly = true;
            this.grcBoxConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxConfirmed.ToolTipText = "Коробок";
            this.grcBoxConfirmed.Width = 80;
            // 
            // grcPalConfirmed
            // 
            this.grcPalConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPalConfirmed.DataPropertyName = "PalConfirmed";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.grcPalConfirmed.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcPalConfirmed.HeaderText = "Пал.";
            this.grcPalConfirmed.Name = "grcPalConfirmed";
            this.grcPalConfirmed.ReadOnly = true;
            this.grcPalConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPalConfirmed.ToolTipText = "Паллет";
            this.grcPalConfirmed.Width = 60;
            // 
            // grcQntConfirmed
            // 
            this.grcQntConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntConfirmed.DataPropertyName = "QntConfirmed";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.grcQntConfirmed.DefaultCellStyle = dataGridViewCellStyle7;
            this.grcQntConfirmed.HeaderText = "Штук";
            this.grcQntConfirmed.Name = "grcQntConfirmed";
            this.grcQntConfirmed.ReadOnly = true;
            this.grcQntConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntConfirmed.ToolTipText = "Штук";
            this.grcQntConfirmed.Width = 90;
            // 
            // grcBoxInPal
            // 
            this.grcBoxInPal.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxInPal.DataPropertyName = "BoxInPal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.grcBoxInPal.DefaultCellStyle = dataGridViewCellStyle8;
            this.grcBoxInPal.HeaderText = "Кор.на пал.";
            this.grcBoxInPal.Name = "grcBoxInPal";
            this.grcBoxInPal.ReadOnly = true;
            this.grcBoxInPal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxInPal.ToolTipText = "Коробок на паллете";
            this.grcBoxInPal.Width = 60;
            // 
            // grcWeighting
            // 
            this.grcWeighting.DataPropertyName = "Weighting";
            this.grcWeighting.HeaderText = "Вес?";
            this.grcWeighting.Name = "grcWeighting";
            this.grcWeighting.ReadOnly = true;
            this.grcWeighting.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcWeighting.ToolTipText = "Весовой товар?";
            this.grcWeighting.Width = 40;
            // 
            // grcGoodBarCode
            // 
            this.grcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodBarCode.DataPropertyName = "GoodBarCode";
            this.grcGoodBarCode.HeaderText = "ШК товара";
            this.grcGoodBarCode.Name = "grcGoodBarCode";
            this.grcGoodBarCode.ReadOnly = true;
            this.grcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodBarCode.Width = 130;
            // 
            // grcGoodERPCode
            // 
            this.grcGoodERPCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodERPCode.DataPropertyName = "GoodERPCode";
            this.grcGoodERPCode.HeaderText = "ERP код товара";
            this.grcGoodERPCode.Name = "grcGoodERPCode";
            this.grcGoodERPCode.ReadOnly = true;
            this.grcGoodERPCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcGoodGroupName
            // 
            this.grcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodGroupName.DataPropertyName = "GoodGroupName";
            this.grcGoodGroupName.HeaderText = "Товарная группа";
            this.grcGoodGroupName.Name = "grcGoodGroupName";
            this.grcGoodGroupName.ReadOnly = true;
            this.grcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodGroupName.Width = 150;
            // 
            // grcGoodBrandName
            // 
            this.grcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodBrandName.DataPropertyName = "GoodBrandName";
            this.grcGoodBrandName.HeaderText = "Товарный бренд";
            this.grcGoodBrandName.Name = "grcGoodBrandName";
            this.grcGoodBrandName.ReadOnly = true;
            this.grcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodBrandName.Width = 150;
            // 
            // grcAuditActGoodID
            // 
            this.grcAuditActGoodID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcAuditActGoodID.DataPropertyName = "AuditActGoodID";
            this.grcAuditActGoodID.HeaderText = "ID";
            this.grcAuditActGoodID.Name = "grcAuditActGoodID";
            this.grcAuditActGoodID.ReadOnly = true;
            this.grcAuditActGoodID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcAuditActGoodID.ToolTipText = "Код записи о товаре в акте";
            this.grcAuditActGoodID.Width = 40;
            // 
            // mnuPrint
            // 
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuPrint.ShowImageMargin = false;
            this.mnuPrint.Size = new System.Drawing.Size(36, 4);
            // 
            // btnService
            // 
            this.btnService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnService.Enabled = false;
            this.btnService.Image = global::WMSSuitable.Properties.Resources.Service;
            this.btnService.Location = new System.Drawing.Point(655, 437);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(30, 30);
            this.btnService.TabIndex = 6;
            this.ttToolTip.SetToolTip(this.btnService, "Дополнительно");
            this.btnService.UseVisualStyleBackColor = true;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
            this.btnPrint.Location = new System.Drawing.Point(605, 437);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 5;
            this.ttToolTip.SetToolTip(this.btnPrint, "Печать");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(5, 437);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.btnHelp, "Помощь");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
            this.btnDelete.IsAccessOn = true;
            this.btnDelete.Location = new System.Drawing.Point(555, 437);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 30);
            this.btnDelete.TabIndex = 4;
            this.ttToolTip.SetToolTip(this.btnDelete, "Удаление ревизии");
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
            this.btnAdd.IsAccessOn = true;
            this.btnAdd.Location = new System.Drawing.Point(405, 437);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnAdd, "Добавление акта");
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnCancel.Location = new System.Drawing.Point(705, 437);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 30);
            this.btnCancel.TabIndex = 7;
            this.ttToolTip.SetToolTip(this.btnCancel, "Выход");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
            this.btnEdit.IsAccessOn = true;
            this.btnEdit.Location = new System.Drawing.Point(455, 437);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 30);
            this.btnEdit.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnEdit, "Редактирование ревизии");
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Image = global::WMSSuitable.Properties.Resources.Go;
            this.btnConfirm.IsAccessOn = true;
            this.btnConfirm.Location = new System.Drawing.Point(505, 437);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(30, 30);
            this.btnConfirm.TabIndex = 3;
            this.ttToolTip.SetToolTip(this.btnConfirm, "Подтверждение ревизии");
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // mnuService
            // 
            this.mnuService.Name = "mnuPrint";
            this.mnuService.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuService.ShowImageMargin = false;
            this.mnuService.Size = new System.Drawing.Size(36, 4);
            // 
            // tmrRestore
            // 
            this.tmrRestore.Tick += new System.EventHandler(this.tmrRestore_Tick);
            // 
            // grcIsConfirmedImage
            // 
            this.grcIsConfirmedImage.HeaderText = "";
            this.grcIsConfirmedImage.Name = "grcIsConfirmedImage";
            this.grcIsConfirmedImage.ReadOnly = true;
            this.grcIsConfirmedImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcIsConfirmedImage.ToolTipText = "Приход подтвержден?";
            this.grcIsConfirmedImage.Width = 30;
            // 
            // grcIsConfirmed
            // 
            this.grcIsConfirmed.DataPropertyName = "IsConfirmed";
            this.grcIsConfirmed.HeaderText = "Подтв.";
            this.grcIsConfirmed.Name = "grcIsConfirmed";
            this.grcIsConfirmed.ReadOnly = true;
            this.grcIsConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcIsConfirmed.ToolTipText = "Ревизия подтвержден?";
            this.grcIsConfirmed.Visible = false;
            this.grcIsConfirmed.Width = 40;
            // 
            // grcDateAudit
            // 
            this.grcDateAudit.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateAudit.DataPropertyName = "DateAudit";
            this.grcDateAudit.HeaderText = "Дата акта";
            this.grcDateAudit.Name = "grcDateAudit";
            this.grcDateAudit.ReadOnly = true;
            this.grcDateAudit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateAudit.Width = 125;
            // 
            // grcOwnerName
            // 
            this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOwnerName.DataPropertyName = "OwnerName";
            this.grcOwnerName.HeaderText = "Владелец";
            this.grcOwnerName.Name = "grcOwnerName";
            this.grcOwnerName.ReadOnly = true;
            this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcGoodStateName
            // 
            this.grcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodStateName.DataPropertyName = "GoodStateName";
            this.grcGoodStateName.HeaderText = "Состояние товара";
            this.grcGoodStateName.Name = "grcGoodStateName";
            this.grcGoodStateName.ReadOnly = true;
            this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcNote
            // 
            this.grcNote.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcNote.DataPropertyName = "Note";
            this.grcNote.HeaderText = "Примечание";
            this.grcNote.Name = "grcNote";
            this.grcNote.ReadOnly = true;
            this.grcNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcNote.Width = 250;
            // 
            // grcDateConfirm
            // 
            this.grcDateConfirm.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateConfirm.DataPropertyName = "DateConfirm";
            this.grcDateConfirm.HeaderText = "Дата вып.";
            this.grcDateConfirm.Name = "grcDateConfirm";
            this.grcDateConfirm.ReadOnly = true;
            this.grcDateConfirm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateConfirm.ToolTipText = "Дата-время выполнения";
            this.grcDateConfirm.Width = 125;
            // 
            // grcErpCode
            // 
            this.grcErpCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcErpCode.DataPropertyName = "ErpCode";
            this.grcErpCode.HeaderText = "ERPCode";
            this.grcErpCode.Name = "grcErpCode";
            this.grcErpCode.ReadOnly = true;
            this.grcErpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcErpCode.ToolTipText = "Код в учетной системе";
            // 
            // grcID
            // 
            this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcID.DataPropertyName = "ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcID.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcID.HeaderText = "ID";
            this.grcID.Name = "grcID";
            this.grcID.ReadOnly = true;
            this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcID.ToolTipText = "Код ревизии";
            this.grcID.Width = 50;
            // 
            // frmAuditActs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 473);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnService);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tcList);
            this.hpHelp.SetHelpKeyword(this, "301");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.hpHelp.SetHelpString(this, "");
            this.IsAccessOn = true;
            this.IsWaitLoading = true;
            this.LastGrid = this.grdData;
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmAuditActs";
            this.hpHelp.SetShowHelp(this, true);
            this.Text = "Акты";
            this.Load += new System.EventHandler(this.frmAuditActs_Load);
            this.tcList.ResumeLayout(false);
            this.tabTerms.ResumeLayout(false);
            this.cntTerms.ResumeLayout(false);
            this.cntTerms.PerformLayout();
            this.ucSelectRecordID_Hosts.ResumeLayout(false);
            this.ucSelectRecordID_Hosts.PerformLayout();
            this.pnlGoodsStates.ResumeLayout(false);
            this.pnlGoodsStates.PerformLayout();
            this.pnlOwners.ResumeLayout(false);
            this.pnlOwners.PerformLayout();
            this.pnlPackings.ResumeLayout(false);
            this.pnlPackings.PerformLayout();
            this.dtrDates.ResumeLayout(false);
            this.dtrDates.PerformLayout();
            this.tabData.ResumeLayout(false);
            this.cntGrids.Panel1.ResumeLayout(false);
            this.cntGrids.Panel2.ResumeLayout(false);
            this.cntGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tcAuditActs.ResumeLayout(false);
            this.tabAuditActsGoods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditActsGoods)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMTabControl tcList;
        private RFMBaseClasses.RFMTabPage tabTerms;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMTabPage tabData;
		private RFMBaseClasses.RFMSplitContainer cntGrids;
        private RFMBaseClasses.RFMDataGridView grdData;
        private RFMBaseClasses.RFMButton btnAdd;
        private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMButton btnPrint;
        private RFMBaseClasses.RFMButton btnService;
		private RFMBaseClasses.RFMContextMenuStrip mnuPrint;
        private RFMBaseClasses.RFMButton btnConfirm;
		private RFMBaseClasses.RFMContextMenuStrip mnuService;
		private RFMBaseClasses.RFMTabControl tcAuditActs;
		private RFMBaseClasses.RFMTabPage tabAuditActsGoods;
		private RFMBaseClasses.RFMButton btnClearTerms;
		private RFMBaseClasses.RFMPanel cntTerms;
		private RFMBaseClasses.RFMLabel lblDateAudit;
		private RFMBaseClasses.RFMDateRange dtrDates;
		private RFMBaseClasses.RFMPanel pnlPackings;
		private RFMBaseClasses.RFMTextBox txtPackingsChoosen;
		private RFMBaseClasses.RFMButton btnPackingsClear;
		private RFMBaseClasses.RFMButton btnPackingsChoose;
		private RFMBaseClasses.RFMLabel lblPackings;
		private RFMBaseClasses.RFMLabel lblGoodsStates;
		private RFMBaseClasses.RFMPanel pnlOwners;
		private RFMBaseClasses.RFMTextBox txtOwnersChoosen;
		private RFMBaseClasses.RFMButton btnOwnersClear;
		private RFMBaseClasses.RFMButton btnOwnersChoose;
		private RFMBaseClasses.RFMLabel lblOwners;
		private RFMBaseClasses.RFMDataGridView grdAuditActsGoods;
		private RFMBaseClasses.RFMPanel pnlGoodsStates;
		private RFMBaseClasses.RFMTextBox txtGoodsStatesChoosen;
		private RFMBaseClasses.RFMButton btnGoodsStatesClear;
		private RFMBaseClasses.RFMButton btnGoodsStatesChoose;
        private RFMBaseClasses.RFMTimer tmrRestore;
		private RFMBaseClasses.RFMCheckBox chkShowSelectedGoodsOnly;
		private RFMBaseClasses.RFMLabel lblHosts;
		private RFMBaseClasses.RFMSelectRecordIDGrid ucSelectRecordID_Hosts;
        private RFMBaseClasses.RFMDataGridViewImageColumn grcResultImage;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxConfirmed;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalConfirmed;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntConfirmed;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxInPal;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBarCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodERPCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBrandName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcAuditActGoodID;
        private RFMBaseClasses.RFMDataGridViewImageColumn grcIsConfirmedImage;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcIsConfirmed;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateAudit;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNote;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateConfirm;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcErpCode;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;
	}
}