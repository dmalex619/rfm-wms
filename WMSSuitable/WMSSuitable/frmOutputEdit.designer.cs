namespace WMSSuitable
{
	partial class frmOutput
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
			this.tmrShow = new System.Windows.Forms.Timer(this.components);
			this.wmsTabControl1 = new WMSBaseClasses.WMSTabControl();
			this.tabPage1 = new WMSBaseClasses.WMSTabPage();
			this.tabPage2 = new WMSBaseClasses.WMSTabPage();
			this.wmsPanel1 = new WMSBaseClasses.WMSPanel();
			this.wmsButton4 = new WMSBaseClasses.WMSButton();
			this.wmsButton3 = new WMSBaseClasses.WMSButton();
			this.wmsButton2 = new WMSBaseClasses.WMSButton();
			this.wmsTextBox2 = new WMSBaseClasses.WMSTextBox();
			this.wmsNumericUpDown3 = new WMSBaseClasses.WMSNumericUpDown();
			this.wmsNumericUpDown2 = new WMSBaseClasses.WMSNumericUpDown();
			this.wmsNumericUpDown1 = new WMSBaseClasses.WMSNumericUpDown();
			this.txtBarCode = new WMSBaseClasses.WMSTextBoxBarCode();
			this.txtCellID = new WMSBaseClasses.WMSTextBox();
			this.wmsCheckBox1 = new WMSBaseClasses.WMSCheckBox();
			this.wmsButton1 = new WMSBaseClasses.WMSButton();
			this.wmsComboBox1 = new WMSBaseClasses.WMSComboBox();
			this.wmsTextBox1 = new WMSBaseClasses.WMSTextBox();
			this.wmsDataGridView1 = new WMSBaseClasses.WMSDataGridView();
			this.grcResult = new WMSBaseClasses.WMSDataGridViewImageColumn();
			this.grcGoodName = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcQntWished = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcBoxWished = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcPalWished = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcQntConfirmed = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcBoxConfirmed = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcPalConfirmed = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.grcBarCode = new WMSBaseClasses.WMSDataGridViewTextBoxColumn();
			this.wmsTabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.wmsPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.wmsNumericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wmsNumericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wmsNumericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wmsDataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tmrShow
			// 
			this.tmrShow.Interval = 1000;
			this.tmrShow.Tick += new System.EventHandler(this.tmrShow_Tick);
			// 
			// wmsTabControl1
			// 
			this.wmsTabControl1.Controls.Add(this.tabPage1);
			this.wmsTabControl1.Controls.Add(this.tabPage2);
			this.wmsTabControl1.Location = new System.Drawing.Point(1, 0);
			this.wmsTabControl1.Name = "wmsTabControl1";
			this.wmsTabControl1.SelectedIndex = 0;
			this.wmsTabControl1.Size = new System.Drawing.Size(741, 424);
			this.wmsTabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(733, 397);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.wmsPanel1);
			this.tabPage2.Controls.Add(this.wmsDataGridView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(733, 397);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// wmsPanel1
			// 
			this.wmsPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wmsPanel1.Controls.Add(this.wmsButton4);
			this.wmsPanel1.Controls.Add(this.wmsButton3);
			this.wmsPanel1.Controls.Add(this.wmsButton2);
			this.wmsPanel1.Controls.Add(this.wmsTextBox2);
			this.wmsPanel1.Controls.Add(this.wmsNumericUpDown3);
			this.wmsPanel1.Controls.Add(this.wmsNumericUpDown2);
			this.wmsPanel1.Controls.Add(this.wmsNumericUpDown1);
			this.wmsPanel1.Controls.Add(this.txtBarCode);
			this.wmsPanel1.Controls.Add(this.txtCellID);
			this.wmsPanel1.Controls.Add(this.wmsCheckBox1);
			this.wmsPanel1.Controls.Add(this.wmsButton1);
			this.wmsPanel1.Controls.Add(this.wmsComboBox1);
			this.wmsPanel1.Controls.Add(this.wmsTextBox1);
			this.wmsPanel1.Location = new System.Drawing.Point(7, 7);
			this.wmsPanel1.Name = "wmsPanel1";
			this.wmsPanel1.Size = new System.Drawing.Size(717, 88);
			this.wmsPanel1.TabIndex = 1;
			// 
			// wmsButton4
			// 
			this.wmsButton4.Location = new System.Drawing.Point(640, 51);
			this.wmsButton4.Name = "wmsButton4";
			this.wmsButton4.Size = new System.Drawing.Size(32, 30);
			this.wmsButton4.TabIndex = 60;
			this.wmsButton4.Text = "wmsButton4";
			this.wmsButton4.UseVisualStyleBackColor = true;
			// 
			// wmsButton3
			// 
			this.wmsButton3.Location = new System.Drawing.Point(678, 51);
			this.wmsButton3.Name = "wmsButton3";
			this.wmsButton3.Size = new System.Drawing.Size(32, 30);
			this.wmsButton3.TabIndex = 59;
			this.wmsButton3.Text = "wmsButton3";
			this.wmsButton3.UseVisualStyleBackColor = true;
			// 
			// wmsButton2
			// 
			this.wmsButton2.Location = new System.Drawing.Point(602, 51);
			this.wmsButton2.Name = "wmsButton2";
			this.wmsButton2.Size = new System.Drawing.Size(32, 30);
			this.wmsButton2.TabIndex = 58;
			this.wmsButton2.Text = "wmsButton2";
			this.wmsButton2.UseVisualStyleBackColor = true;
			// 
			// wmsTextBox2
			// 
			this.wmsTextBox2.Location = new System.Drawing.Point(311, 44);
			this.wmsTextBox2.Name = "wmsTextBox2";
			this.wmsTextBox2.Size = new System.Drawing.Size(93, 22);
			this.wmsTextBox2.TabIndex = 57;
			// 
			// wmsNumericUpDown3
			// 
			this.wmsNumericUpDown3.IsNull = false;
			this.wmsNumericUpDown3.Location = new System.Drawing.Point(209, 44);
			this.wmsNumericUpDown3.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.wmsNumericUpDown3.Name = "wmsNumericUpDown3";
			this.wmsNumericUpDown3.Size = new System.Drawing.Size(93, 22);
			this.wmsNumericUpDown3.TabIndex = 56;
			this.wmsNumericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// wmsNumericUpDown2
			// 
			this.wmsNumericUpDown2.IsNull = false;
			this.wmsNumericUpDown2.Location = new System.Drawing.Point(107, 44);
			this.wmsNumericUpDown2.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.wmsNumericUpDown2.Name = "wmsNumericUpDown2";
			this.wmsNumericUpDown2.Size = new System.Drawing.Size(93, 22);
			this.wmsNumericUpDown2.TabIndex = 55;
			this.wmsNumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// wmsNumericUpDown1
			// 
			this.wmsNumericUpDown1.IsNull = false;
			this.wmsNumericUpDown1.Location = new System.Drawing.Point(5, 44);
			this.wmsNumericUpDown1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.wmsNumericUpDown1.Name = "wmsNumericUpDown1";
			this.wmsNumericUpDown1.Size = new System.Drawing.Size(93, 22);
			this.wmsNumericUpDown1.TabIndex = 54;
			this.wmsNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtBarCode
			// 
			this.txtBarCode.Enabled = false;
			this.txtBarCode.Location = new System.Drawing.Point(535, 10);
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(172, 22);
			this.txtBarCode.TabIndex = 53;
			// 
			// txtCellID
			// 
			this.txtCellID.Enabled = false;
			this.txtCellID.Location = new System.Drawing.Point(481, 10);
			this.txtCellID.Name = "txtCellID";
			this.txtCellID.Size = new System.Drawing.Size(50, 22);
			this.txtCellID.TabIndex = 52;
			// 
			// wmsCheckBox1
			// 
			this.wmsCheckBox1.AutoSize = true;
			this.wmsCheckBox1.Location = new System.Drawing.Point(462, 14);
			this.wmsCheckBox1.Name = "wmsCheckBox1";
			this.wmsCheckBox1.Size = new System.Drawing.Size(15, 14);
			this.wmsCheckBox1.TabIndex = 3;
			this.wmsCheckBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.wmsCheckBox1.UseVisualStyleBackColor = true;
			// 
			// wmsButton1
			// 
			this.wmsButton1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.wmsButton1.Image = global::WMSSuitable.Properties.Resources.Plus;
			this.wmsButton1.Location = new System.Drawing.Point(379, 10);
			this.wmsButton1.Name = "wmsButton1";
			this.wmsButton1.Size = new System.Drawing.Size(25, 25);
			this.wmsButton1.TabIndex = 2;
			this.wmsButton1.Text = "+";
			this.wmsButton1.UseVisualStyleBackColor = true;
			// 
			// wmsComboBox1
			// 
			this.wmsComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.wmsComboBox1.FormattingEnabled = true;
			this.wmsComboBox1.Location = new System.Drawing.Point(145, 10);
			this.wmsComboBox1.Name = "wmsComboBox1";
			this.wmsComboBox1.Size = new System.Drawing.Size(231, 22);
			this.wmsComboBox1.TabIndex = 1;
			// 
			// wmsTextBox1
			// 
			this.wmsTextBox1.Location = new System.Drawing.Point(5, 10);
			this.wmsTextBox1.Name = "wmsTextBox1";
			this.wmsTextBox1.Size = new System.Drawing.Size(136, 22);
			this.wmsTextBox1.TabIndex = 0;
			// 
			// wmsDataGridView1
			// 
			this.wmsDataGridView1.AllowUserToAddRows = false;
			this.wmsDataGridView1.AllowUserToDeleteRows = false;
			this.wmsDataGridView1.AllowUserToOrderColumns = true;
			this.wmsDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.wmsDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grcResult,
            this.grcGoodName,
            this.grcQntWished,
            this.grcBoxWished,
            this.grcPalWished,
            this.grcQntConfirmed,
            this.grcBoxConfirmed,
            this.grcPalConfirmed,
            this.grcBarCode});
			this.wmsDataGridView1.Location = new System.Drawing.Point(6, 107);
			this.wmsDataGridView1.MultiSelect = false;
			this.wmsDataGridView1.Name = "wmsDataGridView1";
			this.wmsDataGridView1.RangedWay = ' ';
			this.wmsDataGridView1.ReadOnly = true;
			this.wmsDataGridView1.RowHeadersWidth = 22;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.wmsDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.wmsDataGridView1.Size = new System.Drawing.Size(720, 284);
			this.wmsDataGridView1.TabIndex = 0;
			// 
			// grcResult
			// 
			this.grcResult.FillWeight = 20F;
			this.grcResult.Frozen = true;
			this.grcResult.HeaderText = "";
			this.grcResult.Name = "grcResult";
			this.grcResult.ReadOnly = true;
			this.grcResult.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.grcResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcResult.Width = 20;
			// 
			// grcGoodName
			// 
			this.grcGoodName.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcGoodName.Frozen = true;
			this.grcGoodName.HeaderText = "Товар";
			this.grcGoodName.Name = "grcGoodName";
			this.grcGoodName.ReadOnly = true;
			this.grcGoodName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcQntWished
			// 
			this.grcQntWished.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcQntWished.Frozen = true;
			this.grcQntWished.HeaderText = "Заказано шт.";
			this.grcQntWished.Name = "grcQntWished";
			this.grcQntWished.ReadOnly = true;
			this.grcQntWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcBoxWished
			// 
			this.grcBoxWished.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcBoxWished.Frozen = true;
			this.grcBoxWished.HeaderText = "Заказано кор.";
			this.grcBoxWished.Name = "grcBoxWished";
			this.grcBoxWished.ReadOnly = true;
			this.grcBoxWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcPalWished
			// 
			this.grcPalWished.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcPalWished.Frozen = true;
			this.grcPalWished.HeaderText = "Заказано пал.";
			this.grcPalWished.Name = "grcPalWished";
			this.grcPalWished.ReadOnly = true;
			this.grcPalWished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcQntConfirmed
			// 
			this.grcQntConfirmed.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcQntConfirmed.Frozen = true;
			this.grcQntConfirmed.HeaderText = "Отгружено шт.";
			this.grcQntConfirmed.Name = "grcQntConfirmed";
			this.grcQntConfirmed.ReadOnly = true;
			this.grcQntConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcBoxConfirmed
			// 
			this.grcBoxConfirmed.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcBoxConfirmed.FillWeight = 120F;
			this.grcBoxConfirmed.Frozen = true;
			this.grcBoxConfirmed.HeaderText = "Отгружено кор.";
			this.grcBoxConfirmed.Name = "grcBoxConfirmed";
			this.grcBoxConfirmed.ReadOnly = true;
			this.grcBoxConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.grcBoxConfirmed.Width = 120;
			// 
			// grcPalConfirmed
			// 
			this.grcPalConfirmed.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcPalConfirmed.HeaderText = "Отгружено пал.";
			this.grcPalConfirmed.Name = "grcPalConfirmed";
			this.grcPalConfirmed.ReadOnly = true;
			this.grcPalConfirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// grcBarCode
			// 
			this.grcBarCode.AgrType = WMSBaseClasses.EnumAgregate.None;
			this.grcBarCode.HeaderText = "ШК товара";
			this.grcBarCode.Name = "grcBarCode";
			this.grcBarCode.ReadOnly = true;
			this.grcBarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			// 
			// frmOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(740, 464);
			this.Controls.Add(this.wmsTabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.IsModalMode = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOutput";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Расход";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.wmsTabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.wmsPanel1.ResumeLayout(false);
			this.wmsPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.wmsNumericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wmsNumericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wmsNumericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wmsDataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer tmrShow;
		private WMSBaseClasses.WMSTabControl wmsTabControl1;
		private WMSBaseClasses.WMSTabPage tabPage1;
		private WMSBaseClasses.WMSTabPage tabPage2;
		private WMSBaseClasses.WMSPanel wmsPanel1;
		private WMSBaseClasses.WMSComboBox wmsComboBox1;
		private WMSBaseClasses.WMSTextBox wmsTextBox1;
		private WMSBaseClasses.WMSDataGridView wmsDataGridView1;
		private WMSBaseClasses.WMSButton wmsButton1;
		private WMSBaseClasses.WMSCheckBox wmsCheckBox1;
		private WMSBaseClasses.WMSNumericUpDown wmsNumericUpDown3;
		private WMSBaseClasses.WMSNumericUpDown wmsNumericUpDown2;
		private WMSBaseClasses.WMSNumericUpDown wmsNumericUpDown1;
		private WMSBaseClasses.WMSTextBoxBarCode txtBarCode;
		private WMSBaseClasses.WMSTextBox txtCellID;
		private WMSBaseClasses.WMSButton wmsButton2;
		private WMSBaseClasses.WMSTextBox wmsTextBox2;
		private WMSBaseClasses.WMSButton wmsButton4;
		private WMSBaseClasses.WMSButton wmsButton3;
		private WMSBaseClasses.WMSDataGridViewImageColumn grcResult;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcGoodName;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcQntWished;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcBoxWished;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcPalWished;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcQntConfirmed;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcBoxConfirmed;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcPalConfirmed;
		private WMSBaseClasses.WMSDataGridViewTextBoxColumn grcBarCode;
	}
}

