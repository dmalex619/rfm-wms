namespace WMSSuitable
{
	partial class frmSelectOnePacking 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectOnePacking));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFilter = new RFMBaseClasses.RFMPanel();
            this.ucSelectRecordID_GoodsBrands = new RFMBaseClasses.RFMSelectRecordIDGrid();
            this.ucSelectRecordID_GoodsGroups = new RFMBaseClasses.RFMSelectRecordIDGrid();
            this.ucSelectRecordID_Hosts = new RFMBaseClasses.RFMSelectRecordIDGrid();
            this.lblHosts = new RFMBaseClasses.RFMLabel();
            this.txtArticul = new RFMBaseClasses.RFMTextBox();
            this.lblArticul = new RFMBaseClasses.RFMLabel();
            this.lblPackingBarCode = new RFMBaseClasses.RFMLabel();
            this.txtPackingBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
            this.lblGoodBarCode = new RFMBaseClasses.RFMLabel();
            this.chkPackingsActual = new RFMBaseClasses.RFMCheckBox();
            this.lblActual = new RFMBaseClasses.RFMLabel();
            this.chkGoodsActual = new RFMBaseClasses.RFMCheckBox();
            this.lblTreeWait = new RFMBaseClasses.RFMLabel();
            this.btnTree = new RFMBaseClasses.RFMButton();
            this.txtName = new RFMBaseClasses.RFMTextBox();
            this.lblName = new RFMBaseClasses.RFMLabel();
            this.txtGoodBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
            this.lblBarCode = new RFMBaseClasses.RFMLabel();
            this.btnClear = new RFMBaseClasses.RFMButton();
            this.btnFilter = new RFMBaseClasses.RFMButton();
            this.lblGoodsBrands = new RFMBaseClasses.RFMLabel();
            this.lblGoodsGroups = new RFMBaseClasses.RFMLabel();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.btnGo = new RFMBaseClasses.RFMButton();
            this.btnPrint = new RFMBaseClasses.RFMButton();
            this.cntData = new RFMBaseClasses.RFMSplitContainer();
            this.tvwGoods = new RFMBaseClasses.RFMTreeView();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcArticul = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcBoxInPal = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcNetto = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxInRow = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPalletTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcRetention = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcTemperatureMode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPickingList = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcPackingActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
            this.grcGoodName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPackingBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPackingID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcPackingErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.pnlFilter.SuspendLayout();
            this.ucSelectRecordID_GoodsBrands.SuspendLayout();
            this.ucSelectRecordID_GoodsGroups.SuspendLayout();
            this.ucSelectRecordID_Hosts.SuspendLayout();
            this.cntData.Panel1.SuspendLayout();
            this.cntData.Panel2.SuspendLayout();
            this.cntData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFilter.Controls.Add(this.ucSelectRecordID_GoodsBrands);
            this.pnlFilter.Controls.Add(this.ucSelectRecordID_GoodsGroups);
            this.pnlFilter.Controls.Add(this.ucSelectRecordID_Hosts);
            this.pnlFilter.Controls.Add(this.lblHosts);
            this.pnlFilter.Controls.Add(this.txtArticul);
            this.pnlFilter.Controls.Add(this.lblArticul);
            this.pnlFilter.Controls.Add(this.lblPackingBarCode);
            this.pnlFilter.Controls.Add(this.txtPackingBarCode);
            this.pnlFilter.Controls.Add(this.lblGoodBarCode);
            this.pnlFilter.Controls.Add(this.chkPackingsActual);
            this.pnlFilter.Controls.Add(this.lblActual);
            this.pnlFilter.Controls.Add(this.chkGoodsActual);
            this.pnlFilter.Controls.Add(this.lblTreeWait);
            this.pnlFilter.Controls.Add(this.btnTree);
            this.pnlFilter.Controls.Add(this.txtName);
            this.pnlFilter.Controls.Add(this.lblName);
            this.pnlFilter.Controls.Add(this.txtGoodBarCode);
            this.pnlFilter.Controls.Add(this.lblBarCode);
            this.pnlFilter.Controls.Add(this.btnClear);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.lblGoodsBrands);
            this.pnlFilter.Controls.Add(this.lblGoodsGroups);
            this.pnlFilter.Location = new System.Drawing.Point(2, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(688, 161);
            this.pnlFilter.TabIndex = 2;
            // 
            // ucSelectRecordID_GoodsBrands
            // 
            this.ucSelectRecordID_GoodsBrands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ucSelectRecordID_GoodsBrands.btnClear
            // 
            this.ucSelectRecordID_GoodsBrands.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_GoodsBrands.BtnClear.Image = ((System.Drawing.Image)(resources.GetObject("ucSelectRecordID_GoodsBrands.btnClear.Image")));
            this.ucSelectRecordID_GoodsBrands.BtnClear.Location = new System.Drawing.Point(482, 0);
            this.ucSelectRecordID_GoodsBrands.BtnClear.Name = "btnClear";
            this.ucSelectRecordID_GoodsBrands.BtnClear.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_GoodsBrands.BtnClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_GoodsBrands.BtnClear, "Очистка выбора товарных брендов");
            this.ucSelectRecordID_GoodsBrands.BtnClear.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_GoodsBrands.btnSelect
            // 
            this.ucSelectRecordID_GoodsBrands.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_GoodsBrands.BtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("ucSelectRecordID_GoodsBrands.btnSelect.Image")));
            this.ucSelectRecordID_GoodsBrands.BtnSelect.Location = new System.Drawing.Point(456, 0);
            this.ucSelectRecordID_GoodsBrands.BtnSelect.Name = "btnSelect";
            this.ucSelectRecordID_GoodsBrands.BtnSelect.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_GoodsBrands.BtnSelect.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_GoodsBrands.BtnSelect, "Выбор товарных брендов");
            this.ucSelectRecordID_GoodsBrands.BtnSelect.UseVisualStyleBackColor = true;
            this.ucSelectRecordID_GoodsBrands.ExpSort = "Name";
            this.ucSelectRecordID_GoodsBrands.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ucSelectRecordID_GoodsBrands.IsActualOnly = true;
            this.ucSelectRecordID_GoodsBrands.IsSaveMark = true;
            this.ucSelectRecordID_GoodsBrands.IsUseMark = true;
            this.ucSelectRecordID_GoodsBrands.Location = new System.Drawing.Point(176, 26);
            this.ucSelectRecordID_GoodsBrands.MarkedCount = 0;
            this.ucSelectRecordID_GoodsBrands.Name = "ucSelectRecordID_GoodsBrands";
            this.ucSelectRecordID_GoodsBrands.Size = new System.Drawing.Size(509, 24);
            this.ucSelectRecordID_GoodsBrands.TabIndex = 3;
            this.ucSelectRecordID_GoodsBrands.TableColumnName = "Name";
            // 
            // ucSelectRecordID_GoodsBrands.txtData
            // 
            this.ucSelectRecordID_GoodsBrands.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_GoodsBrands.TxtData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.ucSelectRecordID_GoodsBrands.TxtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.ucSelectRecordID_GoodsBrands.TxtData.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucSelectRecordID_GoodsBrands.TxtData.IsUserDraw = true;
            this.ucSelectRecordID_GoodsBrands.TxtData.Location = new System.Drawing.Point(0, 1);
            this.ucSelectRecordID_GoodsBrands.TxtData.MaxLength = 128;
            this.ucSelectRecordID_GoodsBrands.TxtData.Name = "txtData";
            this.ucSelectRecordID_GoodsBrands.TxtData.ReadOnly = true;
            this.ucSelectRecordID_GoodsBrands.TxtData.Size = new System.Drawing.Size(454, 22);
            this.ucSelectRecordID_GoodsBrands.TxtData.TabIndex = 0;
            this.ucSelectRecordID_GoodsBrands.СolumnsData.AddRange(new string[] {
            "Name, Товарный бренд"});
            // 
            // ucSelectRecordID_GoodsGroups
            // 
            this.ucSelectRecordID_GoodsGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ucSelectRecordID_GoodsGroups.btnClear
            // 
            this.ucSelectRecordID_GoodsGroups.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_GoodsGroups.BtnClear.Image = ((System.Drawing.Image)(resources.GetObject("ucSelectRecordID_GoodsGroups.btnClear.Image")));
            this.ucSelectRecordID_GoodsGroups.BtnClear.Location = new System.Drawing.Point(482, 0);
            this.ucSelectRecordID_GoodsGroups.BtnClear.Name = "btnClear";
            this.ucSelectRecordID_GoodsGroups.BtnClear.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_GoodsGroups.BtnClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_GoodsGroups.BtnClear, "Очистка выбора товарных групп");
            this.ucSelectRecordID_GoodsGroups.BtnClear.UseVisualStyleBackColor = true;
            // 
            // ucSelectRecordID_GoodsGroups.btnSelect
            // 
            this.ucSelectRecordID_GoodsGroups.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_GoodsGroups.BtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("ucSelectRecordID_GoodsGroups.btnSelect.Image")));
            this.ucSelectRecordID_GoodsGroups.BtnSelect.Location = new System.Drawing.Point(456, 0);
            this.ucSelectRecordID_GoodsGroups.BtnSelect.Name = "btnSelect";
            this.ucSelectRecordID_GoodsGroups.BtnSelect.Size = new System.Drawing.Size(24, 24);
            this.ucSelectRecordID_GoodsGroups.BtnSelect.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.ucSelectRecordID_GoodsGroups.BtnSelect, "Выбор товарных групп");
            this.ucSelectRecordID_GoodsGroups.BtnSelect.UseVisualStyleBackColor = true;
            this.ucSelectRecordID_GoodsGroups.ExpSort = "Name";
            this.ucSelectRecordID_GoodsGroups.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ucSelectRecordID_GoodsGroups.IsActualOnly = true;
            this.ucSelectRecordID_GoodsGroups.IsSaveMark = true;
            this.ucSelectRecordID_GoodsGroups.IsUseMark = true;
            this.ucSelectRecordID_GoodsGroups.Location = new System.Drawing.Point(176, 2);
            this.ucSelectRecordID_GoodsGroups.MarkedCount = 0;
            this.ucSelectRecordID_GoodsGroups.Name = "ucSelectRecordID_GoodsGroups";
            this.ucSelectRecordID_GoodsGroups.Size = new System.Drawing.Size(508, 24);
            this.ucSelectRecordID_GoodsGroups.TabIndex = 1;
            this.ucSelectRecordID_GoodsGroups.TableColumnName = "Name";
            // 
            // ucSelectRecordID_GoodsGroups.txtData
            // 
            this.ucSelectRecordID_GoodsGroups.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_GoodsGroups.TxtData.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.ucSelectRecordID_GoodsGroups.TxtData.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.ucSelectRecordID_GoodsGroups.TxtData.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucSelectRecordID_GoodsGroups.TxtData.IsUserDraw = true;
            this.ucSelectRecordID_GoodsGroups.TxtData.Location = new System.Drawing.Point(0, 1);
            this.ucSelectRecordID_GoodsGroups.TxtData.MaxLength = 128;
            this.ucSelectRecordID_GoodsGroups.TxtData.Name = "txtData";
            this.ucSelectRecordID_GoodsGroups.TxtData.ReadOnly = true;
            this.ucSelectRecordID_GoodsGroups.TxtData.Size = new System.Drawing.Size(454, 22);
            this.ucSelectRecordID_GoodsGroups.TxtData.TabIndex = 0;
            this.ucSelectRecordID_GoodsGroups.СolumnsData.AddRange(new string[] {
            "Name, Товарная группа"});
            // 
            // ucSelectRecordID_Hosts
            // 
            this.ucSelectRecordID_Hosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ucSelectRecordID_Hosts.btnClear
            // 
            this.ucSelectRecordID_Hosts.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSelectRecordID_Hosts.BtnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.ucSelectRecordID_Hosts.BtnClear.Location = new System.Drawing.Point(244, 0);
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
            this.ucSelectRecordID_Hosts.BtnSelect.Location = new System.Drawing.Point(218, 0);
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
            this.ucSelectRecordID_Hosts.Location = new System.Drawing.Point(414, 98);
            this.ucSelectRecordID_Hosts.MarkedCount = 0;
            this.ucSelectRecordID_Hosts.Name = "ucSelectRecordID_Hosts";
            this.ucSelectRecordID_Hosts.Size = new System.Drawing.Size(271, 24);
            this.ucSelectRecordID_Hosts.TabIndex = 17;
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
            this.ucSelectRecordID_Hosts.TxtData.Size = new System.Drawing.Size(216, 22);
            this.ucSelectRecordID_Hosts.TxtData.TabIndex = 0;
            this.ucSelectRecordID_Hosts.СolumnsData.AddRange(new string[] {
            "Name, Хост"});
            // 
            // lblHosts
            // 
            this.lblHosts.AutoSize = true;
            this.lblHosts.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblHosts.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblHosts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHosts.Location = new System.Drawing.Point(380, 103);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(33, 14);
            this.lblHosts.TabIndex = 16;
            this.lblHosts.Text = "Хост";
            // 
            // txtArticul
            // 
            this.txtArticul.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtArticul.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArticul.Location = new System.Drawing.Point(176, 99);
            this.txtArticul.Name = "txtArticul";
            this.txtArticul.Size = new System.Drawing.Size(172, 22);
            this.txtArticul.TabIndex = 12;
            this.ttToolTip.SetToolTip(this.txtArticul, "Название товара (контекст)");
            // 
            // lblArticul
            // 
            this.lblArticul.AutoSize = true;
            this.lblArticul.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblArticul.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblArticul.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArticul.Location = new System.Drawing.Point(4, 103);
            this.lblArticul.Name = "lblArticul";
            this.lblArticul.Size = new System.Drawing.Size(119, 14);
            this.lblArticul.TabIndex = 11;
            this.lblArticul.Text = "Артикул (контекст)";
            // 
            // lblPackingBarCode
            // 
            this.lblPackingBarCode.AutoSize = true;
            this.lblPackingBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblPackingBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPackingBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPackingBarCode.Location = new System.Drawing.Point(356, 78);
            this.lblPackingBarCode.Name = "lblPackingBarCode";
            this.lblPackingBarCode.Size = new System.Drawing.Size(57, 14);
            this.lblPackingBarCode.TabIndex = 9;
            this.lblPackingBarCode.Text = "упаковка";
            // 
            // txtPackingBarCode
            // 
            this.txtPackingBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtPackingBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPackingBarCode.Location = new System.Drawing.Point(414, 75);
            this.txtPackingBarCode.MaxLength = 20;
            this.txtPackingBarCode.Name = "txtPackingBarCode";
            this.txtPackingBarCode.Size = new System.Drawing.Size(172, 22);
            this.txtPackingBarCode.TabIndex = 10;
            this.ttToolTip.SetToolTip(this.txtPackingBarCode, "Штрих-код упаковки");
            // 
            // lblGoodBarCode
            // 
            this.lblGoodBarCode.AutoSize = true;
            this.lblGoodBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodBarCode.Location = new System.Drawing.Point(137, 78);
            this.lblGoodBarCode.Name = "lblGoodBarCode";
            this.lblGoodBarCode.Size = new System.Drawing.Size(39, 14);
            this.lblGoodBarCode.TabIndex = 7;
            this.lblGoodBarCode.Text = "товар";
            // 
            // chkPackingsActual
            // 
            this.chkPackingsActual.AutoSize = true;
            this.chkPackingsActual.Checked = true;
            this.chkPackingsActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPackingsActual.IsChanged = true;
            this.chkPackingsActual.Location = new System.Drawing.Point(269, 125);
            this.chkPackingsActual.Name = "chkPackingsActual";
            this.chkPackingsActual.Size = new System.Drawing.Size(77, 18);
            this.chkPackingsActual.TabIndex = 15;
            this.chkPackingsActual.Text = "упаковки";
            this.chkPackingsActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkPackingsActual.UseVisualStyleBackColor = true;
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblActual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblActual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblActual.Location = new System.Drawing.Point(4, 126);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(121, 14);
            this.lblActual.TabIndex = 13;
            this.lblActual.Text = "Только актуальные:";
            // 
            // chkGoodsActual
            // 
            this.chkGoodsActual.AutoSize = true;
            this.chkGoodsActual.Checked = true;
            this.chkGoodsActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGoodsActual.IsChanged = true;
            this.chkGoodsActual.Location = new System.Drawing.Point(176, 125);
            this.chkGoodsActual.Name = "chkGoodsActual";
            this.chkGoodsActual.Size = new System.Drawing.Size(66, 18);
            this.chkGoodsActual.TabIndex = 14;
            this.chkGoodsActual.Text = "товары";
            this.chkGoodsActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkGoodsActual.UseVisualStyleBackColor = true;
            this.chkGoodsActual.CheckedChanged += new System.EventHandler(this.chkGoodsActual_CheckedChanged);
            // 
            // lblTreeWait
            // 
            this.lblTreeWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTreeWait.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblTreeWait.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTreeWait.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTreeWait.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTreeWait.Location = new System.Drawing.Point(346, 138);
            this.lblTreeWait.Name = "lblTreeWait";
            this.lblTreeWait.Size = new System.Drawing.Size(198, 17);
            this.lblTreeWait.TabIndex = 18;
            this.lblTreeWait.Text = "Ждите, идет загрузка данных...";
            this.lblTreeWait.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTreeWait.Visible = false;
            // 
            // btnTree
            // 
            this.btnTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTree.Image = global::WMSSuitable.Properties.Resources.Tree;
            this.btnTree.Location = new System.Drawing.Point(552, 125);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(30, 30);
            this.btnTree.TabIndex = 19;
            this.ttToolTip.SetToolTip(this.btnTree, "Показать дерево товаров");
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // txtName
            // 
            this.txtName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(176, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(506, 22);
            this.txtName.TabIndex = 5;
            this.ttToolTip.SetToolTip(this.txtName, "Название товара (контекст)");
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Location = new System.Drawing.Point(4, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(166, 14);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Название товара (контекст)";
            // 
            // txtGoodBarCode
            // 
            this.txtGoodBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtGoodBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGoodBarCode.Location = new System.Drawing.Point(176, 75);
            this.txtGoodBarCode.MaxLength = 20;
            this.txtGoodBarCode.Name = "txtGoodBarCode";
            this.txtGoodBarCode.Size = new System.Drawing.Size(172, 22);
            this.txtGoodBarCode.TabIndex = 8;
            this.ttToolTip.SetToolTip(this.txtGoodBarCode, "Штрих-код товара");
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBarCode.Location = new System.Drawing.Point(4, 78);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(136, 14);
            this.lblBarCode.TabIndex = 6;
            this.lblBarCode.Text = "Штрих-код (контекст):";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
            this.btnClear.Location = new System.Drawing.Point(652, 125);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 30);
            this.btnClear.TabIndex = 21;
            this.ttToolTip.SetToolTip(this.btnClear, "Очистить условия");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnFilter.Location = new System.Drawing.Point(602, 125);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(30, 30);
            this.btnFilter.TabIndex = 20;
            this.ttToolTip.SetToolTip(this.btnFilter, "Показать товары, соответствующие условиям (<F5>)");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblGoodsBrands
            // 
            this.lblGoodsBrands.AutoSize = true;
            this.lblGoodsBrands.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodsBrands.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodsBrands.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodsBrands.Location = new System.Drawing.Point(4, 30);
            this.lblGoodsBrands.Name = "lblGoodsBrands";
            this.lblGoodsBrands.Size = new System.Drawing.Size(50, 14);
            this.lblGoodsBrands.TabIndex = 2;
            this.lblGoodsBrands.Text = "Бренды";
            // 
            // lblGoodsGroups
            // 
            this.lblGoodsGroups.AutoSize = true;
            this.lblGoodsGroups.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodsGroups.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodsGroups.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodsGroups.Location = new System.Drawing.Point(4, 6);
            this.lblGoodsGroups.Name = "lblGoodsGroups";
            this.lblGoodsGroups.Size = new System.Drawing.Size(107, 14);
            this.lblGoodsGroups.TabIndex = 0;
            this.lblGoodsGroups.Text = "Товарные группы";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(5, 388);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 8;
            this.ttToolTip.SetToolTip(this.btnHelp, "Помощь");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(657, 389);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnExit, "Выход");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
            this.btnGo.Location = new System.Drawing.Point(607, 389);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 30);
            this.btnGo.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.btnGo, "Выбор");
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
            this.btnPrint.Location = new System.Drawing.Point(557, 389);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 3;
            this.ttToolTip.SetToolTip(this.btnPrint, "Печать");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cntData
            // 
            this.cntData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cntData.Location = new System.Drawing.Point(2, 165);
            this.cntData.Name = "cntData";
            // 
            // cntData.Panel1
            // 
            this.cntData.Panel1.Controls.Add(this.tvwGoods);
            this.cntData.Panel1MinSize = 0;
            // 
            // cntData.Panel2
            // 
            this.cntData.Panel2.Controls.Add(this.grdData);
            this.cntData.Panel2MinSize = 0;
            this.cntData.Size = new System.Drawing.Size(688, 219);
            this.cntData.SplitterDistance = 53;
            this.cntData.SplitterWidth = 2;
            this.cntData.TabIndex = 11;
            // 
            // tvwGoods
            // 
            this.tvwGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwGoods.CheckBoxes = true;
            this.tvwGoods.FullRowSelect = true;
            this.tvwGoods.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1)),
        ((object)(((byte)(0))))};
            this.tvwGoods.Location = new System.Drawing.Point(0, 0);
            this.tvwGoods.Name = "tvwGoods";
            this.tvwGoods.Size = new System.Drawing.Size(53, 219);
            this.tvwGoods.TabIndex = 0;
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
            this.grcGoodAlias,
            this.grcArticul,
            this.grcGoodBarCode,
            this.grcInBox,
            this.grcWeighting,
            this.grcBoxInPal,
            this.grcNetto,
            this.grcBoxInRow,
            this.grcPalletTypeName,
            this.grcGoodGroupName,
            this.grcGoodBrandName,
            this.grcRetention,
            this.grcTemperatureMode,
            this.grcPickingList,
            this.grcGoodActual,
            this.grcPackingActual,
            this.grcGoodName,
            this.grcAddress,
            this.grcStoreZoneName,
            this.grcPackingBarCode,
            this.grcGoodID,
            this.grcPackingID,
            this.grcGoodErpCode,
            this.grcPackingErpCode});
            this.grdData.IdTableColumnName = "PackingID";
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
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
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(633, 219);
            this.grdData.TabIndex = 1;
            this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
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
            // grcArticul
            // 
            this.grcArticul.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcArticul.DataPropertyName = "Articul";
            this.grcArticul.HeaderText = "Артикул";
            this.grcArticul.Name = "grcArticul";
            this.grcArticul.ReadOnly = true;
            this.grcArticul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcGoodBarCode
            // 
            this.grcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodBarCode.DataPropertyName = "GoodBarCode";
            this.grcGoodBarCode.HeaderText = "Штрих-код Товар";
            this.grcGoodBarCode.Name = "grcGoodBarCode";
            this.grcGoodBarCode.ReadOnly = true;
            this.grcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodBarCode.ToolTipText = "Штрих-код товара";
            this.grcGoodBarCode.Width = 120;
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
            this.grcInBox.Width = 60;
            // 
            // grcWeighting
            // 
            this.grcWeighting.DataPropertyName = "Weighting";
            this.grcWeighting.HeaderText = "Вес?";
            this.grcWeighting.Name = "grcWeighting";
            this.grcWeighting.ReadOnly = true;
            this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcWeighting.ToolTipText = "Весовой товар?";
            this.grcWeighting.Width = 40;
            // 
            // grcBoxInPal
            // 
            this.grcBoxInPal.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxInPal.DataPropertyName = "BoxInPal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.grcBoxInPal.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcBoxInPal.HeaderText = "Кор. на пал.";
            this.grcBoxInPal.Name = "grcBoxInPal";
            this.grcBoxInPal.ReadOnly = true;
            this.grcBoxInPal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxInPal.ToolTipText = "Коробок на паллете";
            this.grcBoxInPal.Width = 60;
            // 
            // grcNetto
            // 
            this.grcNetto.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcNetto.DataPropertyName = "Netto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            this.grcNetto.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcNetto.HeaderText = "Нетто, кг";
            this.grcNetto.Name = "grcNetto";
            this.grcNetto.ReadOnly = true;
            this.grcNetto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcNetto.Width = 80;
            // 
            // grcBoxInRow
            // 
            this.grcBoxInRow.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxInRow.DataPropertyName = "BoxInRow";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.grcBoxInRow.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcBoxInRow.HeaderText = "Кор. в ряде";
            this.grcBoxInRow.Name = "grcBoxInRow";
            this.grcBoxInRow.ReadOnly = true;
            this.grcBoxInRow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxInRow.ToolTipText = "Коробок в ряде";
            this.grcBoxInRow.Width = 60;
            // 
            // grcPalletTypeName
            // 
            this.grcPalletTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPalletTypeName.DataPropertyName = "PalletTypeName";
            this.grcPalletTypeName.HeaderText = "Тип поддона";
            this.grcPalletTypeName.Name = "grcPalletTypeName";
            this.grcPalletTypeName.ReadOnly = true;
            this.grcPalletTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPalletTypeName.ToolTipText = "Тип поддона";
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
            this.grcGoodBrandName.Width = 200;
            // 
            // grcRetention
            // 
            this.grcRetention.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcRetention.DataPropertyName = "Retention";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcRetention.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcRetention.HeaderText = "Срок годн.";
            this.grcRetention.Name = "grcRetention";
            this.grcRetention.ReadOnly = true;
            this.grcRetention.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcRetention.ToolTipText = "Срок годности, дней";
            this.grcRetention.Width = 70;
            // 
            // grcTemperatureMode
            // 
            this.grcTemperatureMode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcTemperatureMode.DataPropertyName = "TemperatureMode";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grcTemperatureMode.DefaultCellStyle = dataGridViewCellStyle7;
            this.grcTemperatureMode.HeaderText = "Т";
            this.grcTemperatureMode.Name = "grcTemperatureMode";
            this.grcTemperatureMode.ReadOnly = true;
            this.grcTemperatureMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcTemperatureMode.ToolTipText = "Температурный режим";
            this.grcTemperatureMode.Width = 25;
            // 
            // grcPickingList
            // 
            this.grcPickingList.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPickingList.DataPropertyName = "PickingList";
            this.grcPickingList.HeaderText = "Пикинг";
            this.grcPickingList.Name = "grcPickingList";
            this.grcPickingList.ReadOnly = true;
            this.grcPickingList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPickingList.ToolTipText = "Адрес ячейки пикинга (хранитель)";
            // 
            // grcGoodActual
            // 
            this.grcGoodActual.DataPropertyName = "GoodActual";
            this.grcGoodActual.HeaderText = "Акт. Товар";
            this.grcGoodActual.Name = "grcGoodActual";
            this.grcGoodActual.ReadOnly = true;
            this.grcGoodActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodActual.ToolTipText = "Товар актуален?";
            this.grcGoodActual.Width = 50;
            // 
            // grcPackingActual
            // 
            this.grcPackingActual.DataPropertyName = "PackingActual";
            this.grcPackingActual.HeaderText = "Акт. Упаковка";
            this.grcPackingActual.Name = "grcPackingActual";
            this.grcPackingActual.ReadOnly = true;
            this.grcPackingActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPackingActual.ToolTipText = "Упаковка актуальна?";
            this.grcPackingActual.Width = 50;
            // 
            // grcGoodName
            // 
            this.grcGoodName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodName.DataPropertyName = "GoodName";
            this.grcGoodName.HeaderText = "Товар (полное название)";
            this.grcGoodName.Name = "grcGoodName";
            this.grcGoodName.ReadOnly = true;
            this.grcGoodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodName.Width = 250;
            // 
            // grcAddress
            // 
            this.grcAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcAddress.DataPropertyName = "Address";
            this.grcAddress.HeaderText = "Адрес";
            this.grcAddress.Name = "grcAddress";
            this.grcAddress.ReadOnly = true;
            this.grcAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcAddress.ToolTipText = "Адрес ячейки пикинга";
            this.grcAddress.Visible = false;
            this.grcAddress.Width = 80;
            // 
            // grcStoreZoneName
            // 
            this.grcStoreZoneName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcStoreZoneName.DataPropertyName = "StoreZoneName";
            this.grcStoreZoneName.HeaderText = "Зона";
            this.grcStoreZoneName.Name = "grcStoreZoneName";
            this.grcStoreZoneName.ReadOnly = true;
            this.grcStoreZoneName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcStoreZoneName.ToolTipText = "Зона пикинга";
            this.grcStoreZoneName.Visible = false;
            // 
            // grcPackingBarCode
            // 
            this.grcPackingBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPackingBarCode.DataPropertyName = "PackingBarCode";
            this.grcPackingBarCode.HeaderText = "Штрих-код Упаковка";
            this.grcPackingBarCode.Name = "grcPackingBarCode";
            this.grcPackingBarCode.ReadOnly = true;
            this.grcPackingBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPackingBarCode.ToolTipText = "Штрих-код упаковки";
            this.grcPackingBarCode.Width = 120;
            // 
            // grcGoodID
            // 
            this.grcGoodID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodID.DataPropertyName = "GoodID";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcGoodID.DefaultCellStyle = dataGridViewCellStyle8;
            this.grcGoodID.HeaderText = "ID товара";
            this.grcGoodID.Name = "grcGoodID";
            this.grcGoodID.ReadOnly = true;
            this.grcGoodID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodID.ToolTipText = "Код товара (GoodID)";
            this.grcGoodID.Width = 60;
            // 
            // grcPackingID
            // 
            this.grcPackingID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPackingID.DataPropertyName = "PackingID";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.grcPackingID.DefaultCellStyle = dataGridViewCellStyle9;
            this.grcPackingID.HeaderText = "ID упаковки";
            this.grcPackingID.Name = "grcPackingID";
            this.grcPackingID.ReadOnly = true;
            this.grcPackingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPackingID.ToolTipText = "Код упаковки (PackingID)";
            this.grcPackingID.Width = 60;
            // 
            // grcGoodErpCode
            // 
            this.grcGoodErpCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodErpCode.DataPropertyName = "GoodErpCode";
            this.grcGoodErpCode.HeaderText = "ErpCode товара";
            this.grcGoodErpCode.Name = "grcGoodErpCode";
            this.grcGoodErpCode.ReadOnly = true;
            this.grcGoodErpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodErpCode.ToolTipText = "Код товара в учетной системе";
            // 
            // grcPackingErpCode
            // 
            this.grcPackingErpCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcPackingErpCode.DataPropertyName = "PackingErpCode";
            this.grcPackingErpCode.HeaderText = "ErpCode упаковки";
            this.grcPackingErpCode.Name = "grcPackingErpCode";
            this.grcPackingErpCode.ReadOnly = true;
            this.grcPackingErpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcPackingErpCode.ToolTipText = "Код упаковки в учетной системе";
            // 
            // frmSelectOnePacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 423);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cntData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.pnlFilter);
            this.hpHelp.SetHelpKeyword(this, "1001");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "frmSelectOnePacking";
            this.hpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Выбор товара/упаковки";
            this.Load += new System.EventHandler(this.frmSelectOnePacking_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSelectOnePacking_KeyDown);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ucSelectRecordID_GoodsBrands.ResumeLayout(false);
            this.ucSelectRecordID_GoodsBrands.PerformLayout();
            this.ucSelectRecordID_GoodsGroups.ResumeLayout(false);
            this.ucSelectRecordID_GoodsGroups.PerformLayout();
            this.ucSelectRecordID_Hosts.ResumeLayout(false);
            this.ucSelectRecordID_Hosts.PerformLayout();
            this.cntData.Panel1.ResumeLayout(false);
            this.cntData.Panel2.ResumeLayout(false);
            this.cntData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMPanel pnlFilter;
        private RFMBaseClasses.RFMLabel lblGoodsBrands;
		private RFMBaseClasses.RFMLabel lblGoodsGroups;
		private RFMBaseClasses.RFMButton btnFilter;
        private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnGo;
        private RFMBaseClasses.RFMTextBoxBarCode txtGoodBarCode;
		private RFMBaseClasses.RFMLabel lblBarCode;
		private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMTextBox txtName;
        private RFMBaseClasses.RFMLabel lblName;
		private RFMBaseClasses.RFMSplitContainer cntData;
		private RFMBaseClasses.RFMTreeView tvwGoods;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMButton btnTree;
		private RFMBaseClasses.RFMLabel lblTreeWait;
		private RFMBaseClasses.RFMCheckBox chkPackingsActual;
		private RFMBaseClasses.RFMLabel lblActual;
		private RFMBaseClasses.RFMCheckBox chkGoodsActual;
		private RFMBaseClasses.RFMLabel lblPackingBarCode;
		private RFMBaseClasses.RFMTextBoxBarCode txtPackingBarCode;
		private RFMBaseClasses.RFMLabel lblGoodBarCode;
        private RFMBaseClasses.RFMButton btnPrint;
		private RFMBaseClasses.RFMTextBox txtArticul;
		private RFMBaseClasses.RFMLabel lblArticul;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcArticul;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxInPal;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNetto;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxInRow;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalletTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodBrandName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcRetention;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcTemperatureMode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPickingList;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcGoodActual;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcPackingActual;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodErpCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingErpCode;
		private RFMBaseClasses.RFMSelectRecordIDGrid ucSelectRecordID_Hosts;
		private RFMBaseClasses.RFMLabel lblHosts;
		private RFMBaseClasses.RFMButton btnClear;
		private RFMBaseClasses.RFMSelectRecordIDGrid ucSelectRecordID_GoodsGroups;
		private RFMBaseClasses.RFMSelectRecordIDGrid ucSelectRecordID_GoodsBrands;

	}
}