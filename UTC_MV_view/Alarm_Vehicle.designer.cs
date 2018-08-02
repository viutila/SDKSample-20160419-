namespace UTC_MV_view
{
    partial class Alarm_Vehicle
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
            this.Start_alarm_vehicleID = new System.Windows.Forms.Button();
            this.sel_type = new System.Windows.Forms.ComboBox();
            this.table_listView = new System.Windows.Forms.ListView();
            this.No = new System.Windows.Forms.ColumnHeader();
            this.Event_Name = new System.Windows.Forms.ColumnHeader();
            this.start_time = new System.Windows.Forms.ColumnHeader();
            this.end_time = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // Start_alarm_vehicleID
            // 
            this.Start_alarm_vehicleID.Location = new System.Drawing.Point(23, 30);
            this.Start_alarm_vehicleID.Name = "Start_alarm_vehicleID";
            this.Start_alarm_vehicleID.Size = new System.Drawing.Size(64, 24);
            this.Start_alarm_vehicleID.TabIndex = 0;
            this.Start_alarm_vehicleID.Text = "Start";
            this.Start_alarm_vehicleID.UseVisualStyleBackColor = true;
            this.Start_alarm_vehicleID.Click += new System.EventHandler(this.Start_alarm_vehicleID_Click);
            // 
            // sel_type
            // 
            this.sel_type.FormattingEnabled = true;
            this.sel_type.Items.AddRange(new object[] {
            "Alarm",
            "VehicleID",
            "DayLightSaving"});
            this.sel_type.Location = new System.Drawing.Point(167, 30);
            this.sel_type.Name = "sel_type";
            this.sel_type.Size = new System.Drawing.Size(83, 20);
            this.sel_type.TabIndex = 1;
            // 
            // table_listView
            // 
            this.table_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Event_Name,
            this.start_time,
            this.end_time});
            this.table_listView.Location = new System.Drawing.Point(23, 88);
            this.table_listView.Name = "table_listView";
            this.table_listView.Size = new System.Drawing.Size(405, 286);
            this.table_listView.TabIndex = 2;
            this.table_listView.UseCompatibleStateImageBehavior = false;
            this.table_listView.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 44;
            // 
            // Event_Name
            // 
            this.Event_Name.Text = "Name";
            this.Event_Name.Width = 98;
            // 
            // start_time
            // 
            this.start_time.Text = "start_time";
            this.start_time.Width = 126;
            // 
            // end_time
            // 
            this.end_time.Text = "end_time";
            this.end_time.Width = 115;
            // 
            // Alarm_Vehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 402);
            this.Controls.Add(this.table_listView);
            this.Controls.Add(this.sel_type);
            this.Controls.Add(this.Start_alarm_vehicleID);
            this.Name = "Alarm_Vehicle";
            this.Text = "Alarm_Vehicle";
            this.Load += new System.EventHandler(this.Alarm_Vehicle_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnAlarm_VehicleID_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_alarm_vehicleID;
        private System.Windows.Forms.ComboBox sel_type;
        private System.Windows.Forms.ListView table_listView;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Event_Name;
        private System.Windows.Forms.ColumnHeader start_time;
        private System.Windows.Forms.ColumnHeader end_time;
    }
}