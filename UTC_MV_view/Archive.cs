using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace UTC_MV_view
{
    public partial class Archive : Form
    {
        OPEN_DEVICE_PARAM_T stArchiveParam;
        //DeviceType ArchiveDT;
        //ModalType ArchiveMT;

        IntPtr ptr = IntPtr.Zero;
        IntPtr phRender = IntPtr.Zero;
        private CheckBox[] cb_CamArr = new System.Windows.Forms.CheckBox[12];//camera checkbox
        int cameramask;//convert current CH number to bit mask
        uint uiAudioTag;
        int int_starttime;
        int int_endtime;
        bool completeflag = true;//use to detect the archive is finish or not
        //public CallbackClass class_callback;
        string txtPath;
        uint ulFileSize;
        uint ulBlockID = 0xffffffff;

        //HRESULT DLLAPI SdkShellInitial( long lMaxCh );//nMaxCh for videoWindow
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitial(int nMaxCh);

        //HRESULT DLLAPI SdkShellInitialSource( HDevice *hDevice, DWORD dwDeviceType, DWORD dwModal, DWORD dwVersion );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitialSource(ref IntPtr hDevice, DeviceType dwDeviceType, ModalType dwModal, uint dwVersion);

        //HRESULT DLLAPI SdkShellOpenSource( HDevice hDevice, LPOPEN_DEVICE_PARAM_T stOpenParam, DWORD dwViewMode, long lParameter1 );//dwViewMode Live or playback, Parameter1:playback time
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellOpenSource(IntPtr hDevice, ref OPEN_DEVICE_PARAM_T stOpenParam, ViewType dwViewMode, int lParameter1);

        //HRESULT DLLAPI SdkShellArchive( HDevice hDevice, DWORD dwChannelMap, long lStartTime, long lEndTime, char* pFileName, DWORD dwMaxFileSize, DWORD lBlockID); //neil add lBlockID
        //SdkShellArchive is used to archive files from DVR or HDD
        //hDevice: Pointer of selected device 
        //dwChannelMap: camera map
        //lStartTime: start time
        //lEndTime: end time
        //pFileName: file path and file name 
        //dwMaxFileSize: Use to define max file size. default:0
        //lBlockID: for archive resume 
        //bPartialArchive:Enabling Partial Archive means archive will refer to the lBlockID and start to archive video from certain lBlockID  
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellArchive(IntPtr hDevice, uint dwChannelMap, uint dwAudioTag,int lStartTime, int lEndTime, string pFileName, uint dwMaxFileSize, uint lBlockID, bool bPartialArchive);

        //HRESULT DLLAPI SdkShellCancelArchive( HDevice hDevice );

        [DllImportAttribute("SdkShell.dll")]
        //SdkShellCancelArchive is used to cancel archive
        //hDevice: the pointer of selected device
        private static extern int SdkShellCancelArchive(IntPtr hDevice);

        //HRESULT DLLAPI SdkShellCloseSource( HDevice hDevice, DWORD dwModal );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCloseSource(IntPtr hDevice, ModalType dwModal);

        //HRESULT DLLAPI SdkShellReleaseSource( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellReleaseSource(IntPtr hDevice);

        //HRESULT DLLAPI SdkShellRelease();
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellRelease();

        public Archive()
        {
            InitializeComponent();

            //Express as utc Time
            DateTime CurrentLocalTime = DateTime.Now;
            DateTime CurrentUTCTime = CurrentLocalTime.ToUniversalTime();
            StartTime_Picker.Value = CurrentUTCTime;
            EndTime_Picker.Value = CurrentUTCTime;
            ResumeArchive_btn.Enabled = false;
        }

        private void Archive_Load(object sender, EventArgs e)
        {

        }

        public void Initialshell_Source()
        {
            int result;
            result = SdkShellInitialSource(ref ptr, stArchiveParam.dwDeviceType, stArchiveParam.dwModal, 0);
            result = SdkShellOpenSource(ptr, ref stArchiveParam, ViewType.ARCHIVE, 0);
        }

        /** 
        *********************************************************************
        * @fn<ArchiveStartbtn_Click>
        * @brief<This function will use _stOpenParam as an input parameter.>
        * <This structure contains device information that SdkShell will needed>
        * @param[in]
        *    none
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        public void GetFormValue(OPEN_DEVICE_PARAM_T _stOpenParam)
        {
            stArchiveParam = _stOpenParam;
            //ArchiveDT=stArchiveParam.dwDeviceType;
            if (stArchiveParam.dwDeviceType == DeviceType.DEVICE_DVR)
                Sele_DeviceType.Text = "DVR";
            else if (stArchiveParam.dwDeviceType == DeviceType.DEVICE_HDD)
            {
                Sele_DeviceType.Text = "HDD";
                ResumeArchive_btn.Enabled = false;
            }

            Initialshell_Source();
        }
        public bool getArchiveType()
        {
            //camera array
            cb_CamArr[0] = Camera_cb1;
            cb_CamArr[1] = Camera_cb2;
            cb_CamArr[2] = Camera_cb3;
            cb_CamArr[3] = Camera_cb4;
            cb_CamArr[4] = Camera_cb5;
            cb_CamArr[5] = Camera_cb6;
            cb_CamArr[6] = Camera_cb7;
            cb_CamArr[7] = Camera_cb8;
            cb_CamArr[8] = Camera_cb9;
            cb_CamArr[9] = Camera_cb10;
            cb_CamArr[10] = Camera_cb11;
            cb_CamArr[11] = Camera_cb12;

            cameramask = 0;
            for (int i = 0; i < 12; i++)
            {
                if (MainStream.Checked)
                    cameramask += (cb_CamArr[i].Checked ? 1 : 0) << i;
                else if (SubStream.Checked) //^^
                    cameramask += (cb_CamArr[i].Checked ? 1 : 0) << i + 16;
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (cameramask == 0)
            {
                MessageBox.Show("Please select camera");
                return false;
            }

            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
            int_starttime = (int)((StartTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            int_endtime = (int)((EndTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
            uiAudioTag = Convert.ToUInt32(AudioTag_tb.Text);

            if (int_starttime >= int_endtime)
            {
                MessageBox.Show("Time fail");
                return false;
            }

            return true;
        }

        /** 
        *********************************************************************
        * @fn<ArchiveStartbtn_Click>
        * @brief<This part will be used to start archive. In this function,We will new a save file dialog and an archive thread>
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
        private void ArchiveStartbtn_Click(object sender, EventArgs e)
        {

            Console.WriteLine("(Archive test) ArchiveStartbtn pressed");
            //int result = 0;
            ArchiveBar.Value = 0;
            ResumeArchive_btn.Enabled = false;
            completeflag = false;
            SaveFileDialog path = new SaveFileDialog();
            path.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.*";
            ulFileSize = Convert.ToUInt32(tbFileSize.Text);
            if (ulFileSize < 512 || ulFileSize > 2048)
            {
                MessageBox.Show("File Size should be between 512MB to 2GB");
                return;
            }
            cameramask = 0;
            if (!getArchiveType())
                return;

            if (path.ShowDialog() == DialogResult.OK)
            {
                ArchiveStartbtn.Enabled = false;
                txtPath = path.FileName.ToString();

                //class_callback = new CallbackClass();
                //CallbackType _SeleCallbackType = CallbackType.STATUS_ARCHIVE;
                //class_callback.StatusCallback_assign(_SeleCallbackType, ptr);
                //class_callback.m_StatusCallback.UploadData += new EventHandler(Update_ArchiveProgress);
                AsyncArchiveStart asyArchiveStart = new AsyncArchiveStart(AsyncArchive);
                asyArchiveStart.BeginInvoke(null, null);

                //ThreadStart asyncArchiveStart = new ThreadStart(AsyncArchive);
                //Thread asyncArchiveThread = new Thread(asyncArchiveStart);
                //asyncArchiveThread.Start();
            }
            else
                return;

            path.Dispose();
            Console.WriteLine("(Archive test) ArchiveStartbtn End");
        }

        /** 
        *********************************************************************
        * @fn<PartailArchive_Change>
        * @brief<This part will enable ResumeArchive_btn and get file path if partial archive is enable>
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
        private void PartailArchive_Change(object sender, EventArgs e)
        {
            string FileExten = "";
            string FileDirect = "";
            string FileName = "";
            string RootName = "";

            if (PartialArchive_cb.Checked)
            {
                ResumeArchive_btn.Enabled = true;
                ulFileSize = Convert.ToUInt32(tbFileSize.Text);
                if (ulFileSize < 512 || ulFileSize > 2048)
                {
                    MessageBox.Show("File Size should be between 512MB to 2GB");
                    return;
                }
                SaveFileDialog path = new SaveFileDialog();
                path.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.*";
                if (path.ShowDialog() == DialogResult.OK)
                {

                    RootName = Path.GetPathRoot(path.FileName.ToString());
                    FileExten = Path.GetExtension(path.FileName.ToString());
                    FileDirect = Path.GetDirectoryName(path.FileName.ToString());
                    FileName = Path.GetFileNameWithoutExtension(path.FileName.ToString());
                    if (RootName == FileDirect)
                        FilePath_txt.Text = FileDirect + FileName + "B" + FileExten;
                    else
                        FilePath_txt.Text = FileDirect + "\\" + FileName + "B" + FileExten;
                    //FilePath_txt.Text = path.FileName.ToString();
                }
                else
                    return;
            }
            else
            {
                ResumeArchive_btn.Enabled = false;
            }
            return;
        }

        /** 
        *********************************************************************
        * @fn<AsyncArchive>
        * @brief<This part will be used to initial shell and Source and new an EventHandler for callback function to trigger>
        * <In this function, SdkShellArchive will be used. The needed information will be assigned as input parameters>
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

        private delegate void AsyncArchiveStart();
        private void AsyncArchive()
        {
            int result;

            //result = SdkShellInitialSource(ref ptr, stArchiveParam.dwDeviceType, stArchiveParam.dwModal, 0);

            ////class_callback = new CallbackClass();

            //result = SdkShellOpenSource(ptr, ref stArchiveParam, ViewType.ARCHIVE, 0);

            //CallbackType _SeleCallbackType = CallbackType.STATUS_ARCHIVE;
            //class_callback.StatusCallback_assign(_SeleCallbackType, ptr);
            //class_callback.m_StatusCallback.UploadData += new EventHandler(Update_ArchiveProgress);
            //We suggest the smallest unit should be 512MB
            result = SdkShellArchive(ptr, (uint)cameramask, uiAudioTag, int_starttime, int_endtime, txtPath, ulFileSize, ulBlockID, PartialArchive_cb.Checked);
            ulBlockID = 0xffffffff;
            //cameramask = 0;
            if (result < 0)
            {
                Console.WriteLine("(Archive test) result is < 0");
                MessageBox.Show("Archive error");
                completeflag = true;//must set completeflag before cancel
                ArchiveBar.Value = 0;
                ArchiveStartbtn.Enabled = true;
                ResumeArchive_btn.Enabled = false;
                return;
            }
        }

        /** 
        *********************************************************************
        * @fn< Update_ArchiveProgress>
        * @brief<This function will used UI thread to operate the function "getProgress">
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
        //void Update_ArchiveProgress(object sender, EventArgs e)
        //{
        //    this.BeginInvoke(new AsyncWriteupdata(getProgress), null);
        //}
        //public delegate void AsyncWriteupdata();
        public int getProgress(int _iCurrentProgress, bool bArchiveEnd)
        {
            //show archive progress
            ArchiveBar.Value = _iCurrentProgress;
            if (bArchiveEnd == true)
            {
                completeflag = true;
                //if progress equal to 100, turn off EventHandler and enable ArchiveStartbtn
                MessageBox.Show("Archive complete");
                ArchiveBar.Value = 0;
                ArchiveStartbtn.Enabled = true;
                if (_iCurrentProgress < 100)
                    ResumeArchive_btn.Enabled = true;
                else
                    ResumeArchive_btn.Enabled = false;
            }

            return 0;
        }
        /** 
        *********************************************************************
        * @fn< ArchiveCancelbtn_Click>
        * @brief<This function will cancel archive by SdkShellCancelArchive>
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
        private void ArchiveCancelbtn_Click(object sender, EventArgs e)
        {
            int result = 0;
            completeflag = true;//must set completeflag before cancel
            result = SdkShellCancelArchive(ptr);
            if (result == 0)
            {
                ArchiveBar.Value = 0;
                ArchiveStartbtn.Enabled = true;
                //ResumeArchive_btn.Enabled = false;
            }
            else
            {
                MessageBox.Show("Archive Cancel Failed");
            }

        }

        private void On_ArchiveFormClosing(object sender, FormClosingEventArgs e)
        {
            int ptr_value = ptr.ToInt32();
            if (ptr_value != 0)
            {
                if (stArchiveParam.dwModal == ModalType.MV_DVR)
                    SdkShellCloseSource(ptr, ModalType.MV_DVR);
                else if (stArchiveParam.dwModal == ModalType.MV_HDD)
                    SdkShellCloseSource(ptr, ModalType.MV_HDD);
                else if (stArchiveParam.dwModal == ModalType.MV_IMAGE)
                    SdkShellCloseSource(ptr, ModalType.MV_DVR);
                else
                    SdkShellCloseSource(ptr, ModalType.MV_DVR);

                SdkShellReleaseSource(ptr);
            }
            ptr = IntPtr.Zero;
        }

        /** 
        *********************************************************************
        * @fn<setResumeFilePath>
        * @brief<Return file path using the callback method.>
        * 
        * @param[in]
        * <path: FilePath>
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        public void setResumeFilePath(string path)
        {
            FilePath_txt.Clear();
            FilePath_txt.Text = path;
        }

        /** 
        *********************************************************************
        * @fn<setLastBlockID>
        * @brief<Return block ID using the callback method.>
        * 
        * @param[in]
        * <id: BlockID>
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        public void setLastBlockID(string id)
        {
            LastBlockID_txt.Clear();
            LastBlockID_txt.Text = id;
        }

        public void EnableReusme()
        {
            ResumeArchive_btn.Enabled = true;
        }

        /** 
        *********************************************************************
        * @fn<ResumeArchive_btn_Click>
        * @brief<This part will be used to resume archive.>
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
        private void ResumeArchive_btn_Click(object sender, EventArgs e)
        {
            cameramask = 0;
            if (FilePath_txt.Text == "")
            {
                MessageBox.Show("File Path fail");
                return;
            }
            else if (LastBlockID_txt.Text == "")
            {
                MessageBox.Show("Last Block ID");
                return;
            }

            if (!getArchiveType())
                return;

            ulFileSize = Convert.ToUInt32(tbFileSize.Text);
            if (ulFileSize < 512 || ulFileSize > 2048)
            {
                MessageBox.Show("File Size should be between 512MB to 2GB");
                return;
            }
            txtPath = FilePath_txt.Text.ToString();
            ulBlockID = Convert.ToUInt32(LastBlockID_txt.Text);
            AsyncArchiveStart asyArchiveStart = new AsyncArchiveStart(AsyncArchive);
            asyArchiveStart.BeginInvoke(null, null);
        }
    }
}