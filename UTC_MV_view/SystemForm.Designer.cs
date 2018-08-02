namespace UTC_MV_view
{
    partial class SystemForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnFwBrowse = new System.Windows.Forms.Button();
            this.edFwFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFwUpgrade = new System.Windows.Forms.Button();
            this.panelPgsFw = new System.Windows.Forms.Panel();
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.pgsBarFw = new System.Windows.Forms.ProgressBar();
            this.FwUpgradeTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.panelPgsFw.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnFwBrowse
            // 
            this.BtnFwBrowse.Location = new System.Drawing.Point(262, 17);
            this.BtnFwBrowse.Name = "BtnFwBrowse";
            this.BtnFwBrowse.Size = new System.Drawing.Size(83, 30);
            this.BtnFwBrowse.TabIndex = 0;
            this.BtnFwBrowse.Text = "Browse";
            this.BtnFwBrowse.UseVisualStyleBackColor = true;
            this.BtnFwBrowse.Click += new System.EventHandler(this.BtnFwBrowse_Click);
            // 
            // edFwFilePath
            // 
            this.edFwFilePath.Location = new System.Drawing.Point(16, 23);
            this.edFwFilePath.Name = "edFwFilePath";
            this.edFwFilePath.Size = new System.Drawing.Size(240, 22);
            this.edFwFilePath.TabIndex = 1;
            this.edFwFilePath.Text = "D:\\Project\\UTC\\emv4x.bin";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFwUpgrade);
            this.groupBox1.Controls.Add(this.panelPgsFw);
            this.groupBox1.Controls.Add(this.edFwFilePath);
            this.groupBox1.Controls.Add(this.BtnFwBrowse);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Firmware";
            // 
            // btnFwUpgrade
            // 
            this.btnFwUpgrade.Location = new System.Drawing.Point(262, 61);
            this.btnFwUpgrade.Name = "btnFwUpgrade";
            this.btnFwUpgrade.Size = new System.Drawing.Size(83, 30);
            this.btnFwUpgrade.TabIndex = 3;
            this.btnFwUpgrade.Text = "Upgrade";
            this.btnFwUpgrade.UseVisualStyleBackColor = true;
            this.btnFwUpgrade.Click += new System.EventHandler(this.btnFwUpgrade_Click);
            // 
            // panelPgsFw
            // 
            this.panelPgsFw.Controls.Add(this.txtFirmware);
            this.panelPgsFw.Controls.Add(this.pgsBarFw);
            this.panelPgsFw.Location = new System.Drawing.Point(16, 57);
            this.panelPgsFw.Name = "panelPgsFw";
            this.panelPgsFw.Size = new System.Drawing.Size(240, 39);
            this.panelPgsFw.TabIndex = 2;
            this.panelPgsFw.Visible = false;
            // 
            // txtFirmware
            // 
            this.txtFirmware.BackColor = System.Drawing.SystemColors.Control;
            this.txtFirmware.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirmware.Location = new System.Drawing.Point(166, 8);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.ReadOnly = true;
            this.txtFirmware.Size = new System.Drawing.Size(69, 15);
            this.txtFirmware.TabIndex = 5;
            // 
            // pgsBarFw
            // 
            this.pgsBarFw.Location = new System.Drawing.Point(3, 4);
            this.pgsBarFw.Name = "pgsBarFw";
            this.pgsBarFw.Size = new System.Drawing.Size(157, 23);
            this.pgsBarFw.TabIndex = 0;
            // 
            // FwUpgradeTimer
            // 
            this.FwUpgradeTimer.Interval = 1000;
            this.FwUpgradeTimer.Tick += new System.EventHandler(this.FwUpgradeTimer_Tick_1);
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 134);
            this.Controls.Add(this.groupBox1);
            this.Name = "SystemForm";
            this.Text = "SystemForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SystemFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPgsFw.ResumeLayout(false);
            this.panelPgsFw.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnFwBrowse;
        private System.Windows.Forms.TextBox edFwFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelPgsFw;
        private System.Windows.Forms.ProgressBar pgsBarFw;
        private System.Windows.Forms.Button btnFwUpgrade;
        private System.Windows.Forms.TextBox txtFirmware;
        private System.Windows.Forms.Timer FwUpgradeTimer;
    }
}