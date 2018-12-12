namespace WMSSuitable 
{
	partial class frmSysEdit 
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysEdit));
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.lblForShift1 = new RFMBaseClasses.RFMLabel();
			this.lblForShift2 = new RFMBaseClasses.RFMLabel();
			this.pnlHeader = new RFMBaseClasses.RFMPanel();
			this.lblValues = new RFMBaseClasses.RFMLabel();
			this.lblFields = new RFMBaseClasses.RFMLabel();
			this.lblNull = new RFMBaseClasses.RFMLabel();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.pnlHeader.SuspendLayout();
			this.pnlData.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(7, 387);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 8;
			this.ttToolTip.SetToolTip(this.btnHelp, "Помощь");
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.Location = new System.Drawing.Point(655, 387);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 12;
			this.ttToolTip.SetToolTip(this.btnSave, "Сохранить");
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
			this.btnExit.Location = new System.Drawing.Point(705, 387);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(30, 30);
			this.btnExit.TabIndex = 11;
			this.ttToolTip.SetToolTip(this.btnExit, "Выход");
			this.btnExit.UseVisualStyleBackColor = true;
			// 
			// lblForShift1
			// 
			this.lblForShift1.AutoSize = true;
			this.lblForShift1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblForShift1.Location = new System.Drawing.Point(3, 3);
			this.lblForShift1.Name = "lblForShift1";
			this.lblForShift1.Size = new System.Drawing.Size(129, 14);
			this.lblForShift1.TabIndex = 8;
			this.lblForShift1.Text = "для названий полей1";
			// 
			// lblForShift2
			// 
			this.lblForShift2.AutoSize = true;
			this.lblForShift2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblForShift2.Location = new System.Drawing.Point(3, 22);
			this.lblForShift2.Name = "lblForShift2";
			this.lblForShift2.Size = new System.Drawing.Size(129, 14);
			this.lblForShift2.TabIndex = 9;
			this.lblForShift2.Text = "для названий полей2";
			// 
			// pnlHeader
			// 
			this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlHeader.Controls.Add(this.lblValues);
			this.pnlHeader.Controls.Add(this.lblFields);
			this.pnlHeader.Controls.Add(this.lblNull);
			this.pnlHeader.Location = new System.Drawing.Point(7, 7);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(729, 23);
			this.pnlHeader.TabIndex = 14;
			// 
			// lblValues
			// 
			this.lblValues.AutoSize = true;
			this.lblValues.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblValues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblValues.Location = new System.Drawing.Point(308, 3);
			this.lblValues.Name = "lblValues";
			this.lblValues.Size = new System.Drawing.Size(66, 14);
			this.lblValues.TabIndex = 8;
			this.lblValues.Text = "Значение";
			// 
			// lblFields
			// 
			this.lblFields.AutoSize = true;
			this.lblFields.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblFields.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFields.Location = new System.Drawing.Point(6, 3);
			this.lblFields.Name = "lblFields";
			this.lblFields.Size = new System.Drawing.Size(39, 14);
			this.lblFields.TabIndex = 7;
			this.lblFields.Text = "Поле";
			// 
			// lblNull
			// 
			this.lblNull.AutoSize = true;
			this.lblNull.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblNull.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNull.Location = new System.Drawing.Point(238, 3);
			this.lblNull.Name = "lblNull";
			this.lblNull.Size = new System.Drawing.Size(29, 14);
			this.lblNull.TabIndex = 9;
			this.lblNull.Text = "Null";
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.AutoScroll = true;
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblForShift2);
			this.pnlData.Controls.Add(this.lblForShift1);
			this.pnlData.ImeMode = System.Windows.Forms.ImeMode.On;
			this.pnlData.Location = new System.Drawing.Point(7, 33);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(729, 346);
			this.pnlData.TabIndex = 13;
			// 
			// frmSysEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 423);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnHelp);
			this.hpHelp.SetHelpKeyword(this, "2093");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MinimumSize = new System.Drawing.Size(750, 200);
			this.Name = "frmSysEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Запись таблицы";
			this.Load += new System.EventHandler(this.frmSysEdit_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnHelp;
		internal RFMBaseClasses.RFMLabel lblForShift1;
		internal RFMBaseClasses.RFMLabel lblForShift2;
		internal RFMBaseClasses.RFMPanel pnlHeader;
		internal RFMBaseClasses.RFMLabel lblValues;
		internal RFMBaseClasses.RFMLabel lblFields;
		internal RFMBaseClasses.RFMLabel lblNull;
		internal RFMBaseClasses.RFMPanel pnlData;
		internal RFMBaseClasses.RFMButton btnSave;
		internal RFMBaseClasses.RFMButton btnExit;

	}
}