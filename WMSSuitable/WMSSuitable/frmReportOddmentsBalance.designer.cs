namespace WMSSuitable
{
	partial class frmReportOddmentsBalance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportOddmentsBalance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuService = new RFMBaseClasses.RFMContextMenuStrip();
            this.btnDetail = new RFMBaseClasses.RFMButton();
            this.btnPrint = new RFMBaseClasses.RFMButton();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.btnClearTerms = new RFMBaseClasses.RFMButton();
            this.mnuPrint = new RFMBaseClasses.RFMContextMenuStrip();
            this.tabData = new RFMBaseClasses.RFMTabPage();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.tabTerms = new RFMBaseClasses.RFMTabPage();
            this.cntTerms = new RFMBaseClasses.RFMPanel();
            this.opgMode = new RFMBaseClasses.RFMPanel();
            this.optModeNetto = new RFMBaseClasses.RFMRadioButton();
            this.optModePieces = new RFMBaseClasses.RFMRadioButton();
            this.optModeBoxes = new RFMBaseClasses.RFMRadioButton();
            this.optModePallets = new RFMBaseClasses.RFMRadioButton();
            this.lblMode = new RFMBaseClasses.RFMLabel();
            this.pnlGoodsStates = new RFMBaseClasses.RFMPanel();
            this.txtGoodsStatesChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnGoodsStatesClear = new RFMBaseClasses.RFMButton();
            this.btnGoodsStatesChoose = new RFMBaseClasses.RFMButton();
            this.lblGroupBy = new RFMBaseClasses.RFMLabel();
            this.opgActual = new RFMBaseClasses.RFMPanel();
            this.lblGroupYes = new RFMBaseClasses.RFMLabel();
            this.optGroupYes = new RFMBaseClasses.RFMRadioButton();
            this.optGroupNo = new RFMBaseClasses.RFMRadioButton();
            this.pnlPackings = new RFMBaseClasses.RFMPanel();
            this.txtPackingsChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnPackingsClear = new RFMBaseClasses.RFMButton();
            this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
            this.pnlOwners = new RFMBaseClasses.RFMPanel();
            this.txtOwnersChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnOwnersClear = new RFMBaseClasses.RFMButton();
            this.btnOwnersChoose = new RFMBaseClasses.RFMButton();
            this.dtrDates = new RFMBaseClasses.RFMDateRange();
            this.chkGroupOwner = new RFMBaseClasses.RFMCheckBox();
            this.lblDates = new RFMBaseClasses.RFMLabel();
            this.lblPackings = new RFMBaseClasses.RFMLabel();
            this.lblOwners = new RFMBaseClasses.RFMLabel();
            this.lblGoodsStates = new RFMBaseClasses.RFMLabel();
            this.tcList = new RFMBaseClasses.RFMTabControl();
            this.grcTypeImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
            this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntBeg = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntPlus = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntPlusAct = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntMinus = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntMinusAct = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntEnd = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcQntInCells = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcSeparatePicking = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcPackingID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcOwnerID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tabTerms.SuspendLayout();
            this.cntTerms.SuspendLayout();
            this.opgMode.SuspendLayout();
            this.pnlGoodsStates.SuspendLayout();
            this.opgActual.SuspendLayout();
            this.pnlPackings.SuspendLayout();
            this.pnlOwners.SuspendLayout();
            this.dtrDates.SuspendLayout();
            this.tcList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuService
            // 
            this.mnuService.Name = "mnuPrint";
            this.mnuService.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuService.ShowImageMargin = false;
            this.mnuService.Size = new System.Drawing.Size(36, 4);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Enabled = false;
            this.btnDetail.Image = global::WMSSuitable.Properties.Resources.Detail;
            this.btnDetail.Location = new System.Drawing.Point(656, 438);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(30, 30);
            this.btnDetail.TabIndex = 8;
            this.ttToolTip.SetToolTip(this.btnDetail, "Операции с товаром");
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
            this.btnPrint.Location = new System.Drawing.Point(606, 438);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 7;
            this.ttToolTip.SetToolTip(this.btnPrint, "Печать");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPrint_MouseClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(5, 438);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnCancel.Location = new System.Drawing.Point(706, 438);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 30);
            this.btnCancel.TabIndex = 9;
            this.ttToolTip.SetToolTip(this.btnCancel, "Выход");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClearTerms
            // 
            this.btnClearTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTerms.FlatAppearance.BorderSize = 0;
            this.btnClearTerms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTerms.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnClearTerms.Location = new System.Drawing.Point(703, 371);
            this.btnClearTerms.Name = "btnClearTerms";
            this.btnClearTerms.Size = new System.Drawing.Size(23, 24);
            this.btnClearTerms.TabIndex = 11;
            this.btnClearTerms.Click += new System.EventHandler(this.btnClearTerms_Click);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuPrint.ShowImageMargin = false;
            this.mnuPrint.Size = new System.Drawing.Size(36, 4);
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.grdData);
            this.tabData.Location = new System.Drawing.Point(4, 23);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(733, 403);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Остатки, операции";
            this.tabData.UseVisualStyleBackColor = true;
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
            this.grcTypeImage,
            this.grcGoodAlias,
            this.grcInBox,
            this.grcQntBeg,
            this.grcQntPlus,
            this.grcQntPlusAct,
            this.grcQntMinus,
            this.grcQntMinusAct,
            this.grcQntEnd,
            this.grcQntInCells,
            this.grcGoodStateName,
            this.grcOwnerName,
            this.grcSeparatePicking,
            this.grcGoodGroupName,
            this.grcGoodBrandName,
            this.grcGoodBarCode,
            this.grcWeighting,
            this.grcPackingID,
            this.grcGoodStateID,
            this.grcOwnerID});
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
            this.grdData.Location = new System.Drawing.Point(0, 2);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(732, 400);
            this.grdData.StatusRowState = ((byte)(2));
            this.grdData.TabIndex = 11;
            this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
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
            this.cntTerms.Controls.Add(this.opgMode);
            this.cntTerms.Controls.Add(this.lblMode);
            this.cntTerms.Controls.Add(this.pnlGoodsStates);
            this.cntTerms.Controls.Add(this.lblGroupBy);
            this.cntTerms.Controls.Add(this.opgActual);
            this.cntTerms.Controls.Add(this.pnlPackings);
            this.cntTerms.Controls.Add(this.pnlOwners);
            this.cntTerms.Controls.Add(this.dtrDates);
            this.cntTerms.Controls.Add(this.chkGroupOwner);
            this.cntTerms.Controls.Add(this.lblDates);
            this.cntTerms.Controls.Add(this.btnClearTerms);
            this.cntTerms.Controls.Add(this.lblPackings);
            this.cntTerms.Controls.Add(this.lblOwners);
            this.cntTerms.Controls.Add(this.lblGoodsStates);
            this.hpHelp.SetHelpKeyword(this.cntTerms, "502");
            this.hpHelp.SetHelpNavigator(this.cntTerms, System.Windows.Forms.HelpNavigator.TopicId);
            this.cntTerms.Location = new System.Drawing.Point(0, 2);
            this.cntTerms.Name = "cntTerms";
            this.hpHelp.SetShowHelp(this.cntTerms, true);
            this.cntTerms.Size = new System.Drawing.Size(732, 400);
            this.cntTerms.TabIndex = 0;
            // 
            // opgMode
            // 
            this.opgMode.Controls.Add(this.optModeNetto);
            this.opgMode.Controls.Add(this.optModePieces);
            this.opgMode.Controls.Add(this.optModeBoxes);
            this.opgMode.Controls.Add(this.optModePallets);
            this.opgMode.Location = new System.Drawing.Point(135, 240);
            this.opgMode.Name = "opgMode";
            this.opgMode.Size = new System.Drawing.Size(130, 90);
            this.opgMode.TabIndex = 13;
            // 
            // optModeNetto
            // 
            this.optModeNetto.AutoSize = true;
            this.optModeNetto.Location = new System.Drawing.Point(5, 65);
            this.optModeNetto.Name = "optModeNetto";
            this.optModeNetto.Size = new System.Drawing.Size(73, 18);
            this.optModeNetto.TabIndex = 3;
            this.optModeNetto.Text = "кг нетто";
            this.optModeNetto.UseVisualStyleBackColor = true;
            // 
            // optModePieces
            // 
            this.optModePieces.AutoSize = true;
            this.optModePieces.Location = new System.Drawing.Point(5, 45);
            this.optModePieces.Name = "optModePieces";
            this.optModePieces.Size = new System.Drawing.Size(63, 18);
            this.optModePieces.TabIndex = 2;
            this.optModePieces.Text = "штуках";
            this.optModePieces.UseVisualStyleBackColor = true;
            // 
            // optModeBoxes
            // 
            this.optModeBoxes.AutoSize = true;
            this.optModeBoxes.Location = new System.Drawing.Point(5, 25);
            this.optModeBoxes.Name = "optModeBoxes";
            this.optModeBoxes.Size = new System.Drawing.Size(77, 18);
            this.optModeBoxes.TabIndex = 1;
            this.optModeBoxes.Text = "коробках";
            this.optModeBoxes.UseVisualStyleBackColor = true;
            // 
            // optModePallets
            // 
            this.optModePallets.AutoSize = true;
            this.optModePallets.Checked = true;
            this.optModePallets.IsChanged = true;
            this.optModePallets.Location = new System.Drawing.Point(5, 5);
            this.optModePallets.Name = "optModePallets";
            this.optModePallets.Size = new System.Drawing.Size(77, 18);
            this.optModePallets.TabIndex = 0;
            this.optModePallets.TabStop = true;
            this.optModePallets.Text = "паллетах";
            this.optModePallets.UseVisualStyleBackColor = true;
            // 
            // lblMode
            // 
            this.lblMode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblMode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMode.Location = new System.Drawing.Point(7, 247);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(63, 15);
            this.lblMode.TabIndex = 12;
            this.lblMode.Text = "Расчет в:";
            // 
            // pnlGoodsStates
            // 
            this.pnlGoodsStates.Controls.Add(this.txtGoodsStatesChoosen);
            this.pnlGoodsStates.Controls.Add(this.btnGoodsStatesClear);
            this.pnlGoodsStates.Controls.Add(this.btnGoodsStatesChoose);
            this.pnlGoodsStates.Location = new System.Drawing.Point(135, 44);
            this.pnlGoodsStates.Name = "pnlGoodsStates";
            this.pnlGoodsStates.Size = new System.Drawing.Size(287, 30);
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
            this.txtGoodsStatesChoosen.Size = new System.Drawing.Size(228, 22);
            this.txtGoodsStatesChoosen.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.txtGoodsStatesChoosen, "Выбранные состояния товаров");
            // 
            // btnGoodsStatesClear
            // 
            this.btnGoodsStatesClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnGoodsStatesClear.Location = new System.Drawing.Point(259, 3);
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
            this.btnGoodsStatesChoose.Location = new System.Drawing.Point(231, 3);
            this.btnGoodsStatesChoose.Name = "btnGoodsStatesChoose";
            this.btnGoodsStatesChoose.Size = new System.Drawing.Size(26, 24);
            this.btnGoodsStatesChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnGoodsStatesChoose, "Выбор состояний товаров");
            this.btnGoodsStatesChoose.UseVisualStyleBackColor = true;
            this.btnGoodsStatesChoose.Click += new System.EventHandler(this.btnGoodsStatesChoose_Click);
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGroupBy.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGroupBy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGroupBy.Location = new System.Drawing.Point(7, 92);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(99, 34);
            this.lblGroupBy.TabIndex = 4;
            this.lblGroupBy.Text = "Объединять операции по:";
            // 
            // opgActual
            // 
            this.opgActual.Controls.Add(this.lblGroupYes);
            this.opgActual.Controls.Add(this.optGroupYes);
            this.opgActual.Controls.Add(this.optGroupNo);
            this.opgActual.Location = new System.Drawing.Point(135, 85);
            this.opgActual.Name = "opgActual";
            this.opgActual.Size = new System.Drawing.Size(220, 65);
            this.opgActual.TabIndex = 5;
            // 
            // lblGroupYes
            // 
            this.lblGroupYes.AutoSize = true;
            this.lblGroupYes.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGroupYes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGroupYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGroupYes.Location = new System.Drawing.Point(20, 45);
            this.lblGroupYes.Name = "lblGroupYes";
            this.lblGroupYes.Size = new System.Drawing.Size(187, 14);
            this.lblGroupYes.TabIndex = 46;
            this.lblGroupYes.Text = "(общий товар - одной строкой)";
            // 
            // optGroupYes
            // 
            this.optGroupYes.AutoSize = true;
            this.optGroupYes.Location = new System.Drawing.Point(5, 25);
            this.optGroupYes.Name = "optGroupYes";
            this.optGroupYes.Size = new System.Drawing.Size(214, 18);
            this.optGroupYes.TabIndex = 4;
            this.optGroupYes.Text = "хранителю с раздельным учетом";
            this.optGroupYes.UseVisualStyleBackColor = true;
            // 
            // optGroupNo
            // 
            this.optGroupNo.AutoSize = true;
            this.optGroupNo.Checked = true;
            this.optGroupNo.IsChanged = true;
            this.optGroupNo.Location = new System.Drawing.Point(5, 5);
            this.optGroupNo.Name = "optGroupNo";
            this.optGroupNo.Size = new System.Drawing.Size(84, 18);
            this.optGroupNo.TabIndex = 3;
            this.optGroupNo.TabStop = true;
            this.optGroupNo.Text = "владельцу";
            this.optGroupNo.UseVisualStyleBackColor = true;
            this.optGroupNo.CheckedChanged += new System.EventHandler(this.optGroupNo_CheckedChanged);
            // 
            // pnlPackings
            // 
            this.pnlPackings.Controls.Add(this.txtPackingsChoosen);
            this.pnlPackings.Controls.Add(this.btnPackingsClear);
            this.pnlPackings.Controls.Add(this.btnPackingsChoose);
            this.pnlPackings.Location = new System.Drawing.Point(135, 200);
            this.pnlPackings.Name = "pnlPackings";
            this.pnlPackings.Size = new System.Drawing.Size(287, 30);
            this.pnlPackings.TabIndex = 9;
            // 
            // txtPackingsChoosen
            // 
            this.txtPackingsChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtPackingsChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPackingsChoosen.Enabled = false;
            this.txtPackingsChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtPackingsChoosen.Name = "txtPackingsChoosen";
            this.txtPackingsChoosen.OldValue = "";
            this.txtPackingsChoosen.Size = new System.Drawing.Size(228, 22);
            this.txtPackingsChoosen.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.txtPackingsChoosen, "Контекст названия поставщика");
            // 
            // btnPackingsClear
            // 
            this.btnPackingsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnPackingsClear.Location = new System.Drawing.Point(259, 3);
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
            this.btnPackingsChoose.Location = new System.Drawing.Point(231, 3);
            this.btnPackingsChoose.Name = "btnPackingsChoose";
            this.btnPackingsChoose.Size = new System.Drawing.Size(26, 24);
            this.btnPackingsChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnPackingsChoose, "Выбор товаров");
            this.btnPackingsChoose.UseVisualStyleBackColor = true;
            this.btnPackingsChoose.Click += new System.EventHandler(this.btnPackingsChoose_Click);
            // 
            // pnlOwners
            // 
            this.pnlOwners.Controls.Add(this.txtOwnersChoosen);
            this.pnlOwners.Controls.Add(this.btnOwnersClear);
            this.pnlOwners.Controls.Add(this.btnOwnersChoose);
            this.pnlOwners.Location = new System.Drawing.Point(135, 160);
            this.pnlOwners.Name = "pnlOwners";
            this.pnlOwners.Size = new System.Drawing.Size(287, 30);
            this.pnlOwners.TabIndex = 7;
            // 
            // txtOwnersChoosen
            // 
            this.txtOwnersChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOwnersChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwnersChoosen.Enabled = false;
            this.txtOwnersChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtOwnersChoosen.Name = "txtOwnersChoosen";
            this.txtOwnersChoosen.OldValue = "";
            this.txtOwnersChoosen.Size = new System.Drawing.Size(228, 22);
            this.txtOwnersChoosen.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.txtOwnersChoosen, "Контекст названия поставщика");
            // 
            // btnOwnersClear
            // 
            this.btnOwnersClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnOwnersClear.Location = new System.Drawing.Point(259, 3);
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
            this.btnOwnersChoose.Location = new System.Drawing.Point(231, 3);
            this.btnOwnersChoose.Name = "btnOwnersChoose";
            this.btnOwnersChoose.Size = new System.Drawing.Size(26, 24);
            this.btnOwnersChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnOwnersChoose, "Выбор владельцев");
            this.btnOwnersChoose.UseVisualStyleBackColor = true;
            this.btnOwnersChoose.Click += new System.EventHandler(this.btnOwnersChoose_Click);
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
            this.dtrDates.Location = new System.Drawing.Point(132, 6);
            this.dtrDates.Name = "dtrDates";
            this.dtrDates.Size = new System.Drawing.Size(238, 32);
            this.dtrDates.TabIndex = 1;
            // 
            // chkGroupOwner
            // 
            this.chkGroupOwner.AutoSize = true;
            this.chkGroupOwner.Location = new System.Drawing.Point(10, 369);
            this.chkGroupOwner.Name = "chkGroupOwner";
            this.chkGroupOwner.Size = new System.Drawing.Size(255, 18);
            this.chkGroupOwner.TabIndex = 10;
            this.chkGroupOwner.Text = "показывать общий товар одной строкой";
            this.chkGroupOwner.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkGroupOwner.UseVisualStyleBackColor = true;
            // 
            // lblDates
            // 
            this.lblDates.AutoSize = true;
            this.lblDates.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDates.Location = new System.Drawing.Point(7, 12);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(50, 14);
            this.lblDates.TabIndex = 0;
            this.lblDates.Text = "Период";
            // 
            // lblPackings
            // 
            this.lblPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPackings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPackings.Location = new System.Drawing.Point(7, 207);
            this.lblPackings.Name = "lblPackings";
            this.lblPackings.Size = new System.Drawing.Size(99, 15);
            this.lblPackings.TabIndex = 8;
            this.lblPackings.Text = "Товары";
            // 
            // lblOwners
            // 
            this.lblOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwners.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwners.Location = new System.Drawing.Point(7, 160);
            this.lblOwners.Name = "lblOwners";
            this.lblOwners.Size = new System.Drawing.Size(99, 33);
            this.lblOwners.TabIndex = 6;
            this.lblOwners.Text = "Владелец / Хранитель";
            // 
            // lblGoodsStates
            // 
            this.lblGoodsStates.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodsStates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodsStates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodsStates.Location = new System.Drawing.Point(7, 44);
            this.lblGoodsStates.Name = "lblGoodsStates";
            this.lblGoodsStates.Size = new System.Drawing.Size(99, 42);
            this.lblGoodsStates.TabIndex = 2;
            this.lblGoodsStates.Text = "Состояние товара";
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
            this.tcList.TabIndex = 11;
            this.tcList.SelectedIndexChanged += new System.EventHandler(this.tcList_SelectedIndexChanged);
            // 
            // grcTypeImage
            // 
            this.grcTypeImage.HeaderText = "";
            this.grcTypeImage.Name = "grcTypeImage";
            this.grcTypeImage.ReadOnly = true;
            this.grcTypeImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcTypeImage.Visible = false;
            this.grcTypeImage.Width = 40;
            // 
            // grcGoodAlias
            // 
            this.grcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodAlias.DataPropertyName = "GoodAlias";
            this.grcGoodAlias.HeaderText = "Товар";
            this.grcGoodAlias.Name = "grcGoodAlias";
            this.grcGoodAlias.ReadOnly = true;
            this.grcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodAlias.Width = 250;
            // 
            // grcInBox
            // 
            this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcInBox.DataPropertyName = "InBox";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.grcInBox.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcInBox.HeaderText = "В кор.";
            this.grcInBox.Name = "grcInBox";
            this.grcInBox.ReadOnly = true;
            this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcInBox.ToolTipText = "Штук/кг в коробке";
            this.grcInBox.Width = 55;
            // 
            // grcQntBeg
            // 
            this.grcQntBeg.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntBeg.DataPropertyName = "QntBeg";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grcQntBeg.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcQntBeg.HeaderText = "Кол-во нач.";
            this.grcQntBeg.Name = "grcQntBeg";
            this.grcQntBeg.ReadOnly = true;
            this.grcQntBeg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntBeg.ToolTipText = "Штук/кг в начале периода";
            this.grcQntBeg.Width = 90;
            // 
            // grcQntPlus
            // 
            this.grcQntPlus.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntPlus.DataPropertyName = "QntPlus";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grcQntPlus.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcQntPlus.HeaderText = "Приход";
            this.grcQntPlus.Name = "grcQntPlus";
            this.grcQntPlus.ReadOnly = true;
            this.grcQntPlus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntPlus.ToolTipText = "Штук/кг пришло в течение периода";
            // 
            // grcQntPlusAct
            // 
            this.grcQntPlusAct.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntPlusAct.DataPropertyName = "QntPlusAct";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grcQntPlusAct.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcQntPlusAct.HeaderText = "Приход (акт)";
            this.grcQntPlusAct.Name = "grcQntPlusAct";
            this.grcQntPlusAct.ReadOnly = true;
            this.grcQntPlusAct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntPlusAct.ToolTipText = "Штук/кг сактировано в плюс в течение периода";
            // 
            // grcQntMinus
            // 
            this.grcQntMinus.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntMinus.DataPropertyName = "QntMinus";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grcQntMinus.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcQntMinus.HeaderText = "Расход";
            this.grcQntMinus.Name = "grcQntMinus";
            this.grcQntMinus.ReadOnly = true;
            this.grcQntMinus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntMinus.ToolTipText = "Штук/кг израсходовано в течение периода";
            // 
            // grcQntMinusAct
            // 
            this.grcQntMinusAct.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntMinusAct.DataPropertyName = "QntMinusAct";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grcQntMinusAct.DefaultCellStyle = dataGridViewCellStyle7;
            this.grcQntMinusAct.HeaderText = "Расход (акт)";
            this.grcQntMinusAct.Name = "grcQntMinusAct";
            this.grcQntMinusAct.ReadOnly = true;
            this.grcQntMinusAct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntMinusAct.ToolTipText = "Штук/кг сактировано в минус в течение периода";
            // 
            // grcQntEnd
            // 
            this.grcQntEnd.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntEnd.DataPropertyName = "QntEnd";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.grcQntEnd.DefaultCellStyle = dataGridViewCellStyle8;
            this.grcQntEnd.HeaderText = "Кол-во кон.";
            this.grcQntEnd.Name = "grcQntEnd";
            this.grcQntEnd.ReadOnly = true;
            this.grcQntEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntEnd.ToolTipText = "Штук/кг в конце периода";
            this.grcQntEnd.Width = 90;
            // 
            // grcQntInCells
            // 
            this.grcQntInCells.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcQntInCells.DataPropertyName = "QntInCells";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.grcQntInCells.DefaultCellStyle = dataGridViewCellStyle9;
            this.grcQntInCells.HeaderText = "Кол-во расч.кон.";
            this.grcQntInCells.Name = "grcQntInCells";
            this.grcQntInCells.ReadOnly = true;
            this.grcQntInCells.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcQntInCells.ToolTipText = "Штук/кг в конце периода - расчетное от текущего состояния";
            this.grcQntInCells.Width = 90;
            // 
            // grcGoodStateName
            // 
            this.grcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodStateName.DataPropertyName = "GoodStateName";
            this.grcGoodStateName.HeaderText = "Состояние";
            this.grcGoodStateName.Name = "grcGoodStateName";
            this.grcGoodStateName.ReadOnly = true;
            this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodStateName.Width = 120;
            // 
            // grcOwnerName
            // 
            this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOwnerName.DataPropertyName = "OwnerName";
            this.grcOwnerName.HeaderText = "Хранитель/Владелец";
            this.grcOwnerName.Name = "grcOwnerName";
            this.grcOwnerName.ReadOnly = true;
            this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcOwnerName.Width = 150;
            // 
            // grcSeparatePicking
            // 
            this.grcSeparatePicking.DataPropertyName = "SeparatePicking";
            this.grcSeparatePicking.HeaderText = "Учет";
            this.grcSeparatePicking.Name = "grcSeparatePicking";
            this.grcSeparatePicking.ReadOnly = true;
            this.grcSeparatePicking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcSeparatePicking.ToolTipText = "Отдельный учет остатков для владельца";
            this.grcSeparatePicking.Width = 30;
            // 
            // grcGoodGroupName
            // 
            this.grcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodGroupName.DataPropertyName = "GoodGroupName";
            this.grcGoodGroupName.HeaderText = "Товарная группа";
            this.grcGoodGroupName.Name = "grcGoodGroupName";
            this.grcGoodGroupName.ReadOnly = true;
            this.grcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodGroupName.Width = 200;
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
            // grcGoodBarCode
            // 
            this.grcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodBarCode.DataPropertyName = "GoodBarCode";
            this.grcGoodBarCode.HeaderText = "ШК товара";
            this.grcGoodBarCode.Name = "grcGoodBarCode";
            this.grcGoodBarCode.ReadOnly = true;
            this.grcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodBarCode.ToolTipText = "Штрих-код товара";
            this.grcGoodBarCode.Width = 130;
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
            // grcPackingID
            // 
            this.grcPackingID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPackingID.DataPropertyName = "PackingID";
            this.grcPackingID.HeaderText = "PackingID";
            this.grcPackingID.Name = "grcPackingID";
            this.grcPackingID.ReadOnly = true;
            this.grcPackingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPackingID.Visible = false;
            // 
            // grcGoodStateID
            // 
            this.grcGoodStateID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodStateID.DataPropertyName = "GoodStateID";
            this.grcGoodStateID.HeaderText = "GoodStateID";
            this.grcGoodStateID.Name = "grcGoodStateID";
            this.grcGoodStateID.ReadOnly = true;
            this.grcGoodStateID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodStateID.Visible = false;
            // 
            // grcOwnerID
            // 
            this.grcOwnerID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOwnerID.DataPropertyName = "OwnerID";
            this.grcOwnerID.HeaderText = "OwnerID";
            this.grcOwnerID.Name = "grcOwnerID";
            this.grcOwnerID.ReadOnly = true;
            this.grcOwnerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcOwnerID.Visible = false;
            // 
            // frmReportOddmentsBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 473);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcList);
            this.hpHelp.SetHelpKeyword(this, "1024");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.LastGrid = this.grdData;
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmReportOddmentsBalance";
            this.hpHelp.SetShowHelp(this, true);
            this.Text = "Остатки и операции за период";
            this.Load += new System.EventHandler(this.frmReportOddmentsBalance_Load);
            this.tabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tabTerms.ResumeLayout(false);
            this.cntTerms.ResumeLayout(false);
            this.cntTerms.PerformLayout();
            this.opgMode.ResumeLayout(false);
            this.opgMode.PerformLayout();
            this.pnlGoodsStates.ResumeLayout(false);
            this.pnlGoodsStates.PerformLayout();
            this.opgActual.ResumeLayout(false);
            this.opgActual.PerformLayout();
            this.pnlPackings.ResumeLayout(false);
            this.pnlPackings.PerformLayout();
            this.pnlOwners.ResumeLayout(false);
            this.pnlOwners.PerformLayout();
            this.dtrDates.ResumeLayout(false);
            this.dtrDates.PerformLayout();
            this.tcList.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMButton btnPrint;
        private RFMBaseClasses.RFMButton btnDetail;
		private RFMBaseClasses.RFMContextMenuStrip mnuService;
		private RFMBaseClasses.RFMContextMenuStrip mnuPrint;
		private RFMBaseClasses.RFMTabPage tabData;
		private RFMBaseClasses.RFMTabPage tabTerms;
		private RFMBaseClasses.RFMButton btnClearTerms;
		private RFMBaseClasses.RFMLabel lblDates;
		private RFMBaseClasses.RFMTabControl tcList;
		private RFMBaseClasses.RFMPanel cntTerms;
		private RFMBaseClasses.RFMLabel lblGoodsStates;
		private RFMBaseClasses.RFMLabel lblOwners;
		private RFMBaseClasses.RFMLabel lblPackings;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMCheckBox chkGroupOwner;
        private RFMBaseClasses.RFMDateRange dtrDates;
		private RFMBaseClasses.RFMPanel pnlOwners;
		private RFMBaseClasses.RFMTextBox txtOwnersChoosen;
		private RFMBaseClasses.RFMButton btnOwnersClear;
		private RFMBaseClasses.RFMButton btnOwnersChoose;
		private RFMBaseClasses.RFMPanel pnlPackings;
		private RFMBaseClasses.RFMTextBox txtPackingsChoosen;
		private RFMBaseClasses.RFMButton btnPackingsClear;
		private RFMBaseClasses.RFMButton btnPackingsChoose;
		private RFMBaseClasses.RFMLabel lblGroupBy;
		private RFMBaseClasses.RFMPanel opgActual;
		private RFMBaseClasses.RFMRadioButton optGroupYes;
		private RFMBaseClasses.RFMRadioButton optGroupNo;
		private RFMBaseClasses.RFMLabel lblGroupYes;
		private RFMBaseClasses.RFMPanel pnlGoodsStates;
		private RFMBaseClasses.RFMTextBox txtGoodsStatesChoosen;
		private RFMBaseClasses.RFMButton btnGoodsStatesClear;
		private RFMBaseClasses.RFMButton btnGoodsStatesChoose;
        private RFMBaseClasses.RFMLabel lblMode;
        private RFMBaseClasses.RFMPanel opgMode;
        private RFMBaseClasses.RFMRadioButton optModePieces;
        private RFMBaseClasses.RFMRadioButton optModeBoxes;
        private RFMBaseClasses.RFMRadioButton optModePallets;
        private RFMBaseClasses.RFMRadioButton optModeNetto;
        private RFMBaseClasses.RFMDataGridViewImageColumn grcTypeImage;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntBeg;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntPlus;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntPlusAct;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntMinus;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntMinusAct;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntEnd;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQntInCells;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcSeparatePicking;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBrandName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBarCode;
        private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingID;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateID;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerID;
	}
}