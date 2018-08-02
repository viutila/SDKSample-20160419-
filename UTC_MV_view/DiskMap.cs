using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Runtime.InteropServices;

namespace UTC_MV_view
{
    public partial class DiskMap : Form
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
        int alarmmaskvalue;//convert current CH number to bit mask
        uint videomaskvalue;//convert current CH number to bit mask
        int int_poweron = 0;
        int int_alarm = 0;
        int int_vloss = 0;
        int int_starttime;
        int int_endtime;
        int int_SysFault;
        uint uint_HDDNo;
        uint uint_Degree = 0; // default 0
        uint uint_Minute = 0; // default 0
        uint uint_Second = 0; // default 0
        GPS_POINT SelectedPointd1;
        GPS_POINT SelectedPointd2;
        DiskmapScale SelectedScale;

        DiskMapSearch SearchDataobj;
        SearchData SeqmentSearchDataobj;

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

        public DiskMap()
        {
            InitializeComponent();

            //Express as utc Time
            DateTime CurrentLocalTime = DateTime.Now;
            DateTime CurrentUTCTime = CurrentLocalTime.ToUniversalTime();
            DiskMapEndTime_Picker.Value = CurrentUTCTime;
            SegmentEndTimePicker.Value = CurrentUTCTime;

            CurrentLocalTime = DateTime.Now.AddDays(-1);
            CurrentUTCTime = CurrentLocalTime.ToUniversalTime();
            DiskMapStartTime_Picker.Value = CurrentUTCTime;
            SegmentStartTimePicker.Value = CurrentUTCTime;
            //DiskMapStartTime_Picker.Value = DateTime.Now.AddDays(-1);
            //DiskMapEndTime_Picker.Value = DateTime.Now;
            //SegmentStartTimePicker.Value = DateTime.Now.AddDays(-1);
            //SegmentEndTimePicker.Value = DateTime.Now;

            Selected_Scale.SelectedIndex = 0;
            Select_ch.SelectedIndex = 0;
            SeleCamera_ComboBox.SelectedIndex = 0;
            SelectedPointd1 = new GPS_POINT();
            SelectedPointd2 = new GPS_POINT();
            LAT1_SN.SelectedIndex = 0;
            LAT2_SN.SelectedIndex = 0;
            LON1_EW.SelectedIndex = 0;
            LON2_EW.SelectedIndex = 0;
        }

        public bool getCameraType()
        {
            int iSelectedIndexValue;
            iSelectedIndexValue = SeleCamera_ComboBox.SelectedIndex;
            if (iSelectedIndexValue != 8)
                videomaskvalue = (uint)1 << iSelectedIndexValue;
            else if (iSelectedIndexValue == 8)
                videomaskvalue = 0xff;//select all channels
            else
                Debug.Write("SeleCamera_ComboBox is larger than 8");
            if(fullsearch_cb.Checked)
                videomaskvalue=0xffffffff;
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int_starttime = (int)((DiskMapStartTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_endtime = (int)((DiskMapEndTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_poweron = (Power_on_cb.Checked ? 1 : 0);
            int_alarm = (Alarm_cb.Checked ? 1 : 0);
            int_vloss = (Vloss_cb.Checked ? 1 : 0);
            int_SysFault = (SystemFault_tb.Checked ? 1 : 0);

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
        public void GetHDDValue(uint _iHddNo)
        {
            uint_HDDNo = _iHddNo;
            DTDeviceType = DeviceType.DEVICE_HDD;
            MTModalType = ModalType.MV_HDD;
            Initialshell_Source();
            Select_ch.Enabled = false;
        }
        public void GetFileValue( )
        {
            DTDeviceType = DeviceType.DEVICE_FILE;
            MTModalType = ModalType.MV_IMAGE;
            Initialshell_Source();
        }
        public int GetGPSData()
        {
            uint_Degree = Convert.ToUInt32(Degree_lon1.Text);
            uint_Minute = Convert.ToUInt32(Minute_lon1.Text);
            uint_Second = Convert.ToUInt32(Second_lon1.Text);
            SelectedPointd1.lon_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            uint_Degree = Convert.ToUInt32(Degree_lat1.Text);
            uint_Minute = Convert.ToUInt32(Minute_lat1.Text);
            uint_Second = Convert.ToUInt32(Second_lat1.Text);
            SelectedPointd1.lat_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            uint_Degree = Convert.ToUInt32(Degree_lon2.Text);
            uint_Minute = Convert.ToUInt32(Minute_lon2.Text);
            uint_Second = Convert.ToUInt32(Second_lon2.Text);
            SelectedPointd2.lon_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            uint_Degree = Convert.ToUInt32(Degree_lat2.Text);
            uint_Minute = Convert.ToUInt32(Minute_lat2.Text);
            uint_Second = Convert.ToUInt32(Second_lat2.Text);
            SelectedPointd2.lat_value = uint_Degree * 1000000 + ((uint_Second * 10000) / 60) + uint_Minute * 10000;

            SelectedPointd1.lon_section = (byte)LON1_EW.SelectedIndex;
            SelectedPointd1.lat_section = (byte)LAT1_SN.SelectedIndex;
            SelectedPointd2.lon_section = (byte)LON2_EW.SelectedIndex;
            SelectedPointd2.lat_section = (byte)LAT2_SN.SelectedIndex;
            return 1;
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


        private void StartDiskMap_Click(object sender, EventArgs e)
        {
            if (!getCameraType())
                return;
            StartDiskMap.Enabled = false;
            DiskMapResult.Items.Clear();
            uint uichannel = 0;
            uichannel = (uint)System.Math.Pow((double)2, (double)(Select_ch.SelectedIndex));

            SelectedScale = (DiskmapScale)Selected_Scale.SelectedIndex;
            SearchDataobj = new DiskMapSearch(ptr, DiskMapResult, int_starttime, int_endtime, SelectedScale, uichannel, MTModalType);
            SearchDataobj.m_bStopflag = false;
            SearchDataobj.DiskMapStartenable += new EventHandler(DiskMapStartbtnbox);
            SearchDataobj.DiskMapCloseForm += new EventHandler(CloseFormbox);
            Thread SearchDataThread = new Thread(SearchDataobj.getSearchData);
            SearchDataThread.Start();
            videomaskvalue = 0;
            alarmmaskvalue = 0;
            int_poweron = 0;
        }

        private void StopDiskMap_Click(object sender, EventArgs e)
        {
            SearchDataobj.m_bStopflag = true;
            int result = SdkShellStopSearchEvent(ptr);
            StartDiskMap.Enabled = true; 
        }

        public void DiskMapStartbtnbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncWriteDiskMapdata(ChangeDiskMapstartbtn), null);
        }

        private delegate void AsyncWriteDiskMapdata();
        private void ChangeDiskMapstartbtn()
        {
            StartDiskMap.Enabled = true;
        }

        private void OnDiskMap_Closing(object sender, FormClosingEventArgs e)
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

        private void Segmentbtn_Click(object sender, EventArgs e)
        {
            if (!getCameraType())
                return;
            Segmentbtn.Enabled = false;
            SegmentResult.Items.Clear();
            GetGPSData();
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int int_Segmentstarttime = (int)((SegmentStartTimePicker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int int_Segmentendtime = (int)((SegmentEndTimePicker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time

            SeqmentSearchDataobj = new SearchData(ptr, SegmentResult, int_Segmentstarttime, int_Segmentendtime, int_alarm, int_vloss, int_poweron, int_SysFault, videomaskvalue, SelectedPointd1, SelectedPointd2);
            SeqmentSearchDataobj.m_bStopflag = false;
            SeqmentSearchDataobj.Startenable += new EventHandler(Startbtnbox);
            SeqmentSearchDataobj.CloseForm += new EventHandler(CloseFormbox);
            Thread SearchDataThread = new Thread(SeqmentSearchDataobj.getSearchData);
            SearchDataThread.Start();
            videomaskvalue = 0;
            alarmmaskvalue = 0;
            int_poweron = 0;
        }
        public void Startbtnbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncWritesegmentdata(Changestartbtn), null);

        }
        private delegate void AsyncWritesegmentdata();
        private void Changestartbtn()
        {
            Segmentbtn.Enabled = true;
        }

        public void CloseFormbox(object src, EventArgs e)
        {
            this.BeginInvoke(new AsyncCloseForm(CloseDiskmapForm), null);

        }
        private delegate void AsyncCloseForm();
        private void CloseDiskmapForm()
        {
            this.Close();
        }

        private void SegmentStopbtn_Click(object sender, EventArgs e)
        {
            SeqmentSearchDataobj.m_bStopflag = true;
            int result = SdkShellStopSearchEvent(ptr);
            Segmentbtn.Enabled = true; 
        }
    }


    public class DiskMapSearch
    {
        IntPtr ptr = IntPtr.Zero;
        ListView SearchlistView;
        int int_total = 0;
        int int_starttime = 0;
        int int_endtime = 0;
        int alarmmaskvalue = 0;
        int videomaskvalue = 0;
        public int int_poweron = 0;
        uint nConditions = 0;
        uint uichannel = 0;
        public bool m_bStopflag = false;
        DiskmapScale mSelectedScale;
        public event EventHandler DiskMapStartenable;
        public event EventHandler DiskMapCloseForm;

        ModalType MTModalType;

        public void setDiskMapStartbtnopen()
        {
            if (DiskMapStartenable != null)
                DiskMapStartenable(this, new EventArgs());
        }
        public void setDiskMapCloseForm()
        {
            if (DiskMapCloseForm != null)
                DiskMapCloseForm(this, new EventArgs());
        }

        public DiskMapSearch(IntPtr sptr, ListView listView, int startTime, int endTime, DiskmapScale inputScale, uint channel, ModalType ModalType)
        {
            ptr = sptr;
            SearchlistView = listView;
            int_starttime = startTime;
            int_endtime = endTime;
            mSelectedScale = inputScale;
            uichannel = channel;
            MTModalType = ModalType;
        }

        int discover_count = 0;

        //HRESULT DLLAPI SdkShellSearchDiskmap( HDevice hDevice, long lStartTime, long lEndTime, DWORD dwScaleType );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSearchDiskmap(IntPtr hDevice, int startTime, int endTime, DiskmapScale dwScaleType, uint uichannel);

        //HRESULT DLLAPI SdkShellGetDiskmapItem( HDevice hDevice, long lItem, long *lResultType, void *pResult );
        [DllImportAttribute("SdkShell.dll")]
        private static extern bool SdkShellGetDiskmapItem(IntPtr hDevice, int nIndex, ref IntPtr lResultType, IntPtr pResult);

        //HRESULT DLLAPI SdkShellStopSearchDiskmap( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellStopSearchDiskmap(IntPtr hDevice);

        //long DLLAPI SdkShellGetDiskmapCount( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetDiskmapCount(IntPtr hDevice);

        //build list
        private delegate void AsyncListViewCallBack(ListViewItem lvItem, Control ctl);
        private void ListViewCallBack(ListViewItem lvItem, Control ctl)
        {
            ListView lv = ctl as ListView;
            lv.Items.Add(lvItem);
        }
        private ListViewItem GetListViewItem(string no, string STime, string ETime, string Rec_Status, string ch)
        {
            //no: index
            //ch: channel
            //STime: start time
            //ETime: End time
            //Rec_Status: Rec_Status
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = no;

            ListViewItem.ListViewSubItem lviSubItemSTime = new ListViewItem.ListViewSubItem();
            lviSubItemSTime.Text = STime;
            lvItem.SubItems.Add(lviSubItemSTime);

            ListViewItem.ListViewSubItem lviSubItemETime = new ListViewItem.ListViewSubItem();
            lviSubItemETime.Text = ETime;
            lvItem.SubItems.Add(lviSubItemETime);

            ListViewItem.ListViewSubItem lviSubItemRec_Status = new ListViewItem.ListViewSubItem();
            lviSubItemRec_Status.Text = Rec_Status;
            lvItem.SubItems.Add(lviSubItemRec_Status);

            ListViewItem.ListViewSubItem lviSubItemch = new ListViewItem.ListViewSubItem();
            lviSubItemch.Text = ch;
            lvItem.SubItems.Add(lviSubItemch);
            return lvItem;
        }
        public void getSearchData()
        {
            //assign condition and get search data
            int result = 0;
            IntPtr iResultType;
            DateTime STime = new DateTime();
            DateTime ETime = new DateTime();

            //if (alarmmaskvalue != 0)//alarm
            //{
            //    nConditions += (uint)SearchConditions.ALARM_MAP;
            //}
            //if (videomaskvalue != 0)//videoloss
            //{
            //    nConditions += (uint)SearchConditions.VIDEO_LOSS_MAP;
            //}
            //if (int_poweron != 0)//power on
            //{
            //    nConditions += (uint)SearchConditions.POWER_ON;
            //}

            //if (videomaskvalue == 0)//videomaskvalue default 1
            //{
            //    videomaskvalue = 1;
            //}

            //assign start time, end time, Condition, meta_search structure and alarmmask
            if (MTModalType == ModalType.MV_HDD)
            {
                uichannel = 2048;//only 12ch
                result = SdkShellSearchDiskmap(ptr, int_starttime, int_endtime, mSelectedScale, uichannel);
                if (result < 0)
                {
                    MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                    setDiskMapCloseForm();
                    return;
                }
            }
            else
            {
                result = SdkShellSearchDiskmap(ptr, int_starttime, int_endtime, mSelectedScale, uichannel);
                if (result < 0)
                {
                    MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                    setDiskMapCloseForm();
                    return;
                }
            }

            nConditions = 0;
            videomaskvalue = 0;
            alarmmaskvalue = 0;
            int_total = SdkShellGetDiskmapCount(ptr);

            //get total event
            if (int_total > 0)
            {
                int index = 0;
                while ((m_bStopflag == false) && (index < int_total))
                {

                    iResultType = IntPtr.Zero;
                    IntPtr iResult = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DISKMAP_T_P2)));
                    bool bresult;
                    bresult = SdkShellGetDiskmapItem(ptr, index, ref iResultType, iResult);

                    DISKMAP_T_P2 DiskMapEvent = new DISKMAP_T_P2();
                    DiskMapEvent = (DISKMAP_T_P2)Marshal.PtrToStructure(iResult, typeof(DISKMAP_T_P2));

                    STime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)DiskMapEvent.nStartTime);
                    ETime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)DiskMapEvent.nEndTime);

                    ListViewItem lvItem;

                    //get data to list
                    lvItem = GetListViewItem((index + 1).ToString(), STime.ToString("yyyy/M/d HH:mm:ss tt"), ETime.ToString("yyyy/M/d HH:mm:ss tt"), DiskMapEvent.uiRecordStatus.ToString(), (DiskMapEvent.uiChannel + 1).ToString());

                    object[] inputarg = new object[2];
                    inputarg[0] = lvItem;
                    inputarg[1] = SearchlistView;

                    SearchlistView.BeginInvoke(new AsyncListViewCallBack(ListViewCallBack), inputarg);
                    discover_count++;
                    index++;
                }
                setDiskMapStartbtnopen();
                MessageBox.Show("search complete");
            }
            else
            {
                setDiskMapStartbtnopen();
                MessageBox.Show("No data");
            }
        }
    }
}