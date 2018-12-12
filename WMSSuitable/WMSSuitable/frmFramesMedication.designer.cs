namespace WMSSuitable
{
	partial class frmFramesMedication
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.lblNoteManual = new RFMBaseClasses.RFMLabel();
			this.txtNoteManual = new RFMBaseClasses.RFMTextBox();
			this.grdFramesContents = new RFMBaseClasses.RFMDataGridView();
			this.btnCellChange = new RFMBaseClasses.RFMButton();
			this.lblCellAddress = new RFMBaseClasses.RFMLabel();
			this.btnOwnerClear = new RFMBaseClasses.RFMButton();
			this.lblFrameID = new RFMBaseClasses.RFMLabel();
			this.cboGoodState = new RFMBaseClasses.RFMComboBox();
			this.cboOwner = new RFMBaseClasses.RFMComboBox();
			this.lblFrameInCell = new RFMBaseClasses.RFMLabel();
			this.lblGoodState = new RFMBaseClasses.RFMLabel();
			this.lblFrame = new RFMBaseClasses.RFMLabel();
			this.btnGridSave = new RFMBaseClasses.RFMButton();
			this.lblOwner = new RFMBaseClasses.RFMLabel();
			this.btnGridUndo = new RFMBaseClasses.RFMButton();
			this.pnlDataChange = new RFMBaseClasses.RFMPanel();
			this.lblQnt = new RFMBaseClasses.RFMLabel();
			this.numRestQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.lblBoxQnt = new RFMBaseClasses.RFMLabel();
			this.dtpDateValid = new RFMBaseClasses.RFMDateTimePicker();
			this.lblDateValid = new RFMBaseClasses.RFMLabel();
			this.lblAction = new RFMBaseClasses.RFMLabel();
			this.btnPackings = new RFMBaseClasses.RFMButton();
			this.lblQntNew = new RFMBaseClasses.RFMLabel();
			this.numBoxQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.lblGoodNew = new RFMBaseClasses.RFMLabel();
			this.txtGood = new RFMBaseClasses.RFMTextBox();
			this.cboGood = new RFMBaseClasses.RFMComboBox();
			this.btnDelete = new RFMBaseClasses.RFMButton();
			this.btnEdit = new RFMBaseClasses.RFMButton();
			this.btnAdd = new RFMBaseClasses.RFMButton();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnCancel = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.btnFrameEdit = new RFMBaseClasses.RFMButton();
			this.grcChangesImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPalQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcBoxInPal = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPackingID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcCellsContentsID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcChanges = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdFramesContents)).BeginInit();
			this.pnlDataChange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestQnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxQnt)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.lblNoteManual);
			this.pnlData.Controls.Add(this.txtNoteManual);
			this.pnlData.Controls.Add(this.grdFramesContents);
			this.pnlData.Controls.Add(this.btnCellChange);
			this.pnlData.Controls.Add(this.lblCellAddress);
			this.pnlData.Controls.Add(this.btnOwnerClear);
			this.pnlData.Controls.Add(this.lblFrameID);
			this.pnlData.Controls.Add(this.cboGoodState);
			this.pnlData.Controls.Add(this.cboOwner);
			this.pnlData.Controls.Add(this.lblFrameInCell);
			this.pnlData.Controls.Add(this.lblGoodState);
			this.pnlData.Controls.Add(this.lblFrame);
			this.pnlData.Controls.Add(this.btnGridSave);
			this.pnlData.Controls.Add(this.lblOwner);
			this.pnlData.Controls.Add(this.btnGridUndo);
			this.pnlData.Controls.Add(this.pnlDataChange);
			this.pnlData.Controls.Add(this.btnDelete);
			this.pnlData.Controls.Add(this.btnEdit);
			this.pnlData.Controls.Add(this.btnAdd);
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
			this.lblNoteManual.Location = new System.Drawing.Point(1, 301);
			this.lblNoteManual.Name = "lblNoteManual";
			this.lblNoteManual.Size = new System.Drawing.Size(78, 14);
			this.lblNoteManual.TabIndex = 17;
			this.lblNoteManual.Text = "Примечание";
			// 
			// txtNoteManual
			// 
			this.txtNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNoteManual.Location = new System.Drawing.Point(83, 298);
			this.txtNoteManual.Name = "txtNoteManual";
			this.txtNoteManual.Size = new System.Drawing.Size(593, 22);
			this.txtNoteManual.TabIndex = 18;
			// 
			// grdFramesContents
			// 
			this.grdFramesContents.AllowUserToAddRows = false;
			this.grdFramesContents.AllowUserToDeleteRows = false;
			this.grdFramesContents.AllowUserToOrderColumns = true;
			this.grdFramesContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdFramesContents.BackgroundColor = System.Drawing.SystemColors.Window;
			this.grdFramesContents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdFramesContents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdFramesContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdFramesContents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcChangesImage,
            this.grcGoodAlias,
            this.grcInBox,
            this.grcQnt,
            this.grcBoxQnt,
            this.grcPalQnt,
            this.grcDateValid,
            this.grcWeighting,
            this.grcBoxInPal,
            this.grcPackingID,
            this.grcCellsContentsID,
            this.grcChanges});
			this.grdFramesContents.IsConfigInclude = true;
			this.grdFramesContents.IsMarkedAll = false;
			this.grdFramesContents.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdFramesContents.Location = new System.Drawing.Point(3, 49);
			this.grdFramesContents.MultiSelect = false;
			this.grdFramesContents.Name = "grdFramesContents";
			this.grdFramesContents.RangedWay = ' ';
			this.grdFramesContents.ReadOnly = true;
			this.grdFramesContents.RowHeadersWidth = 24;
			this.grdFramesContents.SelectedRowBorderColor = System.Drawing.Color.Empty;
			this.grdFramesContents.SelectedRowForeColor = System.Drawing.Color.Empty;
			this.grdFramesContents.Size = new System.Drawing.Size(673, 154);
			this.grdFramesContents.TabIndex = 10;
			this.grdFramesContents.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFramesContents_RowEnter);
			this.grdFramesContents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdFramesContents_CellFormatting);
			// 
			// btnCellChange
			// 
			this.btnCellChange.FlatAppearance.BorderSize = 0;
			this.btnCellChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCellChange.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnCellChange.Location = new System.Drawing.Point(426, 0);
			this.btnCellChange.Name = "btnCellChange";
			this.btnCellChange.Size = new System.Drawing.Size(25, 25);
			this.btnCellChange.TabIndex = 3;
			this.ttToolTip.SetToolTip(this.btnCellChange, "Изменить ячейку, в которой размещается контейнер");
			this.btnCellChange.UseVisualStyleBackColor = true;
			this.btnCellChange.Click += new System.EventHandler(this.btnCellChange_Click);
			// 
			// lblCellAddress
			// 
			this.lblCellAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblCellAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellAddress.Location = new System.Drawing.Point(454, 4);
			this.lblCellAddress.Name = "lblCellAddress";
			this.lblCellAddress.Size = new System.Drawing.Size(220, 14);
			this.lblCellAddress.TabIndex = 4;
			this.lblCellAddress.Text = "CellAddress";
			// 
			// btnOwnerClear
			// 
			this.btnOwnerClear.FlatAppearance.BorderSize = 0;
			this.btnOwnerClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOwnerClear.Image = global::WMSSuitable.Properties.Resources.DeleteAll;
			this.btnOwnerClear.Location = new System.Drawing.Point(303, 19);
			this.btnOwnerClear.Name = "btnOwnerClear";
			this.btnOwnerClear.Size = new System.Drawing.Size(25, 25);
			this.btnOwnerClear.TabIndex = 7;
			this.ttToolTip.SetToolTip(this.btnOwnerClear, "Очистить данные о хранителе");
			this.btnOwnerClear.UseVisualStyleBackColor = true;
			this.btnOwnerClear.Click += new System.EventHandler(this.btnOwnerClear_Click);
			// 
			// lblFrameID
			// 
			this.lblFrameID.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrameID.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrameID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblFrameID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameID.Location = new System.Drawing.Point(160, 4);
			this.lblFrameID.Name = "lblFrameID";
			this.lblFrameID.Size = new System.Drawing.Size(99, 14);
			this.lblFrameID.TabIndex = 1;
			this.lblFrameID.Text = "FrameID";
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
			this.cboGoodState.Location = new System.Drawing.Point(456, 21);
			this.cboGoodState.Name = "cboGoodState";
			this.cboGoodState.Size = new System.Drawing.Size(220, 22);
			this.cboGoodState.TabIndex = 9;
			// 
			// cboOwner
			// 
			this.cboOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOwner.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboOwner.Location = new System.Drawing.Point(80, 21);
			this.cboOwner.Name = "cboOwner";
			this.cboOwner.Size = new System.Drawing.Size(222, 22);
			this.cboOwner.TabIndex = 6;
			// 
			// lblFrameInCell
			// 
			this.lblFrameInCell.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrameInCell.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrameInCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrameInCell.Location = new System.Drawing.Point(378, 4);
			this.lblFrameInCell.Name = "lblFrameInCell";
			this.lblFrameInCell.Size = new System.Drawing.Size(59, 14);
			this.lblFrameInCell.TabIndex = 2;
			this.lblFrameInCell.Text = "Ячейка";
			// 
			// lblGoodState
			// 
			this.lblGoodState.AutoSize = true;
			this.lblGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodState.Location = new System.Drawing.Point(378, 24);
			this.lblGoodState.Name = "lblGoodState";
			this.lblGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblGoodState.TabIndex = 8;
			this.lblGoodState.Text = "Состояние";
			// 
			// lblFrame
			// 
			this.lblFrame.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFrame.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFrame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFrame.Location = new System.Drawing.Point(3, 4);
			this.lblFrame.Name = "lblFrame";
			this.lblFrame.Size = new System.Drawing.Size(163, 14);
			this.lblFrame.TabIndex = 0;
			this.lblFrame.Text = "Содержимое контейнера";
			// 
			// btnGridSave
			// 
			this.btnGridSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnGridSave.Location = new System.Drawing.Point(645, 260);
			this.btnGridSave.Name = "btnGridSave";
			this.btnGridSave.Size = new System.Drawing.Size(30, 30);
			this.btnGridSave.TabIndex = 15;
			this.btnGridSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridSave, "Сохранить временные изменения");
			this.btnGridSave.UseVisualStyleBackColor = true;
			this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwner.Location = new System.Drawing.Point(3, 24);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(67, 14);
			this.lblOwner.TabIndex = 5;
			this.lblOwner.Text = "Хранитель";
			// 
			// btnGridUndo
			// 
			this.btnGridUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridUndo.Image = global::WMSSuitable.Properties.Resources.UnDo;
			this.btnGridUndo.Location = new System.Drawing.Point(605, 260);
			this.btnGridUndo.Name = "btnGridUndo";
			this.btnGridUndo.Size = new System.Drawing.Size(30, 30);
			this.btnGridUndo.TabIndex = 16;
			this.btnGridUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridUndo, "Отказаться от изменений");
			this.btnGridUndo.UseVisualStyleBackColor = true;
			this.btnGridUndo.Click += new System.EventHandler(this.btnGridUndo_Click);
			// 
			// pnlDataChange
			// 
			this.pnlDataChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlDataChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDataChange.Controls.Add(this.lblQnt);
			this.pnlDataChange.Controls.Add(this.numRestQnt);
			this.pnlDataChange.Controls.Add(this.lblBoxQnt);
			this.pnlDataChange.Controls.Add(this.dtpDateValid);
			this.pnlDataChange.Controls.Add(this.lblDateValid);
			this.pnlDataChange.Controls.Add(this.lblAction);
			this.pnlDataChange.Controls.Add(this.btnPackings);
			this.pnlDataChange.Controls.Add(this.lblQntNew);
			this.pnlDataChange.Controls.Add(this.numBoxQnt);
			this.pnlDataChange.Controls.Add(this.lblGoodNew);
			this.pnlDataChange.Controls.Add(this.txtGood);
			this.pnlDataChange.Controls.Add(this.cboGood);
			this.pnlDataChange.Location = new System.Drawing.Point(3, 208);
			this.pnlDataChange.Name = "pnlDataChange";
			this.pnlDataChange.Size = new System.Drawing.Size(557, 86);
			this.pnlDataChange.TabIndex = 11;
			// 
			// lblQnt
			// 
			this.lblQnt.AutoSize = true;
			this.lblQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQnt.Location = new System.Drawing.Point(299, 62);
			this.lblQnt.Name = "lblQnt";
			this.lblQnt.Size = new System.Drawing.Size(41, 14);
			this.lblQnt.TabIndex = 9;
			this.lblQnt.Text = "шт./кг";
			// 
			// numRestQnt
			// 
			this.numRestQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numRestQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numRestQnt.InputMask = "#######";
			this.numRestQnt.IsNull = false;
			this.numRestQnt.Location = new System.Drawing.Point(188, 57);
			this.numRestQnt.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.numRestQnt.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
			this.numRestQnt.Name = "numRestQnt";
			this.numRestQnt.RealPlaces = 7;
			this.numRestQnt.Size = new System.Drawing.Size(110, 22);
			this.numRestQnt.TabIndex = 8;
			this.numRestQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numRestQnt, "Дополнительно штук в нецелой коробке / кг");
			// 
			// lblBoxQnt
			// 
			this.lblBoxQnt.AutoSize = true;
			this.lblBoxQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblBoxQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblBoxQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblBoxQnt.Location = new System.Drawing.Point(144, 62);
			this.lblBoxQnt.Name = "lblBoxQnt";
			this.lblBoxQnt.Size = new System.Drawing.Size(47, 14);
			this.lblBoxQnt.TabIndex = 7;
			this.lblBoxQnt.Text = "кор. + ";
			// 
			// dtpDateValid
			// 
			this.dtpDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpDateValid.CustomFormat = "dd.MM.yyyy";
			this.dtpDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.dtpDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.dtpDateValid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateValid.Location = new System.Drawing.Point(450, 58);
			this.dtpDateValid.Name = "dtpDateValid";
			this.dtpDateValid.Size = new System.Drawing.Size(100, 22);
			this.dtpDateValid.TabIndex = 11;
			// 
			// lblDateValid
			// 
			this.lblDateValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDateValid.AutoSize = true;
			this.lblDateValid.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateValid.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateValid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateValid.Location = new System.Drawing.Point(356, 62);
			this.lblDateValid.Name = "lblDateValid";
			this.lblDateValid.Size = new System.Drawing.Size(90, 14);
			this.lblDateValid.TabIndex = 10;
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
			// btnPackings
			// 
			this.btnPackings.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackings.Location = new System.Drawing.Point(47, 26);
			this.btnPackings.Name = "btnPackings";
			this.btnPackings.Size = new System.Drawing.Size(30, 30);
			this.btnPackings.TabIndex = 2;
			this.ttToolTip.SetToolTip(this.btnPackings, "Выбор товара");
			this.btnPackings.UseVisualStyleBackColor = true;
			this.btnPackings.Click += new System.EventHandler(this.btnPackings_Click);
			// 
			// lblQntNew
			// 
			this.lblQntNew.AutoSize = true;
			this.lblQntNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblQntNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblQntNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQntNew.Location = new System.Drawing.Point(3, 62);
			this.lblQntNew.Name = "lblQntNew";
			this.lblQntNew.Size = new System.Drawing.Size(78, 14);
			this.lblQntNew.TabIndex = 5;
			this.lblQntNew.Text = "Количество:";
			// 
			// numBoxQnt
			// 
			this.numBoxQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numBoxQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numBoxQnt.InputMask = "#######";
			this.numBoxQnt.IsNull = false;
			this.numBoxQnt.Location = new System.Drawing.Point(81, 57);
			this.numBoxQnt.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.numBoxQnt.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
			this.numBoxQnt.Name = "numBoxQnt";
			this.numBoxQnt.RealPlaces = 7;
			this.numBoxQnt.Size = new System.Drawing.Size(60, 22);
			this.numBoxQnt.TabIndex = 6;
			this.numBoxQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ttToolTip.SetToolTip(this.numBoxQnt, "количество целых коробок");
			// 
			// lblGoodNew
			// 
			this.lblGoodNew.AutoSize = true;
			this.lblGoodNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodNew.Location = new System.Drawing.Point(3, 34);
			this.lblGoodNew.Name = "lblGoodNew";
			this.lblGoodNew.Size = new System.Drawing.Size(41, 14);
			this.lblGoodNew.TabIndex = 1;
			this.lblGoodNew.Text = "Товар";
			// 
			// txtGood
			// 
			this.txtGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGood.Enabled = false;
			this.txtGood.Location = new System.Drawing.Point(81, 30);
			this.txtGood.Name = "txtGood";
			this.txtGood.Size = new System.Drawing.Size(467, 22);
			this.txtGood.TabIndex = 3;
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
			this.cboGood.Location = new System.Drawing.Point(84, 33);
			this.cboGood.Name = "cboGood";
			this.cboGood.Size = new System.Drawing.Size(469, 22);
			this.cboGood.TabIndex = 4;
			this.cboGood.Visible = false;
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
			this.btnDelete.Location = new System.Drawing.Point(645, 214);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 30);
			this.btnDelete.TabIndex = 14;
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnDelete, "Удалить");
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(605, 214);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 13;
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnEdit, "Изменить");
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
			this.btnAdd.Location = new System.Drawing.Point(566, 214);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(30, 30);
			this.btnAdd.TabIndex = 12;
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnAdd, "Добавить");
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
			this.btnSave.TabIndex = 0;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnFrameEdit
			// 
			this.btnFrameEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFrameEdit.Image = global::WMSSuitable.Properties.Resources.Geometry1;
			this.btnFrameEdit.Location = new System.Drawing.Point(556, 337);
			this.btnFrameEdit.Name = "btnFrameEdit";
			this.btnFrameEdit.Size = new System.Drawing.Size(30, 30);
			this.btnFrameEdit.TabIndex = 5;
			this.btnFrameEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnFrameEdit, "Изменить тип поддона и высоту контейнера");
			this.btnFrameEdit.UseVisualStyleBackColor = true;
			this.btnFrameEdit.Click += new System.EventHandler(this.btnFrameEdit_Click);
			// 
			// grcChangesImage
			// 
			this.grcChangesImage.HeaderText = "";
			this.grcChangesImage.Name = "grcChangesImage";
			this.grcChangesImage.ReadOnly = true;
			this.grcChangesImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcChangesImage.Width = 30;
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
			this.grcWeighting.Width = 40;
			// 
			// grcBoxInPal
			// 
			this.grcBoxInPal.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcBoxInPal.DataPropertyName = "BoxInPal";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N0";
			this.grcBoxInPal.DefaultCellStyle = dataGridViewCellStyle7;
			this.grcBoxInPal.HeaderText = "Кор.на пал.";
			this.grcBoxInPal.Name = "grcBoxInPal";
			this.grcBoxInPal.ReadOnly = true;
			this.grcBoxInPal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxInPal.ToolTipText = "Коробок на паллете, по умолчанию";
			this.grcBoxInPal.Width = 60;
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
			// frmFramesMedication
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(692, 373);
			this.Controls.Add(this.btnFrameEdit);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "631");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmFramesMedication";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Изменение содержимого контейнера";
			this.Load += new System.EventHandler(this.frmFramesMedication_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdFramesContents)).EndInit();
			this.pnlDataChange.ResumeLayout(false);
			this.pnlDataChange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRestQnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBoxQnt)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
        private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMDataGridView grdFramesContents;
		private RFMBaseClasses.RFMButton btnAdd;
		private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMButton btnEdit;
		private RFMBaseClasses.RFMPanel pnlDataChange;
		private RFMBaseClasses.RFMLabel lblOwner;
		private RFMBaseClasses.RFMLabel lblQntNew;
		private RFMBaseClasses.RFMNumericUpDown numBoxQnt;
		private RFMBaseClasses.RFMLabel lblGoodNew;
		private RFMBaseClasses.RFMComboBox cboGood;
		private RFMBaseClasses.RFMLabel lblGoodState;
		private RFMBaseClasses.RFMButton btnPackings;
		private RFMBaseClasses.RFMButton btnGridSave;
		private RFMBaseClasses.RFMButton btnGridUndo;
		private RFMBaseClasses.RFMLabel lblFrame;
		private RFMBaseClasses.RFMLabel lblFrameInCell;
		private RFMBaseClasses.RFMLabel lblAction;
		private RFMBaseClasses.RFMComboBox cboGoodState;
		private RFMBaseClasses.RFMComboBox cboOwner;
		private RFMBaseClasses.RFMLabel lblFrameID;
		private RFMBaseClasses.RFMDateTimePicker dtpDateValid;
		private RFMBaseClasses.RFMLabel lblDateValid;
		private RFMBaseClasses.RFMButton btnOwnerClear;
		private RFMBaseClasses.RFMLabel lblCellAddress;
		private RFMBaseClasses.RFMButton btnCellChange;
		private RFMBaseClasses.RFMLabel lblQnt;
		private RFMBaseClasses.RFMNumericUpDown numRestQnt;
		private RFMBaseClasses.RFMLabel lblBoxQnt;
		private RFMBaseClasses.RFMButton btnFrameEdit;
		private RFMBaseClasses.RFMTextBox txtGood;
		private RFMBaseClasses.RFMLabel lblNoteManual;
		private RFMBaseClasses.RFMTextBox txtNoteManual;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcChangesImage;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxInPal;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellsContentsID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcChanges;
	}
}