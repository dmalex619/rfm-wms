namespace WMSSuitable
{
	partial class frmCellsFixedEdit
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
			this.txtPackingAlias = new RFMBaseClasses.RFMTextBox();
			this.lblAddress = new RFMBaseClasses.RFMLabel();
			this.txtAddress = new RFMBaseClasses.RFMTextBox();
			this.txtPackings = new RFMBaseClasses.RFMTextBox();
			this.txtGoodsStates = new RFMBaseClasses.RFMTextBox();
			this.lblCellID = new RFMBaseClasses.RFMLabel();
			this.lblCellBarCode = new RFMBaseClasses.RFMLabel();
			this.txtOwners = new RFMBaseClasses.RFMTextBox();
			this.txtCellID = new RFMBaseClasses.RFMTextBox();
			this.txtBarCode = new RFMBaseClasses.RFMTextBox();
			this.btnPackingsClear = new RFMBaseClasses.RFMButton();
			this.btnGoodsStatesClear = new RFMBaseClasses.RFMButton();
			this.btnOwnersClear = new RFMBaseClasses.RFMButton();
			this.chkPackings = new RFMBaseClasses.RFMCheckBox();
			this.chkGoodsStates = new RFMBaseClasses.RFMCheckBox();
			this.chkOwners = new RFMBaseClasses.RFMCheckBox();
			this.cboPackings = new RFMBaseClasses.RFMComboBox();
			this.btnPackingsChoose = new RFMBaseClasses.RFMButton();
			this.lblPackings = new RFMBaseClasses.RFMLabel();
			this.cboGoodsStates = new RFMBaseClasses.RFMComboBox();
			this.lblGoodsStates = new RFMBaseClasses.RFMLabel();
			this.cboOwners = new RFMBaseClasses.RFMComboBox();
			this.lblOwner = new RFMBaseClasses.RFMLabel();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.pnlData.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(479, 199);
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
			this.btnSave.Location = new System.Drawing.Point(429, 199);
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
			this.btnHelp.Location = new System.Drawing.Point(6, 199);
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
			this.pnlData.Controls.Add(this.txtPackingAlias);
			this.pnlData.Controls.Add(this.lblAddress);
			this.pnlData.Controls.Add(this.txtAddress);
			this.pnlData.Controls.Add(this.txtPackings);
			this.pnlData.Controls.Add(this.txtGoodsStates);
			this.pnlData.Controls.Add(this.lblCellID);
			this.pnlData.Controls.Add(this.lblCellBarCode);
			this.pnlData.Controls.Add(this.txtOwners);
			this.pnlData.Controls.Add(this.txtCellID);
			this.pnlData.Controls.Add(this.txtBarCode);
			this.pnlData.Controls.Add(this.btnPackingsClear);
			this.pnlData.Controls.Add(this.btnGoodsStatesClear);
			this.pnlData.Controls.Add(this.btnOwnersClear);
			this.pnlData.Controls.Add(this.chkPackings);
			this.pnlData.Controls.Add(this.chkGoodsStates);
			this.pnlData.Controls.Add(this.chkOwners);
			this.pnlData.Controls.Add(this.cboPackings);
			this.pnlData.Controls.Add(this.btnPackingsChoose);
			this.pnlData.Controls.Add(this.lblPackings);
			this.pnlData.Controls.Add(this.cboGoodsStates);
			this.pnlData.Controls.Add(this.lblGoodsStates);
			this.pnlData.Controls.Add(this.cboOwners);
			this.pnlData.Controls.Add(this.lblOwner);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Location = new System.Drawing.Point(6, 7);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(503, 185);
			this.pnlData.TabIndex = 4;
			// 
			// txtPackingAlias
			// 
			this.txtPackingAlias.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPackingAlias.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackingAlias.Enabled = false;
			this.txtPackingAlias.Location = new System.Drawing.Point(142, 123);
			this.txtPackingAlias.Name = "txtPackingAlias";
			this.txtPackingAlias.Size = new System.Drawing.Size(330, 22);
			this.txtPackingAlias.TabIndex = 54;
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAddress.Location = new System.Drawing.Point(97, 37);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(42, 14);
			this.lblAddress.TabIndex = 53;
			this.lblAddress.Text = "јдрес";
			// 
			// txtAddress
			// 
			this.txtAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAddress.Enabled = false;
			this.txtAddress.Location = new System.Drawing.Point(142, 34);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(172, 22);
			this.txtAddress.TabIndex = 52;
			// 
			// txtPackings
			// 
			this.txtPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackings.Enabled = false;
			this.txtPackings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtPackings.Location = new System.Drawing.Point(341, 151);
			this.txtPackings.Name = "txtPackings";
			this.txtPackings.Size = new System.Drawing.Size(150, 22);
			this.txtPackings.TabIndex = 22;
			// 
			// txtGoodsStates
			// 
			this.txtGoodsStates.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodsStates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodsStates.Enabled = false;
			this.txtGoodsStates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtGoodsStates.Location = new System.Drawing.Point(341, 95);
			this.txtGoodsStates.Name = "txtGoodsStates";
			this.txtGoodsStates.Size = new System.Drawing.Size(150, 22);
			this.txtGoodsStates.TabIndex = 21;
			// 
			// lblCellID
			// 
			this.lblCellID.AutoSize = true;
			this.lblCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellID.Location = new System.Drawing.Point(410, 11);
			this.lblCellID.Name = "lblCellID";
			this.lblCellID.Size = new System.Drawing.Size(28, 14);
			this.lblCellID.TabIndex = 18;
			this.lblCellID.Text = " од";
			this.ttToolTip.SetToolTip(this.lblCellID, "”никальный код €чейки");
			// 
			// lblCellBarCode
			// 
			this.lblCellBarCode.AutoSize = true;
			this.lblCellBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellBarCode.Location = new System.Drawing.Point(115, 11);
			this.lblCellBarCode.Name = "lblCellBarCode";
			this.lblCellBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblCellBarCode.TabIndex = 16;
			this.lblCellBarCode.Text = "Ў ";
			// 
			// txtOwners
			// 
			this.txtOwners.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwners.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwners.Enabled = false;
			this.txtOwners.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtOwners.Location = new System.Drawing.Point(341, 67);
			this.txtOwners.Name = "txtOwners";
			this.txtOwners.Size = new System.Drawing.Size(150, 22);
			this.txtOwners.TabIndex = 20;
			// 
			// txtCellID
			// 
			this.txtCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellID.Enabled = false;
			this.txtCellID.Location = new System.Drawing.Point(441, 8);
			this.txtCellID.Name = "txtCellID";
			this.txtCellID.Size = new System.Drawing.Size(50, 22);
			this.txtCellID.TabIndex = 19;
			// 
			// txtBarCode
			// 
			this.txtBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtBarCode.Enabled = false;
			this.txtBarCode.Location = new System.Drawing.Point(142, 8);
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtBarCode.TabIndex = 17;
			// 
			// btnPackingsClear
			// 
			this.btnPackingsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPackingsClear.FlatAppearance.BorderSize = 0;
			this.btnPackingsClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPackingsClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnPackingsClear.Location = new System.Drawing.Point(471, 121);
			this.btnPackingsClear.Name = "btnPackingsClear";
			this.btnPackingsClear.Size = new System.Drawing.Size(25, 25);
			this.btnPackingsClear.TabIndex = 15;
			this.ttToolTip.SetToolTip(this.btnPackingsClear, "ќчистить закрепление €чейки за товаром");
			this.btnPackingsClear.UseVisualStyleBackColor = true;
			this.btnPackingsClear.Click += new System.EventHandler(this.btnPackingsClear_Click);
			// 
			// btnGoodsStatesClear
			// 
			this.btnGoodsStatesClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGoodsStatesClear.FlatAppearance.BorderSize = 0;
			this.btnGoodsStatesClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGoodsStatesClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnGoodsStatesClear.Location = new System.Drawing.Point(314, 92);
			this.btnGoodsStatesClear.Name = "btnGoodsStatesClear";
			this.btnGoodsStatesClear.Size = new System.Drawing.Size(25, 25);
			this.btnGoodsStatesClear.TabIndex = 10;
			this.ttToolTip.SetToolTip(this.btnGoodsStatesClear, "ќчистить закрепление €чейки за состо€нием товара");
			this.btnGoodsStatesClear.UseVisualStyleBackColor = true;
			this.btnGoodsStatesClear.Click += new System.EventHandler(this.btnGoodsStatesClear_Click);
			// 
			// btnOwnersClear
			// 
			this.btnOwnersClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOwnersClear.FlatAppearance.BorderSize = 0;
			this.btnOwnersClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOwnersClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnOwnersClear.Location = new System.Drawing.Point(314, 65);
			this.btnOwnersClear.Name = "btnOwnersClear";
			this.btnOwnersClear.Size = new System.Drawing.Size(25, 25);
			this.btnOwnersClear.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.btnOwnersClear, "ќчистить закрепление €чейки за хранителем");
			this.btnOwnersClear.UseVisualStyleBackColor = true;
			this.btnOwnersClear.Click += new System.EventHandler(this.btnOwnersClear_Click);
			// 
			// chkPackings
			// 
			this.chkPackings.AutoSize = true;
			this.chkPackings.Location = new System.Drawing.Point(122, 127);
			this.chkPackings.Name = "chkPackings";
			this.chkPackings.Size = new System.Drawing.Size(15, 14);
			this.chkPackings.TabIndex = 13;
			this.chkPackings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkPackings, "»зменить закрепление €чеек за товаром");
			this.chkPackings.UseVisualStyleBackColor = true;
			this.chkPackings.CheckedChanged += new System.EventHandler(this.chkPackings_CheckedChanged);
			// 
			// chkGoodsStates
			// 
			this.chkGoodsStates.AutoSize = true;
			this.chkGoodsStates.Location = new System.Drawing.Point(122, 99);
			this.chkGoodsStates.Name = "chkGoodsStates";
			this.chkGoodsStates.Size = new System.Drawing.Size(15, 14);
			this.chkGoodsStates.TabIndex = 8;
			this.chkGoodsStates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkGoodsStates, "»зменить закрепление €чеек за состо€нием товара");
			this.chkGoodsStates.UseVisualStyleBackColor = true;
			this.chkGoodsStates.CheckedChanged += new System.EventHandler(this.chkGoodsStates_CheckedChanged);
			// 
			// chkOwners
			// 
			this.chkOwners.AutoSize = true;
			this.chkOwners.Location = new System.Drawing.Point(122, 70);
			this.chkOwners.Name = "chkOwners";
			this.chkOwners.Size = new System.Drawing.Size(15, 14);
			this.chkOwners.TabIndex = 4;
			this.chkOwners.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkOwners, "»зменить закрепление €чеек за хранителем");
			this.chkOwners.UseVisualStyleBackColor = true;
			this.chkOwners.CheckedChanged += new System.EventHandler(this.chkOwners_CheckedChanged);
			// 
			// cboPackings
			// 
			this.cboPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboPackings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPackings.Enabled = false;
			this.cboPackings.FormattingEnabled = true;
			this.cboPackings.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboPackings.Location = new System.Drawing.Point(142, 127);
			this.cboPackings.Name = "cboPackings";
			this.cboPackings.Size = new System.Drawing.Size(330, 22);
			this.cboPackings.TabIndex = 14;
			this.cboPackings.Visible = false;
			this.cboPackings.SelectedIndexChanged += new System.EventHandler(this.cboPackings_SelectedIndexChanged);
			// 
			// btnPackingsChoose
			// 
			this.btnPackingsChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackingsChoose.Location = new System.Drawing.Point(84, 118);
			this.btnPackingsChoose.Name = "btnPackingsChoose";
			this.btnPackingsChoose.Size = new System.Drawing.Size(30, 30);
			this.btnPackingsChoose.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.btnPackingsChoose, "¬ыбор товара");
			this.btnPackingsChoose.UseVisualStyleBackColor = true;
			this.btnPackingsChoose.Click += new System.EventHandler(this.btnPackingsChoose_Click);
			// 
			// lblPackings
			// 
			this.lblPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPackings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPackings.Location = new System.Drawing.Point(6, 126);
			this.lblPackings.Name = "lblPackings";
			this.lblPackings.Size = new System.Drawing.Size(61, 15);
			this.lblPackings.TabIndex = 11;
			this.lblPackings.Text = "“овары";
			// 
			// cboGoodsStates
			// 
			this.cboGoodsStates.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGoodsStates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGoodsStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGoodsStates.FormattingEnabled = true;
			this.cboGoodsStates.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGoodsStates.Location = new System.Drawing.Point(142, 95);
			this.cboGoodsStates.Name = "cboGoodsStates";
			this.cboGoodsStates.Size = new System.Drawing.Size(172, 22);
			this.cboGoodsStates.TabIndex = 9;
			this.cboGoodsStates.SelectedIndexChanged += new System.EventHandler(this.cboGoodsStates_SelectedIndexChanged);
			// 
			// lblGoodsStates
			// 
			this.lblGoodsStates.AutoSize = true;
			this.lblGoodsStates.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodsStates.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodsStates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodsStates.Location = new System.Drawing.Point(6, 98);
			this.lblGoodsStates.Name = "lblGoodsStates";
			this.lblGoodsStates.Size = new System.Drawing.Size(110, 14);
			this.lblGoodsStates.TabIndex = 7;
			this.lblGoodsStates.Text = "—осто€ние товара";
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
			this.cboOwners.Location = new System.Drawing.Point(142, 67);
			this.cboOwners.Name = "cboOwners";
			this.cboOwners.Size = new System.Drawing.Size(172, 22);
			this.cboOwners.TabIndex = 5;
			this.cboOwners.SelectedIndexChanged += new System.EventHandler(this.cboOwners_SelectedIndexChanged);
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwner.Location = new System.Drawing.Point(6, 70);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(67, 14);
			this.lblOwner.TabIndex = 3;
			this.lblOwner.Text = "’ранитель";
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(6, 11);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(47, 14);
			this.lblCell.TabIndex = 0;
			this.lblCell.Text = "ячейка";
			// 
			// frmCellsFixedEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(516, 235);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "522");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsFixedEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "ячейка: фиксированные закреплени€";
			this.Load += new System.EventHandler(this.frmCellsFixedEdit_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
        private RFMBaseClasses.RFMLabel lblCell;
        private RFMBaseClasses.RFMComboBox cboGoodsStates;
        private RFMBaseClasses.RFMLabel lblGoodsStates;
        private RFMBaseClasses.RFMComboBox cboOwners;
        private RFMBaseClasses.RFMLabel lblOwner;
        private RFMBaseClasses.RFMButton btnPackingsChoose;
        private RFMBaseClasses.RFMLabel lblPackings;
        private RFMBaseClasses.RFMComboBox cboPackings;
        private RFMBaseClasses.RFMCheckBox chkPackings;
        private RFMBaseClasses.RFMCheckBox chkGoodsStates;
        private RFMBaseClasses.RFMCheckBox chkOwners;
        private RFMBaseClasses.RFMButton btnOwnersClear;
        private RFMBaseClasses.RFMButton btnPackingsClear;
        private RFMBaseClasses.RFMButton btnGoodsStatesClear;
		private RFMBaseClasses.RFMTextBox txtPackings;
		private RFMBaseClasses.RFMTextBox txtGoodsStates;
		private RFMBaseClasses.RFMLabel lblCellID;
		private RFMBaseClasses.RFMLabel lblCellBarCode;
		private RFMBaseClasses.RFMTextBox txtOwners;
		private RFMBaseClasses.RFMTextBox txtCellID;
		private RFMBaseClasses.RFMTextBox txtBarCode;
		private RFMBaseClasses.RFMLabel lblAddress;
		private RFMBaseClasses.RFMTextBox txtAddress;
		private RFMBaseClasses.RFMTextBox txtPackingAlias;
	}
}