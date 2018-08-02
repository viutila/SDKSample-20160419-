namespace UTC_MV_view
{
    partial class Archive
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
            this.ArchiveBar = new System.Windows.Forms.ProgressBar();
            this.ArchiveCancelbtn = new System.Windows.Forms.Button();
            this.ArchiveStartbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Camera_cb12 = new System.Windows.Forms.CheckBox();
            this.Camera_cb9 = new System.Windows.Forms.CheckBox();
            this.Camera_cb11 = new System.Windows.Forms.CheckBox();
            this.Camera_cb10 = new System.Windows.Forms.CheckBox();
            this.Camera_cb8 = new System.Windows.Forms.CheckBox();
            this.Camera_cb5 = new System.Windows.Forms.CheckBox();
            this.Camera_cb7 = new System.Windows.Forms.CheckBox();
            this.Camera_cb6 = new System.Windows.Forms.CheckBox();
            this.Camera_cb4 = new System.Windows.Forms.CheckBox();
            this.Camera_cb1 = new System.Windows.Forms.CheckBox();
            this.Camera_cb3 = new System.Windows.Forms.CheckBox();
            this.Camera_cb2 = new System.Windows.Forms.CheckBox();
            this.EndTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.lable_EventEndTime = new System.Windows.Forms.Label();
            this.lable_EventStartTime = new System.Windows.Forms.Label();
            this.StartTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.Sele_DeviceType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileSize = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ResumeArchive_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LastBlockID_txt = new System.Windows.Forms.TextBox();
            this.FilePath_txt = new System.Windows.Forms.TextBox();
            this.AudioTag_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SubStream = new System.Windows.Forms.RadioButton();
            this.MainStream = new System.Windows.Forms.RadioButton();
            this.PartialArchive_cb = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchiveBar
            // 
            this.ArchiveBar.Location = new System.Drawing.Point(32, 213);
            this.ArchiveBar.Name = "ArchiveBar";
            this.ArchiveBar.Size = new System.Drawing.Size(396, 22);
            this.ArchiveBar.TabIndex = 28;
            // 
            // ArchiveCancelbtn
            // 
            this.ArchiveCancelbtn.Location = new System.Drawing.Point(157, 178);
            this.ArchiveCancelbtn.Name = "ArchiveCancelbtn";
            this.ArchiveCancelbtn.Size = new System.Drawing.Size(75, 23);
            this.ArchiveCancelbtn.TabIndex = 27;
            this.ArchiveCancelbtn.Text = "Cancel";
            this.ArchiveCancelbtn.UseVisualStyleBackColor = true;
            this.ArchiveCancelbtn.Click += new System.EventHandler(this.ArchiveCancelbtn_Click);
            // 
            // ArchiveStartbtn
            // 
            this.ArchiveStartbtn.Location = new System.Drawing.Point(32, 178);
            this.ArchiveStartbtn.Name = "ArchiveStartbtn";
            this.ArchiveStartbtn.Size = new System.Drawing.Size(75, 23);
            this.ArchiveStartbtn.TabIndex = 26;
            this.ArchiveStartbtn.Text = "Start";
            this.ArchiveStartbtn.UseVisualStyleBackColor = true;
            this.ArchiveStartbtn.Click += new System.EventHandler(this.ArchiveStartbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Camera_cb12);
            this.groupBox1.Controls.Add(this.Camera_cb9);
            this.groupBox1.Controls.Add(this.Camera_cb11);
            this.groupBox1.Controls.Add(this.Camera_cb10);
            this.groupBox1.Controls.Add(this.Camera_cb8);
            this.groupBox1.Controls.Add(this.Camera_cb5);
            this.groupBox1.Controls.Add(this.Camera_cb7);
            this.groupBox1.Controls.Add(this.Camera_cb6);
            this.groupBox1.Controls.Add(this.Camera_cb4);
            this.groupBox1.Controls.Add(this.Camera_cb1);
            this.groupBox1.Controls.Add(this.Camera_cb3);
            this.groupBox1.Controls.Add(this.Camera_cb2);
            this.groupBox1.Location = new System.Drawing.Point(264, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 113);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera";
            // 
            // Camera_cb12
            // 
            this.Camera_cb12.AutoSize = true;
            this.Camera_cb12.Checked = true;
            this.Camera_cb12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb12.Location = new System.Drawing.Point(115, 85);
            this.Camera_cb12.Name = "Camera_cb12";
            this.Camera_cb12.Size = new System.Drawing.Size(36, 16);
            this.Camera_cb12.TabIndex = 31;
            this.Camera_cb12.Text = "12";
            this.Camera_cb12.UseVisualStyleBackColor = true;
            // 
            // Camera_cb9
            // 
            this.Camera_cb9.AutoSize = true;
            this.Camera_cb9.Checked = true;
            this.Camera_cb9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb9.Location = new System.Drawing.Point(9, 85);
            this.Camera_cb9.Name = "Camera_cb9";
            this.Camera_cb9.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb9.TabIndex = 28;
            this.Camera_cb9.Text = "9";
            this.Camera_cb9.UseVisualStyleBackColor = true;
            // 
            // Camera_cb11
            // 
            this.Camera_cb11.AutoSize = true;
            this.Camera_cb11.Checked = true;
            this.Camera_cb11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb11.Location = new System.Drawing.Point(79, 85);
            this.Camera_cb11.Name = "Camera_cb11";
            this.Camera_cb11.Size = new System.Drawing.Size(36, 16);
            this.Camera_cb11.TabIndex = 30;
            this.Camera_cb11.Text = "11";
            this.Camera_cb11.UseVisualStyleBackColor = true;
            // 
            // Camera_cb10
            // 
            this.Camera_cb10.AutoSize = true;
            this.Camera_cb10.Checked = true;
            this.Camera_cb10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb10.Location = new System.Drawing.Point(43, 85);
            this.Camera_cb10.Name = "Camera_cb10";
            this.Camera_cb10.Size = new System.Drawing.Size(36, 16);
            this.Camera_cb10.TabIndex = 29;
            this.Camera_cb10.Text = "10";
            this.Camera_cb10.UseVisualStyleBackColor = true;
            // 
            // Camera_cb8
            // 
            this.Camera_cb8.AutoSize = true;
            this.Camera_cb8.Checked = true;
            this.Camera_cb8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb8.Location = new System.Drawing.Point(115, 55);
            this.Camera_cb8.Name = "Camera_cb8";
            this.Camera_cb8.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb8.TabIndex = 27;
            this.Camera_cb8.Text = "8";
            this.Camera_cb8.UseVisualStyleBackColor = true;
            // 
            // Camera_cb5
            // 
            this.Camera_cb5.AutoSize = true;
            this.Camera_cb5.Checked = true;
            this.Camera_cb5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb5.Location = new System.Drawing.Point(9, 55);
            this.Camera_cb5.Name = "Camera_cb5";
            this.Camera_cb5.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb5.TabIndex = 24;
            this.Camera_cb5.Text = "5";
            this.Camera_cb5.UseVisualStyleBackColor = true;
            // 
            // Camera_cb7
            // 
            this.Camera_cb7.AutoSize = true;
            this.Camera_cb7.Checked = true;
            this.Camera_cb7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb7.Location = new System.Drawing.Point(79, 55);
            this.Camera_cb7.Name = "Camera_cb7";
            this.Camera_cb7.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb7.TabIndex = 26;
            this.Camera_cb7.Text = "7";
            this.Camera_cb7.UseVisualStyleBackColor = true;
            // 
            // Camera_cb6
            // 
            this.Camera_cb6.AutoSize = true;
            this.Camera_cb6.Checked = true;
            this.Camera_cb6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb6.Location = new System.Drawing.Point(43, 55);
            this.Camera_cb6.Name = "Camera_cb6";
            this.Camera_cb6.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb6.TabIndex = 25;
            this.Camera_cb6.Text = "6";
            this.Camera_cb6.UseVisualStyleBackColor = true;
            // 
            // Camera_cb4
            // 
            this.Camera_cb4.AutoSize = true;
            this.Camera_cb4.Checked = true;
            this.Camera_cb4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb4.Location = new System.Drawing.Point(115, 24);
            this.Camera_cb4.Name = "Camera_cb4";
            this.Camera_cb4.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb4.TabIndex = 23;
            this.Camera_cb4.Text = "4";
            this.Camera_cb4.UseVisualStyleBackColor = true;
            // 
            // Camera_cb1
            // 
            this.Camera_cb1.AutoSize = true;
            this.Camera_cb1.Checked = true;
            this.Camera_cb1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb1.Location = new System.Drawing.Point(9, 24);
            this.Camera_cb1.Name = "Camera_cb1";
            this.Camera_cb1.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb1.TabIndex = 20;
            this.Camera_cb1.Text = "1";
            this.Camera_cb1.UseVisualStyleBackColor = true;
            // 
            // Camera_cb3
            // 
            this.Camera_cb3.AutoSize = true;
            this.Camera_cb3.Checked = true;
            this.Camera_cb3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb3.Location = new System.Drawing.Point(79, 24);
            this.Camera_cb3.Name = "Camera_cb3";
            this.Camera_cb3.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb3.TabIndex = 22;
            this.Camera_cb3.Text = "3";
            this.Camera_cb3.UseVisualStyleBackColor = true;
            // 
            // Camera_cb2
            // 
            this.Camera_cb2.AutoSize = true;
            this.Camera_cb2.Checked = true;
            this.Camera_cb2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cb2.Location = new System.Drawing.Point(43, 24);
            this.Camera_cb2.Name = "Camera_cb2";
            this.Camera_cb2.Size = new System.Drawing.Size(30, 16);
            this.Camera_cb2.TabIndex = 21;
            this.Camera_cb2.Text = "2";
            this.Camera_cb2.UseVisualStyleBackColor = true;
            // 
            // EndTime_Picker
            // 
            this.EndTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.EndTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTime_Picker.Location = new System.Drawing.Point(86, 49);
            this.EndTime_Picker.Name = "EndTime_Picker";
            this.EndTime_Picker.Size = new System.Drawing.Size(146, 22);
            this.EndTime_Picker.TabIndex = 24;
            // 
            // lable_EventEndTime
            // 
            this.lable_EventEndTime.AutoSize = true;
            this.lable_EventEndTime.Location = new System.Drawing.Point(32, 54);
            this.lable_EventEndTime.Name = "lable_EventEndTime";
            this.lable_EventEndTime.Size = new System.Drawing.Size(48, 12);
            this.lable_EventEndTime.TabIndex = 23;
            this.lable_EventEndTime.Text = "EndTime";
            // 
            // lable_EventStartTime
            // 
            this.lable_EventStartTime.AutoSize = true;
            this.lable_EventStartTime.Location = new System.Drawing.Point(30, 26);
            this.lable_EventStartTime.Name = "lable_EventStartTime";
            this.lable_EventStartTime.Size = new System.Drawing.Size(50, 12);
            this.lable_EventStartTime.TabIndex = 22;
            this.lable_EventStartTime.Text = "StartTime";
            // 
            // StartTime_Picker
            // 
            this.StartTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.StartTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTime_Picker.Location = new System.Drawing.Point(86, 21);
            this.StartTime_Picker.Name = "StartTime_Picker";
            this.StartTime_Picker.Size = new System.Drawing.Size(146, 22);
            this.StartTime_Picker.TabIndex = 21;
            // 
            // Sele_DeviceType
            // 
            this.Sele_DeviceType.Enabled = false;
            this.Sele_DeviceType.Location = new System.Drawing.Point(184, 102);
            this.Sele_DeviceType.Name = "Sele_DeviceType";
            this.Sele_DeviceType.Size = new System.Drawing.Size(52, 22);
            this.Sele_DeviceType.TabIndex = 30;
            this.Sele_DeviceType.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "Seleted Device Type: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "Maximum File Size(MB):";
            // 
            // tbFileSize
            // 
            this.tbFileSize.Location = new System.Drawing.Point(184, 128);
            this.tbFileSize.Name = "tbFileSize";
            this.tbFileSize.Size = new System.Drawing.Size(52, 22);
            this.tbFileSize.TabIndex = 33;
            this.tbFileSize.Text = "2000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ResumeArchive_btn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.LastBlockID_txt);
            this.groupBox2.Controls.Add(this.FilePath_txt);
            this.groupBox2.Location = new System.Drawing.Point(32, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 150);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resume Archive";
            // 
            // ResumeArchive_btn
            // 
            this.ResumeArchive_btn.Location = new System.Drawing.Point(18, 111);
            this.ResumeArchive_btn.Name = "ResumeArchive_btn";
            this.ResumeArchive_btn.Size = new System.Drawing.Size(100, 24);
            this.ResumeArchive_btn.TabIndex = 4;
            this.ResumeArchive_btn.Text = "Resume Archive";
            this.ResumeArchive_btn.UseVisualStyleBackColor = true;
            this.ResumeArchive_btn.Click += new System.EventHandler(this.ResumeArchive_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Last block id :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "File Path :";
            // 
            // LastBlockID_txt
            // 
            this.LastBlockID_txt.Location = new System.Drawing.Point(93, 70);
            this.LastBlockID_txt.Name = "LastBlockID_txt";
            this.LastBlockID_txt.Size = new System.Drawing.Size(283, 22);
            this.LastBlockID_txt.TabIndex = 1;
            // 
            // FilePath_txt
            // 
            this.FilePath_txt.Location = new System.Drawing.Point(93, 21);
            this.FilePath_txt.Name = "FilePath_txt";
            this.FilePath_txt.Size = new System.Drawing.Size(284, 22);
            this.FilePath_txt.TabIndex = 0;
            // 
            // AudioTag_tb
            // 
            this.AudioTag_tb.Location = new System.Drawing.Point(184, 75);
            this.AudioTag_tb.Name = "AudioTag_tb";
            this.AudioTag_tb.Size = new System.Drawing.Size(52, 22);
            this.AudioTag_tb.TabIndex = 36;
            this.AudioTag_tb.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "AudioTag:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SubStream);
            this.groupBox3.Controls.Add(this.MainStream);
            this.groupBox3.Location = new System.Drawing.Point(265, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 64);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DualStream";
            // 
            // SubStream
            // 
            this.SubStream.AutoSize = true;
            this.SubStream.Location = new System.Drawing.Point(9, 43);
            this.SubStream.Name = "SubStream";
            this.SubStream.Size = new System.Drawing.Size(41, 16);
            this.SubStream.TabIndex = 50;
            this.SubStream.TabStop = true;
            this.SubStream.Text = "Sub";
            this.SubStream.UseVisualStyleBackColor = true;
            // 
            // MainStream
            // 
            this.MainStream.AutoSize = true;
            this.MainStream.Checked = true;
            this.MainStream.Location = new System.Drawing.Point(9, 21);
            this.MainStream.Name = "MainStream";
            this.MainStream.Size = new System.Drawing.Size(47, 16);
            this.MainStream.TabIndex = 49;
            this.MainStream.TabStop = true;
            this.MainStream.Text = "Main";
            this.MainStream.UseVisualStyleBackColor = true;
            // 
            // PartialArchive_cb
            // 
            this.PartialArchive_cb.AutoSize = true;
            this.PartialArchive_cb.Location = new System.Drawing.Point(148, 156);
            this.PartialArchive_cb.Name = "PartialArchive_cb";
            this.PartialArchive_cb.Size = new System.Drawing.Size(93, 16);
            this.PartialArchive_cb.TabIndex = 50;
            this.PartialArchive_cb.Text = "Partial Archive";
            this.PartialArchive_cb.UseVisualStyleBackColor = true;
            this.PartialArchive_cb.CheckedChanged += new System.EventHandler(this.PartailArchive_Change);
            // 
            // Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 420);
            this.Controls.Add(this.PartialArchive_cb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AudioTag_tb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbFileSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sele_DeviceType);
            this.Controls.Add(this.ArchiveBar);
            this.Controls.Add(this.ArchiveCancelbtn);
            this.Controls.Add(this.ArchiveStartbtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EndTime_Picker);
            this.Controls.Add(this.lable_EventEndTime);
            this.Controls.Add(this.lable_EventStartTime);
            this.Controls.Add(this.StartTime_Picker);
            this.Name = "Archive";
            this.Text = "Archive";
            this.Load += new System.EventHandler(this.Archive_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.On_ArchiveFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ArchiveBar;
        private System.Windows.Forms.Button ArchiveCancelbtn;
        private System.Windows.Forms.Button ArchiveStartbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Camera_cb4;
        private System.Windows.Forms.CheckBox Camera_cb1;
        private System.Windows.Forms.CheckBox Camera_cb3;
        private System.Windows.Forms.CheckBox Camera_cb2;
        private System.Windows.Forms.DateTimePicker EndTime_Picker;
        private System.Windows.Forms.Label lable_EventEndTime;
        private System.Windows.Forms.Label lable_EventStartTime;
        private System.Windows.Forms.DateTimePicker StartTime_Picker;
        private System.Windows.Forms.TextBox Sele_DeviceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileSize;
        private System.Windows.Forms.CheckBox Camera_cb12;
        private System.Windows.Forms.CheckBox Camera_cb9;
        private System.Windows.Forms.CheckBox Camera_cb11;
        private System.Windows.Forms.CheckBox Camera_cb10;
        private System.Windows.Forms.CheckBox Camera_cb8;
        private System.Windows.Forms.CheckBox Camera_cb5;
        private System.Windows.Forms.CheckBox Camera_cb7;
        private System.Windows.Forms.CheckBox Camera_cb6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ResumeArchive_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LastBlockID_txt;
        private System.Windows.Forms.TextBox FilePath_txt;
        private System.Windows.Forms.TextBox AudioTag_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton SubStream;
        private System.Windows.Forms.RadioButton MainStream;
        private System.Windows.Forms.CheckBox PartialArchive_cb;
    }
}