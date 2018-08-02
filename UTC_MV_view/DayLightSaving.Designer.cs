namespace UTC_MV_view
{
    partial class DayLightSaving
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
            this.SMonth = new System.Windows.Forms.TextBox();
            this.SWeek = new System.Windows.Forms.TextBox();
            this.SDay = new System.Windows.Forms.TextBox();
            this.EMonth = new System.Windows.Forms.TextBox();
            this.EWeek = new System.Windows.Forms.TextBox();
            this.EDay = new System.Windows.Forms.TextBox();
            this.SHour = new System.Windows.Forms.TextBox();
            this.SMinute = new System.Windows.Forms.TextBox();
            this.EHour = new System.Windows.Forms.TextBox();
            this.EMinute = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SWeeklabel = new System.Windows.Forms.Label();
            this.SDaylabel = new System.Windows.Forms.Label();
            this.SHourlable = new System.Windows.Forms.Label();
            this.SMinutelabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SMonth
            // 
            this.SMonth.Location = new System.Drawing.Point(51, 21);
            this.SMonth.Name = "SMonth";
            this.SMonth.Size = new System.Drawing.Size(50, 22);
            this.SMonth.TabIndex = 0;
            // 
            // SWeek
            // 
            this.SWeek.Location = new System.Drawing.Point(167, 21);
            this.SWeek.Name = "SWeek";
            this.SWeek.Size = new System.Drawing.Size(50, 22);
            this.SWeek.TabIndex = 1;
            // 
            // SDay
            // 
            this.SDay.Location = new System.Drawing.Point(299, 21);
            this.SDay.Name = "SDay";
            this.SDay.Size = new System.Drawing.Size(50, 22);
            this.SDay.TabIndex = 2;
            // 
            // EMonth
            // 
            this.EMonth.Location = new System.Drawing.Point(51, 24);
            this.EMonth.Name = "EMonth";
            this.EMonth.Size = new System.Drawing.Size(50, 22);
            this.EMonth.TabIndex = 3;
            // 
            // EWeek
            // 
            this.EWeek.Location = new System.Drawing.Point(171, 24);
            this.EWeek.Name = "EWeek";
            this.EWeek.Size = new System.Drawing.Size(49, 22);
            this.EWeek.TabIndex = 4;
            // 
            // EDay
            // 
            this.EDay.Location = new System.Drawing.Point(300, 24);
            this.EDay.Name = "EDay";
            this.EDay.Size = new System.Drawing.Size(49, 22);
            this.EDay.TabIndex = 5;
            // 
            // SHour
            // 
            this.SHour.Location = new System.Drawing.Point(51, 56);
            this.SHour.Name = "SHour";
            this.SHour.Size = new System.Drawing.Size(50, 22);
            this.SHour.TabIndex = 6;
            // 
            // SMinute
            // 
            this.SMinute.Location = new System.Drawing.Point(167, 56);
            this.SMinute.Name = "SMinute";
            this.SMinute.Size = new System.Drawing.Size(50, 22);
            this.SMinute.TabIndex = 7;
            // 
            // EHour
            // 
            this.EHour.Location = new System.Drawing.Point(51, 57);
            this.EHour.Name = "EHour";
            this.EHour.Size = new System.Drawing.Size(50, 22);
            this.EHour.TabIndex = 8;
            // 
            // EMinute
            // 
            this.EMinute.Location = new System.Drawing.Point(171, 57);
            this.EMinute.Name = "EMinute";
            this.EMinute.Size = new System.Drawing.Size(50, 22);
            this.EMinute.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SMinutelabel);
            this.groupBox1.Controls.Add(this.SHourlable);
            this.groupBox1.Controls.Add(this.SDaylabel);
            this.groupBox1.Controls.Add(this.SWeeklabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SMinute);
            this.groupBox1.Controls.Add(this.SHour);
            this.groupBox1.Controls.Add(this.SDay);
            this.groupBox1.Controls.Add(this.SWeek);
            this.groupBox1.Controls.Add(this.SMonth);
            this.groupBox1.Location = new System.Drawing.Point(17, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 109);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.EMinute);
            this.groupBox2.Controls.Add(this.EHour);
            this.groupBox2.Controls.Add(this.EDay);
            this.groupBox2.Controls.Add(this.EWeek);
            this.groupBox2.Controls.Add(this.EMonth);
            this.groupBox2.Location = new System.Drawing.Point(17, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 110);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Month:";
            // 
            // SWeeklabel
            // 
            this.SWeeklabel.AutoSize = true;
            this.SWeeklabel.Location = new System.Drawing.Point(107, 24);
            this.SWeeklabel.Name = "SWeeklabel";
            this.SWeeklabel.Size = new System.Drawing.Size(58, 12);
            this.SWeeklabel.TabIndex = 9;
            this.SWeeklabel.Text = "Week(nth):";
            // 
            // SDaylabel
            // 
            this.SDaylabel.AutoSize = true;
            this.SDaylabel.Location = new System.Drawing.Point(223, 24);
            this.SDaylabel.Name = "SDaylabel";
            this.SDaylabel.Size = new System.Drawing.Size(70, 12);
            this.SDaylabel.TabIndex = 10;
            this.SDaylabel.Text = "Day of Week:";
            // 
            // SHourlable
            // 
            this.SHourlable.AutoSize = true;
            this.SHourlable.Location = new System.Drawing.Point(6, 56);
            this.SHourlable.Name = "SHourlable";
            this.SHourlable.Size = new System.Drawing.Size(32, 12);
            this.SHourlable.TabIndex = 11;
            this.SHourlable.Text = "Hour:";
            // 
            // SMinutelabel
            // 
            this.SMinutelabel.AutoSize = true;
            this.SMinutelabel.Location = new System.Drawing.Point(122, 59);
            this.SMinutelabel.Name = "SMinutelabel";
            this.SMinutelabel.Size = new System.Drawing.Size(41, 12);
            this.SMinutelabel.TabIndex = 12;
            this.SMinutelabel.Text = "Minute:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Month:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "Week(nth):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "Day of Week:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "Hour:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(122, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "Minute:";
            // 
            // DayLightSaving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 266);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DayLightSaving";
            this.Text = "DayLightSaving";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox SMonth;
        private System.Windows.Forms.TextBox SWeek;
        private System.Windows.Forms.TextBox SDay;
        private System.Windows.Forms.TextBox EMonth;
        private System.Windows.Forms.TextBox EWeek;
        private System.Windows.Forms.TextBox EDay;
        private System.Windows.Forms.TextBox SHour;
        private System.Windows.Forms.TextBox SMinute;
        private System.Windows.Forms.TextBox EHour;
        private System.Windows.Forms.TextBox EMinute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label SMinutelabel;
        private System.Windows.Forms.Label SHourlable;
        private System.Windows.Forms.Label SDaylabel;
        private System.Windows.Forms.Label SWeeklabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}