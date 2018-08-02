using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace UTC_MV_view
{
    public partial class XmlConfig : Form
    {
        IntPtr ptr = IntPtr.Zero;
        string str_IP = "";
        int int_port = 0;
        string str_username = "";
        string str_password = "";
        string m_XmlFilePath;
        XmlDocument XmlDoc;
        XmlUrlResolver Resolver;
        ModalType MTModalType;
        DeviceType DTDeviceType;
        private bool b_AlarmLogControl = true;
        string alarmlog_str_getXml = "";

        public XmlConfig()
        {
            InitializeComponent();
            cmbFile.SelectedIndex = 0;
            Stop_Alarmlog_btn.Enabled = false;
            XmlDoc = new XmlDocument();
        }

        private void XmlConfig_Load(object sender, EventArgs e)
        {

        }

        //HRESULT DLLAPI SdkShellInitialSource( HDevice *hDevice, DWORD dwDeviceType, DWORD dwModal, DWORD dwVersion );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitialSource(ref IntPtr hDevice, DeviceType dwDeviceType, ModalType dwModal, uint dwVersion);

        //HRESULT DLLAPI SdkShellOpenSource( HDevice hDevice, LPOPEN_DEVICE_PARAM_T stOpenParam, DWORD dwViewMode, long lParameter1 );//dwViewMode Live or playback, Parameter1:playback time
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellOpenSource(IntPtr hDevice, ref OPEN_DEVICE_PARAM_T stOpenParam, ViewType dwViewMode, int lParameter1);

        /** 
        *********************************************************************
        * @fn<eSdkShellGetHttpRequestXML>
        * @brief<This part will get XML>
        * @param[in]
        * < hDevice: select device that is used to represent a pointer >
        * < p_cpMethod: method> 
        * < p_cpRequestCGI: cgi comment>
        * < p_cpXml: size>
        * @return <string>
        *********************************************************************
        */
        //HRESULT DLLAPI SdkShellGetHttpRequestXML(HDevice hDevice, char* p_cpMethod, char* p_cpRequestCGI, IntPtr p_cpXml);//neil add 0718
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetHttpRequestXML(IntPtr hDevice, string p_cpMethod, string p_cpRequestCGI, IntPtr p_cpXml);

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

        //HRESULT DLLAPI SdkShellCloseSource( HDevice hDevice, DWORD dwModal );//dwModal??
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCloseSource(IntPtr hDevice, ModalType dwModal);

        //HRESULT DLLAPI SdkShellReleaseSource( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellReleaseSource(IntPtr hDevice);

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
        * @fn<cmbFile_SelectedIndexChanged>
        * @brief<This part will change setting cgi or xml. >
        * @param[in]
        *    none
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void cmbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFile.SelectedItem.Equals("dvr_health") || cmbFile.SelectedItem.Equals("dvr_dev_info") || 
                cmbFile.SelectedItem.Equals("alarm_log") || cmbFile.SelectedItem.Equals("get_alarm_table") ||
                cmbFile.SelectedItem.Equals("get_vid_table"))   //use cgi get
            {
                m_XmlFilePath = "/" + cmbFile.SelectedItem.ToString() + ".cgi";
                btnSet.Enabled = false;
            }
            else
            {
                m_XmlFilePath = "/" + cmbFile.SelectedItem.ToString() + ".xml";
                btnSet.Enabled = true;
            }
        }

        /** 
        *********************************************************************
        * @fn<btnGet_Click>
        * @brief<This part will get xml and inside textbox. >
        * @param[in]
        *    none
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void btnGet_Click(object sender, EventArgs e)
        {
            int result = 0;
            txtXML.Text = "";
            treeXML.Nodes.Clear();
            btnGet.Enabled = false;
            Stop_Alarmlog_btn.Enabled = false;
            b_AlarmLogControl = true;

            try
            {
                if (cmbFile.SelectedItem.Equals("dvr_health") || cmbFile.SelectedItem.Equals("dvr_dev_info") ||
                    cmbFile.SelectedItem.Equals("General") || cmbFile.SelectedItem.Equals("get_alarm_table"))   //use cgi get
                {
                    IntPtr ch_cpXml;
                    int int_size = 1024;
                    byte[] _bTemp = new byte[int_size];
                    Array.Clear(_bTemp, 0, int_size);
                    ch_cpXml = Marshal.AllocHGlobal(int_size);
                    Marshal.Copy(_bTemp, 0, ch_cpXml, int_size);                    
                    string str_cpMethod = "GET";
                    string str_cpRequestCGI = m_XmlFilePath;
                   
                    Debug.WriteLine("Address of ch_cpXml is " + ch_cpXml);
                    result = SdkShellGetHttpRequestXML(ptr, str_cpMethod, str_cpRequestCGI, ch_cpXml);
                    if (result < 0)
                    {
                        MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                        Marshal.FreeHGlobal(ch_cpXml);
                        _bTemp = null;
                        this.Close();
                        return;
                    }
                    Marshal.Copy(ch_cpXml, _bTemp, 0, int_size);
                    string str_getXml = System.Text.Encoding.Default.GetString(_bTemp);
                    XmlDoc.LoadXml(str_getXml);
                    Marshal.FreeHGlobal(ch_cpXml);
                    _bTemp = null;
                    txtXML.Text = XmlDoc.InnerXml;
                    btnGet.Enabled = true;
                }
                else if (cmbFile.SelectedItem.Equals("alarm_log"))  //use cgi get
                {
                    Stop_Alarmlog_btn.Enabled = true;
                    cmbFile.Enabled = false;
                    Thread Alarm_Log_Thread = new Thread(new ThreadStart(AlarmLog));
                    Alarm_Log_Thread.Start();
                }
                else if (cmbFile.SelectedItem.Equals("get_vid_table"))
                {
                    IntPtr ch_cpXml;
                    int int_size = 1024 * 4; //local default
                    string str_cpMethod = "GET";
                    string str_cpRequestCGI = m_XmlFilePath;
                    string str_getXml = "";

                    while (Regex.IsMatch(str_getXml, @"<progress>100</progress>") != true)
                    {
                        byte[] _bTemp = new byte[int_size];
                        Array.Clear(_bTemp, 0, int_size);
                        ch_cpXml = Marshal.AllocHGlobal(int_size);
                        Marshal.Copy(_bTemp, 0, ch_cpXml, int_size);

                        Debug.WriteLine("Address of ch_cpXml is " + ch_cpXml);
                        result = SdkShellGetHttpRequestXML(ptr, str_cpMethod, str_cpRequestCGI, ch_cpXml);
                        if (result < 0)
                        {
                            MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                            Marshal.FreeHGlobal(ch_cpXml);
                            _bTemp = null;
                            this.Close();
                            return;
                        }
                        Marshal.Copy(ch_cpXml, _bTemp, 0, int_size);
                        str_getXml = System.Text.Encoding.Default.GetString(_bTemp);
                        XmlDoc.LoadXml(str_getXml);
                        Marshal.FreeHGlobal(ch_cpXml);
                        _bTemp = null;
                        txtXML.Text = txtXML.Text + str_getXml;
                    }

                    //txtXML.Text = XmlDoc.InnerXml;
                    btnGet.Enabled = true;
                }
                else //get xml, don't use SDK
                {
                    Resolver = new XmlUrlResolver();
                    Resolver.Credentials = new NetworkCredential(str_username, str_password);
                    XmlDoc.XmlResolver = Resolver;

                    XmlDoc.Load("http://" + str_IP + m_XmlFilePath);
                    txtXML.Text = XmlDoc.InnerXml;
                    btnGet.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                btnGet.Enabled = true;
                MessageBox.Show(ex.Message, "Get Xml fail");
                return;
            }

        }

        /** 
        *********************************************************************
        * @fn<btnConvert_Click>
        * @brief<This part will get textbox value inside to treeview.>
        * @param[in]
        *    none
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void btnConvert_Click(object sender, EventArgs e)
        {
            treeXML.Nodes.Clear();

            try
            {
                XmlDoc.InnerXml = txtXML.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Convert fail");
                return;
            }

            ConvertXmlNodeToTreeNode(XmlDoc, treeXML.Nodes);
            treeXML.Nodes[0].Text = "http://" + str_IP + m_XmlFilePath;
            treeXML.Nodes[0].ExpandAll();
        }

        /** 
        *********************************************************************
        * @fn<ConvertXmlNodeToTreeNode>
        * @brief<This part will get xml tag change to treenode.>
        * @param[in]
        * < xmlNode: xml>
        * < treeNodes: treeview>
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode, TreeNodeCollection treeNodes)
        {

            TreeNode newTreeNode = treeNodes.Add(xmlNode.Name);

            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + xmlNode.Name + " " +
                      xmlNode.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    newTreeNode.Text = "<" + xmlNode.Name + ">";
                    break;
                case XmlNodeType.Attribute:
                    newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    newTreeNode.Text = xmlNode.Value;
                    break;
                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + xmlNode.Value + "-->";
                    break;
            }

            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
                }
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
            }
        }

        /** 
        *********************************************************************
        * @fn<On_XmlConfigClosing>
        * @brief<This part will Close form, close source and release source.>
        * @param[in]
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void On_XmlConfigClosing(object sender, FormClosingEventArgs e)
        {
            b_AlarmLogControl = false;
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

        /** 
        *********************************************************************
        * @fn<Stop_Alarmlog_btn_Click>
        * @brief<This part will stop get alarm log.>
        * @param[in]
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void Stop_Alarmlog_btn_Click(object sender, EventArgs e)
        {
            b_AlarmLogControl = false;
            btnGet.Enabled = true;
            cmbFile.Enabled = true;
            Stop_Alarmlog_btn.Enabled = false;
        }

        /** 
        *********************************************************************
        * @fn<AlarmLog>
        * @brief<This part will get alarm log.>
        * @param[in]
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        public void AlarmLog()
        {
            int result = 0;

            while (b_AlarmLogControl)
            {
                result = 0;
                IntPtr ch_cpXml;
                int int_size = 1024 * 4;  //local default
                string str_cpMethod = "GET";
                string str_cpRequestCGI = m_XmlFilePath;
                byte[] _bTemp = new byte[int_size];
                Array.Clear(_bTemp, 0, int_size);
                ch_cpXml = Marshal.AllocHGlobal(int_size);
                Marshal.Copy(_bTemp, 0, ch_cpXml, int_size);

                Debug.WriteLine("Address of ch_cpXml is " + ch_cpXml);
                result = SdkShellGetHttpRequestXML(ptr, str_cpMethod, str_cpRequestCGI, ch_cpXml);
                if (result < 0)
                {
                    MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                    this.BeginInvoke(new AsyncCloseForm(CloseXMLForm), null);
                    Marshal.FreeHGlobal(ch_cpXml);
                    _bTemp = null;
                    return;
                }
                Marshal.Copy(ch_cpXml, _bTemp, 0, int_size);
                //string str_getXml = System.Text.Encoding.Default.GetString(_bTemp);
                alarmlog_str_getXml = System.Text.Encoding.Default.GetString(_bTemp);
                //XmlDoc.LoadXml(str_getXml);
                
                Marshal.FreeHGlobal(ch_cpXml);
                _bTemp = null;

                this.BeginInvoke(new AsyncAlarmLog(settxtXml), null);
                Thread.Sleep(3000);
            }
            if (!b_AlarmLogControl)
                return;
        }

        private delegate void AsyncAlarmLog();
        private void settxtXml()
        {
            //txtXML.Text = XmlDoc.InnerXml;
            txtXML.Text = alarmlog_str_getXml;
        }
        private delegate void AsyncCloseForm();
        private void CloseXMLForm()
        {
            this.Close();
        }

        /** 
        *********************************************************************
        * @fn<btnSet_Click>
        * @brief<This part will set xml.>
        * @param[in]
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <void>
        *********************************************************************
        */
        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDoc.InnerXml = txtXML.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set fail");
                return;
            }

            try
            {
                int result = 0;
                IntPtr ch_cpXml;
                byte[] _bTemp = new byte[1024];
                Array.Clear(_bTemp, 0, 1024);
                ch_cpXml = Marshal.AllocHGlobal(1024);
                Marshal.Copy(_bTemp, 0, ch_cpXml, 1024);

                string str_cpMethod = "POST";
                string str_cpRequestCGI = m_XmlFilePath;
                string str_FileName = XmlDoc.InnerXml;
                string str_getXml;

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

                if (Regex.IsMatch(str_getXml, @"<result>1</result>") == true)
                {
                    MessageBox.Show("Set XML success.");
                }
                else
                {
                    MessageBox.Show("Set XML failed.");
                }

                Marshal.FreeHGlobal(ch_cpXml);
                _bTemp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set XML error.");
                return;
            }
        }
    }
}