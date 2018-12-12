namespace WMSSuitable
{
	partial class frmReportsBarCode 
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
			this.btnClear = new RFMBaseClasses.RFMButton();
			this.btnGo = new RFMBaseClasses.RFMButton();
			this.rtxtInfo = new RFMBaseClasses.RFMRichTextBox();
			this.lblBarCode = new RFMBaseClasses.RFMLabel();
			this.txtBarCode = new RFMBaseClasses.RFMTextBoxBarCode();
			this.btnPrint = new RFMBaseClasses.RFMButton();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.pnlData.SuspendLayout();
			this.SuspendLayout();
			// 
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.btnClear);
			this.pnlData.Controls.Add(this.btnGo);
			this.pnlData.Controls.Add(this.rtxtInfo);
			this.pnlData.Controls.Add(this.lblBarCode);
			this.pnlData.Controls.Add(this.txtBarCode);
			this.pnlData.Location = new System.Drawing.Point(6, 7);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(430, 315);
			this.pnlData.TabIndex = 1;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.FlatAppearance.BorderSize = 0;
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnClear.Location = new System.Drawing.Point(399, 7);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(24, 24);
			this.btnClear.TabIndex = 39;
			this.ttToolTip.SetToolTip(this.btnClear, "Очистить");
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnGo
			// 
			this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go;
			this.btnGo.Location = new System.Drawing.Point(214, 5);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(30, 30);
			this.btnGo.TabIndex = 38;
			this.ttToolTip.SetToolTip(this.btnGo, "Получить данные о штрих-коде");
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// rtxtInfo
			// 
			this.rtxtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtxtInfo.Location = new System.Drawing.Point(7, 40);
			this.rtxtInfo.Name = "rtxtInfo";
			this.rtxtInfo.Size = new System.Drawing.Size(414, 267);
			this.rtxtInfo.TabIndex = 37;
			this.rtxtInfo.Text = "";
			// 
			// lblBarCode
			// 
			this.lblBarCode.AutoSize = true;
			this.lblBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBarCode.Location = new System.Drawing.Point(8, 12);
			this.lblBarCode.Name = "lblBarCode";
			this.lblBarCode.Size = new System.Drawing.Size(24, 14);
			this.lblBarCode.TabIndex = 35;
			this.lblBarCode.Text = "ШК";
			this.ttToolTip.SetToolTip(this.lblBarCode, "Штрих-код");
			// 
			// txtBarCode
			// 
			this.txtBarCode.Location = new System.Drawing.Point(36, 9);
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtBarCode.TabIndex = 36;
			this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
			this.btnPrint.Location = new System.Drawing.Point(355, 330);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(30, 30);
			this.btnPrint.TabIndex = 1;
			this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnPrint, "Печать");
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 330);
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
			this.btnCancel.Location = new System.Drawing.Point(405, 330);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(30, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmReportsBarCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(442, 366);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnPrint);
			this.hpHelp.SetHelpKeyword(this, "1021");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.Name = "frmReportsBarCode";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Штрих-код";
			this.Load += new System.EventHandler(this.frmReportsBarCode_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnPrint;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblBarCode;
		private RFMBaseClasses.RFMTextBoxBarCode txtBarCode;
		private RFMBaseClasses.RFMButton btnGo;
		private RFMBaseClasses.RFMRichTextBox rtxtInfo;
        private RFMBaseClasses.RFMButton btnClear;
	}
}