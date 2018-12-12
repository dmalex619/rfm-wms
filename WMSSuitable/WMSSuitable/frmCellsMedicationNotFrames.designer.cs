namespace WMSSuitable
{
	partial class frmCellsMedicationNotFrames
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnGridSave = new RFMBaseClasses.RFMButton();
			this.btnGridUndo = new RFMBaseClasses.RFMButton();
			this.btnDelete = new RFMBaseClasses.RFMButton();
			this.btnEdit = new RFMBaseClasses.RFMButton();
			this.btnAdd = new RFMBaseClasses.RFMButton();
			this.btnPackings = new RFMBaseClasses.RFMButton();
			this.numRestQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.numBoxQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.bsCellsContents = new RFMBaseClasses.RFMBindingSource();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.lblNoteManual = new RFMBaseClasses.RFMLabel();
			this.txtNoteManual = new RFMBaseClasses.RFMTextBox();
			this.txtFixedPackingName = new RFMBaseClasses.RFMTextBox();
			this.txtFixedGoodStateName = new RFMBaseClasses.RFMTextBox();
			this.txtFixedOwnerName = new RFMBaseClasses.RFMTextBox();
			this.lblFixedPacking = new RFMBaseClasses.RFMLabel();
			this.pnlDataChange = new RFMBaseClasses.RFMPanel();
			this.btnOwnerClear = new RFMBaseClasses.RFMButton();
			this.cboOwner = new RFMBaseClasses.RFMComboBox();
			this.lblOwner = new RFMBaseClasses.RFMLabel();
			this.cboGoodState = new RFMBaseClasses.RFMComboBox();
			this.lblGoodState = new RFMBaseClasses.RFMLabel();
			this.lblQnt = new RFMBaseClasses.RFMLabel();
			this.lblBoxQnt = new RFMBaseClasses.RFMLabel();
			this.dtpDateValid = new RFMBaseClasses.RFMDateTimePicker();
			this.lblDateValid = new RFMBaseClasses.RFMLabel();
			this.lblAction = new RFMBaseClasses.RFMLabel();
			this.lblQntNew = new RFMBaseClasses.RFMLabel();
			this.lblGoodNew = new RFMBaseClasses.RFMLabel();
			this.txtGood = new RFMBaseClasses.RFMTextBox();
			this.cboGood = new RFMBaseClasses.RFMComboBox();
			this.grdCellsContents = new RFMBaseClasses.RFMDataGridView();
			this.lblCellID = new RFMBaseClasses.RFMLabel();
			this.lblFixedGoodState = new RFMBaseClasses.RFMLabel();
			this.lblFixedOwner = new RFMBaseClasses.RFMLabel();
			this.grcChangesImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcChanges = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPalQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPackingID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodStateID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellsContentsID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.numRestQnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxQnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).BeginInit();
			this.pnlData.SuspendLayout();
			this.pnlDataChange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).BeginInit();
			this.SuspendLayout();
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(6, 337);
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
			this.btnCancel.Location = new System.Drawing.Point(656, 337);
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
			this.btnSave.Location = new System.Drawing.Point(606, 337);
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
			this.btnGridSave.Location = new System.Drawing.Point(645, 258);
			this.btnGridSave.Name = "btnGridSave";
			this.btnGridSave.Size = new System.Drawing.Size(30, 30);
			this.btnGridSave.TabIndex = 14;
			this.btnGridSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridSave, "Сохранить временные изменения");
			this.btnGridSave.UseVisualStyleBackColor = true;
			this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
			// 
			// btnGridUndo
			// 
			this.btnGridUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridUndo.Image = global::WMSSuitable.Properties.Resources.UnDo;
			this.btnGridUndo.Location = new System.Drawing.Point(605, 258);
			this.btnGridUndo.Name = "btnGridUndo";
			this.btnGridUndo.Size = new System.Drawing.Size(30, 30);
			this.btnGridUndo.TabIndex = 15;
			this.btnGridUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridUndo, "Отказаться от изменений");
			this.btnGridUndo.UseVisualStyleBackColor = true;
			this.btnGridUndo.Click += new System.EventHandler(this.btnGridUndo_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
			this.btnDelete.Location = new System.Drawing.Point(645, 197);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 30);
			this.btnDelete.TabIndex = 13;
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnDelete, "Удалить");
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(605, 197);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 12;
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnEdit, "Изменить");
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
			this.btnAdd.Location = new System.Drawing.Point(566, 197);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(30, 30);
			this.btnAdd.TabIndex = 11;
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnAdd, "Добавить");
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnPackings
			// 
			this.btnPackings.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackings.Location = new System.Drawing.Point(47, 42);
			this.btnPackings.Name = "btnPackings";
			this.btnPackings.Size = new System.Drawing.Size(30, 30);
			this.btnPackings.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.btnPackings, "Выбор товара");
			this.btnPackings.UseVisualStyleBackColor = true;
			this.btnPackings.Click += new System.EventHandler(this.btnPackings_Click);
			// 
			// numRestQnt
			// 
			this.numRestQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestQnt.InputMask = "##########";
			this.numRestQnt.IsNull = false;
			this.numRestQnt.Location = new System.Drawing.Point(188, 74);
			this.numRestQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numRestQnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numRestQnt.Name = "numRestQnt";
			this.numRestQnt.RealPlaces = 10;
			this.numRestQnt.Size = new System.Drawing.Size(110, 22);
			this.numRestQnt.TabIndex = 14;
			this.numRestQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numRestQnt, "Дополнительно штук в нецелой коробке / кг");
			// 
			// numBoxQnt
			// 
			this.numBoxQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numBoxQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numBoxQnt.InputMask = "##########";
			this.numBoxQnt.IsNull = false;
			this.numBoxQnt.Location = new System.Drawing.Point(81, 74);
			this.numBoxQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numBoxQnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numBoxQnt.Name = "numBoxQnt";
			this.numBoxQnt.RealPlaces = 10;
			this.numBoxQnt.Size = new System.Drawing.Size(60, 22);
			this.numBoxQnt.TabIndex = 12;
			this.numBoxQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numBoxQnt, "количество целых коробок");
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(3, 4);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(126, 14);
			this.lblCell.TabIndex = 1;
			this.lblCell.Text = "Содержимое ячейки";
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblNoteManual);
			this.pnlData.Controls.Add(this.txtNoteManual);
			this.pnlData.Controls.Add(this.txtFixedPackingName);
			this.pnlData.Controls.Add(this.txtFixedGoodStateName);
			this.pnlData.Controls.Add(this.txtFixedOwnerName);
			this.pnlData.Controls.Add(this.lblFixedPacking);
			this.pnlData.Controls.Add(this.btnGridSave);
			this.pnlData.Controls.Add(this.btnGridUndo);
			this.pnlData.Controls.Add(this.pnlDataChange);
			this.pnlData.Controls.Add(this.btnDelete);
			this.pnlData.Controls.Add(this.btnEdit);
			this.pnlData.Controls.Add(this.btnAdd);
			this.pnlData.Controls.Add(this.grdCellsContents);
			this.pnlData.Controls.Add(this.lblCellID);
			this.pnlData.Controls.Add(this.lblFixedGoodState);
			this.pnlData.Controls.Add(this.lblFixedOwner);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Location = new System.Drawing.Point(4, 5);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(683, 326);
			this.pnlData.TabIndex = 1;
			// 
			// lblNoteManual
			// 
			this.lblNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblNoteManual.AutoSize = true;
			this.lblNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNoteManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNoteManual.Location = new System.Drawing.Point(3, 301);
			this.lblNoteManual.Name = "lblNoteManual";
			this.lblNoteManual.Size = new System.Drawing.Size(78, 14);
			this.lblNoteManual.TabIndex = 16;
			this.lblNoteManual.Text = "Примечание";
			// 
			// txtNoteManual
			// 
			this.txtNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNoteManual.Location = new System.Drawing.Point(85, 298);
			this.txtNoteManual.Name = "txtNoteManual";
			this.txtNoteManual.Size = new System.Drawing.Size(591, 22);
			this.txtNoteManual.TabIndex = 0;
			// 
			// txtFixedPackingName
			// 
			this.txtFixedPackingName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFixedPackingName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFixedPackingName.Enabled = false;
			this.txtFixedPackingName.Location = new System.Drawing.Point(75, 47);
			this.txtFixedPackingName.Name = "txtFixedPackingName";
			this.txtFixedPackingName.Size = new System.Drawing.Size(600, 22);
			this.txtFixedPackingName.TabIndex = 8;
			// 
			// txtFixedGoodStateName
			// 
			this.txtFixedGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFixedGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFixedGoodStateName.Enabled = false;
			this.txtFixedGoodStateName.Location = new System.Drawing.Point(456, 23);
			this.txtFixedGoodStateName.Name = "txtFixedGoodStateName";
			this.txtFixedGoodStateName.Size = new System.Drawing.Size(219, 22);
			this.txtFixedGoodStateName.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.txtFixedGoodStateName, "Состояние товара, закрепленное за ячейкой");
			// 
			// txtFixedOwnerName
			// 
			this.txtFixedOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtFixedOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFixedOwnerName.Enabled = false;
			this.txtFixedOwnerName.Location = new System.Drawing.Point(75, 23);
			this.txtFixedOwnerName.Name = "txtFixedOwnerName";
			this.txtFixedOwnerName.Size = new System.Drawing.Size(219, 22);
			this.txtFixedOwnerName.TabIndex = 4;
			this.ttToolTip.SetToolTip(this.txtFixedOwnerName, "Хранитель, закрепленный за ячейкой");
			// 
			// lblFixedPacking
			// 
			this.lblFixedPacking.AutoSize = true;
			this.lblFixedPacking.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedPacking.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedPacking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedPacking.Location = new System.Drawing.Point(3, 50);
			this.lblFixedPacking.Name = "lblFixedPacking";
			this.lblFixedPacking.Size = new System.Drawing.Size(41, 14);
			this.lblFixedPacking.TabIndex = 7;
			this.lblFixedPacking.Text = "Товар";
			// 
			// pnlDataChange
			// 
			this.pnlDataChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlDataChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDataChange.Controls.Add(this.btnOwnerClear);
			this.pnlDataChange.Controls.Add(this.cboOwner);
			this.pnlDataChange.Controls.Add(this.lblOwner);
			this.pnlDataChange.Controls.Add(this.cboGoodState);
			this.pnlDataChange.Controls.Add(this.lblGoodState);
			this.pnlDataChange.Controls.Add(this.lblQnt);
			this.pnlDataChange.Controls.Add(this.numRestQnt);
			this.pnlDataChange.Controls.Add(this.lblBoxQnt);
			this.pnlDataChange.Controls.Add(this.numBoxQnt);
			this.pnlDataChange.Controls.Add(this.dtpDateValid);
			this.pnlDataChange.Controls.Add(this.lblDateValid);
			this.pnlDataChange.Controls.Add(this.lblAction);
			this.pnlDataChange.Controls.Add(this.btnPackings);
			this.pnlDataChange.Controls.Add(this.lblQntNew);
			this.pnlDataChange.Controls.Add(this.lblGoodNew);
			this.pnlDataChange.Controls.Add(this.txtGood);
			this.pnlDataChange.Controls.Add(this.cboGood);
			this.pnlDataChange.Location = new System.Drawing.Point(3, 191);
			this.pnlDataChange.Name = "pnlDataChange";
			this.pnlDataChange.Size = new System.Drawing.Size(557, 102);
			this.pnlDataChange.TabIndex = 10;
			// 
			// btnOwnerClear
			// 
			this.btnOwnerClear.FlatAppearance.BorderSize = 0;
			this.btnOwnerClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOwnerClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnOwnerClear.Location = new System.Drawing.Point(252, 20);
			this.btnOwnerClear.Name = "btnOwnerClear";
			this.btnOwnerClear.Size = new System.Drawing.Size(25, 25);
			this.btnOwnerClear.TabIndex = 3;
			this.ttToolTip.SetToolTip(this.btnOwnerClear, "Очистить данные о хранителе");
			this.btnOwnerClear.UseVisualStyleBackColor = true;
			this.btnOwnerClear.Click += new System.EventHandler(this.btnOwnerClear_Click);
			// 
			// cboOwner
			// 
			this.cboOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOwner.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboOwner.Location = new System.Drawing.Point(81, 21);
			this.cboOwner.Name = "cboOwner";
			this.cboOwner.Size = new System.Drawing.Size(170, 22);
			this.cboOwner.TabIndex = 2;
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwner.Location = new System.Drawing.Point(3, 25);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(67, 14);
			this.lblOwner.TabIndex = 1;
			this.lblOwner.Text = "Хранитель";
			// 
			// cboGoodState
			// 
			this.cboGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGoodState.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGoodState.Location = new System.Drawing.Point(380, 21);
			this.cboGoodState.Name = "cboGoodState";
			this.cboGoodState.Size = new System.Drawing.Size(170, 22);
			this.cboGoodState.TabIndex = 5;
			// 
			// lblGoodState
			// 
			this.lblGoodState.AutoSize = true;
			this.lblGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodState.Location = new System.Drawing.Point(308, 25);
			this.lblGoodState.Name = "lblGoodState";
			this.lblGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblGoodState.TabIndex = 4;
			this.lblGoodState.Text = "Состояние";
			// 
			// lblQnt
			// 
			this.lblQnt.AutoSize = true;
			this.lblQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQnt.Location = new System.Drawing.Point(299, 78);
			this.lblQnt.Name = "lblQnt";
			this.lblQnt.Size = new System.Drawing.Size(41, 14);
			this.lblQnt.TabIndex = 15;
			this.lblQnt.Text = "шт./кг";
			// 
			// lblBoxQnt
			// 
			this.lblBoxQnt.AutoSize = true;
			this.lblBoxQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBoxQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBoxQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBoxQnt.Location = new System.Drawing.Point(147, 78);
			this.lblBoxQnt.Name = "lblBoxQnt";
			this.lblBoxQnt.Size = new System.Drawing.Size(47, 14);
			this.lblBoxQnt.TabIndex = 13;
			this.lblBoxQnt.Text = "кор. + ";
			// 
			// dtpDateValid
			// 
			this.dtpDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpDateValid.CustomFormat = "dd.MM.yyyy";
			this.dtpDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.dtpDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.dtpDateValid.Enabled = false;
			this.dtpDateValid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateValid.Location = new System.Drawing.Point(450, 74);
			this.dtpDateValid.Name = "dtpDateValid";
			this.dtpDateValid.Size = new System.Drawing.Size(100, 22);
			this.dtpDateValid.TabIndex = 0;
			// 
			// lblDateValid
			// 
			this.lblDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDateValid.AutoSize = true;
			this.lblDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateValid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateValid.Location = new System.Drawing.Point(357, 78);
			this.lblDateValid.Name = "lblDateValid";
			this.lblDateValid.Size = new System.Drawing.Size(90, 14);
			this.lblDateValid.TabIndex = 16;
			this.lblDateValid.Text = "Срок годн., до";
			// 
			// lblAction
			// 
			this.lblAction.AutoSize = true;
			this.lblAction.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblAction.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblAction.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAction.Location = new System.Drawing.Point(3, 5);
			this.lblAction.Name = "lblAction";
			this.lblAction.Size = new System.Drawing.Size(61, 14);
			this.lblAction.TabIndex = 0;
			this.lblAction.Text = "Действие";
			// 
			// lblQntNew
			// 
			this.lblQntNew.AutoSize = true;
			this.lblQntNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblQntNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblQntNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQntNew.Location = new System.Drawing.Point(3, 78);
			this.lblQntNew.Name = "lblQntNew";
			this.lblQntNew.Size = new System.Drawing.Size(74, 14);
			this.lblQntNew.TabIndex = 11;
			this.lblQntNew.Text = "Количество";
			// 
			// lblGoodNew
			// 
			this.lblGoodNew.AutoSize = true;
			this.lblGoodNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodNew.Location = new System.Drawing.Point(3, 50);
			this.lblGoodNew.Name = "lblGoodNew";
			this.lblGoodNew.Size = new System.Drawing.Size(41, 14);
			this.lblGoodNew.TabIndex = 6;
			this.lblGoodNew.Text = "Товар";
			// 
			// txtGood
			// 
			this.txtGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGood.Enabled = false;
			this.txtGood.Location = new System.Drawing.Point(81, 47);
			this.txtGood.Name = "txtGood";
			this.txtGood.Size = new System.Drawing.Size(468, 22);
			this.txtGood.TabIndex = 9;
			// 
			// cboGood
			// 
			this.cboGood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGood.Enabled = false;
			this.cboGood.FormattingEnabled = true;
			this.cboGood.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGood.Location = new System.Drawing.Point(85, 51);
			this.cboGood.Name = "cboGood";
			this.cboGood.Size = new System.Drawing.Size(469, 22);
			this.cboGood.TabIndex = 10;
			this.cboGood.Visible = false;
			// 
			// grdCellsContents
			// 
			this.grdCellsContents.AllowUserToAddRows = false;
			this.grdCellsContents.AllowUserToDeleteRows = false;
			this.grdCellsContents.AllowUserToOrderColumns = true;
			this.grdCellsContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdCellsContents.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdCellsContents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdCellsContents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdCellsContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdCellsContents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcChangesImage,
            this.grcChanges,
            this.grcGoodAlias,
            this.grcInBox,
            this.grcQnt,
            this.grcBoxQnt,
            this.grcPalQnt,
            this.grcDateValid,
            this.grcWeighting,
            this.grcGoodStateName,
            this.grcOwnerName,
            this.grcPackingID,
            this.grcOwnerID,
            this.grcGoodStateID,
            this.grcCellsContentsID});
			this.grdCellsContents.IsConfigInclude = true;
			this.grdCellsContents.IsMarkedAll = false;
			this.grdCellsContents.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdCellsContents.Location = new System.Drawing.Point(3, 73);
			this.grdCellsContents.MultiSelect = false;
			this.grdCellsContents.Name = "grdCellsContents";
			this.grdCellsContents.RangedWay = ' ';
			this.grdCellsContents.ReadOnly = true;
			this.grdCellsContents.RowHeadersWidth = 24;
			this.grdCellsContents.SelectedRowBorderColor = System.Drawing.Color.Empty;
			this.grdCellsContents.SelectedRowForeColor = System.Drawing.Color.Empty;
			this.grdCellsContents.Size = new System.Drawing.Size(674, 113);
			this.grdCellsContents.TabIndex = 9;
			this.grdCellsContents.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCellsContents_RowEnter);
			this.grdCellsContents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCellsContents_CellFormatting);
			// 
			// lblCellID
			// 
			this.lblCellID.AutoSize = true;
			this.lblCellID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblCellID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellID.Location = new System.Drawing.Point(135, 4);
			this.lblCellID.Name = "lblCellID";
			this.lblCellID.Size = new System.Drawing.Size(42, 14);
			this.lblCellID.TabIndex = 2;
			this.lblCellID.Text = "CellID";
			// 
			// lblFixedGoodState
			// 
			this.lblFixedGoodState.AutoSize = true;
			this.lblFixedGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedGoodState.Location = new System.Drawing.Point(381, 26);
			this.lblFixedGoodState.Name = "lblFixedGoodState";
			this.lblFixedGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblFixedGoodState.TabIndex = 5;
			this.lblFixedGoodState.Text = "Состояние";
			// 
			// lblFixedOwner
			// 
			this.lblFixedOwner.AutoSize = true;
			this.lblFixedOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixedOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixedOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixedOwner.Location = new System.Drawing.Point(3, 26);
			this.lblFixedOwner.Name = "lblFixedOwner";
			this.lblFixedOwner.Size = new System.Drawing.Size(67, 14);
			this.lblFixedOwner.TabIndex = 3;
			this.lblFixedOwner.Text = "Хранитель";
			// 
			// grcChangesImage
			// 
			this.grcChangesImage.HeaderText = "";
			this.grcChangesImage.Name = "grcChangesImage";
			this.grcChangesImage.ReadOnly = true;
			this.grcChangesImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcChangesImage.Width = 30;
			// 
			// grcChanges
			// 
			this.grcChanges.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcChanges.DataPropertyName = "Changes";
			this.grcChanges.HeaderText = "Изм.";
			this.grcChanges.Name = "grcChanges";
			this.grcChanges.ReadOnly = true;
			this.grcChanges.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcChanges.Visible = false;
			this.grcChanges.Width = 35;
			// 
			// grcGoodAlias
			// 
			this.grcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodAlias.DataPropertyName = "GoodAlias";
			this.grcGoodAlias.HeaderText = "Товар";
			this.grcGoodAlias.Name = "grcGoodAlias";
			this.grcGoodAlias.ReadOnly = true;
			this.grcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodAlias.Width = 250;
			// 
			// grcInBox
			// 
			this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcInBox.DataPropertyName = "InBox";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "N0";
			this.grcInBox.DefaultCellStyle = dataGridViewCellStyle2;
			this.grcInBox.HeaderText = "В кор.";
			this.grcInBox.Name = "grcInBox";
			this.grcInBox.ReadOnly = true;
			this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcInBox.ToolTipText = "Штук/кг в коробке";
			this.grcInBox.Width = 60;
			// 
			// grcQnt
			// 
			this.grcQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcQnt.DataPropertyName = "Qnt";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N3";
			dataGridViewCellStyle3.NullValue = null;
			this.grcQnt.DefaultCellStyle = dataGridViewCellStyle3;
			this.grcQnt.HeaderText = "Штук";
			this.grcQnt.Name = "grcQnt";
			this.grcQnt.ReadOnly = true;
			this.grcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQnt.Width = 80;
			// 
			// grcBoxQnt
			// 
			this.grcBoxQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxQnt.DataPropertyName = "BoxQnt";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N1";
			dataGridViewCellStyle4.NullValue = null;
			this.grcBoxQnt.DefaultCellStyle = dataGridViewCellStyle4;
			this.grcBoxQnt.HeaderText = "Кор.";
			this.grcBoxQnt.Name = "grcBoxQnt";
			this.grcBoxQnt.ReadOnly = true;
			this.grcBoxQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxQnt.Width = 60;
			// 
			// grcPalQnt
			// 
			this.grcPalQnt.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPalQnt.DataPropertyName = "PalQnt";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N2";
			dataGridViewCellStyle5.NullValue = null;
			this.grcPalQnt.DefaultCellStyle = dataGridViewCellStyle5;
			this.grcPalQnt.HeaderText = "Пал.";
			this.grcPalQnt.Name = "grcPalQnt";
			this.grcPalQnt.ReadOnly = true;
			this.grcPalQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPalQnt.Width = 60;
			// 
			// grcDateValid
			// 
			this.grcDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcDateValid.DataPropertyName = "DateValid";
			dataGridViewCellStyle6.Format = "d";
			dataGridViewCellStyle6.NullValue = null;
			this.grcDateValid.DefaultCellStyle = dataGridViewCellStyle6;
			this.grcDateValid.HeaderText = "Срок годн.";
			this.grcDateValid.Name = "grcDateValid";
			this.grcDateValid.ReadOnly = true;
			this.grcDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcDateValid.Width = 90;
			// 
			// grcWeighting
			// 
			this.grcWeighting.DataPropertyName = "Weighting";
			this.grcWeighting.HeaderText = "Вес?";
			this.grcWeighting.Name = "grcWeighting";
			this.grcWeighting.ReadOnly = true;
			this.grcWeighting.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcWeighting.ToolTipText = "Весовой товар?";
			this.grcWeighting.Visible = false;
			this.grcWeighting.Width = 40;
			// 
			// grcGoodStateName
			// 
			this.grcGoodStateName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodStateName.DataPropertyName = "GoodStateName";
			this.grcGoodStateName.HeaderText = "Состояние";
			this.grcGoodStateName.Name = "grcGoodStateName";
			this.grcGoodStateName.ReadOnly = true;
			this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcOwnerName
			// 
			this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcOwnerName.DataPropertyName = "OwnerName";
			this.grcOwnerName.HeaderText = "Хранитель";
			this.grcOwnerName.Name = "grcOwnerName";
			this.grcOwnerName.ReadOnly = true;
			this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcPackingID
			// 
			this.grcPackingID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcPackingID.DataPropertyName = "PackingID";
			this.grcPackingID.HeaderText = "PackingID";
			this.grcPackingID.Name = "grcPackingID";
			this.grcPackingID.ReadOnly = true;
			this.grcPackingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingID.Visible = false;
			// 
			// grcOwnerID
			// 
			this.grcOwnerID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcOwnerID.DataPropertyName = "OwnerID";
			this.grcOwnerID.HeaderText = "OwnerID";
			this.grcOwnerID.Name = "grcOwnerID";
			this.grcOwnerID.ReadOnly = true;
			this.grcOwnerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcOwnerID.Visible = false;
			// 
			// grcGoodStateID
			// 
			this.grcGoodStateID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcGoodStateID.DataPropertyName = "GoodStateID";
			this.grcGoodStateID.HeaderText = "GoodStateID";
			this.grcGoodStateID.Name = "grcGoodStateID";
			this.grcGoodStateID.ReadOnly = true;
			this.grcGoodStateID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodStateID.Visible = false;
			// 
			// grcCellsContentsID
			// 
			this.grcCellsContentsID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcCellsContentsID.DataPropertyName = "ID";
			this.grcCellsContentsID.HeaderText = "ID";
			this.grcCellsContentsID.Name = "grcCellsContentsID";
			this.grcCellsContentsID.ReadOnly = true;
			this.grcCellsContentsID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellsContentsID.Visible = false;
			this.grcCellsContentsID.Width = 40;
			// 
			// frmCellsMedicationNotFrames
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 373);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "533");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsMedicationNotFrames";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Изменение содержимого ячейки";
			this.Load += new System.EventHandler(this.frmCellsMedicationNotFrames_Load);
			((System.ComponentModel.ISupportInitialize)(this.numRestQnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxQnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).EndInit();
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.pnlDataChange.ResumeLayout(false);
			this.pnlDataChange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMBindingSource bsCellsContents;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMLabel lblFixedGoodState;
		private RFMBaseClasses.RFMLabel lblFixedOwner;
		private RFMBaseClasses.RFMLabel lblCellID;
		private RFMBaseClasses.RFMButton btnGridSave;
		private RFMBaseClasses.RFMButton btnGridUndo;
		private RFMBaseClasses.RFMPanel pnlDataChange;
		private RFMBaseClasses.RFMDateTimePicker dtpDateValid;
		private RFMBaseClasses.RFMLabel lblDateValid;
		private RFMBaseClasses.RFMLabel lblAction;
		private RFMBaseClasses.RFMButton btnPackings;
		private RFMBaseClasses.RFMLabel lblQntNew;
		private RFMBaseClasses.RFMLabel lblGoodNew;
		private RFMBaseClasses.RFMComboBox cboGood;
		private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMButton btnAdd;
		private RFMBaseClasses.RFMDataGridView grdCellsContents;
		private RFMBaseClasses.RFMLabel lblFixedPacking;
		private RFMBaseClasses.RFMLabel lblQnt;
		private RFMBaseClasses.RFMNumericUpDown numRestQnt;
		private RFMBaseClasses.RFMLabel lblBoxQnt;
		private RFMBaseClasses.RFMNumericUpDown numBoxQnt;
		private RFMBaseClasses.RFMTextBox txtFixedPackingName;
		private RFMBaseClasses.RFMTextBox txtFixedGoodStateName;
		private RFMBaseClasses.RFMTextBox txtFixedOwnerName;
		private RFMBaseClasses.RFMTextBox txtGood;
		private RFMBaseClasses.RFMLabel lblNoteManual;
		private RFMBaseClasses.RFMTextBox txtNoteManual;
		private RFMBaseClasses.RFMComboBox cboGoodState;
		private RFMBaseClasses.RFMLabel lblGoodState;
		private RFMBaseClasses.RFMButton btnOwnerClear;
		private RFMBaseClasses.RFMComboBox cboOwner;
		private RFMBaseClasses.RFMLabel lblOwner;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcChangesImage;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcChanges;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellsContentsID;
	}
}