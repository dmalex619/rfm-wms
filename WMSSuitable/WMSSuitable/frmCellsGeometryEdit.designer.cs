namespace WMSSuitable
{
	partial class frmCellsGeometryEdit
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
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.lblAddress = new RFMBaseClasses.RFMLabel();
			this.txtAddress = new RFMBaseClasses.RFMTextBox();
			this.lblCellID = new RFMBaseClasses.RFMLabel();
			this.lblCellBarCode = new RFMBaseClasses.RFMLabel();
			this.txtPalletsTypes = new RFMBaseClasses.RFMTextBox();
			this.chkMaxPalletQnt = new RFMBaseClasses.RFMCheckBox();
			this.txtStoreZoneMaxPalletQnt = new RFMBaseClasses.RFMTextBox();
			this.txtMaxPalletQnt = new RFMBaseClasses.RFMTextBox();
			this.btnMaxPalletQntClear = new RFMBaseClasses.RFMButton();
			this.lblStoreZoneMaxPalletQnt = new RFMBaseClasses.RFMLabel();
			this.numStoreZoneMaxPalletQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.lblMaxPalletQnt = new RFMBaseClasses.RFMLabel();
			this.numMaxPalletQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.lblMaxPalletQntX = new RFMBaseClasses.RFMLabel();
			this.txtCellHeight = new RFMBaseClasses.RFMTextBox();
			this.txtCellWidth = new RFMBaseClasses.RFMTextBox();
			this.txtMaxWeight = new RFMBaseClasses.RFMTextBox();
			this.chkCellHeight = new RFMBaseClasses.RFMCheckBox();
			this.lblCellWidth1 = new RFMBaseClasses.RFMLabel();
			this.numCellWidth = new RFMBaseClasses.RFMNumericUpDown();
			this.lblCellWidth = new RFMBaseClasses.RFMLabel();
			this.lblCellHeight1 = new RFMBaseClasses.RFMLabel();
			this.numCellHeight = new RFMBaseClasses.RFMNumericUpDown();
			this.lblCellHeight = new RFMBaseClasses.RFMLabel();
			this.lblMaxWeight1 = new RFMBaseClasses.RFMLabel();
			this.numMaxWeight = new RFMBaseClasses.RFMNumericUpDown();
			this.btnPalletsTypesClear = new RFMBaseClasses.RFMButton();
			this.chkCellWidth = new RFMBaseClasses.RFMCheckBox();
			this.chkPalletsTypes = new RFMBaseClasses.RFMCheckBox();
			this.chkMaxWeight = new RFMBaseClasses.RFMCheckBox();
			this.lblPalletsTypes = new RFMBaseClasses.RFMLabel();
			this.cboPalletsTypes = new RFMBaseClasses.RFMComboBox();
			this.lblMaxWeight = new RFMBaseClasses.RFMLabel();
			this.txtCellID = new RFMBaseClasses.RFMTextBox();
			this.txtBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numStoreZoneMaxPalletQnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxPalletQnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCellWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCellHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWeight)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(470, 287);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(420, 287);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 287);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblAddress);
			this.pnlData.Controls.Add(this.txtAddress);
			this.pnlData.Controls.Add(this.lblCellID);
			this.pnlData.Controls.Add(this.lblCellBarCode);
			this.pnlData.Controls.Add(this.txtPalletsTypes);
			this.pnlData.Controls.Add(this.chkMaxPalletQnt);
			this.pnlData.Controls.Add(this.txtStoreZoneMaxPalletQnt);
			this.pnlData.Controls.Add(this.txtMaxPalletQnt);
			this.pnlData.Controls.Add(this.btnMaxPalletQntClear);
			this.pnlData.Controls.Add(this.lblStoreZoneMaxPalletQnt);
			this.pnlData.Controls.Add(this.numStoreZoneMaxPalletQnt);
			this.pnlData.Controls.Add(this.lblMaxPalletQnt);
			this.pnlData.Controls.Add(this.numMaxPalletQnt);
			this.pnlData.Controls.Add(this.lblMaxPalletQntX);
			this.pnlData.Controls.Add(this.txtCellHeight);
			this.pnlData.Controls.Add(this.txtCellWidth);
			this.pnlData.Controls.Add(this.txtMaxWeight);
			this.pnlData.Controls.Add(this.chkCellHeight);
			this.pnlData.Controls.Add(this.lblCellWidth1);
			this.pnlData.Controls.Add(this.numCellWidth);
			this.pnlData.Controls.Add(this.lblCellWidth);
			this.pnlData.Controls.Add(this.lblCellHeight1);
			this.pnlData.Controls.Add(this.numCellHeight);
			this.pnlData.Controls.Add(this.lblCellHeight);
			this.pnlData.Controls.Add(this.lblMaxWeight1);
			this.pnlData.Controls.Add(this.numMaxWeight);
			this.pnlData.Controls.Add(this.btnPalletsTypesClear);
			this.pnlData.Controls.Add(this.chkCellWidth);
			this.pnlData.Controls.Add(this.chkPalletsTypes);
			this.pnlData.Controls.Add(this.chkMaxWeight);
			this.pnlData.Controls.Add(this.lblPalletsTypes);
			this.pnlData.Controls.Add(this.cboPalletsTypes);
			this.pnlData.Controls.Add(this.lblMaxWeight);
			this.pnlData.Controls.Add(this.txtCellID);
			this.pnlData.Controls.Add(this.txtBarCode);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Location = new System.Drawing.Point(6, 7);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(494, 272);
			this.pnlData.TabIndex = 4;
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAddress.Location = new System.Drawing.Point(105, 37);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(42, 14);
			this.lblAddress.TabIndex = 51;
			this.lblAddress.Text = "јдрес";
			// 
			// txtAddress
			// 
			this.txtAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAddress.Enabled = false;
			this.txtAddress.Location = new System.Drawing.Point(150, 34);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(172, 22);
			this.txtAddress.TabIndex = 50;
			// 
			// lblCellID
			// 
			this.lblCellID.AutoSize = true;
			this.lblCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellID.Location = new System.Drawing.Point(399, 11);
			this.lblCellID.Name = "lblCellID";
			this.lblCellID.Size = new System.Drawing.Size(28, 14);
			this.lblCellID.TabIndex = 3;
			this.lblCellID.Text = " од";
			this.ttToolTip.SetToolTip(this.lblCellID, "”никальный код €чейки");
			// 
			// lblCellBarCode
			// 
			this.lblCellBarCode.AutoSize = true;
			this.lblCellBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellBarCode.Location = new System.Drawing.Point(123, 11);
			this.lblCellBarCode.Name = "lblCellBarCode";
			this.lblCellBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblCellBarCode.TabIndex = 1;
			this.lblCellBarCode.Text = "Ў ";
			this.ttToolTip.SetToolTip(this.lblCellBarCode, "Ўтрих-код");
			// 
			// txtPalletsTypes
			// 
			this.txtPalletsTypes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPalletsTypes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPalletsTypes.Enabled = false;
			this.txtPalletsTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtPalletsTypes.Location = new System.Drawing.Point(331, 71);
			this.txtPalletsTypes.Name = "txtPalletsTypes";
			this.txtPalletsTypes.Size = new System.Drawing.Size(150, 22);
			this.txtPalletsTypes.TabIndex = 9;
			// 
			// chkMaxPalletQnt
			// 
			this.chkMaxPalletQnt.AutoSize = true;
			this.chkMaxPalletQnt.Location = new System.Drawing.Point(130, 216);
			this.chkMaxPalletQnt.Name = "chkMaxPalletQnt";
			this.chkMaxPalletQnt.Size = new System.Drawing.Size(15, 14);
			this.chkMaxPalletQnt.TabIndex = 27;
			this.chkMaxPalletQnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkMaxPalletQnt, "»зменить максимальное количество поддонов");
			this.chkMaxPalletQnt.UseVisualStyleBackColor = true;
			this.chkMaxPalletQnt.CheckedChanged += new System.EventHandler(this.chkMaxPalletQnt_CheckedChanged);
			// 
			// txtStoreZoneMaxPalletQnt
			// 
			this.txtStoreZoneMaxPalletQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtStoreZoneMaxPalletQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtStoreZoneMaxPalletQnt.Enabled = false;
			this.txtStoreZoneMaxPalletQnt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtStoreZoneMaxPalletQnt.Location = new System.Drawing.Point(331, 238);
			this.txtStoreZoneMaxPalletQnt.Name = "txtStoreZoneMaxPalletQnt";
			this.txtStoreZoneMaxPalletQnt.Size = new System.Drawing.Size(150, 22);
			this.txtStoreZoneMaxPalletQnt.TabIndex = 33;
			// 
			// txtMaxPalletQnt
			// 
			this.txtMaxPalletQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtMaxPalletQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMaxPalletQnt.Enabled = false;
			this.txtMaxPalletQnt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtMaxPalletQnt.Location = new System.Drawing.Point(331, 210);
			this.txtMaxPalletQnt.Name = "txtMaxPalletQnt";
			this.txtMaxPalletQnt.Size = new System.Drawing.Size(150, 22);
			this.txtMaxPalletQnt.TabIndex = 30;
			// 
			// btnMaxPalletQntClear
			// 
			this.btnMaxPalletQntClear.FlatAppearance.BorderSize = 0;
			this.btnMaxPalletQntClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMaxPalletQntClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnMaxPalletQntClear.Location = new System.Drawing.Point(260, 211);
			this.btnMaxPalletQntClear.Name = "btnMaxPalletQntClear";
			this.btnMaxPalletQntClear.Size = new System.Drawing.Size(25, 25);
			this.btnMaxPalletQntClear.TabIndex = 29;
			this.ttToolTip.SetToolTip(this.btnMaxPalletQntClear, "ќчистить максимальное количество поддонов в €чейке");
			this.btnMaxPalletQntClear.UseVisualStyleBackColor = true;
			this.btnMaxPalletQntClear.Click += new System.EventHandler(this.btnMaxPalletQntClear_Click);
			// 
			// lblStoreZoneMaxPalletQnt
			// 
			this.lblStoreZoneMaxPalletQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoreZoneMaxPalletQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoreZoneMaxPalletQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoreZoneMaxPalletQnt.Location = new System.Drawing.Point(45, 243);
			this.lblStoreZoneMaxPalletQnt.Name = "lblStoreZoneMaxPalletQnt";
			this.lblStoreZoneMaxPalletQnt.Size = new System.Drawing.Size(95, 14);
			this.lblStoreZoneMaxPalletQnt.TabIndex = 31;
			this.lblStoreZoneMaxPalletQnt.Text = "¬ €чейках зоны";
			// 
			// numStoreZoneMaxPalletQnt
			// 
			this.numStoreZoneMaxPalletQnt.DecimalPlaces = 2;
			this.numStoreZoneMaxPalletQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numStoreZoneMaxPalletQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numStoreZoneMaxPalletQnt.Enabled = false;
			this.numStoreZoneMaxPalletQnt.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numStoreZoneMaxPalletQnt.IsNull = false;
			this.numStoreZoneMaxPalletQnt.Location = new System.Drawing.Point(151, 239);
			this.numStoreZoneMaxPalletQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numStoreZoneMaxPalletQnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numStoreZoneMaxPalletQnt.Name = "numStoreZoneMaxPalletQnt";
			this.numStoreZoneMaxPalletQnt.Size = new System.Drawing.Size(106, 22);
			this.numStoreZoneMaxPalletQnt.TabIndex = 32;
			this.numStoreZoneMaxPalletQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblMaxPalletQnt
			// 
			this.lblMaxPalletQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblMaxPalletQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblMaxPalletQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMaxPalletQnt.Location = new System.Drawing.Point(45, 216);
			this.lblMaxPalletQnt.Name = "lblMaxPalletQnt";
			this.lblMaxPalletQnt.Size = new System.Drawing.Size(59, 14);
			this.lblMaxPalletQnt.TabIndex = 26;
			this.lblMaxPalletQnt.Text = "¬ €чейке";
			// 
			// numMaxPalletQnt
			// 
			this.numMaxPalletQnt.DecimalPlaces = 2;
			this.numMaxPalletQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numMaxPalletQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numMaxPalletQnt.IsNull = false;
			this.numMaxPalletQnt.Location = new System.Drawing.Point(151, 211);
			this.numMaxPalletQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numMaxPalletQnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numMaxPalletQnt.Name = "numMaxPalletQnt";
			this.numMaxPalletQnt.Size = new System.Drawing.Size(106, 22);
			this.numMaxPalletQnt.TabIndex = 28;
			this.numMaxPalletQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMaxPalletQnt.ValueChanged += new System.EventHandler(this.numMaxPalletQnt_ValueChanged);
			// 
			// lblMaxPalletQntX
			// 
			this.lblMaxPalletQntX.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblMaxPalletQntX.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblMaxPalletQntX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMaxPalletQntX.Location = new System.Drawing.Point(6, 194);
			this.lblMaxPalletQntX.Name = "lblMaxPalletQntX";
			this.lblMaxPalletQntX.Size = new System.Drawing.Size(222, 14);
			this.lblMaxPalletQntX.TabIndex = 25;
			this.lblMaxPalletQntX.Text = "ћаксимальное количество поддонов:";
			// 
			// txtCellHeight
			// 
			this.txtCellHeight.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellHeight.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellHeight.Enabled = false;
			this.txtCellHeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtCellHeight.Location = new System.Drawing.Point(331, 158);
			this.txtCellHeight.Name = "txtCellHeight";
			this.txtCellHeight.Size = new System.Drawing.Size(150, 22);
			this.txtCellHeight.TabIndex = 24;
			// 
			// txtCellWidth
			// 
			this.txtCellWidth.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellWidth.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellWidth.Enabled = false;
			this.txtCellWidth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtCellWidth.Location = new System.Drawing.Point(331, 129);
			this.txtCellWidth.Name = "txtCellWidth";
			this.txtCellWidth.Size = new System.Drawing.Size(150, 22);
			this.txtCellWidth.TabIndex = 19;
			// 
			// txtMaxWeight
			// 
			this.txtMaxWeight.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtMaxWeight.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMaxWeight.Enabled = false;
			this.txtMaxWeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtMaxWeight.Location = new System.Drawing.Point(331, 100);
			this.txtMaxWeight.Name = "txtMaxWeight";
			this.txtMaxWeight.Size = new System.Drawing.Size(150, 22);
			this.txtMaxWeight.TabIndex = 14;
			// 
			// chkCellHeight
			// 
			this.chkCellHeight.AutoSize = true;
			this.chkCellHeight.Location = new System.Drawing.Point(130, 162);
			this.chkCellHeight.Name = "chkCellHeight";
			this.chkCellHeight.Size = new System.Drawing.Size(15, 14);
			this.chkCellHeight.TabIndex = 21;
			this.chkCellHeight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkCellHeight, "»зменить закрепление €чеек за товаром");
			this.chkCellHeight.UseVisualStyleBackColor = true;
			this.chkCellHeight.CheckedChanged += new System.EventHandler(this.chkCellHeight_CheckedChanged);
			// 
			// lblCellWidth1
			// 
			this.lblCellWidth1.AutoSize = true;
			this.lblCellWidth1.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellWidth1.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellWidth1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellWidth1.Location = new System.Drawing.Point(262, 133);
			this.lblCellWidth1.Name = "lblCellWidth1";
			this.lblCellWidth1.Size = new System.Drawing.Size(15, 14);
			this.lblCellWidth1.TabIndex = 18;
			this.lblCellWidth1.Text = "м";
			// 
			// numCellWidth
			// 
			this.numCellWidth.DecimalPlaces = 3;
			this.numCellWidth.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numCellWidth.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numCellWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numCellWidth.IsNull = false;
			this.numCellWidth.Location = new System.Drawing.Point(150, 129);
			this.numCellWidth.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numCellWidth.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numCellWidth.Name = "numCellWidth";
			this.numCellWidth.Size = new System.Drawing.Size(106, 22);
			this.numCellWidth.TabIndex = 17;
			this.numCellWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numCellWidth.ValueChanged += new System.EventHandler(this.numCellWidth_ValueChanged);
			// 
			// lblCellWidth
			// 
			this.lblCellWidth.AutoSize = true;
			this.lblCellWidth.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellWidth.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellWidth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellWidth.Location = new System.Drawing.Point(6, 133);
			this.lblCellWidth.Name = "lblCellWidth";
			this.lblCellWidth.Size = new System.Drawing.Size(96, 14);
			this.lblCellWidth.TabIndex = 15;
			this.lblCellWidth.Text = "Ўирина €чейки";
			// 
			// lblCellHeight1
			// 
			this.lblCellHeight1.AutoSize = true;
			this.lblCellHeight1.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellHeight1.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellHeight1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellHeight1.Location = new System.Drawing.Point(262, 162);
			this.lblCellHeight1.Name = "lblCellHeight1";
			this.lblCellHeight1.Size = new System.Drawing.Size(15, 14);
			this.lblCellHeight1.TabIndex = 23;
			this.lblCellHeight1.Text = "м";
			// 
			// numCellHeight
			// 
			this.numCellHeight.DecimalPlaces = 3;
			this.numCellHeight.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numCellHeight.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numCellHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numCellHeight.IsNull = false;
			this.numCellHeight.Location = new System.Drawing.Point(150, 158);
			this.numCellHeight.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numCellHeight.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numCellHeight.Name = "numCellHeight";
			this.numCellHeight.Size = new System.Drawing.Size(106, 22);
			this.numCellHeight.TabIndex = 22;
			this.numCellHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numCellHeight.ValueChanged += new System.EventHandler(this.numCellHeight_ValueChanged);
			// 
			// lblCellHeight
			// 
			this.lblCellHeight.AutoSize = true;
			this.lblCellHeight.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellHeight.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellHeight.Location = new System.Drawing.Point(6, 161);
			this.lblCellHeight.Name = "lblCellHeight";
			this.lblCellHeight.Size = new System.Drawing.Size(92, 14);
			this.lblCellHeight.TabIndex = 20;
			this.lblCellHeight.Text = "¬ысота €чейки";
			// 
			// lblMaxWeight1
			// 
			this.lblMaxWeight1.AutoSize = true;
			this.lblMaxWeight1.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblMaxWeight1.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblMaxWeight1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMaxWeight1.Location = new System.Drawing.Point(262, 104);
			this.lblMaxWeight1.Name = "lblMaxWeight1";
			this.lblMaxWeight1.Size = new System.Drawing.Size(18, 14);
			this.lblMaxWeight1.TabIndex = 13;
			this.lblMaxWeight1.Text = "кг";
			// 
			// numMaxWeight
			// 
			this.numMaxWeight.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numMaxWeight.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numMaxWeight.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numMaxWeight.IsNull = false;
			this.numMaxWeight.Location = new System.Drawing.Point(150, 100);
			this.numMaxWeight.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numMaxWeight.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numMaxWeight.Name = "numMaxWeight";
			this.numMaxWeight.Size = new System.Drawing.Size(106, 22);
			this.numMaxWeight.TabIndex = 12;
			this.numMaxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numMaxWeight.ValueChanged += new System.EventHandler(this.numMaxWeight_ValueChanged);
			// 
			// btnPalletsTypesClear
			// 
			this.btnPalletsTypesClear.FlatAppearance.BorderSize = 0;
			this.btnPalletsTypesClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPalletsTypesClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnPalletsTypesClear.Location = new System.Drawing.Point(304, 69);
			this.btnPalletsTypesClear.Name = "btnPalletsTypesClear";
			this.btnPalletsTypesClear.Size = new System.Drawing.Size(25, 25);
			this.btnPalletsTypesClear.TabIndex = 8;
			this.ttToolTip.SetToolTip(this.btnPalletsTypesClear, "ќчистить закрепление €чейки за типом поддона");
			this.btnPalletsTypesClear.UseVisualStyleBackColor = true;
			this.btnPalletsTypesClear.Click += new System.EventHandler(this.btnPalletsTypesClear_Click);
			// 
			// chkCellWidth
			// 
			this.chkCellWidth.AutoSize = true;
			this.chkCellWidth.Location = new System.Drawing.Point(130, 133);
			this.chkCellWidth.Name = "chkCellWidth";
			this.chkCellWidth.Size = new System.Drawing.Size(15, 14);
			this.chkCellWidth.TabIndex = 16;
			this.chkCellWidth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkCellWidth, "»зменить закрепление €чеек за товаром");
			this.chkCellWidth.UseVisualStyleBackColor = true;
			this.chkCellWidth.CheckedChanged += new System.EventHandler(this.chkCellWidth_CheckedChanged);
			// 
			// chkPalletsTypes
			// 
			this.chkPalletsTypes.AutoSize = true;
			this.chkPalletsTypes.Location = new System.Drawing.Point(130, 75);
			this.chkPalletsTypes.Name = "chkPalletsTypes";
			this.chkPalletsTypes.Size = new System.Drawing.Size(15, 14);
			this.chkPalletsTypes.TabIndex = 6;
			this.chkPalletsTypes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkPalletsTypes, "»зменить закрепление €чеек за состо€нием товара");
			this.chkPalletsTypes.UseVisualStyleBackColor = true;
			this.chkPalletsTypes.CheckedChanged += new System.EventHandler(this.chkPalletsTypes_CheckedChanged);
			// 
			// chkMaxWeight
			// 
			this.chkMaxWeight.AutoSize = true;
			this.chkMaxWeight.Location = new System.Drawing.Point(130, 104);
			this.chkMaxWeight.Name = "chkMaxWeight";
			this.chkMaxWeight.Size = new System.Drawing.Size(15, 14);
			this.chkMaxWeight.TabIndex = 11;
			this.chkMaxWeight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkMaxWeight, "»зменить максимально допустимый вес");
			this.chkMaxWeight.UseVisualStyleBackColor = true;
			this.chkMaxWeight.CheckedChanged += new System.EventHandler(this.chkMaxWeight_CheckedChanged);
			// 
			// lblPalletsTypes
			// 
			this.lblPalletsTypes.AutoSize = true;
			this.lblPalletsTypes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPalletsTypes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPalletsTypes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletsTypes.Location = new System.Drawing.Point(6, 75);
			this.lblPalletsTypes.Name = "lblPalletsTypes";
			this.lblPalletsTypes.Size = new System.Drawing.Size(81, 14);
			this.lblPalletsTypes.TabIndex = 5;
			this.lblPalletsTypes.Text = "“ип поддона";
			// 
			// cboPalletsTypes
			// 
			this.cboPalletsTypes.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboPalletsTypes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboPalletsTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPalletsTypes.FormattingEnabled = true;
			this.cboPalletsTypes.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboPalletsTypes.Location = new System.Drawing.Point(150, 71);
			this.cboPalletsTypes.Name = "cboPalletsTypes";
			this.cboPalletsTypes.Size = new System.Drawing.Size(154, 22);
			this.cboPalletsTypes.TabIndex = 7;
			this.cboPalletsTypes.SelectedIndexChanged += new System.EventHandler(this.cboPalletsTypes_SelectedIndexChanged);
			// 
			// lblMaxWeight
			// 
			this.lblMaxWeight.AutoSize = true;
			this.lblMaxWeight.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblMaxWeight.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblMaxWeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMaxWeight.Location = new System.Drawing.Point(6, 104);
			this.lblMaxWeight.Name = "lblMaxWeight";
			this.lblMaxWeight.Size = new System.Drawing.Size(113, 14);
			this.lblMaxWeight.TabIndex = 10;
			this.lblMaxWeight.Text = "√рузоподъемность";
			this.ttToolTip.SetToolTip(this.lblMaxWeight, "ћаксимально допустимый вес");
			// 
			// txtCellID
			// 
			this.txtCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellID.Enabled = false;
			this.txtCellID.Location = new System.Drawing.Point(431, 8);
			this.txtCellID.Name = "txtCellID";
			this.txtCellID.Size = new System.Drawing.Size(50, 22);
			this.txtCellID.TabIndex = 4;
			// 
			// txtBarCode
			// 
			this.txtBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtBarCode.Enabled = false;
			this.txtBarCode.Location = new System.Drawing.Point(150, 8);
			this.txtBarCode.MaxLength = 16;
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtBarCode.TabIndex = 2;
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(6, 11);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(51, 14);
			this.lblCell.TabIndex = 0;
			this.lblCell.Text = "ячейка:";
			// 
			// frmCellsGeometryEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(507, 323);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "521");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsGeometryEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "ячейка: параметры (геометри€, грузоподъемность)";
			this.Load += new System.EventHandler(this.frmCellsGeometryEdit_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numStoreZoneMaxPalletQnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxPalletQnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCellWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCellHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWeight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMPanel pnlData;
        private RFMBaseClasses.RFMTextBox txtCellID;
        private RFMBaseClasses.RFMTextBoxBarCode txtBarCode;
        private RFMBaseClasses.RFMLabel lblCell;
        private RFMBaseClasses.RFMLabel lblPalletsTypes;
        private RFMBaseClasses.RFMComboBox cboPalletsTypes;
        private RFMBaseClasses.RFMLabel lblMaxWeight;
        private RFMBaseClasses.RFMCheckBox chkCellWidth;
        private RFMBaseClasses.RFMCheckBox chkPalletsTypes;
        private RFMBaseClasses.RFMCheckBox chkMaxWeight;
        private RFMBaseClasses.RFMButton btnPalletsTypesClear;
        private RFMBaseClasses.RFMNumericUpDown numMaxWeight;
        private RFMBaseClasses.RFMLabel lblCellWidth1;
        private RFMBaseClasses.RFMNumericUpDown numCellWidth;
        private RFMBaseClasses.RFMLabel lblCellWidth;
        private RFMBaseClasses.RFMLabel lblCellHeight1;
        private RFMBaseClasses.RFMNumericUpDown numCellHeight;
        private RFMBaseClasses.RFMLabel lblCellHeight;
        private RFMBaseClasses.RFMLabel lblMaxWeight1;
        private RFMBaseClasses.RFMCheckBox chkCellHeight;
        private RFMBaseClasses.RFMTextBox txtMaxWeight;
        private RFMBaseClasses.RFMTextBox txtCellHeight;
        private RFMBaseClasses.RFMTextBox txtCellWidth;
		private RFMBaseClasses.RFMCheckBox chkMaxPalletQnt;
		private RFMBaseClasses.RFMTextBox txtStoreZoneMaxPalletQnt;
		private RFMBaseClasses.RFMTextBox txtMaxPalletQnt;
		private RFMBaseClasses.RFMButton btnMaxPalletQntClear;
		private RFMBaseClasses.RFMLabel lblStoreZoneMaxPalletQnt;
		private RFMBaseClasses.RFMNumericUpDown numStoreZoneMaxPalletQnt;
		private RFMBaseClasses.RFMLabel lblMaxPalletQnt;
		private RFMBaseClasses.RFMNumericUpDown numMaxPalletQnt;
		private RFMBaseClasses.RFMLabel lblMaxPalletQntX;
		private RFMBaseClasses.RFMTextBox txtPalletsTypes;
		private RFMBaseClasses.RFMLabel lblCellID;
		private RFMBaseClasses.RFMLabel lblCellBarCode;
		private RFMBaseClasses.RFMLabel lblAddress;
		private RFMBaseClasses.RFMTextBox txtAddress;
	}
}