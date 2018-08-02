namespace UTC_MV_view
{
    partial class GPSSearch_Form
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
            this.GPSEndTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.GPSStartTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.StartSearch_btn = new System.Windows.Forms.Button();
            this.StopSearch_btn = new System.Windows.Forms.Button();
            this.Second_lon1 = new System.Windows.Forms.TextBox();
            this.Minute_lon1 = new System.Windows.Forms.TextBox();
            this.Degree_lon1 = new System.Windows.Forms.TextBox();
            this.lable_EventEndTime = new System.Windows.Forms.Label();
            this.lable_EventStartTime = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.No = new System.Windows.Forms.ColumnHeader();
            this.Time_list = new System.Windows.Forms.ColumnHeader();
            this.Block_ID = new System.Windows.Forms.ColumnHeader();
            this.Frag_ID = new System.Windows.Forms.ColumnHeader();
            this.Lat_SN = new System.Windows.Forms.ColumnHeader();
            this.Lat_list = new System.Windows.Forms.ColumnHeader();
            this.Lon_EW = new System.Windows.Forms.ColumnHeader();
            this.Lon_list = new System.Windows.Forms.ColumnHeader();
            this.Degree_lat1 = new System.Windows.Forms.TextBox();
            this.Degree_lat2 = new System.Windows.Forms.TextBox();
            this.Second_lat2 = new System.Windows.Forms.TextBox();
            this.Minute_lat2 = new System.Windows.Forms.TextBox();
            this.Second_lon2 = new System.Windows.Forms.TextBox();
            this.Minute_lon2 = new System.Windows.Forms.TextBox();
            this.Degree_lon2 = new System.Windows.Forms.TextBox();
            this.Second_lat1 = new System.Windows.Forms.TextBox();
            this.Minute_lat1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LON1_EW = new System.Windows.Forms.ComboBox();
            this.LAT1_SN = new System.Windows.Forms.ComboBox();
            this.LAT2_SN = new System.Windows.Forms.ComboBox();
            this.LON2_EW = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SearchType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.radius_tb = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GPSEndTime_Picker
            // 
            this.GPSEndTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.GPSEndTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.GPSEndTime_Picker.Location = new System.Drawing.Point(60, 58);
            this.GPSEndTime_Picker.Name = "GPSEndTime_Picker";
            this.GPSEndTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.GPSEndTime_Picker.TabIndex = 10;
            // 
            // GPSStartTime_Picker
            // 
            this.GPSStartTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.GPSStartTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.GPSStartTime_Picker.Location = new System.Drawing.Point(60, 12);
            this.GPSStartTime_Picker.Name = "GPSStartTime_Picker";
            this.GPSStartTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.GPSStartTime_Picker.TabIndex = 9;
            // 
            // StartSearch_btn
            // 
            this.StartSearch_btn.Location = new System.Drawing.Point(22, 93);
            this.StartSearch_btn.Name = "StartSearch_btn";
            this.StartSearch_btn.Size = new System.Drawing.Size(68, 26);
            this.StartSearch_btn.TabIndex = 18;
            this.StartSearch_btn.Text = "Start";
            this.StartSearch_btn.UseVisualStyleBackColor = true;
            this.StartSearch_btn.Click += new System.EventHandler(this.StartSearch_btn_Click);
            // 
            // StopSearch_btn
            // 
            this.StopSearch_btn.Location = new System.Drawing.Point(131, 93);
            this.StopSearch_btn.Name = "StopSearch_btn";
            this.StopSearch_btn.Size = new System.Drawing.Size(68, 26);
            this.StopSearch_btn.TabIndex = 19;
            this.StopSearch_btn.Text = "Stop";
            this.StopSearch_btn.UseVisualStyleBackColor = true;
            this.StopSearch_btn.Click += new System.EventHandler(this.StopSearch_btn_Click);
            // 
            // Second_lon1
            // 
            this.Second_lon1.Location = new System.Drawing.Point(496, 34);
            this.Second_lon1.MaxLength = 3;
            this.Second_lon1.Name = "Second_lon1";
            this.Second_lon1.Size = new System.Drawing.Size(51, 22);
            this.Second_lon1.TabIndex = 22;
            this.Second_lon1.Text = "0";
            // 
            // Minute_lon1
            // 
            this.Minute_lon1.Location = new System.Drawing.Point(418, 34);
            this.Minute_lon1.MaxLength = 3;
            this.Minute_lon1.Name = "Minute_lon1";
            this.Minute_lon1.Size = new System.Drawing.Size(51, 22);
            this.Minute_lon1.TabIndex = 21;
            this.Minute_lon1.Text = "0";
            // 
            // Degree_lon1
            // 
            this.Degree_lon1.Location = new System.Drawing.Point(343, 34);
            this.Degree_lon1.MaxLength = 3;
            this.Degree_lon1.Name = "Degree_lon1";
            this.Degree_lon1.Size = new System.Drawing.Size(51, 22);
            this.Degree_lon1.TabIndex = 20;
            this.Degree_lon1.Text = "0";
            // 
            // lable_EventEndTime
            // 
            this.lable_EventEndTime.AutoSize = true;
            this.lable_EventEndTime.Location = new System.Drawing.Point(6, 63);
            this.lable_EventEndTime.Name = "lable_EventEndTime";
            this.lable_EventEndTime.Size = new System.Drawing.Size(48, 12);
            this.lable_EventEndTime.TabIndex = 24;
            this.lable_EventEndTime.Text = "EndTime";
            // 
            // lable_EventStartTime
            // 
            this.lable_EventStartTime.AutoSize = true;
            this.lable_EventStartTime.Location = new System.Drawing.Point(4, 17);
            this.lable_EventStartTime.Name = "lable_EventStartTime";
            this.lable_EventStartTime.Size = new System.Drawing.Size(50, 12);
            this.lable_EventStartTime.TabIndex = 23;
            this.lable_EventStartTime.Text = "StartTime";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Time_list,
            this.Block_ID,
            this.Frag_ID,
            this.Lat_SN,
            this.Lat_list,
            this.Lon_EW,
            this.Lon_list});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(22, 139);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(747, 270);
            this.listView1.TabIndex = 25;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "No";
            // 
            // Time_list
            // 
            this.Time_list.Text = "Time";
            this.Time_list.Width = 100;
            // 
            // Block_ID
            // 
            this.Block_ID.Text = "Block ID";
            // 
            // Frag_ID
            // 
            this.Frag_ID.Text = "Frag ID";
            // 
            // Lat_SN
            // 
            this.Lat_SN.Text = "Lat SN";
            // 
            // Lat_list
            // 
            this.Lat_list.Text = "Lat";
            this.Lat_list.Width = 100;
            // 
            // Lon_EW
            // 
            this.Lon_EW.Text = "Lon EW";
            this.Lon_EW.Width = 59;
            // 
            // Lon_list
            // 
            this.Lon_list.Text = "Lon";
            this.Lon_list.Width = 100;
            // 
            // Degree_lat1
            // 
            this.Degree_lat1.Location = new System.Drawing.Point(343, 6);
            this.Degree_lat1.Name = "Degree_lat1";
            this.Degree_lat1.Size = new System.Drawing.Size(51, 22);
            this.Degree_lat1.TabIndex = 26;
            this.Degree_lat1.Text = "0";
            // 
            // Degree_lat2
            // 
            this.Degree_lat2.Location = new System.Drawing.Point(343, 62);
            this.Degree_lat2.Name = "Degree_lat2";
            this.Degree_lat2.Size = new System.Drawing.Size(51, 22);
            this.Degree_lat2.TabIndex = 27;
            this.Degree_lat2.Text = "0";
            // 
            // Second_lat2
            // 
            this.Second_lat2.Location = new System.Drawing.Point(496, 62);
            this.Second_lat2.Name = "Second_lat2";
            this.Second_lat2.Size = new System.Drawing.Size(51, 22);
            this.Second_lat2.TabIndex = 28;
            this.Second_lat2.Text = "0";
            // 
            // Minute_lat2
            // 
            this.Minute_lat2.Location = new System.Drawing.Point(418, 62);
            this.Minute_lat2.Name = "Minute_lat2";
            this.Minute_lat2.Size = new System.Drawing.Size(51, 22);
            this.Minute_lat2.TabIndex = 29;
            this.Minute_lat2.Text = "0";
            // 
            // Second_lon2
            // 
            this.Second_lon2.Location = new System.Drawing.Point(496, 90);
            this.Second_lon2.Name = "Second_lon2";
            this.Second_lon2.Size = new System.Drawing.Size(51, 22);
            this.Second_lon2.TabIndex = 30;
            this.Second_lon2.Text = "0";
            // 
            // Minute_lon2
            // 
            this.Minute_lon2.Location = new System.Drawing.Point(418, 90);
            this.Minute_lon2.Name = "Minute_lon2";
            this.Minute_lon2.Size = new System.Drawing.Size(51, 22);
            this.Minute_lon2.TabIndex = 31;
            this.Minute_lon2.Text = "0";
            // 
            // Degree_lon2
            // 
            this.Degree_lon2.Location = new System.Drawing.Point(343, 90);
            this.Degree_lon2.Name = "Degree_lon2";
            this.Degree_lon2.Size = new System.Drawing.Size(51, 22);
            this.Degree_lon2.TabIndex = 32;
            this.Degree_lon2.Text = "0";
            // 
            // Second_lat1
            // 
            this.Second_lat1.Location = new System.Drawing.Point(496, 6);
            this.Second_lat1.Name = "Second_lat1";
            this.Second_lat1.Size = new System.Drawing.Size(51, 22);
            this.Second_lat1.TabIndex = 33;
            this.Second_lat1.Text = "0";
            // 
            // Minute_lat1
            // 
            this.Minute_lat1.Location = new System.Drawing.Point(418, 6);
            this.Minute_lat1.Name = "Minute_lat1";
            this.Minute_lat1.Size = new System.Drawing.Size(51, 22);
            this.Minute_lat1.TabIndex = 34;
            this.Minute_lat1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "LON1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "LAT1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "LON2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "LAT2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "\"";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(7, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "\'";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 41;
            this.label7.Text = "o";
            // 
            // LON1_EW
            // 
            this.LON1_EW.FormattingEnabled = true;
            this.LON1_EW.Items.AddRange(new object[] {
            "E",
            "W"});
            this.LON1_EW.Location = new System.Drawing.Point(297, 35);
            this.LON1_EW.Name = "LON1_EW";
            this.LON1_EW.Size = new System.Drawing.Size(40, 20);
            this.LON1_EW.TabIndex = 42;
            // 
            // LAT1_SN
            // 
            this.LAT1_SN.FormattingEnabled = true;
            this.LAT1_SN.Items.AddRange(new object[] {
            "S",
            "N"});
            this.LAT1_SN.Location = new System.Drawing.Point(297, 6);
            this.LAT1_SN.Name = "LAT1_SN";
            this.LAT1_SN.Size = new System.Drawing.Size(40, 20);
            this.LAT1_SN.TabIndex = 43;
            // 
            // LAT2_SN
            // 
            this.LAT2_SN.FormattingEnabled = true;
            this.LAT2_SN.Items.AddRange(new object[] {
            "S",
            "N"});
            this.LAT2_SN.Location = new System.Drawing.Point(297, 62);
            this.LAT2_SN.Name = "LAT2_SN";
            this.LAT2_SN.Size = new System.Drawing.Size(40, 20);
            this.LAT2_SN.TabIndex = 44;
            // 
            // LON2_EW
            // 
            this.LON2_EW.FormattingEnabled = true;
            this.LON2_EW.Items.AddRange(new object[] {
            "E",
            "W"});
            this.LON2_EW.Location = new System.Drawing.Point(297, 90);
            this.LON2_EW.Name = "LON2_EW";
            this.LON2_EW.Size = new System.Drawing.Size(40, 20);
            this.LON2_EW.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(400, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 46;
            this.label8.Text = "o";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(400, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 47;
            this.label9.Text = "o";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(400, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 48;
            this.label10.Text = "o";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(7, 12);
            this.label11.TabIndex = 49;
            this.label11.Text = "\'";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(475, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(7, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "\'";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(475, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(7, 12);
            this.label13.TabIndex = 51;
            this.label13.Text = "\'";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(553, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 12);
            this.label14.TabIndex = 52;
            this.label14.Text = "\"";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(553, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 12);
            this.label15.TabIndex = 53;
            this.label15.Text = "\"";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(553, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 12);
            this.label16.TabIndex = 54;
            this.label16.Text = "\"";
            // 
            // SearchType
            // 
            this.SearchType.FormattingEnabled = true;
            this.SearchType.Items.AddRange(new object[] {
            "TimeSpan",
            "Closest Point",
            "Pass Certain Point"});
            this.SearchType.Location = new System.Drawing.Point(654, 9);
            this.SearchType.Name = "SearchType";
            this.SearchType.Size = new System.Drawing.Size(99, 20);
            this.SearchType.TabIndex = 55;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(572, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 12);
            this.label17.TabIndex = 56;
            this.label17.Text = "Selected Mode:";
            // 
            // radius_tb
            // 
            this.radius_tb.Location = new System.Drawing.Point(654, 37);
            this.radius_tb.MaxLength = 3;
            this.radius_tb.Name = "radius_tb";
            this.radius_tb.Size = new System.Drawing.Size(58, 22);
            this.radius_tb.TabIndex = 57;
            this.radius_tb.Text = "1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(609, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 12);
            this.label18.TabIndex = 58;
            this.label18.Text = "radius:";
            // 
            // GPSSearch_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 432);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.radius_tb);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.SearchType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LON2_EW);
            this.Controls.Add(this.LAT2_SN);
            this.Controls.Add(this.LAT1_SN);
            this.Controls.Add(this.LON1_EW);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Minute_lat1);
            this.Controls.Add(this.Second_lat1);
            this.Controls.Add(this.Degree_lon2);
            this.Controls.Add(this.Minute_lon2);
            this.Controls.Add(this.Second_lon2);
            this.Controls.Add(this.Minute_lat2);
            this.Controls.Add(this.Second_lat2);
            this.Controls.Add(this.Degree_lat2);
            this.Controls.Add(this.Degree_lat1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lable_EventEndTime);
            this.Controls.Add(this.lable_EventStartTime);
            this.Controls.Add(this.Second_lon1);
            this.Controls.Add(this.Minute_lon1);
            this.Controls.Add(this.Degree_lon1);
            this.Controls.Add(this.StartSearch_btn);
            this.Controls.Add(this.StopSearch_btn);
            this.Controls.Add(this.GPSEndTime_Picker);
            this.Controls.Add(this.GPSStartTime_Picker);
            this.Name = "GPSSearch_Form";
            this.Text = "GPSSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.On_GPSSearchClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker GPSEndTime_Picker;
        private System.Windows.Forms.DateTimePicker GPSStartTime_Picker;
        private System.Windows.Forms.Button StartSearch_btn;
        private System.Windows.Forms.Button StopSearch_btn;
        private System.Windows.Forms.TextBox Second_lon1;
        private System.Windows.Forms.TextBox Minute_lon1;
        private System.Windows.Forms.TextBox Degree_lon1;
        private System.Windows.Forms.Label lable_EventEndTime;
        private System.Windows.Forms.Label lable_EventStartTime;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Time_list;
        private System.Windows.Forms.ColumnHeader Lat_SN;
        private System.Windows.Forms.TextBox Degree_lat1;
        private System.Windows.Forms.TextBox Degree_lat2;
        private System.Windows.Forms.TextBox Second_lat2;
        private System.Windows.Forms.TextBox Minute_lat2;
        private System.Windows.Forms.TextBox Second_lon2;
        private System.Windows.Forms.TextBox Minute_lon2;
        private System.Windows.Forms.TextBox Degree_lon2;
        private System.Windows.Forms.TextBox Second_lat1;
        private System.Windows.Forms.TextBox Minute_lat1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox LON1_EW;
        private System.Windows.Forms.ComboBox LAT1_SN;
        private System.Windows.Forms.ComboBox LAT2_SN;
        private System.Windows.Forms.ComboBox LON2_EW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ColumnHeader Block_ID;
        private System.Windows.Forms.ColumnHeader Lat_list;
        private System.Windows.Forms.ColumnHeader Lon_EW;
        private System.Windows.Forms.ColumnHeader Lon_list;
        private System.Windows.Forms.ColumnHeader Frag_ID;
        private System.Windows.Forms.ComboBox SearchType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox radius_tb;
        private System.Windows.Forms.Label label18;
    }
}