namespace WMSSuitable
{
	partial class frmMovingsConfirm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tmrShow = new System.Windows.Forms.Timer(this.components);
			this.dgvMovingGoods = new RFMBaseClasses.RFMDataGridView();
			this.dgrcGoodAlias = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcBoxWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcBoxConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.dgrcQntWished = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcQntConfirmed = new RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn();
			this.dgrcWeighting = new RFMBaseClasses.RFMDataGridViewCheckBoxColumn();
			this.dgrcGoodBarCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcGoodGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcGoodBrandName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.dgrcID = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
			this.btnHelp = new RFMBaseClasses.RFMButton();
			this.btnExit = new RFMBaseClasses.RFMButton();
			this.btnSave = new RFMBaseClasses.RFMButton();
			this.pnlSelectConditions = new RFMBaseClasses.RFMPanel();
			this.lblGoodStateNew = new RFMBaseClasses.RFMLabel();
			this.txtGoodStateNewName = new RFMBaseClasses.RFMTextBox();
			this.txtMovingTypeName = new RFMBaseClasses.RFMTextBox();
			this.txtCellSourceAdress = new RFMBaseClasses.RFMTextBox();
			this.txtGoodStateName = new RFMBaseClasses.RFMTextBox();
			this.txtOwnerName = new RFMBaseClasses.RFMTextBox();
			this.txtDateMoving = new RFMBaseClasses.RFMTextBox();
			this.lblCellSourceAddress = new RFMBaseClasses.RFMLabel();
			this.lblGoodStateName = new RFMBaseClasses.RFMLabel();
			this.lblOwnerName = new RFMBaseClasses.RFMLabel();
			this.lblMovingTypeName = new RFMBaseClasses.RFMLabel();
			this.lblDateMoving = new RFMBaseClasses.RFMLabel();
			((System.ComponentModel.ISupportInitialize)(this.dgvMovingGoods)).BeginInit();
			this.pnlSelectConditions.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrShow
			// 
			this.tmrShow.Interval = 1000;
			// 
			// dgvMovingGoods
			// 
			this.dgvMovingGoods.AllowUserToAddRows = false;
			this.dgvMovingGoods.AllowUserToDeleteRows = false;
			this.dgvMovingGoods.AllowUserToOrderColumns = true;
			this.dgvMovingGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvMovingGoods.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvMovingGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvMovingGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvMovingGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMovingGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgrcGoodAlias,
            this.dgrcInBox,
            this.dgrcBoxWished,
            this.dgrcBoxConfirmed,
            this.dgrcQntWished,
            this.dgrcQntConfirmed,
            this.dgrcWeighting,
            this.dgrcGoodBarCode,
            this.dgrcGoodGroupName,
            this.dgrcGoodBrandName,
            this.dgrcID});
			this.dgvMovingGoods.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvMovingGoods.IsConfigInclude = true;
			this.dgvMovingGoods.IsMarkedAll = false;
			this.dgvMovingGoods.IsStatusInclude = true;
			this.dgvMovingGoods.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
			this.dgvMovingGoods.Location = new System.Drawing.Point(5, 63);
			this.dgvMovingGoods.MultiSelect = false;
			this.dgvMovingGoods.Name = "dgvMovingGoods";
			this.dgvMovingGoods.RangedWay = ' ';
			this.dgvMovingGoods.ReadOnly = true;
			this.dgvMovingGoods.RowHeadersWidth = 24;
			this.dgvMovingGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvMovingGoods.Size = new System.Drawing.Size(732, 366);
			this.dgvMovingGoods.TabIndex = 1;
			this.dgvMovingGoods.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMovingGoods_CellBeginEdit);
			this.dgvMovingGoods.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovingGoods_CellValidated);
			this.dgvMovingGoods.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMovingGoods_CellFormatting);
			this.dgvMovingGoods.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovingGoods_CellEndEdit);
			// 
			// dgrcGoodAlias
			// 
			this.dgrcGoodAlias.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcGoodAlias.DataPropertyName = "GoodAlias";
			this.dgrcGoodAlias.HeaderText = "Товар";
			this.dgrcGoodAlias.Name = "dgrcGoodAlias";
			this.dgrcGoodAlias.ReadOnly = true;
			this.dgrcGoodAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcGoodAlias.Width = 250;
			// 
			// dgrcInBox
			// 
			this.dgrcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcInBox.DataPropertyName = "InBox";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.dgrcInBox.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgrcInBox.HeaderText = "В кор.";
			this.dgrcInBox.Name = "dgrcInBox";
			this.dgrcInBox.ReadOnly = true;
			this.dgrcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcInBox.ToolTipText = "Штук/кг в коробке";
			this.dgrcInBox.Width = 50;
			// 
			// dgrcBoxWished
			// 
			this.dgrcBoxWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcBoxWished.DataPropertyName = "BoxWished";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "N1";
			this.dgrcBoxWished.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgrcBoxWished.HeaderText = "Заказ кор.";
			this.dgrcBoxWished.Name = "dgrcBoxWished";
			this.dgrcBoxWished.ReadOnly = true;
			this.dgrcBoxWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcBoxWished.ToolTipText = "Заказано коробок";
			this.dgrcBoxWished.Width = 80;
			// 
			// dgrcBoxConfirmed
			// 
			this.dgrcBoxConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcBoxConfirmed.DataPropertyName = "BoxConfirmed";
			this.dgrcBoxConfirmed.DecimalPlaces = 1;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N1";
			this.dgrcBoxConfirmed.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgrcBoxConfirmed.HeaderText = "Факт кор.";
			this.dgrcBoxConfirmed.Name = "dgrcBoxConfirmed";
			this.dgrcBoxConfirmed.ReadOnly = true;
			this.dgrcBoxConfirmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgrcBoxConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcBoxConfirmed.ToolTipText = "Фактически подобрано коробок";
			this.dgrcBoxConfirmed.Width = 80;
			// 
			// dgrcQntWished
			// 
			this.dgrcQntWished.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcQntWished.DataPropertyName = "QntWished";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N0";
			this.dgrcQntWished.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgrcQntWished.HeaderText = "Заказ шт.";
			this.dgrcQntWished.Name = "dgrcQntWished";
			this.dgrcQntWished.ReadOnly = true;
			this.dgrcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcQntWished.ToolTipText = "Заказано шт.";
			this.dgrcQntWished.Width = 90;
			// 
			// dgrcQntConfirmed
			// 
			this.dgrcQntConfirmed.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcQntConfirmed.DataPropertyName = "QntConfirmed";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N0";
			this.dgrcQntConfirmed.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgrcQntConfirmed.HeaderText = "Факт штук";
			this.dgrcQntConfirmed.Name = "dgrcQntConfirmed";
			this.dgrcQntConfirmed.ReadOnly = true;
			this.dgrcQntConfirmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgrcQntConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcQntConfirmed.ToolTipText = "Фактически подобрано штук";
			this.dgrcQntConfirmed.Width = 90;
			// 
			// dgrcWeighting
			// 
			this.dgrcWeighting.DataPropertyName = "Weighting";
			this.dgrcWeighting.HeaderText = "Вес?";
			this.dgrcWeighting.Name = "dgrcWeighting";
			this.dgrcWeighting.ReadOnly = true;
			this.dgrcWeighting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcWeighting.ToolTipText = "Весовой товар?";
			this.dgrcWeighting.Width = 40;
			// 
			// dgrcGoodBarCode
			// 
			this.dgrcGoodBarCode.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcGoodBarCode.DataPropertyName = "GoodBarCode";
			this.dgrcGoodBarCode.HeaderText = "ШК товара";
			this.dgrcGoodBarCode.Name = "dgrcGoodBarCode";
			this.dgrcGoodBarCode.ReadOnly = true;
			this.dgrcGoodBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcGoodBarCode.ToolTipText = "Штрих-код товара";
			this.dgrcGoodBarCode.Width = 130;
			// 
			// dgrcGoodGroupName
			// 
			this.dgrcGoodGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcGoodGroupName.DataPropertyName = "GoodGroupName";
			this.dgrcGoodGroupName.HeaderText = "Товарная группа";
			this.dgrcGoodGroupName.Name = "dgrcGoodGroupName";
			this.dgrcGoodGroupName.ReadOnly = true;
			this.dgrcGoodGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcGoodGroupName.Width = 150;
			// 
			// dgrcGoodBrandName
			// 
			this.dgrcGoodBrandName.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcGoodBrandName.DataPropertyName = "GoodBrandName";
			this.dgrcGoodBrandName.HeaderText = "Товарный бренд";
			this.dgrcGoodBrandName.Name = "dgrcGoodBrandName";
			this.dgrcGoodBrandName.ReadOnly = true;
			this.dgrcGoodBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.dgrcGoodBrandName.Width = 150;
			// 
			// dgrcID
			// 
			this.dgrcID.AgrType = RFMBaseClasses.EnumAgregate.None;
			this.dgrcID.DataPropertyName = "MovingGoodID";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.dgrcID.DefaultCellStyle = dataGridViewCellStyle7;
			this.dgrcID.HeaderText = "ID";
			this.dgrcID.Name = "dgrcID";
			this.dgrcID.ReadOnly = true;
			this.dgrcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
			this.btnHelp.Location = new System.Drawing.Point(7, 437);
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
			this.btnExit.Location = new System.Drawing.Point(703, 437);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(32, 30);
			this.btnExit.TabIndex = 7;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Image = global::WMSSuitable.Properties.Resources.Save;
			this.btnSave.Location = new System.Drawing.Point(653, 437);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(32, 30);
			this.btnSave.TabIndex = 6;
			this.ttToolTip.SetToolTip(this.btnSave, "Подтвердить перемещение");
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlSelectConditions
			// 
			this.pnlSelectConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSelectConditions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlSelectConditions.Controls.Add(this.lblGoodStateNew);
			this.pnlSelectConditions.Controls.Add(this.txtGoodStateNewName);
			this.pnlSelectConditions.Controls.Add(this.txtMovingTypeName);
			this.pnlSelectConditions.Controls.Add(this.txtCellSourceAdress);
			this.pnlSelectConditions.Controls.Add(this.txtGoodStateName);
			this.pnlSelectConditions.Controls.Add(this.txtOwnerName);
			this.pnlSelectConditions.Controls.Add(this.txtDateMoving);
			this.pnlSelectConditions.Controls.Add(this.lblCellSourceAddress);
			this.pnlSelectConditions.Controls.Add(this.lblGoodStateName);
			this.pnlSelectConditions.Controls.Add(this.lblOwnerName);
			this.pnlSelectConditions.Controls.Add(this.lblMovingTypeName);
			this.pnlSelectConditions.Controls.Add(this.lblDateMoving);
			this.pnlSelectConditions.Location = new System.Drawing.Point(4, 5);
			this.pnlSelectConditions.Name = "pnlSelectConditions";
			this.pnlSelectConditions.Size = new System.Drawing.Size(734, 55);
			this.pnlSelectConditions.TabIndex = 9;
			// 
			// lblGoodStateNew
			// 
			this.lblGoodStateNew.AutoSize = true;
			this.lblGoodStateNew.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodStateNew.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodStateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodStateNew.Location = new System.Drawing.Point(472, 31);
			this.lblGoodStateNew.Name = "lblGoodStateNew";
			this.lblGoodStateNew.Size = new System.Drawing.Size(106, 14);
			this.lblGoodStateNew.TabIndex = 42;
			this.lblGoodStateNew.Text = "Новое состояние";
			// 
			// txtGoodStateNewName
			// 
			this.txtGoodStateNewName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodStateNewName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodStateNewName.Enabled = false;
			this.txtGoodStateNewName.Location = new System.Drawing.Point(585, 27);
			this.txtGoodStateNewName.Name = "txtGoodStateNewName";
			this.txtGoodStateNewName.Size = new System.Drawing.Size(142, 22);
			this.txtGoodStateNewName.TabIndex = 41;
			// 
			// txtMovingTypeName
			// 
			this.txtMovingTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtMovingTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMovingTypeName.Enabled = false;
			this.txtMovingTypeName.Location = new System.Drawing.Point(275, 3);
			this.txtMovingTypeName.Name = "txtMovingTypeName";
			this.txtMovingTypeName.Size = new System.Drawing.Size(180, 22);
			this.txtMovingTypeName.TabIndex = 40;
			// 
			// txtCellSourceAdress
			// 
			this.txtCellSourceAdress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtCellSourceAdress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCellSourceAdress.Enabled = false;
			this.txtCellSourceAdress.Location = new System.Drawing.Point(585, 3);
			this.txtCellSourceAdress.Name = "txtCellSourceAdress";
			this.txtCellSourceAdress.Size = new System.Drawing.Size(142, 22);
			this.txtCellSourceAdress.TabIndex = 39;
			// 
			// txtGoodStateName
			// 
			this.txtGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoodStateName.Enabled = false;
			this.txtGoodStateName.Location = new System.Drawing.Point(313, 27);
			this.txtGoodStateName.Name = "txtGoodStateName";
			this.txtGoodStateName.Size = new System.Drawing.Size(142, 22);
			this.txtGoodStateName.TabIndex = 38;
			// 
			// txtOwnerName
			// 
			this.txtOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOwnerName.Enabled = false;
			this.txtOwnerName.Location = new System.Drawing.Point(69, 27);
			this.txtOwnerName.Name = "txtOwnerName";
			this.txtOwnerName.Size = new System.Drawing.Size(142, 22);
			this.txtOwnerName.TabIndex = 36;
			// 
			// txtDateMoving
			// 
			this.txtDateMoving.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.txtDateMoving.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.txtDateMoving.Enabled = false;
			this.txtDateMoving.Location = new System.Drawing.Point(69, 3);
			this.txtDateMoving.Name = "txtDateMoving";
			this.txtDateMoving.Size = new System.Drawing.Size(90, 22);
			this.txtDateMoving.TabIndex = 33;
			// 
			// lblCellSourceAddress
			// 
			this.lblCellSourceAddress.AutoSize = true;
			this.lblCellSourceAddress.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblCellSourceAddress.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblCellSourceAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblCellSourceAddress.Location = new System.Drawing.Point(472, 7);
			this.lblCellSourceAddress.Name = "lblCellSourceAddress";
			this.lblCellSourceAddress.Size = new System.Drawing.Size(65, 14);
			this.lblCellSourceAddress.TabIndex = 31;
			this.lblCellSourceAddress.Text = "Из ячейки";
			// 
			// lblGoodStateName
			// 
			this.lblGoodStateName.AutoSize = true;
			this.lblGoodStateName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblGoodStateName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblGoodStateName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblGoodStateName.Location = new System.Drawing.Point(243, 31);
			this.lblGoodStateName.Name = "lblGoodStateName";
			this.lblGoodStateName.Size = new System.Drawing.Size(68, 14);
			this.lblGoodStateName.TabIndex = 30;
			this.lblGoodStateName.Text = "Состояние";
			// 
			// lblOwnerName
			// 
			this.lblOwnerName.AutoSize = true;
			this.lblOwnerName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblOwnerName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblOwnerName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblOwnerName.Location = new System.Drawing.Point(3, 31);
			this.lblOwnerName.Name = "lblOwnerName";
			this.lblOwnerName.Size = new System.Drawing.Size(62, 14);
			this.lblOwnerName.TabIndex = 28;
			this.lblOwnerName.Text = "Владелец";
			// 
			// lblMovingTypeName
			// 
			this.lblMovingTypeName.AutoSize = true;
			this.lblMovingTypeName.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblMovingTypeName.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblMovingTypeName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMovingTypeName.Location = new System.Drawing.Point(243, 7);
			this.lblMovingTypeName.Name = "lblMovingTypeName";
			this.lblMovingTypeName.Size = new System.Drawing.Size(29, 14);
			this.lblMovingTypeName.TabIndex = 27;
			this.lblMovingTypeName.Text = "Тип";
			// 
			// lblDateMoving
			// 
			this.lblDateMoving.AutoSize = true;
			this.lblDateMoving.DisabledBackColor = System.Drawing.SystemColors.Control;
			this.lblDateMoving.DisabledForeColor = System.Drawing.SystemColors.WindowText;
			this.lblDateMoving.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDateMoving.Location = new System.Drawing.Point(3, 7);
			this.lblDateMoving.Name = "lblDateMoving";
			this.lblDateMoving.Size = new System.Drawing.Size(33, 14);
			this.lblDateMoving.TabIndex = 25;
			this.lblDateMoving.Text = "Дата";
			// 
			// frmMovingsConfirm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 473);
			this.Controls.Add(this.pnlSelectConditions);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dgvMovingGoods);
			this.hpHelp.SetHelpKeyword(this, "221");
			this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
			this.IsModalMode = true;
			this.MinimizeBox = false;
			this.Name = "frmMovingsConfirm";
			this.hpHelp.SetShowHelp(this, true);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Подтверждение внутрискладского перемещения";
			this.Load += new System.EventHandler(this.frmMovingsConfirm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvMovingGoods)).EndInit();
			this.pnlSelectConditions.ResumeLayout(false);
			this.pnlSelectConditions.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer tmrShow;
		private RFMBaseClasses.RFMDataGridView dgvMovingGoods;
		private RFMBaseClasses.RFMButton btnSave;
		private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
		private RFMBaseClasses.RFMPanel pnlSelectConditions;
		private RFMBaseClasses.RFMTextBox txtMovingTypeName;
		private RFMBaseClasses.RFMTextBox txtCellSourceAdress;
		private RFMBaseClasses.RFMTextBox txtGoodStateName;
		private RFMBaseClasses.RFMTextBox txtOwnerName;
		private RFMBaseClasses.RFMTextBox txtDateMoving;
		private RFMBaseClasses.RFMLabel lblCellSourceAddress;
		private RFMBaseClasses.RFMLabel lblGoodStateName;
		private RFMBaseClasses.RFMLabel lblOwnerName;
		private RFMBaseClasses.RFMLabel lblMovingTypeName;
		private RFMBaseClasses.RFMLabel lblDateMoving;
        private RFMBaseClasses.RFMLabel lblGoodStateNew;
        private RFMBaseClasses.RFMTextBox txtGoodStateNewName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodAlias;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcInBox;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcBoxWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn dgrcBoxConfirmed;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcQntWished;
		private RFMBaseClasses.RFMDataGridViewTextBoxNumericColumn dgrcQntConfirmed;
		private RFMBaseClasses.RFMDataGridViewCheckBoxColumn dgrcWeighting;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodBarCode;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodGroupName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcGoodBrandName;
		private RFMBaseClasses.RFMDataGridViewTextBoxColumn dgrcID;
	}
}

