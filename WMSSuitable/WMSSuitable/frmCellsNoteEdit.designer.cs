namespace WMSSuitable
{
	partial class frmCellsNoteEdit
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
            this.lblNote = new RFMBaseClasses.RFMLabel();
            this.txtNote = new RFMBaseClasses.RFMTextBox();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnCancel.Location = new System.Drawing.Point(537, 67);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(34, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(480, 67);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(34, 39);
            this.btnSave.TabIndex = 4;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(7, 67);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(34, 39);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.TabStop = false;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.lblNote);
            this.pnlData.Controls.Add(this.txtNote);
            this.pnlData.Location = new System.Drawing.Point(7, 9);
            this.pnlData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(564, 49);
            this.pnlData.TabIndex = 1;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblNote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNote.Location = new System.Drawing.Point(5, 14);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(92, 18);
            this.lblNote.TabIndex = 5;
            this.lblNote.Text = "Примечание";
            // 
            // txtNote
            // 
            this.txtNote.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtNote.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNote.Location = new System.Drawing.Point(103, 10);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNote.MaxLength = 250;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(454, 26);
            this.txtNote.TabIndex = 2;
            // 
            // frmCellsNoteEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(579, 113);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.hpHelp.SetHelpKeyword(this, "521");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmCellsNoteEdit";
            this.hpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Введите примечание к ";
            this.Load += new System.EventHandler(this.frmCellsNoteEdit_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
        private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMPanel pnlData;
        private RFMBaseClasses.RFMTextBox txtNote;
		private RFMBaseClasses.RFMLabel lblNote;
	}
}