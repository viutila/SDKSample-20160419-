namespace UTC_MV_view
{
    partial class Search_Form
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.No = new System.Windows.Forms.ColumnHeader();
            this.ChMap = new System.Windows.Forms.ColumnHeader();
            this.CH = new System.Windows.Forms.ColumnHeader();
            this.Type = new System.Windows.Forms.ColumnHeader();
            this.StartTime = new System.Windows.Forms.ColumnHeader();
            this.EndTime = new System.Windows.Forms.ColumnHeader();
            this.Lat_sn = new System.Windows.Forms.ColumnHeader();
            this.Lat = new System.Windows.Forms.ColumnHeader();
            this.Lon_ew = new System.Windows.Forms.ColumnHeader();
            this.Lon = new System.Windows.Forms.ColumnHeader();
            this.Speed = new System.Windows.Forms.ColumnHeader();
            this.Gravity = new System.Windows.Forms.ColumnHeader();
            this.BlockID = new System.Windows.Forms.ColumnHeader();
            this.Direction = new System.Windows.Forms.ColumnHeader();
            this.Priority = new System.Windows.Forms.ColumnHeader();
            this.a_index = new System.Windows.Forms.ColumnHeader();
            this.v_index = new System.Windows.Forms.ColumnHeader();
            this.PreAlarmTime = new System.Windows.Forms.ColumnHeader();
            this.PostAlarmTime = new System.Windows.Forms.ColumnHeader();
            this.TimeZone = new System.Windows.Forms.ColumnHeader();
            this.DST = new System.Windows.Forms.ColumnHeader();
            this.eventName = new System.Windows.Forms.ColumnHeader();
            this.EventStartTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.lable_EventStartTime = new System.Windows.Forms.Label();
            this.lable_EventEndTime = new System.Windows.Forms.Label();
            this.EventEndTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.Startbtn = new System.Windows.Forms.Button();
            this.Stopbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Camera_cbv11 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv5 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv12 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv7 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv6 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Camera_cbv8 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv1 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv9 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv10 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv2 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv3 = new System.Windows.Forms.CheckBox();
            this.Camera_cbv4 = new System.Windows.Forms.CheckBox();
            this.Power_on_cb = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LON2_EW = new System.Windows.Forms.ComboBox();
            this.LAT2_SN = new System.Windows.Forms.ComboBox();
            this.LAT1_SN = new System.Windows.Forms.ComboBox();
            this.LON1_EW = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Minute_lat1 = new System.Windows.Forms.TextBox();
            this.Second_lat1 = new System.Windows.Forms.TextBox();
            this.Degree_lon2 = new System.Windows.Forms.TextBox();
            this.Minute_lon2 = new System.Windows.Forms.TextBox();
            this.Second_lon2 = new System.Windows.Forms.TextBox();
            this.Minute_lat2 = new System.Windows.Forms.TextBox();
            this.Second_lat2 = new System.Windows.Forms.TextBox();
            this.Degree_lat2 = new System.Windows.Forms.TextBox();
            this.Degree_lat1 = new System.Windows.Forms.TextBox();
            this.Second_lon1 = new System.Windows.Forms.TextBox();
            this.Minute_lon1 = new System.Windows.Forms.TextBox();
            this.Degree_lon1 = new System.Windows.Forms.TextBox();
            this.label_a_index = new System.Windows.Forms.Label();
            this.textBox_a_index = new System.Windows.Forms.TextBox();
            this.textBox_v_index = new System.Windows.Forms.TextBox();
            this.label_v_index = new System.Windows.Forms.Label();
            this.GS_Impact_cb = new System.Windows.Forms.CheckBox();
            this.GS_Accel_cb = new System.Windows.Forms.CheckBox();
            this.Alarm_cb = new System.Windows.Forms.CheckBox();
            this.Vloss_cb = new System.Windows.Forms.CheckBox();
            this.Condition_gb = new System.Windows.Forms.GroupBox();
            this.SystemFault_tb = new System.Windows.Forms.CheckBox();
            this.fullsearch_cb = new System.Windows.Forms.CheckBox();
            this.J1939_cb = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.Condition_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.ChMap,
            this.CH,
            this.Type,
            this.StartTime,
            this.EndTime,
            this.Lat_sn,
            this.Lat,
            this.Lon_ew,
            this.Lon,
            this.Speed,
            this.Gravity,
            this.BlockID,
            this.Direction,
            this.Priority,
            this.a_index,
            this.v_index,
            this.PreAlarmTime,
            this.PostAlarmTime,
            this.TimeZone,
            this.DST,
            this.eventName});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(38, 182);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1287, 324);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 46;
            // 
            // ChMap
            // 
            this.ChMap.Text = "ChMap";
            // 
            // CH
            // 
            this.CH.Text = "CH/Input";
            this.CH.Width = 50;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 100;
            // 
            // StartTime
            // 
            this.StartTime.Text = "StartTime";
            this.StartTime.Width = 50;
            // 
            // EndTime
            // 
            this.EndTime.Text = "EndTime";
            // 
            // Lat_sn
            // 
            this.Lat_sn.Text = "Lat_SN";
            // 
            // Lat
            // 
            this.Lat.Text = "Lat";
            // 
            // Lon_ew
            // 
            this.Lon_ew.Text = "Lon_EW";
            // 
            // Lon
            // 
            this.Lon.Text = "Lon";
            // 
            // Speed
            // 
            this.Speed.Text = "Speed";
            // 
            // Gravity
            // 
            this.Gravity.Text = "Gravity";
            // 
            // BlockID
            // 
            this.BlockID.Text = "BlockID";
            // 
            // Direction
            // 
            this.Direction.Text = "Direction";
            // 
            // Priority
            // 
            this.Priority.Text = "Priority";
            // 
            // a_index
            // 
            this.a_index.Text = "A_Index";
            // 
            // v_index
            // 
            this.v_index.Text = "V_Index";
            this.v_index.Width = 65;
            // 
            // PreAlarmTime
            // 
            this.PreAlarmTime.Text = "Pre";
            // 
            // PostAlarmTime
            // 
            this.PostAlarmTime.Text = "Post";
            // 
            // TimeZone
            // 
            this.TimeZone.Text = "TimeZone";
            this.TimeZone.Width = 72;
            // 
            // DST
            // 
            this.DST.Text = "DST";
            // 
            // eventName
            // 
            this.eventName.Text = "eventName";
            // 
            // EventStartTime_Picker
            // 
            this.EventStartTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.EventStartTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EventStartTime_Picker.Location = new System.Drawing.Point(90, 29);
            this.EventStartTime_Picker.Name = "EventStartTime_Picker";
            this.EventStartTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.EventStartTime_Picker.TabIndex = 1;
            // 
            // lable_EventStartTime
            // 
            this.lable_EventStartTime.AutoSize = true;
            this.lable_EventStartTime.Location = new System.Drawing.Point(34, 34);
            this.lable_EventStartTime.Name = "lable_EventStartTime";
            this.lable_EventStartTime.Size = new System.Drawing.Size(50, 12);
            this.lable_EventStartTime.TabIndex = 2;
            this.lable_EventStartTime.Text = "StartTime";
            // 
            // lable_EventEndTime
            // 
            this.lable_EventEndTime.AutoSize = true;
            this.lable_EventEndTime.Location = new System.Drawing.Point(36, 80);
            this.lable_EventEndTime.Name = "lable_EventEndTime";
            this.lable_EventEndTime.Size = new System.Drawing.Size(48, 12);
            this.lable_EventEndTime.TabIndex = 3;
            this.lable_EventEndTime.Text = "EndTime";
            // 
            // EventEndTime_Picker
            // 
            this.EventEndTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.EventEndTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EventEndTime_Picker.Location = new System.Drawing.Point(90, 75);
            this.EventEndTime_Picker.Name = "EventEndTime_Picker";
            this.EventEndTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.EventEndTime_Picker.TabIndex = 4;
            // 
            // Startbtn
            // 
            this.Startbtn.Location = new System.Drawing.Point(65, 125);
            this.Startbtn.Name = "Startbtn";
            this.Startbtn.Size = new System.Drawing.Size(68, 26);
            this.Startbtn.TabIndex = 5;
            this.Startbtn.Text = "Start";
            this.Startbtn.UseVisualStyleBackColor = true;
            this.Startbtn.Click += new System.EventHandler(this.Startbtn_Click);
            // 
            // Stopbtn
            // 
            this.Stopbtn.Location = new System.Drawing.Point(174, 125);
            this.Stopbtn.Name = "Stopbtn";
            this.Stopbtn.Size = new System.Drawing.Size(68, 26);
            this.Stopbtn.TabIndex = 6;
            this.Stopbtn.Text = "Stop";
            this.Stopbtn.UseVisualStyleBackColor = true;
            this.Stopbtn.Click += new System.EventHandler(this.Stopbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Camera_cbv11);
            this.groupBox1.Controls.Add(this.Camera_cbv5);
            this.groupBox1.Controls.Add(this.Camera_cbv12);
            this.groupBox1.Controls.Add(this.Camera_cbv7);
            this.groupBox1.Controls.Add(this.Camera_cbv6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Camera_cbv8);
            this.groupBox1.Controls.Add(this.Camera_cbv1);
            this.groupBox1.Controls.Add(this.Camera_cbv9);
            this.groupBox1.Controls.Add(this.Camera_cbv10);
            this.groupBox1.Controls.Add(this.Camera_cbv2);
            this.groupBox1.Controls.Add(this.Camera_cbv3);
            this.groupBox1.Controls.Add(this.Camera_cbv4);
            this.groupBox1.Location = new System.Drawing.Point(273, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 64);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera";
            // 
            // Camera_cbv11
            // 
            this.Camera_cbv11.AutoSize = true;
            this.Camera_cbv11.Checked = true;
            this.Camera_cbv11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv11.Location = new System.Drawing.Point(198, 36);
            this.Camera_cbv11.Name = "Camera_cbv11";
            this.Camera_cbv11.Size = new System.Drawing.Size(36, 16);
            this.Camera_cbv11.TabIndex = 95;
            this.Camera_cbv11.Text = "11";
            this.Camera_cbv11.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv5
            // 
            this.Camera_cbv5.AutoSize = true;
            this.Camera_cbv5.Checked = true;
            this.Camera_cbv5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv5.Location = new System.Drawing.Point(198, 14);
            this.Camera_cbv5.Name = "Camera_cbv5";
            this.Camera_cbv5.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv5.TabIndex = 93;
            this.Camera_cbv5.Text = "5";
            this.Camera_cbv5.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv12
            // 
            this.Camera_cbv12.AutoSize = true;
            this.Camera_cbv12.Checked = true;
            this.Camera_cbv12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv12.Location = new System.Drawing.Point(234, 36);
            this.Camera_cbv12.Name = "Camera_cbv12";
            this.Camera_cbv12.Size = new System.Drawing.Size(36, 16);
            this.Camera_cbv12.TabIndex = 96;
            this.Camera_cbv12.Text = "12";
            this.Camera_cbv12.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv7
            // 
            this.Camera_cbv7.AutoSize = true;
            this.Camera_cbv7.Checked = true;
            this.Camera_cbv7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv7.Location = new System.Drawing.Point(56, 36);
            this.Camera_cbv7.Name = "Camera_cbv7";
            this.Camera_cbv7.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv7.TabIndex = 93;
            this.Camera_cbv7.Text = "7";
            this.Camera_cbv7.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv6
            // 
            this.Camera_cbv6.AutoSize = true;
            this.Camera_cbv6.Checked = true;
            this.Camera_cbv6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv6.Location = new System.Drawing.Point(234, 14);
            this.Camera_cbv6.Name = "Camera_cbv6";
            this.Camera_cbv6.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv6.TabIndex = 94;
            this.Camera_cbv6.Text = "6";
            this.Camera_cbv6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Camera:";
            // 
            // Camera_cbv8
            // 
            this.Camera_cbv8.AutoSize = true;
            this.Camera_cbv8.Checked = true;
            this.Camera_cbv8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv8.Location = new System.Drawing.Point(92, 36);
            this.Camera_cbv8.Name = "Camera_cbv8";
            this.Camera_cbv8.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv8.TabIndex = 94;
            this.Camera_cbv8.Text = "8";
            this.Camera_cbv8.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv1
            // 
            this.Camera_cbv1.AutoSize = true;
            this.Camera_cbv1.Checked = true;
            this.Camera_cbv1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv1.Location = new System.Drawing.Point(56, 14);
            this.Camera_cbv1.Name = "Camera_cbv1";
            this.Camera_cbv1.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv1.TabIndex = 7;
            this.Camera_cbv1.Text = "1";
            this.Camera_cbv1.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv9
            // 
            this.Camera_cbv9.AutoSize = true;
            this.Camera_cbv9.Checked = true;
            this.Camera_cbv9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv9.Location = new System.Drawing.Point(126, 36);
            this.Camera_cbv9.Name = "Camera_cbv9";
            this.Camera_cbv9.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv9.TabIndex = 95;
            this.Camera_cbv9.Text = "9";
            this.Camera_cbv9.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv10
            // 
            this.Camera_cbv10.AutoSize = true;
            this.Camera_cbv10.Checked = true;
            this.Camera_cbv10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv10.Location = new System.Drawing.Point(162, 36);
            this.Camera_cbv10.Name = "Camera_cbv10";
            this.Camera_cbv10.Size = new System.Drawing.Size(36, 16);
            this.Camera_cbv10.TabIndex = 96;
            this.Camera_cbv10.Text = "10";
            this.Camera_cbv10.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv2
            // 
            this.Camera_cbv2.AutoSize = true;
            this.Camera_cbv2.Checked = true;
            this.Camera_cbv2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv2.Location = new System.Drawing.Point(92, 14);
            this.Camera_cbv2.Name = "Camera_cbv2";
            this.Camera_cbv2.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv2.TabIndex = 8;
            this.Camera_cbv2.Text = "2";
            this.Camera_cbv2.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv3
            // 
            this.Camera_cbv3.AutoSize = true;
            this.Camera_cbv3.Checked = true;
            this.Camera_cbv3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv3.Location = new System.Drawing.Point(126, 14);
            this.Camera_cbv3.Name = "Camera_cbv3";
            this.Camera_cbv3.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv3.TabIndex = 9;
            this.Camera_cbv3.Text = "3";
            this.Camera_cbv3.UseVisualStyleBackColor = true;
            // 
            // Camera_cbv4
            // 
            this.Camera_cbv4.AutoSize = true;
            this.Camera_cbv4.Checked = true;
            this.Camera_cbv4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Camera_cbv4.Location = new System.Drawing.Point(162, 14);
            this.Camera_cbv4.Name = "Camera_cbv4";
            this.Camera_cbv4.Size = new System.Drawing.Size(30, 16);
            this.Camera_cbv4.TabIndex = 10;
            this.Camera_cbv4.Text = "4";
            this.Camera_cbv4.UseVisualStyleBackColor = true;
            // 
            // Power_on_cb
            // 
            this.Power_on_cb.AutoSize = true;
            this.Power_on_cb.Checked = true;
            this.Power_on_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Power_on_cb.Location = new System.Drawing.Point(149, 21);
            this.Power_on_cb.Name = "Power_on_cb";
            this.Power_on_cb.Size = new System.Drawing.Size(70, 16);
            this.Power_on_cb.TabIndex = 28;
            this.Power_on_cb.Text = "Power On";
            this.Power_on_cb.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1026, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 12);
            this.label16.TabIndex = 86;
            this.label16.Text = "\"";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1026, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 12);
            this.label15.TabIndex = 85;
            this.label15.Text = "\"";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1026, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 12);
            this.label14.TabIndex = 84;
            this.label14.Text = "\"";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(948, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(7, 12);
            this.label13.TabIndex = 83;
            this.label13.Text = "\'";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(948, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(7, 12);
            this.label12.TabIndex = 82;
            this.label12.Text = "\'";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(948, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(7, 12);
            this.label11.TabIndex = 81;
            this.label11.Text = "\'";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(873, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 80;
            this.label10.Text = "o";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(873, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 79;
            this.label9.Text = "o";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(873, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 78;
            this.label8.Text = "o";
            // 
            // LON2_EW
            // 
            this.LON2_EW.FormattingEnabled = true;
            this.LON2_EW.Items.AddRange(new object[] {
            "E",
            "W"});
            this.LON2_EW.Location = new System.Drawing.Point(770, 108);
            this.LON2_EW.Name = "LON2_EW";
            this.LON2_EW.Size = new System.Drawing.Size(40, 20);
            this.LON2_EW.TabIndex = 77;
            // 
            // LAT2_SN
            // 
            this.LAT2_SN.FormattingEnabled = true;
            this.LAT2_SN.Items.AddRange(new object[] {
            "S",
            "N"});
            this.LAT2_SN.Location = new System.Drawing.Point(770, 80);
            this.LAT2_SN.Name = "LAT2_SN";
            this.LAT2_SN.Size = new System.Drawing.Size(40, 20);
            this.LAT2_SN.TabIndex = 76;
            // 
            // LAT1_SN
            // 
            this.LAT1_SN.FormattingEnabled = true;
            this.LAT1_SN.Items.AddRange(new object[] {
            "S",
            "N"});
            this.LAT1_SN.Location = new System.Drawing.Point(770, 24);
            this.LAT1_SN.Name = "LAT1_SN";
            this.LAT1_SN.Size = new System.Drawing.Size(40, 20);
            this.LAT1_SN.TabIndex = 75;
            // 
            // LON1_EW
            // 
            this.LON1_EW.FormattingEnabled = true;
            this.LON1_EW.Items.AddRange(new object[] {
            "E",
            "W"});
            this.LON1_EW.Location = new System.Drawing.Point(770, 53);
            this.LON1_EW.Name = "LON1_EW";
            this.LON1_EW.Size = new System.Drawing.Size(40, 20);
            this.LON1_EW.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(873, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 73;
            this.label7.Text = "o";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(948, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(7, 12);
            this.label6.TabIndex = 72;
            this.label6.Text = "\'";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1026, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 12);
            this.label5.TabIndex = 71;
            this.label5.Text = "\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(729, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "LAT2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(729, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 69;
            this.label3.Text = "LON2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(729, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 68;
            this.label2.Text = "LAT1:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(728, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 12);
            this.label17.TabIndex = 67;
            this.label17.Text = "LON1:";
            // 
            // Minute_lat1
            // 
            this.Minute_lat1.Location = new System.Drawing.Point(891, 24);
            this.Minute_lat1.Name = "Minute_lat1";
            this.Minute_lat1.Size = new System.Drawing.Size(51, 22);
            this.Minute_lat1.TabIndex = 66;
            this.Minute_lat1.Text = "0";
            // 
            // Second_lat1
            // 
            this.Second_lat1.Location = new System.Drawing.Point(969, 24);
            this.Second_lat1.Name = "Second_lat1";
            this.Second_lat1.Size = new System.Drawing.Size(51, 22);
            this.Second_lat1.TabIndex = 65;
            this.Second_lat1.Text = "0";
            // 
            // Degree_lon2
            // 
            this.Degree_lon2.Location = new System.Drawing.Point(816, 108);
            this.Degree_lon2.Name = "Degree_lon2";
            this.Degree_lon2.Size = new System.Drawing.Size(51, 22);
            this.Degree_lon2.TabIndex = 64;
            this.Degree_lon2.Text = "0";
            // 
            // Minute_lon2
            // 
            this.Minute_lon2.Location = new System.Drawing.Point(891, 108);
            this.Minute_lon2.Name = "Minute_lon2";
            this.Minute_lon2.Size = new System.Drawing.Size(51, 22);
            this.Minute_lon2.TabIndex = 63;
            this.Minute_lon2.Text = "0";
            // 
            // Second_lon2
            // 
            this.Second_lon2.Location = new System.Drawing.Point(969, 108);
            this.Second_lon2.Name = "Second_lon2";
            this.Second_lon2.Size = new System.Drawing.Size(51, 22);
            this.Second_lon2.TabIndex = 62;
            this.Second_lon2.Text = "0";
            // 
            // Minute_lat2
            // 
            this.Minute_lat2.Location = new System.Drawing.Point(891, 80);
            this.Minute_lat2.Name = "Minute_lat2";
            this.Minute_lat2.Size = new System.Drawing.Size(51, 22);
            this.Minute_lat2.TabIndex = 61;
            this.Minute_lat2.Text = "0";
            // 
            // Second_lat2
            // 
            this.Second_lat2.Location = new System.Drawing.Point(969, 80);
            this.Second_lat2.Name = "Second_lat2";
            this.Second_lat2.Size = new System.Drawing.Size(51, 22);
            this.Second_lat2.TabIndex = 60;
            this.Second_lat2.Text = "0";
            // 
            // Degree_lat2
            // 
            this.Degree_lat2.Location = new System.Drawing.Point(816, 80);
            this.Degree_lat2.Name = "Degree_lat2";
            this.Degree_lat2.Size = new System.Drawing.Size(51, 22);
            this.Degree_lat2.TabIndex = 59;
            this.Degree_lat2.Text = "0";
            // 
            // Degree_lat1
            // 
            this.Degree_lat1.Location = new System.Drawing.Point(816, 24);
            this.Degree_lat1.Name = "Degree_lat1";
            this.Degree_lat1.Size = new System.Drawing.Size(51, 22);
            this.Degree_lat1.TabIndex = 58;
            this.Degree_lat1.Text = "0";
            // 
            // Second_lon1
            // 
            this.Second_lon1.Location = new System.Drawing.Point(969, 52);
            this.Second_lon1.MaxLength = 3;
            this.Second_lon1.Name = "Second_lon1";
            this.Second_lon1.Size = new System.Drawing.Size(51, 22);
            this.Second_lon1.TabIndex = 57;
            this.Second_lon1.Text = "0";
            // 
            // Minute_lon1
            // 
            this.Minute_lon1.Location = new System.Drawing.Point(891, 52);
            this.Minute_lon1.MaxLength = 3;
            this.Minute_lon1.Name = "Minute_lon1";
            this.Minute_lon1.Size = new System.Drawing.Size(51, 22);
            this.Minute_lon1.TabIndex = 56;
            this.Minute_lon1.Text = "0";
            // 
            // Degree_lon1
            // 
            this.Degree_lon1.Location = new System.Drawing.Point(816, 52);
            this.Degree_lon1.MaxLength = 3;
            this.Degree_lon1.Name = "Degree_lon1";
            this.Degree_lon1.Size = new System.Drawing.Size(51, 22);
            this.Degree_lon1.TabIndex = 55;
            this.Degree_lon1.Text = "0";
            // 
            // label_a_index
            // 
            this.label_a_index.AutoSize = true;
            this.label_a_index.Location = new System.Drawing.Point(587, 26);
            this.label_a_index.Name = "label_a_index";
            this.label_a_index.Size = new System.Drawing.Size(48, 12);
            this.label_a_index.TabIndex = 87;
            this.label_a_index.Text = "A_index:";
            // 
            // textBox_a_index
            // 
            this.textBox_a_index.Location = new System.Drawing.Point(638, 23);
            this.textBox_a_index.Name = "textBox_a_index";
            this.textBox_a_index.Size = new System.Drawing.Size(51, 22);
            this.textBox_a_index.TabIndex = 88;
            this.textBox_a_index.Text = "255";
            // 
            // textBox_v_index
            // 
            this.textBox_v_index.Location = new System.Drawing.Point(638, 52);
            this.textBox_v_index.Name = "textBox_v_index";
            this.textBox_v_index.Size = new System.Drawing.Size(51, 22);
            this.textBox_v_index.TabIndex = 90;
            this.textBox_v_index.Text = "65535";
            // 
            // label_v_index
            // 
            this.label_v_index.AutoSize = true;
            this.label_v_index.Location = new System.Drawing.Point(587, 55);
            this.label_v_index.Name = "label_v_index";
            this.label_v_index.Size = new System.Drawing.Size(48, 12);
            this.label_v_index.TabIndex = 89;
            this.label_v_index.Text = "V_index:";
            // 
            // GS_Impact_cb
            // 
            this.GS_Impact_cb.AutoSize = true;
            this.GS_Impact_cb.Location = new System.Drawing.Point(8, 42);
            this.GS_Impact_cb.Name = "GS_Impact_cb";
            this.GS_Impact_cb.Size = new System.Drawing.Size(101, 16);
            this.GS_Impact_cb.TabIndex = 91;
            this.GS_Impact_cb.Text = "G Sensor Impact";
            this.GS_Impact_cb.UseVisualStyleBackColor = true;
            // 
            // GS_Accel_cb
            // 
            this.GS_Accel_cb.AutoSize = true;
            this.GS_Accel_cb.Location = new System.Drawing.Point(115, 42);
            this.GS_Accel_cb.Name = "GS_Accel_cb";
            this.GS_Accel_cb.Size = new System.Drawing.Size(95, 16);
            this.GS_Accel_cb.TabIndex = 92;
            this.GS_Accel_cb.Text = "G Sensor Accel";
            this.GS_Accel_cb.UseVisualStyleBackColor = true;
            // 
            // Alarm_cb
            // 
            this.Alarm_cb.AutoSize = true;
            this.Alarm_cb.Checked = true;
            this.Alarm_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Alarm_cb.Location = new System.Drawing.Point(8, 21);
            this.Alarm_cb.Name = "Alarm_cb";
            this.Alarm_cb.Size = new System.Drawing.Size(53, 16);
            this.Alarm_cb.TabIndex = 93;
            this.Alarm_cb.Text = "Alarm";
            this.Alarm_cb.UseVisualStyleBackColor = true;
            // 
            // Vloss_cb
            // 
            this.Vloss_cb.AutoSize = true;
            this.Vloss_cb.Checked = true;
            this.Vloss_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Vloss_cb.Location = new System.Drawing.Point(67, 21);
            this.Vloss_cb.Name = "Vloss_cb";
            this.Vloss_cb.Size = new System.Drawing.Size(76, 16);
            this.Vloss_cb.TabIndex = 94;
            this.Vloss_cb.Text = "Video Loss";
            this.Vloss_cb.UseVisualStyleBackColor = true;
            // 
            // Condition_gb
            // 
            this.Condition_gb.Controls.Add(this.J1939_cb);
            this.Condition_gb.Controls.Add(this.SystemFault_tb);
            this.Condition_gb.Controls.Add(this.Alarm_cb);
            this.Condition_gb.Controls.Add(this.GS_Accel_cb);
            this.Condition_gb.Controls.Add(this.Vloss_cb);
            this.Condition_gb.Controls.Add(this.GS_Impact_cb);
            this.Condition_gb.Controls.Add(this.Power_on_cb);
            this.Condition_gb.Location = new System.Drawing.Point(273, 20);
            this.Condition_gb.Name = "Condition_gb";
            this.Condition_gb.Size = new System.Drawing.Size(308, 64);
            this.Condition_gb.TabIndex = 95;
            this.Condition_gb.TabStop = false;
            this.Condition_gb.Text = "Condition";
            // 
            // SystemFault_tb
            // 
            this.SystemFault_tb.AutoSize = true;
            this.SystemFault_tb.Location = new System.Drawing.Point(216, 42);
            this.SystemFault_tb.Name = "SystemFault_tb";
            this.SystemFault_tb.Size = new System.Drawing.Size(83, 16);
            this.SystemFault_tb.TabIndex = 97;
            this.SystemFault_tb.Text = "System Fault";
            this.SystemFault_tb.UseVisualStyleBackColor = true;
            // 
            // fullsearch_cb
            // 
            this.fullsearch_cb.AutoSize = true;
            this.fullsearch_cb.Location = new System.Drawing.Point(479, 157);
            this.fullsearch_cb.Name = "fullsearch_cb";
            this.fullsearch_cb.Size = new System.Drawing.Size(68, 16);
            this.fullsearch_cb.TabIndex = 96;
            this.fullsearch_cb.Text = "0xffffffff";
            this.fullsearch_cb.UseVisualStyleBackColor = true;
            // 
            // J1939_cb
            // 
            this.J1939_cb.AutoSize = true;
            this.J1939_cb.Location = new System.Drawing.Point(216, 20);
            this.J1939_cb.Name = "J1939_cb";
            this.J1939_cb.Size = new System.Drawing.Size(52, 16);
            this.J1939_cb.TabIndex = 98;
            this.J1939_cb.Text = "J1939";
            this.J1939_cb.UseVisualStyleBackColor = true;
            // 
            // Search_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 531);
            this.Controls.Add(this.fullsearch_cb);
            this.Controls.Add(this.Condition_gb);
            this.Controls.Add(this.textBox_v_index);
            this.Controls.Add(this.label_v_index);
            this.Controls.Add(this.textBox_a_index);
            this.Controls.Add(this.label_a_index);
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
            this.Controls.Add(this.label17);
            this.Controls.Add(this.Minute_lat1);
            this.Controls.Add(this.Second_lat1);
            this.Controls.Add(this.Degree_lon2);
            this.Controls.Add(this.Minute_lon2);
            this.Controls.Add(this.Second_lon2);
            this.Controls.Add(this.Minute_lat2);
            this.Controls.Add(this.Second_lat2);
            this.Controls.Add(this.Degree_lat2);
            this.Controls.Add(this.Degree_lat1);
            this.Controls.Add(this.Second_lon1);
            this.Controls.Add(this.Minute_lon1);
            this.Controls.Add(this.Degree_lon1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Stopbtn);
            this.Controls.Add(this.Startbtn);
            this.Controls.Add(this.EventEndTime_Picker);
            this.Controls.Add(this.lable_EventEndTime);
            this.Controls.Add(this.lable_EventStartTime);
            this.Controls.Add(this.EventStartTime_Picker);
            this.Controls.Add(this.listView1);
            this.Name = "Search_Form";
            this.Text = "EventSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.On_EventSearchClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Condition_gb.ResumeLayout(false);
            this.Condition_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader CH;
        private System.Windows.Forms.ColumnHeader StartTime;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.DateTimePicker EventStartTime_Picker;
        private System.Windows.Forms.Label lable_EventStartTime;
        private System.Windows.Forms.Label lable_EventEndTime;
        private System.Windows.Forms.DateTimePicker EventEndTime_Picker;
        private System.Windows.Forms.Button Startbtn;
        private System.Windows.Forms.Button Stopbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Camera_cbv1;
        private System.Windows.Forms.CheckBox Camera_cbv2;
        private System.Windows.Forms.CheckBox Camera_cbv3;
        private System.Windows.Forms.CheckBox Camera_cbv4;
        private System.Windows.Forms.CheckBox Power_on_cb;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader EndTime;
        private System.Windows.Forms.ColumnHeader Lon;
        private System.Windows.Forms.ColumnHeader Lat;
        private System.Windows.Forms.ColumnHeader Speed;
        private System.Windows.Forms.ColumnHeader Gravity;
        private System.Windows.Forms.ColumnHeader BlockID;
        private System.Windows.Forms.ColumnHeader Direction;
        private System.Windows.Forms.ColumnHeader Lat_sn;
        private System.Windows.Forms.ColumnHeader Lon_ew;
        private System.Windows.Forms.ColumnHeader Priority;
        private System.Windows.Forms.ColumnHeader a_index;
        private System.Windows.Forms.ColumnHeader v_index;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox LON2_EW;
        private System.Windows.Forms.ComboBox LAT2_SN;
        private System.Windows.Forms.ComboBox LAT1_SN;
        private System.Windows.Forms.ComboBox LON1_EW;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Minute_lat1;
        private System.Windows.Forms.TextBox Second_lat1;
        private System.Windows.Forms.TextBox Degree_lon2;
        private System.Windows.Forms.TextBox Minute_lon2;
        private System.Windows.Forms.TextBox Second_lon2;
        private System.Windows.Forms.TextBox Minute_lat2;
        private System.Windows.Forms.TextBox Second_lat2;
        private System.Windows.Forms.TextBox Degree_lat2;
        private System.Windows.Forms.TextBox Degree_lat1;
        private System.Windows.Forms.TextBox Second_lon1;
        private System.Windows.Forms.TextBox Minute_lon1;
        private System.Windows.Forms.TextBox Degree_lon1;
        private System.Windows.Forms.Label label_a_index;
        private System.Windows.Forms.TextBox textBox_a_index;
        private System.Windows.Forms.TextBox textBox_v_index;
        private System.Windows.Forms.Label label_v_index;
        private System.Windows.Forms.CheckBox GS_Impact_cb;
        private System.Windows.Forms.CheckBox GS_Accel_cb;
        private System.Windows.Forms.CheckBox Camera_cbv11;
        private System.Windows.Forms.CheckBox Camera_cbv5;
        private System.Windows.Forms.CheckBox Camera_cbv12;
        private System.Windows.Forms.CheckBox Camera_cbv7;
        private System.Windows.Forms.CheckBox Camera_cbv6;
        private System.Windows.Forms.CheckBox Camera_cbv8;
        private System.Windows.Forms.CheckBox Camera_cbv9;
        private System.Windows.Forms.CheckBox Camera_cbv10;
        private System.Windows.Forms.ColumnHeader PreAlarmTime;
        private System.Windows.Forms.ColumnHeader PostAlarmTime;
        private System.Windows.Forms.CheckBox Alarm_cb;
        private System.Windows.Forms.CheckBox Vloss_cb;
        private System.Windows.Forms.GroupBox Condition_gb;
        private System.Windows.Forms.ColumnHeader TimeZone;
        private System.Windows.Forms.ColumnHeader DST;
        private System.Windows.Forms.ColumnHeader ChMap;
        private System.Windows.Forms.CheckBox fullsearch_cb;
        private System.Windows.Forms.CheckBox SystemFault_tb;
        private System.Windows.Forms.ColumnHeader eventName;
        private System.Windows.Forms.CheckBox J1939_cb;

    }
}