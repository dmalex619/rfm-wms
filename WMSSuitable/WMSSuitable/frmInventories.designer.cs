namespace WMSSuitable
{
	partial class frmInventories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventories));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcList = new RFMBaseClasses.RFMTabControl();
            this.tabTerms = new RFMBaseClasses.RFMTabPage();
            this.cntTerms = new RFMBaseClasses.RFMPanel();
            this.chkShowSelectedGoodsOnly = new RFMBaseClasses.RFMCheckBox();
            this.pnlPackings = new RFMBaseClasses.RFMPanel();
            this.txtPackingsChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnPackingsClear = new RFMBaseClasses.RFMButton();
            this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
            this.lblPackings = new RFMBaseClasses.RFMLabel();
            this.pnlInventoriesErrors = new RFMBaseClasses.RFMPanel();
            this.txtInventoriesErrorsChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnInventoriesErrorsClear = new RFMBaseClasses.RFMButton();
            this.btnInventoriesErrorsChoose = new RFMBaseClasses.RFMButton();
            this.lblInventoriesErrors = new RFMBaseClasses.RFMLabel();
            this.pnlCells = new RFMBaseClasses.RFMPanel();
            this.txtCellsChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnCellsClear = new RFMBaseClasses.RFMButton();
            this.btnCellsChoose = new RFMBaseClasses.RFMButton();
            this.lblCells = new RFMBaseClasses.RFMLabel();
            this.pnlUsers = new RFMBaseClasses.RFMPanel();
            this.txtUsersChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnUsersClear = new RFMBaseClasses.RFMButton();
            this.btnUsersChoose = new RFMBaseClasses.RFMButton();
            this.lblUsers = new RFMBaseClasses.RFMLabel();
            this.dtrDates = new RFMBaseClasses.RFMDateRange();
            this.btnClearTerms = new RFMBaseClasses.RFMButton();
            this.lblInventoriesConfirmed = new RFMBaseClasses.RFMLabel();
            this.pnlOpgInventoriesConfirmed = new RFMBaseClasses.RFMPanel();
            this.dtrDatesConfirm = new RFMBaseClasses.RFMDateRange();
            this.optIsNotConfirmed = new RFMBaseClasses.RFMRadioButton();
            this.pnlOpgInventoriesStarted = new RFMBaseClasses.RFMPanel();
            this.optNotStarted = new RFMBaseClasses.RFMRadioButton();
            this.optStartedNotConfirmed = new RFMBaseClasses.RFMRadioButton();
            this.optStartedAll = new RFMBaseClasses.RFMRadioButton();
            this.optIsConfirmed = new RFMBaseClasses.RFMRadioButton();
            this.optAll = new RFMBaseClasses.RFMRadioButton();
            this.lblInventoryDate = new RFMBaseClasses.RFMLabel();
            this.txtBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
            this.lblBarCode = new RFMBaseClasses.RFMLabel();
            this.tabData = new RFMBaseClasses.RFMTabPage();
            this.cntGrids = new RFMBaseClasses.RFMSplitContainer();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.grcIsConfirmedImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
            this.grcIsConfirmed = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcDateInventory = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateStart = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcConfirmUserName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcNote = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcId = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.tcInventoriesCells = new RFMBaseClasses.RFMTabControl();
            this.tabInventoriesCells = new RFMBaseClasses.RFMTabPage();
            this.grdInventoriesCells = new RFMBaseClasses.RFMDataGridView();
            this.grcIsCellSuccessImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
            this.grclAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcFrameID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPackingAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxDiff = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntDiff = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcStoreZoneTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcConfirmNote = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcUserName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcFixedPackingAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcCellID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.mnuPrint = new RFMBaseClasses.RFMContextMenuStrip();
            this.mniPrintInventoryEmpty = new RFMBaseClasses.RFMContextToolStripMenuItem();
            this.mniPrintInventoryBillContents = new RFMBaseClasses.RFMContextToolStripMenuItem();
            this.mniPrintInventoryBillBlank = new RFMBaseClasses.RFMContextToolStripMenuItem();
            this.mniPrintInventoryBillFull = new RFMBaseClasses.RFMContextToolStripMenuItem();
            this.mniPrintInventoryTotalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnService = new RFMBaseClasses.RFMButton();
            this.btnPrint = new RFMBaseClasses.RFMButton();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnDelete = new RFMBaseClasses.RFMButton();
            this.btnAdd = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.btnEdit = new RFMBaseClasses.RFMButton();
            this.btnConfirm = new RFMBaseClasses.RFMButton();
            this.mnuService = new RFMBaseClasses.RFMContextMenuStrip();
            this.btnMedication = new RFMBaseClasses.RFMButton();
            this.tmrRestore = new RFMBaseClasses.RFMTimer();
            this.btnMedicationNotFrames = new RFMBaseClasses.RFMButton();
            this.tcList.SuspendLayout();
            this.tabTerms.SuspendLayout();
            this.cntTerms.SuspendLayout();
            this.pnlPackings.SuspendLayout();
            this.pnlInventoriesErrors.SuspendLayout();
            this.pnlCells.SuspendLayout();
            this.pnlUsers.SuspendLayout();
            this.dtrDates.SuspendLayout();
            this.pnlOpgInventoriesConfirmed.SuspendLayout();
            this.dtrDatesConfirm.SuspendLayout();
            this.pnlOpgInventoriesStarted.SuspendLayout();
            this.tabData.SuspendLayout();
            this.cntGrids.Panel1.SuspendLayout();
            this.cntGrids.Panel2.SuspendLayout();
            this.cntGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tcInventoriesCells.SuspendLayout();
            this.tabInventoriesCells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInventoriesCells)).BeginInit();
            this.mnuPrint.SuspendLayout();
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
            this.tcList.Size = new System.Drawing.Size(741, 430);
            this.tcList.TabIndex = 0;
            this.tcList.SelectedIndexChanged += new System.EventHandler(this.tcList_SelectedIndexChanged);
            // 
            // tabTerms
            // 
            this.tabTerms.Controls.Add(this.cntTerms);
            this.tabTerms.IsFilterPage = true;
            this.tabTerms.Location = new System.Drawing.Point(4, 23);
            this.tabTerms.Name = "tabTerms";
            this.tabTerms.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerms.Size = new System.Drawing.Size(733, 403);
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
            this.cntTerms.Controls.Add(this.chkShowSelectedGoodsOnly);
            this.cntTerms.Controls.Add(this.pnlPackings);
            this.cntTerms.Controls.Add(this.lblPackings);
            this.cntTerms.Controls.Add(this.pnlInventoriesErrors);
            this.cntTerms.Controls.Add(this.lblInventoriesErrors);
            this.cntTerms.Controls.Add(this.pnlCells);
            this.cntTerms.Controls.Add(this.lblCells);
            this.cntTerms.Controls.Add(this.pnlUsers);
            this.cntTerms.Controls.Add(this.lblUsers);
            this.cntTerms.Controls.Add(this.dtrDates);
            this.cntTerms.Controls.Add(this.btnClearTerms);
            this.cntTerms.Controls.Add(this.lblInventoriesConfirmed);
            this.cntTerms.Controls.Add(this.pnlOpgInventoriesConfirmed);
            this.cntTerms.Controls.Add(this.lblInventoryDate);
            this.cntTerms.Controls.Add(this.txtBarCode);
            this.cntTerms.Controls.Add(this.lblBarCode);
            this.cntTerms.Location = new System.Drawing.Point(0, 2);
            this.cntTerms.Name = "cntTerms";
            this.cntTerms.Size = new System.Drawing.Size(732, 400);
            this.cntTerms.TabIndex = 0;
            // 
            // chkShowSelectedGoodsOnly
            // 
            this.chkShowSelectedGoodsOnly.AutoSize = true;
            this.chkShowSelectedGoodsOnly.Location = new System.Drawing.Point(137, 154);
            this.chkShowSelectedGoodsOnly.Name = "chkShowSelectedGoodsOnly";
            this.chkShowSelectedGoodsOnly.Size = new System.Drawing.Size(182, 18);
            this.chkShowSelectedGoodsOnly.TabIndex = 8;
            this.chkShowSelectedGoodsOnly.Text = "только отобранные товары";
            this.chkShowSelectedGoodsOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowSelectedGoodsOnly.UseVisualStyleBackColor = true;
            // 
            // pnlPackings
            // 
            this.pnlPackings.Controls.Add(this.txtPackingsChoosen);
            this.pnlPackings.Controls.Add(this.btnPackingsClear);
            this.pnlPackings.Controls.Add(this.btnPackingsChoose);
            this.pnlPackings.Location = new System.Drawing.Point(137, 124);
            this.pnlPackings.Name = "pnlPackings";
            this.pnlPackings.Size = new System.Drawing.Size(294, 30);
            this.pnlPackings.TabIndex = 7;
            // 
            // txtPackingsChoosen
            // 
            this.txtPackingsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtPackingsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPackingsChoosen.Enabled = false;
            this.txtPackingsChoosen.Location = new System.Drawing.Point(0, 5);
            this.txtPackingsChoosen.Name = "txtPackingsChoosen";
            this.txtPackingsChoosen.OldValue = "";
            this.txtPackingsChoosen.Size = new System.Drawing.Size(237, 22);
            this.txtPackingsChoosen.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.txtPackingsChoosen, "Выбранные товары");
            // 
            // btnPackingsClear
            // 
            this.btnPackingsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnPackingsClear.Location = new System.Drawing.Point(267, 4);
            this.btnPackingsClear.Name = "btnPackingsClear";
            this.btnPackingsClear.Size = new System.Drawing.Size(26, 24);
            this.btnPackingsClear.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnPackingsClear, "Очистить выбор товаров");
            this.btnPackingsClear.UseVisualStyleBackColor = true;
            this.btnPackingsClear.Click += new System.EventHandler(this.btnPackingsClear_Click);
            // 
            // btnPackingsChoose
            // 
            this.btnPackingsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnPackingsChoose.Location = new System.Drawing.Point(239, 4);
            this.btnPackingsChoose.Name = "btnPackingsChoose";
            this.btnPackingsChoose.Size = new System.Drawing.Size(26, 24);
            this.btnPackingsChoose.TabIndex = 0;
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
            this.lblPackings.Location = new System.Drawing.Point(6, 134);
            this.lblPackings.Name = "lblPackings";
            this.lblPackings.Size = new System.Drawing.Size(49, 14);
            this.lblPackings.TabIndex = 6;
            this.lblPackings.Text = "Товары";
            // 
            // pnlInventoriesErrors
            // 
            this.pnlInventoriesErrors.Controls.Add(this.txtInventoriesErrorsChoosen);
            this.pnlInventoriesErrors.Controls.Add(this.btnInventoriesErrorsClear);
            this.pnlInventoriesErrors.Controls.Add(this.btnInventoriesErrorsChoose);
            this.pnlInventoriesErrors.Location = new System.Drawing.Point(137, 227);
            this.pnlInventoriesErrors.Name = "pnlInventoriesErrors";
            this.pnlInventoriesErrors.Size = new System.Drawing.Size(294, 30);
            this.pnlInventoriesErrors.TabIndex = 12;
            this.pnlInventoriesErrors.Visible = false;
            // 
            // txtInventoriesErrorsChoosen
            // 
            this.txtInventoriesErrorsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtInventoriesErrorsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInventoriesErrorsChoosen.Enabled = false;
            this.txtInventoriesErrorsChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtInventoriesErrorsChoosen.Name = "txtInventoriesErrorsChoosen";
            this.txtInventoriesErrorsChoosen.OldValue = "";
            this.txtInventoriesErrorsChoosen.Size = new System.Drawing.Size(236, 22);
            this.txtInventoriesErrorsChoosen.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.txtInventoriesErrorsChoosen, "Контекст названия поставщика");
            // 
            // btnInventoriesErrorsClear
            // 
            this.btnInventoriesErrorsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnInventoriesErrorsClear.Location = new System.Drawing.Point(267, 3);
            this.btnInventoriesErrorsClear.Name = "btnInventoriesErrorsClear";
            this.btnInventoriesErrorsClear.Size = new System.Drawing.Size(26, 24);
            this.btnInventoriesErrorsClear.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnInventoriesErrorsClear, "Очистить выбор пользователей");
            this.btnInventoriesErrorsClear.UseVisualStyleBackColor = true;
            // 
            // btnInventoriesErrorsChoose
            // 
            this.btnInventoriesErrorsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnInventoriesErrorsChoose.Location = new System.Drawing.Point(239, 3);
            this.btnInventoriesErrorsChoose.Name = "btnInventoriesErrorsChoose";
            this.btnInventoriesErrorsChoose.Size = new System.Drawing.Size(26, 24);
            this.btnInventoriesErrorsChoose.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.btnInventoriesErrorsChoose, "Выбор пользователей");
            this.btnInventoriesErrorsChoose.UseVisualStyleBackColor = true;
            // 
            // lblInventoriesErrors
            // 
            this.lblInventoriesErrors.AutoSize = true;
            this.lblInventoriesErrors.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInventoriesErrors.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInventoriesErrors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInventoriesErrors.Location = new System.Drawing.Point(6, 236);
            this.lblInventoriesErrors.Name = "lblInventoriesErrors";
            this.lblInventoriesErrors.Size = new System.Drawing.Size(101, 14);
            this.lblInventoriesErrors.TabIndex = 11;
            this.lblInventoriesErrors.Text = "Ошибки ревизии";
            this.lblInventoriesErrors.Visible = false;
            // 
            // pnlCells
            // 
            this.pnlCells.Controls.Add(this.txtCellsChoosen);
            this.pnlCells.Controls.Add(this.btnCellsClear);
            this.pnlCells.Controls.Add(this.btnCellsChoose);
            this.pnlCells.Location = new System.Drawing.Point(137, 81);
            this.pnlCells.Name = "pnlCells";
            this.pnlCells.Size = new System.Drawing.Size(294, 30);
            this.pnlCells.TabIndex = 5;
            // 
            // txtCellsChoosen
            // 
            this.txtCellsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtCellsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCellsChoosen.Enabled = false;
            this.txtCellsChoosen.Location = new System.Drawing.Point(0, 5);
            this.txtCellsChoosen.Name = "txtCellsChoosen";
            this.txtCellsChoosen.OldValue = "";
            this.txtCellsChoosen.Size = new System.Drawing.Size(237, 22);
            this.txtCellsChoosen.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.txtCellsChoosen, "Контекст названия поставщика");
            // 
            // btnCellsClear
            // 
            this.btnCellsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnCellsClear.Location = new System.Drawing.Point(267, 4);
            this.btnCellsClear.Name = "btnCellsClear";
            this.btnCellsClear.Size = new System.Drawing.Size(26, 24);
            this.btnCellsClear.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnCellsClear, "Очистить выбор товаров");
            this.btnCellsClear.UseVisualStyleBackColor = true;
            this.btnCellsClear.Click += new System.EventHandler(this.btnCellsClear_Click);
            // 
            // btnCellsChoose
            // 
            this.btnCellsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnCellsChoose.Location = new System.Drawing.Point(239, 4);
            this.btnCellsChoose.Name = "btnCellsChoose";
            this.btnCellsChoose.Size = new System.Drawing.Size(26, 24);
            this.btnCellsChoose.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.btnCellsChoose, "Выбор товаров");
            this.btnCellsChoose.UseVisualStyleBackColor = true;
            this.btnCellsChoose.Click += new System.EventHandler(this.btnCellsChoose_Click);
            // 
            // lblCells
            // 
            this.lblCells.AutoSize = true;
            this.lblCells.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCells.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCells.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCells.Location = new System.Drawing.Point(6, 91);
            this.lblCells.Name = "lblCells";
            this.lblCells.Size = new System.Drawing.Size(48, 14);
            this.lblCells.TabIndex = 4;
            this.lblCells.Text = "Ячейки";
            // 
            // pnlUsers
            // 
            this.pnlUsers.Controls.Add(this.txtUsersChoosen);
            this.pnlUsers.Controls.Add(this.btnUsersClear);
            this.pnlUsers.Controls.Add(this.btnUsersChoose);
            this.pnlUsers.Location = new System.Drawing.Point(137, 184);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(294, 30);
            this.pnlUsers.TabIndex = 10;
            // 
            // txtUsersChoosen
            // 
            this.txtUsersChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtUsersChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUsersChoosen.Enabled = false;
            this.txtUsersChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtUsersChoosen.Name = "txtUsersChoosen";
            this.txtUsersChoosen.OldValue = "";
            this.txtUsersChoosen.Size = new System.Drawing.Size(236, 22);
            this.txtUsersChoosen.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.txtUsersChoosen, "Контекст названия поставщика");
            // 
            // btnUsersClear
            // 
            this.btnUsersClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnUsersClear.Location = new System.Drawing.Point(267, 3);
            this.btnUsersClear.Name = "btnUsersClear";
            this.btnUsersClear.Size = new System.Drawing.Size(26, 24);
            this.btnUsersClear.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnUsersClear, "Очистить выбор пользователей");
            this.btnUsersClear.UseVisualStyleBackColor = true;
            this.btnUsersClear.Click += new System.EventHandler(this.btnUsersClear_Click);
            // 
            // btnUsersChoose
            // 
            this.btnUsersChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnUsersChoose.Location = new System.Drawing.Point(239, 3);
            this.btnUsersChoose.Name = "btnUsersChoose";
            this.btnUsersChoose.Size = new System.Drawing.Size(26, 24);
            this.btnUsersChoose.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.btnUsersChoose, "Выбор пользователей");
            this.btnUsersChoose.UseVisualStyleBackColor = true;
            this.btnUsersChoose.Click += new System.EventHandler(this.btnUsersChoose_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblUsers.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsers.Location = new System.Drawing.Point(6, 193);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(86, 14);
            this.lblUsers.TabIndex = 9;
            this.lblUsers.Text = "Пользователи";
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
            this.dtrDates.Location = new System.Drawing.Point(137, 43);
            this.dtrDates.Name = "dtrDates";
            this.dtrDates.Size = new System.Drawing.Size(222, 29);
            this.dtrDates.TabIndex = 3;
            // 
            // btnClearTerms
            // 
            this.btnClearTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTerms.FlatAppearance.BorderSize = 0;
            this.btnClearTerms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTerms.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnClearTerms.Location = new System.Drawing.Point(704, 373);
            this.btnClearTerms.Name = "btnClearTerms";
            this.btnClearTerms.Size = new System.Drawing.Size(22, 22);
            this.btnClearTerms.TabIndex = 19;
            this.ttToolTip.SetToolTip(this.btnClearTerms, "Очистить условия");
            this.btnClearTerms.Click += new System.EventHandler(this.btnClearTerms_Click);
            // 
            // lblInventoriesConfirmed
            // 
            this.lblInventoriesConfirmed.AutoSize = true;
            this.lblInventoriesConfirmed.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInventoriesConfirmed.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInventoriesConfirmed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInventoriesConfirmed.Location = new System.Drawing.Point(484, 13);
            this.lblInventoriesConfirmed.Name = "lblInventoriesConfirmed";
            this.lblInventoriesConfirmed.Size = new System.Drawing.Size(218, 14);
            this.lblInventoriesConfirmed.TabIndex = 13;
            this.lblInventoriesConfirmed.Text = "Состояние ревизии: подтверждение";
            // 
            // pnlOpgInventoriesConfirmed
            // 
            this.pnlOpgInventoriesConfirmed.Controls.Add(this.dtrDatesConfirm);
            this.pnlOpgInventoriesConfirmed.Controls.Add(this.optIsNotConfirmed);
            this.pnlOpgInventoriesConfirmed.Controls.Add(this.pnlOpgInventoriesStarted);
            this.pnlOpgInventoriesConfirmed.Controls.Add(this.optIsConfirmed);
            this.pnlOpgInventoriesConfirmed.Controls.Add(this.optAll);
            this.pnlOpgInventoriesConfirmed.Location = new System.Drawing.Point(483, 28);
            this.pnlOpgInventoriesConfirmed.Name = "pnlOpgInventoriesConfirmed";
            this.pnlOpgInventoriesConfirmed.Size = new System.Drawing.Size(243, 148);
            this.pnlOpgInventoriesConfirmed.TabIndex = 14;
            // 
            // dtrDatesConfirm
            // 
            this.dtrDatesConfirm.BegValue = new System.DateTime(2007, 7, 31, 0, 0, 0, 0);
            // 
            // dtrDatesConfirm.btnClear
            // 
            this.dtrDatesConfirm.BtnСlear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dtrDatesConfirm.BtnСlear.Image = ((System.Drawing.Image)(resources.GetObject("dtrDatesConfirm.btnClear.Image")));
            this.dtrDatesConfirm.BtnСlear.Location = new System.Drawing.Point(195, 2);
            this.dtrDatesConfirm.BtnСlear.Name = "btnClear";
            this.dtrDatesConfirm.BtnСlear.Size = new System.Drawing.Size(24, 22);
            this.dtrDatesConfirm.BtnСlear.TabIndex = 3;
            this.dtrDatesConfirm.BtnСlear.UseVisualStyleBackColor = true;
            // 
            // dtrDatesConfirm.dtpBegDate
            // 
            this.dtrDatesConfirm.DtpBegDate.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtrDatesConfirm.DtpBegDate.CustomFormat = "dd.MM.yyyy";
            this.dtrDatesConfirm.DtpBegDate.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtrDatesConfirm.DtpBegDate.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtrDatesConfirm.DtpBegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtrDatesConfirm.DtpBegDate.Location = new System.Drawing.Point(0, 2);
            this.dtrDatesConfirm.DtpBegDate.Name = "dtpBegDate";
            this.dtrDatesConfirm.DtpBegDate.Size = new System.Drawing.Size(91, 22);
            this.dtrDatesConfirm.DtpBegDate.TabIndex = 0;
            // 
            // dtrDatesConfirm.dtpEndDate
            // 
            this.dtrDatesConfirm.DtpEndDate.CalendarFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtrDatesConfirm.DtpEndDate.CustomFormat = "dd.MM.yyyy";
            this.dtrDatesConfirm.DtpEndDate.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtrDatesConfirm.DtpEndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtrDatesConfirm.DtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtrDatesConfirm.DtpEndDate.Location = new System.Drawing.Point(101, 2);
            this.dtrDatesConfirm.DtpEndDate.Name = "dtpEndDate";
            this.dtrDatesConfirm.DtpEndDate.Size = new System.Drawing.Size(91, 22);
            this.dtrDatesConfirm.DtpEndDate.TabIndex = 2;
            this.dtrDatesConfirm.EndValue = new System.DateTime(2007, 7, 31, 0, 0, 0, 0);
            this.dtrDatesConfirm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // dtrDatesConfirm.lblDelimiter
            // 
            this.dtrDatesConfirm.LblDelimiter.AutoSize = true;
            this.dtrDatesConfirm.LblDelimiter.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.dtrDatesConfirm.LblDelimiter.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.dtrDatesConfirm.LblDelimiter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtrDatesConfirm.LblDelimiter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtrDatesConfirm.LblDelimiter.Location = new System.Drawing.Point(90, 5);
            this.dtrDatesConfirm.LblDelimiter.Name = "lblDelimiter";
            this.dtrDatesConfirm.LblDelimiter.Size = new System.Drawing.Size(13, 16);
            this.dtrDatesConfirm.LblDelimiter.TabIndex = 1;
            this.dtrDatesConfirm.LblDelimiter.Text = ":";
            this.dtrDatesConfirm.Location = new System.Drawing.Point(21, 118);
            this.dtrDatesConfirm.Name = "dtrDatesConfirm";
            this.dtrDatesConfirm.Size = new System.Drawing.Size(222, 26);
            this.dtrDatesConfirm.TabIndex = 4;
            // 
            // optIsNotConfirmed
            // 
            this.optIsNotConfirmed.AutoSize = true;
            this.optIsNotConfirmed.Location = new System.Drawing.Point(3, 20);
            this.optIsNotConfirmed.Name = "optIsNotConfirmed";
            this.optIsNotConfirmed.Size = new System.Drawing.Size(129, 18);
            this.optIsNotConfirmed.TabIndex = 1;
            this.optIsNotConfirmed.Text = "не подтверждены";
            this.optIsNotConfirmed.UseVisualStyleBackColor = true;
            this.optIsNotConfirmed.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // pnlOpgInventoriesStarted
            // 
            this.pnlOpgInventoriesStarted.Controls.Add(this.optNotStarted);
            this.pnlOpgInventoriesStarted.Controls.Add(this.optStartedNotConfirmed);
            this.pnlOpgInventoriesStarted.Controls.Add(this.optStartedAll);
            this.pnlOpgInventoriesStarted.Location = new System.Drawing.Point(19, 38);
            this.pnlOpgInventoriesStarted.Name = "pnlOpgInventoriesStarted";
            this.pnlOpgInventoriesStarted.Size = new System.Drawing.Size(167, 63);
            this.pnlOpgInventoriesStarted.TabIndex = 2;
            // 
            // optNotStarted
            // 
            this.optNotStarted.AutoSize = true;
            this.optNotStarted.Location = new System.Drawing.Point(3, 23);
            this.optNotStarted.Name = "optNotStarted";
            this.optNotStarted.Size = new System.Drawing.Size(144, 18);
            this.optNotStarted.TabIndex = 1;
            this.optNotStarted.Text = "обработка не начата";
            this.optNotStarted.UseVisualStyleBackColor = true;
            // 
            // optStartedNotConfirmed
            // 
            this.optStartedNotConfirmed.AutoSize = true;
            this.optStartedNotConfirmed.Location = new System.Drawing.Point(3, 42);
            this.optStartedNotConfirmed.Name = "optStartedNotConfirmed";
            this.optStartedNotConfirmed.Size = new System.Drawing.Size(126, 18);
            this.optStartedNotConfirmed.TabIndex = 2;
            this.optStartedNotConfirmed.Text = "обработка начата";
            this.optStartedNotConfirmed.UseVisualStyleBackColor = true;
            // 
            // optStartedAll
            // 
            this.optStartedAll.AutoSize = true;
            this.optStartedAll.Checked = true;
            this.optStartedAll.IsChanged = true;
            this.optStartedAll.Location = new System.Drawing.Point(3, 4);
            this.optStartedAll.Name = "optStartedAll";
            this.optStartedAll.Size = new System.Drawing.Size(44, 18);
            this.optStartedAll.TabIndex = 0;
            this.optStartedAll.TabStop = true;
            this.optStartedAll.Text = "все";
            this.optStartedAll.UseVisualStyleBackColor = true;
            // 
            // optIsConfirmed
            // 
            this.optIsConfirmed.AutoSize = true;
            this.optIsConfirmed.Location = new System.Drawing.Point(3, 101);
            this.optIsConfirmed.Name = "optIsConfirmed";
            this.optIsConfirmed.Size = new System.Drawing.Size(111, 18);
            this.optIsConfirmed.TabIndex = 3;
            this.optIsConfirmed.Text = "подтверждены";
            this.optIsConfirmed.UseVisualStyleBackColor = true;
            this.optIsConfirmed.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.IsChanged = true;
            this.optAll.Location = new System.Drawing.Point(3, 2);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(44, 18);
            this.optAll.TabIndex = 0;
            this.optAll.TabStop = true;
            this.optAll.Text = "все";
            this.optAll.UseVisualStyleBackColor = true;
            this.optAll.CheckedChanged += new System.EventHandler(this.optAll_CheckedChanged);
            // 
            // lblInventoryDate
            // 
            this.lblInventoryDate.AutoSize = true;
            this.lblInventoryDate.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInventoryDate.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInventoryDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInventoryDate.Location = new System.Drawing.Point(6, 51);
            this.lblInventoryDate.Name = "lblInventoryDate";
            this.lblInventoryDate.Size = new System.Drawing.Size(83, 14);
            this.lblInventoryDate.TabIndex = 2;
            this.lblInventoryDate.Text = "Дата ревизии";
            // 
            // txtBarCode
            // 
            this.txtBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBarCode.Location = new System.Drawing.Point(137, 9);
            this.txtBarCode.MaxLength = 16;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.OldValue = "";
            this.txtBarCode.Size = new System.Drawing.Size(218, 22);
            this.txtBarCode.TabIndex = 1;
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBarCode.Location = new System.Drawing.Point(6, 12);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(132, 14);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "Штрих-код (контекст)";
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.cntGrids);
            this.tabData.Location = new System.Drawing.Point(4, 23);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(733, 403);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Ревизии";
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
            this.cntGrids.Panel2.Controls.Add(this.tcInventoriesCells);
            this.cntGrids.Size = new System.Drawing.Size(732, 400);
            this.cntGrids.SplitterDistance = 114;
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
            this.grcDateInventory,
            this.grcDateStart,
            this.grcConfirmed,
            this.grcConfirmUserName,
            this.grcNote,
            this.grcBarCode,
            this.grcErpCode,
            this.grcId});
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
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(728, 110);
            this.grdData.TabIndex = 11;
            this.grdData.CurrentRowChanged += new RFMBaseClasses.RFMDataGridView.CurrentRowChangedEventHandler(this.grdData_CurrentRowChanged);
            this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
            // 
            // grcIsConfirmedImage
            // 
            this.grcIsConfirmedImage.HeaderText = "";
            this.grcIsConfirmedImage.Name = "grcIsConfirmedImage";
            this.grcIsConfirmedImage.ReadOnly = true;
            this.grcIsConfirmedImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcIsConfirmedImage.ToolTipText = "Ревизия подтверждена?";
            this.grcIsConfirmedImage.Width = 30;
            // 
            // grcIsConfirmed
            // 
            this.grcIsConfirmed.DataPropertyName = "IsConfirmed";
            this.grcIsConfirmed.HeaderText = "Подтв.";
            this.grcIsConfirmed.Name = "grcIsConfirmed";
            this.grcIsConfirmed.ReadOnly = true;
            this.grcIsConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcIsConfirmed.ToolTipText = "Ревизия подтверждена?";
            this.grcIsConfirmed.Visible = false;
            this.grcIsConfirmed.Width = 40;
            // 
            // grcDateInventory
            // 
            this.grcDateInventory.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateInventory.DataPropertyName = "DateInventory";
            this.grcDateInventory.HeaderText = "Дата";
            this.grcDateInventory.Name = "grcDateInventory";
            this.grcDateInventory.ReadOnly = true;
            this.grcDateInventory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateInventory.ToolTipText = "Дата ревизии";
            this.grcDateInventory.Width = 77;
            // 
            // grcDateStart
            // 
            this.grcDateStart.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateStart.DataPropertyName = "DateStart";
            this.grcDateStart.HeaderText = "Нач.";
            this.grcDateStart.Name = "grcDateStart";
            this.grcDateStart.ReadOnly = true;
            this.grcDateStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateStart.ToolTipText = "Дата-время начала обработки ревизии";
            this.grcDateStart.Width = 120;
            // 
            // grcConfirmed
            // 
            this.grcConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcConfirmed.DataPropertyName = "DateConfirm";
            this.grcConfirmed.HeaderText = "Подтв.";
            this.grcConfirmed.Name = "grcConfirmed";
            this.grcConfirmed.ReadOnly = true;
            this.grcConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcConfirmed.ToolTipText = "Дата-время подтверждения";
            this.grcConfirmed.Width = 120;
            // 
            // grcConfirmUserName
            // 
            this.grcConfirmUserName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcConfirmUserName.DataPropertyName = "ConfirmUserName";
            this.grcConfirmUserName.HeaderText = "Кто подтв.";
            this.grcConfirmUserName.Name = "grcConfirmUserName";
            this.grcConfirmUserName.ReadOnly = true;
            this.grcConfirmUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcConfirmUserName.ToolTipText = "Кто подтвердил ревизию";
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
            // grcBarCode
            // 
            this.grcBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBarCode.DataPropertyName = "BarCode";
            this.grcBarCode.HeaderText = "ШК ревизии";
            this.grcBarCode.Name = "grcBarCode";
            this.grcBarCode.ReadOnly = true;
            this.grcBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBarCode.ToolTipText = "Штрих-код документа";
            this.grcBarCode.Width = 130;
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
            // grcId
            // 
            this.grcId.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcId.DataPropertyName = "Id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcId.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcId.HeaderText = "ID";
            this.grcId.Name = "grcId";
            this.grcId.ReadOnly = true;
            this.grcId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcId.ToolTipText = "Код ревизии";
            this.grcId.Width = 50;
            // 
            // tcInventoriesCells
            // 
            this.tcInventoriesCells.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcInventoriesCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcInventoriesCells.Controls.Add(this.tabInventoriesCells);
            this.tcInventoriesCells.ItemSize = new System.Drawing.Size(120, 18);
            this.tcInventoriesCells.Location = new System.Drawing.Point(0, 0);
            this.tcInventoriesCells.Multiline = true;
            this.tcInventoriesCells.Name = "tcInventoriesCells";
            this.tcInventoriesCells.SelectedIndex = 0;
            this.tcInventoriesCells.Size = new System.Drawing.Size(728, 280);
            this.tcInventoriesCells.TabIndex = 0;
            // 
            // tabInventoriesCells
            // 
            this.tabInventoriesCells.Controls.Add(this.grdInventoriesCells);
            this.tabInventoriesCells.Location = new System.Drawing.Point(4, 4);
            this.tabInventoriesCells.Name = "tabInventoriesCells";
            this.tabInventoriesCells.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventoriesCells.Size = new System.Drawing.Size(720, 254);
            this.tabInventoriesCells.TabIndex = 0;
            this.tabInventoriesCells.Text = "Ячейки";
            this.tabInventoriesCells.UseVisualStyleBackColor = true;
            // 
            // grdInventoriesCells
            // 
            this.grdInventoriesCells.AllowUserToAddRows = false;
            this.grdInventoriesCells.AllowUserToDeleteRows = false;
            this.grdInventoriesCells.AllowUserToOrderColumns = true;
            this.grdInventoriesCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInventoriesCells.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdInventoriesCells.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdInventoriesCells.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInventoriesCells.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdInventoriesCells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInventoriesCells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcIsCellSuccessImage,
            this.grclAddress,
            this.grcStoreZoneName,
            this.grcFrameID,
            this.grcPackingAlias,
            this.grcInBox,
            this.grcBoxWished,
            this.grcBoxConfirmed,
            this.grcBoxDiff,
            this.grcQntWished,
            this.grcQntConfirmed,
            this.grcQntDiff,
            this.grcDateValid,
            this.grcGoodStateName,
            this.grcOwnerName,
            this.grcStoreZoneTypeName,
            this.grcConfirmNote,
            this.grcUserName,
            this.grcFixedPackingAlias,
            this.grcCellID});
            this.grdInventoriesCells.IsConfigInclude = true;
            this.grdInventoriesCells.IsMarkedAll = false;
            this.grdInventoriesCells.IsStatusInclude = true;
            this.grdInventoriesCells.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdInventoriesCells.Location = new System.Drawing.Point(0, 0);
            this.grdInventoriesCells.MultiSelect = false;
            this.grdInventoriesCells.Name = "grdInventoriesCells";
            this.grdInventoriesCells.RangedWay = ' ';
            this.grdInventoriesCells.ReadOnly = true;
            this.grdInventoriesCells.RowHeadersWidth = 24;
            this.grdInventoriesCells.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdInventoriesCells.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdInventoriesCells.Size = new System.Drawing.Size(719, 251);
            this.grdInventoriesCells.TabIndex = 13;
            this.grdInventoriesCells.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInventoriesCells_RowEnter);
            this.grdInventoriesCells.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdInventoriesCells_CellFormatting);
            // 
            // grcIsCellSuccessImage
            // 
            this.grcIsCellSuccessImage.HeaderText = "ОК";
            this.grcIsCellSuccessImage.Name = "grcIsCellSuccessImage";
            this.grcIsCellSuccessImage.ReadOnly = true;
            this.grcIsCellSuccessImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcIsCellSuccessImage.ToolTipText = "Обработка ячейки: черная галочка - нет несоответствий, красная галочка - есть нес" +
                "оответствия, пусто - ячейка не обработана";
            this.grcIsCellSuccessImage.Width = 45;
            // 
            // grclAddress
            // 
            this.grclAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grclAddress.DataPropertyName = "Address";
            this.grclAddress.HeaderText = "Ячейка";
            this.grclAddress.Name = "grclAddress";
            this.grclAddress.ReadOnly = true;
            this.grclAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grclAddress.ToolTipText = "Адрес ячейки";
            this.grclAddress.Width = 80;
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
            // grcFrameID
            // 
            this.grcFrameID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcFrameID.DataPropertyName = "FrameID";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcFrameID.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcFrameID.HeaderText = "Контейнер";
            this.grcFrameID.Name = "grcFrameID";
            this.grcFrameID.ReadOnly = true;
            this.grcFrameID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcFrameID.Width = 80;
            // 
            // grcPackingAlias
            // 
            this.grcPackingAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPackingAlias.DataPropertyName = "GoodAlias";
            this.grcPackingAlias.HeaderText = "Товар";
            this.grcPackingAlias.Name = "grcPackingAlias";
            this.grcPackingAlias.ReadOnly = true;
            this.grcPackingAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPackingAlias.Width = 250;
            // 
            // grcInBox
            // 
            this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcInBox.DataPropertyName = "InBox";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.grcInBox.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcInBox.HeaderText = "В кор.";
            this.grcInBox.Name = "grcInBox";
            this.grcInBox.ReadOnly = true;
            this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcInBox.ToolTipText = "Штук в коробке";
            this.grcInBox.Width = 55;
            // 
            // grcBoxWished
            // 
            this.grcBoxWished.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxWished.DataPropertyName = "BoxWished";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            this.grcBoxWished.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcBoxWished.HeaderText = "Кор. До";
            this.grcBoxWished.Name = "grcBoxWished";
            this.grcBoxWished.ReadOnly = true;
            this.grcBoxWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxWished.ToolTipText = "Коробок до ревизии (по компьютеру)";
            this.grcBoxWished.Width = 80;
            // 
            // grcBoxConfirmed
            // 
            this.grcBoxConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxConfirmed.DataPropertyName = "BoxConfirmed";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            this.grcBoxConfirmed.DefaultCellStyle = dataGridViewCellStyle7;
            this.grcBoxConfirmed.HeaderText = "Кор.Факт";
            this.grcBoxConfirmed.Name = "grcBoxConfirmed";
            this.grcBoxConfirmed.ReadOnly = true;
            this.grcBoxConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxConfirmed.ToolTipText = "Коробок фактически";
            this.grcBoxConfirmed.Width = 80;
            // 
            // grcBoxDiff
            // 
            this.grcBoxDiff.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxDiff.DataPropertyName = "BoxDiff";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N1";
            this.grcBoxDiff.DefaultCellStyle = dataGridViewCellStyle8;
            this.grcBoxDiff.HeaderText = "Кор.РАЗН.";
            this.grcBoxDiff.Name = "grcBoxDiff";
            this.grcBoxDiff.ReadOnly = true;
            this.grcBoxDiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxDiff.ToolTipText = "Коробок разница (Факт - До)";
            this.grcBoxDiff.Width = 80;
            // 
            // grcQntWished
            // 
            this.grcQntWished.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntWished.DataPropertyName = "QntWished";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.grcQntWished.DefaultCellStyle = dataGridViewCellStyle9;
            this.grcQntWished.HeaderText = "Штук До";
            this.grcQntWished.Name = "grcQntWished";
            this.grcQntWished.ReadOnly = true;
            this.grcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntWished.ToolTipText = "Штук до ревизии (по компьютеру)";
            this.grcQntWished.Width = 90;
            // 
            // grcQntConfirmed
            // 
            this.grcQntConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntConfirmed.DataPropertyName = "QntConfirmed";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.grcQntConfirmed.DefaultCellStyle = dataGridViewCellStyle10;
            this.grcQntConfirmed.HeaderText = "Штук Факт";
            this.grcQntConfirmed.Name = "grcQntConfirmed";
            this.grcQntConfirmed.ReadOnly = true;
            this.grcQntConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntConfirmed.ToolTipText = "Штук фактически";
            this.grcQntConfirmed.Width = 90;
            // 
            // grcQntDiff
            // 
            this.grcQntDiff.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntDiff.DataPropertyName = "QntDiff";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N1";
            this.grcQntDiff.DefaultCellStyle = dataGridViewCellStyle11;
            this.grcQntDiff.HeaderText = "Штук РАЗН.";
            this.grcQntDiff.Name = "grcQntDiff";
            this.grcQntDiff.ReadOnly = true;
            this.grcQntDiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntDiff.ToolTipText = "Штук разница (Факт - До)";
            this.grcQntDiff.Width = 90;
            // 
            // grcDateValid
            // 
            this.grcDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateValid.DataPropertyName = "DateValid";
            dataGridViewCellStyle12.Format = "dd.MM.yyyy";
            this.grcDateValid.DefaultCellStyle = dataGridViewCellStyle12;
            this.grcDateValid.HeaderText = "Срок годн.";
            this.grcDateValid.Name = "grcDateValid";
            this.grcDateValid.ReadOnly = true;
            this.grcDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateValid.ToolTipText = "Срок годности";
            this.grcDateValid.Width = 80;
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
            this.grcOwnerName.HeaderText = "Владелец";
            this.grcOwnerName.Name = "grcOwnerName";
            this.grcOwnerName.ReadOnly = true;
            this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcStoreZoneTypeName
            // 
            this.grcStoreZoneTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcStoreZoneTypeName.DataPropertyName = "StoreZoneTypeName";
            this.grcStoreZoneTypeName.HeaderText = "Тип скл.зоны";
            this.grcStoreZoneTypeName.Name = "grcStoreZoneTypeName";
            this.grcStoreZoneTypeName.ReadOnly = true;
            this.grcStoreZoneTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcConfirmNote
            // 
            this.grcConfirmNote.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcConfirmNote.DataPropertyName = "ConfirmNote";
            this.grcConfirmNote.HeaderText = "Примечание";
            this.grcConfirmNote.Name = "grcConfirmNote";
            this.grcConfirmNote.ReadOnly = true;
            this.grcConfirmNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcConfirmNote.Width = 200;
            // 
            // grcUserName
            // 
            this.grcUserName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcUserName.DataPropertyName = "UserName";
            this.grcUserName.HeaderText = "Пользователь";
            this.grcUserName.Name = "grcUserName";
            this.grcUserName.ReadOnly = true;
            this.grcUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcUserName.Width = 120;
            // 
            // grcFixedPackingAlias
            // 
            this.grcFixedPackingAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcFixedPackingAlias.DataPropertyName = "FixedPackingAlias";
            this.grcFixedPackingAlias.HeaderText = "Закреплен товар";
            this.grcFixedPackingAlias.Name = "grcFixedPackingAlias";
            this.grcFixedPackingAlias.ReadOnly = true;
            this.grcFixedPackingAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcFixedPackingAlias.Width = 200;
            // 
            // grcCellID
            // 
            this.grcCellID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcCellID.DataPropertyName = "CellID";
            this.grcCellID.HeaderText = "CellID";
            this.grcCellID.Name = "grcCellID";
            this.grcCellID.ReadOnly = true;
            this.grcCellID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcCellID.Visible = false;
            // 
            // mnuPrint
            // 
            this.mnuPrint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniPrintInventoryEmpty,
            this.mniPrintInventoryBillContents,
            this.mniPrintInventoryBillBlank,
            this.mniPrintInventoryBillFull,
            this.mniPrintInventoryTotalReport});
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuPrint.ShowImageMargin = false;
            this.mnuPrint.Size = new System.Drawing.Size(336, 114);
            // 
            // mniPrintInventoryEmpty
            // 
            this.mniPrintInventoryEmpty.Name = "mniPrintInventoryEmpty";
            this.mniPrintInventoryEmpty.Size = new System.Drawing.Size(335, 22);
            this.mniPrintInventoryEmpty.Text = "Бланк-пустографка";
            this.mniPrintInventoryEmpty.Click += new System.EventHandler(this.mniPrintInventoryEmpty_Click);
            // 
            // mniPrintInventoryBillContents
            // 
            this.mniPrintInventoryBillContents.Name = "mniPrintInventoryBillContents";
            this.mniPrintInventoryBillContents.Size = new System.Drawing.Size(335, 22);
            this.mniPrintInventoryBillContents.Text = "Бланк ревизии (с содержимым ячеек)";
            this.mniPrintInventoryBillContents.Click += new System.EventHandler(this.mniPrintInventoryBillContents_Click);
            // 
            // mniPrintInventoryBillBlank
            // 
            this.mniPrintInventoryBillBlank.Name = "mniPrintInventoryBillBlank";
            this.mniPrintInventoryBillBlank.Size = new System.Drawing.Size(335, 22);
            this.mniPrintInventoryBillBlank.Text = "Бланк ревизии (со штрих-кодами ячеек)";
            this.mniPrintInventoryBillBlank.Click += new System.EventHandler(this.mniPrintInventoryBillBlank_Click);
            // 
            // mniPrintInventoryBillFull
            // 
            this.mniPrintInventoryBillFull.Name = "mniPrintInventoryBillFull";
            this.mniPrintInventoryBillFull.Size = new System.Drawing.Size(335, 22);
            this.mniPrintInventoryBillFull.Text = "Отчет (со старым и новым состоянием)";
            this.mniPrintInventoryBillFull.Click += new System.EventHandler(this.mniPrintInventoryBillBlank_Click);
            // 
            // mniPrintInventoryTotalReport
            // 
            this.mniPrintInventoryTotalReport.Name = "mniPrintInventoryTotalReport";
            this.mniPrintInventoryTotalReport.Size = new System.Drawing.Size(335, 22);
            this.mniPrintInventoryTotalReport.Text = "Суммарный отчет по отмеченным ревизиям";
            this.mniPrintInventoryTotalReport.Click += new System.EventHandler(this.mniPrintInventoryTotalReport_Click);
            // 
            // btnService
            // 
            this.btnService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnService.Enabled = false;
            this.btnService.Image = global::WMSSuitable.Properties.Resources.Service;
            this.btnService.IsAccessOn = true;
            this.btnService.Location = new System.Drawing.Point(656, 439);
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
            this.btnPrint.Location = new System.Drawing.Point(606, 439);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 5;
            this.ttToolTip.SetToolTip(this.btnPrint, "Печать");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPrint_MouseClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(5, 439);
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
            this.btnDelete.Location = new System.Drawing.Point(556, 439);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 30);
            this.btnDelete.TabIndex = 4;
            this.ttToolTip.SetToolTip(this.btnDelete, "Удаление ревизии");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
            this.btnAdd.IsAccessOn = true;
            this.btnAdd.Location = new System.Drawing.Point(324, 438);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnAdd, "Добавление ревизии");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnCancel.Location = new System.Drawing.Point(706, 439);
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
            this.btnEdit.Location = new System.Drawing.Point(374, 439);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 30);
            this.btnEdit.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnEdit, "Редактирование ревизии");
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Image = global::WMSSuitable.Properties.Resources.Go;
            this.btnConfirm.IsAccessOn = true;
            this.btnConfirm.Location = new System.Drawing.Point(506, 439);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(30, 30);
            this.btnConfirm.TabIndex = 3;
            this.ttToolTip.SetToolTip(this.btnConfirm, "Подтверждение ревизии");
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // mnuService
            // 
            this.mnuService.Name = "mnuPrint";
            this.mnuService.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuService.ShowImageMargin = false;
            this.mnuService.Size = new System.Drawing.Size(36, 4);
            // 
            // btnMedication
            // 
            this.btnMedication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMedication.Enabled = false;
            this.btnMedication.Image = global::WMSSuitable.Properties.Resources.Medication;
            this.btnMedication.IsAccessOn = true;
            this.btnMedication.Location = new System.Drawing.Point(424, 439);
            this.btnMedication.Name = "btnMedication";
            this.btnMedication.Size = new System.Drawing.Size(30, 30);
            this.btnMedication.TabIndex = 8;
            this.ttToolTip.SetToolTip(this.btnMedication, "Ввод фактического содержимого ячейки");
            this.btnMedication.UseVisualStyleBackColor = true;
            // 
            // tmrRestore
            // 
            this.tmrRestore.Tick += new System.EventHandler(this.tmrRestore_Tick);
            // 
            // btnMedicationNotFrames
            // 
            this.btnMedicationNotFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMedicationNotFrames.Enabled = false;
            this.btnMedicationNotFrames.Image = global::WMSSuitable.Properties.Resources.Boxes;
            this.btnMedicationNotFrames.IsAccessOn = true;
            this.btnMedicationNotFrames.Location = new System.Drawing.Point(456, 439);
            this.btnMedicationNotFrames.Name = "btnMedicationNotFrames";
            this.btnMedicationNotFrames.Size = new System.Drawing.Size(30, 30);
            this.btnMedicationNotFrames.TabIndex = 9;
            this.ttToolTip.SetToolTip(this.btnMedicationNotFrames, "Ввод фактического содержимого неконтейнерных ячеек");
            this.btnMedicationNotFrames.UseVisualStyleBackColor = true;
            // 
            // frmInventories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 474);
            this.Controls.Add(this.btnMedicationNotFrames);
            this.Controls.Add(this.btnMedication);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnService);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tcList);
            this.hpHelp.SetHelpKeyword(this, "902");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.hpHelp.SetHelpString(this, "");
            this.IsAccessOn = true;
            this.IsWaitLoading = true;
            this.LastGrid = this.grdData;
            this.MinimumSize = new System.Drawing.Size(750, 501);
            this.Name = "frmInventories";
            this.hpHelp.SetShowHelp(this, true);
            this.Text = "Ревизии";
            this.Load += new System.EventHandler(this.frmInventories_Load);
            this.tcList.ResumeLayout(false);
            this.tabTerms.ResumeLayout(false);
            this.cntTerms.ResumeLayout(false);
            this.cntTerms.PerformLayout();
            this.pnlPackings.ResumeLayout(false);
            this.pnlPackings.PerformLayout();
            this.pnlInventoriesErrors.ResumeLayout(false);
            this.pnlInventoriesErrors.PerformLayout();
            this.pnlCells.ResumeLayout(false);
            this.pnlCells.PerformLayout();
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.dtrDates.ResumeLayout(false);
            this.dtrDates.PerformLayout();
            this.pnlOpgInventoriesConfirmed.ResumeLayout(false);
            this.pnlOpgInventoriesConfirmed.PerformLayout();
            this.dtrDatesConfirm.ResumeLayout(false);
            this.dtrDatesConfirm.PerformLayout();
            this.pnlOpgInventoriesStarted.ResumeLayout(false);
            this.pnlOpgInventoriesStarted.PerformLayout();
            this.tabData.ResumeLayout(false);
            this.cntGrids.Panel1.ResumeLayout(false);
            this.cntGrids.Panel2.ResumeLayout(false);
            this.cntGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tcInventoriesCells.ResumeLayout(false);
            this.tabInventoriesCells.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInventoriesCells)).EndInit();
            this.mnuPrint.ResumeLayout(false);
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
		private RFMBaseClasses.RFMTabControl tcInventoriesCells;
		private RFMBaseClasses.RFMTabPage tabInventoriesCells;
		private RFMBaseClasses.RFMDataGridView grdInventoriesCells;
		private RFMBaseClasses.RFMButton btnClearTerms;
		private RFMBaseClasses.RFMContextToolStripMenuItem mniPrintInventoryBillBlank;
		private RFMBaseClasses.RFMPanel cntTerms;
		private RFMBaseClasses.RFMLabel lblInventoriesConfirmed;
		private RFMBaseClasses.RFMPanel pnlOpgInventoriesConfirmed;
		private RFMBaseClasses.RFMRadioButton optIsNotConfirmed;
		private RFMBaseClasses.RFMRadioButton optIsConfirmed;
		private RFMBaseClasses.RFMRadioButton optAll;
		private RFMBaseClasses.RFMLabel lblInventoryDate;
		private RFMBaseClasses.RFMTextBoxBarCode txtBarCode;
		private RFMBaseClasses.RFMLabel lblBarCode;
		private RFMBaseClasses.RFMDateRange dtrDates;
		private RFMBaseClasses.RFMButton btnUsersClear;
		private RFMBaseClasses.RFMButton btnUsersChoose;
		private RFMBaseClasses.RFMLabel lblUsers;
		private RFMBaseClasses.RFMPanel pnlUsers;
		private RFMBaseClasses.RFMTextBox txtUsersChoosen;
		private RFMBaseClasses.RFMPanel pnlOpgInventoriesStarted;
		private RFMBaseClasses.RFMRadioButton optNotStarted;
		private RFMBaseClasses.RFMRadioButton optStartedNotConfirmed;
		private RFMBaseClasses.RFMRadioButton optStartedAll;
		private RFMBaseClasses.RFMPanel pnlCells;
		private RFMBaseClasses.RFMTextBox txtCellsChoosen;
		private RFMBaseClasses.RFMButton btnCellsClear;
		private RFMBaseClasses.RFMButton btnCellsChoose;
		private RFMBaseClasses.RFMLabel lblCells;
		private RFMBaseClasses.RFMPanel pnlInventoriesErrors;
		private RFMBaseClasses.RFMTextBox txtInventoriesErrorsChoosen;
		private RFMBaseClasses.RFMButton btnInventoriesErrorsClear;
		private RFMBaseClasses.RFMButton btnInventoriesErrorsChoose;
		private RFMBaseClasses.RFMLabel lblInventoriesErrors;
		private RFMBaseClasses.RFMContextToolStripMenuItem mniPrintInventoryEmpty;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcIsConfirmedImage;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcIsConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateInventory;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateStart;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcConfirmUserName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNote;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcErpCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcId;
		private RFMBaseClasses.RFMButton btnMedication;
		private RFMBaseClasses.RFMTimer tmrRestore;
		private RFMBaseClasses.RFMContextToolStripMenuItem mniPrintInventoryBillContents;
		private RFMBaseClasses.RFMButton btnMedicationNotFrames;
		private RFMBaseClasses.RFMContextToolStripMenuItem mniPrintInventoryBillFull;
		private RFMBaseClasses.RFMPanel pnlPackings;
		private RFMBaseClasses.RFMTextBox txtPackingsChoosen;
		private RFMBaseClasses.RFMButton btnPackingsClear;
		private RFMBaseClasses.RFMButton btnPackingsChoose;
		private RFMBaseClasses.RFMLabel lblPackings;
		private RFMBaseClasses.RFMDateRange dtrDatesConfirm;
		private System.Windows.Forms.ToolStripMenuItem mniPrintInventoryTotalReport;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcIsCellSuccessImage;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grclAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFrameID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxDiff;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntDiff;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcConfirmNote;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcUserName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFixedPackingAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellID;
		private RFMBaseClasses.RFMCheckBox chkShowSelectedGoodsOnly;
	}
}