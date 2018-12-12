namespace WMSSuitable
{
	partial class frmInputsUnloaders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnCancel = new RFMBaseClasses.RFMButton();
            this.btnSave = new RFMBaseClasses.RFMButton();
            this.btnGridSave = new RFMBaseClasses.RFMButton();
            this.btnGridUndo = new RFMBaseClasses.RFMButton();
            this.btnDelete = new RFMBaseClasses.RFMButton();
            this.btnEdit = new RFMBaseClasses.RFMButton();
            this.btnAdd = new RFMBaseClasses.RFMButton();
            this.bsCellsContents = new RFMBaseClasses.RFMBindingSource();
            this.pnlData = new RFMBaseClasses.RFMPanel();
            this.numPalletsFactQnt = new RFMBaseClasses.RFMNumericUpDown();
            this.lblPalletsFactQnt = new RFMBaseClasses.RFMLabel();
            this.numCoefficientUnload = new RFMBaseClasses.RFMNumericUpDown();
            this.CoefficientUnload = new RFMBaseClasses.RFMLabel();
            this.pnlDataChange = new RFMBaseClasses.RFMPanel();
            this.cboBrigade = new RFMBaseClasses.RFMComboBox();
            this.txtTabNumber = new RFMBaseClasses.RFMTextBox();
            this.cboUser = new RFMBaseClasses.RFMComboBox();
            this.lblUser = new RFMBaseClasses.RFMLabel();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.grcUserName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBrigadeName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.pnlSelectConditions = new RFMBaseClasses.RFMPanel();
            this.txtInputTypeName = new RFMBaseClasses.RFMTextBox();
            this.txtGoodStateName = new RFMBaseClasses.RFMTextBox();
            this.txtPartnerName = new RFMBaseClasses.RFMTextBox();
            this.txtOwnerName = new RFMBaseClasses.RFMTextBox();
            this.txtErpCode = new RFMBaseClasses.RFMTextBox();
            this.txtInputBarCode = new RFMBaseClasses.RFMTextBox();
            this.txtDateInput = new RFMBaseClasses.RFMTextBox();
            this.lblGoodStateName = new RFMBaseClasses.RFMLabel();
            this.lblPartnerName = new RFMBaseClasses.RFMLabel();
            this.lblOwnerName = new RFMBaseClasses.RFMLabel();
            this.lblInputTypeName = new RFMBaseClasses.RFMLabel();
            this.lblInputBarCode = new RFMBaseClasses.RFMLabel();
            this.lblDateInput = new RFMBaseClasses.RFMLabel();
            this.lblInputID = new RFMBaseClasses.RFMLabel();
            this.txtID = new RFMBaseClasses.RFMTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPalletsFactQnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficientUnload)).BeginInit();
            this.pnlDataChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.pnlSelectConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(6, 388);
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
            this.btnCancel.Location = new System.Drawing.Point(535, 388);
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
            this.btnSave.Location = new System.Drawing.Point(495, 388);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGridSave
            // 
            this.btnGridSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridSave.Image = global::WMSSuitable.Properties.Resources.Save;
            this.btnGridSave.Location = new System.Drawing.Point(531, 261);
            this.btnGridSave.Name = "btnGridSave";
            this.btnGridSave.Size = new System.Drawing.Size(30, 30);
            this.btnGridSave.TabIndex = 10;
            this.btnGridSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnGridSave, "Сохранить временные изменения");
            this.btnGridSave.UseVisualStyleBackColor = true;
            this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
            // 
            // btnGridUndo
            // 
            this.btnGridUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridUndo.Image = global::WMSSuitable.Properties.Resources.UnDo;
            this.btnGridUndo.Location = new System.Drawing.Point(491, 261);
            this.btnGridUndo.Name = "btnGridUndo";
            this.btnGridUndo.Size = new System.Drawing.Size(30, 30);
            this.btnGridUndo.TabIndex = 9;
            this.btnGridUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnGridUndo, "Отказаться от изменений");
            this.btnGridUndo.UseVisualStyleBackColor = true;
            this.btnGridUndo.Click += new System.EventHandler(this.btnGridUndo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(531, 224);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnDelete, "Удалить");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(491, 224);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 30);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnEdit, "Изменить");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(451, 224);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttToolTip.SetToolTip(this.btnAdd, "Добавить");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.numPalletsFactQnt);
            this.pnlData.Controls.Add(this.lblPalletsFactQnt);
            this.pnlData.Controls.Add(this.numCoefficientUnload);
            this.pnlData.Controls.Add(this.CoefficientUnload);
            this.pnlData.Controls.Add(this.btnGridSave);
            this.pnlData.Controls.Add(this.btnGridUndo);
            this.pnlData.Controls.Add(this.pnlDataChange);
            this.pnlData.Controls.Add(this.btnDelete);
            this.pnlData.Controls.Add(this.btnEdit);
            this.pnlData.Controls.Add(this.btnAdd);
            this.pnlData.Controls.Add(this.grdData);
            this.pnlData.Location = new System.Drawing.Point(2, 83);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(568, 298);
            this.pnlData.TabIndex = 0;
            // 
            // numPalletsFactQnt
            // 
            this.numPalletsFactQnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numPalletsFactQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numPalletsFactQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numPalletsFactQnt.InputMask = "###";
            this.numPalletsFactQnt.IsNull = false;
            this.numPalletsFactQnt.Location = new System.Drawing.Point(511, 5);
            this.numPalletsFactQnt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numPalletsFactQnt.Name = "numPalletsFactQnt";
            this.numPalletsFactQnt.RealPlaces = 3;
            this.numPalletsFactQnt.Size = new System.Drawing.Size(50, 22);
            this.numPalletsFactQnt.TabIndex = 3;
            this.numPalletsFactQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPalletsFactQnt
            // 
            this.lblPalletsFactQnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPalletsFactQnt.AutoSize = true;
            this.lblPalletsFactQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblPalletsFactQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPalletsFactQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPalletsFactQnt.Location = new System.Drawing.Point(393, 9);
            this.lblPalletsFactQnt.Name = "lblPalletsFactQnt";
            this.lblPalletsFactQnt.Size = new System.Drawing.Size(115, 14);
            this.lblPalletsFactQnt.TabIndex = 2;
            this.lblPalletsFactQnt.Text = "Принято поддонов";
            // 
            // numCoefficientUnload
            // 
            this.numCoefficientUnload.DecimalPlaces = 1;
            this.numCoefficientUnload.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numCoefficientUnload.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numCoefficientUnload.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numCoefficientUnload.InputMask = "#0.0";
            this.numCoefficientUnload.IsNull = false;
            this.numCoefficientUnload.Location = new System.Drawing.Point(218, 5);
            this.numCoefficientUnload.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numCoefficientUnload.Name = "numCoefficientUnload";
            this.numCoefficientUnload.RealPlaces = 2;
            this.numCoefficientUnload.Size = new System.Drawing.Size(50, 22);
            this.numCoefficientUnload.TabIndex = 1;
            this.numCoefficientUnload.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CoefficientUnload
            // 
            this.CoefficientUnload.AutoSize = true;
            this.CoefficientUnload.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.CoefficientUnload.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.CoefficientUnload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CoefficientUnload.Location = new System.Drawing.Point(2, 9);
            this.CoefficientUnload.Name = "CoefficientUnload";
            this.CoefficientUnload.Size = new System.Drawing.Size(213, 14);
            this.CoefficientUnload.TabIndex = 0;
            this.CoefficientUnload.Text = "Коэффициент сложности разгрузки";
            // 
            // pnlDataChange
            // 
            this.pnlDataChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDataChange.Controls.Add(this.cboBrigade);
            this.pnlDataChange.Controls.Add(this.txtTabNumber);
            this.pnlDataChange.Controls.Add(this.cboUser);
            this.pnlDataChange.Controls.Add(this.lblUser);
            this.pnlDataChange.Location = new System.Drawing.Point(3, 258);
            this.pnlDataChange.Name = "pnlDataChange";
            this.pnlDataChange.Size = new System.Drawing.Size(448, 33);
            this.pnlDataChange.TabIndex = 5;
            // 
            // cboBrigade
            // 
            this.cboBrigade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBrigade.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboBrigade.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboBrigade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrigade.Enabled = false;
            this.cboBrigade.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboBrigade.Location = new System.Drawing.Point(303, 5);
            this.cboBrigade.Name = "cboBrigade";
            this.cboBrigade.Size = new System.Drawing.Size(140, 22);
            this.cboBrigade.TabIndex = 3;
            // 
            // txtTabNumber
            // 
            this.txtTabNumber.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtTabNumber.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTabNumber.Location = new System.Drawing.Point(73, 5);
            this.txtTabNumber.MaxLength = 3;
            this.txtTabNumber.Name = "txtTabNumber";
            this.txtTabNumber.Size = new System.Drawing.Size(36, 22);
            this.txtTabNumber.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.txtTabNumber, "Табельный номер сотрудника (3 знака)");
            this.txtTabNumber.TextChanged += new System.EventHandler(this.txtTabNumber_TextChanged);
            // 
            // cboUser
            // 
            this.cboUser.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.cboUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.cboUser.Location = new System.Drawing.Point(112, 5);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(188, 22);
            this.cboUser.TabIndex = 2;
            this.cboUser.SelectedIndexChanged += new System.EventHandler(this.cboUser_SelectedIndexChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblUser.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Location = new System.Drawing.Point(3, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(67, 14);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Сотрудник";
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToOrderColumns = true;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcUserName,
            this.grcBrigadeName,
            this.grcID});
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(3, 31);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(558, 189);
            this.grdData.TabIndex = 4;
            this.grdData.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_RowEnter);
            // 
            // grcUserName
            // 
            this.grcUserName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcUserName.DataPropertyName = "UserName";
            this.grcUserName.HeaderText = "Сотрудник";
            this.grcUserName.Name = "grcUserName";
            this.grcUserName.ReadOnly = true;
            this.grcUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcUserName.Width = 120;
            // 
            // grcBrigadeName
            // 
            this.grcBrigadeName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBrigadeName.DataPropertyName = "BrigadeName";
            this.grcBrigadeName.HeaderText = "Бригада";
            this.grcBrigadeName.Name = "grcBrigadeName";
            this.grcBrigadeName.ReadOnly = true;
            this.grcBrigadeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcID
            // 
            this.grcID.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcID.DataPropertyName = "ID";
            this.grcID.HeaderText = "ID";
            this.grcID.Name = "grcID";
            this.grcID.ReadOnly = true;
            this.grcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcID.Visible = false;
            this.grcID.Width = 40;
            // 
            // pnlSelectConditions
            // 
            this.pnlSelectConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSelectConditions.Controls.Add(this.txtInputTypeName);
            this.pnlSelectConditions.Controls.Add(this.txtGoodStateName);
            this.pnlSelectConditions.Controls.Add(this.txtPartnerName);
            this.pnlSelectConditions.Controls.Add(this.txtOwnerName);
            this.pnlSelectConditions.Controls.Add(this.txtErpCode);
            this.pnlSelectConditions.Controls.Add(this.txtInputBarCode);
            this.pnlSelectConditions.Controls.Add(this.txtDateInput);
            this.pnlSelectConditions.Controls.Add(this.lblGoodStateName);
            this.pnlSelectConditions.Controls.Add(this.lblPartnerName);
            this.pnlSelectConditions.Controls.Add(this.lblOwnerName);
            this.pnlSelectConditions.Controls.Add(this.lblInputTypeName);
            this.pnlSelectConditions.Controls.Add(this.lblInputBarCode);
            this.pnlSelectConditions.Controls.Add(this.lblDateInput);
            this.pnlSelectConditions.Controls.Add(this.lblInputID);
            this.pnlSelectConditions.Controls.Add(this.txtID);
            this.pnlSelectConditions.Location = new System.Drawing.Point(2, 3);
            this.pnlSelectConditions.Name = "pnlSelectConditions";
            this.pnlSelectConditions.Size = new System.Drawing.Size(568, 77);
            this.pnlSelectConditions.TabIndex = 0;
            // 
            // txtInputTypeName
            // 
            this.txtInputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtInputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInputTypeName.Enabled = false;
            this.txtInputTypeName.Location = new System.Drawing.Point(248, 49);
            this.txtInputTypeName.Name = "txtInputTypeName";
            this.txtInputTypeName.Size = new System.Drawing.Size(130, 22);
            this.txtInputTypeName.TabIndex = 14;
            // 
            // txtGoodStateName
            // 
            this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGoodStateName.Enabled = false;
            this.txtGoodStateName.Location = new System.Drawing.Point(76, 49);
            this.txtGoodStateName.Name = "txtGoodStateName";
            this.txtGoodStateName.Size = new System.Drawing.Size(130, 22);
            this.txtGoodStateName.TabIndex = 12;
            // 
            // txtPartnerName
            // 
            this.txtPartnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtPartnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPartnerName.Enabled = false;
            this.txtPartnerName.Location = new System.Drawing.Point(289, 26);
            this.txtPartnerName.Name = "txtPartnerName";
            this.txtPartnerName.Size = new System.Drawing.Size(272, 22);
            this.txtPartnerName.TabIndex = 10;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwnerName.Enabled = false;
            this.txtOwnerName.Location = new System.Drawing.Point(76, 26);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(130, 22);
            this.txtOwnerName.TabIndex = 8;
            // 
            // txtErpCode
            // 
            this.txtErpCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtErpCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtErpCode.Enabled = false;
            this.txtErpCode.Location = new System.Drawing.Point(76, 3);
            this.txtErpCode.Name = "txtErpCode";
            this.txtErpCode.Size = new System.Drawing.Size(130, 22);
            this.txtErpCode.TabIndex = 2;
            // 
            // txtInputBarCode
            // 
            this.txtInputBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtInputBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInputBarCode.Enabled = false;
            this.txtInputBarCode.Location = new System.Drawing.Point(431, 3);
            this.txtInputBarCode.Name = "txtInputBarCode";
            this.txtInputBarCode.Size = new System.Drawing.Size(130, 22);
            this.txtInputBarCode.TabIndex = 6;
            // 
            // txtDateInput
            // 
            this.txtDateInput.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtDateInput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateInput.Enabled = false;
            this.txtDateInput.Location = new System.Drawing.Point(248, 3);
            this.txtDateInput.Name = "txtDateInput";
            this.txtDateInput.Size = new System.Drawing.Size(90, 22);
            this.txtDateInput.TabIndex = 4;
            // 
            // lblGoodStateName
            // 
            this.lblGoodStateName.AutoSize = true;
            this.lblGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodStateName.Location = new System.Drawing.Point(2, 53);
            this.lblGoodStateName.Name = "lblGoodStateName";
            this.lblGoodStateName.Size = new System.Drawing.Size(68, 14);
            this.lblGoodStateName.TabIndex = 11;
            this.lblGoodStateName.Text = "Состояние";
            // 
            // lblPartnerName
            // 
            this.lblPartnerName.AutoSize = true;
            this.lblPartnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblPartnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPartnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPartnerName.Location = new System.Drawing.Point(213, 29);
            this.lblPartnerName.Name = "lblPartnerName";
            this.lblPartnerName.Size = new System.Drawing.Size(68, 14);
            this.lblPartnerName.TabIndex = 9;
            this.lblPartnerName.Text = "Поставщик";
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.AutoSize = true;
            this.lblOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwnerName.Location = new System.Drawing.Point(2, 29);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(62, 14);
            this.lblOwnerName.TabIndex = 7;
            this.lblOwnerName.Text = "Владелец";
            // 
            // lblInputTypeName
            // 
            this.lblInputTypeName.AutoSize = true;
            this.lblInputTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInputTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInputTypeName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInputTypeName.Location = new System.Drawing.Point(213, 53);
            this.lblInputTypeName.Name = "lblInputTypeName";
            this.lblInputTypeName.Size = new System.Drawing.Size(29, 14);
            this.lblInputTypeName.TabIndex = 13;
            this.lblInputTypeName.Text = "Тип";
            // 
            // lblInputBarCode
            // 
            this.lblInputBarCode.AutoSize = true;
            this.lblInputBarCode.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInputBarCode.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInputBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInputBarCode.Location = new System.Drawing.Point(356, 6);
            this.lblInputBarCode.Name = "lblInputBarCode";
            this.lblInputBarCode.Size = new System.Drawing.Size(75, 14);
            this.lblInputBarCode.TabIndex = 5;
            this.lblInputBarCode.Text = "ШК прихода";
            // 
            // lblDateInput
            // 
            this.lblDateInput.AutoSize = true;
            this.lblDateInput.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateInput.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateInput.Location = new System.Drawing.Point(213, 6);
            this.lblDateInput.Name = "lblDateInput";
            this.lblDateInput.Size = new System.Drawing.Size(33, 14);
            this.lblDateInput.TabIndex = 3;
            this.lblDateInput.Text = "Дата";
            // 
            // lblInputID
            // 
            this.lblInputID.AutoSize = true;
            this.lblInputID.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblInputID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInputID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInputID.Location = new System.Drawing.Point(2, 6);
            this.lblInputID.Name = "lblInputID";
            this.lblInputID.Size = new System.Drawing.Size(28, 14);
            this.lblInputID.TabIndex = 0;
            this.lblInputID.Text = "Код";
            // 
            // txtID
            // 
            this.txtID.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(30, 3);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(45, 22);
            this.txtID.TabIndex = 1;
            // 
            // frmInputsUnloaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 423);
            this.Controls.Add(this.pnlSelectConditions);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.hpHelp.SetHelpKeyword(this, "533");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.Name = "frmInputsUnloaders";
            this.hpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Сотрудники, выполнявшие прием товара";
            this.Load += new System.EventHandler(this.frmInputsUnloaders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPalletsFactQnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficientUnload)).EndInit();
            this.pnlDataChange.ResumeLayout(false);
            this.pnlDataChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.pnlSelectConditions.ResumeLayout(false);
            this.pnlSelectConditions.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMBindingSource bsCellsContents;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMButton btnGridSave;
		private RFMBaseClasses.RFMButton btnGridUndo;
		private RFMBaseClasses.RFMPanel pnlDataChange;
		private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMButton btnAdd;
		private RFMBaseClasses.RFMDataGridView grdData;
		private RFMBaseClasses.RFMComboBox cboUser;
		private RFMBaseClasses.RFMLabel lblUser;
		private RFMBaseClasses.RFMPanel pnlSelectConditions;
		private RFMBaseClasses.RFMTextBox txtInputTypeName;
		private RFMBaseClasses.RFMTextBox txtGoodStateName;
		private RFMBaseClasses.RFMTextBox txtPartnerName;
		private RFMBaseClasses.RFMTextBox txtOwnerName;
		private RFMBaseClasses.RFMTextBox txtErpCode;
		private RFMBaseClasses.RFMTextBox txtInputBarCode;
		private RFMBaseClasses.RFMTextBox txtDateInput;
		private RFMBaseClasses.RFMLabel lblGoodStateName;
		private RFMBaseClasses.RFMLabel lblPartnerName;
		private RFMBaseClasses.RFMLabel lblOwnerName;
		private RFMBaseClasses.RFMLabel lblInputTypeName;
		private RFMBaseClasses.RFMLabel lblInputBarCode;
		private RFMBaseClasses.RFMLabel lblDateInput;
		private RFMBaseClasses.RFMLabel lblInputID;
		private RFMBaseClasses.RFMTextBox txtID;
		private RFMBaseClasses.RFMTextBox txtTabNumber;
		private RFMBaseClasses.RFMComboBox cboBrigade;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcUserName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBrigadeName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcID;
		private RFMBaseClasses.RFMNumericUpDown numCoefficientUnload;
		private RFMBaseClasses.RFMLabel CoefficientUnload;
		private RFMBaseClasses.RFMNumericUpDown numPalletsFactQnt;
		private RFMBaseClasses.RFMLabel lblPalletsFactQnt;
	}
}