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
    public partial class HDDLog : Form
    {
        uint uint_HDDNo;
        IntPtr ptr = IntPtr.Zero;
        DeviceType DTDeviceType;
        ModalType MTModalType;
        string str_IP = "";
        int int_port = 0;
        string str_username = "";
        string str_password = "";


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


        /*********************************************************************
        * @fn<SdkShellGetLogFromHDD>
        * @brief<This part will archive HDD log from HDD by selected time span>
        * @param[in]
        * < hDevice:file path of .avr file>
        * < pFileName: file path of log file> 
        * < uStartTime:Start Time >
        * < uEndTime: End Time>
        * < sLogType: 0 means .rtf file. 1 means .csv file> 
        * < TimeFormat: Time format of LOG_SYS_TIME_CHG and LOG_SYS_GPS_SYNC_ERROR entry. 0 is "%I:%M:%S %p". 1 is "%H:%M:%S".>
        * < DateFormat: Date format of LOG_SYS_TIME_CHG and LOG_SYS_GPS_SYNC_ERROR entry. 0 is "%d/%m/%Y". 1 is "%Y/%m/%d". 2 is "%m/%d/%Y">
        * @return <EFRESULT >
        *********************************************************************
        */
        //added by 20130717 Edward for archivie HDD log from HDD
        //EFRESULT _stdcall SdkShellGetLogFromHDD(HDevice hDevice, char* p_filename, unsigned int uStartTime, unsigned int uEndTime, short sLogType, int TimeFormat, int DateFormat);
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetLogFromHDD(IntPtr hDevice, string pFileName, uint uStartTime, uint uEndTime, short sLogType, int TimeFormat, int DateFormat);

        public HDDLog()
        {
            InitializeComponent();
            TimeFormatcb.SelectedIndex = 0;
            DateFormatcb.SelectedIndex = 0;
        }

        public void Initialshell_Source()
        {
            int result;
            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(MTModalType);
            if (MTModalType == ModalType.MV_HDD)
                stOpenParam.dwDiskID = uint_HDDNo;
            else if (MTModalType == ModalType.MV_IMAGE)
            {
                MessageBox.Show("Error Device Type");
                    return;
            }
            else
            {
                MessageBox.Show("Error Device Type");
                return;
            }

            //Initial shell and Source
            result = SdkShellInitialSource(ref ptr, DTDeviceType, stOpenParam.dwModal, 0);
            result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.NONE, 0);
            if (result < 0)
                MessageBox.Show("Open archive log from HDD fail");
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




        public void GetHDDValue(uint _iHddNo)
        {
            uint_HDDNo = _iHddNo;
            DTDeviceType = DeviceType.DEVICE_HDD;
            MTModalType = ModalType.MV_HDD;
            Initialshell_Source();
        }

        private void HDDLogbtn_Click(object sender, EventArgs e)
        {

            HDDLogbtn.Enabled = false;
            int result = 0; 
            SaveFileDialog path = new SaveFileDialog();
            if (RTF_radio.Checked)
                path.Filter = "RTF files(*.rtf)|*.rtf|All files (*.*)|*.*";//Filename Extension
            else
                path.Filter = "CSV files(*.csv)|*.csv|All files (*.*)|*.*";//Filename Extension

            short sLogType = 0;
            int iTimeFormat = 0;
            int iDateFormat = 0;
            uint uiStartTime = 0;
            uint uiEndTime = 0;

            if (path.ShowDialog() == DialogResult.OK)
            {

                if (RTF_radio.Checked)
                    sLogType = 0;
                else
                    sLogType = 1;

                iTimeFormat = TimeFormatcb.SelectedIndex;
                iDateFormat = DateFormatcb.SelectedIndex;

                DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
                uiStartTime = (uint)((StartTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time

                BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
                uiEndTime = (uint)((EndTimePicker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time

                result = SdkShellGetLogFromHDD(ptr, path.FileName, uiStartTime, uiEndTime, sLogType, iTimeFormat, iDateFormat);
                //result = SdkShellGetLogFromHDD(Logptr, path.FileName , 0 ,0X7fffffff, 0, 0, 0);
                if (result < 0)
                    MessageBox.Show("Archive log from HDD fail");

            }
            else
                return;

            HDDLogbtn.Enabled = true;
            return;
        }

        private void On_HDDLog_Closing(object sender, FormClosingEventArgs e)
        {
            int result = 0;
            result = SdkShellCloseSource(ptr, ModalType.MV_HDD);
            result = SdkShellReleaseSource(ptr);
            if (result < 0)
                MessageBox.Show("Close archive log from HDD fail");

        }
    }
}