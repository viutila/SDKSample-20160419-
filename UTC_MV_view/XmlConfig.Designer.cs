namespace UTC_MV_view
{
    partial class XmlConfig
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
            this.txtXML = new System.Windows.Forms.TextBox();
            this.treeXML = new System.Windows.Forms.TreeView();
            this.Selectlab = new System.Windows.Forms.Label();
            this.cmbFile = new System.Windows.Forms.ComboBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.Stop_Alarmlog_btn = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(31, 61);
            this.txtXML.MaxLength = 500000;
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXML.Size = new System.Drawing.Size(407, 460);
            this.txtXML.TabIndex = 0;
            // 
            // treeXML
            // 
            this.treeXML.Location = new System.Drawing.Point(457, 61);
            this.treeXML.Name = "treeXML";
            this.treeXML.Size = new System.Drawing.Size(327, 460);
            this.treeXML.TabIndex = 1;
            // 
            // Selectlab
            // 
            this.Selectlab.AutoSize = true;
            this.Selectlab.Location = new System.Drawing.Point(36, 29);
            this.Selectlab.Name = "Selectlab";
            this.Selectlab.Size = new System.Drawing.Size(41, 12);
            this.Selectlab.TabIndex = 2;
            this.Selectlab.Text = "Select : ";
            // 
            // cmbFile
            // 
            this.cmbFile.FormattingEnabled = true;
            this.cmbFile.Items.AddRange(new object[] {
            "dvr_dev_info",
            "dvr_health",
            "alarm_log",
            "get_alarm_table",
            "General",
            "get_vid_table"});
            this.cmbFile.Location = new System.Drawing.Point(83, 26);
            this.cmbFile.Name = "cmbFile";
            this.cmbFile.Size = new System.Drawing.Size(121, 20);
            this.cmbFile.TabIndex = 3;
            this.cmbFile.SelectedIndexChanged += new System.EventHandler(this.cmbFile_SelectedIndexChanged);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(211, 24);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(62, 23);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(457, 24);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(95, 23);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "Convert to Tree View";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // Stop_Alarmlog_btn
            // 
            this.Stop_Alarmlog_btn.Location = new System.Drawing.Point(349, 24);
            this.Stop_Alarmlog_btn.Name = "Stop_Alarmlog_btn";
            this.Stop_Alarmlog_btn.Size = new System.Drawing.Size(89, 22);
            this.Stop_Alarmlog_btn.TabIndex = 6;
            this.Stop_Alarmlog_btn.Text = "Stop Alarm Log";
            this.Stop_Alarmlog_btn.UseVisualStyleBackColor = true;
            this.Stop_Alarmlog_btn.Click += new System.EventHandler(this.Stop_Alarmlog_btn_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(281, 24);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(62, 22);
            this.btnSet.TabIndex = 7;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // XmlConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 549);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.Stop_Alarmlog_btn);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.cmbFile);
            this.Controls.Add(this.Selectlab);
            this.Controls.Add(this.treeXML);
            this.Controls.Add(this.txtXML);
            this.Name = "XmlConfig";
            this.Text = "XmlConfig";
            this.Load += new System.EventHandler(this.XmlConfig_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.On_XmlConfigClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.TreeView treeXML;
        private System.Windows.Forms.Label Selectlab;
        private System.Windows.Forms.ComboBox cmbFile;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button Stop_Alarmlog_btn;
        private System.Windows.Forms.Button btnSet;
    }
}