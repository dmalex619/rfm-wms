namespace WMSSuitable
{
	partial class frmCellsMedication
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellsMedication));
			this.pnlData = new WMSBaseClasses.WMSPanel();
			this.btnGridSave = new WMSBaseClasses.WMSButton();
			this.btnGridUndo = new WMSBaseClasses.WMSButton();
			this.pnlDataChange = new WMSBaseClasses.WMSPanel();
			this.chkFrameNew = new WMSBaseClasses.WMSCheckBox();
			this.btnPackings = new WMSBaseClasses.WMSButton();
			this.lblGoodState = new WMSBaseClasses.WMSLabel();
			this.cboGoodState = new WMSBaseClasses.WMSComboBox();
			this.lblOwner = new WMSBaseClasses.WMSLabel();
			this.cboOwner = new WMSBaseClasses.WMSComboBox();
			this.lblQntNew = new WMSBaseClasses.WMSLabel();
			this.numQnt = new WMSBaseClasses.WMSNumericUpDown();
			this.lblGoodNew = new WMSBaseClasses.WMSLabel();
			this.cboGood = new WMSBaseClasses.WMSComboBox();
			this.lbFrameNew = new WMSBaseClasses.WMSLabel();
			this.cboFrame = new WMSBaseClasses.WMSComboBox();
			this.btnDelete = new WMSBaseClasses.WMSButton();
			this.btnEdit = new WMSBaseClasses.WMSButton();
			this.btnAdd = new WMSBaseClasses.WMSButton();
			this.grdCellsContents = new WMSBaseClasses.WMSDataGridView();
			this.grcChangesImage = new WMSBaseClasses.WMSDataGridViewImageColumn();
			this.grcChanges = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcCellsContentsID = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcPackingID = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcPackingAlias = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcFrameID = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcOwnerName = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcQnt = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcBoxQnt = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcPalQnt = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcGoodStateName = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcWeighting = new WMSBaseClasses.WMSDataGridViewCheckBoxColumn();
			this.grcOwnerID = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcGoodStateID = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.pnlOptFRameGood = new WMSBaseClasses.WMSPanel();
			this.lblCell = new WMSBaseClasses.WMSLabel();
			this.optNotFrame = new WMSBaseClasses.WMSRadioButton();
			this.optFrame = new WMSBaseClasses.WMSRadioButton();
			this.btnHelp = new WMSBaseClasses.WMSButton();
			this.btnCancel = new WMSBaseClasses.WMSButton();
			this.btnSave = new WMSBaseClasses.WMSButton();
			this.ttToolTip = new WMSBaseClasses.WMSToolTip();
			this.bsCellsContents = new WMSBaseClasses.WMSBindingSource();
			this.mnuAddCellsContents = new WMSBaseClasses.WMSContextMenuStrip();
			this.mniAddFrame = new WMSBaseClasses.WMSContextToolStripMenuItem();
			this.mniAddCellsContents = new WMSBaseClasses.WMSContextToolStripMenuItem();
			this.pnlData.SuspendLayout();
			this.pnlDataChange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).BeginInit();
			this.pnlOptFRameGood.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).BeginInit();
			this.mnuAddCellsContents.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlData
			// 
			this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlData.Controls.Add(this.btnGridSave);
			this.pnlData.Controls.Add(this.btnGridUndo);
			this.pnlData.Controls.Add(this.pnlDataChange);
			this.pnlData.Controls.Add(this.btnDelete);
			this.pnlData.Controls.Add(this.btnEdit);
			this.pnlData.Controls.Add(this.btnAdd);
			this.pnlData.Controls.Add(this.grdCellsContents);
			this.pnlData.Controls.Add(this.pnlOptFRameGood);
			this.pnlData.Location = new System.Drawing.Point(5, 6);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(681, 374);
			this.pnlData.TabIndex = 4;
			// 
			// btnGridSave
			// 
			this.btnGridSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnGridSave.Location = new System.Drawing.Point(643, 335);
			this.btnGridSave.Name = "btnGridSave";
			this.btnGridSave.Size = new System.Drawing.Size(30, 30);
			this.btnGridSave.TabIndex = 18;
			this.btnGridSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridSave, "Сохранить временные изменения");
			this.btnGridSave.UseVisualStyleBackColor = true;
			this.btnGridSave.Click += new System.EventHandler(this.btnGridSave_Click);
			// 
			// btnGridUndo
			// 
			this.btnGridUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGridUndo.Image = global::WMSSuitable.Properties.Resources.UnDo;
			this.btnGridUndo.Location = new System.Drawing.Point(603, 335);
			this.btnGridUndo.Name = "btnGridUndo";
			this.btnGridUndo.Size = new System.Drawing.Size(30, 30);
			this.btnGridUndo.TabIndex = 17;
			this.btnGridUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnGridUndo, "Отказ от изменений");
			this.btnGridUndo.UseVisualStyleBackColor = true;
			this.btnGridUndo.Click += new System.EventHandler(this.btnGridUndo_Click);
			// 
			// pnlDataChange
			// 
			this.pnlDataChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlDataChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDataChange.Controls.Add(this.chkFrameNew);
			this.pnlDataChange.Controls.Add(this.btnPackings);
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
			this.pnlDataChange.Location = new System.Drawing.Point(3, 282);
			this.pnlDataChange.Name = "pnlDataChange";
			this.pnlDataChange.Size = new System.Drawing.Size(555, 86);
			this.pnlDataChange.TabIndex = 16;
			// 
			// chkFrameNew
			// 
			this.chkFrameNew.AutoSize = true;
			this.chkFrameNew.Location = new System.Drawing.Point(272, 7);
			this.chkFrameNew.Name = "chkFrameNew";
			this.chkFrameNew.Size = new System.Drawing.Size(61, 18);
			this.chkFrameNew.TabIndex = 54;
			this.chkFrameNew.Text = "новый";
			this.chkFrameNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.chkFrameNew.UseVisualStyleBackColor = true;
			// 
			// btnPackings
			// 
			this.btnPackings.Image = global::WMSSuitable.Properties.Resources.Detail;
			this.btnPackings.Location = new System.Drawing.Point(44, 26);
			this.btnPackings.Name = "btnPackings";
			this.btnPackings.Size = new System.Drawing.Size(30, 30);
			this.btnPackings.TabIndex = 53;
			this.btnPackings.UseVisualStyleBackColor = true;
			this.btnPackings.Click += new System.EventHandler(this.btnPackings_Click);
			// 
			// lblGoodState
			// 
			this.lblGoodState.AutoSize = true;
			this.lblGoodState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodState.Location = new System.Drawing.Point(289, 60);
			this.lblGoodState.Name = "lblGoodState";
			this.lblGoodState.Size = new System.Drawing.Size(68, 14);
			this.lblGoodState.TabIndex = 9;
			this.lblGoodState.Text = "Состояние";
			// 
			// cboGoodState
			// 
			this.cboGoodState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGoodState.FormattingEnabled = true;
			this.cboGoodState.Location = new System.Drawing.Point(357, 57);
			this.cboGoodState.Name = "cboGoodState";
			this.cboGoodState.Size = new System.Drawing.Size(191, 22);
			this.cboGoodState.TabIndex = 8;
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwner.Location = new System.Drawing.Point(3, 60);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(62, 14);
			this.lblOwner.TabIndex = 7;
			this.lblOwner.Text = "Владелец";
			// 
			// cboOwner
			// 
			this.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOwner.FormattingEnabled = true;
			this.cboOwner.Location = new System.Drawing.Point(75, 57);
			this.cboOwner.Name = "cboOwner";
			this.cboOwner.Size = new System.Drawing.Size(191, 22);
			this.cboOwner.TabIndex = 6;
			// 
			// lblQntNew
			// 
			this.lblQntNew.AutoSize = true;
			this.lblQntNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblQntNew.Location = new System.Drawing.Point(457, 14);
			this.lblQntNew.Name = "lblQntNew";
			this.lblQntNew.Size = new System.Drawing.Size(74, 14);
			this.lblQntNew.TabIndex = 5;
			this.lblQntNew.Text = "Количество";
			// 
			// numQnt
			// 
			this.numQnt.IsNull = false;
			this.numQnt.Location = new System.Drawing.Point(454, 31);
			this.numQnt.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.numQnt.Name = "numQnt";
			this.numQnt.Size = new System.Drawing.Size(94, 22);
			this.numQnt.TabIndex = 4;
			this.numQnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblGoodNew
			// 
			this.lblGoodNew.AutoSize = true;
			this.lblGoodNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodNew.Location = new System.Drawing.Point(3, 34);
			this.lblGoodNew.Name = "lblGoodNew";
			this.lblGoodNew.Size = new System.Drawing.Size(41, 14);
			this.lblGoodNew.TabIndex = 3;
			this.lblGoodNew.Text = "Товар";
			// 
			// cboGood
			// 
			this.cboGood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGood.FormattingEnabled = true;
			this.cboGood.Location = new System.Drawing.Point(75, 31);
			this.cboGood.Name = "cboGood";
			this.cboGood.Size = new System.Drawing.Size(376, 22);
			this.cboGood.TabIndex = 2;
			// 
			// lbFrameNew
			// 
			this.lbFrameNew.AutoSize = true;
			this.lbFrameNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbFrameNew.Location = new System.Drawing.Point(3, 8);
			this.lbFrameNew.Name = "lbFrameNew";
			this.lbFrameNew.Size = new System.Drawing.Size(69, 14);
			this.lbFrameNew.TabIndex = 1;
			this.lbFrameNew.Text = "Контейнер";
			// 
			// cboFrame
			// 
			this.cboFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFrame.FormattingEnabled = true;
			this.cboFrame.Location = new System.Drawing.Point(75, 5);
			this.cboFrame.Name = "cboFrame";
			this.cboFrame.Size = new System.Drawing.Size(191, 22);
			this.cboFrame.TabIndex = 0;
			this.cboFrame.SelectedIndexChanged += new System.EventHandler(this.cboFrame_SelectedIndexChanged);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::WMSSuitable.Properties.Resources.Delete;
			this.btnDelete.Location = new System.Drawing.Point(643, 289);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 30);
			this.btnDelete.TabIndex = 15;
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnDelete, "Удалить");
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::WMSSuitable.Properties.Resources.Edit;
			this.btnEdit.Location = new System.Drawing.Point(603, 289);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(30, 30);
			this.btnEdit.TabIndex = 14;
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnEdit, "Изменить");
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::WMSSuitable.Properties.Resources.Add;
			this.btnAdd.Location = new System.Drawing.Point(564, 289);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(30, 30);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ttToolTip.SetToolTip(this.btnAdd, "Добавить");
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
			this.grdCellsContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdCellsContents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcChangesImage,
            this.grcChanges,
            this.grcCellsContentsID,
            this.grcPackingID,
            this.grcPackingAlias,
            this.grcFrameID,
            this.grcOwnerName,
            this.grcQnt,
            this.grcBoxQnt,
            this.grcPalQnt,
            this.grcGoodStateName,
            this.grcWeighting,
            this.grcOwnerID,
            this.grcGoodStateID});
			this.grdCellsContents.Location = new System.Drawing.Point(3, 27);
			this.grdCellsContents.Name = "grdCellsContents";
			this.grdCellsContents.ReadOnly = true;
			this.grdCellsContents.RowHeadersWidth = 16;
			this.grdCellsContents.Size = new System.Drawing.Size(671, 251);
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
			this.grcChanges.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcChanges.DataPropertyName = "Changes";
			this.grcChanges.HeaderText = "Изм.";
			this.grcChanges.Name = "grcChanges";
			this.grcChanges.ReadOnly = true;
			this.grcChanges.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcChanges.Width = 35;
			// 
			// grcCellsContentsID
			// 
			this.grcCellsContentsID.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcCellsContentsID.DataPropertyName = "ID";
			this.grcCellsContentsID.HeaderText = "ID";
			this.grcCellsContentsID.Name = "grcCellsContentsID";
			this.grcCellsContentsID.ReadOnly = true;
			this.grcCellsContentsID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcCellsContentsID.Width = 40;
			// 
			// grcPackingID
			// 
			this.grcPackingID.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcPackingID.DataPropertyName = "PackingID";
			this.grcPackingID.HeaderText = "PackingID";
			this.grcPackingID.Name = "grcPackingID";
			this.grcPackingID.ReadOnly = true;
			this.grcPackingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingID.Visible = false;
			// 
			// grcPackingAlias
			// 
			this.grcPackingAlias.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcPackingAlias.DataPropertyName = "PackingAlias";
			this.grcPackingAlias.HeaderText = "Товар";
			this.grcPackingAlias.Name = "grcPackingAlias";
			this.grcPackingAlias.ReadOnly = true;
			this.grcPackingAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPackingAlias.Width = 200;
			// 
			// grcFrameID
			// 
			this.grcFrameID.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcFrameID.DataPropertyName = "FrameID";
			this.grcFrameID.HeaderText = "Контейнер";
			this.grcFrameID.Name = "grcFrameID";
			this.grcFrameID.ReadOnly = true;
			this.grcFrameID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcFrameID.Width = 70;
			// 
			// grcOwnerName
			// 
			this.grcOwnerName.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcOwnerName.DataPropertyName = "OwnerName";
			this.grcOwnerName.HeaderText = "Владелец";
			this.grcOwnerName.Name = "grcOwnerName";
			this.grcOwnerName.ReadOnly = true;
			this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcOwnerName.Width = 150;
			// 
			// grcQnt
			// 
			this.grcQnt.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcQnt.DataPropertyName = "Qnt";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N3";
			dataGridViewCellStyle7.NullValue = null;
			this.grcQnt.DefaultCellStyle = dataGridViewCellStyle7;
			this.grcQnt.HeaderText = "Штук";
			this.grcQnt.Name = "grcQnt";
			this.grcQnt.ReadOnly = true;
			this.grcQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcQnt.Width = 60;
			// 
			// grcBoxQnt
			// 
			this.grcBoxQnt.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcBoxQnt.DataPropertyName = "BoxQnt";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "N0";
			dataGridViewCellStyle8.NullValue = null;
			this.grcBoxQnt.DefaultCellStyle = dataGridViewCellStyle8;
			this.grcBoxQnt.HeaderText = "Кор.";
			this.grcBoxQnt.Name = "grcBoxQnt";
			this.grcBoxQnt.ReadOnly = true;
			this.grcBoxQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxQnt.Width = 60;
			// 
			// grcPalQnt
			// 
			this.grcPalQnt.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcPalQnt.DataPropertyName = "PalQnt";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle9.Format = "N2";
			dataGridViewCellStyle9.NullValue = null;
			this.grcPalQnt.DefaultCellStyle = dataGridViewCellStyle9;
			this.grcPalQnt.HeaderText = "Пал.";
			this.grcPalQnt.Name = "grcPalQnt";
			this.grcPalQnt.ReadOnly = true;
			this.grcPalQnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcPalQnt.Width = 60;
			// 
			// grcGoodStateName
			// 
			this.grcGoodStateName.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcGoodStateName.DataPropertyName = "GoodStateName";
			this.grcGoodStateName.HeaderText = "Состояние";
			this.grcGoodStateName.Name = "grcGoodStateName";
			this.grcGoodStateName.ReadOnly = true;
			this.grcGoodStateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcWeighting
			// 
			this.grcWeighting.DataPropertyName = "Weighting";
			this.grcWeighting.HeaderText = "Weighting";
			this.grcWeighting.Name = "grcWeighting";
			this.grcWeighting.ReadOnly = true;
			this.grcWeighting.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.grcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcWeighting.Visible = false;
			// 
			// grcOwnerID
			// 
			this.grcOwnerID.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcOwnerID.DataPropertyName = "OwnerID";
			this.grcOwnerID.HeaderText = "OwnerID";
			this.grcOwnerID.Name = "grcOwnerID";
			this.grcOwnerID.ReadOnly = true;
			this.grcOwnerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcOwnerID.Visible = false;
			// 
			// grcGoodStateID
			// 
			this.grcGoodStateID.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcGoodStateID.DataPropertyName = "GoodStateID";
			this.grcGoodStateID.HeaderText = "GoodStateID";
			this.grcGoodStateID.Name = "grcGoodStateID";
			this.grcGoodStateID.ReadOnly = true;
			this.grcGoodStateID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcGoodStateID.Visible = false;
			// 
			// pnlOptFRameGood
			// 
			this.pnlOptFRameGood.Controls.Add(this.lblCell);
			this.pnlOptFRameGood.Controls.Add(this.optNotFrame);
			this.pnlOptFRameGood.Controls.Add(this.optFrame);
			this.pnlOptFRameGood.Location = new System.Drawing.Point(4, 1);
			this.pnlOptFRameGood.Name = "pnlOptFRameGood";
			this.pnlOptFRameGood.Size = new System.Drawing.Size(284, 25);
			this.pnlOptFRameGood.TabIndex = 0;
			// 
			// lblCell
			// 
			this.lblCell.AutoSize = true;
			this.lblCell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCell.Location = new System.Drawing.Point(3, 5);
			this.lblCell.Name = "lblCell";
			this.lblCell.Size = new System.Drawing.Size(76, 14);
			this.lblCell.TabIndex = 2;
			this.lblCell.Text = "Ячейка для ";
			// 
			// optNotFrame
			// 
			this.optNotFrame.AutoSize = true;
			this.optNotFrame.Enabled = false;
			this.optNotFrame.Location = new System.Drawing.Point(203, 4);
			this.optNotFrame.Name = "optNotFrame";
			this.optNotFrame.Size = new System.Drawing.Size(70, 18);
			this.optNotFrame.TabIndex = 1;
			this.optNotFrame.TabStop = true;
			this.optNotFrame.Text = "товаров";
			this.optNotFrame.UseVisualStyleBackColor = true;
			// 
			// optFrame
			// 
			this.optFrame.AutoSize = true;
			this.optFrame.Enabled = false;
			this.optFrame.Location = new System.Drawing.Point(84, 3);
			this.optFrame.Name = "optFrame";
			this.optFrame.Size = new System.Drawing.Size(99, 18);
			this.optFrame.TabIndex = 0;
			this.optFrame.TabStop = true;
			this.optFrame.Text = "контейнеров";
			this.optFrame.UseVisualStyleBackColor = true;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
			this.btnHelp.Location = new System.Drawing.Point(6, 387);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(30, 30);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::WMSSuitable.Properties.Resources.Exit;
			this.btnCancel.Location = new System.Drawing.Point(656, 387);
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
			this.btnSave.Location = new System.Drawing.Point(606, 387);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// mnuAddCellsContents
			// 
			this.mnuAddCellsContents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddFrame,
            this.mniAddCellsContents});
			this.mnuAddCellsContents.Name = "mnuAddCellsContents";
			this.mnuAddCellsContents.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.mnuAddCellsContents.ShowImageMargin = false;
			this.mnuAddCellsContents.Size = new System.Drawing.Size(258, 70);
			// 
			// mniAddFrame
			// 
			this.mniAddFrame.LocateParameters = null;
			this.mniAddFrame.Name = "mniAddFrame";
			this.mniAddFrame.Size = new System.Drawing.Size(257, 22);
			this.mniAddFrame.Text = "Добавить контейнер";
			this.mniAddFrame.Click += new System.EventHandler(this.mniAddFrame_Click);
			// 
			// mniAddCellsContents
			// 
			this.mniAddCellsContents.LocateParameters = null;
			this.mniAddCellsContents.Name = "mniAddCellsContents";
			this.mniAddCellsContents.Size = new System.Drawing.Size(257, 22);
			this.mniAddCellsContents.Text = "Добавить товар в текущий контейнер";
			this.mniAddCellsContents.Click += new System.EventHandler(this.mniAddCellsContents_Click);
			// 
			// frmCellsMedication
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(692, 423);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.IsModalMode = true;
			this.Name = "frmCellsMedication";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Изменение содержимого ячейки";
			this.Load += new System.EventHandler(this.frmCellsMedication_Load);
			this.pnlData.ResumeLayout(false);
			this.pnlDataChange.ResumeLayout(false);
			this.pnlDataChange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCellsContents)).EndInit();
			this.pnlOptFRameGood.ResumeLayout(false);
			this.pnlOptFRameGood.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsCellsContents)).EndInit();
			this.mnuAddCellsContents.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

        private WMSBaseClasses.WMSButton btnSave;
		private WMSBaseClasses.WMSButton btnCancel;
        private WMSBaseClasses.WMSButton btnHelp;
		private WMSBaseClasses.WMSPanel pnlData;
		private WMSBaseClasses.WMSPanel pnlOptFRameGood;
		private WMSBaseClasses.WMSRadioButton optNotFrame;
		private WMSBaseClasses.WMSRadioButton optFrame;
		private WMSBaseClasses.WMSDataGridView grdCellsContents;
		private WMSBaseClasses.WMSButton btnAdd;
		private WMSBaseClasses.WMSButton btnDelete;
		private WMSBaseClasses.WMSToolTip ttToolTip;
		private WMSBaseClasses.WMSButton btnEdit;
		private WMSBaseClasses.WMSPanel pnlDataChange;
		private WMSBaseClasses.WMSLabel lblOwner;
		private WMSBaseClasses.WMSComboBox cboOwner;
		private WMSBaseClasses.WMSLabel lblQntNew;
		private WMSBaseClasses.WMSNumericUpDown numQnt;
		private WMSBaseClasses.WMSLabel lblGoodNew;
		private WMSBaseClasses.WMSComboBox cboGood;
		private WMSBaseClasses.WMSLabel lbFrameNew;
		private WMSBaseClasses.WMSComboBox cboFrame;
		private WMSBaseClasses.WMSLabel lblGoodState;
		private WMSBaseClasses.WMSComboBox cboGoodState;
		private WMSBaseClasses.WMSButton btnPackings;
		private WMSBaseClasses.WMSButton btnGridSave;
		private WMSBaseClasses.WMSButton btnGridUndo;
		private WMSBaseClasses.WMSBindingSource bsCellsContents;
		private WMSBaseClasses.WMSLabel lblCell;
		private WMSBaseClasses.WMSCheckBox chkFrameNew;
		private WMSBaseClasses.WMSDataGridViewImageColumn grcChangesImage;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcChanges;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcCellsContentsID;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcPackingID;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcPackingAlias;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcFrameID;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcOwnerName;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcQnt;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcBoxQnt;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcPalQnt;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcGoodStateName;
		private WMSBaseClasses.WMSDataGridViewCheckBoxColumn grcWeighting;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcOwnerID;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcGoodStateID;
		private WMSBaseClasses.WMSContextMenuStrip mnuAddCellsContents;
		private WMSBaseClasses.WMSContextToolStripMenuItem mniAddFrame;
		private WMSBaseClasses.WMSContextToolStripMenuItem mniAddCellsContents;
	}
}