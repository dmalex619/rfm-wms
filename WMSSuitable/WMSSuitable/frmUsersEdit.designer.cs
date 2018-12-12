namespace WMSSuitable
{
	partial class frmUsersEdit
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
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.lblHost = new RFMBaseClasses.RFMLabel();
			this.cboHost = new RFMBaseClasses.RFMComboBox();
			this.lblBrigade = new RFMBaseClasses.RFMLabel();
			this.cboBrigades = new RFMBaseClasses.RFMComboBox();
			this.lblAlias = new RFMBaseClasses.RFMLabel();
			this.txtAlias = new RFMBaseClasses.RFMTextBox();
			this.txtUserNаme = new RFMBaseClasses.RFMTextBox();
			this.lblRoles = new RFMBaseClasses.RFMLabel();
			this.lblUserName = new RFMBaseClasses.RFMLabel();
			this.lblNetPath = new RFMBaseClasses.RFMLabel();
			this.lblLocPath = new RFMBaseClasses.RFMLabel();
			this.txtNetPath = new RFMBaseClasses.RFMTextBox();
			this.txtLocPath = new RFMBaseClasses.RFMTextBox();
			this.chkIsAdmin = new RFMBaseClasses.RFMCheckBox();
			this.chkActual = new RFMBaseClasses.RFMCheckBox();
			this.dgvUserRoles = new RFMBaseClasses.RFMDataGridView();
			this.dgvcCheck = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.dgvcRoleName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.lblPhoto = new RFMBaseClasses.RFMLabel();
			this.picPhoto = new RFMBaseClasses.RFMPictureBox();
			this.lblPassword = new RFMBaseClasses.RFMLabel();
			this.txtPassword = new RFMBaseClasses.RFMTextBox();
			this.btnLoadPhoto = new RFMBaseClasses.RFMButton();
			this.btnClearPhoto = new RFMBaseClasses.RFMButton();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(7, 244);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(32, 30);
			this.btnHelp.TabIndex = 8;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnExit.Location = new System.Drawing.Point(653, 244);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.btnExit, "Отказ");
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(603, 244);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(32, 30);
			this.btnSave.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.btnSave, "Сохранить");
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlData
			// 
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblHost);
			this.pnlData.Controls.Add(this.cboHost);
			this.pnlData.Controls.Add(this.lblBrigade);
			this.pnlData.Controls.Add(this.cboBrigades);
			this.pnlData.Controls.Add(this.lblAlias);
			this.pnlData.Controls.Add(this.txtAlias);
			this.pnlData.Controls.Add(this.txtUserNаme);
			this.pnlData.Controls.Add(this.lblRoles);
			this.pnlData.Controls.Add(this.lblUserName);
			this.pnlData.Controls.Add(this.lblNetPath);
			this.pnlData.Controls.Add(this.lblLocPath);
			this.pnlData.Controls.Add(this.txtNetPath);
			this.pnlData.Controls.Add(this.txtLocPath);
			this.pnlData.Controls.Add(this.chkIsAdmin);
			this.pnlData.Controls.Add(this.chkActual);
			this.pnlData.Controls.Add(this.dgvUserRoles);
			this.pnlData.Controls.Add(this.lblPhoto);
			this.pnlData.Controls.Add(this.picPhoto);
			this.pnlData.Controls.Add(this.lblPassword);
			this.pnlData.Controls.Add(this.txtPassword);
			this.pnlData.Location = new System.Drawing.Point(6, 6);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(680, 231);
			this.pnlData.TabIndex = 0;
			// 
			// lblHost
			// 
			this.lblHost.AutoSize = true;
			this.lblHost.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblHost.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblHost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblHost.Location = new System.Drawing.Point(147, 180);
			this.lblHost.Name = "lblHost";
			this.lblHost.Size = new System.Drawing.Size(33, 14);
			this.lblHost.TabIndex = 12;
			this.lblHost.Text = "Хост";
			// 
			// cboHost
			// 
			this.cboHost.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboHost.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboHost.FormattingEnabled = true;
			this.cboHost.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboHost.Location = new System.Drawing.Point(263, 177);
			this.cboHost.Name = "cboHost";
			this.cboHost.Size = new System.Drawing.Size(192, 22);
			this.cboHost.TabIndex = 13;
			// 
			// lblBrigade
			// 
			this.lblBrigade.AutoSize = true;
			this.lblBrigade.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBrigade.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBrigade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBrigade.Location = new System.Drawing.Point(147, 50);
			this.lblBrigade.Name = "lblBrigade";
			this.lblBrigade.Size = new System.Drawing.Size(52, 14);
			this.lblBrigade.TabIndex = 2;
			this.lblBrigade.Text = "Бригада";
			// 
			// cboBrigades
			// 
			this.cboBrigades.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboBrigades.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboBrigades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBrigades.FormattingEnabled = true;
			this.cboBrigades.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboBrigades.Location = new System.Drawing.Point(263, 47);
			this.cboBrigades.Name = "cboBrigades";
			this.cboBrigades.Size = new System.Drawing.Size(192, 22);
			this.cboBrigades.TabIndex = 3;
			// 
			// lblAlias
			// 
			this.lblAlias.AutoSize = true;
			this.lblAlias.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblAlias.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblAlias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAlias.Location = new System.Drawing.Point(147, 102);
			this.lblAlias.Name = "lblAlias";
			this.lblAlias.Size = new System.Drawing.Size(80, 14);
			this.lblAlias.TabIndex = 6;
			this.lblAlias.Text = "Сетевое имя";
			// 
			// txtAlias
			// 
			this.txtAlias.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtAlias.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAlias.Location = new System.Drawing.Point(263, 99);
			this.txtAlias.MaxLength = 50;
			this.txtAlias.Name = "txtAlias";
			this.txtAlias.Size = new System.Drawing.Size(192, 22);
			this.txtAlias.TabIndex = 7;
			// 
			// txtUserNаme
			// 
			this.txtUserNаme.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtUserNаme.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUserNаme.Location = new System.Drawing.Point(263, 21);
			this.txtUserNаme.MaxLength = 50;
			this.txtUserNаme.Name = "txtUserNаme";
			this.txtUserNаme.Size = new System.Drawing.Size(192, 22);
			this.txtUserNаme.TabIndex = 1;
			// 
			// lblRoles
			// 
			this.lblRoles.AutoSize = true;
			this.lblRoles.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblRoles.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblRoles.Location = new System.Drawing.Point(461, 4);
			this.lblRoles.Name = "lblRoles";
			this.lblRoles.Size = new System.Drawing.Size(143, 14);
			this.lblRoles.TabIndex = 16;
			this.lblRoles.Text = "Пользовательские роли\r\n";
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblUserName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblUserName.Location = new System.Drawing.Point(147, 24);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(112, 14);
			this.lblUserName.TabIndex = 0;
			this.lblUserName.Text = "Имя пользователя";
			// 
			// lblNetPath
			// 
			this.lblNetPath.AutoSize = true;
			this.lblNetPath.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblNetPath.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNetPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNetPath.Location = new System.Drawing.Point(147, 154);
			this.lblNetPath.Name = "lblNetPath";
			this.lblNetPath.Size = new System.Drawing.Size(101, 14);
			this.lblNetPath.TabIndex = 10;
			this.lblNetPath.Text = "Сетевой каталог";
			// 
			// lblLocPath
			// 
			this.lblLocPath.AutoSize = true;
			this.lblLocPath.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblLocPath.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblLocPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblLocPath.Location = new System.Drawing.Point(147, 128);
			this.lblLocPath.Name = "lblLocPath";
			this.lblLocPath.Size = new System.Drawing.Size(116, 14);
			this.lblLocPath.TabIndex = 8;
			this.lblLocPath.Text = "Локальный каталог";
			// 
			// txtNetPath
			// 
			this.txtNetPath.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtNetPath.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNetPath.Location = new System.Drawing.Point(263, 151);
			this.txtNetPath.MaxLength = 50;
			this.txtNetPath.Name = "txtNetPath";
			this.txtNetPath.Size = new System.Drawing.Size(192, 22);
			this.txtNetPath.TabIndex = 11;
			// 
			// txtLocPath
			// 
			this.txtLocPath.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtLocPath.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtLocPath.Location = new System.Drawing.Point(263, 125);
			this.txtLocPath.MaxLength = 50;
			this.txtLocPath.Name = "txtLocPath";
			this.txtLocPath.Size = new System.Drawing.Size(192, 22);
			this.txtLocPath.TabIndex = 9;
			// 
			// chkIsAdmin
			// 
			this.chkIsAdmin.AutoSize = true;
			this.chkIsAdmin.Location = new System.Drawing.Point(147, 205);
			this.chkIsAdmin.Name = "chkIsAdmin";
			this.chkIsAdmin.Size = new System.Drawing.Size(115, 18);
			this.chkIsAdmin.TabIndex = 14;
			this.chkIsAdmin.Text = "Администратор";
			this.chkIsAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkIsAdmin.UseVisualStyleBackColor = true;
			// 
			// chkActual
			// 
			this.chkActual.AutoSize = true;
			this.chkActual.Location = new System.Drawing.Point(342, 205);
			this.chkActual.Name = "chkActual";
			this.chkActual.Size = new System.Drawing.Size(103, 18);
			this.chkActual.TabIndex = 15;
			this.chkActual.Text = "Актуальность";
			this.chkActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkActual.UseVisualStyleBackColor = true;
			// 
			// dgvUserRoles
			// 
			this.dgvUserRoles.AllowUserToAddRows = false;
			this.dgvUserRoles.AllowUserToDeleteRows = false;
			this.dgvUserRoles.AllowUserToOrderColumns = true;
			this.dgvUserRoles.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvUserRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvUserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUserRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCheck,
            this.dgvcRoleName});
			this.dgvUserRoles.IsConfigInclude = true;
			this.dgvUserRoles.IsMarkedAll = false;
			this.dgvUserRoles.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvUserRoles.Location = new System.Drawing.Point(461, 21);
			this.dgvUserRoles.MultiSelect = false;
			this.dgvUserRoles.Name = "dgvUserRoles";
			this.dgvUserRoles.RangedWay = ' ';
			this.dgvUserRoles.RowHeadersWidth = 24;
			this.dgvUserRoles.SelectedRowBorderColor = System.Drawing.Color.Empty;
			this.dgvUserRoles.SelectedRowForeColor = System.Drawing.Color.Empty;
			this.dgvUserRoles.Size = new System.Drawing.Size(210, 201);
			this.dgvUserRoles.TabIndex = 17;
			// 
			// dgvcCheck
			// 
			this.dgvcCheck.DataPropertyName = "IsUsed";
			this.dgvcCheck.HeaderText = "";
			this.dgvcCheck.Name = "dgvcCheck";
			this.dgvcCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcCheck.ToolTipText = "Роль доступна пользователю?";
			this.dgvcCheck.Width = 24;
			// 
			// dgvcRoleName
			// 
			this.dgvcRoleName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgvcRoleName.DataPropertyName = "RoleName";
			this.dgvcRoleName.HeaderText = "Роль";
			this.dgvcRoleName.Name = "dgvcRoleName";
			this.dgvcRoleName.ReadOnly = true;
			this.dgvcRoleName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvcRoleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgvcRoleName.Width = 170;
			// 
			// lblPhoto
			// 
			this.lblPhoto.AutoSize = true;
			this.lblPhoto.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPhoto.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPhoto.Location = new System.Drawing.Point(4, 4);
			this.lblPhoto.Name = "lblPhoto";
			this.lblPhoto.Size = new System.Drawing.Size(37, 14);
			this.lblPhoto.TabIndex = 0;
			this.lblPhoto.Text = "Фото";
			// 
			// picPhoto
			// 
			this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picPhoto.Location = new System.Drawing.Point(5, 21);
			this.picPhoto.Name = "picPhoto";
			this.picPhoto.Size = new System.Drawing.Size(135, 174);
			this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPhoto.TabIndex = 10;
			this.picPhoto.TabStop = false;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblPassword.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblPassword.Location = new System.Drawing.Point(147, 76);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(48, 14);
			this.lblPassword.TabIndex = 4;
			this.lblPassword.Text = "Пароль";
			// 
			// txtPassword
			// 
			this.txtPassword.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtPassword.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPassword.Location = new System.Drawing.Point(263, 73);
			this.txtPassword.MaxLength = 20;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(192, 22);
			this.txtPassword.TabIndex = 5;
			// 
			// btnLoadPhoto
			// 
			this.btnLoadPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadPhoto.Image = global::WMSSuitable.Properties.Resources.Locate;
			this.btnLoadPhoto.Location = new System.Drawing.Point(116, 244);
			this.btnLoadPhoto.Name = "btnLoadPhoto";
			this.btnLoadPhoto.Size = new System.Drawing.Size(32, 30);
			this.btnLoadPhoto.TabIndex = 13;
			this.ttToolTip.SetToolTip(this.btnLoadPhoto, "Выбрать изображение для фото");
			this.btnLoadPhoto.UseVisualStyleBackColor = true;
			this.btnLoadPhoto.Click += new System.EventHandler(this.btnLoadPhoto_Click);
			// 
			// btnClearPhoto
			// 
			this.btnClearPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearPhoto.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnClearPhoto.Location = new System.Drawing.Point(78, 244);
			this.btnClearPhoto.Name = "btnClearPhoto";
			this.btnClearPhoto.Size = new System.Drawing.Size(32, 30);
			this.btnClearPhoto.TabIndex = 14;
			this.ttToolTip.SetToolTip(this.btnClearPhoto, "Очистить фото");
			this.btnClearPhoto.UseVisualStyleBackColor = true;
			this.btnClearPhoto.Click += new System.EventHandler(this.btnClearPhoto_Click);
			// 
			// frmUsersEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 280);
			this.Controls.Add(this.btnClearPhoto);
			this.Controls.Add(this.btnLoadPhoto);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MinimizeBox = false;
			this.Name = "frmUsersEdit";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Атрибуты пользователя и назначение ролей";
			this.Load += new System.EventHandler(this.frmUsersEdit_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUserRoles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblPhoto;
		private RFMBaseClasses.RFMPictureBox picPhoto;
		private RFMBaseClasses.RFMLabel lblPassword;
		private RFMBaseClasses.RFMTextBox txtPassword;
		private RFMBaseClasses.RFMDataGridView dgvUserRoles;
		private RFMBaseClasses.RFMCheckBox chkIsAdmin;
		private RFMBaseClasses.RFMCheckBox chkActual;
		private RFMBaseClasses.RFMTextBox txtNetPath;
		private RFMBaseClasses.RFMTextBox txtLocPath;
		private RFMBaseClasses.RFMLabel lblUserName;
		private RFMBaseClasses.RFMLabel lblNetPath;
		private RFMBaseClasses.RFMLabel lblLocPath;
		private RFMBaseClasses.RFMButton btnLoadPhoto;
		private RFMBaseClasses.RFMLabel lblRoles;
		private RFMBaseClasses.RFMTextBox txtUserNаme;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgvcCheck;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgvcRoleName;
		private RFMBaseClasses.RFMButton btnClearPhoto;
		private RFMBaseClasses.RFMLabel lblAlias;
		private RFMBaseClasses.RFMTextBox txtAlias;
		private RFMBaseClasses.RFMComboBox cboBrigades;
		private RFMBaseClasses.RFMLabel lblBrigade;
		private RFMBaseClasses.RFMLabel lblHost;
		private RFMBaseClasses.RFMComboBox cboHost;

	}
}

