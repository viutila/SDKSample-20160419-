namespace UTC_MV_view
{
    partial class Gsensor_Form
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
            this.GsensorEndTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.lable_EventEndTime = new System.Windows.Forms.Label();
            this.lable_EventStartTime = new System.Windows.Forms.Label();
            this.GsensorStartTime_Picker = new System.Windows.Forms.DateTimePicker();
            this.SearchMode = new System.Windows.Forms.Label();
            this.Valuelab = new System.Windows.Forms.Label();
            this.Searchmode_cb = new System.Windows.Forms.ComboBox();
            this.ValueX_txt = new System.Windows.Forms.TextBox();
            this.ValueY_txt = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.No = new System.Windows.Forms.ColumnHeader();
            this.Starttime_list = new System.Windows.Forms.ColumnHeader();
            this.Value_list = new System.Windows.Forms.ColumnHeader();
            this.Startgsensor_btn = new System.Windows.Forms.Button();
            this.Stopgsensor_btn = new System.Windows.Forms.Button();
            this.ValueZ_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GsensorEndTime_Picker
            // 
            this.GsensorEndTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.GsensorEndTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.GsensorEndTime_Picker.Location = new System.Drawing.Point(82, 61);
            this.GsensorEndTime_Picker.Name = "GsensorEndTime_Picker";
            this.GsensorEndTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.GsensorEndTime_Picker.TabIndex = 8;
            // 
            // lable_EventEndTime
            // 
            this.lable_EventEndTime.AutoSize = true;
            this.lable_EventEndTime.Location = new System.Drawing.Point(28, 66);
            this.lable_EventEndTime.Name = "lable_EventEndTime";
            this.lable_EventEndTime.Size = new System.Drawing.Size(48, 12);
            this.lable_EventEndTime.TabIndex = 7;
            this.lable_EventEndTime.Text = "EndTime";
            // 
            // lable_EventStartTime
            // 
            this.lable_EventStartTime.AutoSize = true;
            this.lable_EventStartTime.Location = new System.Drawing.Point(26, 20);
            this.lable_EventStartTime.Name = "lable_EventStartTime";
            this.lable_EventStartTime.Size = new System.Drawing.Size(50, 12);
            this.lable_EventStartTime.TabIndex = 6;
            this.lable_EventStartTime.Text = "StartTime";
            // 
            // GsensorStartTime_Picker
            // 
            this.GsensorStartTime_Picker.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.GsensorStartTime_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.GsensorStartTime_Picker.Location = new System.Drawing.Point(82, 15);
            this.GsensorStartTime_Picker.Name = "GsensorStartTime_Picker";
            this.GsensorStartTime_Picker.Size = new System.Drawing.Size(167, 22);
            this.GsensorStartTime_Picker.TabIndex = 5;
            // 
            // SearchMode
            // 
            this.SearchMode.AutoSize = true;
            this.SearchMode.Location = new System.Drawing.Point(273, 20);
            this.SearchMode.Name = "SearchMode";
            this.SearchMode.Size = new System.Drawing.Size(66, 12);
            this.SearchMode.TabIndex = 9;
            this.SearchMode.Text = "Search Mode";
            // 
            // Valuelab
            // 
            this.Valuelab.AutoSize = true;
            this.Valuelab.Location = new System.Drawing.Point(307, 46);
            this.Valuelab.Name = "Valuelab";
            this.Valuelab.Size = new System.Drawing.Size(32, 12);
            this.Valuelab.TabIndex = 10;
            this.Valuelab.Text = "Value";
            // 
            // Searchmode_cb
            // 
            this.Searchmode_cb.FormattingEnabled = true;
            this.Searchmode_cb.Items.AddRange(new object[] {
            "Less Than",
            "More Than",
            "Inside Range",
            "Outside Range"});
            this.Searchmode_cb.Location = new System.Drawing.Point(345, 17);
            this.Searchmode_cb.Name = "Searchmode_cb";
            this.Searchmode_cb.Size = new System.Drawing.Size(136, 20);
            this.Searchmode_cb.TabIndex = 11;
            this.Searchmode_cb.SelectedIndexChanged += new System.EventHandler(this.Searchmode_cb_SelectedIndexChanged);
            // 
            // ValueX_txt
            // 
            this.ValueX_txt.Location = new System.Drawing.Point(345, 43);
            this.ValueX_txt.MaxLength = 3;
            this.ValueX_txt.Name = "ValueX_txt";
            this.ValueX_txt.Size = new System.Drawing.Size(51, 22);
            this.ValueX_txt.TabIndex = 12;
            this.ValueX_txt.Text = "5";
            // 
            // ValueY_txt
            // 
            this.ValueY_txt.Location = new System.Drawing.Point(345, 71);
            this.ValueY_txt.MaxLength = 3;
            this.ValueY_txt.Name = "ValueY_txt";
            this.ValueY_txt.Size = new System.Drawing.Size(51, 22);
            this.ValueY_txt.TabIndex = 13;
            this.ValueY_txt.Text = "15";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Starttime_list,
            this.Value_list});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(28, 142);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(453, 270);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "No";
            // 
            // Starttime_list
            // 
            this.Starttime_list.Text = "Start Time";
            this.Starttime_list.Width = 223;
            // 
            // Value_list
            // 
            this.Value_list.Text = "Value";
            this.Value_list.Width = 222;
            // 
            // Startgsensor_btn
            // 
            this.Startgsensor_btn.Location = new System.Drawing.Point(51, 100);
            this.Startgsensor_btn.Name = "Startgsensor_btn";
            this.Startgsensor_btn.Size = new System.Drawing.Size(68, 26);
            this.Startgsensor_btn.TabIndex = 16;
            this.Startgsensor_btn.Text = "Start";
            this.Startgsensor_btn.UseVisualStyleBackColor = true;
            this.Startgsensor_btn.Click += new System.EventHandler(this.Startgsensor_btn_Click);
            // 
            // Stopgsensor_btn
            // 
            this.Stopgsensor_btn.Location = new System.Drawing.Point(161, 100);
            this.Stopgsensor_btn.Name = "Stopgsensor_btn";
            this.Stopgsensor_btn.Size = new System.Drawing.Size(68, 26);
            this.Stopgsensor_btn.TabIndex = 17;
            this.Stopgsensor_btn.Text = "Stop";
            this.Stopgsensor_btn.UseVisualStyleBackColor = true;
            this.Stopgsensor_btn.Click += new System.EventHandler(this.Stopgsensor_btn_Click);
            // 
            // ValueZ_txt
            // 
            this.ValueZ_txt.Location = new System.Drawing.Point(345, 99);
            this.ValueZ_txt.MaxLength = 3;
            this.ValueZ_txt.Name = "ValueZ_txt";
            this.ValueZ_txt.Size = new System.Drawing.Size(51, 22);
            this.ValueZ_txt.TabIndex = 18;
            this.ValueZ_txt.Text = "5";
            // 
            // Gsensor_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 439);
            this.Controls.Add(this.ValueZ_txt);
            this.Controls.Add(this.Startgsensor_btn);
            this.Controls.Add(this.Stopgsensor_btn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ValueY_txt);
            this.Controls.Add(this.ValueX_txt);
            this.Controls.Add(this.Searchmode_cb);
            this.Controls.Add(this.Valuelab);
            this.Controls.Add(this.SearchMode);
            this.Controls.Add(this.GsensorEndTime_Picker);
            this.Controls.Add(this.lable_EventEndTime);
            this.Controls.Add(this.lable_EventStartTime);
            this.Controls.Add(this.GsensorStartTime_Picker);
            this.Name = "Gsensor_Form";
            this.Text = "G-sensor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.On_GSensorSearchClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker GsensorEndTime_Picker;
        private System.Windows.Forms.Label lable_EventEndTime;
        private System.Windows.Forms.Label lable_EventStartTime;
        private System.Windows.Forms.DateTimePicker GsensorStartTime_Picker;
        private System.Windows.Forms.Label SearchMode;
        private System.Windows.Forms.Label Valuelab;
        private System.Windows.Forms.ComboBox Searchmode_cb;
        private System.Windows.Forms.TextBox ValueX_txt;
        private System.Windows.Forms.TextBox ValueY_txt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Starttime_list;
        private System.Windows.Forms.ColumnHeader Value_list;
        private System.Windows.Forms.Button Startgsensor_btn;
        private System.Windows.Forms.Button Stopgsensor_btn;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.TextBox ValueZ_txt;
    }
}