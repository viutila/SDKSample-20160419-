namespace UTC_MV_view
{
    partial class DiskMap
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
            this.DiskMapEndTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.lable_DiskMapEndTime = new System.Windows.Forms.Label();
            this.lable_DiskMaptStartTime = new System.Windows.Forms.Label();
            this.DiskMapStartTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.Power_on_cb = new System.Windows.Forms.CheckBox();
            this.StopDiskMap = new System.Windows.Forms.Button();
            this.StartDiskMap = new System.Windows.Forms.Button();
            this.DiskMapResult = new System.Windows.Forms.ListView();
            this.No = new System.Windows.Forms.ColumnHeader();
            this.StartTime = new System.Windows.Forms.ColumnHeader();
            this.EndTime = new System.Windows.Forms.ColumnHeader();
            this.Rec_Status = new System.Windows.Forms.ColumnHeader();
            this.Ch = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.Selected_Scale = new System.Windows.Forms.ComboBox();
            this.SegmentResult = new System.Windows.Forms.ListView();
            this.segment_no = new System.Windows.Forms.ColumnHeader();
            this.ChMap = new System.Windows.Forms.ColumnHeader();
            this.segment_CH = new System.Windows.Forms.ColumnHeader();
            this.segment_type = new System.Windows.Forms.ColumnHeader();
            this.segment_starttime = new System.Windows.Forms.ColumnHeader();
            this.segment_endtime = new System.Windows.Forms.ColumnHeader();
            this.segment_Lat_SN = new System.Windows.Forms.ColumnHeader();
            this.segment_Lat = new System.Windows.Forms.ColumnHeader();
            this.segment_Lon_EW = new System.Windows.Forms.ColumnHeader();
            this.segment_Lon = new System.Windows.Forms.ColumnHeader();
            this.segment_speed = new System.Windows.Forms.ColumnHeader();
            this.segment_Grarity = new System.Windows.Forms.ColumnHeader();
            this.segment_BlockID = new System.Windows.Forms.ColumnHeader();
            this.segment_Direction = new System.Windows.Forms.ColumnHeader();
            this.segment_Priority = new System.Windows.Forms.ColumnHeader();
            this.segment_A_Index = new System.Windows.Forms.ColumnHeader();
            this.segment_V_Index = new System.Windows.Forms.ColumnHeader();
            this.PreAlarmTime = new System.Windows.Forms.ColumnHeader();
            this.PostAlarmTime = new System.Windows.Forms.ColumnHeader();
            this.TimeZone = new System.Windows.Forms.ColumnHeader();
            this.DayLightSaving = new System.Windows.Forms.ColumnHeader();
            this.SegmentEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SegmentStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Segmentbtn = new System.Windows.Forms.Button();
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
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
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
            this.Select_ch = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.SegmentStopbtn = new System.Windows.Forms.Button();
            this.Alarm_cb = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Vloss_cb = new System.Windows.Forms.CheckBox();
            this.SeleCamera_ComboBox = new System.Windows.Forms.ComboBox();
            this.SeleCamera_tb = new System.Windows.Forms.Label();
            this.fullsearch_cb = new System.Windows.Forms.CheckBox();
            this.SystemFault_tb = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DiskMapEndTime_Picker
            // 
            this.DiskMapEndTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.DiskMapEndTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DiskMapEndTime_Picker.Location = new System.Drawing.Point(66, 87);
            this.DiskMapEndTime_Picker.Name = "DiskMapEndTime_Picker";
            this.DiskMapEndTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.DiskMapEndTime_Picker.TabIndex = 8;
            // 
            // lable_DiskMapEndTime
            // 
            this.lable_DiskMapEndTime.AutoSize = true;
            this.lable_DiskMapEndTime.Location = new System.Drawing.Point(12, 92);
            this.lable_DiskMapEndTime.Name = "lable_DiskMapEndTime";
            this.lable_DiskMapEndTime.Size = new System.Drawing.Size(48, 12);
            this.lable_DiskMapEndTime.TabIndex = 7;
            this.lable_DiskMapEndTime.Text = "EndTime";
            // 
            // lable_DiskMaptStartTime
            // 
            this.lable_DiskMaptStartTime.AutoSize = true;
            this.lable_DiskMaptStartTime.Location = new System.Drawing.Point(12, 37);
            this.lable_DiskMaptStartTime.Name = "lable_DiskMaptStartTime";
            this.lable_DiskMaptStartTime.Size = new System.Drawing.Size(50, 12);
            this.lable_DiskMaptStartTime.TabIndex = 6;
            this.lable_DiskMaptStartTime.Text = "StartTime";
            // 
            // DiskMapStartTime_Picker
            // 
            this.DiskMapStartTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.DiskMapStartTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DiskMapStartTime_Picker.Location = new System.Drawing.Point(68, 32);
            this.DiskMapStartTime_Picker.Name = "DiskMapStartTime_Picker";
            this.DiskMapStartTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.DiskMapStartTime_Picker.TabIndex = 5;
            // 
            // Power_on_cb
            // 
            this.Power_on_cb.AutoSize = true;
            this.Power_on_cb.Checked = true;
            this.Power_on_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Power_on_cb.Location = new System.Drawing.Point(148, 19);
            this.Power_on_cb.Name = "Power_on_cb";
            this.Power_on_cb.Size = new System.Drawing.Size(70, 16);
            this.Power_on_cb.TabIndex = 32;
            this.Power_on_cb.Text = "Power On";
            this.Power_on_cb.UseVisualStyleBackColor = true;
            // 
            // StopDiskMap
            // 
            this.StopDiskMap.Location = new System.Drawing.Point(124, 128);
            this.StopDiskMap.Name = "StopDiskMap";
            this.StopDiskMap.Size = new System.Drawing.Size(68, 26);
            this.StopDiskMap.TabIndex = 31;
            this.StopDiskMap.Text = "Stop";
            this.StopDiskMap.UseVisualStyleBackColor = true;
            this.StopDiskMap.Click += new System.EventHandler(this.StopDiskMap_Click);
            // 
            // StartDiskMap
            // 
            this.StartDiskMap.Location = new System.Drawing.Point(14, 128);
            this.StartDiskMap.Name = "StartDiskMap";
            this.StartDiskMap.Size = new System.Drawing.Size(68, 26);
            this.StartDiskMap.TabIndex = 30;
            this.StartDiskMap.Text = "Start";
            this.StartDiskMap.UseVisualStyleBackColor = true;
            this.StartDiskMap.Click += new System.EventHandler(this.StartDiskMap_Click);
            // 
            // DiskMapResult
            // 
            this.DiskMapResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.StartTime,
            this.EndTime,
            this.Rec_Status,
            this.Ch});
            this.DiskMapResult.FullRowSelect = true;
            this.DiskMapResult.HideSelection = false;
            this.DiskMapResult.Location = new System.Drawing.Point(7, 160);
            this.DiskMapResult.Name = "DiskMapResult";
            this.DiskMapResult.Size = new System.Drawing.Size(464, 324);
            this.DiskMapResult.TabIndex = 33;
            this.DiskMapResult.UseCompatibleStateImageBehavior = false;
            this.DiskMapResult.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 46;
            // 
            // StartTime
            // 
            this.StartTime.Text = "StartTime";
            this.StartTime.Width = 158;
            // 
            // EndTime
            // 
            this.EndTime.Text = "EndTime";
            this.EndTime.Width = 129;
            // 
            // Rec_Status
            // 
            this.Rec_Status.Text = "Rec_Status";
            this.Rec_Status.Width = 86;
            // 
            // Ch
            // 
            this.Ch.Text = "CH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "Scale: ";
            // 
            // Selected_Scale
            // 
            this.Selected_Scale.FormattingEnabled = true;
            this.Selected_Scale.Items.AddRange(new object[] {
            "Year",
            "Month",
            "Day",
            "Hour"});
            this.Selected_Scale.Location = new System.Drawing.Point(384, 34);
            this.Selected_Scale.Name = "Selected_Scale";
            this.Selected_Scale.Size = new System.Drawing.Size(61, 20);
            this.Selected_Scale.TabIndex = 36;
            // 
            // SegmentResult
            // 
            this.SegmentResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.segment_no,
            this.ChMap,
            this.segment_CH,
            this.segment_type,
            this.segment_starttime,
            this.segment_endtime,
            this.segment_Lat_SN,
            this.segment_Lat,
            this.segment_Lon_EW,
            this.segment_Lon,
            this.segment_speed,
            this.segment_Grarity,
            this.segment_BlockID,
            this.segment_Direction,
            this.segment_Priority,
            this.segment_A_Index,
            this.segment_V_Index,
            this.PreAlarmTime,
            this.PostAlarmTime,
            this.TimeZone,
            this.DayLightSaving});
            this.SegmentResult.FullRowSelect = true;
            this.SegmentResult.HideSelection = false;
            this.SegmentResult.Location = new System.Drawing.Point(493, 160);
            this.SegmentResult.Name = "SegmentResult";
            this.SegmentResult.Size = new System.Drawing.Size(727, 324);
            this.SegmentResult.TabIndex = 48;
            this.SegmentResult.UseCompatibleStateImageBehavior = false;
            this.SegmentResult.View = System.Windows.Forms.View.Details;
            // 
            // segment_no
            // 
            this.segment_no.Text = "No";
            this.segment_no.Width = 46;
            // 
            // ChMap
            // 
            this.ChMap.Text = "ChMap";
            // 
            // segment_CH
            // 
            this.segment_CH.Text = "CH/Input";
            // 
            // segment_type
            // 
            this.segment_type.Text = "Type";
            this.segment_type.Width = 49;
            // 
            // segment_starttime
            // 
            this.segment_starttime.Text = "StartTime";
            this.segment_starttime.Width = 112;
            // 
            // segment_endtime
            // 
            this.segment_endtime.Text = "EndTime";
            this.segment_endtime.Width = 153;
            // 
            // segment_Lat_SN
            // 
            this.segment_Lat_SN.Text = "Lat_SN";
            // 
            // segment_Lat
            // 
            this.segment_Lat.Text = "Lat";
            // 
            // segment_Lon_EW
            // 
            this.segment_Lon_EW.Text = "Lon_EW";
            // 
            // segment_Lon
            // 
            this.segment_Lon.Text = "Lon";
            // 
            // segment_speed
            // 
            this.segment_speed.Text = "speed";
            // 
            // segment_Grarity
            // 
            this.segment_Grarity.Text = "Grarity";
            // 
            // segment_BlockID
            // 
            this.segment_BlockID.Text = "BlockID";
            // 
            // segment_Direction
            // 
            this.segment_Direction.Text = "Direction";
            // 
            // segment_Priority
            // 
            this.segment_Priority.Text = "Priority";
            // 
            // segment_A_Index
            // 
            this.segment_A_Index.Text = "A_Index";
            // 
            // segment_V_Index
            // 
            this.segment_V_Index.Text = "V_Index";
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
            // 
            // DayLightSaving
            // 
            this.DayLightSaving.Text = "DayLightSaving";
            // 
            // SegmentEndTimePicker
            // 
            this.SegmentEndTimePicker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.SegmentEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SegmentEndTimePicker.Location = new System.Drawing.Point(1084, 79);
            this.SegmentEndTimePicker.Name = "SegmentEndTimePicker";
            this.SegmentEndTimePicker.Size = new System.Drawing.Size(137, 22);
            this.SegmentEndTimePicker.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1028, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "EndTime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1028, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 45;
            this.label4.Text = "StartTime";
            // 
            // SegmentStartTimePicker
            // 
            this.SegmentStartTimePicker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.SegmentStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SegmentStartTimePicker.Location = new System.Drawing.Point(1084, 24);
            this.SegmentStartTimePicker.Name = "SegmentStartTimePicker";
            this.SegmentStartTimePicker.Size = new System.Drawing.Size(137, 22);
            this.SegmentStartTimePicker.TabIndex = 44;
            // 
            // Segmentbtn
            // 
            this.Segmentbtn.Location = new System.Drawing.Point(1030, 113);
            this.Segmentbtn.Name = "Segmentbtn";
            this.Segmentbtn.Size = new System.Drawing.Size(75, 23);
            this.Segmentbtn.TabIndex = 43;
            this.Segmentbtn.Text = "Segment";
            this.Segmentbtn.UseVisualStyleBackColor = true;
            this.Segmentbtn.Click += new System.EventHandler(this.Segmentbtn_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1012, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 12);
            this.label16.TabIndex = 86;
            this.label16.Text = "\"";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1012, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 12);
            this.label15.TabIndex = 85;
            this.label15.Text = "\"";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1012, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 12);
            this.label14.TabIndex = 84;
            this.label14.Text = "\"";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(958, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(7, 12);
            this.label13.TabIndex = 83;
            this.label13.Text = "\'";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(958, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(7, 12);
            this.label12.TabIndex = 82;
            this.label12.Text = "\'";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(958, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(7, 12);
            this.label11.TabIndex = 81;
            this.label11.Text = "\'";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(901, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 80;
            this.label10.Text = "o";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(901, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 79;
            this.label9.Text = "o";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(901, 81);
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
            this.LON2_EW.Location = new System.Drawing.Point(814, 109);
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
            this.LAT2_SN.Location = new System.Drawing.Point(814, 81);
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
            this.LAT1_SN.Location = new System.Drawing.Point(814, 25);
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
            this.LON1_EW.Location = new System.Drawing.Point(814, 54);
            this.LON1_EW.Name = "LON1_EW";
            this.LON1_EW.Size = new System.Drawing.Size(40, 20);
            this.LON1_EW.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(901, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 73;
            this.label7.Text = "o";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(958, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(7, 12);
            this.label6.TabIndex = 72;
            this.label6.Text = "\'";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1012, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 12);
            this.label5.TabIndex = 71;
            this.label5.Text = "\"";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(773, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 12);
            this.label17.TabIndex = 70;
            this.label17.Text = "LAT2:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(773, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 12);
            this.label18.TabIndex = 69;
            this.label18.Text = "LON2:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(773, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 12);
            this.label19.TabIndex = 68;
            this.label19.Text = "LAT1:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(772, 56);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 12);
            this.label20.TabIndex = 67;
            this.label20.Text = "LON1:";
            // 
            // Minute_lat1
            // 
            this.Minute_lat1.Location = new System.Drawing.Point(914, 25);
            this.Minute_lat1.Name = "Minute_lat1";
            this.Minute_lat1.Size = new System.Drawing.Size(38, 22);
            this.Minute_lat1.TabIndex = 66;
            this.Minute_lat1.Text = "0";
            // 
            // Second_lat1
            // 
            this.Second_lat1.Location = new System.Drawing.Point(969, 25);
            this.Second_lat1.Name = "Second_lat1";
            this.Second_lat1.Size = new System.Drawing.Size(37, 22);
            this.Second_lat1.TabIndex = 65;
            this.Second_lat1.Text = "0";
            // 
            // Degree_lon2
            // 
            this.Degree_lon2.Location = new System.Drawing.Point(859, 109);
            this.Degree_lon2.Name = "Degree_lon2";
            this.Degree_lon2.Size = new System.Drawing.Size(36, 22);
            this.Degree_lon2.TabIndex = 64;
            this.Degree_lon2.Text = "0";
            // 
            // Minute_lon2
            // 
            this.Minute_lon2.Location = new System.Drawing.Point(914, 109);
            this.Minute_lon2.Name = "Minute_lon2";
            this.Minute_lon2.Size = new System.Drawing.Size(38, 22);
            this.Minute_lon2.TabIndex = 63;
            this.Minute_lon2.Text = "0";
            // 
            // Second_lon2
            // 
            this.Second_lon2.Location = new System.Drawing.Point(969, 109);
            this.Second_lon2.Name = "Second_lon2";
            this.Second_lon2.Size = new System.Drawing.Size(37, 22);
            this.Second_lon2.TabIndex = 62;
            this.Second_lon2.Text = "0";
            // 
            // Minute_lat2
            // 
            this.Minute_lat2.Location = new System.Drawing.Point(914, 81);
            this.Minute_lat2.Name = "Minute_lat2";
            this.Minute_lat2.Size = new System.Drawing.Size(38, 22);
            this.Minute_lat2.TabIndex = 61;
            this.Minute_lat2.Text = "0";
            // 
            // Second_lat2
            // 
            this.Second_lat2.Location = new System.Drawing.Point(969, 81);
            this.Second_lat2.Name = "Second_lat2";
            this.Second_lat2.Size = new System.Drawing.Size(37, 22);
            this.Second_lat2.TabIndex = 60;
            this.Second_lat2.Text = "0";
            // 
            // Degree_lat2
            // 
            this.Degree_lat2.Location = new System.Drawing.Point(859, 81);
            this.Degree_lat2.Name = "Degree_lat2";
            this.Degree_lat2.Size = new System.Drawing.Size(36, 22);
            this.Degree_lat2.TabIndex = 59;
            this.Degree_lat2.Text = "0";
            // 
            // Degree_lat1
            // 
            this.Degree_lat1.Location = new System.Drawing.Point(859, 25);
            this.Degree_lat1.Name = "Degree_lat1";
            this.Degree_lat1.Size = new System.Drawing.Size(36, 22);
            this.Degree_lat1.TabIndex = 58;
            this.Degree_lat1.Text = "0";
            // 
            // Second_lon1
            // 
            this.Second_lon1.Location = new System.Drawing.Point(969, 53);
            this.Second_lon1.MaxLength = 3;
            this.Second_lon1.Name = "Second_lon1";
            this.Second_lon1.Size = new System.Drawing.Size(37, 22);
            this.Second_lon1.TabIndex = 57;
            this.Second_lon1.Text = "0";
            // 
            // Minute_lon1
            // 
            this.Minute_lon1.Location = new System.Drawing.Point(914, 53);
            this.Minute_lon1.MaxLength = 3;
            this.Minute_lon1.Name = "Minute_lon1";
            this.Minute_lon1.Size = new System.Drawing.Size(38, 22);
            this.Minute_lon1.TabIndex = 56;
            this.Minute_lon1.Text = "0";
            // 
            // Degree_lon1
            // 
            this.Degree_lon1.Location = new System.Drawing.Point(859, 53);
            this.Degree_lon1.MaxLength = 3;
            this.Degree_lon1.Name = "Degree_lon1";
            this.Degree_lon1.Size = new System.Drawing.Size(36, 22);
            this.Degree_lon1.TabIndex = 55;
            this.Degree_lon1.Text = "0";
            // 
            // Select_ch
            // 
            this.Select_ch.FormattingEnabled = true;
            this.Select_ch.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.Select_ch.Location = new System.Drawing.Point(291, 34);
            this.Select_ch.Name = "Select_ch";
            this.Select_ch.Size = new System.Drawing.Size(46, 20);
            this.Select_ch.TabIndex = 87;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(241, 37);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 12);
            this.label21.TabIndex = 88;
            this.label21.Text = "channel:";
            // 
            // SegmentStopbtn
            // 
            this.SegmentStopbtn.Location = new System.Drawing.Point(1133, 113);
            this.SegmentStopbtn.Name = "SegmentStopbtn";
            this.SegmentStopbtn.Size = new System.Drawing.Size(75, 22);
            this.SegmentStopbtn.TabIndex = 89;
            this.SegmentStopbtn.Text = "Stop";
            this.SegmentStopbtn.UseVisualStyleBackColor = true;
            this.SegmentStopbtn.Click += new System.EventHandler(this.SegmentStopbtn_Click);
            // 
            // Alarm_cb
            // 
            this.Alarm_cb.AutoSize = true;
            this.Alarm_cb.Checked = true;
            this.Alarm_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Alarm_cb.Location = new System.Drawing.Point(6, 19);
            this.Alarm_cb.Name = "Alarm_cb";
            this.Alarm_cb.Size = new System.Drawing.Size(53, 16);
            this.Alarm_cb.TabIndex = 90;
            this.Alarm_cb.Text = "Alarm";
            this.Alarm_cb.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SystemFault_tb);
            this.groupBox2.Controls.Add(this.Vloss_cb);
            this.groupBox2.Controls.Add(this.Power_on_cb);
            this.groupBox2.Controls.Add(this.Alarm_cb);
            this.groupBox2.Location = new System.Drawing.Point(493, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 69);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condition";
            // 
            // Vloss_cb
            // 
            this.Vloss_cb.AutoSize = true;
            this.Vloss_cb.Checked = true;
            this.Vloss_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Vloss_cb.Location = new System.Drawing.Point(65, 19);
            this.Vloss_cb.Name = "Vloss_cb";
            this.Vloss_cb.Size = new System.Drawing.Size(76, 16);
            this.Vloss_cb.TabIndex = 92;
            this.Vloss_cb.Text = "Video Loss";
            this.Vloss_cb.UseVisualStyleBackColor = true;
            // 
            // SeleCamera_ComboBox
            // 
            this.SeleCamera_ComboBox.FormattingEnabled = true;
            this.SeleCamera_ComboBox.Items.AddRange(new object[] {
            "Channel1",
            "Channel2",
            "Channel3",
            "Channel4",
            "Channel5",
            "Channel6",
            "Channel7",
            "Channel8",
            "SelectAll"});
            this.SeleCamera_ComboBox.Location = new System.Drawing.Point(664, 99);
            this.SeleCamera_ComboBox.Name = "SeleCamera_ComboBox";
            this.SeleCamera_ComboBox.Size = new System.Drawing.Size(103, 20);
            this.SeleCamera_ComboBox.TabIndex = 92;
            // 
            // SeleCamera_tb
            // 
            this.SeleCamera_tb.AutoSize = true;
            this.SeleCamera_tb.Location = new System.Drawing.Point(614, 103);
            this.SeleCamera_tb.Name = "SeleCamera_tb";
            this.SeleCamera_tb.Size = new System.Drawing.Size(44, 12);
            this.SeleCamera_tb.TabIndex = 93;
            this.SeleCamera_tb.Text = "Camera:";
            // 
            // fullsearch_cb
            // 
            this.fullsearch_cb.AutoSize = true;
            this.fullsearch_cb.Location = new System.Drawing.Point(703, 128);
            this.fullsearch_cb.Name = "fullsearch_cb";
            this.fullsearch_cb.Size = new System.Drawing.Size(64, 16);
            this.fullsearch_cb.TabIndex = 94;
            this.fullsearch_cb.Text = "0xfffffff";
            this.fullsearch_cb.UseVisualStyleBackColor = true;
            // 
            // SystemFault_tb
            // 
            this.SystemFault_tb.AutoSize = true;
            this.SystemFault_tb.Location = new System.Drawing.Point(6, 41);
            this.SystemFault_tb.Name = "SystemFault_tb";
            this.SystemFault_tb.Size = new System.Drawing.Size(83, 16);
            this.SystemFault_tb.TabIndex = 93;
            this.SystemFault_tb.Text = "System Fault";
            this.SystemFault_tb.UseVisualStyleBackColor = true;
            // 
            // DiskMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 498);
            this.Controls.Add(this.fullsearch_cb);
            this.Controls.Add(this.SeleCamera_tb);
            this.Controls.Add(this.SeleCamera_ComboBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SegmentStopbtn);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Select_ch);
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
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
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
            this.Controls.Add(this.SegmentResult);
            this.Controls.Add(this.SegmentEndTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SegmentStartTimePicker);
            this.Controls.Add(this.Segmentbtn);
            this.Controls.Add(this.Selected_Scale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DiskMapResult);
            this.Controls.Add(this.StopDiskMap);
            this.Controls.Add(this.StartDiskMap);
            this.Controls.Add(this.DiskMapEndTime_Picker);
            this.Controls.Add(this.lable_DiskMapEndTime);
            this.Controls.Add(this.lable_DiskMaptStartTime);
            this.Controls.Add(this.DiskMapStartTime_Picker);
            this.Name = "DiskMap";
            this.Text = "DiskMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnDiskMap_Closing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DiskMapEndTime_Picker;
        private System.Windows.Forms.Label lable_DiskMapEndTime;
        private System.Windows.Forms.Label lable_DiskMaptStartTime;
        private System.Windows.Forms.DateTimePicker DiskMapStartTime_Picker;
        private System.Windows.Forms.CheckBox Power_on_cb;
        private System.Windows.Forms.Button StopDiskMap;
        private System.Windows.Forms.Button StartDiskMap;
        private System.Windows.Forms.ListView DiskMapResult;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader StartTime;
        private System.Windows.Forms.ColumnHeader Rec_Status;
        private System.Windows.Forms.ColumnHeader EndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Selected_Scale;
        private System.Windows.Forms.ListView SegmentResult;
        private System.Windows.Forms.ColumnHeader segment_no;
        private System.Windows.Forms.ColumnHeader segment_starttime;
        private System.Windows.Forms.ColumnHeader segment_endtime;
        private System.Windows.Forms.ColumnHeader segment_type;
        private System.Windows.Forms.DateTimePicker SegmentEndTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker SegmentStartTimePicker;
        private System.Windows.Forms.Button Segmentbtn;
        private System.Windows.Forms.ColumnHeader segment_CH;
        private System.Windows.Forms.ColumnHeader segment_Lat_SN;
        private System.Windows.Forms.ColumnHeader segment_Lat;
        private System.Windows.Forms.ColumnHeader segment_Lon_EW;
        private System.Windows.Forms.ColumnHeader segment_Lon;
        private System.Windows.Forms.ColumnHeader segment_speed;
        private System.Windows.Forms.ColumnHeader segment_Grarity;
        private System.Windows.Forms.ColumnHeader segment_BlockID;
        private System.Windows.Forms.ColumnHeader segment_Direction;
        private System.Windows.Forms.ColumnHeader segment_Priority;
        private System.Windows.Forms.ColumnHeader segment_A_Index;
        private System.Windows.Forms.ColumnHeader segment_V_Index;
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
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
        private System.Windows.Forms.ColumnHeader Ch;
        private System.Windows.Forms.ComboBox Select_ch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button SegmentStopbtn;
        private System.Windows.Forms.CheckBox Alarm_cb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Vloss_cb;
        private System.Windows.Forms.ColumnHeader PreAlarmTime;
        private System.Windows.Forms.ColumnHeader PostAlarmTime;
        private System.Windows.Forms.ColumnHeader TimeZone;
        private System.Windows.Forms.ColumnHeader DayLightSaving;
        private System.Windows.Forms.ColumnHeader ChMap;
        private System.Windows.Forms.ComboBox SeleCamera_ComboBox;
        private System.Windows.Forms.Label SeleCamera_tb;
        private System.Windows.Forms.CheckBox fullsearch_cb;
        private System.Windows.Forms.CheckBox SystemFault_tb;
    }
}