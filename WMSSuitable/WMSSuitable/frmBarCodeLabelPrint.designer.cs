namespace WMSSuitable
{
	partial class frmBarCodeLabelPrint 
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
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.btnPrint = new RFMBaseClasses.RFMButton();
			this.bsData = new RFMBaseClasses.RFMBindingSource();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.numCopies = new RFMBaseClasses.RFMNumericUpDown();
			this.lblCopies = new RFMBaseClasses.RFMLabel();
			this.lblPrinter = new RFMBaseClasses.RFMLabel();
			this.cboPrinters = new RFMBaseClasses.RFMComboBox();
			this.lblBarCodeLabel = new RFMBaseClasses.RFMLabel();
			this.cboBarCodeLabels = new RFMBaseClasses.RFMComboBox();
			((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(5, 104);
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
			this.btnExit.Location = new System.Drawing.Point(507, 105);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(30, 30);
			this.btnExit.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.btnExit, "Выход");
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnPrint.Image = global::WMSSuitable.Properties.Resources.Print;
			this.btnPrint.Location = new System.Drawing.Point(457, 105);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(30, 30);
			this.btnPrint.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.btnPrint, "Печать");
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.numCopies);
			this.pnlData.Controls.Add(this.lblCopies);
			this.pnlData.Controls.Add(this.lblPrinter);
			this.pnlData.Controls.Add(this.cboPrinters);
			this.pnlData.Controls.Add(this.lblBarCodeLabel);
			this.pnlData.Controls.Add(this.cboBarCodeLabels);
			this.pnlData.Location = new System.Drawing.Point(3, 3);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(534, 95);
			this.pnlData.TabIndex = 9;
			// 
			// numCopies
			// 
			this.numCopies.IsNull = false;
			this.numCopies.Location = new System.Drawing.Point(115, 35);
			this.numCopies.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numCopies.Name = "numCopies";
			this.numCopies.Size = new System.Drawing.Size(70, 22);
			this.numCopies.TabIndex = 3;
			this.numCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblCopies
			// 
			this.lblCopies.AutoSize = true;
			this.lblCopies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCopies.Location = new System.Drawing.Point(6, 38);
			this.lblCopies.Name = "lblCopies";
			this.lblCopies.Size = new System.Drawing.Size(80, 14);
			this.lblCopies.TabIndex = 2;
			this.lblCopies.Text = "Число копий";
			// 
			// lblPrinter
			// 
			this.lblPrinter.AutoSize = true;
			this.lblPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPrinter.Location = new System.Drawing.Point(6, 65);
			this.lblPrinter.Name = "lblPrinter";
			this.lblPrinter.Size = new System.Drawing.Size(56, 14);
			this.lblPrinter.TabIndex = 4;
			this.lblPrinter.Text = "Принтер";
			// 
			// cboPrinters
			// 
			this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPrinters.FormattingEnabled = true;
			this.cboPrinters.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboPrinters.Location = new System.Drawing.Point(115, 62);
			this.cboPrinters.Name = "cboPrinters";
			this.cboPrinters.Size = new System.Drawing.Size(408, 22);
			this.cboPrinters.TabIndex = 5;
			// 
			// lblBarCodeLabel
			// 
			this.lblBarCodeLabel.AutoSize = true;
			this.lblBarCodeLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBarCodeLabel.Location = new System.Drawing.Point(6, 11);
			this.lblBarCodeLabel.Name = "lblBarCodeLabel";
			this.lblBarCodeLabel.Size = new System.Drawing.Size(106, 14);
			this.lblBarCodeLabel.TabIndex = 0;
			this.lblBarCodeLabel.Text = "Шаблон этикетки";
			// 
			// cboBarCodeLabels
			// 
			this.cboBarCodeLabels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBarCodeLabels.FormattingEnabled = true;
			this.cboBarCodeLabels.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboBarCodeLabels.Location = new System.Drawing.Point(115, 8);
			this.cboBarCodeLabels.Name = "cboBarCodeLabels";
			this.cboBarCodeLabels.Size = new System.Drawing.Size(408, 22);
			this.cboBarCodeLabels.TabIndex = 1;
			this.cboBarCodeLabels.SelectedIndexChanged += new System.EventHandler(this.cboBarCodeLabels_SelectedIndexChanged);
			// 
			// frmBarCodeLabelPrint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 139);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnPrint);
			this.hpHelp.SetHelpKeyword(this, "1101");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmBarCodeLabelPrint";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Печать этикеток";
			this.Load += new System.EventHandler(this.frmBarCodeLabelPrint_Load);
			((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnPrint;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMBindingSource bsData;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblPrinter;
		private RFMBaseClasses.RFMComboBox cboPrinters;
		private RFMBaseClasses.RFMLabel lblBarCodeLabel;
		private RFMBaseClasses.RFMComboBox cboBarCodeLabels;
		private RFMBaseClasses.RFMLabel lblCopies;
		private RFMBaseClasses.RFMNumericUpDown numCopies;
	}
}