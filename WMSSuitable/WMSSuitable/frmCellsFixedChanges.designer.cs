namespace WMSSuitable
{
	partial class frmCellsFixedChanges
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
			this.btnCellNewChoose = new RFMBaseClasses.RFMButton();
			this.txtCellNewAddress = new RFMBaseClasses.RFMTextBox();
			this.txtStoreZoneNewName = new RFMBaseClasses.RFMTextBox();
			this.lblFixedNew = new RFMBaseClasses.RFMLabel();
			this.lblFixedCur = new RFMBaseClasses.RFMLabel();
			this.txtGoodStateName = new RFMBaseClasses.RFMTextBox();
			this.txtOwnerName = new RFMBaseClasses.RFMTextBox();
			this.txtPackingAlias = new RFMBaseClasses.RFMTextBox();
			this.txtCellCurAddress = new RFMBaseClasses.RFMTextBox();
			this.txtStoreZoneCurName = new RFMBaseClasses.RFMTextBox();
			this.btnPackingChoose = new RFMBaseClasses.RFMButton();
			this.lblPackings = new RFMBaseClasses.RFMLabel();
			this.lblGoodStateName = new RFMBaseClasses.RFMLabel();
			this.lblOwnerName = new RFMBaseClasses.RFMLabel();
			this.pnlData.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(573, 141);
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
			this.btnSave.Location = new System.Drawing.Point(523, 141);
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
			this.btnHelp.Location = new System.Drawing.Point(6, 141);
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
			this.pnlData.Controls.Add(this.btnCellNewChoose);
			this.pnlData.Controls.Add(this.txtCellNewAddress);
			this.pnlData.Controls.Add(this.txtStoreZoneNewName);
			this.pnlData.Controls.Add(this.lblFixedNew);
			this.pnlData.Controls.Add(this.lblFixedCur);
			this.pnlData.Controls.Add(this.txtGoodStateName);
			this.pnlData.Controls.Add(this.txtOwnerName);
			this.pnlData.Controls.Add(this.txtPackingAlias);
			this.pnlData.Controls.Add(this.txtCellCurAddress);
			this.pnlData.Controls.Add(this.txtStoreZoneCurName);
			this.pnlData.Controls.Add(this.btnPackingChoose);
			this.pnlData.Controls.Add(this.lblPackings);
			this.pnlData.Controls.Add(this.lblGoodStateName);
			this.pnlData.Controls.Add(this.lblOwnerName);
			this.pnlData.Location = new System.Drawing.Point(3, 3);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(603, 129);
			this.pnlData.TabIndex = 4;
			// 
			// btnCellNewChoose
			// 
			this.btnCellNewChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnCellNewChoose.Location = new System.Drawing.Point(120, 92);
			this.btnCellNewChoose.Name = "btnCellNewChoose";
			this.btnCellNewChoose.Size = new System.Drawing.Size(30, 30);
			this.btnCellNewChoose.TabIndex = 61;
			this.ttToolTip.SetToolTip(this.btnCellNewChoose, "Выбор ячейки");
			this.btnCellNewChoose.UseVisualStyleBackColor = true;
			this.btnCellNewChoose.Click += new System.EventHandler(this.btnCellNewChoose_Click);
			// 
			// txtCellNewAddress
			// 
			this.txtCellNewAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellNewAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellNewAddress.Enabled = false;
			this.txtCellNewAddress.Location = new System.Drawing.Point(153, 96);
			this.txtCellNewAddress.Name = "txtCellNewAddress";
			this.txtCellNewAddress.Size = new System.Drawing.Size(103, 22);
			this.txtCellNewAddress.TabIndex = 60;
			// 
			// txtStoreZoneNewName
			// 
			this.txtStoreZoneNewName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtStoreZoneNewName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtStoreZoneNewName.Enabled = false;
			this.txtStoreZoneNewName.Location = new System.Drawing.Point(260, 96);
			this.txtStoreZoneNewName.Name = "txtStoreZoneNewName";
			this.txtStoreZoneNewName.Size = new System.Drawing.Size(172, 22);
			this.txtStoreZoneNewName.TabIndex = 59;
			// 
			// lblFixedNew
			// 
			this.lblFixedNew.AutoSize = true;
			this.lblFixedNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedNew.Location = new System.Drawing.Point(6, 100);
			this.lblFixedNew.Name = "lblFixedNew";
			this.lblFixedNew.Size = new System.Drawing.Size(107, 14);
			this.lblFixedNew.TabIndex = 58;
			this.lblFixedNew.Text = "Будет закреплен:";
			// 
			// lblFixedCur
			// 
			this.lblFixedCur.AutoSize = true;
			this.lblFixedCur.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedCur.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedCur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedCur.Location = new System.Drawing.Point(6, 70);
			this.lblFixedCur.Name = "lblFixedCur";
			this.lblFixedCur.Size = new System.Drawing.Size(114, 14);
			this.lblFixedCur.TabIndex = 57;
			this.lblFixedCur.Text = "Сейчас закреплен:";
			// 
			// txtGoodStateName
			// 
			this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodStateName.Enabled = false;
			this.txtGoodStateName.Location = new System.Drawing.Point(153, 6);
			this.txtGoodStateName.Name = "txtGoodStateName";
			this.txtGoodStateName.Size = new System.Drawing.Size(172, 22);
			this.txtGoodStateName.TabIndex = 56;
			// 
			// txtOwnerName
			// 
			this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwnerName.Enabled = false;
			this.txtOwnerName.Location = new System.Drawing.Point(422, 6);
			this.txtOwnerName.Name = "txtOwnerName";
			this.txtOwnerName.Size = new System.Drawing.Size(172, 22);
			this.txtOwnerName.TabIndex = 55;
			// 
			// txtPackingAlias
			// 
			this.txtPackingAlias.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPackingAlias.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPackingAlias.Enabled = false;
			this.txtPackingAlias.Location = new System.Drawing.Point(153, 36);
			this.txtPackingAlias.Name = "txtPackingAlias";
			this.txtPackingAlias.Size = new System.Drawing.Size(441, 22);
			this.txtPackingAlias.TabIndex = 54;
			// 
			// txtCellCurAddress
			// 
			this.txtCellCurAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellCurAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellCurAddress.Enabled = false;
			this.txtCellCurAddress.Location = new System.Drawing.Point(153, 66);
			this.txtCellCurAddress.Name = "txtCellCurAddress";
			this.txtCellCurAddress.Size = new System.Drawing.Size(103, 22);
			this.txtCellCurAddress.TabIndex = 52;
			// 
			// txtStoreZoneCurName
			// 
			this.txtStoreZoneCurName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtStoreZoneCurName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtStoreZoneCurName.Enabled = false;
			this.txtStoreZoneCurName.Location = new System.Drawing.Point(260, 66);
			this.txtStoreZoneCurName.Name = "txtStoreZoneCurName";
			this.txtStoreZoneCurName.Size = new System.Drawing.Size(172, 22);
			this.txtStoreZoneCurName.TabIndex = 17;
			// 
			// btnPackingChoose
			// 
			this.btnPackingChoose.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackingChoose.Location = new System.Drawing.Point(120, 32);
			this.btnPackingChoose.Name = "btnPackingChoose";
			this.btnPackingChoose.Size = new System.Drawing.Size(30, 30);
			this.btnPackingChoose.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.btnPackingChoose, "Выбор товара");
			this.btnPackingChoose.UseVisualStyleBackColor = true;
			this.btnPackingChoose.Click += new System.EventHandler(this.btnPackingChoose_Click);
			// 
			// lblPackings
			// 
			this.lblPackings.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPackings.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPackings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPackings.Location = new System.Drawing.Point(8, 39);
			this.lblPackings.Name = "lblPackings";
			this.lblPackings.Size = new System.Drawing.Size(61, 15);
			this.lblPackings.TabIndex = 11;
			this.lblPackings.Text = "Товар";
			// 
			// lblGoodStateName
			// 
			this.lblGoodStateName.AutoSize = true;
			this.lblGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodStateName.Location = new System.Drawing.Point(6, 9);
			this.lblGoodStateName.Name = "lblGoodStateName";
			this.lblGoodStateName.Size = new System.Drawing.Size(110, 14);
			this.lblGoodStateName.TabIndex = 7;
			this.lblGoodStateName.Text = "Состояние товара";
			// 
			// lblOwnerName
			// 
			this.lblOwnerName.AutoSize = true;
			this.lblOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwnerName.Location = new System.Drawing.Point(349, 9);
			this.lblOwnerName.Name = "lblOwnerName";
			this.lblOwnerName.Size = new System.Drawing.Size(67, 14);
			this.lblOwnerName.TabIndex = 3;
			this.lblOwnerName.Text = "Хранитель";
			// 
			// frmCellsFixedChanges
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(610, 177);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "522");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsFixedChanges";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Изменение фиксированного закрепления товара";
			this.Load += new System.EventHandler(this.frmCellsFixedChanges_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblGoodStateName;
        private RFMBaseClasses.RFMLabel lblOwnerName;
        private RFMBaseClasses.RFMButton btnPackingChoose;
		private RFMBaseClasses.RFMLabel lblPackings;
		private RFMBaseClasses.RFMTextBox txtStoreZoneCurName;
		private RFMBaseClasses.RFMTextBox txtCellCurAddress;
		private RFMBaseClasses.RFMTextBox txtPackingAlias;
		private RFMBaseClasses.RFMTextBox txtGoodStateName;
		private RFMBaseClasses.RFMTextBox txtOwnerName;
		private RFMBaseClasses.RFMButton btnCellNewChoose;
		private RFMBaseClasses.RFMTextBox txtCellNewAddress;
		private RFMBaseClasses.RFMTextBox txtStoreZoneNewName;
		private RFMBaseClasses.RFMLabel lblFixedNew;
		private RFMBaseClasses.RFMLabel lblFixedCur;
	}
}