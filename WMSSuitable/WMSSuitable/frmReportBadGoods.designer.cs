namespace WMSSuitable
{
	partial class frmReportBadGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportBadGoods));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHelp = new RFMBaseClasses.RFMButton();
            this.btnExit = new RFMBaseClasses.RFMButton();
            this.pnlData = new RFMBaseClasses.RFMPanel();
            this.lblOwner = new RFMBaseClasses.RFMLabel();
            this.pnlFixedOwners = new RFMBaseClasses.RFMPanel();
            this.txtOwnersChoosen = new RFMBaseClasses.RFMTextBox();
            this.btnOwnersClear = new RFMBaseClasses.RFMButton();
            this.btnOwnersChoose = new RFMBaseClasses.RFMButton();
            this.btnGo = new RFMBaseClasses.RFMButton();
            this.numRestPrc = new RFMBaseClasses.RFMNumericUpDown();
            this.lblDateValidPercent = new RFMBaseClasses.RFMLabel();
            this.grdData = new RFMBaseClasses.RFMDataGridView();
            this.grcOwnerName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGroupName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcArticul = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcInBox = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodStateName = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcDateValid = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcRest = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcRestPrc = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcBoxes = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcNetto = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcCost = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.grcGoodERPCode = new RFMBaseClasses.RFMDataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            this.pnlFixedOwners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRestPrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = global::WMSSuitable.Properties.Resources.Help;
            this.btnHelp.Location = new System.Drawing.Point(7, 425);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 30);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::WMSSuitable.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(695, 425);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 30);
            this.btnExit.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnExit, "Отказ");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlData.Controls.Add(this.lblOwner);
            this.pnlData.Controls.Add(this.pnlFixedOwners);
            this.pnlData.Controls.Add(this.btnGo);
            this.pnlData.Controls.Add(this.numRestPrc);
            this.pnlData.Controls.Add(this.lblDateValidPercent);
            this.pnlData.Location = new System.Drawing.Point(4, 4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(725, 75);
            this.pnlData.TabIndex = 0;
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblOwner.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOwner.Location = new System.Drawing.Point(6, 43);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(67, 14);
            this.lblOwner.TabIndex = 32;
            this.lblOwner.Text = "Хранитель";
            // 
            // pnlFixedOwners
            // 
            this.pnlFixedOwners.Controls.Add(this.txtOwnersChoosen);
            this.pnlFixedOwners.Controls.Add(this.btnOwnersClear);
            this.pnlFixedOwners.Controls.Add(this.btnOwnersChoose);
            this.pnlFixedOwners.Location = new System.Drawing.Point(194, 35);
            this.pnlFixedOwners.Name = "pnlFixedOwners";
            this.pnlFixedOwners.Size = new System.Drawing.Size(259, 30);
            this.pnlFixedOwners.TabIndex = 31;
            // 
            // txtOwnersChoosen
            // 
            this.txtOwnersChoosen.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.txtOwnersChoosen.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwnersChoosen.Enabled = false;
            this.txtOwnersChoosen.Location = new System.Drawing.Point(1, 4);
            this.txtOwnersChoosen.Name = "txtOwnersChoosen";
            this.txtOwnersChoosen.OldValue = "";
            this.txtOwnersChoosen.Size = new System.Drawing.Size(200, 22);
            this.txtOwnersChoosen.TabIndex = 0;
            this.ttToolTip.SetToolTip(this.txtOwnersChoosen, "Контекст названия поставщика");
            // 
            // btnOwnersClear
            // 
            this.btnOwnersClear.Image = ((System.Drawing.Image)(resources.GetObject("btnOwnersClear.Image")));
            this.btnOwnersClear.Location = new System.Drawing.Point(231, 3);
            this.btnOwnersClear.Name = "btnOwnersClear";
            this.btnOwnersClear.Size = new System.Drawing.Size(26, 24);
            this.btnOwnersClear.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.btnOwnersClear, "Очистить выбор владельцев");
            this.btnOwnersClear.UseVisualStyleBackColor = true;
            this.btnOwnersClear.Click += new System.EventHandler(this.btnOwnersClear_Click);
            // 
            // btnOwnersChoose
            // 
            this.btnOwnersChoose.Image = ((System.Drawing.Image)(resources.GetObject("btnOwnersChoose.Image")));
            this.btnOwnersChoose.Location = new System.Drawing.Point(203, 3);
            this.btnOwnersChoose.Name = "btnOwnersChoose";
            this.btnOwnersChoose.Size = new System.Drawing.Size(26, 24);
            this.btnOwnersChoose.TabIndex = 1;
            this.ttToolTip.SetToolTip(this.btnOwnersChoose, "Выбор владельцев");
            this.btnOwnersChoose.UseVisualStyleBackColor = true;
            this.btnOwnersChoose.Click += new System.EventHandler(this.btnOwnersChoose_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Image = global::WMSSuitable.Properties.Resources.Go_Blue;
            this.btnGo.Location = new System.Drawing.Point(685, 5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 30);
            this.btnGo.TabIndex = 30;
            this.ttToolTip.SetToolTip(this.btnGo, "Заполнить журнал смен");
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // numRestPrc
            // 
            this.numRestPrc.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.numRestPrc.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.numRestPrc.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRestPrc.InputMask = "###";
            this.numRestPrc.IsNull = false;
            this.numRestPrc.Location = new System.Drawing.Point(195, 10);
            this.numRestPrc.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numRestPrc.Name = "numRestPrc";
            this.numRestPrc.RealPlaces = 3;
            this.numRestPrc.Size = new System.Drawing.Size(60, 22);
            this.numRestPrc.TabIndex = 22;
            this.numRestPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRestPrc.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblDateValidPercent
            // 
            this.lblDateValidPercent.AutoSize = true;
            this.lblDateValidPercent.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.lblDateValidPercent.DisabledForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDateValidPercent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateValidPercent.Location = new System.Drawing.Point(5, 13);
            this.lblDateValidPercent.Name = "lblDateValidPercent";
            this.lblDateValidPercent.Size = new System.Drawing.Size(186, 14);
            this.lblDateValidPercent.TabIndex = 21;
            this.lblDateValidPercent.Text = "% остаточного срока годности";
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
            this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.grcOwnerName,
            this.grcGroupName,
            this.grcGoodName,
            this.grcArticul,
            this.grcInBox,
            this.grcGoodStateName,
            this.grcDateValid,
            this.grcRest,
            this.grcRestPrc,
            this.grcBoxes,
            this.grcNetto,
            this.grcCost,
            this.grcGoodERPCode});
            this.grdData.IsConfigInclude = true;
            this.grdData.IsMarkedAll = false;
            this.grdData.IsStatusInclude = true;
            this.grdData.IsStatusShow = true;
            this.grdData.LocateParameters = new object[] {
        ((object)("")),
        ((object)(false)),
        ((object)(false)),
        ((object)(true)),
        ((object)(-1))};
            this.grdData.Location = new System.Drawing.Point(5, 85);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RangedWay = ' ';
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 24;
            this.grdData.SelectedRowBorderColor = System.Drawing.Color.Empty;
            this.grdData.SelectedRowForeColor = System.Drawing.Color.Empty;
            this.grdData.Size = new System.Drawing.Size(724, 330);
            this.grdData.StatusRowState = ((byte)(2));
            this.grdData.TabIndex = 14;
            // 
            // grcOwnerName
            // 
            this.grcOwnerName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcOwnerName.DataPropertyName = "OwnerName";
            this.grcOwnerName.HeaderText = "Владелец";
            this.grcOwnerName.Name = "grcOwnerName";
            this.grcOwnerName.ReadOnly = true;
            this.grcOwnerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcGroupName
            // 
            this.grcGroupName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGroupName.DataPropertyName = "GroupName";
            this.grcGroupName.HeaderText = "Товарная группа";
            this.grcGroupName.Name = "grcGroupName";
            this.grcGroupName.ReadOnly = true;
            this.grcGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGroupName.Width = 250;
            // 
            // grcGoodName
            // 
            this.grcGoodName.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodName.DataPropertyName = "GoodName";
            this.grcGoodName.HeaderText = "Товар";
            this.grcGoodName.Name = "grcGoodName";
            this.grcGoodName.ReadOnly = true;
            this.grcGoodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodName.Width = 250;
            // 
            // grcArticul
            // 
            this.grcArticul.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcArticul.DataPropertyName = "Articul";
            this.grcArticul.HeaderText = "Артикул";
            this.grcArticul.Name = "grcArticul";
            this.grcArticul.ReadOnly = true;
            this.grcArticul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // grcInBox
            // 
            this.grcInBox.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcInBox.DataPropertyName = "InBox";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            this.grcInBox.DefaultCellStyle = dataGridViewCellStyle2;
            this.grcInBox.HeaderText = "В кор.";
            this.grcInBox.Name = "grcInBox";
            this.grcInBox.ReadOnly = true;
            this.grcInBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcInBox.Width = 60;
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
            // grcDateValid
            // 
            this.grcDateValid.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcDateValid.DataPropertyName = "DateValid";
            dataGridViewCellStyle3.Format = "dd.MM.yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.grcDateValid.DefaultCellStyle = dataGridViewCellStyle3;
            this.grcDateValid.HeaderText = "Срок годн.";
            this.grcDateValid.Name = "grcDateValid";
            this.grcDateValid.ReadOnly = true;
            this.grcDateValid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcDateValid.ToolTipText = "Дата-время окончания срока годности";
            // 
            // grcRest
            // 
            this.grcRest.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcRest.DataPropertyName = "Rest";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.grcRest.DefaultCellStyle = dataGridViewCellStyle4;
            this.grcRest.HeaderText = "СГ дн.";
            this.grcRest.Name = "grcRest";
            this.grcRest.ReadOnly = true;
            this.grcRest.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcRest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcRest.ToolTipText = "Остаточный срок годности в днях";
            this.grcRest.Width = 60;
            // 
            // grcRestPrc
            // 
            this.grcRestPrc.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcRestPrc.DataPropertyName = "RestPrc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N1";
            this.grcRestPrc.DefaultCellStyle = dataGridViewCellStyle5;
            this.grcRestPrc.HeaderText = "СГ %";
            this.grcRestPrc.Name = "grcRestPrc";
            this.grcRestPrc.ReadOnly = true;
            this.grcRestPrc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcRestPrc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcRestPrc.ToolTipText = "Остаточный срок годности в %";
            this.grcRestPrc.Width = 60;
            // 
            // grcBoxes
            // 
            this.grcBoxes.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcBoxes.DataPropertyName = "Boxes";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            this.grcBoxes.DefaultCellStyle = dataGridViewCellStyle6;
            this.grcBoxes.HeaderText = "Кор.";
            this.grcBoxes.Name = "grcBoxes";
            this.grcBoxes.ReadOnly = true;
            this.grcBoxes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcBoxes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcBoxes.ToolTipText = "Кол-во коробок";
            this.grcBoxes.Width = 80;
            // 
            // grcNetto
            // 
            this.grcNetto.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcNetto.DataPropertyName = "Netto";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            this.grcNetto.DefaultCellStyle = dataGridViewCellStyle7;
            this.grcNetto.HeaderText = "Нетто";
            this.grcNetto.Name = "grcNetto";
            this.grcNetto.ReadOnly = true;
            this.grcNetto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grcNetto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcNetto.Width = 80;
            // 
            // grcCost
            // 
            this.grcCost.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcCost.DataPropertyName = "Cost";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.grcCost.DefaultCellStyle = dataGridViewCellStyle8;
            this.grcCost.HeaderText = "Себестоимость";
            this.grcCost.Name = "grcCost";
            this.grcCost.ReadOnly = true;
            this.grcCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcCost.ToolTipText = "Текущая нормативная себестоимость";
            // 
            // grcGoodERPCode
            // 
            this.grcGoodERPCode.AgrType = RFMBaseClasses.EnumAgregate.None;
            this.grcGoodERPCode.DataPropertyName = "GoodERPCode";
            this.grcGoodERPCode.HeaderText = "ERPCode товара";
            this.grcGoodERPCode.Name = "grcGoodERPCode";
            this.grcGoodERPCode.ReadOnly = true;
            this.grcGoodERPCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grcGoodERPCode.ToolTipText = "Код товара в хост-системе";
            // 
            // frmReportBadGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExit);
            this.hpHelp.SetHelpKeyword(this, "");
            this.hpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.IsModalMode = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "frmReportBadGoods";
            this.hpHelp.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет о товарах с плохим сроком годности";
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlFixedOwners.ResumeLayout(false);
            this.pnlFixedOwners.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRestPrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private RFMBaseClasses.RFMButton btnExit;
		private RFMBaseClasses.RFMButton btnHelp;
        private RFMBaseClasses.RFMPanel pnlData;
		private RFMBaseClasses.RFMNumericUpDown numRestPrc;
        private RFMBaseClasses.RFMLabel lblDateValidPercent;
        private RFMBaseClasses.RFMButton btnGo;
        private RFMBaseClasses.RFMDataGridView grdData;
        private RFMBaseClasses.RFMLabel lblOwner;
        private RFMBaseClasses.RFMPanel pnlFixedOwners;
        private RFMBaseClasses.RFMTextBox txtOwnersChoosen;
        private RFMBaseClasses.RFMButton btnOwnersClear;
        private RFMBaseClasses.RFMButton btnOwnersChoose;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcOwnerName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGroupName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcArticul;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcInBox;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodStateName;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcDateValid;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcRest;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcRestPrc;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcBoxes;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcNetto;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcCost;
        private RFMBaseClasses.RFMDataGridViewTextBoxColumn grcGoodERPCode;

	}
}

