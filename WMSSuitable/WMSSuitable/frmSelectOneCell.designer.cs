namespace WMSSuitable
{
	partial class frmSelectOneCell 
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlFilter = new RFMBaseClasses.RFMPanel();
			this.cboCPlace = new RFMBaseClasses.RFMComboBox();
			this.cboCLevel = new RFMBaseClasses.RFMComboBox();
			this.cboCRack = new RFMBaseClasses.RFMComboBox();
			this.cboCLine = new RFMBaseClasses.RFMComboBox();
			this.lblCBuilding = new RFMBaseClasses.RFMLabel();
			this.cboCBuilding = new RFMBaseClasses.RFMComboBox();
			this.lblCLine = new RFMBaseClasses.RFMLabel();
			this.lblCPlace = new RFMBaseClasses.RFMLabel();
			this.lblCRack = new RFMBaseClasses.RFMLabel();
			this.lblCLevel = new RFMBaseClasses.RFMLabel();
			this.txtStoresZonesChoosen = new RFMBaseClasses.RFMTextBox();
			this.btnStorezZonesChoose = new RFMBaseClasses.RFMButton();
			this.lblActual = new RFMBaseClasses.RFMLabel();
			this.chkCellsActual = new RFMBaseClasses.RFMCheckBox();
			this.txtCellBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.lblTreeWait = new RFMBaseClasses.RFMLabel();
			this.btnTree = new RFMBaseClasses.RFMButton();
			this.lblCellBarCode = new RFMBaseClasses.RFMLabel();
			this.btnClear = new RFMBaseClasses.RFMButton();
			this.btnFilter = new RFMBaseClasses.RFMButton();
			this.txtCellAddress = new RFMBaseClasses.RFMTextBox();
			this.lblCellAddress = new RFMBaseClasses.RFMLabel();
			this.lblStoreZone = new RFMBaseClasses.RFMLabel();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.btnGo = new RFMBaseClasses.RFMButton();
			this.cntData = new RFMBaseClasses.RFMSplitContainer();
			this.tvwCells = new RFMBaseClasses.RFMTreeView();
			this.grdData = new RFMBaseClasses.RFMDataGridView();
			this.grcCellStateImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcLockedImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcId = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcFixedOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcFixedGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcFixedPackingAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcState = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcActual = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcCBuilding = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCLine = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCRack = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCLevel = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCPlace = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcMaxWeight = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellWidth = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellHeight = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPalletTypeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcTemperatureMode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcLocked = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcBufferAddress = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcErpCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcHasCellContent = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcMaxPalletQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcStoreZoneMaxPalletQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcForFrames = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcIsForFrames = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.pnlFilter.SuspendLayout();
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
			this.pnlFilter.Controls.Add(this.cboCPlace);
			this.pnlFilter.Controls.Add(this.cboCLevel);
			this.pnlFilter.Controls.Add(this.cboCRack);
			this.pnlFilter.Controls.Add(this.cboCLine);
			this.pnlFilter.Controls.Add(this.lblCBuilding);
			this.pnlFilter.Controls.Add(this.cboCBuilding);
			this.pnlFilter.Controls.Add(this.lblCLine);
			this.pnlFilter.Controls.Add(this.lblCPlace);
			this.pnlFilter.Controls.Add(this.lblCRack);
			this.pnlFilter.Controls.Add(this.lblCLevel);
			this.pnlFilter.Controls.Add(this.txtStoresZonesChoosen);
			this.pnlFilter.Controls.Add(this.btnStorezZonesChoose);
			this.pnlFilter.Controls.Add(this.lblActual);
			this.pnlFilter.Controls.Add(this.chkCellsActual);
			this.pnlFilter.Controls.Add(this.txtCellBarCode);
			this.pnlFilter.Controls.Add(this.lblCell);
			this.pnlFilter.Controls.Add(this.lblTreeWait);
			this.pnlFilter.Controls.Add(this.btnTree);
			this.pnlFilter.Controls.Add(this.lblCellBarCode);
			this.pnlFilter.Controls.Add(this.btnClear);
			this.pnlFilter.Controls.Add(this.btnFilter);
			this.pnlFilter.Controls.Add(this.txtCellAddress);
			this.pnlFilter.Controls.Add(this.lblCellAddress);
			this.pnlFilter.Controls.Add(this.lblStoreZone);
			this.pnlFilter.Location = new System.Drawing.Point(2, 3);
			this.pnlFilter.Name = "pnlFilter";
			this.pnlFilter.Size = new System.Drawing.Size(638, 122);
			this.pnlFilter.TabIndex = 0;
			// 
			// cboCPlace
			// 
			this.cboCPlace.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCPlace.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCPlace.FormattingEnabled = true;
			this.cboCPlace.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCPlace.Location = new System.Drawing.Point(386, 68);
			this.cboCPlace.Name = "cboCPlace";
			this.cboCPlace.Size = new System.Drawing.Size(52, 22);
			this.cboCPlace.TabIndex = 17;
			// 
			// cboCLevel
			// 
			this.cboCLevel.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCLevel.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCLevel.FormattingEnabled = true;
			this.cboCLevel.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCLevel.Location = new System.Drawing.Point(322, 68);
			this.cboCLevel.Name = "cboCLevel";
			this.cboCLevel.Size = new System.Drawing.Size(52, 22);
			this.cboCLevel.TabIndex = 15;
			// 
			// cboCRack
			// 
			this.cboCRack.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCRack.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCRack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCRack.FormattingEnabled = true;
			this.cboCRack.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCRack.Location = new System.Drawing.Point(258, 68);
			this.cboCRack.Name = "cboCRack";
			this.cboCRack.Size = new System.Drawing.Size(52, 22);
			this.cboCRack.TabIndex = 13;
			// 
			// cboCLine
			// 
			this.cboCLine.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCLine.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCLine.FormattingEnabled = true;
			this.cboCLine.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCLine.Location = new System.Drawing.Point(194, 68);
			this.cboCLine.Name = "cboCLine";
			this.cboCLine.Size = new System.Drawing.Size(52, 22);
			this.cboCLine.TabIndex = 11;
			// 
			// lblCBuilding
			// 
			this.lblCBuilding.AutoSize = true;
			this.lblCBuilding.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCBuilding.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCBuilding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCBuilding.Location = new System.Drawing.Point(130, 52);
			this.lblCBuilding.Name = "lblCBuilding";
			this.lblCBuilding.Size = new System.Drawing.Size(47, 14);
			this.lblCBuilding.TabIndex = 8;
			this.lblCBuilding.Text = "Здание";
			// 
			// cboCBuilding
			// 
			this.cboCBuilding.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCBuilding.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCBuilding.FormattingEnabled = true;
			this.cboCBuilding.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCBuilding.Location = new System.Drawing.Point(130, 68);
			this.cboCBuilding.Name = "cboCBuilding";
			this.cboCBuilding.Size = new System.Drawing.Size(52, 22);
			this.cboCBuilding.TabIndex = 9;
			// 
			// lblCLine
			// 
			this.lblCLine.AutoSize = true;
			this.lblCLine.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCLine.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCLine.Location = new System.Drawing.Point(191, 52);
			this.lblCLine.Name = "lblCLine";
			this.lblCLine.Size = new System.Drawing.Size(43, 14);
			this.lblCLine.TabIndex = 10;
			this.lblCLine.Text = "Линия";
			// 
			// lblCPlace
			// 
			this.lblCPlace.AutoSize = true;
			this.lblCPlace.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCPlace.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCPlace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCPlace.Location = new System.Drawing.Point(385, 52);
			this.lblCPlace.Name = "lblCPlace";
			this.lblCPlace.Size = new System.Drawing.Size(47, 14);
			this.lblCPlace.TabIndex = 16;
			this.lblCPlace.Text = "Ячейка";
			// 
			// lblCRack
			// 
			this.lblCRack.AutoSize = true;
			this.lblCRack.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCRack.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCRack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCRack.Location = new System.Drawing.Point(257, 52);
			this.lblCRack.Name = "lblCRack";
			this.lblCRack.Size = new System.Drawing.Size(40, 14);
			this.lblCRack.TabIndex = 12;
			this.lblCRack.Text = "Стояк";
			// 
			// lblCLevel
			// 
			this.lblCLevel.AutoSize = true;
			this.lblCLevel.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCLevel.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCLevel.Location = new System.Drawing.Point(320, 52);
			this.lblCLevel.Name = "lblCLevel";
			this.lblCLevel.Size = new System.Drawing.Size(54, 14);
			this.lblCLevel.TabIndex = 14;
			this.lblCLevel.Text = "Уровень";
			// 
			// txtStoresZonesChoosen
			// 
			this.txtStoresZonesChoosen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtStoresZonesChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtStoresZonesChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtStoresZonesChoosen.Enabled = false;
			this.txtStoresZonesChoosen.Location = new System.Drawing.Point(130, 3);
			this.txtStoresZonesChoosen.Name = "txtStoresZonesChoosen";
			this.txtStoresZonesChoosen.Size = new System.Drawing.Size(501, 22);
			this.txtStoresZonesChoosen.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.txtStoresZonesChoosen, "Выбранные складские зоны");
			// 
			// btnStorezZonesChoose
			// 
			this.btnStorezZonesChoose.FlatAppearance.BorderSize = 0;
			this.btnStorezZonesChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStorezZonesChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnStorezZonesChoose.Location = new System.Drawing.Point(101, 1);
			this.btnStorezZonesChoose.Name = "btnStorezZonesChoose";
			this.btnStorezZonesChoose.Size = new System.Drawing.Size(24, 24);
			this.btnStorezZonesChoose.TabIndex = 1;
			this.ttToolTip.SetToolTip(this.btnStorezZonesChoose, "Выбрать складские зоны");
			this.btnStorezZonesChoose.UseVisualStyleBackColor = true;
			this.btnStorezZonesChoose.Click += new System.EventHandler(this.btnStorezZonesChoose_Click);
			// 
			// lblActual
			// 
			this.lblActual.AutoSize = true;
			this.lblActual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblActual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblActual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblActual.Location = new System.Drawing.Point(3, 96);
			this.lblActual.Name = "lblActual";
			this.lblActual.Size = new System.Drawing.Size(117, 14);
			this.lblActual.TabIndex = 18;
			this.lblActual.Text = "Только актуальные";
			// 
			// chkCellsActual
			// 
			this.chkCellsActual.AutoSize = true;
			this.chkCellsActual.Checked = true;
			this.chkCellsActual.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCellsActual.IsChanged = true;
			this.chkCellsActual.Location = new System.Drawing.Point(130, 97);
			this.chkCellsActual.Name = "chkCellsActual";
			this.chkCellsActual.Size = new System.Drawing.Size(15, 14);
			this.chkCellsActual.TabIndex = 19;
			this.chkCellsActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkCellsActual.UseVisualStyleBackColor = true;
			this.chkCellsActual.CheckedChanged += new System.EventHandler(this.chkCellsActual_CheckedChanged);
			// 
			// txtCellBarCode
			// 
			this.txtCellBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellBarCode.Location = new System.Drawing.Point(130, 27);
			this.txtCellBarCode.MaxLength = 16;
			this.txtCellBarCode.Name = "txtCellBarCode";
			this.txtCellBarCode.Size = new System.Drawing.Size(179, 22);
			this.txtCellBarCode.TabIndex = 5;
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(3, 29);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(51, 14);
			this.lblCell.TabIndex = 3;
			this.lblCell.Text = "Ячейка:";
			// 
			// lblTreeWait
			// 
			this.lblTreeWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTreeWait.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblTreeWait.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblTreeWait.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblTreeWait.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTreeWait.Location = new System.Drawing.Point(269, 95);
			this.lblTreeWait.Name = "lblTreeWait";
			this.lblTreeWait.Size = new System.Drawing.Size(226, 17);
			this.lblTreeWait.TabIndex = 20;
			this.lblTreeWait.Text = "Ждите, идет загрузка данных...";
			this.lblTreeWait.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblTreeWait.Visible = false;
			// 
			// btnTree
			// 
			this.btnTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTree.Image = global::WMSSuitable.Properties.Resources.Tree;
			this.btnTree.Location = new System.Drawing.Point(501, 86);
			this.btnTree.Name = "btnTree";
			this.btnTree.Size = new System.Drawing.Size(30, 30);
			this.btnTree.TabIndex = 21;
			this.ttToolTip.SetToolTip(this.btnTree, "Показать дерево ячеек");
			this.btnTree.UseVisualStyleBackColor = true;
			this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
			// 
			// lblCellBarCode
			// 
			this.lblCellBarCode.AutoSize = true;
			this.lblCellBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellBarCode.Location = new System.Drawing.Point(101, 30);
			this.lblCellBarCode.Name = "lblCellBarCode";
			this.lblCellBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblCellBarCode.TabIndex = 4;
			this.lblCellBarCode.Text = "ШК";
			this.ttToolTip.SetToolTip(this.lblCellBarCode, "Штрих-код");
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnClear.Location = new System.Drawing.Point(601, 86);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(30, 30);
			this.btnClear.TabIndex = 23;
			this.ttToolTip.SetToolTip(this.btnClear, "Очистить условия");
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnFilter
			// 
			this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFilter.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
			this.btnFilter.Location = new System.Drawing.Point(551, 86);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(30, 30);
			this.btnFilter.TabIndex = 22;
			this.ttToolTip.SetToolTip(this.btnFilter, "Показать ячейки, соответствующие условиям");
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// txtCellAddress
			// 
			this.txtCellAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCellAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellAddress.Location = new System.Drawing.Point(386, 27);
			this.txtCellAddress.Name = "txtCellAddress";
			this.txtCellAddress.Size = new System.Drawing.Size(160, 22);
			this.txtCellAddress.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.txtCellAddress, "Полный адрес или контекст адреса ячейки (_ - замена одного символа, % - замена не" +
					"скольких символов)");
			this.txtCellAddress.TextChanged += new System.EventHandler(this.txtCellAddress_TextChanged);
			// 
			// lblCellAddress
			// 
			this.lblCellAddress.AutoSize = true;
			this.lblCellAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellAddress.Location = new System.Drawing.Point(343, 30);
			this.lblCellAddress.Name = "lblCellAddress";
			this.lblCellAddress.Size = new System.Drawing.Size(42, 14);
			this.lblCellAddress.TabIndex = 6;
			this.lblCellAddress.Text = "Адрес";
			this.ttToolTip.SetToolTip(this.lblCellAddress, "Полный адрес или контекст адреса ячейки (_ - замена одного символа, % - замена не" +
					"скольких символов)");
			// 
			// lblStoreZone
			// 
			this.lblStoreZone.AutoSize = true;
			this.lblStoreZone.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoreZone.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoreZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoreZone.Location = new System.Drawing.Point(3, 6);
			this.lblStoreZone.Name = "lblStoreZone";
			this.lblStoreZone.Size = new System.Drawing.Size(97, 14);
			this.lblStoreZone.TabIndex = 0;
			this.lblStoreZone.Text = "Складские зоны";
			// 
			// btnHelp
			// 
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(5, 338);
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
			this.btnExit.Location = new System.Drawing.Point(606, 338);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(30, 30);
			this.btnExit.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.btnExit, "Выход");
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnGo.Location = new System.Drawing.Point(556, 338);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(30, 30);
			this.btnGo.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.btnGo, "Выбор");
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// cntData
			// 
			this.cntData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cntData.Location = new System.Drawing.Point(2, 129);
			this.cntData.Name = "cntData";
			// 
			// cntData.Panel1
			// 
			this.cntData.Panel1.Controls.Add(this.tvwCells);
			this.cntData.Panel1MinSize = 0;
			// 
			// cntData.Panel2
			// 
			this.cntData.Panel2.Controls.Add(this.grdData);
			this.cntData.Panel2MinSize = 0;
			this.cntData.Size = new System.Drawing.Size(638, 204);
			this.cntData.SplitterDistance = 48;
			this.cntData.SplitterWidth = 2;
			this.cntData.TabIndex = 11;
			// 
			// tvwCells
			// 
			this.tvwCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tvwCells.CheckBoxes = true;
			this.tvwCells.FullRowSelect = true;
			this.tvwCells.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1)),
        ((object)(((byte)(0))))};
			this.tvwCells.Location = new System.Drawing.Point(0, 0);
			this.tvwCells.Name = "tvwCells";
			this.tvwCells.Size = new System.Drawing.Size(48, 204);
			this.tvwCells.TabIndex = 0;
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
            this.grcCellStateImage,
            this.grcLockedImage,
            this.grcId,
            this.grcAddress,
            this.grcStoreZoneName,
            this.grcStoreZoneTypeName,
            this.grcFixedOwnerName,
            this.grcFixedGoodStateName,
            this.grcFixedPackingAlias,
            this.grcState,
            this.grcActual,
            this.grcCBuilding,
            this.grcCLine,
            this.grcCRack,
            this.grcCLevel,
            this.grcCPlace,
            this.grcMaxWeight,
            this.grcCellWidth,
            this.grcCellHeight,
            this.grcPalletTypeName,
            this.grcTemperatureMode,
            this.grcLocked,
            this.grcBufferAddress,
            this.grcErpCode,
            this.grcHasCellContent,
            this.grcMaxPalletQnt,
            this.grcStoreZoneMaxPalletQnt,
            this.grcForFrames,
            this.grcIsForFrames});
			this.grdData.IsCheckerInclude = true;
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
			this.grdData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grdData.Size = new System.Drawing.Size(588, 204);
			this.grdData.TabIndex = 0;
			this.grdData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdData_CellFormatting);
			// 
			// grcCellStateImage
			// 
			this.grcCellStateImage.HeaderText = "";
			this.grcCellStateImage.Name = "grcCellStateImage";
			this.grcCellStateImage.ReadOnly = true;
			this.grcCellStateImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellStateImage.ToolTipText = "Ячейка заполнена?";
			this.grcCellStateImage.Width = 30;
			// 
			// grcLockedImage
			// 
			this.grcLockedImage.HeaderText = "Блок.";
			this.grcLockedImage.Name = "grcLockedImage";
			this.grcLockedImage.ReadOnly = true;
			this.grcLockedImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcLockedImage.ToolTipText = "Ячейка блокирована?";
			this.grcLockedImage.Width = 30;
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
			this.grcId.ToolTipText = "Код записи";
			this.grcId.Width = 50;
			// 
			// grcAddress
			// 
			this.grcAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcAddress.DataPropertyName = "Address";
			this.grcAddress.HeaderText = "Адрес";
			this.grcAddress.Name = "grcAddress";
			this.grcAddress.ReadOnly = true;
			this.grcAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcAddress.Width = 77;
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
			// grcStoreZoneTypeName
			// 
			this.grcStoreZoneTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneTypeName.DataPropertyName = "StoreZoneTypeName";
			this.grcStoreZoneTypeName.HeaderText = "Тип зоны";
			this.grcStoreZoneTypeName.Name = "grcStoreZoneTypeName";
			this.grcStoreZoneTypeName.ReadOnly = true;
			this.grcStoreZoneTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcFixedOwnerName
			// 
			this.grcFixedOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcFixedOwnerName.DataPropertyName = "FixedOwnerName";
			this.grcFixedOwnerName.HeaderText = "Хранитель (фикс.)";
			this.grcFixedOwnerName.Name = "grcFixedOwnerName";
			this.grcFixedOwnerName.ReadOnly = true;
			this.grcFixedOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFixedOwnerName.ToolTipText = "Хранитель фиксированный";
			this.grcFixedOwnerName.Width = 150;
			// 
			// grcFixedGoodStateName
			// 
			this.grcFixedGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcFixedGoodStateName.DataPropertyName = "FixedGoodStateName";
			this.grcFixedGoodStateName.HeaderText = "Состояние товара (фикс.)";
			this.grcFixedGoodStateName.Name = "grcFixedGoodStateName";
			this.grcFixedGoodStateName.ReadOnly = true;
			this.grcFixedGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFixedGoodStateName.ToolTipText = "Состояние товара (фиксированное)";
			this.grcFixedGoodStateName.Width = 150;
			// 
			// grcFixedPackingAlias
			// 
			this.grcFixedPackingAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcFixedPackingAlias.DataPropertyName = "PackingAlias";
			this.grcFixedPackingAlias.HeaderText = "Товар (фикс.)";
			this.grcFixedPackingAlias.Name = "grcFixedPackingAlias";
			this.grcFixedPackingAlias.ReadOnly = true;
			this.grcFixedPackingAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFixedPackingAlias.ToolTipText = "Товар фиксированный";
			this.grcFixedPackingAlias.Width = 150;
			// 
			// grcState
			// 
			this.grcState.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcState.DataPropertyName = "State";
			this.grcState.HeaderText = "Состояние ячейки";
			this.grcState.Name = "grcState";
			this.grcState.ReadOnly = true;
			this.grcState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcState.Width = 40;
			// 
			// grcActual
			// 
			this.grcActual.DataPropertyName = "Actual";
			this.grcActual.HeaderText = "Акт.";
			this.grcActual.Name = "grcActual";
			this.grcActual.ReadOnly = true;
			this.grcActual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcActual.ToolTipText = "Актуально?";
			this.grcActual.Width = 30;
			// 
			// grcCBuilding
			// 
			this.grcCBuilding.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCBuilding.DataPropertyName = "CBuilding";
			this.grcCBuilding.HeaderText = "Адрес: Здание";
			this.grcCBuilding.Name = "grcCBuilding";
			this.grcCBuilding.ReadOnly = true;
			this.grcCBuilding.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCBuilding.Width = 60;
			// 
			// grcCLine
			// 
			this.grcCLine.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCLine.DataPropertyName = "CLine";
			this.grcCLine.HeaderText = "Адрес: Линия";
			this.grcCLine.Name = "grcCLine";
			this.grcCLine.ReadOnly = true;
			this.grcCLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCLine.Width = 60;
			// 
			// grcCRack
			// 
			this.grcCRack.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCRack.DataPropertyName = "CRack";
			this.grcCRack.HeaderText = "Адрес: Стояк";
			this.grcCRack.Name = "grcCRack";
			this.grcCRack.ReadOnly = true;
			this.grcCRack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCRack.Width = 60;
			// 
			// grcCLevel
			// 
			this.grcCLevel.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCLevel.DataPropertyName = "CLevel";
			this.grcCLevel.HeaderText = "Адрес: Уровень";
			this.grcCLevel.Name = "grcCLevel";
			this.grcCLevel.ReadOnly = true;
			this.grcCLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCLevel.Width = 60;
			// 
			// grcCPlace
			// 
			this.grcCPlace.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCPlace.DataPropertyName = "CPlace";
			this.grcCPlace.HeaderText = "Адрес: Ячейка";
			this.grcCPlace.Name = "grcCPlace";
			this.grcCPlace.ReadOnly = true;
			this.grcCPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCPlace.Width = 60;
			// 
			// grcMaxWeight
			// 
			this.grcMaxWeight.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcMaxWeight.DataPropertyName = "MaxWeight";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N0";
			dataGridViewCellStyle3.NullValue = null;
			this.grcMaxWeight.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcMaxWeight.HeaderText = "Макс.вес, кг";
			this.grcMaxWeight.Name = "grcMaxWeight";
			this.grcMaxWeight.ReadOnly = true;
			this.grcMaxWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcMaxWeight.ToolTipText = "Максимальная грузоподъемность ячейки, кг";
			this.grcMaxWeight.Width = 60;
			// 
			// grcCellWidth
			// 
			this.grcCellWidth.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellWidth.DataPropertyName = "CellWidth";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N3";
			dataGridViewCellStyle4.NullValue = null;
			this.grcCellWidth.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcCellWidth.HeaderText = "Ширина, м";
			this.grcCellWidth.Name = "grcCellWidth";
			this.grcCellWidth.ReadOnly = true;
			this.grcCellWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellWidth.ToolTipText = "Ширина ячейки, м";
			this.grcCellWidth.Width = 60;
			// 
			// grcCellHeight
			// 
			this.grcCellHeight.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellHeight.DataPropertyName = "CellHeight";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N3";
			dataGridViewCellStyle5.NullValue = null;
			this.grcCellHeight.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcCellHeight.HeaderText = "Высота, м";
			this.grcCellHeight.Name = "grcCellHeight";
			this.grcCellHeight.ReadOnly = true;
			this.grcCellHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellHeight.ToolTipText = "Высота ячейки, м";
			this.grcCellHeight.Width = 60;
			// 
			// grcPalletTypeName
			// 
			this.grcPalletTypeName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPalletTypeName.DataPropertyName = "PalletTypeName";
			this.grcPalletTypeName.HeaderText = "Тип поддона";
			this.grcPalletTypeName.Name = "grcPalletTypeName";
			this.grcPalletTypeName.ReadOnly = true;
			this.grcPalletTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPalletTypeName.Width = 80;
			// 
			// grcTemperatureMode
			// 
			this.grcTemperatureMode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcTemperatureMode.DataPropertyName = "TemperatureMode";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grcTemperatureMode.DefaultCellStyle = dataGridViewCellStyle6;
			this.grcTemperatureMode.HeaderText = "Т";
			this.grcTemperatureMode.Name = "grcTemperatureMode";
			this.grcTemperatureMode.ReadOnly = true;
			this.grcTemperatureMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcTemperatureMode.ToolTipText = "Температурный режим";
			this.grcTemperatureMode.Width = 25;
			// 
			// grcLocked
			// 
			this.grcLocked.DataPropertyName = "Locked";
			this.grcLocked.HeaderText = "Блок.";
			this.grcLocked.Name = "grcLocked";
			this.grcLocked.ReadOnly = true;
			this.grcLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.grcLocked.ToolTipText = "Ячейка блокирована?";
			this.grcLocked.Visible = false;
			this.grcLocked.Width = 30;
			// 
			// grcBufferAddress
			// 
			this.grcBufferAddress.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBufferAddress.DataPropertyName = "BufferAddress";
			this.grcBufferAddress.HeaderText = "Буф.ячейка";
			this.grcBufferAddress.Name = "grcBufferAddress";
			this.grcBufferAddress.ReadOnly = true;
			this.grcBufferAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBufferAddress.Width = 80;
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
			// grcHasCellContent
			// 
			this.grcHasCellContent.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcHasCellContent.DataPropertyName = "HasCellContent";
			this.grcHasCellContent.HeaderText = "HasCellContent";
			this.grcHasCellContent.Name = "grcHasCellContent";
			this.grcHasCellContent.ReadOnly = true;
			this.grcHasCellContent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcHasCellContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcHasCellContent.Visible = false;
			// 
			// grcMaxPalletQnt
			// 
			this.grcMaxPalletQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcMaxPalletQnt.DataPropertyName = "MaxPalletQnt";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N2";
			this.grcMaxPalletQnt.DefaultCellStyle = dataGridViewCellStyle7;
			this.grcMaxPalletQnt.HeaderText = "Max пал. ячейка";
			this.grcMaxPalletQnt.Name = "grcMaxPalletQnt";
			this.grcMaxPalletQnt.ReadOnly = true;
			this.grcMaxPalletQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcMaxPalletQnt.ToolTipText = "Максимальное число поддонов (паллет) в ячейке";
			this.grcMaxPalletQnt.Width = 80;
			// 
			// grcStoreZoneMaxPalletQnt
			// 
			this.grcStoreZoneMaxPalletQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcStoreZoneMaxPalletQnt.DataPropertyName = "StoreZoneMaxPalletQnt";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "N2";
			this.grcStoreZoneMaxPalletQnt.DefaultCellStyle = dataGridViewCellStyle8;
			this.grcStoreZoneMaxPalletQnt.HeaderText = "Max пал. зона";
			this.grcStoreZoneMaxPalletQnt.Name = "grcStoreZoneMaxPalletQnt";
			this.grcStoreZoneMaxPalletQnt.ReadOnly = true;
			this.grcStoreZoneMaxPalletQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcStoreZoneMaxPalletQnt.ToolTipText = "Максимальное число поддонов (паллет) в ячейке складской зоны";
			this.grcStoreZoneMaxPalletQnt.Width = 80;
			// 
			// grcForFrames
			// 
			this.grcForFrames.DataPropertyName = "ForFrames";
			this.grcForFrames.HeaderText = "Конт.?";
			this.grcForFrames.Name = "grcForFrames";
			this.grcForFrames.ReadOnly = true;
			this.grcForFrames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcForFrames.ToolTipText = "Ячейка для контейнеров?";
			this.grcForFrames.Width = 40;
			// 
			// grcIsForFrames
			// 
			this.grcIsForFrames.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcIsForFrames.HeaderText = "IsForFrames";
			this.grcIsForFrames.Name = "grcIsForFrames";
			this.grcIsForFrames.ReadOnly = true;
			this.grcIsForFrames.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcIsForFrames.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcIsForFrames.Visible = false;
			// 
			// frmSelectOneCell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 373);
			this.Controls.Add(this.cntData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.pnlFilter);
			this.hpHelp.SetHelpKeyword(this, "1002");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MinimumSize = new System.Drawing.Size(650, 400);
			this.Name = "frmSelectOneCell";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Выбор товара/упаковки";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSelectOneCell_KeyDown);
			this.Load += new System.EventHandler(this.frmSelectOneCell_Load);
			this.pnlFilter.ResumeLayout(false);
			this.pnlFilter.PerformLayout();
			this.cntData.Panel1.ResumeLayout(false);
			this.cntData.Panel2.ResumeLayout(false);
			this.cntData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMPanel pnlFilter;
        private RFMBaseClasses.RFMTextBox txtCellAddress;
        private RFMBaseClasses.RFMLabel lblCellAddress;
        private RFMBaseClasses.RFMLabel lblStoreZone;
        private RFMBaseClasses.RFMButton btnClear;
		private RFMBaseClasses.RFMButton btnFilter;
        private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnGo;
		private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMLabel lblCellBarCode;
		private RFMBaseClasses.RFMSplitContainer cntData;
		private RFMBaseClasses.RFMTreeView tvwCells;
		private RFMBaseClasses.RFMButton btnTree;
		private RFMBaseClasses.RFMLabel lblTreeWait;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMTextBoxBarCode txtCellBarCode;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMLabel lblActual;
		private RFMBaseClasses.RFMCheckBox chkCellsActual;
		private RFMBaseClasses.RFMTextBox txtStoresZonesChoosen;
		private RFMBaseClasses.RFMButton btnStorezZonesChoose;
		private RFMBaseClasses.RFMComboBox cboCPlace;
		private RFMBaseClasses.RFMComboBox cboCLevel;
		private RFMBaseClasses.RFMComboBox cboCRack;
		private RFMBaseClasses.RFMComboBox cboCLine;
		private RFMBaseClasses.RFMLabel lblCBuilding;
		private RFMBaseClasses.RFMComboBox cboCBuilding;
		private RFMBaseClasses.RFMLabel lblCLine;
		private RFMBaseClasses.RFMLabel lblCPlace;
		private RFMBaseClasses.RFMLabel lblCRack;
		private RFMBaseClasses.RFMLabel lblCLevel;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcCellStateImage;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcLockedImage;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcId;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFixedOwnerName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFixedGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFixedPackingAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcState;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcActual;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCBuilding;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCLine;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCRack;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCLevel;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCPlace;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMaxWeight;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellWidth;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellHeight;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalletTypeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcTemperatureMode;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcLocked;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBufferAddress;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcErpCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcHasCellContent;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcMaxPalletQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcStoreZoneMaxPalletQnt;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcForFrames;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcIsForFrames;

	}
}