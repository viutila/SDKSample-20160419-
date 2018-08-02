using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace UTC_MV_view
{
    /// <summary>
    /// dls2_set_t
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct dls2_set_t
    {
        public byte enable;

        public byte start_mon;

        public byte start_week;

        public byte start_weekday;

        public byte start_hour;

        public byte start_min;

        public byte set_hour;

        public byte set_min;

        public byte end_mon;

        public byte end_week;

        public byte end_weekday;

        public byte end_hour;

        public byte end_min;
    }

    public partial class Alarm_Vehicle : Form
    {
        uint uint_HDDNo;
        IntPtr ptr = IntPtr.Zero;
        DeviceType DTDeviceType;
        ModalType MTModalType;
        string str_IP = "";
        int int_port = 0;
        string str_username = "";
        string str_password = "";
        DayLightSaving DayLightSavingForm = new DayLightSaving();
        /// <summary>
        /// SdkShellGetTableInfo Type
        /// </summary>
        public enum MV3_TABLE_INFO : int
        {
            MV3_ALARM_TABLE_INFO = 0,
            MV3_VEHICLE_TABLE_INFO = 1,
            MV3_DayLightSaving_TABLE_INFO = 2,
        }


        /// <summary>
        /// vehicle ID
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct _vid_table_t
        {
            /// unsigned int
	        public uint start; // [0-3], record start time    u32

            /// unsigned int
	        public uint end; // [4-7], record end time    u32

            /// unsigned short
	        public ushort index; // [8-9], vehicle index    u16

            /// unsigned char[16]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
	        public char[] name; // [10-25], vehicle id    u8

            /// unsigned char[6]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6)]
	        public byte[] reserv; // [26-31]  u8
        }



        //[StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        //public struct _extra_header_t
        //{
        //    /// unsigned int
        //    public uint magic; // [0-3] u32

        //    /// unsigned char[16]
        //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        //    public char[] hdd_serial; // [4-19], hd disk serial number u8

        //    /// unsigned char[32]
        //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
        //    public char[] bus_id; // [20-51], current machine serial number u8

        //    /// int
        //    public int curr_index; // [52-55], current vehicle id index

        //    /// unsigned char[16][16]
        //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256)]
        //    public char[] event_name; // [56-311] u8

        //    /// unsigned int
        //    public uint curr_vehicle_st; // [312-315] u32

        //    /// unsigned char[200]
        //    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 200)]
        //    public byte[] reserv; // [316-511] u8
        //}

        /// <summary>
        /// alarm table
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct _extra_header_t

        {
            /// unsigned char[16]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 19)]
            public char[] event_name; 
        }

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

        //HRESULT DLLAPI SdkShellGetTableInfo( HDevice hDevice, long lType, long *lCount, void *pResult );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetTableInfo(IntPtr hDevice, int lType, out int lCount, IntPtr pResult);

        public Alarm_Vehicle()
        {
            InitializeComponent();
            sel_type.SelectedIndex = 0;
        }

        private void Alarm_Vehicle_Load(object sender, EventArgs e)
        {

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

        /** 
         *********************************************************************
         * @fn< GetHDDValue>
         * @brief<This function is used to get and set DeviceType, ModalType and HDD No. >
         * <It will open and close some unused window object>
         * <HDD only provide "more than" functionality in table search>
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

        private void OnAlarm_VehicleID_Closing(object sender, FormClosingEventArgs e)
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

        //build list
        private delegate void AsyncListViewCallBack(ListViewItem lvItem, Control ctl);
        private void ListViewCallBack(ListViewItem lvItem, Control ctl)
        {
            ListView lv = ctl as ListView;
            lv.Items.Add(lvItem);
        }

        private ListViewItem GetTableListViewItem(string no,  string name, string STime, string ETime)
        {
            //no: index
            //name: name
            //STime: start time
            //ETime: End time
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = no;

            ListViewItem.ListViewSubItem lviSubItemName = new ListViewItem.ListViewSubItem();
            lviSubItemName.Text = name;
            lvItem.SubItems.Add(lviSubItemName);

            ListViewItem.ListViewSubItem lviSubItemSTime = new ListViewItem.ListViewSubItem();
            lviSubItemSTime.Text = STime;
            lvItem.SubItems.Add(lviSubItemSTime);

            ListViewItem.ListViewSubItem lviSubItemETime = new ListViewItem.ListViewSubItem();
            lviSubItemETime.Text = ETime;
            lvItem.SubItems.Add(lviSubItemETime);

            return lvItem;
        }

        /** 
        *********************************************************************
        * @fn<Start_alarm_vehicleID_Click>
        * @brief<This part will be used to get vehicle ID and alarm table.>
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
        private void Start_alarm_vehicleID_Click(object sender, EventArgs e)
        {
            table_listView.Items.Clear();
            int result = 0;
            DateTime STime = new DateTime();
            DateTime ETime = new DateTime();

            IntPtr iResult = IntPtr.Zero;
            int lReturnedAmount = 0;

            if (sel_type.SelectedIndex == (int)MV3_TABLE_INFO.MV3_ALARM_TABLE_INFO) //alarm table
            {
                int itemSize = Marshal.SizeOf(typeof(_extra_header_t));
                iResult = Marshal.AllocHGlobal(itemSize * 16);

                result = SdkShellGetTableInfo(ptr, sel_type.SelectedIndex, out lReturnedAmount, iResult);

                for (int i = 0; i < lReturnedAmount; i++)
                {
                    _extra_header_t alarmtable = new _extra_header_t();
                    //MessageBox.Show( Marshal.SizeOf(alarmtable).ToString());
                    IntPtr ItemPtr = new IntPtr(iResult.ToInt32() + itemSize * i);
                    alarmtable = (_extra_header_t)Marshal.PtrToStructure(ItemPtr, typeof(_extra_header_t));
                    
                    bool bEmptyString = false;
                    if (Array.IndexOf(alarmtable.event_name, '\0') == 0)//added by Edward to skip unused vid items
                        bEmptyString = true;
                    if (!bEmptyString)
                    {
                        ListViewItem lvItem;
                        lvItem = GetTableListViewItem((i + 1).ToString(), new string(alarmtable.event_name), "", "");

                        object[] inputarg = new object[2];
                        inputarg[0] = lvItem;
                        inputarg[1] = table_listView;

                        table_listView.BeginInvoke(new AsyncListViewCallBack(ListViewCallBack), inputarg);
                    }
                }
                Marshal.FreeHGlobal(iResult);
            }
            else if (sel_type.SelectedIndex == (int)MV3_TABLE_INFO.MV3_VEHICLE_TABLE_INFO)  //vehicle table
            {
                int itemSize = Marshal.SizeOf(typeof(_vid_table_t));
                iResult = Marshal.AllocHGlobal(itemSize * 1024);

                result = SdkShellGetTableInfo(ptr, sel_type.SelectedIndex, out lReturnedAmount, iResult);

                for (int i = 0; i < lReturnedAmount; i++)
                {
                    _vid_table_t vidtable = new _vid_table_t();
                    //MessageBox.Show(Marshal.SizeOf(vidtable).ToString());
                    IntPtr ItemPtr = new IntPtr(iResult.ToInt32() + itemSize * i);
                    vidtable = (_vid_table_t)Marshal.PtrToStructure(ItemPtr, typeof(_vid_table_t));
                    
                    bool bEmtpyStructure = false;//added by Edward to skip unused vid items
                    if ((vidtable.start == 0) && (vidtable.end == 0) && (Array.IndexOf(vidtable.name, '\0') == 0) && (vidtable.index == 0))
                        bEmtpyStructure = true;
                    if (!bEmtpyStructure)
                    {
                        STime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)vidtable.start);
                        ETime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)vidtable.end);
                        ListViewItem lvItem;
                        lvItem = GetTableListViewItem(vidtable.index.ToString(), new string(vidtable.name), STime.ToString("yyyy/M/d HH:mm:ss tt"), ETime.ToString("yyyy/M/d HH:mm:ss tt"));

                        object[] inputarg = new object[2];
                        inputarg[0] = lvItem;
                        inputarg[1] = table_listView;

                        table_listView.BeginInvoke(new AsyncListViewCallBack(ListViewCallBack), inputarg);
                    }
                }
                Marshal.FreeHGlobal(iResult);
            }

            else if(sel_type.SelectedIndex == (int)MV3_TABLE_INFO.MV3_DayLightSaving_TABLE_INFO)
            {
                int itemSize = Marshal.SizeOf(typeof(dls2_set_t));
                iResult = Marshal.AllocHGlobal(itemSize);

                result = SdkShellGetTableInfo(ptr, sel_type.SelectedIndex, out lReturnedAmount, iResult);

                if (lReturnedAmount == 1)
                {
                    dls2_set_t DayLightSavingTable = new dls2_set_t();
                    DayLightSavingTable = (dls2_set_t)Marshal.PtrToStructure(iResult, typeof(dls2_set_t));
                    DayLightSavingForm.Show();
                    DayLightSavingForm.GetInformation(DayLightSavingTable);
                    Marshal.FreeHGlobal(iResult);
                }
                else 
                {
                    Debug.WriteLine("The returnd value of SdkShellGetTableInfo is not 1 in DayLightSaving table");
                }

            }

        }
    }
}