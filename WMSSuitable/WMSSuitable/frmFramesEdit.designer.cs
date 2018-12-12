namespace WMSSuitable
{
	partial class frmFramesEdit
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
			this.txtCnt = new RFMBaseClasses.RFMTextBox();
			this.chkFrameHeight = new RFMBaseClasses.RFMCheckBox();
			this.chkPalletsTypes = new RFMBaseClasses.RFMCheckBox();
			this.txtFrameHeight = new RFMBaseClasses.RFMTextBox();
			this.txtPalletsTypes = new RFMBaseClasses.RFMTextBox();
			this.numFrameHeight = new RFMBaseClasses.RFMNumericUpDown();
			this.lblFrameID = new RFMBaseClasses.RFMLabel();
			this.lblFrameBarCode = new RFMBaseClasses.RFMLabel();
			this.txtFrameID = new RFMBaseClasses.RFMTextBox();
			this.txtBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
			this.lblFrameHeight = new RFMBaseClasses.RFMLabel();
			this.cboPalletsTypes = new RFMBaseClasses.RFMComboBox();
			this.lblPalletType = new RFMBaseClasses.RFMLabel();
			this.lblFrame = new RFMBaseClasses.RFMLabel();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numFrameHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(485, 144);
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
			this.btnSave.Location = new System.Drawing.Point(435, 144);
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
			this.btnHelp.Location = new System.Drawing.Point(6, 144);
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
			this.pnlData.Controls.Add(this.txtCnt);
			this.pnlData.Controls.Add(this.chkFrameHeight);
			this.pnlData.Controls.Add(this.chkPalletsTypes);
			this.pnlData.Controls.Add(this.txtFrameHeight);
			this.pnlData.Controls.Add(this.txtPalletsTypes);
			this.pnlData.Controls.Add(this.numFrameHeight);
			this.pnlData.Controls.Add(this.lblFrameID);
			this.pnlData.Controls.Add(this.lblFrameBarCode);
			this.pnlData.Controls.Add(this.txtFrameID);
			this.pnlData.Controls.Add(this.txtBarCode);
			this.pnlData.Controls.Add(this.lblFrameHeight);
			this.pnlData.Controls.Add(this.cboPalletsTypes);
			this.pnlData.Controls.Add(this.lblPalletType);
			this.pnlData.Controls.Add(this.lblFrame);
			this.pnlData.Location = new System.Drawing.Point(6, 7);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(509, 130);
			this.pnlData.TabIndex = 0;
			// 
			// txtCnt
			// 
			this.txtCnt.Enabled = false;
			this.txtCnt.Location = new System.Drawing.Point(172, 34);
			this.txtCnt.Name = "txtCnt";
			this.txtCnt.Size = new System.Drawing.Size(172, 22);
			this.txtCnt.TabIndex = 13;
			// 
			// chkFrameHeight
			// 
			this.chkFrameHeight.AutoSize = true;
			this.chkFrameHeight.Location = new System.Drawing.Point(154, 101);
			this.chkFrameHeight.Name = "chkFrameHeight";
			this.chkFrameHeight.Size = new System.Drawing.Size(15, 14);
			this.chkFrameHeight.TabIndex = 10;
			this.chkFrameHeight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkFrameHeight, "Изменить высоту контейнера");
			this.chkFrameHeight.UseVisualStyleBackColor = true;
			this.chkFrameHeight.CheckedChanged += new System.EventHandler(this.chkFrameHeight_CheckedChanged);
			// 
			// chkPalletsTypes
			// 
			this.chkPalletsTypes.AutoSize = true;
			this.chkPalletsTypes.Location = new System.Drawing.Point(154, 75);
			this.chkPalletsTypes.Name = "chkPalletsTypes";
			this.chkPalletsTypes.Size = new System.Drawing.Size(15, 14);
			this.chkPalletsTypes.TabIndex = 6;
			this.chkPalletsTypes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.chkPalletsTypes, "Изменить тип поддона");
			this.chkPalletsTypes.UseVisualStyleBackColor = true;
			this.chkPalletsTypes.CheckedChanged += new System.EventHandler(this.chkPalletsTypes_CheckedChanged);
			// 
			// txtFrameHeight
			// 
			this.txtFrameHeight.Enabled = false;
			this.txtFrameHeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtFrameHeight.Location = new System.Drawing.Point(347, 97);
			this.txtFrameHeight.Name = "txtFrameHeight";
			this.txtFrameHeight.Size = new System.Drawing.Size(150, 22);
			this.txtFrameHeight.TabIndex = 12;
			// 
			// txtPalletsTypes
			// 
			this.txtPalletsTypes.Enabled = false;
			this.txtPalletsTypes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtPalletsTypes.Location = new System.Drawing.Point(347, 71);
			this.txtPalletsTypes.Name = "txtPalletsTypes";
			this.txtPalletsTypes.Size = new System.Drawing.Size(150, 22);
			this.txtPalletsTypes.TabIndex = 8;
			// 
			// numFrameHeight
			// 
			this.numFrameHeight.DecimalPlaces = 3;
			this.numFrameHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numFrameHeight.IsNull = false;
			this.numFrameHeight.Location = new System.Drawing.Point(172, 98);
			this.numFrameHeight.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
			this.numFrameHeight.Name = "numFrameHeight";
			this.numFrameHeight.Size = new System.Drawing.Size(95, 22);
			this.numFrameHeight.TabIndex = 11;
			this.numFrameHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numFrameHeight.ValueChanged += new System.EventHandler(this.numFrameHeight_ValueChanged);
			// 
			// lblFrameID
			// 
			this.lblFrameID.AutoSize = true;
			this.lblFrameID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameID.Location = new System.Drawing.Point(415, 11);
			this.lblFrameID.Name = "lblFrameID";
			this.lblFrameID.Size = new System.Drawing.Size(28, 14);
			this.lblFrameID.TabIndex = 3;
			this.lblFrameID.Text = "Код";
			this.ttToolTip.SetToolTip(this.lblFrameID, "Уникальный код ячейки");
			// 
			// lblFrameBarCode
			// 
			this.lblFrameBarCode.AutoSize = true;
			this.lblFrameBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameBarCode.Location = new System.Drawing.Point(145, 11);
			this.lblFrameBarCode.Name = "lblFrameBarCode";
			this.lblFrameBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblFrameBarCode.TabIndex = 1;
			this.lblFrameBarCode.Text = "ШК";
			this.ttToolTip.SetToolTip(this.lblFrameBarCode, "Штрих-код");
			// 
			// txtFrameID
			// 
			this.txtFrameID.Enabled = false;
			this.txtFrameID.Location = new System.Drawing.Point(447, 8);
			this.txtFrameID.Name = "txtFrameID";
			this.txtFrameID.Size = new System.Drawing.Size(50, 22);
			this.txtFrameID.TabIndex = 4;
			// 
			// txtBarCode
			// 
			this.txtBarCode.Enabled = false;
			this.txtBarCode.Location = new System.Drawing.Point(172, 8);
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtBarCode.TabIndex = 2;
			// 
			// lblFrameHeight
			// 
			this.lblFrameHeight.AutoSize = true;
			this.lblFrameHeight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameHeight.Location = new System.Drawing.Point(6, 100);
			this.lblFrameHeight.Name = "lblFrameHeight";
			this.lblFrameHeight.Size = new System.Drawing.Size(134, 14);
			this.lblFrameHeight.TabIndex = 9;
			this.lblFrameHeight.Text = "Высота контейнера, м";
			// 
			// cboPalletsTypes
			// 
			this.cboPalletsTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPalletsTypes.FormattingEnabled = true;
			this.cboPalletsTypes.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboPalletsTypes.Location = new System.Drawing.Point(172, 71);
			this.cboPalletsTypes.Name = "cboPalletsTypes";
			this.cboPalletsTypes.Size = new System.Drawing.Size(172, 22);
			this.cboPalletsTypes.TabIndex = 7;
			this.cboPalletsTypes.SelectedIndexChanged += new System.EventHandler(this.cboPalletsTypes_SelectedIndexChanged);
			// 
			// lblPalletType
			// 
			this.lblPalletType.AutoSize = true;
			this.lblPalletType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPalletType.Location = new System.Drawing.Point(6, 74);
			this.lblPalletType.Name = "lblPalletType";
			this.lblPalletType.Size = new System.Drawing.Size(81, 14);
			this.lblPalletType.TabIndex = 5;
			this.lblPalletType.Text = "Тип поддона";
			// 
			// lblFrame
			// 
			this.lblFrame.AutoSize = true;
			this.lblFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrame.Location = new System.Drawing.Point(6, 11);
			this.lblFrame.Name = "lblFrame";
			this.lblFrame.Size = new System.Drawing.Size(73, 14);
			this.lblFrame.TabIndex = 0;
			this.lblFrame.Text = "Контейнер:";
			// 
			// frmFramesEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(522, 180);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "621");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmFramesEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Контейнер: геометрия";
			this.Load += new System.EventHandler(this.frmFramesEdit_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numFrameHeight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblFrame;
        private RFMBaseClasses.RFMLabel lblFrameHeight;
        private RFMBaseClasses.RFMComboBox cboPalletsTypes;
		private RFMBaseClasses.RFMLabel lblPalletType;
		private RFMBaseClasses.RFMLabel lblFrameID;
		private RFMBaseClasses.RFMLabel lblFrameBarCode;
		private RFMBaseClasses.RFMTextBox txtFrameID;
		private RFMBaseClasses.RFMTextBoxBarCode txtBarCode;
		private RFMBaseClasses.RFMNumericUpDown numFrameHeight;
		private RFMBaseClasses.RFMTextBox txtPalletsTypes;
		private RFMBaseClasses.RFMTextBox txtFrameHeight;
		private RFMBaseClasses.RFMCheckBox chkFrameHeight;
		private RFMBaseClasses.RFMCheckBox chkPalletsTypes;
		private RFMBaseClasses.RFMTextBox txtCnt;
	}
}