namespace Exchange_SWMS_LW
{
    partial class frmExchange
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
            this.tmrExchange = new System.Windows.Forms.Timer(this.components);
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.colStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInProc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrExchange
            // 
            this.tmrExchange.Interval = 5000;
            this.tmrExchange.Tick += new System.EventHandler(this.tmrExchange_Tick);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStep,
            this.colTime,
            this.colDocsCount,
            this.colFinished,
            this.colInProc});
            this.dgvMain.Location = new System.Drawing.Point(14, 13);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(546, 261);
            this.dgvMain.TabIndex = 0;
            // 
            // colStep
            // 
            this.colStep.DataPropertyName = "Step";
            this.colStep.HeaderText = "Step";
            this.colStep.Name = "colStep";
            this.colStep.ReadOnly = true;
            this.colStep.Width = 50;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "Time";
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 150;
            // 
            // colDocsCount
            // 
            this.colDocsCount.DataPropertyName = "DocsCount";
            this.colDocsCount.HeaderText = "Total";
            this.colDocsCount.Name = "colDocsCount";
            this.colDocsCount.ReadOnly = true;
            // 
            // colFinished
            // 
            this.colFinished.DataPropertyName = "FinishCount";
            this.colFinished.HeaderText = "Finished";
            this.colFinished.Name = "colFinished";
            this.colFinished.ReadOnly = true;
            // 
            // colInProc
            // 
            this.colInProc.DataPropertyName = "InProcCount";
            this.colInProc.HeaderText = "InProc";
            this.colInProc.Name = "colInProc";
            this.colInProc.ReadOnly = true;
            // 
            // frmExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 286);
            this.Controls.Add(this.dgvMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "frmExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange SuitableWMS-LightWareHouse";
            this.Load += new System.EventHandler(this.frmExchange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrExchange;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinished;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInProc;
    }
}

