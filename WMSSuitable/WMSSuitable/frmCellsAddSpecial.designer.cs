namespace WMSSuitable
{
	partial class frmCellsAddSpecial
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
            this.pnlData = new RFMBaseClasses.RFMPanel();
            this.lblAddressMask = new RFMBaseClasses.RFMLabel();
            this.cboCPlace = new RFMBaseClasses.RFMComboBox();
            this.cboCLevel = new RFMBaseClasses.RFMComboBox();
            this.cboCRack = new RFMBaseClasses.RFMComboBox();
            this.cboCLine = new RFMBaseClasses.RFMComboBox();
            this.cboCBuilding = new RFMBaseClasses.RFMComboBox();
            this.txtCPlace = new RFMBaseClasses.RFMTextBox();
            this.lblCPlace = new RFMBaseClasses.RFMLabel();
            this.txtCLevel = new RFMBaseClasses.RFMTextBox();
            this.lblCLevel = new RFMBaseClasses.RFMLabel();
            this.txtCRack = new RFMBaseClasses.RFMTextBox();
            this.lblCRack = new RFMBaseClasses.RFMLabel();
            this.txtCLine = new RFMBaseClasses.RFMTextBox();
            this.lblCLine = new RFMBaseClasses.RFMLabel();
            this.txtCBuilding = new RFMBaseClasses.RFMTextBox();
            this.lblCBuilding = new RFMBaseClasses.RFMLabel();
            this.btnAddressBuild = new RFMBaseClasses.RFMButton();
            this.lblAddress = new RFMBaseClasses.RFMLabel();
            this.chkAddressManual = new RFMBaseClasses.RFMCheckBox();
            this.txtAddress = new RFMBaseClasses.RFMTextBox();
            this.lblStoresZonesTypes = new RFMBaseClasses.RFMLabel();
            this.cboStoresZonesTypes = new RFMBaseClasses.RFMComboBox();
            this.lblStoresZones = new RFMBaseClasses.RFMLabel();
            this.cboStoresZones = new RFMBaseClasses.RFMComboBox();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.btnSave = new RFMBaseClasses.RFMButton();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.lblAddressMask);
            this.pnlData.Controls.Add(this.cboCPlace);
            this.pnlData.Controls.Add(this.cboCLevel);
            this.pnlData.Controls.Add(this.cboCRack);
            this.pnlData.Controls.Add(this.cboCLine);
            this.pnlData.Controls.Add(this.cboCBuilding);
            this.pnlData.Controls.Add(this.txtCPlace);
            this.pnlData.Controls.Add(this.lblCPlace);
            this.pnlData.Controls.Add(this.txtCLevel);
            this.pnlData.Controls.Add(this.lblCLevel);
            this.pnlData.Controls.Add(this.txtCRack);
            this.pnlData.Controls.Add(this.lblCRack);
            this.pnlData.Controls.Add(this.txtCLine);
            this.pnlData.Controls.Add(this.lblCLine);
            this.pnlData.Controls.Add(this.txtCBuilding);
            this.pnlData.Controls.Add(this.lblCBuilding);
            this.pnlData.Controls.Add(this.btnAddressBuild);
            this.pnlData.Controls.Add(this.lblAddress);
            this.pnlData.Controls.Add(this.chkAddressManual);
            this.pnlData.Controls.Add(this.txtAddress);
            this.pnlData.Controls.Add(this.lblStoresZonesTypes);
            this.pnlData.Controls.Add(this.cboStoresZonesTypes);
            this.pnlData.Controls.Add(this.lblStoresZones);
            this.pnlData.Controls.Add(this.cboStoresZones);
            this.pnlData.Location = new System.Drawing.Point(6, 8);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(414, 174);
            this.pnlData.TabIndex = 4;
            // 
            // lblAddressMask
            // 
            this.lblAddressMask.AutoSize = true;
            this.lblAddressMask.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblAddressMask.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAddressMask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddressMask.Location = new System.Drawing.Point(299, 35);
            this.lblAddressMask.Name = "lblAddressMask";
            this.lblAddressMask.Size = new System.Drawing.Size(103, 14);
            this.lblAddressMask.TabIndex = 36;
            this.lblAddressMask.Text = "#�����_������#";
            this.ttToolTip.SetToolTip(this.lblAddressMask, "����� ������: B - ������, L - �����, R - �����, V - �������, C - ������");
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
            this.cboCPlace.Location = new System.Drawing.Point(350, 84);
            this.cboCPlace.Name = "cboCPlace";
            this.cboCPlace.Size = new System.Drawing.Size(52, 22);
            this.cboCPlace.TabIndex = 13;
            this.ttToolTip.SetToolTip(this.cboCPlace, "������ (������������) �� ������ (�����)");
            this.cboCPlace.SelectedIndexChanged += new System.EventHandler(this.cboCPlace_SelectedIndexChanged);
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
            this.cboCLevel.Location = new System.Drawing.Point(290, 84);
            this.cboCLevel.Name = "cboCLevel";
            this.cboCLevel.Size = new System.Drawing.Size(52, 22);
            this.cboCLevel.TabIndex = 12;
            this.ttToolTip.SetToolTip(this.cboCLevel, "������� (�����)");
            this.cboCLevel.SelectedIndexChanged += new System.EventHandler(this.cboCLevel_SelectedIndexChanged);
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
            this.cboCRack.Location = new System.Drawing.Point(230, 84);
            this.cboCRack.Name = "cboCRack";
            this.cboCRack.Size = new System.Drawing.Size(52, 22);
            this.cboCRack.TabIndex = 11;
            this.ttToolTip.SetToolTip(this.cboCRack, "����� (�����)");
            this.cboCRack.SelectedIndexChanged += new System.EventHandler(this.cboCRack_SelectedIndexChanged);
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
            this.cboCLine.Location = new System.Drawing.Point(170, 84);
            this.cboCLine.Name = "cboCLine";
            this.cboCLine.Size = new System.Drawing.Size(52, 22);
            this.cboCLine.TabIndex = 10;
            this.ttToolTip.SetToolTip(this.cboCLine, "����� (��������� ��������� �����)");
            this.cboCLine.SelectedIndexChanged += new System.EventHandler(this.cboCLine_SelectedIndexChanged);
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
            this.cboCBuilding.Location = new System.Drawing.Point(110, 84);
            this.cboCBuilding.Name = "cboCBuilding";
            this.cboCBuilding.Size = new System.Drawing.Size(52, 22);
            this.cboCBuilding.TabIndex = 9;
            this.ttToolTip.SetToolTip(this.cboCBuilding, "������ (������)");
            this.cboCBuilding.SelectedIndexChanged += new System.EventHandler(this.cboCBuilding_SelectedIndexChanged);
            // 
            // txtCPlace
            // 
            this.txtCPlace.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtCPlace.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCPlace.Location = new System.Drawing.Point(350, 111);
            this.txtCPlace.MaxLength = 10;
            this.txtCPlace.Name = "txtCPlace";
            this.txtCPlace.Size = new System.Drawing.Size(34, 22);
            this.txtCPlace.TabIndex = 18;
            this.ttToolTip.SetToolTip(this.txtCPlace, "������ (������������) �� ������ (�����)");
            this.txtCPlace.TextChanged += new System.EventHandler(this.txtCField_TextChanged);
            // 
            // lblCPlace
            // 
            this.lblCPlace.AutoSize = true;
            this.lblCPlace.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCPlace.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCPlace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCPlace.Location = new System.Drawing.Point(349, 68);
            this.lblCPlace.Name = "lblCPlace";
            this.lblCPlace.Size = new System.Drawing.Size(47, 14);
            this.lblCPlace.TabIndex = 8;
            this.lblCPlace.Text = "������";
            this.ttToolTip.SetToolTip(this.lblCPlace, "������ (������������) �� ������ (�����)");
            // 
            // txtCLevel
            // 
            this.txtCLevel.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtCLevel.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCLevel.Location = new System.Drawing.Point(290, 111);
            this.txtCLevel.MaxLength = 10;
            this.txtCLevel.Name = "txtCLevel";
            this.txtCLevel.Size = new System.Drawing.Size(34, 22);
            this.txtCLevel.TabIndex = 17;
            this.ttToolTip.SetToolTip(this.txtCLevel, "������� (�����)");
            this.txtCLevel.TextChanged += new System.EventHandler(this.txtCField_TextChanged);
            // 
            // lblCLevel
            // 
            this.lblCLevel.AutoSize = true;
            this.lblCLevel.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCLevel.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCLevel.Location = new System.Drawing.Point(288, 68);
            this.lblCLevel.Name = "lblCLevel";
            this.lblCLevel.Size = new System.Drawing.Size(54, 14);
            this.lblCLevel.TabIndex = 7;
            this.lblCLevel.Text = "�������";
            this.ttToolTip.SetToolTip(this.lblCLevel, "������� (�����)");
            // 
            // txtCRack
            // 
            this.txtCRack.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtCRack.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCRack.Location = new System.Drawing.Point(230, 111);
            this.txtCRack.MaxLength = 10;
            this.txtCRack.Name = "txtCRack";
            this.txtCRack.Size = new System.Drawing.Size(34, 22);
            this.txtCRack.TabIndex = 16;
            this.ttToolTip.SetToolTip(this.txtCRack, "����� (�����)");
            this.txtCRack.TextChanged += new System.EventHandler(this.txtCField_TextChanged);
            // 
            // lblCRack
            // 
            this.lblCRack.AutoSize = true;
            this.lblCRack.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCRack.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCRack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCRack.Location = new System.Drawing.Point(229, 68);
            this.lblCRack.Name = "lblCRack";
            this.lblCRack.Size = new System.Drawing.Size(40, 14);
            this.lblCRack.TabIndex = 6;
            this.lblCRack.Text = "�����";
            this.ttToolTip.SetToolTip(this.lblCRack, "����� (�����)");
            // 
            // txtCLine
            // 
            this.txtCLine.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtCLine.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCLine.Location = new System.Drawing.Point(170, 111);
            this.txtCLine.MaxLength = 10;
            this.txtCLine.Name = "txtCLine";
            this.txtCLine.Size = new System.Drawing.Size(34, 22);
            this.txtCLine.TabIndex = 15;
            this.ttToolTip.SetToolTip(this.txtCLine, "����� (��������� ��������� �����)");
            this.txtCLine.TextChanged += new System.EventHandler(this.txtCField_TextChanged);
            // 
            // lblCLine
            // 
            this.lblCLine.AutoSize = true;
            this.lblCLine.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCLine.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCLine.Location = new System.Drawing.Point(169, 68);
            this.lblCLine.Name = "lblCLine";
            this.lblCLine.Size = new System.Drawing.Size(43, 14);
            this.lblCLine.TabIndex = 5;
            this.lblCLine.Text = "�����";
            this.ttToolTip.SetToolTip(this.lblCLine, "����� (��������� ��������� �����)");
            // 
            // txtCBuilding
            // 
            this.txtCBuilding.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtCBuilding.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCBuilding.Location = new System.Drawing.Point(110, 111);
            this.txtCBuilding.MaxLength = 10;
            this.txtCBuilding.Name = "txtCBuilding";
            this.txtCBuilding.Size = new System.Drawing.Size(34, 22);
            this.txtCBuilding.TabIndex = 14;
            this.ttToolTip.SetToolTip(this.txtCBuilding, "������ (������)");
            this.txtCBuilding.TextChanged += new System.EventHandler(this.txtCField_TextChanged);
            // 
            // lblCBuilding
            // 
            this.lblCBuilding.AutoSize = true;
            this.lblCBuilding.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblCBuilding.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCBuilding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCBuilding.Location = new System.Drawing.Point(109, 68);
            this.lblCBuilding.Name = "lblCBuilding";
            this.lblCBuilding.Size = new System.Drawing.Size(47, 14);
            this.lblCBuilding.TabIndex = 4;
            this.lblCBuilding.Text = "������";
            this.ttToolTip.SetToolTip(this.lblCBuilding, "������ (������)");
            // 
            // btnAddressBuild
            // 
            this.btnAddressBuild.FlatAppearance.BorderSize = 0;
            this.btnAddressBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddressBuild.Image = global::WMSSuitable.Properties.Resources.Refresh;
            this.btnAddressBuild.Location = new System.Drawing.Point(83, 137);
            this.btnAddressBuild.Name = "btnAddressBuild";
            this.btnAddressBuild.Size = new System.Drawing.Size(25, 25);
            this.btnAddressBuild.TabIndex = 20;
            this.ttToolTip.SetToolTip(this.btnAddressBuild, "��������� ����� �� ������������");
            this.btnAddressBuild.Click += new System.EventHandler(this.btnAddressBuild_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddress.Location = new System.Drawing.Point(10, 142);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(42, 14);
            this.lblAddress.TabIndex = 19;
            this.lblAddress.Text = "�����";
            // 
            // chkAddressManual
            // 
            this.chkAddressManual.AutoSize = true;
            this.chkAddressManual.Location = new System.Drawing.Point(289, 141);
            this.chkAddressManual.Name = "chkAddressManual";
            this.chkAddressManual.Size = new System.Drawing.Size(116, 18);
            this.chkAddressManual.TabIndex = 22;
            this.chkAddressManual.Text = "�������� �����";
            this.chkAddressManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.chkAddressManual, "�������� ����� ������");
            this.chkAddressManual.CheckedChanged += new System.EventHandler(this.chkAddressManual_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.Location = new System.Drawing.Point(110, 139);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(172, 22);
            this.txtAddress.TabIndex = 21;
            // 
            // lblStoresZonesTypes
            // 
            this.lblStoresZonesTypes.AutoSize = true;
            this.lblStoresZonesTypes.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStoresZonesTypes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStoresZonesTypes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStoresZonesTypes.Location = new System.Drawing.Point(10, 38);
            this.lblStoresZonesTypes.Name = "lblStoresZonesTypes";
            this.lblStoresZonesTypes.Size = new System.Drawing.Size(60, 14);
            this.lblStoresZonesTypes.TabIndex = 2;
            this.lblStoresZonesTypes.Text = "��� ����";
            // 
            // cboStoresZonesTypes
            // 
            this.cboStoresZonesTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStoresZonesTypes.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboStoresZonesTypes.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboStoresZonesTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStoresZonesTypes.FormattingEnabled = true;
            this.cboStoresZonesTypes.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboStoresZonesTypes.Location = new System.Drawing.Point(110, 35);
            this.cboStoresZonesTypes.Name = "cboStoresZonesTypes";
            this.cboStoresZonesTypes.Size = new System.Drawing.Size(172, 22);
            this.cboStoresZonesTypes.TabIndex = 3;
            // 
            // lblStoresZones
            // 
            this.lblStoresZones.AutoSize = true;
            this.lblStoresZones.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblStoresZones.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblStoresZones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStoresZones.Location = new System.Drawing.Point(10, 13);
            this.lblStoresZones.Name = "lblStoresZones";
            this.lblStoresZones.Size = new System.Drawing.Size(94, 14);
            this.lblStoresZones.TabIndex = 0;
            this.lblStoresZones.Text = "��������� ����";
            // 
            // cboStoresZones
            // 
            this.cboStoresZones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStoresZones.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboStoresZones.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboStoresZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStoresZones.FormattingEnabled = true;
            this.cboStoresZones.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboStoresZones.Location = new System.Drawing.Point(110, 10);
            this.cboStoresZones.Name = "cboStoresZones";
            this.cboStoresZones.Size = new System.Drawing.Size(172, 22);
            this.cboStoresZones.TabIndex = 1;
            this.cboStoresZones.SelectedIndexChanged += new System.EventHandler(this.cboStoresZones_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(6, 189);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnCancel.Location = new System.Drawing.Point(390, 189);
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
            this.btnSave.Location = new System.Drawing.Point(340, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCellsAddSpecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(427, 225);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.hpHelp.SetHelpKeyword(this, "512");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.Name = "frmCellsAddSpecial";
            this.hpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "���������� ����� ������";
            this.Load += new System.EventHandler(this.frmCellsSpecialEdit_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
        private RFMBaseClasses.RFMLabel lblStoresZones;
		private RFMBaseClasses.RFMComboBox cboStoresZones;
        private RFMBaseClasses.RFMLabel lblStoresZonesTypes;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypes;
		private RFMBaseClasses.RFMButton btnAddressBuild;
		private RFMBaseClasses.RFMLabel lblAddress;
		private RFMBaseClasses.RFMCheckBox chkAddressManual;
		private RFMBaseClasses.RFMTextBox txtAddress;
		private RFMBaseClasses.RFMComboBox cboCPlace;
		private RFMBaseClasses.RFMComboBox cboCLevel;
		private RFMBaseClasses.RFMComboBox cboCRack;
		private RFMBaseClasses.RFMComboBox cboCLine;
		private RFMBaseClasses.RFMComboBox cboCBuilding;
		private RFMBaseClasses.RFMTextBox txtCPlace;
		private RFMBaseClasses.RFMLabel lblCPlace;
		private RFMBaseClasses.RFMTextBox txtCLevel;
		private RFMBaseClasses.RFMLabel lblCLevel;
		private RFMBaseClasses.RFMTextBox txtCRack;
		private RFMBaseClasses.RFMLabel lblCRack;
		private RFMBaseClasses.RFMTextBox txtCLine;
		private RFMBaseClasses.RFMLabel lblCLine;
		private RFMBaseClasses.RFMTextBox txtCBuilding;
		private RFMBaseClasses.RFMLabel lblCBuilding;
		private RFMBaseClasses.RFMLabel lblAddressMask;
	}
}