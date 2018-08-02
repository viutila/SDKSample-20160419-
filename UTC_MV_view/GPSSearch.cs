using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace UTC_MV_view
{


    public partial class GPSSearch_Form : Form
    {
        uint uint_HDDNo;
        DeviceType DTDeviceType;
        ModalType MTModalType;
        IntPtr ptr = IntPtr.Zero;
        IntPtr phRender = IntPtr.Zero;
        string str_IP = "";
        int int_port = 0;
        string str_username = "";
        string str_password = "";
        public int int_starttime = 0;
        public int int_endtime = 0;
        public ushort us_mode = 0;
        uint uint_Degree = 0; // default 0
        uint uint_Minute = 0; // default 0
        uint uint_Second = 0; // default 0
        byte by_radius = 1; //default 1

        GPS_POINT SelectedPoint1;
        GPS_POINT SelectedPoint2;
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

        public GPSSearch_Form()
        {
            InitializeComponent();
            LAT1_SN.SelectedIndex = 0;
            LAT2_SN.SelectedIndex = 0;
            LON1_EW.SelectedIndex = 0;
            LON2_EW.SelectedIndex = 0;
            SearchType.SelectedIndex = 1;
            //Express as utc Time
            DateTime CurrentLocalTime = DateTime.Now;
            DateTime CurrentUTCTime = CurrentLocalTime.ToUniversalTime();
            GPSEndTime_Picker.Value = CurrentUTCTime;
            GPSStartTime_Picker.Value = CurrentUTCTime.AddDays(-1);
        }

        /** 
         *********************************************************************
         * @fn<CreateDeviceParam>
         * @brief<This function will new a OPEN_DEVICE_PARAM_T structure and set the values of it>
         * <After setting value,the pointer of  this structure will be returned>
         * 
         * @param[in]
         * <ModalType __mtSelectedType>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <OPEN_DEVICE_PARAM_T>
         *********************************************************************
         */
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
                path.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.*";
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

        public void Initialshell_Source()
        {
            int result;
            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(MTModalType);
            if (MTModalType == ModalType.MV_HDD)
                stOpenParam.dwDiskID = uint_HDDNo;
            else if (MTModalType == ModalType.MV_IMAGE)
            {
                if (stOpenParam.szFileName == null)
                    return;
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

        /** 
         *********************************************************************
         * @fn< GetHDDValue>
         * @brief<This function is used to get and set DeviceType, ModalType and HDD No. >
         * <It will open and close some unused window object>
         * <HDD only provide "more than" functionality in G-Sensor search>
         * @param[in]
         * < _iHddNo:It is used to get disk number. It will be assign to unit_HDDNo to open selected disk>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int>
         *********************************************************************
         */
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
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local); // 1970/1/1 0:0:0
            int_starttime = (int)((GPSStartTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_endtime = (int)((GPSEndTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            if (int_starttime >= int_endtime)
            {
                MessageBox.Show("Time fail");
                return 0;
            }
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

                by_radius = (byte)Convert.ToInt32(radius_tb.Text);

                if (by_radius <= 100 && by_radius > 0)
                {
                    return 1;
                }
                else
                {
                    MessageBox.Show("Please Radius value between 1~100");
                    return 0;
                }
        }

        /** 
         *********************************************************************
         * @fn< StartSearch_btn_Click>
         * @brief<This function is used start GPS search. SDK will need ptr of device, start time, end time,and two GPS points. >
         * <This function will Initial and Open Soucre>
         *  <then fork a thread to deal with GPS Search because it need to loop many time to retrieve all search result>
         * 
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private void StartSearch_btn_Click(object sender, EventArgs e)
        {
            if (GetGPSData() == 1)
            {
                StartSearch_btn.Enabled = false;
                listView1.Items.Clear();

                uint _uiSearchType;
                if (SearchType.SelectedIndex == 0)
                    _uiSearchType = (uint)(SearchType.SelectedIndex | (uint)SearchConditions.SEARCH_GPS_BY_Time);//0x02000000 for searching by time
                else if (SearchType.SelectedIndex == 1)
                    _uiSearchType = (uint)(SearchType.SelectedIndex | (uint)SearchConditions.SEARCH_GPS_CLOSEST_POINT);//0x02000001 for searching closest point
                else if (SearchType.SelectedIndex == 2)
                    _uiSearchType = (uint)(SearchType.SelectedIndex | (uint)SearchConditions.SEARCH_GPS_WHEN_VEHICLE_PASS);//0x02000002 for searching when vehicle pass the point
                else
                    return;

                SearchDataobj = new SearchData(ptr, listView1, int_starttime, int_endtime, MTModalType, _uiSearchType, by_radius);
                SearchDataobj.m_bStopflag = false;
                SearchDataobj.SetGPSTwoPointLocation(SelectedPoint1, SelectedPoint2);
                SearchDataobj.Startenable += new EventHandler(Startbtnbox);//An Event Handler which enables Start button after searching 
                SearchDataobj.CloseForm += new EventHandler(CloseFormbox);
                Thread SearchDataThread = new Thread(SearchDataobj.getSearchData);
                SearchDataThread.Start();
            }
            else
            {
                MessageBox.Show("Gsensor search fail");
            }
        }


        /** 
         *********************************************************************
         * @fn< StopSearch_btn_Click>
         * @brief<This function is used to stop Search >
         * 
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private void StopSearch_btn_Click(object sender, EventArgs e)
        {
            SearchDataobj.m_bStopflag = true;
            int result = SdkShellStopSearchEvent(ptr);
            StartSearch_btn.Enabled = true;
        }

        /** 
         *********************************************************************
         * @fn< Startbtnbox>
         * @brief<This function will call ui thread to enable start button >
         * 
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        public void Startbtnbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncWritegpsdata(Changestartbtn), null);

        }
        private delegate void AsyncWritegpsdata();
        private void Changestartbtn()
        {
            StartSearch_btn.Enabled = true;
        }
        public void CloseFormbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncCloseForm(CloseGPSForm), null);

        }
        private delegate void AsyncCloseForm();
        private void CloseGPSForm()
        {
            this.Close();
        }

        private void On_GPSSearchClosing(object sender, FormClosingEventArgs e)
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