using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;//For DLLImport
using System.Text.RegularExpressions;

namespace UTC_MV_view
{
    public partial class SystemForm : Form
    {
        public enum UpdateErrorMessage : int
        {
            OTHERS,
            UPDATE_FAIL = -1,
            OPEN_USB_FAIL = -2,
            REMOVE_USB_FAIL = -3,
            OPEN_FW_FAIL = -4,
            READ_FW_FAIL = -5,
            MAGICNUM_ERROR = -6,
            CHECKSUM_ERROR = -7,
            OPEN_MTD_FAIL = -8,
            READ_MTD_FAIL = -9,
            WRITE_MTD_FAIL = -10,
            ERASE_MTD_FAIL = -11,

        }
        //HRESULT DLLAPI SdkShellInitialSource( HDevice *hDevice, DWORD dwDeviceType, DWORD dwModal, DWORD dwVersion );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitialSource(ref IntPtr hDevice, DeviceType dwDeviceType, ModalType dwModal, uint dwVersion);

        //HRESULT DLLAPI SdkShellOpenSource( HDevice hDevice, LPOPEN_DEVICE_PARAM_T stOpenParam, DWORD dwViewMode, long lParameter1 );//dwViewMode Live or playback, Parameter1:playback time
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellOpenSource(IntPtr hDevice, ref OPEN_DEVICE_PARAM_T stOpenParam, ViewType dwViewMode, int lParameter1);

        //HRESULT DLLAPI SdkShellGetHttpRequestXML(HDevice hDevice, char* p_cpMethod, char* p_cpRequestCGI, IntPtr p_cpXml);//neil add 0718
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetHttpRequestXML(IntPtr hDevice, string p_cpMethod, string p_cpRequestCGI, IntPtr p_cpXml);

        //HRESULT DLLAPI SdkShellCloseSource( HDevice hDevice, DWORD dwModal );//dwModal??
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCloseSource(IntPtr hDevice, ModalType dwModal);

        //HRESULT DLLAPI SdkShellReleaseSource( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellReleaseSource(IntPtr hDevice);

        /** 
        *********************************************************************
        * @fn<SdkShellFWExam>
        * @brief<This Fuction will verify the binary file going to send to DVR is validated or not >
        * @param[in]
        * < hDevice: select device that is used to represent a pointer >
        * < strFileName: 1.path and filename> 
        * @return <string>
        *********************************************************************
        */
        //HRESULT DLLAPI SdkShellFWExam( HDevice hDevice, char* strFileName );//20120827 Edward add
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellFWExam(IntPtr hDevice, string strFileName);


        /** 
        *********************************************************************
        * @fn<SdkShellPostFile>
        * @brief<This part will post XML or post file>
        * @param[in]
        * < hDevice: select device that is used to represent a pointer >
        * < p_cpMethod: method> 
        * < p_cpRequestCGI: cgi comment or xml comment>
        * < p_cpXml: size>
        * < p_cpFileName: 1.path and filename 2.xml tag string> 
        * @return <string>
        *********************************************************************
        */
        //HRESULT DLLAPI SdkShellPostFile( HDevice hDevice, char* p_cpMethod, char* p_cpRequestCGI, IntPtr p_cpXml, char* p_cpFileName);//20110803 Ruby add
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellPostFile(IntPtr hDevice, string p_cpMethod, string p_cpRequestCGI, IntPtr p_cpXml, string p_cpFileName);
        
        /// Open device param structure
        /// (for sdk function parameters)
        /// </summary>
        public struct OPEN_DEVICE_PARAM_T
        {
            /// DWORD->unsigned int
            public DeviceType dwDeviceType;

            /// DWORD->unsigned int
            public ModalType dwModal;

            //CONNECT_PARAM_T->CONNECT_PARAM_T
            public CONNECT_PARAM_T mDvrParam;

            /// DWORD->unsigned int
            public uint dwDiskID;

            /// char[512]
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string szFileName;
        }

        IntPtr ptr = IntPtr.Zero;
        string str_IP = "";
        int int_port = 0;
        string str_username = "";
        string str_password = "";
        XmlDocument XmlDoc;
        ModalType MTModalType;
        DeviceType DTDeviceType;

        public SystemForm()
        {
            InitializeComponent();
            XmlDoc = new XmlDocument();
        }

        private void BtnFwBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelFileDlg = new OpenFileDialog();
            SelFileDlg.Filter = "MV3 Firmware Files (*.bin)|*.bin|All Files (*.*)|*.*";
            DialogResult result = SelFileDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                edFwFilePath.Text = SelFileDlg.FileName;
            }
        }

        public void Initialshell_Source()
        {
            int result;
            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(MTModalType);

            result = SdkShellInitialSource(ref ptr, DTDeviceType, stOpenParam.dwModal, 0);
            result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.NONE, 0);
        }

        public void GetFormValue(string str_IP_Form1, int int_port_Form1, string str_username_Form1, string str_password_Form1)
        {
            str_IP = str_IP_Form1;
            int_port = int_port_Form1;
            str_username = str_username_Form1;
            str_password = str_password_Form1;
            MTModalType = ModalType.MV_DVR;
            DTDeviceType = DeviceType.DEVICE_DVR;
            Initialshell_Source();
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
            else
                MessageBox.Show("Device type error!!!");

            return stOpenParam;
        }

        /** 
        *********************************************************************
        * @fn<SystemFormClosing>
        * @brief<This part will Close form, close source and release source.>
        * @param[in]
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void SystemFormClosing(object sender, FormClosingEventArgs e)
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

        private void btnFwUpgrade_Click(object sender, EventArgs e)
        {

            if (edFwFilePath.Text != "")
            {
                try
                {
                    int result = 0;
                    IntPtr ch_cpXml;
                    byte[] _bTemp = new byte[1024];
                    Array.Clear(_bTemp, 0, 1024);
                    ch_cpXml = Marshal.AllocHGlobal(1024);
                    Marshal.Copy(_bTemp, 0, ch_cpXml, 1024);

                    string str_cpMethod = "POST";
                    string str_cpRequestCGI = "/FW_Upgrade.cgi";
                    string str_FileName = edFwFilePath.Text;
                    string str_getXml;
                         
                    //added by Edward in 20120827 for binary file exam
                    result = SdkShellFWExam(ptr, str_FileName);
                    if (result != 0)
                    {
                        MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                        Marshal.FreeHGlobal(ch_cpXml);
                        _bTemp = null;
                        this.Close();
                        return;

                    }
                    result = SdkShellPostFile(ptr, str_cpMethod, str_cpRequestCGI, ch_cpXml, str_FileName);
                    if (result < 0)
                    {
                        MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                        Marshal.FreeHGlobal(ch_cpXml);
                        _bTemp = null;
                        this.Close();
                        return;
                    }
                    Marshal.Copy(ch_cpXml, _bTemp, 0, 1024);
                    str_getXml = System.Text.Encoding.Default.GetString(_bTemp);
                    pgsBarFw.Value = 0;
                    txtFirmware.Text = "Upgrade 0%";
                    panelPgsFw.Visible = true;

                    //Updata error message 
                    for (int r = -1; r >= -12; r--)
                    {
                        if (Regex.IsMatch(str_getXml, "<result>" + r + "</result>") == true)
                        {
                            MessageBox.Show(Enum.Parse(typeof(UpdateErrorMessage), r.ToString()).ToString());
                            return;
                        }
                    }

                    // If the upload file is valid, DVR will response "<script>parent.startFwUpload();</script>\n",
                    // and you can start to ask the upload/upgrade status.
                    // Else, response "<script>parent.fwUploadFail();</script>\n".

                    if (Regex.IsMatch(str_getXml, @"parent.startFwUpload") == true)
                    {
                        FwUpgradeTimer.Start();
                    }
                    else
                    {
                        panelPgsFw.Visible = false;
                        MessageBox.Show("File submit failed.");
                    }

                    Marshal.FreeHGlobal(ch_cpXml);
                    _bTemp = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Upgrade firmware error.");
                    FwUpgradeTimer.Stop();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a file.");
            }
        }

        private void FwUpgradeTimer_Tick_1(object sender, EventArgs e)
        {
            try
            {
                int nProgress;
                int result = 0;
                IntPtr ch_cpXml;
                byte[] _bTemp = new byte[1024];
                Array.Clear(_bTemp, 0, 1024);
                ch_cpXml = Marshal.AllocHGlobal(1024);
                Marshal.Copy(_bTemp, 0, ch_cpXml, 1024);
                string str_cpMethod = "GET";
                string str_cpRequestCGI = "/FW_Upgrade.cgi?cmd=fw_upgrade_status";

                Console.WriteLine("Address of ch_cpXml is " + ch_cpXml);
                result = SdkShellGetHttpRequestXML(ptr, str_cpMethod, str_cpRequestCGI, ch_cpXml);
                if (result < 0)
                {
                    MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                    Marshal.FreeHGlobal(ch_cpXml);
                    _bTemp = null;
                    this.Close();
                    return;
                }
                Marshal.Copy(ch_cpXml, _bTemp, 0, 1024);
                string str_getXml = System.Text.Encoding.Default.GetString(_bTemp);
                XmlDoc.LoadXml(str_getXml);
                string strValue = XmlDoc.GetElementsByTagName("result").Item(0).InnerXml;
                nProgress = Convert.ToInt32(strValue);
                Marshal.FreeHGlobal(ch_cpXml);
                _bTemp = null;

                if (nProgress >= 100) // upgrade finish
                {
                    pgsBarFw.Value = 100;
                    txtFirmware.Text = "Upgrade 100%";

                    FwUpgradeTimer.Stop();

                    MessageBox.Show("Upgrade succeeded!\r\nThe DVR will reboot. Please reconnect it latter.");
                    panelPgsFw.Visible = false;
                }
                else if (nProgress < 0)
                {
                    FwUpgradeTimer.Stop();

                    MessageBox.Show("Upgrade failed!");
                    panelPgsFw.Visible = false;
                }
                else
                {
                    pgsBarFw.Value = nProgress;
                    txtFirmware.Text = "Upgrade " + nProgress + "%";
                }
            }
            catch (Exception ex)
            {
               FwUpgradeTimer.Stop();

               MessageBox.Show(ex.Message, "Upgrade firmware error(timer).");
            }
        }

    }
}