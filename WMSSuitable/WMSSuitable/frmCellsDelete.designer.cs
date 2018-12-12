namespace WMSSuitable
{
	partial class frmCellsDelete
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
			this.lblAddress = new RFMBaseClasses.RFMLabel();
			this.txtAddress = new RFMBaseClasses.RFMTextBox();
			this.lblBarCode = new RFMBaseClasses.RFMLabel();
			this.lblID = new RFMBaseClasses.RFMLabel();
			this.txtCellID = new RFMBaseClasses.RFMTextBox();
			this.txtBarCode = new RFMBaseClasses.RFMTextBox();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.chkDeleteHole = new RFMBaseClasses.RFMCheckBox();
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
			this.pnlData.Controls.Add(this.lblAddress);
			this.pnlData.Controls.Add(this.txtAddress);
			this.pnlData.Controls.Add(this.lblBarCode);
			this.pnlData.Controls.Add(this.lblID);
			this.pnlData.Controls.Add(this.txtCellID);
			this.pnlData.Controls.Add(this.txtBarCode);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Controls.Add(this.chkDeleteHole);
			this.pnlData.Location = new System.Drawing.Point(6, 7);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(432, 96);
			this.pnlData.TabIndex = 1;
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAddress.Location = new System.Drawing.Point(68, 39);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(42, 14);
			this.lblAddress.TabIndex = 51;
			this.lblAddress.Text = "Адрес";
			// 
			// txtAddress
			// 
			this.txtAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAddress.Enabled = false;
			this.txtAddress.Location = new System.Drawing.Point(113, 36);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(172, 22);
			this.txtAddress.TabIndex = 50;
			// 
			// lblBarCode
			// 
			this.lblBarCode.AutoSize = true;
			this.lblBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBarCode.Location = new System.Drawing.Point(85, 13);
			this.lblBarCode.Name = "lblBarCode";
			this.lblBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblBarCode.TabIndex = 35;
			this.lblBarCode.Text = "ШК";
			this.ttToolTip.SetToolTip(this.lblBarCode, "Штрих-код");
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblID.Location = new System.Drawing.Point(337, 13);
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
			this.txtCellID.Location = new System.Drawing.Point(369, 10);
			this.txtCellID.Name = "txtCellID";
			this.txtCellID.Size = new System.Drawing.Size(50, 22);
			this.txtCellID.TabIndex = 38;
			// 
			// txtBarCode
			// 
			this.txtBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtBarCode.Enabled = false;
			this.txtBarCode.Location = new System.Drawing.Point(113, 10);
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtBarCode.TabIndex = 36;
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(11, 13);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(51, 14);
			this.lblCell.TabIndex = 34;
			this.lblCell.Text = "Ячейка:";
			// 
			// chkDeleteHole
			// 
			this.chkDeleteHole.AutoSize = true;
			this.chkDeleteHole.Location = new System.Drawing.Point(11, 67);
			this.chkDeleteHole.Name = "chkDeleteHole";
			this.chkDeleteHole.Size = new System.Drawing.Size(405, 18);
			this.chkDeleteHole.TabIndex = 33;
			this.chkDeleteHole.Text = "удалять, даже если пропуски в линиях, стояках, уровнях, местах";
			this.chkDeleteHole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkDeleteHole.UseVisualStyleBackColor = true;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 111);
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
			this.btnCancel.Location = new System.Drawing.Point(407, 111);
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
			this.btnSave.Location = new System.Drawing.Point(357, 111);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmCellsDelete
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(444, 147);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "515");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsDelete";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Удаление ячеек";
			this.Load += new System.EventHandler(this.frmCellsDelete_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMCheckBox chkDeleteHole;
		private RFMBaseClasses.RFMLabel lblBarCode;
		private RFMBaseClasses.RFMLabel lblID;
		private RFMBaseClasses.RFMTextBox txtCellID;
		private RFMBaseClasses.RFMTextBox txtBarCode;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMLabel lblAddress;
		private RFMBaseClasses.RFMTextBox txtAddress;
	}
}