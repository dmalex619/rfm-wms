namespace WMSSuitable
{
	partial class frmReportPickFreeRill
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabForFree = new RFMBaseClasses.RFMTabPage();
			this.cntGrids = new RFMBaseClasses.RFMSplitContainer();
			this.dgvGoods = new RFMBaseClasses.RFMDataGridView();
			this.dgvñGoodName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvñGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcMinQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcFreeQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvCells = new RFMBaseClasses.RFMDataGridView();
			this.tabTerms = new RFMBaseClasses.RFMTabPage();
			this.tcList = new RFMBaseClasses.RFMTabControl();
			this.btnPrint = new RFMBaseClasses.RFMButton();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnGo = new RFMBaseClasses.RFMButton();
			this.tmrRestore = new RFMBaseClasses.RFMTimer();
			this.dgvcAddressName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcMinDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcMaxDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcFree = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgvcMaxPalletQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.tabForFree.SuspendLayout();
			this.cntGrids.Panel1.SuspendLayout();
			this.cntGrids.Panel2.SuspendLayout();
			this.cntGrids.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCells)).BeginInit();
			this.tcList.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabForFree
			// 
			this.tabForFree.Controls.Add(this.cntGrids);
			this.tabForFree.Location = new System.Drawing.Point(4, 23);
			this.tabForFree.Name = "tabForFree";
			this.tabForFree.Size = new System.Drawing.Size(733, 403);
			this.tabForFree.TabIndex = 2;
			this.tabForFree.Text = "Òîâàðû-Ðó÷üè";
			this.tabForFree.UseVisualStyleBackColor = true;
			// 
			// cntGrids
			// 
			this.cntGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cntGrids.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.cntGrids.Location = new System.Drawing.Point(0, 2);
			this.cntGrids.Name = "cntGrids";
			this.cntGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// cntGrids.Panel1
			// 
			this.cntGrids.Panel1.Controls.Add(this.dgvGoods);
			// 
			// cntGrids.Panel2
			// 
			this.cntGrids.Panel2.Controls.Add(this.dgvCells);
			this.cntGrids.Size = new System.Drawing.Size(732, 400);
			this.cntGrids.SplitterDistance = 196;
			this.cntGrids.SplitterWidth = 2;
			this.cntGrids.TabIndex = 0;
			// 
			// dgvGoods
			// 
			this.dgvGoods.AllowUserToAddRows = false;
			this.dgvGoods.AllowUserToDeleteRows = false;
			this.dgvGoods.AllowUserToOrderColumns = true;
			this.dgvGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGoods.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvñGoodName,
            this.dgvcOwnerName,
            this.dgvñGoodStateName,
            this.dgvcMinQnt,
            this.dgvcFreeQnt});
			this.dgvGoods.IsConfigInclude = true;
			this.dgvGoods.IsMarkedAll = false;
			this.dgvGoods.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvGoods.Location = new System.Drawing.Point(1, 1);
			this.dgvGoods.MultiSelect = false;
			this.dgvGoods.Name = "dgvGoods";
			this.dgvGoods.RangedWay = ' ';
			this.dgvGoods.ReadOnly = true;
			this.dgvGoods.RowHeadersWidth = 24;
			this.dgvGoods.Size = new System.Drawing.Size(724, 190);
			this.dgvGoods.TabIndex = 0;
			this.dgvGoods.CurrentRowChanged += new RFMBaseClasses.RFMDataGridView.CurrentRowChangedEventHandler(this.dgvGoods_CurrentRowChanged);
			// 
			// dgvñGoodName
			// 
			this.dgvñGoodName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvñGoodName.DataPropertyName = "GName";
			this.dgvñGoodName.HeaderText = "Òîâàð";
			this.dgvñGoodName.Name = "dgvñGoodName";
			this.dgvñGoodName.ReadOnly = true;
			this.dgvñGoodName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvñGoodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dgvñGoodName.Width = 250;
			// 
			// dgvcOwnerName
			// 
			this.dgvcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcOwnerName.DataPropertyName = "OName";
			this.dgvcOwnerName.HeaderText = "Õðàíèòåëü";
			this.dgvcOwnerName.Name = "dgvcOwnerName";
			this.dgvcOwnerName.ReadOnly = true;
			this.dgvcOwnerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dgvcOwnerName.Width = 150;
			// 
			// dgvñGoodStateName
			// 
			this.dgvñGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvñGoodStateName.DataPropertyName = "GSName";
			this.dgvñGoodStateName.HeaderText = "Ñîñòîÿíèå òîâàðà";
			this.dgvñGoodStateName.Name = "dgvñGoodStateName";
			this.dgvñGoodStateName.ReadOnly = true;
			this.dgvñGoodStateName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvñGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dgvñGoodStateName.Width = 150;
			// 
			// dgvcMinQnt
			// 
			this.dgvcMinQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcMinQnt.DataPropertyName = "Qnt";
			dataGridViewCellStyle1.Format = "N0";
			this.dgvcMinQnt.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgvcMinQnt.HeaderText = "Ìèí êîë-âî";
			this.dgvcMinQnt.Name = "dgvcMinQnt";
			this.dgvcMinQnt.ReadOnly = true;
			this.dgvcMinQnt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcMinQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dgvcMinQnt.ToolTipText = "Ìèíèìàëüíîå  êîëè÷åñòâî êîíòåéíåðîâ â ÿ÷åéêå";
			this.dgvcMinQnt.Width = 80;
			// 
			// dgvcFreeQnt
			// 
			this.dgvcFreeQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcFreeQnt.DataPropertyName = "Free";
			dataGridViewCellStyle2.Format = "N0";
			this.dgvcFreeQnt.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvcFreeQnt.HeaderText = "Ñâîáîäíî";
			this.dgvcFreeQnt.Name = "dgvcFreeQnt";
			this.dgvcFreeQnt.ReadOnly = true;
			this.dgvcFreeQnt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcFreeQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dgvcFreeQnt.ToolTipText = "Êîëè÷åñòâî ñâîáîäíûõ ìåñò âî âñåõ ðó÷üÿõ ñ ýòèì òîâàðîì";
			this.dgvcFreeQnt.Width = 80;
			// 
			// dgvCells
			// 
			this.dgvCells.AllowUserToAddRows = false;
			this.dgvCells.AllowUserToDeleteRows = false;
			this.dgvCells.AllowUserToOrderColumns = true;
			this.dgvCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCells.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvCells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcAddressName,
            this.dgvcMinDateValid,
            this.dgvcMaxDateValid,
            this.dgvcQnt,
            this.dgvcFree,
            this.dgvcMaxPalletQnt});
			this.dgvCells.IsConfigInclude = true;
			this.dgvCells.IsMarkedAll = false;
			this.dgvCells.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvCells.Location = new System.Drawing.Point(2, 5);
			this.dgvCells.MultiSelect = false;
			this.dgvCells.Name = "dgvCells";
			this.dgvCells.RangedWay = ' ';
			this.dgvCells.ReadOnly = true;
			this.dgvCells.RowHeadersWidth = 24;
			this.dgvCells.Size = new System.Drawing.Size(726, 191);
			this.dgvCells.TabIndex = 2;
			// 
			// tabTerms
			// 
			this.tabTerms.Enabled = false;
			this.tabTerms.Location = new System.Drawing.Point(4, 23);
			this.tabTerms.Name = "tabTerms";
			this.tabTerms.Padding = new System.Windows.Forms.Padding(3);
			this.tabTerms.Size = new System.Drawing.Size(733, 403);
			this.tabTerms.TabIndex = 0;
			this.tabTerms.Text = "Óñëîâèÿ";
			this.tabTerms.UseVisualStyleBackColor = true;
			// 
			// tcList
			// 
			this.tcList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tcList.Controls.Add(this.tabTerms);
			this.tcList.Controls.Add(this.tabForFree);
			this.tcList.Location = new System.Drawing.Point(1, 1);
			this.tcList.Name = "tcList";
			this.tcList.SelectedIndex = 0;
			this.tcList.Size = new System.Drawing.Size(741, 430);
			this.tcList.TabIndex = 0;
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.Enabled = false;
			this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
			this.btnPrint.Location = new System.Drawing.Point(671, 439);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(30, 30);
			this.btnPrint.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.btnPrint, "Ïå÷àòü");
			this.btnPrint.UseVisualStyleBackColor = true;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(5, 439);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.btnHelp, "Ïîìîùü");
			this.btnHelp.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(705, 439);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 3;
			this.ttToolTip.SetToolTip(this.btnCancel, "Âûõîä");
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnGo.IsAccessOn = true;
			this.btnGo.Location = new System.Drawing.Point(635, 439);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(30, 30);
			this.btnGo.TabIndex = 9;
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// tmrRestore
			// 
			this.tmrRestore.Tick += new System.EventHandler(this.tmrRestore_Tick);
			// 
			// dgvcAddressName
			// 
			this.dgvcAddressName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcAddressName.DataPropertyName = "Address";
			this.dgvcAddressName.HeaderText = "ß÷åéêà";
			this.dgvcAddressName.Name = "dgvcAddressName";
			this.dgvcAddressName.ReadOnly = true;
			this.dgvcAddressName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcAddressName.Width = 120;
			// 
			// dgvcMinDateValid
			// 
			this.dgvcMinDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcMinDateValid.DataPropertyName = "MinDateValid";
			dataGridViewCellStyle3.Format = "dd.MM.yyyy";
			this.dgvcMinDateValid.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvcMinDateValid.HeaderText = "Ìèí ñðîê ãîäíîñòè";
			this.dgvcMinDateValid.Name = "dgvcMinDateValid";
			this.dgvcMinDateValid.ReadOnly = true;
			this.dgvcMinDateValid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcMinDateValid.Width = 125;
			// 
			// dgvcMaxDateValid
			// 
			this.dgvcMaxDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcMaxDateValid.DataPropertyName = "MAxDateValid";
			dataGridViewCellStyle4.Format = "dd.MM.yyyy";
			this.dgvcMaxDateValid.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvcMaxDateValid.HeaderText = "Ìàõ ñðîê ãîäíîñòè";
			this.dgvcMaxDateValid.Name = "dgvcMaxDateValid";
			this.dgvcMaxDateValid.ReadOnly = true;
			this.dgvcMaxDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcMaxDateValid.Width = 125;
			// 
			// dgvcQnt
			// 
			this.dgvcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcQnt.DataPropertyName = "Qnt";
			dataGridViewCellStyle5.Format = "N0";
			dataGridViewCellStyle5.NullValue = null;
			this.dgvcQnt.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgvcQnt.HeaderText = "Ïàëëåò";
			this.dgvcQnt.Name = "dgvcQnt";
			this.dgvcQnt.ReadOnly = true;
			this.dgvcQnt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dgvcFree
			// 
			this.dgvcFree.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcFree.DataPropertyName = "CellFree";
			dataGridViewCellStyle6.Format = "N0";
			dataGridViewCellStyle6.NullValue = null;
			this.dgvcFree.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgvcFree.HeaderText = "Ñâîáîäíî";
			this.dgvcFree.Name = "dgvcFree";
			this.dgvcFree.ReadOnly = true;
			this.dgvcFree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcFree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dgvcMaxPalletQnt
			// 
			this.dgvcMaxPalletQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcMaxPalletQnt.DataPropertyName = "MAxPalletQnt";
			dataGridViewCellStyle7.Format = "N0";
			dataGridViewCellStyle7.NullValue = null;
			this.dgvcMaxPalletQnt.DefaultCellStyle = dataGridViewCellStyle7;
			this.dgvcMaxPalletQnt.HeaderText = "Â ðó÷üå";
			this.dgvcMaxPalletQnt.Name = "dgvcMaxPalletQnt";
			this.dgvcMaxPalletQnt.ReadOnly = true;
			this.dgvcMaxPalletQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// frmReportPickFreeRill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 473);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tcList);
			this.hpHelp.SetHelpKeyword(this, "602");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsAccessOn = true;
			this.LastGrid = this.dgvGoods;
			this.MinimumSize = new System.Drawing.Size(750, 500);
			this.Name = "frmReportPickFreeRill";
			this.hpHelp.SetShowHelp(this, true);
			this.Text = "";
			this.Load += new System.EventHandler(this.frmReportPickFreeRill_Load);
			this.tabForFree.ResumeLayout(false);
			this.cntGrids.Panel1.ResumeLayout(false);
			this.cntGrids.Panel2.ResumeLayout(false);
			this.cntGrids.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCells)).EndInit();
			this.tcList.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMButton btnPrint;
		private RFMBaseClasses.RFMTabPage tabForFree;
		private RFMBaseClasses.RFMSplitContainer cntGrids;
        private RFMBaseClasses.RFMTabPage tabTerms;
		private RFMBaseClasses.RFMTabControl tcList;
		private RFMBaseClasses.RFMButton btnGo;
		private RFMBaseClasses.RFMTimer tmrRestore;
		private RFMBaseClasses.RFMDataGridView dgvGoods;
		private RFMBaseClasses.RFMDataGridView dgvCells;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvñGoodName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcOwnerName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvñGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcMinQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcFreeQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcAddressName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcMinDateValid;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcMaxDateValid;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcFree;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcMaxPalletQnt;
	}
}