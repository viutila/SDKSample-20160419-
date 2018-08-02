using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;


namespace UTC_MV_view
{

    public partial class Search_Form : Form
    {
        DeviceType DTDeviceType;
        ModalType MTModalType;
        IntPtr ptr = IntPtr.Zero;
        IntPtr phRender = IntPtr.Zero;
        //IntPtr iResultType;
        string str_IP = "";
        int int_port = 0;
        string str_username = "";
        string str_password = "";
        private CheckBox[] cb_AlarmCamArr = new System.Windows.Forms.CheckBox[6];
        private CheckBox[] cb_VideoCamArr = new System.Windows.Forms.CheckBox[12];
        int alarmmaskvalue;//convert current CH number to bit mask
        uint videomaskvalue;//convert current CH number to bit mask
        int int_poweron = 0;
        int int_gs_impact = 0;
        int int_gs_accel = 0;
        int int_alarm = 0;
        int int_vloss = 0;
        int int_J1939Type = 0;
        int int_starttime;
        int int_endtime;
        int int_SysFault;
        uint uint_HDDNo;

        uint uint_Degree = 0; // default 0
        uint uint_Minute = 0; // default 0
        uint uint_Second = 0; // default 0
        public GPS_POINT SelectedPoint1;
        public GPS_POINT SelectedPoint2;
        ushort uint_a_index = 0;
        ushort uint_v_index = 0;

        SearchData SearchDataobj;

        //HRESULT DLLAPI SdkShellInitial( long lMaxCh );//nMaxCh for videoWindow
        //[DllImportAttribute("SdkShell.dll")]
        //private static extern int SdkShellInitial(int nMaxCh);

        //HRESULT DLLAPI SdkShellInitialSource( HDevice *hDevice, DWORD dwDeviceType, DWORD dwModal, DWORD dwVersion );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitialSource(ref IntPtr hDevice, DeviceType dwDeviceType, ModalType dwModal, uint dwVersion);

        //HRESULT DLLAPI SdkShellOpenSource( HDevice hDevice, LPOPEN_DEVICE_PARAM_T stOpenParam, DWORD dwViewMode, long lParameter1 );//dwViewMode Live or playback, Parameter1:playback time
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellOpenSource(IntPtr hDevice, ref OPEN_DEVICE_PARAM_T stOpenParam, ViewType dwViewMode, int lParameter1);

        //HRESULT DLLAPI SdkShellCloseSource( HDevice hDevice, DWORD dwModal );//dwModal??
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCloseSource(IntPtr hDevice, ModalType dwModal);

        //HRESULT DLLAPI SdkShellReleaseSource( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellReleaseSource(IntPtr hDevice);

        //HRESULT DLLAPI SdkShellStopSearchEvent( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellStopSearchEvent(IntPtr hDevice);

        public Search_Form()
        {
            InitializeComponent();
            LAT1_SN.SelectedIndex = 0;
            LAT2_SN.SelectedIndex = 0;
            LON1_EW.SelectedIndex = 0;
            LON2_EW.SelectedIndex = 0;

            DateTime CurrentLocalTime = DateTime.Now;
            DateTime CurrentUTCTime = CurrentLocalTime.ToUniversalTime();
            EventEndTime_Picker.Value = CurrentUTCTime;
            EventStartTime_Picker.Value = CurrentUTCTime.AddDays(-1);
            SelectedPoint1 = new GPS_POINT();
            SelectedPoint2 = new GPS_POINT();
        }
        public bool getCameraType()
        {
            //Video Loss camera array
            cb_VideoCamArr[0] = Camera_cbv1;
            cb_VideoCamArr[1] = Camera_cbv2;
            cb_VideoCamArr[2] = Camera_cbv3;
            cb_VideoCamArr[3] = Camera_cbv4;
            cb_VideoCamArr[4] = Camera_cbv5;
            cb_VideoCamArr[5] = Camera_cbv6;
            cb_VideoCamArr[6] = Camera_cbv7;
            cb_VideoCamArr[7] = Camera_cbv8;
            cb_VideoCamArr[8] = Camera_cbv9;
            cb_VideoCamArr[9] = Camera_cbv10;
            cb_VideoCamArr[10] = Camera_cbv11;
            cb_VideoCamArr[11] = Camera_cbv12;

            for (int i = 0; i < 12; i++)
            {
                videomaskvalue += (uint)(cb_VideoCamArr[i].Checked ? 1 : 0) << i;
            }

            if (fullsearch_cb.Checked)
                videomaskvalue = 0xffffffff;//this is for full search, it will search those search event which chmap is 0
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int_starttime = (int)((EventStartTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_endtime = (int)((EventEndTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_alarm = (Alarm_cb.Checked ? 1 : 0);
            int_vloss = (Vloss_cb.Checked ? 1 : 0);
            int_poweron = (Power_on_cb.Checked ? 1 : 0);
            int_gs_impact = (GS_Impact_cb.Checked ? 1 : 0);
            int_gs_accel = (GS_Accel_cb.Checked ? 1 : 0);
            int_SysFault = (SystemFault_tb.Checked ? 1 : 0);
            int_J1939Type = (J1939_cb.Checked ? 1 : 0);

            if (int_starttime >= int_endtime)
            {
                MessageBox.Show("Time fail");
                return false;
            }

            return true;
        }
        public void Initialshell_Source()
        {
            int result;
            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(MTModalType);
            if (MTModalType == ModalType.MV_HDD)
                stOpenParam.dwDiskID = uint_HDDNo;
            else if (MTModalType == ModalType.MV_IMAGE)
            {
                if (stOpenParam.szFileName == null)
                {
                    MessageBox.Show("Please select any .avr file");
                    this.Close();
                    return;
                }
            }
            //Initial shell and Source
            result = SdkShellInitialSource(ref ptr, DTDeviceType, stOpenParam.dwModal, 0);
            result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.SEARCH, 0);
        }
        public void GetFormValue(string str_IP_Form1, int int_port_Form1, string str_username_Form1, string str_password_Form1)
        {
            str_IP = str_IP_Form1;
            int_port = int_port_Form1;
            str_username = str_username_Form1;
            str_password = str_password_Form1;
            DTDeviceType = DeviceType.DEVICE_DVR;
            MTModalType = ModalType.MV_DVR;
            Initialshell_Source();
        }
        public void GetHDDValue(uint _iHddNo)
        {
            uint_HDDNo = _iHddNo;
            DTDeviceType = DeviceType.DEVICE_HDD;
            MTModalType = ModalType.MV_HDD;
            Initialshell_Source();
        }
        public void GetFileValue( )
        {
            DTDeviceType = DeviceType.DEVICE_FILE;
            MTModalType = ModalType.MV_IMAGE;
            Initialshell_Source();
        }
        /** 
         *********************************************************************
         * @fn<GetGPSData>
         * @brief<This function will get start time, end time and GPS points from menu>
         * <GPS points will be convert to the format which SDK can accept>
         * <This format is DDDMMMMMM. D means degress while M means minute>
         * @param[in]
         * 
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int>
         *********************************************************************
         */
        public int GetGPSData()
        {
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int_starttime = (int)((EventStartTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_endtime = (int)((EventEndTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            //if (MTModalType == ModalType.MV_HDD)
            //{
            uint_Degree = Convert.ToUInt32(Degree_lon1.Text);
            uint_Minute = Convert.ToUInt32(Minute_lon1.Text);
            uint_Second = Convert.ToUInt32(Second_lon1.Text);
            SelectedPoint1.lon_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            uint_Degree = Convert.ToUInt32(Degree_lat1.Text);
            uint_Minute = Convert.ToUInt32(Minute_lat1.Text);
            uint_Second = Convert.ToUInt32(Second_lat1.Text);
            SelectedPoint1.lat_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            uint_Degree = Convert.ToUInt32(Degree_lon2.Text);
            uint_Minute = Convert.ToUInt32(Minute_lon2.Text);
            uint_Second = Convert.ToUInt32(Second_lon2.Text);
            SelectedPoint2.lon_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            uint_Degree = Convert.ToUInt32(Degree_lat2.Text);
            uint_Minute = Convert.ToUInt32(Minute_lat2.Text);
            uint_Second = Convert.ToUInt32(Second_lat2.Text);
            SelectedPoint2.lat_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            SelectedPoint1.lon_section = (byte)LON1_EW.SelectedIndex;
            SelectedPoint1.lat_section = (byte)LAT1_SN.SelectedIndex;
            SelectedPoint2.lon_section = (byte)LON2_EW.SelectedIndex;
            SelectedPoint2.lat_section = (byte)LAT2_SN.SelectedIndex;

            uint_a_index = Convert.ToUInt16(textBox_a_index.Text);
            uint_v_index = Convert.ToUInt16(textBox_v_index.Text);

            return 1;
            //}
            //return 0;
        }
        private OPEN_DEVICE_PARAM_T CreateDeviceParam(ModalType _mtSelectedType)
        {
            OPEN_DEVICE_PARAM_T stOpenParam = new OPEN_DEVICE_PARAM_T();
            if (_mtSelectedType == ModalType.MV_DVR)
                stOpenParam.dwDeviceType = DeviceType.DEVICE_DVR;
            else if (_mtSelectedType == ModalType.MV_HDD)
                stOpenParam.dwDeviceType = DeviceType.DEVICE_HDD;
            else if (_mtSelectedType == ModalType.MV_IMAGE)
                stOpenParam.dwDeviceType = DeviceType.DEVICE_FILE;
            else
                stOpenParam.dwDeviceType = DeviceType.DEVICE_DVR;

            if (stOpenParam.dwDeviceType == DeviceType.DEVICE_DVR)
            {
                stOpenParam.dwModal = ModalType.MV_DVR;
                CONNECT_PARAM_T conn_param = new CONNECT_PARAM_T();
                conn_param.dwModal = ModalType.MV_DVR;

                conn_param.device = new DEVICE();
                conn_param.device.mv = new moblie_view();
                conn_param.device.mv.szUrl = str_IP;
                conn_param.device.mv.usWebPort = (ushort)Math.Min(ushort.MaxValue, int_port);
                conn_param.device.mv.szUID = str_username;
                conn_param.device.mv.szPWD = str_password;

                stOpenParam.mDvrParam = conn_param;
            }

            else if (stOpenParam.dwDeviceType == DeviceType.DEVICE_HDD)
            {
                stOpenParam.dwModal = ModalType.MV_HDD;
                CONNECT_PARAM_T conn_param = new CONNECT_PARAM_T();
                conn_param.dwModal = ModalType.MV_HDD;

                conn_param.device = new DEVICE();
                conn_param.device.mv = new moblie_view();

                stOpenParam.mDvrParam = conn_param;
            }
            else if (stOpenParam.dwDeviceType == DeviceType.DEVICE_FILE)
            {
                OpenFileDialog path = new OpenFileDialog();
                path.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.* ";
                if (path.ShowDialog() == DialogResult.OK)
                {
                    stOpenParam.szFileName = path.FileName.ToString();
                }
                stOpenParam.dwModal = ModalType.MV_IMAGE;
                CONNECT_PARAM_T conn_param = new CONNECT_PARAM_T();
                conn_param.device = new DEVICE();
                conn_param.device.mv = new moblie_view();
                stOpenParam.mDvrParam = conn_param;
            }
            else
                MessageBox.Show("Device type error!!!");

            return stOpenParam;
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            if (GetGPSData() == 1)
            {
                if (!getCameraType())
                    return;
                Startbtn.Enabled = false;
                listView1.Items.Clear();

                SearchDataobj = new SearchData(ptr, listView1, int_starttime, int_endtime, int_alarm, int_vloss, int_poweron, int_gs_impact, int_gs_accel, int_SysFault, int_J1939Type, videomaskvalue);
                //we do not use alarmmaskvalue temporary. We use int_alarm as a condition variable like power on or impact
                SearchDataobj.m_bStopflag = false;
                SearchDataobj.SetGPSLocation(SelectedPoint1, SelectedPoint2, uint_a_index, uint_v_index);
                SearchDataobj.Startenable += new EventHandler(Startbtnbox);
                SearchDataobj.CloseForm += new EventHandler(CloseFormbox);
                Thread SearchDataThread = new Thread(SearchDataobj.getSearchData);
                SearchDataThread.Start();
                videomaskvalue = 0;
                alarmmaskvalue = 0;
                int_poweron = 0;
            }
            else
            {
                MessageBox.Show("Event search fail");
            }
        }

        private void Stopbtn_Click(object sender, EventArgs e)
        {
            SearchDataobj.m_bStopflag = true;
            int result = SdkShellStopSearchEvent(ptr);
            Startbtn.Enabled = true;
        }

        public void Startbtnbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncWriteeventdata(Changestartbtn), null);

        }
        private delegate void AsyncWriteeventdata();
        private void Changestartbtn()
        {
            Startbtn.Enabled = true;
        }
        public void CloseFormbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncCloseForm(CloseEventForm), null);

        }
        private delegate void AsyncCloseForm();
        private void CloseEventForm()
        {
            this.Close();
        }

        private void On_EventSearchClosing(object sender, FormClosingEventArgs e)
        {

            int ptr_value = ptr.ToInt32();
            if (ptr_value != 0)
            {
                if (MTModalType == ModalType.MV_DVR)
                    SdkShellCloseSource(ptr, ModalType.MV_DVR);
                else if (MTModalType == ModalType.MV_HDD)
                    SdkShellCloseSource(ptr, ModalType.MV_HDD);
                else
                    SdkShellCloseSource(ptr, ModalType.MV_DVR);

                SdkShellReleaseSource(ptr);
            }
            ptr = IntPtr.Zero;
        }
     }
}
