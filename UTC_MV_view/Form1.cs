using System;
using System.IO;
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
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;

namespace UTC_MV_view
{

    /// <summary>
    /// Device type
    /// (for sdk function parameters)
    /// </summary>
    /// 
    public enum DeviceType : uint
    {
        DEVICE_DVR = 1,
        DEVICE_HDD = 2,
        DEVICE_FILE = 3,
        DEVICE_MULTI_FILE = 4,
        DEVICE_BUF_DVR=5,
    }

    public enum ViewType : uint
    {
        NONE = 0,
        LIVE_VIEW = 1,
        PLAY_VIEW = 2,
        ARCHIVE = 3,
        SEARCH = 4,
        IMGLOG = 5,
        DVR_SNAPSHOT = 6,
    }

    /// <summary>
    /// Modal type
    /// (for sdk function parameters)
    /// </summary>
    public enum ModalType : uint
    {
        // MV
        MV_HDD = 0x00000400,// HDD
        MV_DVR = 0x00000410,//  DVR
        MV_IMAGE = 0x00000420,// FILE
    }

    public enum ViewInfoType : uint
    {
        PAUSE_LIVE = 0x00000000,
        FORWARD_PLAY = 0x00000001,
        REVERSE_PLAY = 0x00000002,
        NEXT_FRAME = 0x00000004,
        PREVIOUS_FRAME = 0x00000008,
        STOP = 0x00000010,
        PAUSE_PLAYBACK = 0x00000020,
        START_PLAYBACK = 0x00000040,
        SWITCH_STREAM = 0x00000080,
        VIEW_INFO = 0x00000100, // Setting video, audio and meta map (Both live view and playback), it can shift with forward/reverse play(only playback)
        REMOTE_SNAPSHOT = 0x00000200,
    }

    /// <summary>
    /// Search Conditions
    /// </summary>
    public enum SearchConditions : uint
    {
        //META_MAP = 0x01,
        //PANIC_ALARM_MAP = 0x10,
        //SEARCH_META_GPS = 0x100,
        //SEARCH_META_G_SENSOR = 0x200,
        //SEARCH_META_SPEED = 0x400,
        //SEARCH_META_INPUT = 0x2000,
        //SEARCH_META_IGN = 0x4000,
        //CHANNEL_MAP = 0xFFFF,
        //ALARM_MAP = 0x01,
        //VIDEO_LOSS_MAP = 0x02,
        //POWER_ON = 0x20,
        GSENSOR_MAP = 0x00000400,
        //GPS_MAP = 0x00000200,
        //GPS_SPEED = 0x01000000,
        //GPS_BORDER = 0x02000000,
        //SEARCH_SEGMENT = 0x20000000,

        SEARCH_COND_ALARM = 0x01,
        SEARCH_COND_VLOSS = 0x02,
        SEARCH_COND_HIGH_SPEED = 0x04,
        SEARCH_COND_GS_IMPACT = 0x08,
        SEARCH_COND_GS_ACCEL = 0x10,
        SEARCH_COND_POWER_ON = 0x20,
        SEARCH_COND_HDD_FAULT = 0x40,
        SEARCH_COND_SYSTEM_FAULT = 0x80,
        SEARCH_COND_GPS = 0x400,
        SEARCH_COND_GPS_CLOSEST = 0x01000000,
        SEARCH_COND_GPS_BORDERING = 0x02000000,
        SEARCH_COND_EVENT = 0x08000000,
        SEARCH_COND_CALENDAR = 0x10000000,
        SEARCH_COND_SEGMENT = 0x20000000,
        SEARCH_COND_GPS_MODE = 0x02000000,
        SEARCH_GPS_BY_Time         = 0x02000000,
        SEARCH_GPS_CLOSEST_POINT = 0x02000001,
        SEARCH_GPS_WHEN_VEHICLE_PASS = 0x02000002,
        SEARCH_COND_J1939_TYPE = 0x4000,  //14
    }

    public enum Speed : int
    {
        SPEED_1_32X = -32,	//	1/32
        SPEED_1_16X = -16,	//	1/16
        SPEED_1_8X = -8,	//	1/8
        SPEED_1_4X = -4,	//	1/4
        SPEED_1_2X = -2,	//	1/2
        SPEED_0X = 0,		//	0
        SPEED_1X = 1,		//	1
        SPEED_2X = 2,		//	2
        SPEED_4X = 4,		//	4
        SPEED_8X = 8,		//	8
        SPEED_16X = 16,		//	16
        SPEED_32X = 32,		//	32
    }

    public enum PlayTimeMode : uint
    {
        NORMAL_SEEK = 0,
        SEEK_AND_PLAY,
    }

    /// <summary>
    /// Media Type
    /// </summary>
    public enum MediaType : uint
    {
        MEDIA_EDR = 1,
        MEDIA_P2 = 2,
        MEDIA_MV3 = 4,
        MEDIA_AVI = 0x100,
        MEDIA_XML = 0x110,
        MEDIA_IMGLOG=0x120,
        NEW_MEDIA_IMGLOG,
    }

    /// <summary>
    /// Search diskmap time scale type
    /// (for sdk function parameters)
    /// </summary>
    public enum DiskmapScale : uint
    {
        YEAR = 0,
        MONTH = 1,
        DAY = 2,
        HOUR = 3
    }

    /// <summary>
    /// EventType
    /// </summary>
    public enum EventType : uint
    {
        OTHERS,
        ALARM = 0,
        VLOSS = 1,
        HIGH_SPEED = 2,
        GS_IMPACT = 3,
        GS_ACCEL = 4,
        POWER_ON = 5,
        HDD_FAULT = 6,
        SYS_FAULT = 7,
        TEXTA = 8,
        TEXTB = 9,
        GPS = 10,
        G_SENSOR_META = 11,
        G_SENSOR_ALM = 12,
        J1939_TYPE = 14,
        SEGMENT = 29,
        END_OFFSET = 64,
    }

    /// <summary>
    /// Error Message
    /// </summary>
    public enum ErrorMessage : int
    {
        OTHERS,
        SDK_FAIL = -1,
        SDK_FW_UPDATE_FAIL	= -12,
        DVRSDK_CONNECTION_FAILED = -20,
        DVRSDK_NO_DATA = -21,
        DVRSDK_UNDEFINED_TYPE = -22,
        DVRSDK_TYPE_MISMATCH = -23,
        DVRSDK_CONDITIONS_FAIL = -24,
    }

    /// <summary>
    /// enumerator for selected button
    /// </summary>
    public enum enumBtnSelected : int 
    {
        SysLogButton = 1,
        DVRLogButton,
    }


    /// <summary>
    /// GPS Parameter
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct GPS_POINT
    {
        ///usigned int
        public byte lat_section;//0: South, 1: North 

        /// unsigned int
        public uint lat_value;//GPS lat value

        ///usigned int
        public byte lon_section;//0: East, 1: West 

        /// unsigned int
        public uint lon_value;//GPS lon value

    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct moblie_view
    {
        /// char[72]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 72)]
        public string szUrl;

        /// unsigned short
        public ushort usWebPort;

        /// char[20]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string szUID;

        /// char[20]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string szPWD;

        /// char[6]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string szReserve;
    }

    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct DEVICE
    {
        [FieldOffsetAttribute(0)]
        public moblie_view mv;

    }

    /// <summary>
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

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CONNECT_PARAM_T
    {
        /// U32->unsigned int
        public ModalType dwModal;

        /// DEVICE
        public DEVICE device;
    }

    /// <summary>
    /// Added by Edward in 2012/12/20
    /// The strcture is used for device list
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Device_List_Entry_T
    {
        /// U32->unsigned int
        public OPEN_DEVICE_PARAM_T Device_Param;

        /// DEVICE
        public IntPtr Device_Ptr;
    }

    /// <summary>
    /// HDD parameter
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct HDD_INFO
    {

        /// unsigned int
        public uint product;//[0-3]

        /// unsigned int
        public uint model;//[4-7]

        /// unsigned short
        public uint local_channels;//[8-9]

        /// unsigned int
        public uint fw_version;//[10-13]

        /// unsigned short
        public uint av_format;//[14-15]

        /// unsigned int
        public uint start_time;//[48-51]

        /// unsigned int
        public uint end_time;//[52-55]

        /// unsigned int
        public uint video_map;//[56-59]

        /// unsigned int
        public uint audio_map;//[60-63]

        /// unsigned char[16]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string vehicle_id;

        //unsigned int 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] serial_number;//[16-47] 

        /// unsigned char[8][16]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] input_description;

        //unsigned char
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] hdd_serial;//16byte 

        //start time zone
        public int	  start_offset;		  // [276-279]
	    //end time zone
        public int	  end_offset;         // [280-283]
	    //start day light saving
        public uint	  start_ds;           // [284-287]
	    //end day light saving
        public uint	  end_ds;             // [288-291]
    }

    //MV3 META_SEARCH 
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct MV3_META_SEARCH_T
    {
        /// unsigned char
        public byte ign; // 2bit: 0 on, 1 off (0x00-0x03)

        /// unsigned char
        public byte input;// 8bit (0-0xff)

        /// unsigned short
        public ushort speed; // 2bit: 0 over, 1 under (0x00-0x03)

        /// unsigned short
        public ushort speed_over; // unit:MPH

        /// unsigned short
        public ushort speed_under;// unit:MPH

        /// unsigned char
        public byte g_sensor;// 3bit: 0 x, 1 y, 2 z (0x00-0x07)

        /// unsigned char
        public byte g_x_val;

        /// unsigned char
        ///It is reserved now ,becasue EMV do not use it
        public byte g_x_fract; // unit:1/256
        /// unsigned char
        public byte g_x_dir; // 0:plus, 1:negative

        /// unsigned char
        public byte g_y_val;

        /// unsigned char
        ///It is reserved now ,becasue EMV do not use it
        public byte g_y_fract;

        /// unsigned char
        public byte g_y_dir;

        /// unsigned char
        public byte g_z_val;

        /// unsigned char
        ///It is reserved now ,becasue EMV do not use it
        public byte g_z_fract;

        /// unsigned char
        public byte g_z_dir;

        /// unsigned short
        public ushort gps_inout; //2bit: 0 exit, 1 entry (0x00 - 0x03)

        /// unsigned char
        public byte gps_lat1_sn; // 1:n, 0:s

        /// unsigned char
        public byte gps_lon1_ew;// 0:e, 1:w

        /// unsigned char
        public byte gps_lat2_sn; // 1:n, 0:s

        /// unsigned char
        public byte gps_lon2_ew;// 0:e, 1:w

        /// unsigned int
        public uint gps_lat1;//ddmm.mmmm * 10000

        /// unsigned int
        public uint gps_lon1;//ddmm.mmmm * 10000

        /// unsigned int
        public uint gps_lat2;//ddmm.mmmm * 10000

        /// unsigned int
        public uint gps_lon2;//ddmm.mmmm * 10000

        /// unsigned short
        public ushort range; //0~3

        /// unsigned char
        public byte g_value1; //1~127

        /// unsigned char
        public byte g_value2; //1~127

        /// unsigned char
        public byte unit;  //0~1

        /// unsigned short
        public ushort mode; //0~3

        /// unsigned char
        public byte radius; // 0~100

        /// unsigned short
        public byte a_index;

        /// unsigned short
        public ushort v_index;
    }

    ///// <summary>
    ///// Search event structure in MV3
    ///// (for sdk function parameters)
    ///// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct EVENT_T_MV3
    {
        public uint uiEventID;
        public uint uiEventType;    //refer to the tag<type>
        public uint uiExt;          //used to get camera map //refer to the tag<cam>
        public uint uiblock_start;
        public uint uiFragID;       //for hdd
        public uint StartTime;
        public uint EndTime;
        public uint speed;          // speed rate, speed = xxx.xx(000.0~999.9) * 100, unit:nmi
        public uint acc;            // vehicle acceleration, B0-7:X value, B8-15:Y value, B16-23: Z value //refer to the tag<acc>
        public uint course;         // course, course = xxx.x(000.0~359.9) * 10  //refer to the tag<dir>
        public uint lat;            // u32// latitude, lat = ddmm.mmmm * 10000
        public uint lon;            //u32  // longitude, lon = dddmm.mmmm * 10000
        public byte lat_sn;         // 0:s, 1:n
        public byte lon_ew;         // 0:n, 1:e
        public byte priority;       // alarm priority  //refer to the tag<pri>
        public byte a_index;        // Event index  //refer to the tag<aidx>
        public ushort v_index;      // Vehicle ID index  //refer to the tag<vidx>
        //public byte v_index;      // Vehicle ID index  //refer to the tag<vidx>
        public byte ucPre;          //Pre alarm time //unit is minute
        public byte ucPost;         //Post alarm time //unit is minute
        public sbyte offset;         //TimeZone on DVR
        public byte dst;            //DayLightSaving on DVR
        public uint chnmap;         //Channel Map which will change FPS when alarm happened
        /// char[80]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szEventMsg;
        ///unsigned char[16]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] eventName;
    }

    /// <summary>
    /// Search event structure
    /// (for sdk function parameters)
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct EVENT_T_P2
    {
        /// unsigned int
        public uint uiEventID;

        /// unsigned int
        public uint uiEventType;

        /// unsigned int
        public uint uiExt;

        /// unsigned int
        public uint uiBlockID;

        /// unsigned int
        public uint uiFragID;

        /// int
        public int nStartTime;

        /// int
        public int nEndTime;

        /// int
        public int nPreAlarm;

        /// char[80]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szEventMsg;
    }

    //[StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DISKMAP_T_P2
    {
        /// unsigned int
        public uint uiRecordStatus;

        /// int
        public int nScaleType;

        /// int
        public int nStartTime;

        /// int
        public int nEndTime;

        /// unsigned int
        public uint uiFragID;

        /// unsigned int
        public uint uiChannel;
    }

    /// <summary>
    /// Search event structure
    /// (for sdk function parameters)
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct DVR_LOCAL_TIME
    {
        /// unsigned char
        public uint uDVRTime;

        /// unsigned char
        public sbyte TimeZone;

        /// unsigned char
        public byte DayLightSaving;

        /// unsigned char
        public uint uDVRTimeMiniSec;
    }



    public partial class view : Form
    {
        const int PAUSE_SPEED = 0;
        const int NORMAL_SPEED = 1;
        IntPtr ptr = IntPtr.Zero;
        IntPtr ptr2 = IntPtr.Zero;
        IntPtr[] phRender = new IntPtr[16];
        string str_IP="";
        int int_port=0;
        string str_username="";
        string str_password ="";
        private CheckBox[] cb_CamArr = new System.Windows.Forms.CheckBox[16];
        private PictureBox[] pb_CamArr = new System.Windows.Forms.PictureBox[16];

        int CurrentChannel = 1;//channel number starts from 0 to max-1
        int maskvalue;//convert current CH number to bit mask
        uint audiomask = 0;
        int forward_speed = 0;
        int backward_speed = 0;
        int int_CH_NO_Left = 0;
        int int_CH_NO_Right = 0;
        ModalType mtSelectedType;//Current selected modal
        bool bRecVideo = false;//added by Edward in 20110906 for video recording

        public CallbackClass class_callback;
        public Archive cl_Archive;
        public ImgLog cl_ImgLog;//added by Edward in 20110118 for Image log enhancement
        META_DATA_T metadata = new META_DATA_T();
        ArrayList olddeviceset = new ArrayList();
        ArrayList newdeviceset = new ArrayList();

        bool bSSTimer = false;
        String foldername = "";
        IntPtr SnapShotptr = IntPtr.Zero;
        uint nSnapshotMask = 0;

        public String[] j1939MsgAry = new String[40];


        //Added by Edward in 2011/12/20
        //Device list should manage opened device
        //Infomation of opened device should stall in it and search opend device by device's pointer
        //When user want to close device, he should check the device is the list or not.
        //And the arguments use to close source should come from device list 
        List<Device_List_Entry_T> DeviceList = new List<Device_List_Entry_T>();

        //HRESULT DLLAPI SdkShellInitial( long lMaxCh );//nMaxCh for videoWindow
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitial(int nMaxCh);

        //HRESULT DLLAPI SdkShellInitialSource( HDevice *hDevice, DWORD dwDeviceType, DWORD dwModal, DWORD dwVersion );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellInitialSource(ref IntPtr hDevice, DeviceType dwDeviceType, ModalType dwModal, uint dwVersion);

        //HRESULT DLLAPI SdkShellOpenSource( HDevice hDevice, LPOPEN_DEVICE_PARAM_T stOpenParam, DWORD dwViewMode, long lParameter1 );//dwViewMode Live or playback, Parameter1:playback time
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellOpenSource(IntPtr hDevice, ref OPEN_DEVICE_PARAM_T stOpenParam, ViewType dwViewMode, int lParameter1);

        //HRESULT DLLAPI SdkShellCreateVideoWindow( HANDLE *phRender, HDevice hDevice, BYTE nCh, HWND hWnd );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCreateVideoWindow(ref IntPtr phRender, IntPtr hDevice, byte nCh, IntPtr hWnd);

        //HRESULT DLLAPI SdkShellRemoveVideoWindow( HANDLE hRender );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellRemoveVideoWindow(IntPtr phRender);

        [DllImportAttribute("SdkShell.dll")]
        //private static extern int SdkShellSetStreamInfo(IntPtr hDevice, uint dwVideoMap, uint dwAudioMap, uint dwMetaMap, uint dwStreamCtrl, Speed speed);
        private static extern int SdkShellSetStreamInfo(IntPtr hDevice, uint dwVideoMap, uint dwAudioMap, uint dwMetaMap, uint dwDualMap, uint dwStreamCtrl, Speed speed);

        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSetAudioCH(IntPtr hLeftDevice, int lLeftCH, IntPtr hRightDevice, int lRightCH);

        // EFRESULT _stdcall SdkShellSetAudioVolume( long lLeftVolume, long lRightVolume );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSetAudioVolume(int lLeftVolume, int lRightVolume);


        //HRESULT DLLAPI SdkShellSnapshot( HANDLE hRender, char* pFileName );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSnapshot(IntPtr phRender, string pFileName);

        //HRESULT DLLAPI SdkShellCloseSource( HDevice hDevice, DWORD dwModal );//dwModal??
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCloseSource(IntPtr hDevice, ModalType dwModal);

        //HRESULT DLLAPI SdkShellReleaseSource( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellReleaseSource(IntPtr hDevice);

        //HRESULT DLLAPI SdkShellRelease();
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellRelease();

        // EFRESULT DLLAPI SdkShellUpdateWindow();
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellUpdateWindow(int isForceUpdate);

        // EFRESULT DLLAPI SdkShellSetPlayTime( HDevice hDevice, DWORD dwPlayMode, long lPlayTime );
        [DllImportAttribute("SdkShell.dll")]
        //private static extern int SdkShellSetPlayTime(IntPtr hDevice, uint dwPlayMode, int lPlayTime);
        private static extern int SdkShellSetPlayTime(IntPtr hDevice, uint dwPlayMode, int lPlayTime, uint uiFragID);

        //HRESULT DLLAPI SdkShellScanHDD( DWORD dwModal );//Scan current connected drivers
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellScanHDD(ModalType dwModal);

        //HRESULT DLLAPI SdkShellGetDeviceInfo( HDevice hDevice, long *lResultType, void *pResult );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetDeviceInfo(IntPtr hDevice, ref IntPtr lResultType, IntPtr pResult);

        //HRESULT DLLAPI SdkShellStopAllSource(DWORD dwModal )
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellStopAllSource(ModalType dwModal);

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

        /// <summary>
        /// Method of Diskmap
        /// </summary>
        //HRESULT DLLAPI SdkShellSearchDiskmap( HDevice hDevice, long lStartTime, long lEndTime, DWORD dwScaleType );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSearchDiskmap(IntPtr hDevice, int startTime, int endTime, DiskmapScale dwScaleType);

        //HRESULT DLLAPI SdkShellGetDiskmapItem( HDevice hDevice, long lItem, long *lResultType, void *pResult );
        [DllImportAttribute("SdkShell.dll")]
        private static extern bool SdkShellGetDiskmapItem(IntPtr hDevice, int nIndex, ref IntPtr lResultType, IntPtr pResult);

        //HRESULT DLLAPI SdkShellStopSearchDiskmap( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellStopSearchDiskmap(IntPtr hDevice);

        //long DLLAPI SdkShellGetDiskmapCount( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetDiskmapCount(IntPtr hDevice);

        //EFRESULT _stdcall SdkShellStartLiveRec( HDevice hDevice, long lCH, char* pFileName );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellStartLiveRec(IntPtr hDevice, int dwChannelMap, string pFileName);

        //EFRESULT _stdcall SdkShellStopLiveRec( HDevice hDevice );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellStopLiveRec(IntPtr hDevice);
        /** 
        *********************************************************************
        * @fn<efTransIMGLOG>
        * @brief<This part will save all I frames from a .avr file>
        * @param[in]
        * < pInputFile:file path of .avr file>
        * < lInputType: Input media type> 
        * < pOutputFile:Series Name of JPGs>
        * < lOutputType: Output media type>
        * < lChannelMask: Selected Channels> 
        * < lStartTime: Reservered, Set as 0>
        * < lEndTime: Time Span limitation of input .avr file. If .avr files time span longer than value, function will break>
        * < dwDeviceType: Device Type> 
        * < dwModal: Modal>
        * < hWnd: Because we use D3D to render and save jpg, we must give a window handle to EFRender.dll>
        * @return <EFRESULT >
        *********************************************************************
        */
        // HRESULT DLLAPI SdkShellFileTrans( char* pInputFile, long lInputType, char* pOutputFile, long lOutputType, long lChannel, long lStartTime, long lEndTime ,, HWND hWnd);
        [DllImportAttribute("SdkShell.dll")]
        //private static extern int SdkShellFileTrans(string pInputFile, int lInputType, string pOutputFile, int lOutputType, int lChannel, int lStartTime, int lEndTime, HWND hWnd);
        private static extern int SdkShellFileTrans(string pInputFile, int lInputType, string pOutputFile, int lOutputType, int lChannel, int lStartTime, int lEndTime, UInt32 uiPicLimit,IntPtr hWnd);

        //EFRESULT _stdcall SdkShellWaterMarkCBEnable( HDevice hDevice, bool bWaterMarkCBEnable );
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellWaterMarkCBEnable(IntPtr hDevice, bool bWaterMarkCBEnable);

        //added by 20130619 Edward for remote snapshot
        //EFRESULT	RemoteSnapShot( HDevice hDevice, DWORD dwSnapShotCH, DWORD dwStreamCtrl, unsigned char *jpg, int *jpgLength, unsigned int *PicTime);//added by Edward 20130619
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellRemoteSnapShot(IntPtr hDevice, uint uSnapShotCH, uint dwStreamCtrl, byte[] jpg, out int jpgLength, out uint uPicTime);

        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCombineFile(IntPtr hDevice, string p_cpInputFile1, string p_cpInputFile2, string p_cpOutputFile); //Soya add 20130709

        //extern EFRESULT _stdcall SdkShellRemoSnapShot_Start(HDevice hDevice, DWORD dwSnapShotCH, DWORD dwPlayTime, DWORD dwStreamCtrl);
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellRemoSnapShot_Start(IntPtr hDevice, uint uSnapShotCH, uint dwPlayTime, uint dwStreamCtrl); //Edward add 20130906

        //extern EFRESULT _stdcall SdkShellContinueSnapShot_Start(HDevice hDevice, DWORD dwVideoMap, DWORD dwStreamCtrl);
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellContinueSnapShot_Start(IntPtr hDevice, uint dwVideoMap, uint dwStreamCtrl); //Edward add 20130906

        public view()
        {
            //result = SdkShellInitial(32);
            InitializeComponent();
            //Enable and disable buttons
            Pausebtn.Enabled = false;
            Resumebtn.Enabled = false;
            Stopbtn.Enabled = false;
            CameraBox.Enabled = true;
            fast_forward.Enabled = false;
            backward.Enabled = false;
            fast_backward.Enabled = false;
            step_forward.Enabled = false;
            step_backward.Enabled = false;
            Select_Left_Aud.SelectedIndex = 0;
            Aud_GB.Enabled= false;
            ChangeCamera.Enabled = false;
            StopDVR.Enabled = false;

            for (int i = 0; i < 16; i++)
                phRender[i] = IntPtr.Zero;

            // camera array
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

            //picture box array
            pb_CamArr[0] = video_view1;
            pb_CamArr[1] = video_view2;
            pb_CamArr[2] = video_view3;
            pb_CamArr[3] = video_view4;
            pb_CamArr[4] = video_view5;
            pb_CamArr[5] = video_view6;
            pb_CamArr[6] = video_view7;
            pb_CamArr[7] = video_view8;
            pb_CamArr[8] = video_view9;
            pb_CamArr[9] = video_view10;
            pb_CamArr[10] = video_view11;
            pb_CamArr[11] = video_view12;

            int result;
            result = SdkShellInitial(32);
            Select_Modaltype.SelectedIndex = 0;
            class_callback = new CallbackClass();
            IntPtr _piempty = IntPtr.Zero;
            class_callback.StatusCallback_assign(_piempty);
            class_callback.m_StatusCallback.UploadData += new EventHandler(Writetextbox);//When dll use the callback function, EventHandler will call writetextbox

            DVR_Gsensor_Search.Enabled = false; //DVR G sensor close
            HDD_G_Sensor.Enabled = false;   //HDD G sensor close
            File_G_Sensor.Enabled = false;  //File G sensor close

            //Express as utc Time
            DateTime CurrentLocalTime = DateTime.Now;
            DateTime CurrentUTCTime = CurrentLocalTime.ToUniversalTime();
            CurrentTime_Picker.Value = CurrentUTCTime;
            Playbacktime_Picker.Value = CurrentUTCTime;

        }
        
        private void Livebtn_Click(object sender, EventArgs e)
        {
            if ((IP_tb.Text.Length == 0) && (Select_Modaltype.SelectedIndex != 2) && (Select_Modaltype.SelectedIndex != 3))
            {
                MessageBox.Show("IP string is Empty");
                return;
            }

            for (int i = 0; i < 12; i++) 
            {
                pb_CamArr[i].Refresh();
            }

            int result = 0;
            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username =account_tb.Text;
            str_password = password_tb.Text;
            DeviceType _dtDeviceType;

            //Initial shell and Source
            
 

            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1)) //0:DVR_Live, 1:DVR_PlayBack
            {
                mtSelectedType = ModalType.MV_DVR;
                _dtDeviceType = DeviceType.DEVICE_DVR;

                getJ1939MetaDetail();
                class_callback.assignJ1939DetailMeta(j1939MsgAry);
            }
            else if (Select_Modaltype.SelectedIndex == 2)   //2:HDD
            {
                int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
                _iSelectedHDD = _iSelectedHDD - 1;
                if (CheckHDDList(_iSelectedHDD) == true)
                {
                    mtSelectedType = ModalType.MV_HDD;
                    _dtDeviceType = DeviceType.DEVICE_HDD;
                }
                else
                    return;
            }
            else if (Select_Modaltype.SelectedIndex == 3)   //3:File
            {
                mtSelectedType = ModalType.MV_IMAGE;
                _dtDeviceType = DeviceType.DEVICE_FILE;
            }
            else
            {
                mtSelectedType = ModalType.MV_DVR;
                _dtDeviceType = DeviceType.DEVICE_DVR;
            }

            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(mtSelectedType);
            result = SdkShellInitialSource(ref ptr, _dtDeviceType, stOpenParam.dwModal, 0);


            show_meta_data( );
            if (Select_Modaltype.SelectedIndex == 0)
            {
                result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.LIVE_VIEW, 0);
            }
            else if (Select_Modaltype.SelectedIndex == 1)
            {
                //set playback time
                DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
                int playTime = (int)((Playbacktime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time

                result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.PLAY_VIEW, playTime);
                result = SdkShellSetPlayTime(ptr, (uint)PlayTimeMode.SEEK_AND_PLAY, playTime, 0);//uiFragID will be used when anyone changed the device time.
            }
            else if (Select_Modaltype.SelectedIndex == 2)
            {
                //set playback time
                DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
                int playTime = (int)((Playbacktime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
                int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
                _iSelectedHDD = _iSelectedHDD - 1;
                stOpenParam.dwDiskID = class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number;
                result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.PLAY_VIEW, playTime);
                result = SdkShellSetPlayTime(ptr, (uint)PlayTimeMode.SEEK_AND_PLAY, playTime, 10);//uiFragID will be used when anyone changed the device time.
            }
            else if (Select_Modaltype.SelectedIndex == 3)//play saved video
            {
                //Set playback time
                DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
                int playTime = (int)((Playbacktime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time
                if (stOpenParam.szFileName == null)
                {
                    MessageBox.Show("Please select any saved video!");
                    return;
                }
                //If user want to play this video from certain time, he must assign the timestamp to last parameter in the function.
                //ex: SdkShellOpenSource(ptr, ref stOpenParam, ViewType.PLAY_VIEW, playTime);
                //     SdkShellSetPlayTime(ptr, (uint)PlayTimeMode.SEEK_AND_PLAY, playTime, 10);
                result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.PLAY_VIEW, 0);
                if (result < 0)
                {//20140114 To add this to know if the file does exit or not by John
                    if (File.Exists(@stOpenParam.szFileName))
                    {
                        //MessageBox.Show("file exits.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("OpenSource error! File does not exist.");
                        return;
                    }
                }
                result = SdkShellSetPlayTime(ptr, (uint)PlayTimeMode.SEEK_AND_PLAY, 0, 10);//uiFragID will be used when anyone changed the device time.
            }
            else
            {
                result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.LIVE_VIEW, 0);
            }
            //Added by Edward in 2011/12/20 for adding opend device to device list
            //Because those device is used to play video and audio.

            Device_List_Entry_T OpenedDevice = new Device_List_Entry_T();
            OpenedDevice.Device_Ptr = ptr;
            OpenedDevice.Device_Param = stOpenParam;
            DeviceList.Add(OpenedDevice);

            CurrentChannel = 0;
            maskvalue = 0;
            byte CurrentChannel_byte = 0;
            for (int i = 0; i < 12; i++)
            {
                maskvalue += (cb_CamArr[i].Checked ? 1 : 0) << i;

                //Give the selected picture box's handle to the dll
                if (cb_CamArr[i].Checked)
                {
                    CurrentChannel_byte = Convert.ToByte(CurrentChannel);
                    result = SdkShellCreateVideoWindow(ref phRender[i], ptr, CurrentChannel_byte, pb_CamArr[i].Handle);
                }
                CurrentChannel++;
            }
            audiomask = (uint)maskvalue; //for audio mask
            //set stream information and audio channel
            ViewInfoType view_info_type;
            view_info_type = (ViewInfoType.VIEW_INFO);
            Speed playspeed;
            playspeed = Speed.SPEED_1X;

            int_CH_NO_Left = Convert.ToInt32(Select_Left_Aud.SelectedIndex);

            //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 255, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
            if (Select_Modaltype.SelectedIndex == 0 || Select_Modaltype.SelectedIndex == 1)
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 255, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, audiomask, 255, 0, (uint)view_info_type, playspeed);// neil modify
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, audiomask, 255, 0, (uint)view_info_type, playspeed);
                else
                    result = SdkShellSetStreamInfo(ptr, 0, audiomask, 0, (uint)maskvalue, (uint)view_info_type, playspeed);//add audio mask
                
            }
            else if (Select_Modaltype.SelectedIndex == 2 || Select_Modaltype.SelectedIndex == 3)
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 255, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, 0, 255, 0, (uint)view_info_type, playspeed);// modify by Edward for new step play method
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, audiomask, 255, 0, (uint)view_info_type, playspeed);// neil modify
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, 0, 255, 0, (uint)view_info_type, playspeed);
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            if (result < 0)
            {
                MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                //return;
            }
            if (result == 0)
                Selected_Speed.Text = Convert.ToString(NORMAL_SPEED);
            else
                Console.WriteLine("SetStreamInfo returns error!");

            result = SdkShellSetAudioCH(ptr, int_CH_NO_Left, ptr, int_CH_NO_Left);

            //Enable and disable buttons
            Livebtn.Enabled = false;
            Search_HDD.Enabled = false;
            //CameraBox.Enabled = false;
            Resumebtn.Enabled = true;
            Pausebtn.Enabled = true;
            Stopbtn.Enabled = true;
            //Set_Aud_CH.Enabled = true; 
            Aud_GB.Enabled = true;
            ChangeCamera.Enabled = true;
            StopDVR.Enabled = true;

            if ( (Select_Modaltype.SelectedIndex == 1) || (Select_Modaltype.SelectedIndex == 2) ||(Select_Modaltype.SelectedIndex==3) )
            {
                fast_forward.Enabled = true;
                backward.Enabled = true;
                fast_backward.Enabled = true;
                step_backward.Enabled = true;
                step_forward.Enabled = true;
            }
            else if (Select_Modaltype.SelectedIndex == 0)
            {
                fast_forward.Enabled = false;
                backward.Enabled = false;
                fast_backward.Enabled = false;
                step_backward.Enabled = false;
                step_forward.Enabled = false;
            }
            else
            {
                fast_forward.Enabled = false;
                backward.Enabled = false;
                fast_backward.Enabled = false;
                step_backward.Enabled = false;
                step_forward.Enabled = false;
            }


            Search_HDD.Enabled = false;
            Get_HDDInfo.Enabled = false;
            //Set speed to default
            forward_speed = 1;
            backward_speed = 0;
            //Set current ModalType

        }

        private void Pausebtn_Click(object sender, EventArgs e)
        {
            //select pause mode
            ViewInfoType view_info_type;
            if ((Select_Modaltype.SelectedIndex == 1) || (Select_Modaltype.SelectedIndex == 2))
                view_info_type = ViewInfoType.PAUSE_PLAYBACK;
            else if (Select_Modaltype.SelectedIndex == 0)
                view_info_type = ViewInfoType.PAUSE_LIVE;
            else
                view_info_type = ViewInfoType.PAUSE_LIVE;

            Speed playspeed;
            playspeed = Speed.SPEED_0X;
            forward_speed = 0;
            backward_speed = 0;
            int result = 0;
            //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }

            //ViewType should be "PAUSE_LIVE" or "PAUSE_PLAYBACK"
            if (result == 0)
                Selected_Speed.Text = Convert.ToString( PAUSE_SPEED);
            else
                Console.WriteLine("SetStreamInfo returns error!");
        }

        private void Resumebtn_Click(object sender, EventArgs e)
        {
            ViewInfoType viewtype;
            viewtype = (ViewInfoType.VIEW_INFO|ViewInfoType.FORWARD_PLAY);
            Speed playspeed;
            playspeed = Speed.SPEED_1X;
            int result = 0;

            uint mask_CH_NO;
            mask_CH_NO = audiomask;

            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream 
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream 
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (result == 0)
                Selected_Speed.Text = Convert.ToString( NORMAL_SPEED);
            else
                Console.WriteLine("SetStreamInfo returns error!");
            //Set the origin maskvalue and channel number to the function
            forward_speed = 1;
            backward_speed = 0;
        }

        private void Stopbtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Close Start");
            for (int i = 0; i < 12; i++)
            {
                //Give the selected picture box's handle to the dll
                if (cb_CamArr[i].Checked)
                {
                    SdkShellRemoveVideoWindow(phRender[i]);
                    pb_CamArr[i].Refresh();
                }
            }

            //Close source and release source
            //Do not release shell when you want close and release source
            //This will cause the rest source have to no shell
            //Please close shell only when you do not need to use SDK anymore.
            
            //added by Edward in 2011/12/20
            //In this sample, we only release shell when we close the whole sample
            //Release Selected device, Find the device infomation from device list and check this device is in the list

            int _iDeviceIdx=-1;
            for(int i =0; i<DeviceList.Count; i++)
            {
                if(DeviceList[i].Device_Ptr == ptr)
                {
                    _iDeviceIdx = i;
                    break;
                }
            }
            if(_iDeviceIdx ==-1)
            {
                MessageBox.Show("Deive is not in the List");
                return;
            }
            mtSelectedType = DeviceList[_iDeviceIdx].Device_Param.dwModal;
            if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_DVR)
                SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_DVR);
            else if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_HDD)
                SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_HDD);
            else if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_IMAGE)
                SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_IMAGE);
            else
            {
                MessageBox.Show("No Such ModalType");
                return;
            }

            SdkShellReleaseSource(DeviceList[_iDeviceIdx].Device_Ptr);
            Debug.WriteLine("Close End");
            //SdkShellRelease();
            ptr = IntPtr.Zero;

            DeviceList.Remove(DeviceList[_iDeviceIdx]);
            //Enable and disable buttons
            Livebtn.Enabled = true;
            Search_HDD.Enabled = true;
            Get_HDDInfo.Enabled = true;

            Resumebtn.Enabled = false;
            Pausebtn.Enabled = false;
            Stopbtn.Enabled = false;
            CameraBox.Enabled = true;
            fast_forward.Enabled = false;
            backward.Enabled = false;
            fast_backward.Enabled = false;
            step_forward.Enabled = false;
            step_backward.Enabled = false;
            Aud_GB.Enabled = false;
            ChangeCamera.Enabled = false;
            StopDVR.Enabled = false;

            //Set speed to default
            forward_speed = 0;
            backward_speed = 0;
            Selected_Speed.Text = Convert.ToString(PAUSE_SPEED);
        }

        private void veiw1_onpaint(object sender, PaintEventArgs e)
        {

        }

        private void On_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close source and release source and shell if user do not use "Stop" button
            //Remove all active window, add by James in 2012/02/02
            for (int i = 0; i < 12; i++)
            {
                //Give the selected picture box's handle to the dll
                if (cb_CamArr[i].Checked)
                {
                    SdkShellRemoveVideoWindow(phRender[i]);
                }
            }
            //Close source according to DeiveList, add by Edward in 2011/12/20
            for (int i = 0; i < DeviceList.Count; i++)
            {
                

                int ptr_value = DeviceList[i].Device_Ptr.ToInt32();
                if (ptr_value != 0)
                {
                    if (DeviceList[i].Device_Param.dwModal == ModalType.MV_DVR)
                        SdkShellCloseSource(DeviceList[i].Device_Ptr, ModalType.MV_DVR);
                    else if (DeviceList[i].Device_Param.dwModal == ModalType.MV_HDD)
                        SdkShellCloseSource(DeviceList[i].Device_Ptr, ModalType.MV_HDD);
                    else if (DeviceList[i].Device_Param.dwModal == ModalType.MV_IMAGE)
                        SdkShellCloseSource(DeviceList[i].Device_Ptr, ModalType.MV_IMAGE);
                    else
                        SdkShellCloseSource(DeviceList[i].Device_Ptr, ModalType.MV_DVR);

                    SdkShellReleaseSource(DeviceList[i].Device_Ptr);
                }
            }

            DeviceList.Clear();
            SdkShellRelease();
        }

        private OPEN_DEVICE_PARAM_T CreateDeviceParam( ModalType _mtSelectedType)
        {
            OPEN_DEVICE_PARAM_T stOpenParam = new OPEN_DEVICE_PARAM_T();
            if( _mtSelectedType== ModalType.MV_DVR)
                stOpenParam.dwDeviceType = DeviceType.DEVICE_DVR;
            else if(_mtSelectedType==ModalType.MV_HDD)
                stOpenParam.dwDeviceType = DeviceType.DEVICE_HDD;
            else if (_mtSelectedType==ModalType.MV_IMAGE)
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

        private void MainForm_onpaint(object sender, PaintEventArgs e)
        {
            int resultB = SdkShellUpdateWindow(0);
            Console.WriteLine("MainForm write line");
        }

        //If button and picbox are in the same groupbox. Group_onpaint will be needed
        private void group1_onpaint(object sender, PaintEventArgs e)
        {
           //int resultB = SdkShellUpdateWindow(0);
           //Console.WriteLine("Group1 write line");
        }

        private void fast_forward_Click(object sender, EventArgs e)
        {
            //valid speed value is 1,2,4,8,16,32
            backward_speed = 0;
            if (forward_speed == 0|| forward_speed==1)
            {
                forward_speed = 2;
            }
            else if ((forward_speed >= 2) && (forward_speed < 32))
            {
                forward_speed = forward_speed << 1;
            }
            else if (forward_speed >= 32)
            {
                forward_speed = 32;
            }
            else 
            {
                MessageBox.Show("Exception speed!!!");
            }
            ViewInfoType view_info_type;
            view_info_type = (ViewInfoType.FORWARD_PLAY);
            Speed playspeed;
            playspeed = (Speed)forward_speed;
            int result = 0;
            //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);//Set the origin maskvalue to the function
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (result == 0)
                Selected_Speed.Text = Convert.ToString(forward_speed);
            else
                Console.WriteLine("SetStreamInfo returns error!");
        }

        private void backward_Click(object sender, EventArgs e)
        {
            ViewInfoType viewtype;
            viewtype = (ViewInfoType.VIEW_INFO | ViewInfoType.REVERSE_PLAY);
            Speed playspeed;
            playspeed = Speed.SPEED_1X;
            int result = 0;
            //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);//Set the origin maskvalue to the function
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (result == 0)
                Selected_Speed.Text = Convert.ToString(NORMAL_SPEED);
            else
                Console.WriteLine("SetStreamInfo returns error!");

            forward_speed = 0;
            backward_speed = 1;
        }

        private void fast_backward_Click(object sender, EventArgs e)
        {
            //valid speed value is 1,2,4,8,16,32
            forward_speed = 0;
            if (backward_speed == 0 || backward_speed==1)
            {
                backward_speed = 2;
            }
            else if ((backward_speed >= 2) && (backward_speed < 32))
            {
                backward_speed = backward_speed << 1;
            }
            else if (backward_speed >= 32)
            {
                backward_speed = 32;
            }
            else
            {
                MessageBox.Show("Exception speed!!!");
            }

            ViewInfoType view_info_type;
            view_info_type = (ViewInfoType.REVERSE_PLAY);
            Speed playspeed;
            playspeed = (Speed)backward_speed;
            int result = 0;
            //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);//Set the origin maskvalue to the function
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (result == 0)
                Selected_Speed.Text = Convert.ToString(backward_speed);
            else
                Console.WriteLine("SetStreamInfo returns error!");
        }

        private void step_forward_Click(object sender, EventArgs e)
        {
            ViewInfoType viewtype;
            viewtype = (ViewInfoType.NEXT_FRAME);
            Speed playspeed;
            playspeed = Speed.SPEED_0X;//change play speed from 1x to 0x to fix step play issue
            int result = 0;
            //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);//Set the origin maskvalue to the function
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (result == 0)
                Selected_Speed.Text = Convert.ToString( PAUSE_SPEED );
            else
                Console.WriteLine("SetStreamInfo returns error!");
            forward_speed = 0;
            backward_speed = 0;
        }

        private void step_backward_Click(object sender, EventArgs e)
        {
            ViewInfoType viewtype;
            viewtype = (ViewInfoType.PREVIOUS_FRAME);
            Speed playspeed;
            playspeed = Speed.SPEED_0X;//change play speed from 1x to 0x to fix step play issue
            int result = 0;
            //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);//Set the origin maskvalue to the function
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (result == 0)
                Selected_Speed.Text = Convert.ToString( PAUSE_SPEED);
            else
                Console.WriteLine("SetStreamInfo returns error!");
            forward_speed = 0;
            backward_speed = 0;
        }

        private void Set_Aud_CH_Click(object sender, EventArgs e)
        {
            int_CH_NO_Left = Convert.ToInt32(Select_Left_Aud.SelectedIndex);

            int result;
            int int_volum_Left;
            int int_volum_Right;
            uint mask_CH_NO_Left;
            uint mask_CH_NO_Right;
            uint mask_CH_NO;
            //input ch number is from 0 to 11
            //convert the int value to uint mask

            //from FW version 90.11, new audio inputs has been applyed. SDK do not need to SetStreamInfo when it changes audio input.

            ViewInfoType view_info_type;
            view_info_type = (ViewInfoType.VIEW_INFO);
            Speed playspeed;
            playspeed = Speed.SPEED_1X;

            result = SdkShellSetAudioCH(ptr, int_CH_NO_Left, ptr, int_CH_NO_Left);
            int_volum_Left = Convert.ToInt32(Aud_Left_text.Text);
            int_volum_Right = int_volum_Left;
            //volum's range is from 0 to 100
            if (int_volum_Left < 0 || int_volum_Right < 0)
            {
                int_volum_Left = 0;
                int_volum_Right = 0;
            }
            else if (int_volum_Left > 100 || int_volum_Right > 100)
            {
                int_volum_Left = 100;
                int_volum_Right = 100;
            }

            result=SdkShellSetAudioVolume(int_volum_Left, int_volum_Right);
        }

        private int show_meta_data( )//this function will create a class which deals with Metadata callback
        {

            class_callback.GetMetaptr(ptr);//assign device pointer to this class
            class_callback.metaCallback_assign();
            class_callback.m_cl_InnerMetacallback.UploadMeta += new EventHandler(Writetextbox);//When dll use the callback function, EventHandler will call writetextbox
            return 0;
        }

        /** 
         *********************************************************************
         * @fn<Writetextbox>
         * @brief<This function will work with fired event from SDKcallback>
         * <Because only UI thread can access ui object, this function will call this.BeginInvoke() to ask ui thread handle the rest job>
         * @param[in]
         * <src:>
         * <e: An EventArgs which contain CallbackType in it>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private void Writetextbox(object src, EventArgs e)
        {
            //added by Edward 20121018
            //We detect ConnectionCBEventArgs at first, because ConnectionCBEventArgs is inherit from CallbackEventArgs.
            //If we put ConnectionCBEventArgs after CallbackEventArgs, sample code will always regard e as CallbackEventArgs
            if (e is ConnectionCBEventArgs)//added by Edward in 20121018, we need a new async function to operate device close according the device ptr 
            {
                ConnectionCBEventArgs _CallbackEventArgs = e as ConnectionCBEventArgs;  // Covert object from EventArgs to CallbackEventArgs 

                object[] inputarg = new object[2];
                inputarg[0] = _CallbackEventArgs.pDevicePtr;
                inputarg[1] = _CallbackEventArgs.CallbackEventType;

                //there should be a new Async function to handle this issue
                this.BeginInvoke(new AsyncWriteConnectionCBdata(WriteConnectionCBdata), inputarg);//assigin UI thread to handle connection status
            }
            else if (e is ArchiveCBEventArgs)
            {
                ArchiveCBEventArgs _CallbackEventArgs = e as ArchiveCBEventArgs;  // Covert object from EventArgs to CallbackEventArgs 

                object[] inputarg = new object[6];
                inputarg[0] = _CallbackEventArgs.pDevicePtr;
                inputarg[1] = _CallbackEventArgs.CallbackEventType;
                inputarg[2] = _CallbackEventArgs.m_Archive_message;
                inputarg[3] = _CallbackEventArgs.m_iArvprogress;
                inputarg[4] = _CallbackEventArgs.m_strArvFilePath;
                inputarg[5] = _CallbackEventArgs.m_ArvBlockID;

                // there are a lot of input args in this version. Because we need them to control archiving files from multiple device
                this.BeginInvoke(new AsyncWriteArchiveCBdata(WriteArchiveCBdata), inputarg);//assigin UI thread to insert text into text box
            }
            // if e is not ConnectionCBEventArgs and ArchiveCBEventArgs
            else if (e is CallbackEventArgs)// Decide the type of EventArgs is Callback EventArgs or not 
            {
                CallbackEventArgs _CallbackEventArgs = e as CallbackEventArgs;  // Covert object from EventArgs to CallbackEventArgs 


                object[] inputarg = new object[1];
                inputarg[0] = _CallbackEventArgs.CallbackEventType;


                //Release Shell when it is compeleted
                if (_CallbackEventArgs.CallbackEventType == CallbackType.STATUS_SCANN_HDD)
                {
                    //int result;
                    //result=SdkShellRelease();
                    // class_callback.m_StatusCallback.UploadData -= new EventHandler(Writetextbox);
                }

                //we should implement a new pure callback for writing time
                this.BeginInvoke(new AsyncWriteCallbackdata(WriteCallbackdata), inputarg);//assigin UI thread to insert text into text box
                

            }
            else
            {
                MessageBox.Show("Error EventArgs!");
            }

        }

        /** 
         *********************************************************************
         * @fn<CloseReleaseDeivce>
         * @brief<This function will be close and release selected device.>
         *<This function is modified from stop button >
         * @param[in]
         * <IntPtr: pDevicePtr>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <bool>
         *********************************************************************
         */
        private bool CloseReleaseDeivce(IntPtr pDevicePtr)
        {
            int _iResult = 0;
            for (int i = 0; i < 12; i++)
            {
                //Give the selected picture box's handle to the dll
                if (cb_CamArr[i].Checked)
                {
                    SdkShellRemoveVideoWindow(phRender[i]);
                    pb_CamArr[i].Refresh();
                }
            }

            //Close source and release source
            //Do not release shell when you want close and release source
            //This will cause the rest source have to no shell
            //Please close shell only when you do not need to use SDK anymore.

            //added by Edward in 2011/12/20
            //In this sample, we only release shell when we close the whole sample
            //Release Selected device, Find the device infomation from device list and check this device is in the list

            int _iDeviceIdx = -1;
            for (int i = 0; i < DeviceList.Count; i++)
            {
                if (DeviceList[i].Device_Ptr == pDevicePtr)//we should use the device ptr which is sent from SDK 
                //to exam the this pointer is in the list or not
                {
                    _iDeviceIdx = i;
                    break;
                }
            }
            if (_iDeviceIdx == -1)
            {
                MessageBox.Show("Deive is not in the List");
                return false;
            }
            Debug.WriteLine("Close Source start!!!!!!!!");
            mtSelectedType = DeviceList[_iDeviceIdx].Device_Param.dwModal;
            _iResult = SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_DVR);

            _iResult = SdkShellReleaseSource(DeviceList[_iDeviceIdx].Device_Ptr);
            Debug.WriteLine("Close Source End!!!!!!!!");
            if (_iResult < 0)
                return false;
            //SdkShellRelease();
            DeviceList.Remove(DeviceList[_iDeviceIdx]);

            if (pDevicePtr == ptr)
            {
                ptr = IntPtr.Zero;
                Livebtn.Enabled = true;
                Search_HDD.Enabled = true;
                Get_HDDInfo.Enabled = true;

                Resumebtn.Enabled = false;
                Pausebtn.Enabled = false;
                Stopbtn.Enabled = false;
                CameraBox.Enabled = true;
                fast_forward.Enabled = false;
                backward.Enabled = false;
                fast_backward.Enabled = false;
                step_forward.Enabled = false;
                step_backward.Enabled = false;
                Aud_GB.Enabled = false;
                ChangeCamera.Enabled = false;
                StopDVR.Enabled = false;

                //Set speed to default
                forward_speed = 0;
                backward_speed = 0;
                Selected_Speed.Text = Convert.ToString(PAUSE_SPEED);

            }
            else if (pDevicePtr == SnapShotptr)
            {
                SnapShotptr = IntPtr.Zero;
                bSSTimer = false;
                SnapshotTimer.Stop();
            }
            else
                Debug.WriteLine("(CloseReleaseDevice) There No match ptr for pDevicePtr");

            //Enable and disable buttons
            //Those button enable and disable is only remote video streaming

            return true;
        }

        //added by Edward in 20121018
        /** 
         *********************************************************************
         * @fn<WriteCallbackdata>
         * @brief<This function will be used with AsyncWriteCallbackdata.>
         *<In this function, Messagbox will notified user the connection status>
         *<And we also fixed the behavior of STATUS_DISCONNET,>
         * @param[in]
         * <pDevicePtr: The device pointer which used this callback>
         * <_CallbackType: Input callback type>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private delegate void AsyncWriteConnectionCBdata( IntPtr pDevicePtr, CallbackType _CallbackType);
        private void WriteConnectionCBdata(IntPtr pDevicePtr, CallbackType _CallbackType)
        {

            if (_CallbackType == CallbackType.STATUS_DISCONNECT)
            {
                if (mtSelectedType == ModalType.MV_DVR && (Livebtn.Enabled == false || bSSTimer))
                {

                    //added by Edward in 20121018
                    //we should close and release the device,once we found it has been disconnected or login failed
                    bool _iReleaseResult = false;
                    _iReleaseResult = CloseReleaseDeivce( pDevicePtr );
                    if (_iReleaseResult)
                        MessageBox.Show("Connection disconnect");
                    else
                        MessageBox.Show("Connection disconnect, but Device close failed");
                }
                else
                {
                    MessageBox.Show("Connection failed");
                    if (cl_Archive != null)
                        cl_Archive.EnableReusme();
                }
            }
            else if (_CallbackType == CallbackType.STATUS_LOGINBLOCKED)
            {
                MessageBox.Show("Login Blocked");
            }
            else if (_CallbackType == CallbackType.STATUS_TIMEERROR)
            {
                MessageBox.Show("PlayBack Time Error");
            }
            else
                MessageBox.Show("No Such Callback Type in Connection Callback!");
        }

        /** 
         *********************************************************************
         * @fn<WriteArchiveCBdata>
         * @brief<This function will be used with AsyncWriteArchiveCBdata.>
         *<In this function, input variables will be used during user archiving their data>
         * @param[in]
         * <pDevicePtr: Sepecify this callback is send by which device>
         * <_CallbackType: Input callback type>
         * <ArchiveCBMessage: Detail archive callback type>
         * <ArchiveProgress: Current archive progress>
         * <ArchiveFilePath: Current file path>
         * <ArchiveBlockID: Current Block ID>
         * 
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private delegate void AsyncWriteArchiveCBdata(IntPtr pDevicePtr, CallbackType _CallbackType, int ArchiveCBMessage, int ArchiveProgress, string ArchiveFilePath, string ArchiveBlockID);
        private void WriteArchiveCBdata(IntPtr pDevicePtr, CallbackType _CallbackType, int ArchiveCBMessage, int ArchiveProgress, string ArchiveFilePath, string ArchiveBlockID) 
        {
           
                if (_CallbackType == CallbackType.STATUS_ARCHIVE)
                {
                    if (ArchiveCBMessage == (int)ArchiveCallbackMessage.ARCHIVE_PROGRESS)
                    {
                        cl_Archive.getProgress(ArchiveProgress, false);
                    }
                    else if (ArchiveCBMessage == (int)ArchiveCallbackMessage.ARCHIVE_FILE_PATH)
                    {
                        cl_Archive.setResumeFilePath(ArchiveFilePath);
                    }
                    else if (ArchiveCBMessage == (int)ArchiveCallbackMessage.ARCHIVE_LAST_BLOCK_ID)
                    {
                        cl_Archive.setLastBlockID(ArchiveBlockID);
                    }
                }
                else if (_CallbackType == CallbackType.STATUS_ARCHIVE_END || _CallbackType == CallbackType.STATUS_ARCHIVE_NODATA || _CallbackType == CallbackType.STATUS_ARCHIVE_CANCEL)
                {
                    /*
                    int _iDeviceIdx = -1;
                    for (int i = 0; i < DeviceList.Count; i++)
                    {
                        if (DeviceList[i].Device_Ptr == pDevicePtr)
                        {
                            _iDeviceIdx = i;
                            break;
                        }
                    }
                    if (_iDeviceIdx == -1)
                    {
                        MessageBox.Show("Deive is not in the List");
                        return;
                    }
                   
                    //in single device sample this function will the progress and control button in archive panel
                    //cl_Archive.getProgress(ArchiveProgress, true);
                    //close and release
                    int iResult = 0;


                    mtSelectedType = DeviceList[_iDeviceIdx].Device_Param.dwModal;
                    if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_DVR)
                        iResult = SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_DVR);
                    else if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_HDD)
                        iResult = SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_HDD);
                    else if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_IMAGE)
                        iResult = SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_IMAGE);
                    else
                    {
                        MessageBox.Show("No Such ModalType");
                        return;
                    }

                    iResult = SdkShellReleaseSource(DeviceList[_iDeviceIdx].Device_Ptr);

                    DeviceList.Remove(DeviceList[_iDeviceIdx]);

                    Debug.WriteLine("Source closed is " +iResult+ " pointer is" +pDevicePtr);
                    */


                    if(_CallbackType == CallbackType.STATUS_ARCHIVE_NODATA)
                    {
                        MessageBox.Show("Archive no data");
                    }
                    else if (_CallbackType == CallbackType.STATUS_ARCHIVE_CANCEL)
                    {
                        MessageBox.Show("Archive Canceled");
                    }
                    else if (_CallbackType == CallbackType.STATUS_ARCHIVE_END)
                    {
                        cl_Archive.getProgress(ArchiveProgress, true);
                    }

                }
                else
                    MessageBox.Show("No Such Callback Type!");
            
        }

         /** 
         *********************************************************************
         * @fn<WriteCallbackdata>
         * @brief<This function will be used with AsyncWriteCallbackdata.>
         *<In this function, member variables in the SDKcallback will be assigned to ui object on the form >
         * @param[in]
         * <_CallbackType: Input callback type>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private delegate void AsyncWriteCallbackdata(CallbackType _CallbackType);
        private void WriteCallbackdata(CallbackType _CallbackType)
        {
            if (_CallbackType == CallbackType.IFRAME_META_DATA)
                gpsdata1.Text = class_callback.m_cl_InnerMetacallback.strDatatowrite;
            else if (_CallbackType == CallbackType.STATUS_SCANN_HDD)
                HDDInfo.Text = class_callback.m_StatusCallback.m_strHddStatus;
            else if (_CallbackType == CallbackType.STATUS_VIDEO_TIME)
            {
                DateTime _CurrenttDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970/1/1 0:0:0
                LocalTime_Picker.Value = _CurrenttDateTime.AddSeconds(class_callback.m_StatusCallback.m_uiVideoLocalTime);
                CurrentTime_Picker.Value = _CurrenttDateTime.AddSeconds(class_callback.m_StatusCallback.m_uiVideoUTCTime);
                //Console.WriteLine("MiniSec: " + class_callback.m_StatusCallback.m_uiVideoUTCTimeMiniSec);
            }
            else
                MessageBox.Show("No Such Callback Type!");
        }
        
        
        /** 
         *********************************************************************
         * @fn<Search_HDD_Click>
         * @brief<Start to scan HDD and post their info on textbox>
         * <Use asynchronous invoke to prevent ui thread getting stuck by HDD scan>
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private void Search_HDD_Click(object sender, EventArgs e)
        {
            HDDInfo.Text = "";
            AsyncFindHDD _asyncFindHDD = new AsyncFindHDD(FindHDD);//HDD scan must be assigned to another thread.
            _asyncFindHDD.BeginInvoke(null, null );
        }

        private void HDDControl_Click(object sender, EventArgs e)
        {

        }

        /** 
         *********************************************************************
         * @fn<FindHDD>
         * @brief<Use BeginIvoke to assign this function to other thread, This function always work with AsyncFindHDD >
         * <SdkShellScanHDD will be use in this function, And SdkShellScanHDD will raise the callback function which is assigned by SdkShellSetStatusCallback>
         * <The SdkShell will release in Writetextbox>
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private delegate void AsyncFindHDD( );
        private void FindHDD( )
        {
            //int result;
            //result = SdkShellInitial(32);
            CallbackType _SeleCallbackType = CallbackType.STATUS_SCANN_HDD;
            //class_callback.m_StatusCallback.UploadData += new EventHandler(Writetextbox);//When dll use the callback function, EventHandler will call writetextbox
            class_callback.ClearHDDList( );
            ModalType _mtHddtype = ModalType.MV_HDD;
            SdkShellScanHDD(_mtHddtype);
        }

        /** 
         *********************************************************************
         * @fn<GetHDDInfo_Click>
         * @brief<This part will be used after FindHDD, In this function you can retrieve the HDD information from selected HDD >
         * <The retrieved information can be referred in class HDD_INFO>
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private void GetHDDInfo_Click(object sender, EventArgs e)
        {
            int result = 0;
            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                //Initial shell and Source
                //result = SdkShellInitial(32);
                OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(ModalType.MV_HDD);
                result = SdkShellInitialSource(ref ptr, DeviceType.DEVICE_HDD, stOpenParam.dwModal, 0);
                //set playback time
                stOpenParam.dwDiskID = class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number;
                result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.SEARCH, 0);

                IntPtr iResultType = IntPtr.Zero;
                IntPtr iResult = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(HDD_INFO)));
                //Get device infomation
                result = SdkShellGetDeviceInfo(ptr, ref iResultType, iResult);

                HDD_INFO hdd_Info = new HDD_INFO();
                hdd_Info = (HDD_INFO)Marshal.PtrToStructure(iResult, typeof(HDD_INFO));

                //Deal with Hdd serial number
                string TestingString = "";
                char[] TestingArray;
                TestingArray = System.Text.Encoding.Default.GetChars(hdd_Info.hdd_serial);
                TestingString = new string(TestingArray);
                string[] TestingStrArray = TestingString.Split(new Char[] { '\0' });
                HDD_serial.Text = TestingStrArray[0];

                DateTime _StartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(hdd_Info.start_time);
                tb_StartTime.Text = _StartTime.ToString("yyyy/M/d HH:mm:ss tt");
                DateTime _EndTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(hdd_Info.end_time);
                tb_EndTime.Text = _EndTime.ToString("yyyy/M/d HH:mm:ss tt");
                Total_Ch.Text = Convert.ToString(hdd_Info.local_channels);

                int uiLocalST = Convert.ToInt32(hdd_Info.start_offset)*15*60 + Convert.ToInt32(hdd_Info.start_ds)*60;
                _StartTime = _StartTime.AddSeconds(uiLocalST);
                LocalStartTime.Text = _StartTime.ToString("yyyy/M/d HH:mm:ss tt");
                
                int uiLocalET = Convert.ToInt32(hdd_Info.end_offset)*15*60 + Convert.ToInt32(hdd_Info.end_ds)*60;
                _EndTime = _EndTime.AddSeconds(uiLocalET);
                LocalEndTime.Text = _EndTime.ToString("yyyy/M/d HH:mm:ss tt");
                
                Total_Ch.Text = Convert.ToString(hdd_Info.local_channels);

                SdkShellCloseSource(ptr, ModalType.MV_HDD);
                SdkShellReleaseSource(ptr);
            }
            else
                return;
            //SdkShellRelease();
        }

        private void Select_Modaltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(Select_Modaltype.SelectedIndex)
            {
                case 0:
                    Livebtn.Text = "Live";
                    Resumebtn.Text = "Resume";
                    break;
                case 1:
                    Livebtn.Text = "PlayBack";
                    Resumebtn.Text = "Forward";
                    break;
                case 2:
                    Livebtn.Text = "HDD";
                    Resumebtn.Text = "Forward";
                    break;
                case 3:
                    Livebtn.Text = "File";
                    Resumebtn.Text = "Forward";
                    break;
            }

        }

        private void DVR_Event_Search_Click(object sender, EventArgs e)
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }
            
            Search_Form cl_searchform = new Search_Form();
            cl_searchform.Text = "EventSearch_DVR";
            cl_searchform.Show();
            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            cl_searchform.GetFormValue(str_IP, int_port, str_username, str_password);
        }

        private void DVR_Gsensor_Search_Click(object sender, EventArgs e)
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }
            Gsensor_Form cl_Gsensor_Form = new Gsensor_Form();
            cl_Gsensor_Form.Text = "G-sensor_DVR";
            cl_Gsensor_Form.Show();
            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            cl_Gsensor_Form.GetFormValue(str_IP, int_port, str_username, str_password);
        }

        private void DVR_GPS_Search_Click(object sender, EventArgs e)
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }
            GPSSearch_Form cl_GPS_Form = new GPSSearch_Form();
            cl_GPS_Form.Text = "GPSSearch_DVR";
            cl_GPS_Form.Show();
            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            cl_GPS_Form.GetFormValue(str_IP, int_port, str_username, str_password);
        }

        /** 
         *********************************************************************
         * @fn<ChangeCam_Click>
         * @brief<This part will be used to change camera mask. >
         * <User can add new camera to current connection or remove camera from current connection>
         * <SdkShellSetStreamInfo, SdkShellRemoveVideoWindow, SdkShellCreateVideoWindow will be used in this part>
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         *********************************************************************
         */
        private void ChangeCam_Click(object sender, EventArgs e)
        {

            //In this version, the behavior of ChangeCam_Click will be divided into two parts
            //One is for DVR and the other is for HDD and File

            ViewInfoType view_info_type;
            //DVR will have different behavior than HDD and File
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
                view_info_type = (ViewInfoType.VIEW_INFO);
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
                view_info_type = (ViewInfoType.VIEW_INFO | ViewInfoType.FORWARD_PLAY);
            else
                view_info_type = (ViewInfoType.VIEW_INFO | ViewInfoType.FORWARD_PLAY);

            int_CH_NO_Left = Convert.ToInt32(Select_Left_Aud.SelectedIndex);
            int_CH_NO_Right = Convert.ToInt32(Select_Left_Aud.SelectedIndex);
            uint mask_CH_NO;
            uint mask_CH_NO_Left;
            uint mask_CH_NO_Right;
 
            mask_CH_NO_Left = (uint)1 << int_CH_NO_Left;
            mask_CH_NO_Right = (uint)1 << int_CH_NO_Right;
            mask_CH_NO = mask_CH_NO_Left | mask_CH_NO_Right;
            //audiomask = mask_CH_NO;
            CurrentChannel = 0;
            int _Changedmaskvalue = 0;
            byte CurrentChannel_byte = 0;

            for (int i = 0; i < 12; i++)
            {
                _Changedmaskvalue += (cb_CamArr[i].Checked ? 1 : 0) << i;
            }

            Speed playspeed;
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1) )
            {
                int _iTempSpeed = 0;
                if (forward_speed == 0 && backward_speed == 0)
                {
                    _iTempSpeed = forward_speed;
                }
                else if (forward_speed != 0 && backward_speed == 0)
                {
                    _iTempSpeed = forward_speed;
                }
                else if (forward_speed == 0 && backward_speed != 0)
                {
                    _iTempSpeed = backward_speed;
                }
                playspeed = (Speed)_iTempSpeed;
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                playspeed = Speed.SPEED_1X;
            }
            else
            {
                playspeed = Speed.SPEED_1X;
            }
            
            int result = -1;
            audiomask = (uint)_Changedmaskvalue;
            //result = SdkShellSetStreamInfo(ptr, (uint)_Changedmaskvalue, mask_CH_NO, 1, 0, (uint)view_info_type, playspeed);
            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)_Changedmaskvalue, audiomask, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)_Changedmaskvalue, (uint)audiomask, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)_Changedmaskvalue, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            //modified by Edward in 20121114
            {
                // result = SdkShellSetStreamInfo(ptr, (uint)_Changedmaskvalue, audiomask, 1, 0, (uint)view_info_type, playspeed);
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)_Changedmaskvalue, audiomask, 1, 0, (uint)view_info_type, playspeed);
                else if (SubStream.Checked) //^^
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)_Changedmaskvalue, (uint)view_info_type, playspeed);
                else
                    MessageBox.Show("Select any stream type.");



                if (result == 0)
                    Selected_Speed.Text = Convert.ToString(NORMAL_SPEED);
                else
                    Console.WriteLine("SetStreamInfo returns error!");
                forward_speed = 1;
                backward_speed = 0;
            }
        
            int _Overlapmask = _Changedmaskvalue & maskvalue;
            //SdkShell.dll will help uers to remove or add new camera window to Render.dll
            //We will use operator "AND" to find out Remained, Added, Removed camera from cameramask
            for (int i = 0; i < 12; i++)
            {
                int _CounterMask = 1;
                _CounterMask = _CounterMask << i;

                if (((_Changedmaskvalue & _CounterMask) == 0) && ((maskvalue & _CounterMask) != 0))
                {
                    SdkShellRemoveVideoWindow(phRender[i]);
                    pb_CamArr[i].Refresh();
                }
                if (((_Changedmaskvalue & _CounterMask) != 0) && ((maskvalue & _CounterMask) == 0))
                {
                    CurrentChannel_byte = Convert.ToByte(CurrentChannel);
                    result = SdkShellCreateVideoWindow(ref phRender[i], ptr, CurrentChannel_byte, pb_CamArr[i].Handle);
                    pb_CamArr[i].Refresh();
                }

                CurrentChannel++;
            }

            maskvalue = _Changedmaskvalue;

            //Only File and HDD needs reset play time when change camera mask
            if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                int iPlayTime = Convert.ToInt32(class_callback.m_StatusCallback.m_uiVideoUTCTime);
                result = SdkShellSetPlayTime(ptr, (uint)PlayTimeMode.SEEK_AND_PLAY, iPlayTime, 10);
                if (result != 0)
                    Console.WriteLine("SetPlayTime returns error!");
            }
            //Set the origin maskvalue and channel number to the function

        }

        private void Archive_btn_Click(object sender, EventArgs e)
        {
            //if (IP_tb.Text.Length == 0)
            //{
            //    MessageBox.Show("IP string is Empty");
            //    return;
            //}
            
            cl_Archive = new Archive();
            cl_Archive.Text = "Archive_DVR";
            cl_Archive.Show();

            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;

            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam( ModalType.MV_DVR);

            cl_Archive.GetFormValue(stOpenParam);
            //class_callback.m_StatusCallback.UploadData += new EventHandler(Writetextbox);//When dll use the callback function, EventHandler will call writetextbox

        }

        private void HDD_Archive_btn_Click(object sender, EventArgs e)
        {
            cl_Archive = new Archive();

            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;

            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(ModalType.MV_HDD);

            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                stOpenParam.dwDiskID = class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number;
                cl_Archive.Text = "Archive_HDD";
                cl_Archive.Show();
                cl_Archive.GetFormValue(stOpenParam);
            }
            else
                return;


            //class_callback.m_StatusCallback.UploadData += new EventHandler(Writetextbox);//When dll use the callback function, EventHandler will call writetextbox
        }

        /** 
        *********************************************************************
        * @fn<CheckHDDList>
        * @brief<This part will check the selected HDDs number is valid or not. >
        * @param[in]
        * <_iSelectedHDD: Selected HDDs NO.>
        * @param[out]
        *    none
        * @retval
        *    none
        * @return <bool>
        *********************************************************************
        */
        private bool CheckHDDList(int _iSelectedHDD)
        {

            if (class_callback.m_StatusCallback != null)
            {
                if (class_callback.m_StatusCallback.HDDList.Count >= 1)
                {
                    if (_iSelectedHDD < 0)
                    {
                        MessageBox.Show("Selected number is not correct");
                        return false;
                    }
                    else
                    {
                        if (_iSelectedHDD >= class_callback.m_StatusCallback.HDDList.Count)
                        {
                            MessageBox.Show("Selected number is out of range");
                            return false;
                        }
                        else
                            return true;
                    }
                }
                else
                {
                    MessageBox.Show("No HDD device in the HDDlist");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please Scan HDD");
                return false;
            }

        }

        private void HDD_Event_Search_Click(object sender, EventArgs e)
        {
            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                Search_Form cl_searchform = new Search_Form();
                cl_searchform.Text = "EventSearch_HDD";
                cl_searchform.Show();
                cl_searchform.GetHDDValue(class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number);
            }
            else
                return;
        }

        private void HDD_G_Sensor_Click(object sender, EventArgs e)
        {
            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                Gsensor_Form cl_GSensorform = new Gsensor_Form();
                cl_GSensorform.Text = "G-sensor_HDD";
                cl_GSensorform.Show();
                cl_GSensorform.GetHDDValue(class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number);
            }
            else
                return;
        }

        private void HDD_GPS_Search_Click(object sender, EventArgs e)
        {
            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                GPSSearch_Form cl_GPSSearchform = new GPSSearch_Form();
                cl_GPSSearchform.Text = "GPSSearch_HDD";
                cl_GPSSearchform.Show();
                cl_GPSSearchform.GetHDDValue(class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number);
            }
            else
                return;
        }

        private void SnapShotbtn_Click(object sender, EventArgs e)
        {
            SnapShotbtn.Enabled = false;

            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }

            String filename = "";
            SaveFileDialog path = new SaveFileDialog();
            path.Filter = "JPEG files(*.jpg)|*.jpg|All files (*.*)|*.*";//Filename Extension
            if (path.ShowDialog() == DialogResult.OK)
            {
                filename = path.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Please enter a file name");
                SnapShotbtn.Enabled = true;
                return;
            }

            int result = 0;
            int nSnapshotch = Convert.ToInt32(Snapshotch.Text);
            if (nSnapshotch <= 0 || nSnapshotch > 12)
            {
                MessageBox.Show("Please Select ch1~ch12");
                SnapShotbtn.Enabled = true;
                return;
            }

            nSnapshotch = nSnapshotch - 1;

            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                str_IP = IP_tb.Text;
                int_port = Convert.ToInt32(port_tb.Text);
                str_username = account_tb.Text;
                str_password = password_tb.Text;
                DeviceType _dtDeviceType;

                mtSelectedType = ModalType.MV_DVR;
                _dtDeviceType = DeviceType.DEVICE_DVR;
                IntPtr SnapShotptr = IntPtr.Zero;

                Debug.WriteLine("Snapshot!!! Start to open source");
                OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(mtSelectedType);
                result = SdkShellInitialSource(ref SnapShotptr, _dtDeviceType, stOpenParam.dwModal, 0);

                DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local); // 1970/1/1 0:0:0
                uint playTime = (uint)((Playbacktime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time 
                result = SdkShellOpenSource(SnapShotptr, ref stOpenParam, ViewType.DVR_SNAPSHOT, (int)playTime);

                //Added by Edward in 2011/12/20 for adding opend device to device list
                //Because those device is used to play video and audio.
                Debug.WriteLine("Snapshot!!! Try to remote snapshot");
                Device_List_Entry_T OpenedDevice = new Device_List_Entry_T();
                OpenedDevice.Device_Ptr = SnapShotptr;
                OpenedDevice.Device_Param = stOpenParam;
                DeviceList.Add(OpenedDevice);

                CurrentChannel = 0;
                maskvalue = 0;

                byte[] jpg = new byte[1024 * 1024];
                int iJpgLength = 0;
                uint uPicTime = 0;

                if (Select_Modaltype.SelectedIndex == 0)
                    result = SdkShellRemoSnapShot_Start(SnapShotptr, (uint)nSnapshotch, 0, (uint)ViewInfoType.REMOTE_SNAPSHOT); //Edward add 20130906
                else if (Select_Modaltype.SelectedIndex == 1)
                    result = SdkShellRemoSnapShot_Start(SnapShotptr, (uint)nSnapshotch, playTime, (uint)ViewInfoType.REMOTE_SNAPSHOT); //Edward add 20130906
                if (result < 0)
                {
                    MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                    //return;
                }

                Thread.Sleep(500);
                result = SdkShellRemoteSnapShot(SnapShotptr, (uint)nSnapshotch, (uint)ViewInfoType.REMOTE_SNAPSHOT, jpg, out iJpgLength, out uPicTime);
                if (result < 0)
                {
                    MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                    //return;
                }


                if (iJpgLength > 0 && uPicTime >0)
                {
                    FileStream fs = new FileStream(filename, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(jpg, 0, iJpgLength);
                    bw.Close();
                    fs.Close();
                }
                else
                    MessageBox.Show("iJpgLength or PicTime is not correct");



                Debug.WriteLine("Close Start");

                //Close source and release source
                //Do not release shell when you want close and release source
                //This will cause the rest source have to no shell
                //Please close shell only when you do not need to use SDK anymore.

                //added by Edward in 2011/12/20
                //In this sample, we only release shell when we close the whole sample
                //Release Selected device, Find the device infomation from device list and check this device is in the list

                int _iDeviceIdx = -1;
                for (int i = 0; i < DeviceList.Count; i++)
                {
                    if (DeviceList[i].Device_Ptr == SnapShotptr)
                    {
                        _iDeviceIdx = i;
                        break;
                    }
                }
                if (_iDeviceIdx == -1)
                {
                    MessageBox.Show("Deive is not in the List");
                    return;
                }

                mtSelectedType = DeviceList[_iDeviceIdx].Device_Param.dwModal;
                if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_DVR)
                    SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_DVR);
                else
                {
                    MessageBox.Show("No Such ModalType");
                    return;
                }

                SdkShellReleaseSource(DeviceList[_iDeviceIdx].Device_Ptr);
                Debug.WriteLine("Close End");
                //SdkShellRelease();
                SnapShotptr = IntPtr.Zero;

                DeviceList.Remove(DeviceList[_iDeviceIdx]);
                //Enable and disable buttons

            }
            else
            {

                //this method is for saving current picture box's image only
                if (phRender[nSnapshotch] == IntPtr.Zero)
                {
                    return;
                }

                Debug.WriteLine("Snapshot Start");
                result = SdkShellSnapshot(phRender[nSnapshotch], filename);

            }

            SnapShotbtn.Enabled = true;
            return;  
        }

        /** 
         *********************************************************************
         * @fn<StopDVR_Click>
         * @brief<This part will use the function stop "SdkShellStopAllSource">
         * 
         * @param[in]
         *    none
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <void>
         * 
         * 
         *********************************************************************
         */
        private void StopDVR_Click(object sender, EventArgs e)
        {
            if (mtSelectedType == ModalType.MV_DVR)
            {
                for (int i = 0; i < 12; i++)
                {
                    //Give the selected picture box's handle to the dll
                    if (cb_CamArr[i].Checked)
                    {
                        SdkShellRemoveVideoWindow(phRender[i]);
                        pb_CamArr[i].Refresh();
                    }
                }

                //Stop All Source
                //This function will stop all source connect to certain kind device
                //If user give this function MV_DVR, it will stop all source connect to every DVR 
                //Please use it carefully

                SdkShellStopAllSource( ModalType.MV_DVR);

                ptr = IntPtr.Zero;

                //Enable and disable buttons
                Livebtn.Enabled = true;
                Search_HDD.Enabled = true;
                Get_HDDInfo.Enabled = true;

                Resumebtn.Enabled = false;
                Pausebtn.Enabled = false;
                Stopbtn.Enabled = false;
                CameraBox.Enabled = true;
                fast_forward.Enabled = false;
                backward.Enabled = false;
                fast_backward.Enabled = false;
                step_forward.Enabled = false;
                step_backward.Enabled = false;
                Aud_GB.Enabled = false;
                ChangeCamera.Enabled = false;
                StopDVR.Enabled = false;

                //Set speed to default
                forward_speed = 0;
                backward_speed = 0;
                Selected_Speed.Text = Convert.ToString(PAUSE_SPEED);
            }
            else
                MessageBox.Show("Please Select DVR, and this button will close all source connect to DVR");
        }

        private void IMGLOG_Click(object sender, EventArgs e)
        {

            cl_ImgLog = new ImgLog();
            cl_ImgLog.Show();

        }


        /** 
        *********************************************************************
        * @fn<SystemLogbtn_Click>
        * @brief<This part will get ip, port, username, password and file path, >
        * <before download system log file. >
         * @param[in]
         *    none
         * @param[out]
         *    none
        * @retval
        *    none
        * @return <bool>
        *********************************************************************
        */
        private void SystemLogbtn_Click(object sender, EventArgs e)//neil add 0711
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }

            IntPtr Logptr = IntPtr.Zero;
            int result = 0;

            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            DeviceType _dtDeviceType;

            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(ModalType.MV_DVR);

            //Initial shell and Source
            _dtDeviceType = DeviceType.DEVICE_DVR;

            SaveFileDialog path = new SaveFileDialog();
            path.Filter = "RTF files(*.rtf)|*.rtf|All files (*.*)|*.*";//Filename Extension

            if (path.ShowDialog() == DialogResult.OK)
            {
                SystemLogbtn.Enabled = false;
                String txtPath;
                txtPath = path.FileName.ToString();

                result = SdkShellInitialSource(ref Logptr, _dtDeviceType, stOpenParam.dwModal, 0);
                result = SdkShellOpenSource(Logptr, ref stOpenParam, ViewType.NONE, 0);

                GetSystemLog GetSystemLogfile;
                GetSystemLogfile = new GetSystemLog(Logptr, txtPath);
                GetSystemLogfile.StartLogenable += new EventHandler(StartSelectedBtn);
                Thread GetLogthread = new Thread(GetSystemLogfile.getSystemLogData);
                GetLogthread.Start();
            }
            else
                return;
        }
        /** 
         *********************************************************************
         * @fn<StartLogbtn>
         * @brief<This function will call ui thread to enable selected button >
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
        //This function will control buttons enable
        public void StartSelectedBtn(object src, EventArgs e)//neil add 0711,modify by Edward in 20120815.
        {
            if (e is EnableBtnSelection)
            {
                EnableBtnSelection _EnableBtnSelected = e as EnableBtnSelection;
                
                object[] inputarg = new object[1];
                inputarg[0] = _EnableBtnSelected.BtnSelected;

                this.BeginInvoke(new AsyncBtnEnable(ChangeSeletedbtn), inputarg);
            }

        }
        private delegate void AsyncBtnEnable(enumBtnSelected enumSelectedBtn);
        private void ChangeSeletedbtn(enumBtnSelected enumSelectedBtn)
        {
            switch(enumSelectedBtn)
            {
                case enumBtnSelected.SysLogButton:
                    SystemLogbtn.Enabled = true;
                    break;

                case enumBtnSelected.DVRLogButton:
                    DVRLogbtn.Enabled = true;
                    break;
            }
        }


        private void Get_FileInfo_Click(object sender, EventArgs e)
        {
            int result = 0;
            IntPtr tempptr=IntPtr.Zero;
                //Initial shell and Source
                //result = SdkShellInitial(32);
            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(ModalType.MV_IMAGE);
            string strFile_Info;
            if(stOpenParam.szFileName!=null)
            {
                result = SdkShellInitialSource(ref tempptr, DeviceType.DEVICE_FILE, stOpenParam.dwModal, 0);
                //set playback time
                result = SdkShellOpenSource(tempptr, ref stOpenParam, ViewType.SEARCH, 0);
                Console.WriteLine("the result of open is " +result);
                IntPtr iResultType = IntPtr.Zero;
                IntPtr iResult = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(HDD_INFO)));
                //Get device infomation
                result = SdkShellGetDeviceInfo(tempptr, ref iResultType, iResult);

                HDD_INFO File_Info = new HDD_INFO();
                File_Info = (HDD_INFO)Marshal.PtrToStructure(iResult, typeof(HDD_INFO));

                //pasing FWversion to string format EX:123456 to 12.34.56
                uint tempFWmask = 255;
                uint FWversion = File_Info.fw_version;
                byte[] byFWversion = new byte[4];

                strFile_Info = "Product: " + File_Info.product.ToString()+"\r\n";
                strFile_Info += "Mode: " + File_Info.model.ToString() + "\r\n";
                strFile_Info += "Local Channels: "+File_Info.local_channels.ToString() + "\r\n";
                strFile_Info += "FW version: ";
               
                //changed by Edward in 2013/08/30 for new fw version format
                string strFWversion;
                strFWversion = String.Format("{0:G}.{1:G}.{2:X}", (FWversion) & 0xff, (FWversion >> 8) & 0xff, (FWversion >> 24) & 0xffff);
                strFile_Info += strFWversion+ "\r\n";

                strFile_Info += "AV format: " + File_Info.av_format.ToString() + "\r\n";
                DateTime _StartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(File_Info.start_time);
                strFile_Info += "Start Time: "+_StartTime.ToString("yyyy/M/d HH:mm:ss tt")+"\r\n";
                DateTime _EndTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(File_Info.end_time);
                strFile_Info +="End Time: "+ _EndTime.ToString("yyyy/M/d HH:mm:ss tt")+"\r\n";
                strFile_Info += "Video map: " + File_Info.video_map.ToString() + "\r\n";
                strFile_Info += "Audio map: " + File_Info.audio_map.ToString() + "\r\n";
                //strFile_Info += "Vehicle ID: " + File_Info.vehicle_id + "\r\n";//removed the vehicle ID is not used currently
                //strFile_Info += "Company Name: " + File_Info.company_name + "\r\n";
                strFile_Info += "STTimeZone: " + File_Info.start_offset.ToString() + " DST: "+ File_Info.start_ds.ToString() +"\r\n";
                strFile_Info += "EDTimeZone: " + File_Info.end_offset.ToString() + " DST: " + File_Info.end_ds.ToString() + "\r\n";
                File_Info_Box.Text = strFile_Info;
                SdkShellCloseSource(tempptr, ModalType.MV_IMAGE);
                SdkShellReleaseSource(tempptr);
            }

        }

        private void File_Event_Search_Click(object sender, EventArgs e)
        {

                Search_Form cl_searchform = new Search_Form();
                cl_searchform.Text = "EventSearch_File";
                cl_searchform.Show();
                cl_searchform.GetFileValue( );

        }

        private void File_G_Sensor_Click(object sender, EventArgs e)
        {

                Gsensor_Form cl_GSensorform = new Gsensor_Form();
                cl_GSensorform.Text = "G-sensor_File";
                cl_GSensorform.Show();
                cl_GSensorform.GetFileValue( );

        }

        private void File_GPS_Search_Click(object sender, EventArgs e)
        {

                GPSSearch_Form cl_GPSSearchform = new GPSSearch_Form();
                cl_GPSSearchform.Text = "GPSSearch_File";
                cl_GPSSearchform.Show();
                cl_GPSSearchform.GetFileValue( );

        }

        private void DiskMap_btn_Click(object sender, EventArgs e)
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }

            DiskMap cl_DiskMap = new DiskMap();
            cl_DiskMap.Text = "DiskMap_DVR";
            cl_DiskMap.Show();
            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            cl_DiskMap.GetFormValue(str_IP, int_port, str_username, str_password);

        //SdkShellSearchDiskmap(hDevice, startTime, endTime, dwScaleType);

        ////HRESULT DLLAPI SdkShellGetDiskmapItem( HDevice hDevice, long lItem, long *lResultType, void *pResult );
        //SdkShellGetDiskmapItem(ptr ,nIndex,  lResultType,pResult);

        ////HRESULT DLLAPI SdkShellStopSearchDiskmap( HDevice hDevice );
        //SdkShellStopSearchDiskmap(ptr);

        ////long DLLAPI SdkShellGetDiskmapCount( HDevice hDevice );
        //SdkShellGetDiskmapCount(ptr);
        }

        private void HDD_DiskMap_Click(object sender, EventArgs e)
        {
            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                DiskMap cl_DiskMap = new DiskMap();
                cl_DiskMap.Text = "DiskMap_HDD";
                cl_DiskMap.Show();
                cl_DiskMap.GetHDDValue(class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number);
            }
            else
                return;

        }

        private void File_DiskMap_Click(object sender, EventArgs e)
        {
            DiskMap cl_DiskMap = new DiskMap();
            cl_DiskMap.Text = "DiskMap_File";
            cl_DiskMap.Show();
            cl_DiskMap.GetFileValue();
        }

        private void Rebootbtn_Click(object sender, EventArgs e)
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }
            
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("Do you want to remote reboot ?",
            "",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.None,
            MessageBoxDefaultButton.Button1);

            if (MsgBoxResult == DialogResult.Yes)
            {
                ptr = IntPtr.Zero;
                int result = 0;
                //char[] ch_cpXml = new char[1024];
                IntPtr ch_cpXml;
                byte[] _bTemp = new byte[1024];
                Array.Clear(_bTemp, 0, 1024);
                ch_cpXml = Marshal.AllocHGlobal(1024);
                Marshal.Copy(_bTemp, 0, ch_cpXml, 1024);

                string str_cpMethod = "GET";
                string str_cpRequestCGI = "/reboot.cgi";
                string str_getXml;

                str_IP = IP_tb.Text;
                int_port = Convert.ToInt32(port_tb.Text);
                str_username = account_tb.Text;
                str_password = password_tb.Text;
                DeviceType _dtDeviceType;
                OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(ModalType.MV_DVR);

                //Initial shell and Source
                _dtDeviceType = DeviceType.DEVICE_DVR;

                Rebootbtn.Enabled = false;

                result = SdkShellInitialSource(ref ptr, _dtDeviceType, stOpenParam.dwModal, 0);
                result = SdkShellOpenSource(ptr, ref stOpenParam, ViewType.NONE, 0);
                result = SdkShellGetHttpRequestXML(ptr, str_cpMethod, str_cpRequestCGI, ch_cpXml);
                if (result < 0)
                {
                    MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                    Rebootbtn.Enabled = true;
                    Marshal.FreeHGlobal(ch_cpXml);
                    _bTemp = null;
                    return;
                }
                Marshal.Copy(ch_cpXml, _bTemp, 0, 1024);
                str_getXml = System.Text.Encoding.Default.GetString(_bTemp);

                if (Regex.IsMatch(str_getXml, @"<result>1</result>") == true)
                {
                    MessageBox.Show("Reboot success.");
                }
                else
                {
                    MessageBox.Show("Reboot fail, please check DVR setting.");
                }
                Rebootbtn.Enabled = true;
                Marshal.FreeHGlobal(ch_cpXml);
                _bTemp = null;
            }
            else
                return;
        }

        private void XmlConfigbtn_Click(object sender, EventArgs e)
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }
            XmlConfig cl_XmlConfigform = new XmlConfig();
            cl_XmlConfigform.Show();
            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            cl_XmlConfigform.GetFormValue(str_IP, int_port, str_username, str_password);
        }

        private void btnFwUpgrade_Click(object sender, EventArgs e)//20110809 Ruby add FwUpgrade button
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }
            
            SystemForm FwUpgradeDlg = new SystemForm();
            FwUpgradeDlg.Show();
            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            FwUpgradeDlg.GetFormValue(str_IP, int_port, str_username, str_password);
        }

        private void btn_RecVideo_Click(object sender, EventArgs e)
        {
            if (bRecVideo == false)
            {
                int iResult = 0;

                string localfpath;

                Debug.WriteLine("Open File Dialog");
                SaveVideoFile.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.*";
                if (SaveVideoFile.ShowDialog() == DialogResult.OK)
                    localfpath = SaveVideoFile.FileName;
                //global_filepath = SaveVideoFile.FileName;
                else
                {
                    MessageBox.Show("Please enter any file name");
                    return;
                }
                Debug.WriteLine("Before SDKstartLiveRec");
                iResult = SdkShellStartLiveRec(ptr, (int)maskvalue, localfpath);
                Debug.WriteLine("Finish SDKstartLiveRec ");
                if (iResult >= 0)
                {
                    btn_RecVideo.BackColor = System.Drawing.Color.Gold;
                    bRecVideo = true;
                }

            }
            else
            {
                int iResult = 0;
                iResult = SdkShellStopLiveRec(ptr);
                if (iResult >= 0)
                {
                    btn_RecVideo.BackColor = System.Drawing.SystemColors.Control;
                    bRecVideo = false;
                }
            }
        }

        private void SelStream_Click(object sender, EventArgs e)
        {

                ViewInfoType view_info_type;
                view_info_type = ViewInfoType.SWITCH_STREAM;
                Speed playspeed;
                playspeed = Speed.SPEED_1X;
                forward_speed = 0;
                backward_speed = 0;
                int result = 0;
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);
                if ( (Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
                {
                    if (MainStream.Checked)
                        result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else if (SubStream.Checked)
                        //modified by Edward in 20120425
                        result = SdkShellSetStreamInfo(ptr, 0, (uint)maskvalue, 0, (uint)maskvalue, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else
                        MessageBox.Show("Select any stream type.");
                }
                else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
                {
                    //MessageBox.Show("HDD and File do not support Dual Stream."); //^^
                    if (MainStream.Checked)
                        result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else if (SubStream.Checked)
                        result = SdkShellSetStreamInfo(ptr, 0, (uint)maskvalue, 0, (uint)maskvalue, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else
                        MessageBox.Show("Select any stream type.");
                }

            /*
                view_info_type = (ViewInfoType.VIEW_INFO | ViewInfoType.FORWARD_PLAY);
                if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
                {
                    if (MainStream.Checked)
                        result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else if (SubStream.Checked)
                        //modified by Edward in 20120425
                        result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else
                        MessageBox.Show("Select any stream type.");
                }
                else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
                {
                    //MessageBox.Show("HDD and File do not support Dual Stream."); //^^
                    if (MainStream.Checked)
                        result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)maskvalue, 1, 0, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else if (SubStream.Checked)
                        result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)view_info_type, playspeed);// give shell the bitmask value. This function can control the data stream
                    else
                        MessageBox.Show("Select any stream type.");
                }

                //DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local); // 1970/1/1 0:0:0
                //int playTime = (int)((CurrentTime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time 

            */
            
                int iPlayTime = Convert.ToInt32(class_callback.m_StatusCallback.m_uiVideoUTCTime);
                result = SdkShellSetPlayTime(ptr, (uint)PlayTimeMode.SEEK_AND_PLAY, iPlayTime, 10);
                if (result != 0)
                    Console.WriteLine("SetPlayTime returns error!");
                    //Set the origin maskvalue and channel number to the function
                forward_speed = 1;
                backward_speed = 0;
             
        }

        private void get_alarm_vehicleID_Click(object sender, EventArgs e)
        {
            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                Alarm_Vehicle cl_Alarm_Vehicle = new Alarm_Vehicle();
                cl_Alarm_Vehicle.Show();
                cl_Alarm_Vehicle.GetHDDValue(class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number);
            }
            else
                return;
        }

        private void SetPbTime_Click(object sender, EventArgs e)
        {

            //This function is use to controll playback time, user can select the time they are interested
            //Before user use the SdkShellSetPlayTime, user needs to use SdkShellSetStreamInfo to make the video played under 1xspeed forward
            //The following codes is the demonstration
            ViewInfoType viewtype;
            viewtype = (ViewInfoType.VIEW_INFO | ViewInfoType.FORWARD_PLAY);
            Speed playspeed;
            playspeed = Speed.SPEED_1X;
            int result = 0;
            uint mask_CH_NO;
            mask_CH_NO = audiomask;

            if ((Select_Modaltype.SelectedIndex == 0) || (Select_Modaltype.SelectedIndex == 1))
            {
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else
                    MessageBox.Show("Select any stream type.");
            }
            else if ((Select_Modaltype.SelectedIndex == 2) || (Select_Modaltype.SelectedIndex == 3))
            {
                //modified by Edward in 20120425
                //result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream 
                if (MainStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, (uint)maskvalue, (uint)mask_CH_NO, 1, 0, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else if (SubStream.Checked)
                    result = SdkShellSetStreamInfo(ptr, 0, 0, 0, (uint)maskvalue, (uint)viewtype, playspeed);// give shell the bitmask value. This function can control the data stream
                else
                    MessageBox.Show("Select any stream type.");
            }

            if (result == 0)
                Selected_Speed.Text = Convert.ToString(NORMAL_SPEED);
            else
                Console.WriteLine("SetStreamInfo returns error!");
            //Set the origin maskvalue and channel number to the function

            DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local); // 1970/1/1 0:0:0
            int playTime = (int)((Playbacktime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time 
            result=SdkShellSetPlayTime(ptr, (uint)PlayTimeMode.SEEK_AND_PLAY, playTime, 10);
            if(result!=0)
                Console.WriteLine("SetPlayTime returns error!");
            //Set the origin maskvalue and channel number to the function
            forward_speed = 1;
            backward_speed = 0;
        }

        private void WaterMarkCB_Change(object sender, EventArgs e)
        {

            if (SdkShellWaterMarkCBEnable(ptr, WaterMarckCB.Checked) < 0)  
                MessageBox.Show("Water Mark Callback setting Error");

        }

        private void DVRLogbtn_Click(object sender, EventArgs e)
        {
            if (IP_tb.Text.Length == 0)
            {
                MessageBox.Show("IP string is Empty");
                return;
            }
            
            IntPtr Logptr = IntPtr.Zero;
            int result = 0;

            str_IP = IP_tb.Text;
            int_port = Convert.ToInt32(port_tb.Text);
            str_username = account_tb.Text;
            str_password = password_tb.Text;
            DeviceType _dtDeviceType;

            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(ModalType.MV_DVR);

            //Initial shell and Source
            _dtDeviceType = DeviceType.DEVICE_DVR;

            SaveFileDialog path = new SaveFileDialog();
            path.Filter = "RTF files(*.rtf)|*.rtf|All files (*.*)|*.*";//Filename Extension

            if (path.ShowDialog() == DialogResult.OK)
            {
                DVRLogbtn.Enabled = false;
                String txtPath;
                txtPath = path.FileName.ToString();

                result = SdkShellInitialSource(ref Logptr, _dtDeviceType, stOpenParam.dwModal, 0);
                result = SdkShellOpenSource(Logptr, ref stOpenParam, ViewType.NONE, 0);

                GetSystemLog GetSystemLogfile;
                GetSystemLogfile = new GetSystemLog(Logptr, txtPath);
                GetSystemLogfile.StartLogenable += new EventHandler(StartSelectedBtn);
                Thread GetLogthread = new Thread(GetSystemLogfile.getDVRLogData);
                GetLogthread.Start();
            }
            else
                return;
        }

        private void HDDLog_Click(object sender, EventArgs e)
        {


            int _iSelectedHDD = Int32.Parse(SelectHDD.Text);
            _iSelectedHDD = _iSelectedHDD - 1;
            if (CheckHDDList(_iSelectedHDD) == true)
            {
                HDDLog cl_HDDLog = new HDDLog();
                cl_HDDLog.Show();

                cl_HDDLog.GetHDDValue(class_callback.m_StatusCallback.HDDList[_iSelectedHDD].drv_number);
            }
            else
                return;
        }

        private void btn_Combine_Click(object sender, EventArgs e)
        {
            int result = 0;

            IntPtr tempptr = IntPtr.Zero;
            OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(ModalType.MV_HDD);
            result = SdkShellInitialSource(ref tempptr, DeviceType.DEVICE_HDD, stOpenParam.dwModal, 0);

            string CombinePath;
            OutputFile.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.* ";
            if (OutputFile.ShowDialog() == DialogResult.OK)
            {
                CombinePath = OutputFile.FileName;
                result = SdkShellCombineFile(tempptr, txt_InputFile1.Text, txt_InputFile2.Text, CombinePath);
                if (result == 0)
                {
                    MessageBox.Show("Combine file success.");
                }
                else
                {
                    MessageBox.Show("Combine file fail.");
                }
            }
        }

        private void txt_InputFile1_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Open InputFile1 Dialog");

            InputFile1.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.* ";
            if (InputFile1.ShowDialog() == DialogResult.OK)
                txt_InputFile1.Text = InputFile1.FileName;
        }

        private void txt_InputFile2_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Open InputFile2 Dialog");

            InputFile2.Filter = "avr files(*.avr)|*.avr|All files (*.*)|*.* ";
            if (InputFile2.ShowDialog() == DialogResult.OK)
                txt_InputFile2.Text = InputFile2.FileName;
        }

        private void btnContSS_Click(object sender, EventArgs e)
        {

            if (!bSSTimer)
            {

                if (IP_tb.Text.Length == 0)
                {
                    MessageBox.Show("IP string is Empty");
                    return;
                }

                if (Select_Modaltype.SelectedIndex != 0)
                {
                    MessageBox.Show("Only live stream support continuous snapshot");
                    return;
                }

                FolderBrowserDialog path = new FolderBrowserDialog();
                //path.Filter = "JPEG files(*.jpg)|*.jpg|All files (*.*)|*.*";//Filename Extension
                if (path.ShowDialog() == DialogResult.OK)
                {
                    foldername = path.SelectedPath.ToString();
                    if (foldername != path.RootFolder.ToString())
                    {
                        foldername=foldername  + "\\";
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a file name");
                    return;
                }

                int result = 0;
                nSnapshotMask = Convert.ToUInt32(Snapshotch.Text);

                if (nSnapshotMask < 0 || nSnapshotMask >= 4095)
                {
                    MessageBox.Show("Please set mask between 1~4095");
                    return;
                }

                if (Select_Modaltype.SelectedIndex == 0)
                {
                    str_IP = IP_tb.Text;
                    int_port = Convert.ToInt32(port_tb.Text);
                    str_username = account_tb.Text;
                    str_password = password_tb.Text;
                    DeviceType _dtDeviceType;

                    mtSelectedType = ModalType.MV_DVR;
                    _dtDeviceType = DeviceType.DEVICE_DVR;
                    SnapShotptr = IntPtr.Zero;

                    Debug.WriteLine("Snapshot!!! Start to open source");
                    OPEN_DEVICE_PARAM_T stOpenParam = CreateDeviceParam(mtSelectedType);
                    result = SdkShellInitialSource(ref SnapShotptr, _dtDeviceType, stOpenParam.dwModal, 0);
                    if (result < 0)
                        return;

                    DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local); // 1970/1/1 0:0:0
                    uint playTime = (uint)((Playbacktime_Picker.Value.Ticks - BaseTime.Ticks) / 10000000); // sec from base time 
                    result = SdkShellOpenSource(SnapShotptr, ref stOpenParam, ViewType.DVR_SNAPSHOT, (int)playTime);
                    if (result < 0)
                        return;

                    //Added by Edward in 2011/12/20 for adding opend device to device list
                    //Because those device is used to play video and audio.
                    Debug.WriteLine("Snapshot!!! Try to remote snapshot");
                    Device_List_Entry_T OpenedDevice = new Device_List_Entry_T();
                    OpenedDevice.Device_Ptr = SnapShotptr;
                    OpenedDevice.Device_Param = stOpenParam;
                    DeviceList.Add(OpenedDevice);


                    //要把snapshot start起來
                    //輸入改成mask
                    result = SdkShellContinueSnapShot_Start(SnapShotptr, (uint)nSnapshotMask, (uint)ViewInfoType.REMOTE_SNAPSHOT); //Edward add 20130906
                    if (result < 0)
                        return;
                    bSSTimer = true;
                    SnapshotTimer.Start();
                    btnContSS.BackColor = System.Drawing.Color.Gold;
                    return;
                }
                else
                {
                    MessageBox.Show("Only live stream support continuous snapshot");
                }


            }
            else
            {

                int _iDeviceIdx = -1;
                for (int i = 0; i < DeviceList.Count; i++)
                {
                    if (DeviceList[i].Device_Ptr == SnapShotptr)
                    {
                        _iDeviceIdx = i;
                        break;
                    }
                }
                if (_iDeviceIdx == -1)
                {
                    MessageBox.Show("Deive is not in the List");
                    return;
                }

                mtSelectedType = DeviceList[_iDeviceIdx].Device_Param.dwModal;
                if (DeviceList[_iDeviceIdx].Device_Param.dwModal == ModalType.MV_DVR)
                    SdkShellCloseSource(DeviceList[_iDeviceIdx].Device_Ptr, ModalType.MV_DVR);
                else
                {
                    MessageBox.Show("No Such ModalType");
                    return;
                }

                SdkShellReleaseSource(DeviceList[_iDeviceIdx].Device_Ptr);
                Debug.WriteLine("Close End");
                //SdkShellRelease();
                SnapShotptr = IntPtr.Zero;
                DeviceList.Remove(DeviceList[_iDeviceIdx]);

                bSSTimer = false;
                SnapshotTimer.Stop();
                btnContSS.BackColor = System.Drawing.SystemColors.Control;

                return; 
            }



        }

        private void GetSnapShotTimer(object sender, EventArgs e)
        {
            if ( !bSSTimer)
            {
                return;
            }

            for(int i=0; i < 16; i++)
            {
                byte[] jpg = new byte[1024 * 1024];
                int iJpgLength = 0;
                uint uPicTime = 0;
                int result = 0;
                if ((int)(nSnapshotMask & 1 << i) != 0)
                {
                    result = SdkShellRemoteSnapShot(SnapShotptr, (uint)i, (uint)ViewInfoType.REMOTE_SNAPSHOT, jpg, out iJpgLength, out uPicTime);
                    if (iJpgLength > 0)
                    {
                        string filename = foldername + "Ch" + Convert.ToString(i + 1) + "_Time" + Convert.ToString(uPicTime) + ".jpg";
                        FileStream fs = new FileStream(filename, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        bw.Write(jpg, 0, iJpgLength);
                        bw.Close();
                        fs.Close();
                    }
                    else
                        MessageBox.Show("iJpgLength is less than or equal to 0");
                }
            }
       
        }

        public void getJ1939MetaDetail()
        {
            str_username = account_tb.Text;
            str_password = password_tb.Text;

            XmlDocument XmlDoc = new XmlDocument();
            XmlUrlResolver Resolver = new XmlUrlResolver();
            Resolver.Credentials = new NetworkCredential(str_username, str_password);
            XmlDoc.XmlResolver = Resolver;

            string str_IP01 = IP_tb.Text;
            string str_xml = "http://" + str_IP01 + "/J1939_MetaDetail.xml";
            try
            {
                XmlDoc.Load(str_xml);
                for (int i = 0; i < 40; i++)
                {
                    j1939MsgAry[i] = XmlDoc.GetElementsByTagName("Description").Item(i).InnerXml.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("This device doesn't support J1939. Please update FW to the latest version.");
            }
            

            
            
        }

    }

    /// <summary>
    /// this class inherit from EventArgs, and carry one enum variable to specify which button will be enable
    /// add by Edward in 20120815
    /// </summary>
    public class EnableBtnSelection : EventArgs //CallbackEventArgs inherit from EventArgs
    {
        public enumBtnSelected BtnSelected;
    }

    public class GetSystemLog //neil add 0711
    {
        IntPtr Logptr = IntPtr.Zero;
        String txtPath;
        EnableBtnSelection LogEnableBtnSelection;
        public event EventHandler StartLogenable;

        public GetSystemLog(IntPtr pLogptr, string pPath)
        {
            Logptr = pLogptr;
            txtPath = pPath;
        }
        public void setLogbtnopen()
        {
            if (StartLogenable != null)
            {
                if (LogEnableBtnSelection != null)
                    StartLogenable(this, LogEnableBtnSelection);
            }
        }

        //HRESULT DLLAPI SdkShellGetSystemLogFile( HDevice hDevice, char* pFileName );
        // SdkShellGetSystemLogFile is used to download system file
        //hDevice: the pointer of selected device
        //pFileName: this string is file path and file name
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetSystemLogFile(IntPtr hDevice, string pFileName ,UInt32 uiStartTime, UInt32 uiEndTime, short sLogType);

        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellCloseSource(IntPtr hDevice, ModalType dwModal);

        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellReleaseSource(IntPtr hDevice);

        /** 
         *********************************************************************
         * @fn<getSystemLogData>
         * @brief<This function will download HDD log file. >
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
        public void getSystemLogData()
        {
            int result = 0;
			int result2 = 0;
            //Added by Edward in 20111223, This function have to add two more variable because web and firmware have change this cgi
            UInt32 uiStartTime, uiEndTime;
            uiStartTime = 0;
            uiEndTime = 0x773593ff;
            

            short sLogType = 1;
            result = SdkShellGetSystemLogFile(Logptr, txtPath, uiStartTime, uiEndTime, sLogType);
            result2 = SdkShellCloseSource(Logptr, ModalType.MV_DVR);
            result2 = SdkShellReleaseSource(Logptr);
            LogEnableBtnSelection = new EnableBtnSelection();
            LogEnableBtnSelection.BtnSelected = enumBtnSelected.SysLogButton;//selected button

            if (result < 0)
            {
                MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                setLogbtnopen();
                return;
            }
            setLogbtnopen();
            MessageBox.Show("Downloading system log file is Completed.");
        }

         /** 
         *********************************************************************
         * @fn<getSystemLogData>
         * @brief<This function will download DVR log file. >
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
        public void getDVRLogData()
        {
            int result = 0;
            int result2 = 0;
            //Added by Edward in 20111223, This function have to add two more variable because web and firmware have change this cgi
            UInt32 uiStartTime, uiEndTime;
            uiStartTime = 0;
            uiEndTime = 0x773593ff;

            short sLogType = 2;
            result = SdkShellGetSystemLogFile(Logptr, txtPath, uiStartTime, uiEndTime, sLogType);
            result2 = SdkShellCloseSource(Logptr, ModalType.MV_DVR);
            result2 = SdkShellReleaseSource(Logptr);
            LogEnableBtnSelection = new EnableBtnSelection();
            LogEnableBtnSelection.BtnSelected = enumBtnSelected.DVRLogButton;//selected button
            if (result < 0)
            {
                MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                setLogbtnopen();
                return;
            }
            setLogbtnopen();
            MessageBox.Show("Downloading system log file is Completed.");
        }


    }

}
