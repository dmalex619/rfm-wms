namespace WMSSuitable
{
	partial class frmConvert
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
			this.wmsButton1 = new RFMBaseClasses.RFMButton();
			this.wmsButton2 = new RFMBaseClasses.RFMButton();
			this.wmsButton3 = new RFMBaseClasses.RFMButton();
			this.wmsButton4 = new RFMBaseClasses.RFMButton();
			this.wmsButton5 = new RFMBaseClasses.RFMButton();
			this.txtInputsErpCodes = new RFMBaseClasses.RFMTextBox();
			this.txt1 = new RFMBaseClasses.RFMTextBox();
			this.txt2 = new RFMBaseClasses.RFMTextBox();
			this.SuspendLayout();
			// 
			// wmsButton1
			// 
			this.wmsButton1.Location = new System.Drawing.Point(12, 43);
			this.wmsButton1.Name = "wmsButton1";
			this.wmsButton1.Size = new System.Drawing.Size(477, 30);
			this.wmsButton1.TabIndex = 0;
			this.wmsButton1.Text = "ws_GetInputs (делаем xml)";
			this.wmsButton1.UseVisualStyleBackColor = true;
			this.wmsButton1.Click += new System.EventHandler(this.wmsButton1_Click);
			// 
			// wmsButton2
			// 
			this.wmsButton2.Location = new System.Drawing.Point(12, 108);
			this.wmsButton2.Name = "wmsButton2";
			this.wmsButton2.Size = new System.Drawing.Size(477, 30);
			this.wmsButton2.TabIndex = 1;
			this.wmsButton2.Text = "ws_WHDraftsD_ToWms (делаем xml в Trd)";
			this.wmsButton2.UseVisualStyleBackColor = true;
			this.wmsButton2.Click += new System.EventHandler(this.wmsButton2_Click);
			// 
			// wmsButton3
			// 
			this.wmsButton3.Location = new System.Drawing.Point(12, 144);
			this.wmsButton3.Name = "wmsButton3";
			this.wmsButton3.Size = new System.Drawing.Size(477, 30);
			this.wmsButton3.TabIndex = 2;
			this.wmsButton3.Text = "ws_UpdateCells (в Wms получаем данные из xml)";
			this.wmsButton3.UseVisualStyleBackColor = true;
			this.wmsButton3.Click += new System.EventHandler(this.wmsButton3_Click);
			// 
			// wmsButton4
			// 
			this.wmsButton4.Location = new System.Drawing.Point(12, 204);
			this.wmsButton4.Name = "wmsButton4";
			this.wmsButton4.Size = new System.Drawing.Size(477, 30);
			this.wmsButton4.TabIndex = 3;
			this.wmsButton4.Text = "ws_GetCellsEtc (делаем xml в Wms)";
			this.wmsButton4.UseVisualStyleBackColor = true;
			this.wmsButton4.Click += new System.EventHandler(this.wmsButton4_Click);
			// 
			// wmsButton5
			// 
			this.wmsButton5.Location = new System.Drawing.Point(12, 240);
			this.wmsButton5.Name = "wmsButton5";
			this.wmsButton5.Size = new System.Drawing.Size(477, 30);
			this.wmsButton5.TabIndex = 4;
			this.wmsButton5.Text = "ws_WHStorage_FromWms (в Trd получаем данные из xml)";
			this.wmsButton5.UseVisualStyleBackColor = true;
			this.wmsButton5.Click += new System.EventHandler(this.wmsButton5_Click);
			// 
			// txtInputsErpCodes
			// 
			this.txtInputsErpCodes.Location = new System.Drawing.Point(12, 15);
			this.txtInputsErpCodes.Name = "txtInputsErpCodes";
			this.txtInputsErpCodes.Size = new System.Drawing.Size(477, 22);
			this.txtInputsErpCodes.TabIndex = 5;
			// 
			// txt1
			// 
			this.txt1.Location = new System.Drawing.Point(12, 286);
			this.txt1.Name = "txt1";
			this.txt1.Size = new System.Drawing.Size(100, 22);
			this.txt1.TabIndex = 6;
			// 
			// txt2
			// 
			this.txt2.Location = new System.Drawing.Point(12, 314);
			this.txt2.Multiline = true;
			this.txt2.Name = "txt2";
			this.txt2.Size = new System.Drawing.Size(220, 48);
			this.txt2.TabIndex = 7;
			// 
			// frmConvert
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(501, 374);
			this.Controls.Add(this.txt2);
			this.Controls.Add(this.txt1);
			this.Controls.Add(this.txtInputsErpCodes);
			this.Controls.Add(this.wmsButton5);
			this.Controls.Add(this.wmsButton4);
			this.Controls.Add(this.wmsButton3);
			this.Controls.Add(this.wmsButton2);
			this.Controls.Add(this.wmsButton1);
			this.Name = "frmConvert";
			this.Text = "ќбмен (€чейки etc)";
			this.Load += new System.EventHandler(this.frmConvert_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RFMBaseClasses.RFMButton wmsButton1;
		private RFMBaseClasses.RFMButton wmsButton2;
		private RFMBaseClasses.RFMButton wmsButton3;
		private RFMBaseClasses.RFMButton wmsButton4;
		private RFMBaseClasses.RFMButton wmsButton5;
		private RFMBaseClasses.RFMTextBox txtInputsErpCodes;
		private RFMBaseClasses.RFMTextBox txt1;
		private RFMBaseClasses.RFMTextBox txt2;
	}
}