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
    public partial class Gsensor_Form : Form
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
        public byte by_valueX = 0; // default 0
        public byte by_valueY = 0; // default 0
        public byte by_valueZ = 0; // default 0
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

        public Gsensor_Form()
        {
            InitializeComponent();
            Searchmode_cb.SelectedIndex = 0; //combobox default
            //Express as utc Time
            DateTime CurrentLocalTime = DateTime.Now;
            DateTime CurrentUTCTime = CurrentLocalTime.ToUniversalTime();
            GsensorEndTime_Picker.Value = CurrentUTCTime;
            GsensorStartTime_Picker.Value = CurrentUTCTime.AddDays(-1);

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
            ValueY_txt.Visible = false;
            ValueZ_txt.Visible = false;
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
            Searchmode_cb.SelectedIndex = 1;//HDD only provide "more than" functionality
            Searchmode_cb.Enabled = false;
        }

        public void GetFileValue( )
        {
            DTDeviceType = DeviceType.DEVICE_FILE;
            MTModalType = ModalType.MV_IMAGE;
            Initialshell_Source();
            Searchmode_cb.SelectedIndex = 1;//HDD only provide "more than" functionality
            Searchmode_cb.Enabled = false;
        }

        private void Searchmode_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MTModalType == ModalType.MV_HDD)
            {
                switch (Searchmode_cb.SelectedIndex)
                {
                    case 0:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = true;
                        ValueZ_txt.Visible = true;

                        break;
                    case 1:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = true;
                        ValueZ_txt.Visible = true;

                        break;
                    case 2:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = true;
                        ValueZ_txt.Visible = true;

                        break;
                    case 3:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = true;
                        ValueZ_txt.Visible = true;

                        break;
                    default:
                        break;
                }
            }
            else if (MTModalType == ModalType.MV_DVR)
            {
                ValueZ_txt.Visible = false;
                switch (Searchmode_cb.SelectedIndex)
                {
                    case 0:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = false;

                        break;
                    case 1:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = false;

                        break;
                    case 2:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = true;

                        break;
                    case 3:
                        ValueX_txt.Visible = true;
                        ValueY_txt.Visible = true;

                        break;
                    default:
                        break;
                }
            }
        }
        public bool Limitvalue(int value)
        {
            if (value < 128 && value > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please input value between 1~127");
                return false;
            }
        }
        public int getGsenortype() 
        {
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int_starttime = (int)((GsensorStartTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_endtime = (int)((GsensorEndTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            if (int_starttime >= int_endtime)
            {
                MessageBox.Show("Time fail");
                return 0;
            }
            us_mode = (ushort)Searchmode_cb.SelectedIndex;
            if ( (MTModalType == ModalType.MV_HDD) || (MTModalType==ModalType.MV_IMAGE))
            {
                by_valueX = (byte)Convert.ToInt32(ValueX_txt.Text);
                by_valueY = (byte)Convert.ToInt32(ValueY_txt.Text);
                by_valueZ = (byte)Convert.ToInt32(ValueZ_txt.Text);
                return 1;
            }
            else if (MTModalType == ModalType.MV_DVR)
            {
                //Get txt value 
                switch (Searchmode_cb.SelectedIndex)
                {
                    case 0:
                        if (Limitvalue((byte)Convert.ToInt32(ValueX_txt.Text)) == false)
                        {
                            return 0;
                        }
                        else
                        {
                            by_valueX = (byte)Convert.ToInt32(ValueX_txt.Text);
                            return 1;
                        }

                    case 1:
                        if (Limitvalue((byte)Convert.ToInt32(ValueX_txt.Text)) == false)
                        {
                            return 0;
                        }
                        else
                        {
                            by_valueX = (byte)Convert.ToInt32(ValueX_txt.Text);
                            return 1;
                        }

                    case 2:
                        if (Limitvalue((byte)Convert.ToInt32(ValueX_txt.Text)) == false || Limitvalue(Convert.ToInt32(ValueY_txt.Text)) == false)
                        {
                            return 0;
                        }
                        else
                        {
                            by_valueX = (byte)Convert.ToInt32(ValueX_txt.Text);
                            by_valueY = (byte)Convert.ToInt32(ValueY_txt.Text);
                            return 1;
                        }

                    case 3:
                        if (Limitvalue((byte)Convert.ToInt32(ValueX_txt.Text)) == false || Limitvalue(Convert.ToInt32(ValueY_txt.Text)) == false)
                        {
                            return 0;
                        }
                        else
                        {
                            by_valueX = (byte)Convert.ToInt32(ValueX_txt.Text);
                            by_valueY = (byte)Convert.ToInt32(ValueY_txt.Text);
                            return 1;
                        }
                    default:
                        return 0;
                }
            }
            else
                return 0;
        
        }

        private void Startgsensor_btn_Click(object sender, EventArgs e)
        {
            if (getGsenortype() == 1)
            {
                Startgsensor_btn.Enabled = false;
                listView1.Items.Clear();

                SearchDataobj = new SearchData(ptr, listView1, int_starttime, int_endtime, us_mode, by_valueX, by_valueY, by_valueZ);
                SearchDataobj.m_bStopflag = false;
                SearchDataobj.Startenable += new EventHandler(Startbtnbox);
                SearchDataobj.CloseForm += new EventHandler(CloseFormbox);
                Thread SearchDataThread = new Thread(SearchDataobj.getSearchData);
                SearchDataThread.Start();
            }
            else
            {
                MessageBox.Show("Gsensor search fail");
            }
        }

        private void Stopgsensor_btn_Click(object sender, EventArgs e)
        {
            SearchDataobj.m_bStopflag =  true;
            int result = SdkShellStopSearchEvent(ptr);
            Startgsensor_btn.Enabled = true;
        }
        public void Startbtnbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncWritegsdata(Changestartbtn), null);

        }
        private delegate void AsyncWritegsdata();
        private void Changestartbtn()
        {
            Startgsensor_btn.Enabled = true;
        }
        public void CloseFormbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncCloseForm(CloseGSensorForm), null);

        }
        private delegate void AsyncCloseForm();
        private void CloseGSensorForm()
        {
            this.Close();
        }

        private void On_GSensorSearchClosing(object sender, FormClosingEventArgs e)
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