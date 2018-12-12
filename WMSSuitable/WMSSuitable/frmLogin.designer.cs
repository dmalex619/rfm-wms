namespace WMSSuitable
{
	partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            this.tmrShow = new System.Windows.Forms.Timer(this.components);
            this.prbProcess = new System.Windows.Forms.ProgressBar();
            this.cboUserList = new RFMBaseClasses.RFMComboBox();
            this.btnOk = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.txtPassword = new RFMBaseClasses.RFMTextBox();
            this.lblUserList = new RFMBaseClasses.RFMLabel();
            this.lblPassword = new RFMBaseClasses.RFMLabel();
            this.picPhoto = new RFMBaseClasses.RFMPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrShow
            // 
            this.tmrShow.Interval = 1000;
            this.tmrShow.Tick += new System.EventHandler(this.tmrShow_Tick);
            // 
            // prbProcess
            // 
            this.prbProcess.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prbProcess.Location = new System.Drawing.Point(0, 197);
            this.prbProcess.Maximum = 60;
            this.prbProcess.Name = "prbProcess";
            this.prbProcess.Size = new System.Drawing.Size(339, 17);
            this.prbProcess.TabIndex = 4;
            // 
            // cboUserList
            // 
            this.cboUserList.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboUserList.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserList.FormattingEnabled = true;
            this.cboUserList.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboUserList.Location = new System.Drawing.Point(166, 27);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(161, 22);
            this.cboUserList.TabIndex = 3;
            this.cboUserList.SelectedIndexChanged += new System.EventHandler(this.cboUserList_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(166, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Location = new System.Drawing.Point(253, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отказ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtPassword.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Location = new System.Drawing.Point(166, 103);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(161, 22);
            this.txtPassword.TabIndex = 0;
            // 
            // lblUserList
            // 
            this.lblUserList.AutoSize = true;
            this.lblUserList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserList.Location = new System.Drawing.Point(166, 10);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(85, 14);
            this.lblUserList.TabIndex = 5;
            this.lblUserList.Text = "Пользователь";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPassword.Location = new System.Drawing.Point(166, 86);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 14);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Пароль";
            // 
            // picPhoto
            // 
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPhoto.Location = new System.Drawing.Point(14, 10);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(135, 174);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.TabIndex = 7;
            this.picPhoto.TabStop = false;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(339, 214);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserList);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cboUserList);
            this.Controls.Add(this.prbProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsModalMode = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer tmrShow;
		private System.Windows.Forms.ProgressBar prbProcess;
		private RFMBaseClasses.RFMComboBox cboUserList;
		private RFMBaseClasses.RFMButton btnOk;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMTextBox txtPassword;
		private RFMBaseClasses.RFMLabel lblUserList;
		private RFMBaseClasses.RFMLabel lblPassword;
		private RFMBaseClasses.RFMPictureBox picPhoto;
	}
}

