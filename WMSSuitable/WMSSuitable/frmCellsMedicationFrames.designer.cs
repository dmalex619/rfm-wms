namespace WMSSuitable
{
	partial class frmCellsMedicationFrames
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
			this.btnAdd = new RFMBaseClasses.RFMButton();
			this.btnDelete = new RFMBaseClasses.RFMButton();
			this.btnGridUndo = new RFMBaseClasses.RFMButton();
			this.btnGridSave = new RFMBaseClasses.RFMButton();
			this.grdCellsContents = new RFMBaseClasses.RFMDataGridView();
			this.grcChangesImage = new RFMBaseClasses.RFMDataGridViewImageColumn();
			this.grcChanges = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcFrameID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcBoxQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPalQnt = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.grcCellsContentsID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcPackingID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcOwnerID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.grcGoodStateID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.pnlDataChange = new RFMBaseClasses.RFMPanel();
			this.txtFrameID = new RFMBaseClasses.RFMTextBoxNumeric();
			this.lblGoodState = new RFMBaseClasses.RFMLabel();
			this.cboGoodState = new RFMBaseClasses.RFMComboBox();
			this.lblOwner = new RFMBaseClasses.RFMLabel();
			this.cboOwner = new RFMBaseClasses.RFMComboBox();
			this.lblQntNew = new RFMBaseClasses.RFMLabel();
			this.numQnt = new RFMBaseClasses.RFMNumericUpDown();
			this.lblGoodNew = new RFMBaseClasses.RFMLabel();
			this.cboGood = new RFMBaseClasses.RFMComboBox();
			this.lbFrameNew = new RFMBaseClasses.RFMLabel();
			this.cboFrame = new RFMBaseClasses.RFMComboBox();
			this.lblCell = new RFMBaseClasses.RFMLabel();
			this.pnlData = new RFMBaseClasses.RFMPanel();
			this.lblNoteManual = new RFMBaseClasses.RFMLabel();
			this.txtNoteManual = new RFMBaseClasses.RFMTextBox();
			this.cboFixedPacking = new RFMBaseClasses.RFMComboBox();
			this.lblFixedPacking = new RFMBaseClasses.RFMLabel();
			this.lblCellID = new RFMBaseClasses.RFMLabel();
			this.cboFixedGoodState = new RFMBaseClasses.RFMComboBox();
			this.cboFixedOwner = new RFMBaseClasses.RFMComboBox();
			this.lblFixedGoodState = new RFMBaseClasses.RFMLabel();
			this.lblFixesOwner = new RFMBaseClasses.RFMLabel();
			this.lblMaxPalletQnt = new RFMBaseClasses.RFMLabel();
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).BeginInit();
			this.pnlDataChange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQnt)).BeginInit();
			this.pnlData.SuspendLayout();
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
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
			this.btnAdd.Location = new System.Drawing.Point(605, 212);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(30, 30);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnAdd, "Добавить");
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
			this.btnDelete.Location = new System.Drawing.Point(645, 212);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 30);
			this.btnDelete.TabIndex = 15;
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnDelete, "Удалить");
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnGridUndo
			// 
			this.btnGridUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridUndo.Image = global::WMSSuitable.Properties.Resources.UnDo;
			this.btnGridUndo.Location = new System.Drawing.Point(605, 258);
			this.btnGridUndo.Name = "btnGridUndo";
			this.btnGridUndo.Size = new System.Drawing.Size(30, 30);
			this.btnGridUndo.TabIndex = 17;
			this.btnGridUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridUndo, "Отказаться от изменений");
			this.btnGridUndo.UseVisualStyleBackColor = true;
			this.btnGridUndo.Click += new System.EventHandler(this.btnGridUndo_Click);
			// 
			// btnGridSave
			// 
			this.btnGridSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnGridSave.Location = new System.Drawing.Point(645, 258);
			this.btnGridSave.Name = "btnGridSave";
			this.btnGridSave.Size = new System.Drawing.Size(30, 30);
			this.btnGridSave.TabIndex = 18;
			this.btnGridSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridSave, "Сохранить временные изменения");
			this.btnGridSave.UseVisualStyleBackColor = true;
			this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
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
            this.grcFrameID,
            this.grcOwnerName,
            this.grcGoodStateName,
            this.grcGoodAlias,
            this.grcInBox,
            this.grcQnt,
            this.grcBoxQnt,
            this.grcPalQnt,
            this.grcDateValid,
            this.grcWeighting,
            this.grcCellsContentsID,
            this.grcPackingID,
            this.grcOwnerID,
            this.grcGoodStateID});
			this.grdCellsContents.IsConfigInclude = true;
			this.grdCellsContents.IsMarkedAll = false;
			this.grdCellsContents.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.grdCellsContents.Location = new System.Drawing.Point(3, 70);
			this.grdCellsContents.MultiSelect = false;
			this.grdCellsContents.Name = "grdCellsContents";
			this.grdCellsContents.RangedWay = ' ';
			this.grdCellsContents.ReadOnly = true;
			this.grdCellsContents.RowHeadersWidth = 24;
			this.grdCellsContents.Size = new System.Drawing.Size(673, 131);
			this.grdCellsContents.TabIndex = 12;
			this.grdCellsContents.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCellsContents_RowEnter);
			this.grdCellsContents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCellsContents_CellFormatting);
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
			// grcFrameID
			// 
			this.grcFrameID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcFrameID.DataPropertyName = "FrameID";
			this.grcFrameID.HeaderText = "Контейнер";
			this.grcFrameID.Name = "grcFrameID";
			this.grcFrameID.ReadOnly = true;
			this.grcFrameID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFrameID.Width = 70;
			// 
			// grcOwnerName
			// 
			this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.grcOwnerName.DataPropertyName = "OwnerName";
			this.grcOwnerName.HeaderText = "Хранитель";
			this.grcOwnerName.Name = "grcOwnerName";
			this.grcOwnerName.ReadOnly = true;
			this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcOwnerName.Width = 150;
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
			this.grcDateValid.Width = 86;
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
			// pnlDataChange
			// 
			this.pnlDataChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlDataChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDataChange.Controls.Add(this.txtFrameID);
			this.pnlDataChange.Controls.Add(this.lblGoodState);
			this.pnlDataChange.Controls.Add(this.cboGoodState);
			this.pnlDataChange.Controls.Add(this.lblOwner);
			this.pnlDataChange.Controls.Add(this.cboOwner);
			this.pnlDataChange.Controls.Add(this.lblQntNew);
			this.pnlDataChange.Controls.Add(this.numQnt);
			this.pnlDataChange.Controls.Add(this.lblGoodNew);
			this.pnlDataChange.Controls.Add(this.cboGood);
			this.pnlDataChange.Controls.Add(this.lbFrameNew);
			this.pnlDataChange.Controls.Add(this.cboFrame);
			this.pnlDataChange.Location = new System.Drawing.Point(3, 206);
			this.pnlDataChange.Name = "pnlDataChange";
			this.pnlDataChange.Size = new System.Drawing.Size(596, 86);
			this.pnlDataChange.TabIndex = 1;
			// 
			// txtFrameID
			// 
			this.txtFrameID.Location = new System.Drawing.Point(77, 5);
			this.txtFrameID.MaxLength = 4;
			this.txtFrameID.Name = "txtFrameID";
			this.txtFrameID.OldValue = null;
			this.txtFrameID.Size = new System.Drawing.Size(50, 22);
			this.txtFrameID.TabIndex = 1;
			this.txtFrameID.TextChanged += new System.EventHandler(this.txtFrameID_TextChanged);
			// 
			// lblGoodState
			// 
			this.lblGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGoodState.AutoSize = true;
			this.lblGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodState.Location = new System.Drawing.Point(302, 60);
			this.lblGoodState.Name = "lblGoodState";
			this.lblGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblGoodState.TabIndex = 8;
			this.lblGoodState.Text = "Состояние";
			// 
			// cboGoodState
			// 
			this.cboGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGoodState.FormattingEnabled = true;
			this.cboGoodState.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGoodState.Location = new System.Drawing.Point(369, 57);
			this.cboGoodState.Name = "cboGoodState";
			this.cboGoodState.Size = new System.Drawing.Size(220, 22);
			this.cboGoodState.TabIndex = 9;
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwner.Location = new System.Drawing.Point(3, 60);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(67, 14);
			this.lblOwner.TabIndex = 7;
			this.lblOwner.Text = "Хранитель";
			// 
			// cboOwner
			// 
			this.cboOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOwner.FormattingEnabled = true;
			this.cboOwner.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboOwner.Location = new System.Drawing.Point(77, 57);
			this.cboOwner.Name = "cboOwner";
			this.cboOwner.Size = new System.Drawing.Size(222, 22);
			this.cboOwner.TabIndex = 7;
			// 
			// lblQntNew
			// 
			this.lblQntNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblQntNew.AutoSize = true;
			this.lblQntNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblQntNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblQntNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQntNew.Location = new System.Drawing.Point(497, 14);
			this.lblQntNew.Name = "lblQntNew";
			this.lblQntNew.Size = new System.Drawing.Size(74, 14);
			this.lblQntNew.TabIndex = 5;
			this.lblQntNew.Text = "Количество";
			// 
			// numQnt
			// 
			this.numQnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.numQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.numQnt.IsNull = false;
			this.numQnt.Location = new System.Drawing.Point(498, 31);
			this.numQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numQnt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
			this.numQnt.Name = "numQnt";
			this.numQnt.Size = new System.Drawing.Size(91, 22);
			this.numQnt.TabIndex = 6;
			this.numQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			this.lblGoodNew.TabIndex = 3;
			this.lblGoodNew.Text = "Товар";
			// 
			// cboGood
			// 
			this.cboGood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboGood.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboGood.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGood.FormattingEnabled = true;
			this.cboGood.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboGood.Location = new System.Drawing.Point(77, 31);
			this.cboGood.Name = "cboGood";
			this.cboGood.Size = new System.Drawing.Size(417, 22);
			this.cboGood.TabIndex = 4;
			// 
			// lbFrameNew
			// 
			this.lbFrameNew.AutoSize = true;
			this.lbFrameNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lbFrameNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lbFrameNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbFrameNew.Location = new System.Drawing.Point(3, 8);
			this.lbFrameNew.Name = "lbFrameNew";
			this.lbFrameNew.Size = new System.Drawing.Size(69, 14);
			this.lbFrameNew.TabIndex = 0;
			this.lbFrameNew.Text = "Контейнер";
			// 
			// cboFrame
			// 
			this.cboFrame.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboFrame.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFrame.FormattingEnabled = true;
			this.cboFrame.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboFrame.Location = new System.Drawing.Point(130, 5);
			this.cboFrame.Name = "cboFrame";
			this.cboFrame.Size = new System.Drawing.Size(167, 22);
			this.cboFrame.TabIndex = 2;
			this.cboFrame.SelectedIndexChanged += new System.EventHandler(this.cboFrame_SelectedIndexChanged);
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
			this.lblCell.TabIndex = 2;
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
			this.pnlData.Controls.Add(this.cboFixedPacking);
			this.pnlData.Controls.Add(this.lblFixedPacking);
			this.pnlData.Controls.Add(this.lblCellID);
			this.pnlData.Controls.Add(this.cboFixedGoodState);
			this.pnlData.Controls.Add(this.cboFixedOwner);
			this.pnlData.Controls.Add(this.lblFixedGoodState);
			this.pnlData.Controls.Add(this.lblFixesOwner);
			this.pnlData.Controls.Add(this.lblMaxPalletQnt);
			this.pnlData.Controls.Add(this.lblCell);
			this.pnlData.Controls.Add(this.btnGridSave);
			this.pnlData.Controls.Add(this.btnGridUndo);
			this.pnlData.Controls.Add(this.pnlDataChange);
			this.pnlData.Controls.Add(this.btnDelete);
			this.pnlData.Controls.Add(this.btnAdd);
			this.pnlData.Controls.Add(this.grdCellsContents);
			this.pnlData.Location = new System.Drawing.Point(4, 5);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(683, 326);
			this.pnlData.TabIndex = 4;
			// 
			// lblNoteManual
			// 
			this.lblNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblNoteManual.AutoSize = true;
			this.lblNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblNoteManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblNoteManual.Location = new System.Drawing.Point(3, 300);
			this.lblNoteManual.Name = "lblNoteManual";
			this.lblNoteManual.Size = new System.Drawing.Size(78, 14);
			this.lblNoteManual.TabIndex = 42;
			this.lblNoteManual.Text = "Примечание";
			// 
			// txtNoteManual
			// 
			this.txtNoteManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNoteManual.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtNoteManual.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNoteManual.Location = new System.Drawing.Point(81, 297);
			this.txtNoteManual.Name = "txtNoteManual";
			this.txtNoteManual.Size = new System.Drawing.Size(595, 22);
			this.txtNoteManual.TabIndex = 41;
			// 
			// cboFixedPacking
			// 
			this.cboFixedPacking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboFixedPacking.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboFixedPacking.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFixedPacking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFixedPacking.FormattingEnabled = true;
			this.cboFixedPacking.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboFixedPacking.Location = new System.Drawing.Point(81, 47);
			this.cboFixedPacking.Name = "cboFixedPacking";
			this.cboFixedPacking.Size = new System.Drawing.Size(595, 22);
			this.cboFixedPacking.TabIndex = 40;
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
			this.lblFixedPacking.TabIndex = 39;
			this.lblFixedPacking.Text = "Товар";
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
			this.lblCellID.TabIndex = 29;
			this.lblCellID.Text = "CellID";
			// 
			// cboFixedGoodState
			// 
			this.cboFixedGoodState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboFixedGoodState.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboFixedGoodState.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFixedGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFixedGoodState.FormattingEnabled = true;
			this.cboFixedGoodState.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboFixedGoodState.Location = new System.Drawing.Point(457, 23);
			this.cboFixedGoodState.Name = "cboFixedGoodState";
			this.cboFixedGoodState.Size = new System.Drawing.Size(219, 22);
			this.cboFixedGoodState.TabIndex = 28;
			// 
			// cboFixedOwner
			// 
			this.cboFixedOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.cboFixedOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.cboFixedOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFixedOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFixedOwner.FormattingEnabled = true;
			this.cboFixedOwner.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.cboFixedOwner.Location = new System.Drawing.Point(81, 23);
			this.cboFixedOwner.Name = "cboFixedOwner";
			this.cboFixedOwner.Size = new System.Drawing.Size(221, 22);
			this.cboFixedOwner.TabIndex = 27;
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
			this.lblFixedGoodState.TabIndex = 26;
			this.lblFixedGoodState.Text = "Состояние";
			// 
			// lblFixesOwner
			// 
			this.lblFixesOwner.AutoSize = true;
			this.lblFixesOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblFixesOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblFixesOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblFixesOwner.Location = new System.Drawing.Point(3, 26);
			this.lblFixesOwner.Name = "lblFixesOwner";
			this.lblFixesOwner.Size = new System.Drawing.Size(67, 14);
			this.lblFixesOwner.TabIndex = 25;
			this.lblFixesOwner.Text = "Хранитель";
			// 
			// lblMaxPalletQnt
			// 
			this.lblMaxPalletQnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaxPalletQnt.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblMaxPalletQnt.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblMaxPalletQnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMaxPalletQnt.Location = new System.Drawing.Point(307, 4);
			this.lblMaxPalletQnt.Name = "lblMaxPalletQnt";
			this.lblMaxPalletQnt.Size = new System.Drawing.Size(368, 14);
			this.lblMaxPalletQnt.TabIndex = 19;
			this.lblMaxPalletQnt.Text = "Максимальное число поддонов в ячейке:";
			this.lblMaxPalletQnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmCellsMedicationFrames
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 373);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.hpHelp.SetHelpKeyword(this, "532");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.Name = "frmCellsMedicationFrames";
			this.hpHelp.SetShowHelp(this, true);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Изменение содержимого ячейки (контейнеры)";
			this.Load += new System.EventHandler(this.frmCellsMedicationFrames_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).EndInit();
			this.pnlDataChange.ResumeLayout(false);
			this.pnlDataChange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQnt)).EndInit();
			this.pnlData.ResumeLayout(false);
			this.pnlData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnCancel;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMDataGridView grdCellsContents;
		private RFMBaseClasses.RFMButton btnAdd;
		private RFMBaseClasses.RFMButton btnDelete;
		private RFMBaseClasses.RFMPanel pnlDataChange;
		private RFMBaseClasses.RFMLabel lblGoodState;
		private RFMBaseClasses.RFMComboBox cboGoodState;
		private RFMBaseClasses.RFMLabel lblOwner;
		private RFMBaseClasses.RFMComboBox cboOwner;
		private RFMBaseClasses.RFMLabel lblQntNew;
		private RFMBaseClasses.RFMNumericUpDown numQnt;
		private RFMBaseClasses.RFMLabel lblGoodNew;
		private RFMBaseClasses.RFMComboBox cboGood;
		private RFMBaseClasses.RFMLabel lbFrameNew;
		private RFMBaseClasses.RFMComboBox cboFrame;
		private RFMBaseClasses.RFMButton btnGridUndo;
		private RFMBaseClasses.RFMButton btnGridSave;
		private RFMBaseClasses.RFMLabel lblCell;
		private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMTextBoxNumeric txtFrameID;
		private RFMBaseClasses.RFMLabel lblMaxPalletQnt;
		private RFMBaseClasses.RFMComboBox cboFixedGoodState;
		private RFMBaseClasses.RFMComboBox cboFixedOwner;
		private RFMBaseClasses.RFMLabel lblFixedGoodState;
		private RFMBaseClasses.RFMLabel lblFixesOwner;
		private RFMBaseClasses.RFMLabel lblCellID;
		private RFMBaseClasses.RFMComboBox cboFixedPacking;
		private RFMBaseClasses.RFMLabel lblFixedPacking;
		private RFMBaseClasses.RFMDataGridViewImageColumn grcChangesImage;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcChanges;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcFrameID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPalQnt;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn grcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCellsContentsID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcPackingID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerID;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateID;
		private RFMBaseClasses.RFMLabel lblNoteManual;
		private RFMBaseClasses.RFMTextBox txtNoteManual;
	}
}