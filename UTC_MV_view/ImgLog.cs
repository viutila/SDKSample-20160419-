using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace UTC_MV_view
{
    public partial class ImgLog : Form
    {
        OPEN_DEVICE_PARAM_T stImgLogParam;

        private CheckBox[] cb_CamArr = new System.Windows.Forms.CheckBox[12];

        //HRESULT DLLAPI SdkShellInitialSource( HDevice *hDevice, DWORD dwDeviceType, DWORD dwModal, DWORD dwVersion );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitialSource(ref IntPtr hDevice, DeviceType dwDeviceType, ModalType dwModal, uint dwVersion);

        //HRESULT DLLAPI SdkShellOpenSource( HDevice hDevice, LPOPEN_DEVICE_PARAM_T stOpenParam, DWORD dwViewMode, long lParameter1 );//dwViewMode Live or playback, Parameter1:playback time
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellOpenSource(IntPtr hDevice, ref OPEN_DEVICE_PARAM_T stOpenParam, ViewType dwViewMode, int lParameter1);

        // HRESULT DLLAPI SdkShellFileTrans( char* pInputFile, long lInputType, char* pOutputFile, long lOutputType, long lChannel, long lStartTime, long lEndTime ,, HWND hWnd);
        [DllImportAttribute("SdkShell.dll")]
        //private static extern int SdkShellFileTrans(string pInputFile, int lInputType, string pOutputFile, int lOutputType, int lChannel, int lStartTime, int lEndTime, HWND hWnd);
        private static extern int SdkShellFileTrans(IntPtr hDevice, string pInputFile, int lInputType, string pOutputFile, int lOutputType, int lChannel, int lStartTime, int lEndTime, UInt32 uiPicLimit, IntPtr hWnd);

        // HRESULT DLLAPI SdkShellCancelTrans(long lInputType, long lOutputType);
        [DllImportAttribute("SdkShell.dll")]
        //private static extern int SdkShellCancelTrans(long lInputType, long lOutputType);
        private static extern int SdkShellCancelTrans(IntPtr hDevice, int lInputType, int lOutputType);

        //HRESULT DLLAPI SdkShellCloseSource( HDevice hDevice, DWORD dwModal );//dwModal??
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCloseSource(IntPtr hDevice, ModalType dwModal);

        //HRESULT DLLAPI SdkShellReleaseSource( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellReleaseSource(IntPtr hDevice);
        
        IntPtr ImgLogPtr;
        public ImgLog()
        {
            InitializeComponent();

            // camera array
            cb_CamArr[0] = CameraCB1;
            cb_CamArr[1] = CameraCB2;
            cb_CamArr[2] = CameraCB3;
            cb_CamArr[3] = CameraCB4;
            cb_CamArr[4] = CameraCB5;
            cb_CamArr[5] = CameraCB6;
            cb_CamArr[6] = CameraCB7;
            cb_CamArr[7] = CameraCB8;
            cb_CamArr[8] = CameraCB9;
            cb_CamArr[9] = CameraCB10;
            cb_CamArr[10] = CameraCB11;
            cb_CamArr[11] = CameraCB12;
            ImgLogPtr = IntPtr.Zero;
            OPEN_DEVICE_PARAM_T stImgLogParam;

        }


        /** 
        *********************************************************************
        * @fn<IMGLOG_Click>
        * @brief<This part will save all I frames from a .avr file>
        * <In this function, user have to give the limitation of time span and name and path of jpg file>
        * <If we use the functionality of image log, the starttime should be 0 and the end should be the limitation of time span>
        * <Give the outputstring not only file path but also file name you want. SDK will append channel number and series number after that>
        * <The limit of total of JPGs in each channel is 9999. Once the total amount is larger than it, SDK will overwrite>
        * @param[in]
        * <check the comment under SdkShellFileTrans for the infomation of input parameter>
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        * 
        * 
        *********************************************************************
        */

        private OPEN_DEVICE_PARAM_T CreateDeviceParamImgLog(ModalType _mtSelectedType)
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
                //conn_param.device.mv.szUrl = str_IP;
                //conn_param.device.mv.usWebPort = (ushort)Math.Min(ushort.MaxValue, int_port);
                //conn_param.device.mv.szUID = str_username;
                //conn_param.device.mv.szPWD = str_password;

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

        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            //Use Camera Penel on Form1 to select camera mask
            //If the selected camera mask is not the subset of video's camera mask, SDK function will return it without processing video to image
            int lChannel = 0;
            for (int i = 0; i < 12; i++)
            {
                lChannel += (cb_CamArr[i].Checked ? 1 : 0) << i;
            }
            //If the time span of opened video is larger than defined time span, SDK function will return it without processing video to image
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int playTime = (int)((StartTimePicker.Value.Ticks - BaseTime.Ticks) / 10000000); // Start time
            int lStartTime = playTime;
            playTime = (int)((EndTimePicker.Value.Ticks - BaseTime.Ticks) / 10000000); // End time
            int lEndTime = playTime;
            UInt32 uiInterval = Convert.ToUInt32( IntervalTB.Text);
            string outputstring = "";//New ImgLog do not need outputstring
            IntPtr NullHandle = IntPtr.Zero;//New ImgLog do not need window handle

            ConvertOldBtn.Enabled = false;
            CancelOldBtn.Enabled = false;
            ConvertBtn.Enabled = false;
            //This function will need a window handle to process video frames, user should give this function a window handle.
            //This window can be a small and invisible one like what we do in this sample
            //The progress will be shown in the callback function StatusCallbackMethod
            //AsyncFileTrans asyncFileTrans = new AsyncFileTrans(FileTransNew);
            //asyncFileTrans.BeginInvoke(inputstring, outputstring, lChannel, lStartTime, lEndTime, uiInterval, NullHandle, null, null); 
            string inputstring = stImgLogParam.szFileName;
            int iResult = 0;
            iResult = SdkShellFileTrans(ImgLogPtr, inputstring, (int)MediaType.MEDIA_MV3, outputstring, (int)MediaType.NEW_MEDIA_IMGLOG, lChannel, lStartTime, lEndTime, uiInterval, NullHandle);
            if (iResult < 0)
            {
                //ImgLogPtr = IntPtr.Zero;
                SdkShellCancelTrans(ImgLogPtr ,(int)MediaType.MEDIA_MV3, (int)MediaType.NEW_MEDIA_IMGLOG);
                Console.WriteLine("SdkShellFileTrans failed " + iResult);
                ConvertOldBtn.Enabled = true;
                CancelOldBtn.Enabled = true;
                ConvertBtn.Enabled = true;
            }

        }

        private void ConvertOldBtn_Click(object sender, EventArgs e)
        {
            //Use Camera Penel on Form1 to select camera mask
            //If the selected camera mask is not the subset of video's camera mask, SDK function will return it without processing video to image
            int lChannel = 0;
            for (int i = 0; i < 8; i++)
            {
                lChannel += (cb_CamArr[i].Checked ? 1 : 0) << i;
            }
            //If the time span of opened video is larger than defined time span, SDK function will return it without processing video to image
            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int playTime = (int)((StartTimePicker.Value.Ticks - BaseTime.Ticks) / 10000000); // Start time
            int lStartTime = playTime;
            playTime = (int)((EndTimePicker.Value.Ticks - BaseTime.Ticks) / 10000000); // End time
            int lEndTime = playTime;
            UInt32 uiInterval = Convert.ToUInt32(IntervalTB.Text);
            string outputstring = "";//New ImgLog do not need window handle
            IntPtr NullHandle = IntPtr.Zero;//New ImgLog do not need window handle
            
            ConvertOldBtn.Enabled = false;
            ConvertBtn.Enabled = false;
            CancelNewBtn.Enabled = false;
            string inputstring = stImgLogParam.szFileName;
            outputstring = System.AppDomain.CurrentDomain.BaseDirectory;
            outputstring += "IMGLOG/.jpg";

            //This function will need a window handle to process video frames, user should give this function a window handle.
            //This window can be a small and invisible one like what we do in this sample
            //The progress will be shown in the callback function StatusCallbackMethod
            int iResult = 0;
            iResult = SdkShellFileTrans(ImgLogPtr ,inputstring, (int)MediaType.MEDIA_MV3, outputstring, (int)MediaType.MEDIA_IMGLOG, lChannel, lStartTime, lEndTime, uiInterval, NullHandle);
            if (iResult < 0)
            {
                SdkShellCancelTrans(ImgLogPtr, (int)MediaType.MEDIA_MV3, (int)MediaType.MEDIA_IMGLOG);
                Console.WriteLine("SdkShellFileTrans failed " + iResult);
                //ImgLogPtr = IntPtr.Zero;
                ConvertOldBtn.Enabled = true;
                ConvertBtn.Enabled = true;
                CancelNewBtn.Enabled = true;
            }

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            //SdkShellCancelTrans(ImgLogPtr, (int)MediaType.MEDIA_MV3, (int)MediaType.MEDIA_IMGLOG);
            //SdkShellCancelTrans(ImgLogPtr, (int)MediaType.MEDIA_MV3, (int)MediaType.NEW_MEDIA_IMGLOG);
            SdkShellCloseSource(ImgLogPtr, ModalType.MV_IMAGE);
            SdkShellReleaseSource(ImgLogPtr);
        }

        private void CancelOldBtn_Click(object sender, EventArgs e)
        {
            SdkShellCancelTrans( ImgLogPtr, (int)MediaType.MEDIA_MV3, (int)MediaType.MEDIA_IMGLOG);
            ConvertOldBtn.Enabled = true;
        }

        private void CancelNewBtn_Click(object sender, EventArgs e)
        {
            SdkShellCancelTrans( ImgLogPtr, (int)MediaType.MEDIA_MV3, (int)MediaType.NEW_MEDIA_IMGLOG);
            ConvertBtn.Enabled = true;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();
            path.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.*";
            if (path.ShowDialog() == DialogResult.OK)
            {
                string inputstring = path.FileName.ToString();
                //This function will need a window handle to process video frames, user should give this function a window handle.
                //This window can be a small and invisible one like what we do in this sample
                //The progress will be shown in the callback function StatusCallbackMethod
                //AsyncFileTrans asyncFileTrans = new AsyncFileTrans(FileTransNew);
                //asyncFileTrans.BeginInvoke(inputstring, outputstring, lChannel, lStartTime, lEndTime, uiInterval, NullHandle, null, null); 

                stImgLogParam = CreateDeviceParamImgLog(ModalType.MV_IMAGE);
                stImgLogParam.szFileName = inputstring;
                int iResult = 0;
                iResult = SdkShellInitialSource(ref ImgLogPtr, DeviceType.DEVICE_FILE, stImgLogParam.dwModal, 0);
                iResult = SdkShellOpenSource(ImgLogPtr, ref stImgLogParam, ViewType.IMGLOG, 0);

                if (iResult < 0)
                {
                    MessageBox.Show("FileOpen Fail");
                }
            }
            else
                MessageBox.Show("No File has been selected");
        }

    }

}