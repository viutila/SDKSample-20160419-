using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;



namespace UTC_MV_view
{
    /// <summary>
    /// Status call back type
    /// </summary>
    enum StatusCallbackType : int
    {
        STATUS_EVENT_SEARCH_PROGRESS = 0x10,
        STATUS_EVENT_SEARCH_CANCEL = 17,
        STATUS_EVENT_SEARCH_ERROR = 18,

        STATUS_DISKMAP_SEARCH_PROGRESS = 0x20,
        STATUS_DISKMAP_SEARCH_CANCEL = 33,
        STATUS_DISKMAP_SEARCH_ERROR = 34,

        STATUS_GPS_SEARCH_PROGRESS = 0x30,
        STATUS_GPS_SEARCH_CANCEL = 49,
        STATUS_GPS_SEARCH_ERROR = 50,

        STATUS_ARCHIVE_PROGRESS = 0x40,
        STATUS_ARCHIVE_CANCEL ,
        STATUS_ARCHIVE_CANCEL_FAIL,
        STATUS_ARCHIVE_ERROR ,
        STATUS_ARCHIVE_SUCCESS ,
        STATUS_ARCHIVE_NO_DATA ,
        STATUS_ARCHIVE_PROGRESS_END ,//change by Edward for UTCFS's archive requirement in 20120110
        STATUS_ARCHIVE_LAST_BLOCKID ,
        STATUS_ARCHIVE_LAST_FILENAME ,

        STATUS_TRANS_PROGRESS = 0x50,
        STATUS_TRANS_CANCEL = 81,
        STATUS_TRANS_ERROR = 82,
        STATUS_TRANS_END = 83,

        STATUS_DISK_SCAN_RESULT = 0x60,
        STATUS_DISK_SCAN_ERROR = 97,
        STATUS_DISK_SCAN_FINISH = 98,
        STATUS_DISK_OPEN_PROGRESS = 99,
        STATUS_DISK_READ_SECTOR_ERROR = 0x70,

        STATUS_DECODE_BUSY = 0x80,
        STATUS_DECODE_NORMAL = 129,
        STATUS_DECODE_WMERROR,//added by Edward for water mark exam error in 20120628

        STATUS_PLAY_VEHICLE_START = 0x90,
        STATUS_PLAY_VEHICLE_END = 145,

        STATUS_VIDEO_TIME = 0x100,
        STATUS_VIDEO_TIME_JUMP = 257,

        STATUS_PLAYBACK_PROGRESS = 0x200,
        STATUS_PLAYBACK_START = 513,
        STATUS_PLAYBACK_FINISH = 514,
        STATUS_PLAYBACK_ERROR_WRITE_FILE = 515,
        STATUS_PLAYBACK_ERROR = 516,
        STATUS_PLAYBACK_PAUSE = 517,
        STATUS_PLAYBACK_RESTART = 518,
        STATUS_PLAYBACK_BUFFER_PROGRESS = 519,

        STATUS_LIVE_DISCONNECT = 0x300,
        STATUS_PLAYBACK_DISCONNECT,
        STATUS_CONNECTION_FAILED,
        STATUS_LOGIN_ERROR,
	    STATUS_LOGIN_BLOCKED,//added by Edward for user right exam
        STATUS_EXCEED_MAX_CONNECTION,
        STATUS_PLAYBACK_TIMEERROR,//Added by Edward for playback time error, in 20120203

        SYNC_RES_UPDATE = 0x400,

        STATUS_DETECT_HDD_Mounted = 0x500,
        STATUS_DETECT_HDD_UnMounted,
    }


    /// <summary>
    /// enumerate callback types
    /// </summary>
    public enum CallbackType : int
    {
        NONE_TYPE = -1,
        IFRAME = 0,
        STATUS_DISCONNECT = 1,
        STATUS_DISKMAP = 2,
        STATUS_GPS = 3,
        STATUS_ARCHIVE = 4,
        STATUS_ARCHIVE_NODATA = 5,
        STATUS_ARCHIVE_CANCEL = 6,
        STATUS_ARCHIVE_END = 7,
        STATUS_VIDEO_TIME =  8,
        IFRAME_META_DATA = 9,
        STATUS_SCANN_HDD = 10,
        STATUS_TIMEERROR = 11,
        STATUS_LOGINBLOCKED,
    }

    /// <summary>
    /// enumerate archive callback message
    /// </summary>
    public enum ArchiveCallbackMessage : int
    {
        ARCHIVE_PROGRESS = 0,
        ARCHIVE_FILE_PATH = 1,
        ARCHIVE_LAST_BLOCK_ID = 2,
        ARCHIVE_NODATA,
        ARCHIVE_CANCEL
    }

    /// <summary>
    /// G-Sensor structure in meta data, MV3's g-sensor structure does not contain any reservation
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ACC_T
    {
        ///// unsigned char
        //public byte acon;

        /// unsigned char
        public byte x_val;

        ///// unsigned char
        //public byte x_fract;

        /// unsigned char
        public byte x_dir;

        /// unsigned char
        public byte y_val;

        ///// unsigned char
        //public byte y_fract;

        /// unsigned char
        public byte y_dir;

        /// unsigned char
        public byte z_val;

        ///// unsigned char
        //public byte z_fract;

        /// unsigned char
        public byte z_dir;
    }

    /// <summary>
    /// EMV G-Sensor structure in meta data
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct EMV_ACC_T
    {
        ///// unsigned char
        //public byte acon;

        /// unsigned char
        public byte x_val;

        ///// unsigned char
        //public byte x_fract;

        /// unsigned char
        public byte x_dir;

        /// unsigned char
        public byte y_val;

        ///// unsigned char
        //public byte y_fract;

        /// unsigned char
        public byte y_dir;

        /// unsigned char
        public byte z_val;

        ///// unsigned char
        //public byte z_fract;

        /// unsigned char
        public byte z_dir;

        /// unsigned char[2]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string reserv;//modified by Edward for MV3
    }

    /// <summary>
    /// GPS structure in Meta data
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct GPS_GPRMC_T
    {
        /// unsigned int
        public uint utc_date;

        /// unsigned int
        public uint utc_time;

        /// unsigned int
        public uint lat;

        /// unsigned int
        public uint lon;

        /// unsigned short
        public ushort speed;

        /// unsigned short
        public ushort course;

        /// unsigned short
        public ushort mag;

        /// unsigned char
        public byte mag_ew;

        /// unsigned char
        public byte valid;

        /// unsigned char
        public byte lat_sn;

        /// unsigned char
        public byte lon_ew;

        /// unsigned char
        public byte mode;

        /// unsigned char
        public byte con;

        /// unsigned char[4]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string reserv;
    }

    /// <summary>
    /// zb_info_t structure in Meta data
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct zb_info_t
    {
        public ulong dst_type;   //[00-07]   destination mac address
        public ulong src_mac;    //[08-15]   source mac address
        public ulong lock_mac;   //[16-23]   source mac address
        public ushort seq_no;  //[24-25]   sequence number
        public byte  msg_type;   //[26]      message type
        public byte lock_total; //[27]      total number of locks
        public byte status;     //[28]      lock status
        public byte rssi;       //[29]      received singal strength indicator
        public byte fake;       //[30]      1:no received, 0:have data
        public byte reserv;     //[31]
    }

    /// <summary>
    /// EMV Meta data structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class EMV_META_DATA_T
    {

        public uint marker;         //[000-003]
        public ushort flag;           //[004]
        public ushort valid;          //[006-007]
        public GPS_GPRMC_T gps;            //[008-039]
        public EMV_ACC_T gs;             //[040-047]
        public zb_info_t zb;             //[048-079]

        // unsigned char[16]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] fps;     //[080-095]

        // unsigned char[16]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] bus_id;        //[096-111]

        public ulong vloss;          //[112-115]
        public ulong alarm;          //[116-119]

        // unsigned char[8]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] reserv;        //[120-127]

    }

    /// <summary>
    /// Meta data structure, modified by Edward for new MV3 metadata
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class META_DATA_T
    {

        public uint marker;         //[000-003]
        public ushort flag;           //[004-005]
        public ushort valid;          //[006-007]
        public GPS_GPRMC_T gps;            //[008-039]
        public ACC_T gs;             //[040-045]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] bus_id;     //[046-077]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] reserv1;     //[078-079]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] fps;        //[080-095]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] vehicle_id;     //[096-111]
        public uint vloss;          //[112-115]
        public uint alarm;          //[116-119]
        public byte gps_status;     //[120]
        public byte gs_status;      //[121]
        public uint ipaddr;         //[122-125]
        public uint cam_install;    //[126-129]//added by Edward for smallest channel
        public uint cam_recording;  //[130-133]//added by Edward for smallest channel
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] sfps;         //[134-149]//for sub stream fps
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] j1939data;    //[150-189]
        public byte accelerometerTrigger;   //[190]
        public byte ch_id;			        //[191]
        // unsigned char[32]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] camera_title;	//[192-223] //added by Edward in 2011/08/18
        // unsigned char[73]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] reserv;    //[224-255]	//added by Edward in 2011/08/18
    }

    /// <summary>
    /// Hdd scan result
    /// sdk: EF_DRIVE
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class HDD_DEVICE
    {
        /// unsigned long
        public uint drv_size_GB; // drive size in GB

        /// unsigned long
        public uint drv_type; // EDSR, EDR or Invader

        /// unsigned long
        public uint drv_number;  // drive number in Windows

        /// unsigned long
        public uint aud_type;  // 0: no audio, otherwise audio type

        /// unsigned long
        public uint error_num;

        /// unsigned char[16]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string product_info;//vehicle_id

        /// unsigned char[16]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string company_info;

        /// char[260]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string name;
    }

    /// <summary>
    /// Get archive resume path
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ArchiveFilePath
    {
        /// unsigned char[16]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] file_path;
    }

    /// <summary>
    /// JPGCallbackInfo
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct JPGCallbackInfo
    {
	    public uint dwJPGSize;
	    public IntPtr pJPGBuffer;
	    public int	  iProgress;
        /// char[16]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        //public string strTimeStamp;
        //public UInt32 uiTimeStamp;
        public DVR_LOCAL_TIME JpgTime;
        public short sCameraID;
        /// char[32]
        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        //public string strCameraTitle;
        
        /// char[512]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string strFileName;       
    }


    class CallbackEventArgs : EventArgs //CallbackEventArgs inherit from EventArgs
    {       
       public CallbackType CallbackEventType;  
    }

    class ConnectionCBEventArgs : CallbackEventArgs //ConnectionCBEventArgs inherit from CallbackEventArgs
    {
        public IntPtr pDevicePtr;
    }
    class ArchiveCBEventArgs : CallbackEventArgs//ArchiveCBEventArgs inherit from CallbackEventArgs
    {
        public IntPtr pDevicePtr;
        public int m_Archive_message;
        public int m_iArvprogress;
        public string m_ArvBlockID;
        public string m_strArvFilePath;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class J1939Signal
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 50)]
        public byte[] Description; // char[50]
        public int Type;            // 0: Status, i.e. only 0 (inactive) or 1 (active)

        // 1: Integer
        // 2: Floating Point
        // 3: ASCII String

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] Value;       // value depends on Type - all numeric data are in network byte order       - use as many bytes as we need

        public float LowerRange;
        public float UpperRange;
        public float Resolution;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15)]
        public byte[] Unit;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class J1939Signals
    {
        int SignalCount;
        IntPtr Ptr_J1939Signals;
    }



     /** 
    *********************************************************************
    * @Class<CallbackClass>
    * @brief<This class has two smaller class to control meta callback or status callback>
    * <Metacallback work with functions "metaCallback_assign", "GetMetaptr", "MetadataCallbackMethod">
    * <StatusCallback work with functions "StatusCallback_assign", "StatusCallbackMethod">
    * @param[in]
    * 
    *********************************************************************
    */
     public class CallbackClass
    {

        public IntPtr m_piDevice_outer;
        public string tb_ptr;
        public static string[] j1939MsgAry = new string[40];

        // typedef DWORD (__stdcall *FDeviceMetadataCallback)(HANDLE hInstance, HDevice hDevice, int iMetaType, void *pMetadata);
        public delegate int DeviceMetadataCallback(SDKcallback hInstance, IntPtr hDevice, int iMetaType, ref IntPtr pMetadata);

        //private static extern int SdkShellSetMetadataCallback(HDevice hDevice, HANDLE hParant, FDeviceMetadataCallback cbfMetadataCallback);
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSetMetadataCallback(IntPtr hDevice, SDKcallback hParant, DeviceMetadataCallback deviceMetadataCallback);

        //typedef DWORD (__stdcall *FDeviceStatusCallback)(HANDLE hInstance, HDevice hDevice, int iType, void *pData);
        public delegate int DeviceStatusCallback(SDKcallback hInstance, IntPtr hDevice, int iType, ref IntPtr pData);

        //private static extern int SdkShellSetStatusCallback(HDevice hDevice, HANDLE hParant, FDeviceStatusCallback cbfStatusCallback);
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSetStatusCallback(IntPtr hDevice, SDKcallback hParant, DeviceStatusCallback deviceStatusCallback);

        //extern EFRESULT _stdcall SdkShellSetDetectUSB( HANDLE hParant, FDeviceStatusCallback cbfStatusCallback );
         [DllImportAttribute("SdkShell.dll")]
         private static extern int SdkShellSetDetectUSB(SDKcallback hParant, DeviceStatusCallback deviceStatusCallback);

        /** 
         *********************************************************************
         * @Class<SDKcallback>
         * @brief<This class control all the callback functions of SDK>
         * <In this SDK, the second parameter of SdkShellSetMetadataCallback and SdkShellSetStatusCallback should be the same type>
         * <So I combine the metacallback and statuscallback into one class.>
         * <There is one more important thing about the callback functions in SDK, there is only one status callback between application and sdk>
         * <This means user should found out the callback belongs to which device by checking the value of hDevice>
         * @param[in]
         * 
         *********************************************************************
         */
         public class SDKcallback
         {
             /** 
              *********************************************************************
              * @<Metadatacallback>
              * @brief<This part will control the callback functions of metadat>
              * <The main purpose of this parts is assgining a function which can deal with returned data to function pointer "asyncDeviceMetadataCallback">
              * <This function pointer and the reference of this class will be the input parameter of SdkShellSetMetadataCallback>
              * <There is a eventhandler to send Metadata to ui level and try to give the meta data to ui object>
              * @param[in]
              * 
              *********************************************************************
              */
             public DeviceMetadataCallback asyncDeviceMetadataCallback = null;// function pointer of  MetadataCallbackMethod
             public string strDatatowrite;
             public IntPtr m_piDevice = IntPtr.Zero;
             public META_DATA_T m_stMetadata = new META_DATA_T();//Save the metadata from called-back function
             public event EventHandler UploadMeta;
             public string[] strCameraTitlelist = new string[12];//added by Edward for adding camera tilte to metadata
             

             /** 
              *********************************************************************
              * @fn<Writegpsdata()>
              * @brief<This function will count and write gps data>
              * <This function always work with AsyncWritegpsdata> 
              * @param[in]
              * <_stMetadata: Metadata passed from called-back function>
              * @param[out]
              *    none
              * @retval
              *    none
              * @return <int>
              *********************************************************************
              */
             //private delegate void AsyncWritegpsdata(META_DATA_T _stMetadata);
             //private void Writegpsdata(META_DATA_T _stMetadata)
             private delegate void AsyncWritegpsdata();
             private void Writegpsdata()
             {

                 Monitor.Enter(m_stMetadata);
                 double _dGpslon;
                 double _dGpslat;
                 int _iGpslonDegree;
                 int _iGpslatDegree;
                 double _dGpslonMinute;
                 double _dGpslatMinute;

                 // string strDatatowrite;
                 _dGpslat = dCount_lon_lat(m_stMetadata.gps.lat, m_stMetadata.gps.lat_sn);
                 //separate degree and minute
                 _iGpslatDegree = Convert.ToInt32( Math.Floor(_dGpslat) );
                 _dGpslatMinute = (_dGpslat - _iGpslatDegree) * 100;
                 //strDatatowrite = "LAT: " + Convert.ToString(_dGpslat) + " ";
                 decimal _decGpslatMinute = Convert.ToDecimal(_dGpslatMinute);
                 _dGpslatMinute = (double)decimal.Round(_decGpslatMinute, 6);
                 strDatatowrite = "LAT: Deg is " + Convert.ToString(_iGpslatDegree) + " Min is " + Convert.ToString(_dGpslatMinute);
                 if (m_stMetadata.gps.lat_sn == 0)
                     strDatatowrite += "S \r\n";
                 else
                     strDatatowrite += "N \r\n";

                 _dGpslon = dCount_lon_lat(m_stMetadata.gps.lon, m_stMetadata.gps.lon_ew);
                 //separate degree and minute
                 _iGpslonDegree = Convert.ToInt32( Math.Floor(_dGpslon) );
                 _dGpslonMinute = (_dGpslon - _iGpslonDegree) * 100;
                 //strDatatowrite += "LON: " + Convert.ToString(_dGpslon) + " ";
                 decimal _decGpslonMinute = Convert.ToDecimal(_dGpslonMinute);
                 _dGpslonMinute = (double)decimal.Round(_decGpslonMinute, 6);
                 strDatatowrite += "LON: Deg is " + Convert.ToString(_iGpslonDegree) + " Min is " + Convert.ToString(_dGpslonMinute);
                 if (m_stMetadata.gps.lon_ew == 0)
                     strDatatowrite += "E \r\n";
                 else
                     strDatatowrite += "W \r\n";

                 double _dspeed = m_stMetadata.gps.speed / 100;//xxx.xx(000.0~999.9) * 100, unit:navy mile
                 _dspeed = _dspeed * 1.852;//navy mile to KM
                 string _strspeed = "Speed: " + Convert.ToString(_dspeed);
                 strDatatowrite += _strspeed + "KPH ";
                 strDatatowrite += "\r\n";

                 string _strDirection;
                 _strDirection = GetGpsDirection(GpsDirectionMethod(m_stMetadata.gps.course));
                 strDatatowrite += "Dir: " + _strDirection + "\r\n";

                 strDatatowrite += "X: ";
                 strDatatowrite += GetGsensorval(m_stMetadata.gs.x_val, m_stMetadata.gs.x_dir) + " ";

                 strDatatowrite += "Y: ";
                 strDatatowrite += GetGsensorval(m_stMetadata.gs.y_val, m_stMetadata.gs.y_dir) + " ";

                 strDatatowrite += "Z: ";
                 strDatatowrite += GetGsensorval(m_stMetadata.gs.z_val, m_stMetadata.gs.z_dir) + " \r\n";

                 //added by Edward in 2011/08/19 for adding Camer tilte to metadata
                 string tempCamTitle;
                 tempCamTitle = GetStringFromBytes(m_stMetadata.camera_title);
                 if (!tempCamTitle.Equals(""))
                 {
                     int TilteIndex = Convert.ToInt32(m_stMetadata.ch_id);
                     if (TilteIndex >= 12)//for debugging only
                         Debug.WriteLine("m_stMetadata.ch_id in metadata is " + TilteIndex);
                     strCameraTitlelist[TilteIndex] = tempCamTitle;
                 }
                 //******* GPS Status
                 int int_gps_status = Convert.ToInt32(m_stMetadata.gps_status);
                 strDatatowrite += "gps_status: " + int_gps_status.ToString();
                 strDatatowrite += "\r\n";
                 //******* G-Sensor Status
                 int int_gs_status = Convert.ToInt32(m_stMetadata.gs_status);
                 strDatatowrite += "gs_status: " + int_gs_status.ToString();
                 strDatatowrite += "\r\n";
                 //******* Accelerometer Trigger
                 int int_accelerometerTrigger = Convert.ToInt32(m_stMetadata.accelerometerTrigger);
                 strDatatowrite += "accelerometerTrigger: " + int_accelerometerTrigger.ToString();
                 strDatatowrite += "\r\n";

                 for (int i = 0; i < 12; i++)
                 {
                     uint cammask = 1;
                     int tmpChNo = i + 1;
                     strDatatowrite += "Ch" + tmpChNo + " :" + strCameraTitlelist[i] + " ";
                     //if ((m_stMetadata.alarm & 1 << i) > 0)
                         //strDatatowrite += "[Alarm] ";
                     if ((m_stMetadata.vloss & 1 << i) > 0)
                         strDatatowrite += "[Vloss] ";
                     strDatatowrite += "\r\n";
                 }

                 for (int i = 0; i < 14; i++)
                 {
                     uint cammask = 1;
                     int tmpChNo = i + 1;
                     if (i<12)
                        strDatatowrite += "Input Alarm" + tmpChNo + " :" + " ";
                     else
                        strDatatowrite += "Output Alarm" + tmpChNo + " :" + " ";
                     if ((m_stMetadata.alarm & 1 << i) > 0)
                         strDatatowrite += "[Alarm] ";
                     strDatatowrite += "\r\n";
                 }

                 string strVid;
                 strVid = GetStringFromBytes(m_stMetadata.vehicle_id);
                 strDatatowrite += "VID: " + strVid + "\r\n";
                 strDatatowrite += ".................................." + "\r\n";


                 for (int i = 0; i < 40; i++)
                 {
                     int tt = m_stMetadata.j1939data[i];
                     if (i < 37)
                     {
                         if (tt == 1)
                             strDatatowrite += CallbackClass.j1939MsgAry[i] + " [True]" + "\r\n";
                         else
                             strDatatowrite += CallbackClass.j1939MsgAry[i] + " [False]" + "\r\n";
                     }
                     else
                     {
                         strDatatowrite += CallbackClass.j1939MsgAry[i] + " [" + tt.ToString() + "]" + "\r\n";
                     }
                     
                 }

                 //Debug.WriteLine("Install channel is " + m_stMetadata.cam_install + " " + m_stMetadata.cam_recording);

                 CallbackEventArgs mCallbackEventArgs = new CallbackEventArgs();
                 mCallbackEventArgs.CallbackEventType = CallbackType.IFRAME_META_DATA;
                 EventHandler temp = UploadMeta;//this event handle will call UploadMeta and try assign strDatatowrite to textbox
                 if (temp != null)
                     temp(this, mCallbackEventArgs);
                 Monitor.Exit(m_stMetadata);

             }
             /** 
              *********************************************************************
              * @fn<WriteCallback()>
              * @brief<There is an async control in it. A new thread will take control the rest GPS data wiriting.>
              * <This action will let Dvr.dll run more smoothly. Becasue the thread in Dvr.dll only needs to pass down the pointer of Metadata. > 
              * @param[in]
              *    none
              * @param[out]
              *    none
              * @retval
              *    none
              * @return <int>
              *********************************************************************
              */
             public int WriteCallback()//call by MetadataCallbackMethod
             {
                 //start to count and write gps data into a string
                 //The rest part will be done by another thread
                 //AsyncWritegpsdata cbWritegpsdata = new AsyncWritegpsdata(Writegpsdata);
                 //cbWritegpsdata.BeginInvoke(m_stMetadata, null, null);
                 AsyncWritegpsdata cbWritegpsdata = new AsyncWritegpsdata(Writegpsdata);
                 cbWritegpsdata.BeginInvoke(null, null);
                 return 0;

             }

             /// <summary>
             /// Counting GPS value
             /// </summary>
             private double dCount_lon_lat(uint uGpsCoordinate, byte bEWorSN)
             {
                 //uGpsCoordinate should be ddmmmmmm(d for degree and m for minute)
                 //define variable 
                 double _dMETADATA_GPS_DEGREE_MULTIPLE = 0xF4240;//1 000 000
                 double _dMETADATA_GPS_MINUTE_MULTIPLE = 0x2710;//10 000
                 double _dMETADATA_GPS_UNIT = 60d;

                 double dGpsCoordinate = Convert.ToDouble(uGpsCoordinate);//following computation will be operated in double type to prevent coverting issue
                 double dDegreePart = Math.Floor(dGpsCoordinate / _dMETADATA_GPS_DEGREE_MULTIPLE);//get degree part
                 double dMinutePart = (dGpsCoordinate - dDegreePart * _dMETADATA_GPS_DEGREE_MULTIPLE);// get minute part

                 decimal _decRonded = Convert.ToDecimal(dMinutePart / _dMETADATA_GPS_DEGREE_MULTIPLE);//minute should be stored as decimal
                 dMinutePart = (double)decimal.Round(_decRonded, 8);

                 double dLon_Lat = dDegreePart + dMinutePart;
                 return dLon_Lat;//the integer part degree and decimal part minute
             }

             /// <summary>
             /// Get Gps Direction
             /// </summary>
             /// <param name="degree"></param>
             private int GpsDirectionMethod(int degree)
             {
                 for (int i = 0; i < 8; i++)
                 {
                     if (degree >= i * 450 && degree < 450 * (i + 1))
                     {
                         if (degree == i * 450)
                             return 2 * i;
                         else
                         {
                             if (Math.Abs(degree - i * 450) * 10 < 1125)
                                 return 2 * i;
                             else if (Math.Abs(degree - (i + 1) * 450) * 10 < 1125)
                                 return 2 * (i + 1);
                             else
                                 return (2 * i + 1);
                         }
                     }
                 }
                 return 0;
             }

             /// <summary>
             /// Get GPS direction by index.
             /// </summary>
             /// <param name="index"></param>
             /// <returns></returns>
             private string GetGpsDirection(int index)
             {
                 switch (index)
                 {
                     case 0:
                         return "N";
                     case 1:
                         return "NNE";
                     case 2:
                         return "NE";
                     case 3:
                         return "ENE";
                     case 4:
                         return "E";
                     case 5:
                         return "ESE";
                     case 6:
                         return "SE";
                     case 7:
                         return "SSE";
                     case 8:
                         return "S";
                     case 9:
                         return "SSW";
                     case 10:
                         return "SW";
                     case 11:
                         return "WSW";
                     case 12:
                         return "W";
                     case 13:
                         return "WNW";
                     case 14:
                         return "NW";
                     case 15:
                         return "NNW";
                     default:
                         return "N";
                 }
             }

             /// <summary>
             /// Get GSenor value.
             /// </summary>
             /// <param name="axis value "></param>
             /// <param name="axis direction "></param>
             /// <returns></returns>
             private string GetGsensorval(byte _bCoordinval, byte _bCoordindir)
             {
                 string _strReturnstr = " ";
                 double _dGsensorval = double.Parse((_bCoordinval).ToString("0.00"));
                 if (_bCoordindir == 0)
                     _strReturnstr = "+";
                 else
                     _strReturnstr = "-";

                 _strReturnstr += Convert.ToString(_bCoordinval);
                 return _strReturnstr;
             }

             /// <summary>
             /// Get string form the byte array
             /// </summary>
             /// <param name="bytes"></param>
             private string GetStringFromBytes(byte[] bytes)
             {
                 if (bytes == null || bytes.Length <= 0)
                     return string.Empty;

                 string str = Encoding.Default.GetString(bytes);
                 if (string.IsNullOrEmpty(str))
                     return string.Empty;
                 else
                 {
                     string[] strArray = str.Split('\0');
                     if (strArray.Length > 0)
                         return strArray[0];
                     else
                         return string.Empty;
                 }
             }


             /** 
              *********************************************************************
              * @Class<StatusCallback>
              * @brief<This part will control the callback functions of scan HDD, archive file and camera status>
              *  <The main purpose of this class is assgining a function which can deal with returned data to function pointer "asyncDeviceStatusCallback">
              * <This function pointer and the reference of this class will be the input parameter of SdkShellSetStatusCallback>
              * <There is a eventhandler to send returned data to ui level and try to give the returned data to ui object>
              * @param[in]
              * 
              *********************************************************************
              */

             public DeviceStatusCallback asyncDeviceStatusCallback = null;// function pointer of CallbackMethod
             public HDD_DEVICE m_HddDevice = new HDD_DEVICE();//Save one HDD information when it is called-back
             public DVR_LOCAL_TIME DevLocTime = new DVR_LOCAL_TIME();//testing only
             public List<HDD_DEVICE> HDDList = null;//Save every HDD information 
             public string m_strHddStatus = "";
             public event EventHandler UploadData;
             public int m_iArvprogress;//archive progress
             public long m_uiVideoUTCTime;
             public long m_uiVideoLocalTime;
             public long m_uiVideoUTCTimeMiniSec; //John + 20150515 for milli second callback
             public int m_Archive_message;//archive message type
             public string m_ArvBlockID = "";//archive last block ID
             public string m_strArvFilePath = ""; //file path
             public ArchiveFilePath m_ArvFilePath = new ArchiveFilePath();

             /** 
              *********************************************************************
              * @fn<WriteHddStatusCallback>
              * @brief<Convert HDD information to string>
              * <Send event to call UI thread to write Textbox> 
              * @param[in]
              *    none
              * @param[out]
              *    none
              * @retval
              *    none
              * @return <int>
              *********************************************************************
              */
             public int WriteHddStatusCallback()
             {
                 int _iCounter = HDDList.Count;
                 if ((HDDList != null) && (_iCounter != 0))//Check HDDList has any elements or not
                 {
                     m_strHddStatus = " ";
                     for (int i = 0; i < _iCounter; i++)
                     {
                         int _iTempi = i + 1;
                         m_strHddStatus += "Available Device NO." + _iTempi + " ";
                         m_strHddStatus += "GB: " + Convert.ToString(HDDList[i].drv_size_GB) + "\r\n";
                         //m_strHddStatus += "Type: " + Convert.ToString(HDDList[i].drv_type) + "\r\n";
                         //m_strHddStatus += "Number: " + Convert.ToString(HDDList[i].drv_number) + "\r\n";
                         //m_strHddStatus += "Aud: " + Convert.ToString(HDDList[i].aud_type) + "\r\n";
                         //m_strHddStatus += "Error:" + Convert.ToString(HDDList[i].error_num) + "\r\n";
                         //m_strHddStatus += "Product_Info: " + HDDList[i].product_info + "\r\n";
                         //m_strHddStatus += "Company_Info: " + HDDList[i].company_info + "\r\n";
                         //m_strHddStatus += "Name: " + HDDList[i].name + "\r\n";

                     }
                 }

                 //mCallbackEventArgs has variable to specify it is sent by Meta or HDD
                 CallbackEventArgs mCallbackEventArgs = new CallbackEventArgs();
                 mCallbackEventArgs.CallbackEventType = CallbackType.STATUS_SCANN_HDD;
                 EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                 if (temp != null)
                     temp(this, mCallbackEventArgs);

                 return 0;
             }

             /** 
              *********************************************************************
              * @fn<ProgressCallback>
              * @brief<Assign archive progress to member variable of StatusCallback or Acknowledge the connection status>
              * <Send event to call UI thread to draw archive progress or Acknowledge user the connection status> 
              * @param[in]
              *    none
              * @param[out]
              *    none
              * @retval
              *    none
              * @return <int>
              *********************************************************************
              */
             public int ProgressCallback(IntPtr _hDevicePtr, long _iInputvalue, int _iType)
             {
                 if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_PROGRESS)
                 {
                     //m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_PROGRESS;//archive message type
                     //m_iArvprogress = Convert.ToInt32(_iInputvalue);
                     //if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_PROGRESS)
                     //    Debug.WriteLine("Current progress is " + m_iArvprogress);

                     //new ArchiveCBEventArgs can bring more detailed variable and pointer to specify which device it belongs to
                     ArchiveCBEventArgs ArchiveEventArgs = new ArchiveCBEventArgs();//需要重新new一個archive專用的 eventargs
                     ArchiveEventArgs.pDevicePtr = _hDevicePtr;
                     ArchiveEventArgs.CallbackEventType = CallbackType.STATUS_ARCHIVE;
                     ArchiveEventArgs.m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_PROGRESS;
                     ArchiveEventArgs.m_iArvprogress = Convert.ToInt32(_iInputvalue);
                     if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_PROGRESS)
                         Debug.WriteLine("Current progress is " + ArchiveEventArgs.m_iArvprogress + " pointer is " + _hDevicePtr);


                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ArchiveEventArgs);
                 }

                 else if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_PROGRESS_END)
                 {

                     //m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_PROGRESS;//archive message type
                     //m_iArvprogress = Convert.ToInt32(_iInputvalue);
                     if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_PROGRESS)
                         Debug.WriteLine("Current archive has been ended " + m_iArvprogress);

                     ArchiveCBEventArgs ArchiveEventArgs = new ArchiveCBEventArgs();
                     ArchiveEventArgs.pDevicePtr = _hDevicePtr;
                     ArchiveEventArgs.CallbackEventType = CallbackType.STATUS_ARCHIVE_END;
                     ArchiveEventArgs.m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_PROGRESS;
                     ArchiveEventArgs.m_iArvprogress = Convert.ToInt32(_iInputvalue);

                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ArchiveEventArgs);

                 }

                 else if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_NO_DATA || _iType == (int)StatusCallbackType.STATUS_ARCHIVE_CANCEL)
                 {

                     ArchiveCBEventArgs ArchiveEventArgs = new ArchiveCBEventArgs();
                     ArchiveEventArgs.pDevicePtr = _hDevicePtr;
                     if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_NO_DATA)
                     {
                         ArchiveEventArgs.CallbackEventType = CallbackType.STATUS_ARCHIVE_NODATA;
                         ArchiveEventArgs.m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_NODATA;
                     }
                     else if(_iType == (int)StatusCallbackType.STATUS_ARCHIVE_CANCEL)
                     {
                         ArchiveEventArgs.CallbackEventType = CallbackType.STATUS_ARCHIVE_CANCEL;
                         ArchiveEventArgs.m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_CANCEL;
                     }
                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ArchiveEventArgs);
                 }
                 return 0;
             }

             //added by Edward in 20121018
             /** 
              *********************************************************************
              * @fn<ConnectionCallback>
              * @brief<Acknowledge the connection status and Get the device pointer which uses this callback>
              * <Send event to call UI thread to Acknowledge user the connection status> 
              * @param[in]
              *    _iType = Status of Callback type
              *    pDevicePtr = pointer of device
              * @param[out]
              *    none
              * @retval
              *    none
              * @return <int>
              *********************************************************************
              */
             public int ConnectionCallback(IntPtr pDevicePtr, int _iType)
             {

                 if (_iType == (int)StatusCallbackType.STATUS_LIVE_DISCONNECT || _iType == (int)StatusCallbackType.STATUS_CONNECTION_FAILED)
                 {
                     //mCallbackEventArgs has variable to specify it is sent by Meta or HDD
                     ConnectionCBEventArgs ConnectionEventArgs = new ConnectionCBEventArgs();
                     ConnectionEventArgs.pDevicePtr = pDevicePtr;
                     ConnectionEventArgs.CallbackEventType = CallbackType.STATUS_DISCONNECT;
                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ConnectionEventArgs);
                 }

                 else if (_iType == (int)StatusCallbackType.STATUS_LOGIN_BLOCKED)
                 {
                     ConnectionCBEventArgs ConnectionEventArgs = new ConnectionCBEventArgs();
                     ConnectionEventArgs.pDevicePtr = pDevicePtr;
                     ConnectionEventArgs.CallbackEventType = CallbackType.STATUS_LOGINBLOCKED;
                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ConnectionEventArgs);
                 }
                 //added by Edward in 20121105
                 //move STATUS_PLAYBACK_TIMEERROR to ConnectionCallback because Playback time error is belong to connecton problem not progress
                 else if (_iType == (int)StatusCallbackType.STATUS_PLAYBACK_TIMEERROR)
                 {
                     ConnectionCBEventArgs ConnectionEventArgs = new ConnectionCBEventArgs();
                     ConnectionEventArgs.pDevicePtr = pDevicePtr;
                     ConnectionEventArgs.CallbackEventType = CallbackType.STATUS_TIMEERROR;
                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ConnectionEventArgs);
                 }


                 return 0;
             }


             /** 
              *********************************************************************
              * @fn<DualTimeCallback>
              * @brief<Assign video utc time and video local time to member variable of StatusCallback>
              * <Send event to call UI thread to display the video time> 
              * @param[in]
              *    none
              * @param[out]
              *    none
              * @retval
              *    none
              * @return <int>
              *********************************************************************
              */
             public int DualTimeCallback(DVR_LOCAL_TIME _DevLocTime, int _iType)
             {
                 if (_iType == (int)StatusCallbackType.STATUS_VIDEO_TIME)
                 {
                     m_uiVideoUTCTime = Convert.ToInt64(_DevLocTime.uDVRTime);
                     //sbyte _SignedTimeZone = Convert.ToSByte(_DevLocTime.TimeZone);
                     m_uiVideoLocalTime = Convert.ToInt64(_DevLocTime.uDVRTime) + Convert.ToInt64(_DevLocTime.TimeZone) * 15 * 60 + Convert.ToInt64(_DevLocTime.DayLightSaving) * 60;

                     m_uiVideoUTCTimeMiniSec = Convert.ToInt64(_DevLocTime.uDVRTimeMiniSec);
                     //mCallbackEventArgs has variable to specify it is sent by Meta or HDD
                     CallbackEventArgs mCallbackEventArgs = new CallbackEventArgs();
                     mCallbackEventArgs.CallbackEventType = CallbackType.STATUS_VIDEO_TIME;
                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, mCallbackEventArgs);
                     return 0;
                 }

                 return -1;
             }

             /** 
              *********************************************************************
              * @fn<ArchiveMessageCallback>
              * @brief<Assign archive message of StatusCallback>
              * <Send event to call UI thread to archive form> 
              * @param[in]
              *    <_hDevicePtr: pointer for device>
              *    <_data:file name or block ID>
              *    <_iType:callback type>
              * @param[out]
              *    none
              * @retval
              *    none
              * @return <int>
              *********************************************************************
              */
             public int ArchiveMessageCallback(IntPtr _hDevicePtr, string _data, int _iType)
             {
                 if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_LAST_FILENAME)
                 {
                     //m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_FILE_PATH;//archive message type
                     //m_strArvFilePath = _data;
                     //ArchiveCBEventArgs mCallbackEventArgs = new ArchiveCBEventArgs();
                     ArchiveCBEventArgs ArchiveEventArgs = new ArchiveCBEventArgs();//需要重新new一個archive專用的 eventargs
                     ArchiveEventArgs.pDevicePtr = _hDevicePtr;
                     ArchiveEventArgs.CallbackEventType = CallbackType.STATUS_ARCHIVE;
                     ArchiveEventArgs.m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_FILE_PATH;
          
                     ArchiveEventArgs.m_strArvFilePath = _data;

                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ArchiveEventArgs);
                 }
                 else if (_iType == (int)StatusCallbackType.STATUS_ARCHIVE_LAST_BLOCKID)
                 {
                     m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_LAST_BLOCK_ID;//archive message type
                     m_ArvBlockID = _data;
                     ArchiveCBEventArgs ArchiveEventArgs = new ArchiveCBEventArgs();
                     ArchiveEventArgs.pDevicePtr = _hDevicePtr;
                     ArchiveEventArgs.CallbackEventType = CallbackType.STATUS_ARCHIVE;
                     ArchiveEventArgs.m_Archive_message = (int)ArchiveCallbackMessage.ARCHIVE_LAST_BLOCK_ID;
                     ArchiveEventArgs.m_ArvBlockID = _data;

                     EventHandler temp = UploadData;//this event handle will call UploadDeta and try assign m_strHddStatus to textbox
                     if (temp != null)
                         temp(this, ArchiveEventArgs);
                 }

                 return 0;
             }

         }//End of SDKcallback

        //declaration of HDDCallback
        public SDKcallback m_cl_InnerMetacallback;
        public SDKcallback m_StatusCallback;

        /** 
         *********************************************************************
         * @fn<metaCallback_assign>
         * @brief<Give physical address to m_cl_InnerMetacallback >
         * <Assign device pointer and InnerMetacallback  to  SdkShellSetMetadataCallback> 
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int>
         *********************************************************************
         */
        public int metaCallback_assign()//assign Metacallback function
        {
            int result = 0;
            m_cl_InnerMetacallback.asyncDeviceMetadataCallback = new DeviceMetadataCallback(MetadataCallbackMethod);
            result = SdkShellSetMetadataCallback(m_piDevice_outer, m_cl_InnerMetacallback, m_cl_InnerMetacallback.asyncDeviceMetadataCallback);
            return 0;
        }

        /** 
         *********************************************************************
         * @fn<Getptr>
         * @brief<Give physical address to m_cl_InnerMetacallback >
         * <Assign Device pointer of  m_cl_InnerMetacallback.m_piDevice > 
         * @param[in]
         * <piInputptr: Device pointer>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int>
         *********************************************************************
         */
        public int GetMetaptr(IntPtr piInputptr)//assign device pointer to this class
        {
            m_cl_InnerMetacallback = new SDKcallback();
            m_piDevice_outer = piInputptr;
            m_cl_InnerMetacallback.m_piDevice= piInputptr;

            return 0;
        }

        /** 
         *********************************************************************
         * @fn<StatusCallback_assign>
         * @brief<Give physical address to m_StatusCallback and m_StatusCallback.HDDList >
         * <Assign StatusCallbackMethod to m_StatusCallback.asyncDeviceStatusCallback.> 
         * <StatusCallbackMethod will be the callback function after SdkShellSetStatusCallback>
         * <The first variable of SdkShellSetStatusCallback is the pointer of selected device.>
         * <Set m_piDevice_outer to IntPtr.Zero when we need to scan HDD, And set it to the selected device when we need to archive>
         * @param[in]
         * < _SeleCallbackType: It represents which kind of callback user want to use.>
         * < _piInputptr: Pointer of Selected Device>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int>
         *********************************************************************
         */
        public int StatusCallback_assign(IntPtr _piInputptr)//assign Status callback function
        {

            int result = 0;
            if(m_StatusCallback==null)
                m_StatusCallback = new SDKcallback();
            m_StatusCallback.HDDList = new List<HDD_DEVICE>();
            m_piDevice_outer = _piInputptr;

            m_StatusCallback.asyncDeviceStatusCallback = new DeviceStatusCallback(StatusCallbackMethod);
            result = SdkShellSetStatusCallback(m_piDevice_outer, m_StatusCallback, m_StatusCallback.asyncDeviceStatusCallback);
            result = SdkShellSetDetectUSB(m_StatusCallback, m_StatusCallback.asyncDeviceStatusCallback);
            return 0;
        }

         public int ClearHDDList( )//assign Status callback function
         {
            if (m_StatusCallback.HDDList == null)//give physical address to HDDList.If the physical address has already existed, clear and re-assign
                m_StatusCallback.HDDList = new List<HDD_DEVICE>();
            else
            {
                m_StatusCallback.HDDList.Clear();
                m_StatusCallback.HDDList = new List<HDD_DEVICE>();
            }
            return 0;
         }

        /** 
         *********************************************************************
         * @fn<MetadataCallbackMethod>
         * @brief<Assign the content of pMetedat to m_cl_InnerMetacallback.m_stMetadata>
         * <m_cl_InnerMetacallback.WriteCallback() will start to parse Metadata>
         * <the thread in Dvr.dll will callback this function every time when it receive Metadata>
         * @param[in]
         * <hInstance:reserved>
         * <hDevice: the pointer of source.In this function, the source should be DVR>
         * <iMetaType: Metadata type>
         * <pMetadata: pointer of metadata. Refer the the definition of META_DATA_T>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int>
         *********************************************************************
         */
        public int MetadataCallbackMethod(SDKcallback hInstance, IntPtr hDevice, int iMetaType, ref IntPtr pMetadata)
        {
            Monitor.Enter(m_cl_InnerMetacallback.m_stMetadata);
            Marshal.PtrToStructure(pMetadata, m_cl_InnerMetacallback.m_stMetadata);//assign the metadata to m_stMetadata

            int result;
            result = m_cl_InnerMetacallback.WriteCallback();

            Monitor.Exit(m_cl_InnerMetacallback.m_stMetadata);
            if (iMetaType == 1) {
                Console.WriteLine("1");
            }
            else if (iMetaType == 2) {
                Console.WriteLine("2");
            }
            else if (iMetaType == 3) {
                Console.WriteLine("3");
            }
            return 0;
        }

        /** 
         *********************************************************************
         * @fn< StatusCallbackMethod>
         * @brief<This is callback function. This function will be called-back when we use SdkShellSetStatusCallback and assign it to sdk>
         * <Besides metadatacallback, all callback information will be send to this function>
         * <When we use SdkShellScanHDD:>
         * <pData is the pointer of HDD_DEVICE. It contains the infomation of HDD >
         * <This function will be called for 16 times. Becasue the limit of connected HDD is 16>
         * <WriteHddStatusCallback() will convert the HDD_DEVICE to string>
         * 
         * <When we use SdkShellArchive:>
         * <pData is the pointer of Archvie Progress. The pointer type of pData is string >
         * <This function will be called during user archiving files if you assign this function to SdkShellSetStatusCallback.>
         * <TimeAndProgressCallback() will fire event to upper level and try give progress value to progress bar>
         * 
         * <When we play video :>
         * <pData is the pointer of video time. The pointer type of pData is string >
         * <This function will be called when video has been played if you assign this function to SdkShellSetStatusCallback.>
         * <TimeAndProgressCallback() will fire event to upper level and try give progress value to progress bar>
         * @param[in]
         * <hInstance:reserved>
         * <hDevice: pointer of device where this function come from. User can use the pointer to known which Device need these data >
         * <iTpye:It is callback status.It will give information of current condition . User can refer StatusCallbackType for the values and corresponding meaning  >
         * <pData: It is the pointer of returned Data. It contains some information of HDD, Archive Progress or CameraStatus>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int>
         *********************************************************************
         */
        public int StatusCallbackMethod(SDKcallback hInstance, IntPtr hDevice, int iType, ref IntPtr pData)//iType is the value of scan result or the value of callback result. pData is the pointer of returned value, it could be anything.
        {
            //try
            {
                switch (iType)
                {
                    case (int)StatusCallbackType.STATUS_VIDEO_TIME:
                        m_StatusCallback.DevLocTime = (DVR_LOCAL_TIME)Marshal.PtrToStructure(pData, typeof(DVR_LOCAL_TIME));
                        //string _stvideotime = DevLocTime.TimeZone.ToString();
                        //long _liVideotime = 0;

                        if (m_StatusCallback.DevLocTime.uDVRTime != 0)
                        {
                            m_StatusCallback.DualTimeCallback(m_StatusCallback.DevLocTime, iType);
                        }
                        break;

                    case (int)StatusCallbackType.STATUS_ARCHIVE_PROGRESS:
                        string progress = pData.ToString();
                        long nProgress = 0;
                        if (long.TryParse(progress, out nProgress))
                        {
                            m_StatusCallback.ProgressCallback( hDevice, nProgress, iType);
                        }
                        break;

                    case (int)StatusCallbackType.STATUS_TRANS_PROGRESS:
                        progress = pData.ToString();
                        //this part will save the JPG DATA as a file

                        JPGCallbackInfo tmpJPGCallbackInfo = new JPGCallbackInfo();//testing only
                        tmpJPGCallbackInfo = (JPGCallbackInfo)Marshal.PtrToStructure(pData, typeof(JPGCallbackInfo));
                        byte[] byCopiedImage = new byte[tmpJPGCallbackInfo.dwJPGSize];
                        //some error handle should add here. Try to avoid the problem when pJPGBuffer is emtpy
                        Marshal.Copy(tmpJPGCallbackInfo.pJPGBuffer, byCopiedImage, 0, (int)tmpJPGCallbackInfo.dwJPGSize);

                        FileStream fs = new FileStream(tmpJPGCallbackInfo.strFileName, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        bw.Write(byCopiedImage, 0, (int)tmpJPGCallbackInfo.dwJPGSize);

                        bw.Close();
                        fs.Close();

                        DateTime TimeStamp = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)tmpJPGCallbackInfo.JpgTime.uDVRTime);
                        Debug.WriteLine("Current Trans progress is " + tmpJPGCallbackInfo.iProgress + " Time is "
                                        + TimeStamp.ToString() + " TZ and DST is "+ tmpJPGCallbackInfo.JpgTime.TimeZone +" "+ tmpJPGCallbackInfo.JpgTime.DayLightSaving 
                                        + " CamID is " +  (short)(tmpJPGCallbackInfo.sCameraID+1) );
                        break;

                    case (int)StatusCallbackType.STATUS_ARCHIVE_CANCEL:
                        Debug.WriteLine("Archive Cancel");
                        MessageBox.Show("Archive Cancel has been pressed");
                        //there should be some close and release operation to handle this scenario
                        //user should close and release canceled device
                        m_StatusCallback.ProgressCallback( hDevice, 0, iType);
                        break;

                    //added by edward in 20120830,This will fix archive cancel before archive connection is built
                    case (int)StatusCallbackType.STATUS_ARCHIVE_CANCEL_FAIL:
                        Debug.WriteLine("Archive Cancel Fail");
                        break;

                    case (int)StatusCallbackType.STATUS_ARCHIVE_PROGRESS_END:
                        progress = pData.ToString();
                        nProgress = 0;
                        if (long.TryParse(progress, out nProgress))
                        {
                            m_StatusCallback.ProgressCallback( hDevice, nProgress, iType);
                        }
                        break;

                    case (int)StatusCallbackType.STATUS_ARCHIVE_NO_DATA:
                        Console.WriteLine("Archive Nodata");
                        //there should be some close and release operation to handle this scenario
                        m_StatusCallback.ProgressCallback(hDevice, 0, iType);
                        break;

                    case (int)StatusCallbackType.STATUS_DISK_SCAN_RESULT:
                        m_StatusCallback.m_HddDevice = (HDD_DEVICE)Marshal.PtrToStructure(pData, typeof(HDD_DEVICE));

                        if (pData != null)
                        {
                            int _iHDDNo = FindHDDbyDrvNumber(m_StatusCallback.HDDList, m_StatusCallback.m_HddDevice.drv_number);
                            if (_iHDDNo == -1)
                                m_StatusCallback.HDDList.Add(m_StatusCallback.m_HddDevice);
                        }
                        else
                            Debug.WriteLine("pData pointer error:");
                        break;

                    case (int)StatusCallbackType.STATUS_DISK_SCAN_ERROR:
                        Debug.WriteLine("SCAN_ERROR or No More Device ");
                        break;

                    case (int)StatusCallbackType.STATUS_DISK_SCAN_FINISH:
                         m_StatusCallback.WriteHddStatusCallback();
                        break;

                    case (int)StatusCallbackType.STATUS_DETECT_HDD_Mounted:
                        m_StatusCallback.m_HddDevice = (HDD_DEVICE)Marshal.PtrToStructure(pData, typeof(HDD_DEVICE));
                        if (pData != null)
                        {
                            int _iHDDNo = FindHDDbyDrvNumber(m_StatusCallback.HDDList, m_StatusCallback.m_HddDevice.drv_number);
                            if (_iHDDNo == -1)
                            {
                                m_StatusCallback.HDDList.Add(m_StatusCallback.m_HddDevice);
                                m_StatusCallback.WriteHddStatusCallback();
                            }
                        }
                        else
                            Debug.WriteLine("pData pointer error:");
                        MessageBox.Show("HDD has been Mounted");
                        break;

                    case (int)StatusCallbackType.STATUS_DETECT_HDD_UnMounted:
                        m_StatusCallback.m_HddDevice = (HDD_DEVICE)Marshal.PtrToStructure(pData, typeof(HDD_DEVICE));

                        if (pData != null)
                        {
                            int _iHDDNo = FindHDDbyDrvNumber(m_StatusCallback.HDDList, m_StatusCallback.m_HddDevice.drv_number);
                            if (_iHDDNo >= 0)
                            {
                                m_StatusCallback.HDDList.Remove(m_StatusCallback.HDDList[_iHDDNo]);
                                m_StatusCallback.WriteHddStatusCallback();
                            }
                            //for (int i = 0; i < m_StatusCallback.HDDList.Count; i++)
                            //{
                            //    if(m_StatusCallback.HDDList[i].drv_number == m_StatusCallback.m_HddDevice.drv_number )
                            //        m_StatusCallback.HDDList.Remove( m_StatusCallback.HDDList[i] );
                            //    m_StatusCallback.HDDList
                            //}
                        }
                        else
                            Debug.WriteLine("pData pointer error:");
                        MessageBox.Show("HDD has been removed");
                        break;

                    //Added in 20121018 by Edward
                    //STATUS_LIVE_DISCONNECT , STATUS_CONNECTION_FAILED ,STATUS_LOGIN_BLOCKED will ConnectionCallback
                    case (int)StatusCallbackType.STATUS_LIVE_DISCONNECT:
                        m_StatusCallback.ConnectionCallback(hDevice, iType);
                        Debug.WriteLine("Live disconnect");
                        break;

                    case (int)StatusCallbackType.STATUS_CONNECTION_FAILED:
                        m_StatusCallback.ConnectionCallback(hDevice, iType);
                        Debug.WriteLine("Connection failed");
                        break;
                    case (int)StatusCallbackType.STATUS_LOGIN_BLOCKED:
                        m_StatusCallback.ConnectionCallback(hDevice, iType);
                        Debug.WriteLine("Login blocked");
                        break;

                    //Added new callback for the Error of PlayBack Time
                    //Added in 20120203 by Edward
                    case (int)StatusCallbackType.STATUS_PLAYBACK_TIMEERROR:
                        m_StatusCallback.ConnectionCallback(hDevice, iType);
                        Debug.WriteLine("PlayBack Time Error");
                        break;

                    case (int)StatusCallbackType.STATUS_ARCHIVE_ERROR:
                        Debug.WriteLine("Archive error");
                        break;

                    case (int)StatusCallbackType.STATUS_ARCHIVE_LAST_FILENAME:
                        m_StatusCallback.m_ArvFilePath = (ArchiveFilePath)Marshal.PtrToStructure(pData, typeof(ArchiveFilePath));
                        if (pData != null)
                        {
                            string FilePath = new string(m_StatusCallback.m_ArvFilePath.file_path);
                            m_StatusCallback.ArchiveMessageCallback( hDevice, FilePath, iType);
                        }
                        else
                            Debug.WriteLine("pData pointer error:");
                        break;

                    case (int)StatusCallbackType.STATUS_ARCHIVE_LAST_BLOCKID:
                        string blockid = pData.ToString();
                        m_StatusCallback.ArchiveMessageCallback(hDevice, blockid, iType);
                        break;

                    case (int)StatusCallbackType.STATUS_TRANS_END:
                        progress = pData.ToString();
                        Debug.WriteLine("Current Trans progress is " + progress);
                        break;

                    case (int)StatusCallbackType.STATUS_DECODE_WMERROR:
                        MessageBox.Show("WaterMark Comparer Error");
                        if(pData == null)//pData can not be refered because callback function assign null
                        {
                            Debug.WriteLine("pData pointer is null");
                        }
                        break;

                }

            }
            //catch (Exception ex)
            {
                //Debug.WriteLine("Status hdd call back structure data error:" + ex.Message);
                //return 0;
            }


            return 0;
        }

         int FindHDDbyDrvNumber(List<HDD_DEVICE> HDDList, uint iDrv_Number )
         {
             for(int i=0; i<HDDList.Count; i++)
             {
                  if(m_StatusCallback.HDDList[i].drv_number == iDrv_Number )
                  {
                    return i;
                  }
             }

             Debug.WriteLine("No matched HDD");
             return -1; 
         }
         
         public void assignJ1939DetailMeta(string[] j1939_form1) 
         {
             for (int i = 0; i < 40; i++)
             {
                 j1939MsgAry[i] = j1939_form1[i];
             }
         }


     }
}