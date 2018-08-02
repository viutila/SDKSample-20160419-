using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UTC_MV_view
{

    public partial class DayLightSaving : Form
    {
        public DayLightSaving()
        {
            InitializeComponent();
        }


        public void GetInformation(dls2_set_t DaylightSavingInformation)
        {
            
            SMonth.Text = DaylightSavingInformation.start_mon.ToString();
            SWeek.Text  = DaylightSavingInformation.start_week.ToString();
            SDay.Text   = DaylightSavingInformation.start_weekday.ToString();
            SHour.Text  = DaylightSavingInformation.start_hour.ToString();
            SMinute.Text= DaylightSavingInformation.start_min.ToString();
    
            EMonth.Text = DaylightSavingInformation.end_mon.ToString();
            EWeek.Text  = DaylightSavingInformation.end_week.ToString();
            EDay.Text   = DaylightSavingInformation.end_weekday.ToString();
            EHour.Text  = DaylightSavingInformation.end_hour.ToString();
            EMinute.Text= DaylightSavingInformation.end_min.ToString();
        }

    }
}