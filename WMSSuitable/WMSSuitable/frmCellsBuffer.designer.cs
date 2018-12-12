namespace WMSSuitable
{
	partial class frmCellsBuffer
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
			this.lblBarCode = new RFMBaseClasses.RFMLabel();
			this.txtBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
			this.lblAddress = new RFMBaseClasses.RFMLabel();
			this.lblBuffer = new RFMBaseClasses.RFMLabel();
			this.pnlBuffer = new RFMBaseClasses.RFMPanel();
			this.txtCellBuffer = new RFMBaseClasses.RFMTextBox();
			this.btnCellBufferClear = new RFMBaseClasses.RFMButton();
			this.cboStoresZonesBuffer = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesTypesBuffer = new RFMBaseClasses.RFMLabel();
			this.cboStoresZonesTypesBuffer = new RFMBaseClasses.RFMComboBox();
			this.lblStoresZonesBuffer = new RFMBaseClasses.RFMLabel();
			this.cboCellAddressBuffer = new RFMBaseClasses.RFMComboBox();
			this.lblCellsBuffer = new RFMBaseClasses.RFMLabel();
			this.lblID = new RFMBaseClasses.RFMLabel();
			this.txtCellID = new RFMBaseClasses.RFMTextBox();
			this.txtAddress = new RFMBaseClasses.RFMTextBox();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.chkCellsBuffersUpdate = new RFMBaseClasses.RFMCheckBox();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.pnlData.SuspendLayout();
			this.pnlBuffer.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblBarCode);
			this.pnlData.Controls.Add(this.txtBarCode);
			this.pnlData.Controls.Add(this.lblAddress);
			this.pnlData.Controls.Add(this.lblBuffer);
			this.pnlData.Controls.Add(this.pnlBuffer);
			this.pnlData.Controls.Add(this.lblID);
			this.pnlData.Controls.Add(this.txtCellID);
			this.pnlData.Controls.Add(this.txtAddress);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Controls.Add(this.chkCellsBuffersUpdate);
			this.pnlData.Location = new System.Drawing.Point(6, 7);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(456, 197);
			this.pnlData.TabIndex = 1;
			// 
			// lblBarCode
			// 
			this.lblBarCode.AutoSize = true;
			this.lblBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBarCode.Location = new System.Drawing.Point(99, 11);
			this.lblBarCode.Name = "lblBarCode";
			this.lblBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblBarCode.TabIndex = 51;
			this.lblBarCode.Text = "ШК";
			this.ttToolTip.SetToolTip(this.lblBarCode, "Штрих-код");
			// 
			// txtBarCode
			// 
			this.txtBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtBarCode.Enabled = false;
			this.txtBarCode.Location = new System.Drawing.Point(126, 8);
			this.txtBarCode.MaxLength = 16;
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtBarCode.TabIndex = 50;
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAddress.Location = new System.Drawing.Point(81, 37);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(42, 14);
			this.lblAddress.TabIndex = 49;
			this.lblAddress.Text = "Адрес";
			// 
			// lblBuffer
			// 
			this.lblBuffer.AutoSize = true;
			this.lblBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBuffer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBuffer.Location = new System.Drawing.Point(8, 63);
			this.lblBuffer.Name = "lblBuffer";
			this.lblBuffer.Size = new System.Drawing.Size(108, 14);
			this.lblBuffer.TabIndex = 48;
			this.lblBuffer.Text = "Буферная ячейка";
			// 
			// pnlBuffer
			// 
			this.pnlBuffer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlBuffer.Controls.Add(this.txtCellBuffer);
			this.pnlBuffer.Controls.Add(this.btnCellBufferClear);
			this.pnlBuffer.Controls.Add(this.cboStoresZonesBuffer);
			this.pnlBuffer.Controls.Add(this.lblStoresZonesTypesBuffer);
			this.pnlBuffer.Controls.Add(this.cboStoresZonesTypesBuffer);
			this.pnlBuffer.Controls.Add(this.lblStoresZonesBuffer);
			this.pnlBuffer.Controls.Add(this.cboCellAddressBuffer);
			this.pnlBuffer.Controls.Add(this.lblCellsBuffer);
			this.pnlBuffer.Location = new System.Drawing.Point(6, 73);
			this.pnlBuffer.Name = "pnlBuffer";
			this.pnlBuffer.Size = new System.Drawing.Size(441, 90);
			this.pnlBuffer.TabIndex = 47;
			// 
			// txtCellBuffer
			// 
			this.txtCellBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellBuffer.Enabled = false;
			this.txtCellBuffer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtCellBuffer.Location = new System.Drawing.Point(292, 58);
			this.txtCellBuffer.Name = "txtCellBuffer";
			this.txtCellBuffer.Size = new System.Drawing.Size(139, 22);
			this.txtCellBuffer.TabIndex = 55;
			// 
			// btnCellBufferClear
			// 
			this.btnCellBufferClear.FlatAppearance.BorderSize = 0;
			this.btnCellBufferClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCellBufferClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnCellBufferClear.Location = new System.Drawing.Point(91, 58);
			this.btnCellBufferClear.Name = "btnCellBufferClear";
			this.btnCellBufferClear.Size = new System.Drawing.Size(25, 25);
			this.btnCellBufferClear.TabIndex = 54;
			this.ttToolTip.SetToolTip(this.btnCellBufferClear, "Очистить назначенную буферную ячейку");
			this.btnCellBufferClear.UseVisualStyleBackColor = true;
			this.btnCellBufferClear.Click += new System.EventHandler(this.btnCellBufferClear_Click);
			// 
			// cboStoresZonesBuffer
			// 
			this.cboStoresZonesBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesBuffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesBuffer.FormattingEnabled = true;
			this.cboStoresZonesBuffer.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesBuffer.Location = new System.Drawing.Point(118, 7);
			this.cboStoresZonesBuffer.Name = "cboStoresZonesBuffer";
			this.cboStoresZonesBuffer.Size = new System.Drawing.Size(313, 22);
			this.cboStoresZonesBuffer.TabIndex = 51;
			this.cboStoresZonesBuffer.SelectedIndexChanged += new System.EventHandler(this.cboStoresZonesBuffer_SelectedIndexChanged);
			// 
			// lblStoresZonesTypesBuffer
			// 
			this.lblStoresZonesTypesBuffer.AutoSize = true;
			this.lblStoresZonesTypesBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoresZonesTypesBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoresZonesTypesBuffer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesTypesBuffer.Location = new System.Drawing.Point(6, 36);
			this.lblStoresZonesTypesBuffer.Name = "lblStoresZonesTypesBuffer";
			this.lblStoresZonesTypesBuffer.Size = new System.Drawing.Size(60, 14);
			this.lblStoresZonesTypesBuffer.TabIndex = 52;
			this.lblStoresZonesTypesBuffer.Text = "Тип зоны";
			// 
			// cboStoresZonesTypesBuffer
			// 
			this.cboStoresZonesTypesBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboStoresZonesTypesBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboStoresZonesTypesBuffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStoresZonesTypesBuffer.FormattingEnabled = true;
			this.cboStoresZonesTypesBuffer.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboStoresZonesTypesBuffer.Location = new System.Drawing.Point(118, 32);
			this.cboStoresZonesTypesBuffer.Name = "cboStoresZonesTypesBuffer";
			this.cboStoresZonesTypesBuffer.Size = new System.Drawing.Size(313, 22);
			this.cboStoresZonesTypesBuffer.TabIndex = 27;
			// 
			// lblStoresZonesBuffer
			// 
			this.lblStoresZonesBuffer.AutoSize = true;
			this.lblStoresZonesBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblStoresZonesBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblStoresZonesBuffer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStoresZonesBuffer.Location = new System.Drawing.Point(6, 10);
			this.lblStoresZonesBuffer.Name = "lblStoresZonesBuffer";
			this.lblStoresZonesBuffer.Size = new System.Drawing.Size(94, 14);
			this.lblStoresZonesBuffer.TabIndex = 50;
			this.lblStoresZonesBuffer.Text = "Складская зона";
			// 
			// cboCellAddressBuffer
			// 
			this.cboCellAddressBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboCellAddressBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCellAddressBuffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCellAddressBuffer.FormattingEnabled = true;
			this.cboCellAddressBuffer.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboCellAddressBuffer.Location = new System.Drawing.Point(118, 58);
			this.cboCellAddressBuffer.Name = "cboCellAddressBuffer";
			this.cboCellAddressBuffer.Size = new System.Drawing.Size(172, 22);
			this.cboCellAddressBuffer.TabIndex = 48;
			this.cboCellAddressBuffer.SelectedIndexChanged += new System.EventHandler(this.cboCellAddressBuffer_SelectedIndexChanged);
			// 
			// lblCellsBuffer
			// 
			this.lblCellsBuffer.AutoSize = true;
			this.lblCellsBuffer.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellsBuffer.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellsBuffer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellsBuffer.Location = new System.Drawing.Point(6, 63);
			this.lblCellsBuffer.Name = "lblCellsBuffer";
			this.lblCellsBuffer.Size = new System.Drawing.Size(88, 14);
			this.lblCellsBuffer.TabIndex = 47;
			this.lblCellsBuffer.Text = "Ячейка-буфер";
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblID.Location = new System.Drawing.Point(356, 11);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(28, 14);
			this.lblID.TabIndex = 37;
			this.lblID.Text = "Код";
			this.ttToolTip.SetToolTip(this.lblID, "Уникальный код (ID)");
			// 
			// txtCellID
			// 
			this.txtCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellID.Enabled = false;
			this.txtCellID.Location = new System.Drawing.Point(390, 8);
			this.txtCellID.Name = "txtCellID";
			this.txtCellID.Size = new System.Drawing.Size(50, 22);
			this.txtCellID.TabIndex = 38;
			// 
			// txtAddress
			// 
			this.txtAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAddress.Enabled = false;
			this.txtAddress.Location = new System.Drawing.Point(126, 34);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(172, 22);
			this.txtAddress.TabIndex = 36;
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(8, 11);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(51, 14);
			this.lblCell.TabIndex = 34;
			this.lblCell.Text = "Ячейка:";
			// 
			// chkCellsBuffersUpdate
			// 
			this.chkCellsBuffersUpdate.AutoSize = true;
			this.chkCellsBuffersUpdate.Location = new System.Drawing.Point(8, 170);
			this.chkCellsBuffersUpdate.Name = "chkCellsBuffersUpdate";
			this.chkCellsBuffersUpdate.Size = new System.Drawing.Size(301, 18);
			this.chkCellsBuffersUpdate.TabIndex = 33;
			this.chkCellsBuffersUpdate.Text = "заменять ранее назначенную буферную ячейку";
			this.chkCellsBuffersUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkCellsBuffersUpdate.UseVisualStyleBackColor = true;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 212);
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
			this.btnCancel.Location = new System.Drawing.Point(431, 212);
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
			this.btnSave.Location = new System.Drawing.Point(381, 212);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmCellsBuffer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(468, 248);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "525");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsBuffer";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Назначение буферной ячейки";
			this.Load += new System.EventHandler(this.frmCellsBuffer_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.pnlBuffer.ResumeLayout(false);
			this.pnlBuffer.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMCheckBox chkCellsBuffersUpdate;
		private RFMBaseClasses.RFMLabel lblID;
		private RFMBaseClasses.RFMTextBox txtCellID;
		private RFMBaseClasses.RFMTextBox txtAddress;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMLabel lblBuffer;
		private RFMBaseClasses.RFMPanel pnlBuffer;
		private RFMBaseClasses.RFMComboBox cboStoresZonesBuffer;
		private RFMBaseClasses.RFMLabel lblStoresZonesTypesBuffer;
		private RFMBaseClasses.RFMComboBox cboStoresZonesTypesBuffer;
		private RFMBaseClasses.RFMLabel lblStoresZonesBuffer;
		private RFMBaseClasses.RFMComboBox cboCellAddressBuffer;
		private RFMBaseClasses.RFMLabel lblCellsBuffer;
		private RFMBaseClasses.RFMTextBox txtCellBuffer;
		private RFMBaseClasses.RFMButton btnCellBufferClear;
		private RFMBaseClasses.RFMLabel lblBarCode;
		private RFMBaseClasses.RFMTextBoxBarCode txtBarCode;
		private RFMBaseClasses.RFMLabel lblAddress;
	}
}