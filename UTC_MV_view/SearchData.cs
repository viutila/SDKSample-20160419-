using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace UTC_MV_view
{
    class SearchData
    {
        IntPtr ptr = IntPtr.Zero;
        ListView SearchlistView;
        int int_total = 0;
        int int_starttime = 0;
        int int_endtime = 0;
        int int_alarm = 0;
        int int_vloss = 0;
        int int_J1939 = 0;
        int int_SystemFault = 0;
        uint videomaskvalue = 0;
        public int int_poweron = 0;
        public int int_gs_impact = 0;
        public int int_gs_accel = 0;
        uint nConditions = 0;
        public bool m_bStopflag = false;
        ModalType MTModalType;

        public MV3_META_SEARCH_T meta_search = new MV3_META_SEARCH_T();
        int discover_count = 0;

        //Gsensor
        ushort us_range = 0;
        byte by_g_value1 = 0;//X axis
        byte by_g_value2 = 0;//Y axis
        byte by_g_value3 = 0;//Z axis

        //Segment GPS
        GPS_POINT SelectedPoint1;
        GPS_POINT SelectedPoint2;
        byte by_radius = 1;

        public const int EVENT_SEARCH = 0;
        public const int GPS_SEARCH = 1;
        public const int G_SENSOR_SEARCH = 2;
        public const int SEGMENT_SEARCH = 3;
        int Search_type = 0;

        public event EventHandler Startenable;
        public event EventHandler CloseForm;
        EVENT_T_MV3toString_Struct mv3EventString = new EVENT_T_MV3toString_Struct();

        public struct EVENT_T_MV3toString_Struct
        {
            public string uiEventID;
            public string uiEventType; 
            public string uiExt;
            public string uiblock_start;
            public string uiFragID;
            public string StartTime;
            public string EndTime;
            public string speed;
            public string acc;
            public string course;
            public string lat;
            public string lon;
            public string lat_sn;
            public string lon_ew;
            public string priority;
            public string a_index;
            public string v_index;
            public string ucPre;
            public string ucPost;
            public string Offset;
            public string DayLightSaving;
            public string chmap;
            public string szEventMsg;
            public string eventName;
        }

        public void EVENT_T_MV3toString(EVENT_T_MV3 mv3event)
        {
            DateTime eventSTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)mv3event.StartTime);
            DateTime eventETime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)mv3event.EndTime);

            mv3EventString.uiEventID = mv3event.uiEventID.ToString();
            mv3EventString.uiEventType = Enum.Parse(typeof(EventType), mv3event.uiEventType.ToString()).ToString();
            if (mv3event.uiEventType == 13)//for power_on no ch display
            {
                mv3EventString.uiExt = "";
            }
            else
            {
                mv3EventString.uiExt = (mv3event.uiExt + 1).ToString();
            }
            mv3EventString.uiblock_start = mv3event.uiblock_start.ToString();
            mv3EventString.uiFragID = mv3event.uiFragID.ToString();
            mv3EventString.StartTime = eventSTime.ToString("yyyy/M/d HH:mm:ss tt");
            mv3EventString.EndTime = eventETime.ToString("yyyy/M/d HH:mm:ss tt");
            mv3EventString.speed = mv3event.speed.ToString();
            mv3EventString.acc = mv3event.acc.ToString();
            mv3EventString.course = mv3event.course.ToString();
            mv3EventString.lat = mv3event.lat.ToString();
            mv3EventString.lon = mv3event.lon.ToString();
            mv3EventString.lat_sn = mv3event.lat_sn.ToString();
            mv3EventString.lon_ew = mv3event.lon_ew.ToString();
            mv3EventString.priority = mv3event.priority.ToString();
            mv3EventString.a_index = mv3event.a_index.ToString();
            mv3EventString.v_index = mv3event.v_index.ToString();
            mv3EventString.ucPre = mv3event.ucPre.ToString();
            mv3EventString.ucPost = mv3event.ucPost.ToString();
            mv3EventString.Offset = mv3event.offset.ToString();
            mv3EventString.DayLightSaving = mv3event.dst.ToString();
            mv3EventString.chmap = mv3event.chnmap.ToString();
            mv3EventString.szEventMsg = mv3event.szEventMsg.ToString();
            mv3EventString.eventName = GetStringFromBytes(mv3event.eventName);
        }

        public string GetStringFromBytes(byte[] bytes)
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

        public void setStartbtnopen()
        {
            if (Startenable != null)
                Startenable(this, new EventArgs());
        }
        public void setCloseForm()
        {
            if (CloseForm != null)
                CloseForm(this, new EventArgs());
        }

        //Event constructor
        public SearchData(IntPtr sptr, ListView listView, int startTime, int endTime, int alarmCon, int vlossCon, int poweron, int gs_impact, int gs_accel, int SystemFault, int J1939Con, uint videomask)
        {
            ptr = sptr;
            SearchlistView = listView;
            int_starttime = startTime;
            int_endtime = endTime;
            int_alarm = alarmCon;
            int_vloss = vlossCon;
            int_J1939 = J1939Con;
            int_poweron = poweron;
            int_gs_impact = gs_impact;
            int_gs_accel = gs_accel;
            int_SystemFault = SystemFault;
            videomaskvalue = videomask;
            Search_type = EVENT_SEARCH;//event search
            //In current version, if user does not want to search by a_index, they can assign this value(255).
            //In current version, if user does not want to search by a_index, they can assign this value(65535)
            //In current version, if user does not want to search by GPS coordinate, assigne all gps variables zero
            meta_search.a_index = (byte)255;
            meta_search.v_index = (ushort)65535;
        }

        //Gsensor constructor
        public SearchData(IntPtr sptr, ListView listView, int startTime, int endTime, ushort us_mode, byte by_valueone, byte by_valuetwo, byte by_valuethree)
        {
            ptr = sptr;
            SearchlistView = listView;
            int_starttime = startTime;
            int_endtime = endTime;
            us_range = us_mode;
            by_g_value1 = by_valueone;
            by_g_value2 = by_valuetwo;
            by_g_value3 = by_valuethree;
            videomaskvalue = 1; //Gsensor camera map default
            Search_type = G_SENSOR_SEARCH;//G sensor search
            meta_search.a_index = (byte)255;
            meta_search.v_index = (ushort)65535;
        }

        //GPS constructor
        public SearchData(IntPtr sptr, ListView listView, int startTime, int endTime, ModalType MT_ModalType, uint InputConditions, byte radius)
        {
            ptr = sptr;
            SearchlistView = listView;
            int_starttime = startTime;
            int_endtime = endTime;
            MTModalType = MT_ModalType;
            nConditions = InputConditions;
            by_radius = radius;
            Search_type = GPS_SEARCH;//GPS search
            meta_search.a_index = (byte)255;
            meta_search.v_index = (ushort)65535;
        }

        //Segment constructor
        public SearchData(IntPtr sptr, ListView listView, int startTime, int endTime, int alarmCon, int vlossCon, int poweron, int SystemFault, uint videomask, GPS_POINT SelectedPointd1, GPS_POINT SelectedPointd2)
        {
            ptr = sptr;
            SearchlistView = listView;
            int_starttime = startTime;
            int_endtime = endTime;
            int_alarm = alarmCon;
            int_vloss = vlossCon;
            videomaskvalue = videomask;
            int_poweron = poweron;
            int_SystemFault = SystemFault;
            SelectedPoint1 = new GPS_POINT();
            SelectedPoint2 = new GPS_POINT();
            SelectedPoint1 = SelectedPointd1;
            SelectedPoint2 = SelectedPointd2;
            Search_type = SEGMENT_SEARCH;//Segment search
            //In current version, if user does not want to search by a_index, they can assign this value(255).
            //In current version, if user does not want to search by a_index, they can assign this value(65535)
            //In current version, if user does not want to search by GPS coordinate, assigne all gps variables zero
            meta_search.a_index = (byte)255;
            meta_search.v_index = (ushort)65535;
        }

        //HRESULT DLLAPI SdkShellSearchEventList( HDevice hDevice, DWORD dwChannelMap, long lStartTime, long lEndTime, DWORD dwEventType, MV3_META_SEARCH_T meta_search);
        //SdkShellSearchEventList is used to set event search parameters and ask device start to search
        //hDevice: select device that is used to represent a pointer 
        //dwChannelMap: camera map
        //lStartTime: start search time
        //lEndTime: end search time
        //dwEventType: use define conditions 
        //meta_search: Set search parameters
        //dwAlarmMap: If want to search alarm need to alarm map
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellSearchEventList(IntPtr hDevice, uint dwChannelMap, int lStartTime, int lEndTime, uint dwEventType, MV3_META_SEARCH_T meta_search);

        //long DLLAPI SdkShellGetSearchEventCount( HDevice hDevice )
        //SdkShellGetSearchEventCount is used to get event count
        //hDevice: the pointer of selected device
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetSearchEventCount(IntPtr hDevice);

        //HRESULT DLLAPI SdkShellGetSearchEventItem( HDevice hDevice, long lItem, long *lResultType, void *pResult );
        //SdkShellGetSearchEventItem is used to transfer event data
        //hDevice: the pointer of selected device
        //nIndex: event item index
        //lResultType: Currently, it is a reserved variable
        //pResult: pointer of search result, its type should be EVENT_T_P2
        [DllImportAttribute("SdkShell.dll")]
        private static extern int SdkShellGetSearchEventItem(IntPtr hDevice, int nStartIndex, int nEndIndex, out int lItemCount, ref IntPtr lResultType, IntPtr pResult);

        //build list
        private delegate void AsyncListViewCallBack(ListViewItem lvItem, Control ctl);
        private void ListViewCallBack(ListViewItem lvItem, Control ctl)
        {
            ListView lv = ctl as ListView;
            lv.Items.Add(lvItem);
        }

        //Event list    
        private ListViewItem GetEnventSearchListViewItem(string no)
        {
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = no;

            ListViewItem.ListViewSubItem lviSubItemChMap = new ListViewItem.ListViewSubItem();
            lviSubItemChMap.Text = mv3EventString.chmap;
            lvItem.SubItems.Add(lviSubItemChMap);

            ListViewItem.ListViewSubItem lviSubItemCH = new ListViewItem.ListViewSubItem();
            lviSubItemCH.Text = mv3EventString.uiExt;
            lvItem.SubItems.Add(lviSubItemCH);

            ListViewItem.ListViewSubItem lviSubItemtype = new ListViewItem.ListViewSubItem();
            lviSubItemtype.Text = mv3EventString.uiEventType;
            lvItem.SubItems.Add(lviSubItemtype);

            ListViewItem.ListViewSubItem lviSubItemSTime = new ListViewItem.ListViewSubItem();
            lviSubItemSTime.Text = mv3EventString.StartTime;
            lvItem.SubItems.Add(lviSubItemSTime);

            ListViewItem.ListViewSubItem lviSubItemETime = new ListViewItem.ListViewSubItem();
            lviSubItemETime.Text = mv3EventString.EndTime;
            lvItem.SubItems.Add(lviSubItemETime);

            ListViewItem.ListViewSubItem lviSubItemlat_sn = new ListViewItem.ListViewSubItem();
            lviSubItemlat_sn.Text = mv3EventString.lat_sn;
            lvItem.SubItems.Add(lviSubItemlat_sn);

            ListViewItem.ListViewSubItem lviSubItemlat = new ListViewItem.ListViewSubItem();
            lviSubItemlat.Text = mv3EventString.lat;
            lvItem.SubItems.Add(lviSubItemlat);

            ListViewItem.ListViewSubItem lviSubItemlon_ew = new ListViewItem.ListViewSubItem();
            lviSubItemlon_ew.Text = mv3EventString.lon_ew;
            lvItem.SubItems.Add(lviSubItemlon_ew);

            ListViewItem.ListViewSubItem lviSubItemlon = new ListViewItem.ListViewSubItem();
            lviSubItemlon.Text = mv3EventString.lon;
            lvItem.SubItems.Add(lviSubItemlon);

            ListViewItem.ListViewSubItem lviSubItemspeed = new ListViewItem.ListViewSubItem();
            lviSubItemspeed.Text = mv3EventString.speed;
            lvItem.SubItems.Add(lviSubItemspeed);

            ListViewItem.ListViewSubItem lviSubItemgravity = new ListViewItem.ListViewSubItem();
            lviSubItemgravity.Text = mv3EventString.acc;
            lvItem.SubItems.Add(lviSubItemgravity);

            ListViewItem.ListViewSubItem lviSubItemblockID = new ListViewItem.ListViewSubItem();
            lviSubItemblockID.Text = mv3EventString.uiblock_start;
            lvItem.SubItems.Add(lviSubItemblockID);

            ListViewItem.ListViewSubItem lviSubItemdirection = new ListViewItem.ListViewSubItem();
            lviSubItemdirection.Text = mv3EventString.course;
            lvItem.SubItems.Add(lviSubItemdirection);

            ListViewItem.ListViewSubItem lviSubItempriority = new ListViewItem.ListViewSubItem();
            lviSubItempriority.Text = mv3EventString.priority;
            lvItem.SubItems.Add(lviSubItempriority);

            ListViewItem.ListViewSubItem lviSubItema_index = new ListViewItem.ListViewSubItem();
            lviSubItema_index.Text = mv3EventString.a_index;
            lvItem.SubItems.Add(lviSubItema_index);

            ListViewItem.ListViewSubItem lviSubItemv_index = new ListViewItem.ListViewSubItem();
            lviSubItemv_index.Text = mv3EventString.v_index;
            lvItem.SubItems.Add(lviSubItemv_index);

            ListViewItem.ListViewSubItem lviSubItemPre_alarm = new ListViewItem.ListViewSubItem();
            lviSubItemPre_alarm.Text = mv3EventString.ucPre;
            lvItem.SubItems.Add(lviSubItemPre_alarm);

            ListViewItem.ListViewSubItem lviSubItemPost_alarm = new ListViewItem.ListViewSubItem();
            lviSubItemPost_alarm.Text = mv3EventString.ucPost;
            lvItem.SubItems.Add(lviSubItemPost_alarm);

            ListViewItem.ListViewSubItem lviSubItemTimeZone = new ListViewItem.ListViewSubItem();
            lviSubItemTimeZone.Text = mv3EventString.Offset;
            lvItem.SubItems.Add(lviSubItemTimeZone);

            ListViewItem.ListViewSubItem lviSubItemDST = new ListViewItem.ListViewSubItem();
            lviSubItemDST.Text = mv3EventString.DayLightSaving;
            lvItem.SubItems.Add(lviSubItemDST);

            ListViewItem.ListViewSubItem lviSubItemeventName = new ListViewItem.ListViewSubItem();
            lviSubItemeventName.Text = mv3EventString.eventName;
            lvItem.SubItems.Add(lviSubItemeventName);

            return lvItem;
        }

        //GSensor list
        private ListViewItem GetGSensorListViewItem(string no, string STime, string type)
        {
            //get event data add list
            //no: index
            //STime: start time
            //type: event type
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = no;

            ListViewItem.ListViewSubItem lviSubItemSTime = new ListViewItem.ListViewSubItem();
            lviSubItemSTime.Text = STime;
            lvItem.SubItems.Add(lviSubItemSTime);

            ListViewItem.ListViewSubItem lviSubItemtype = new ListViewItem.ListViewSubItem();
            lviSubItemtype.Text = type;
            lvItem.SubItems.Add(lviSubItemtype);

            return lvItem;
        }

        //Segment list
        private ListViewItem GetSegmentListViewItem(string no)
        {
            //no: index
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = no;

            ListViewItem.ListViewSubItem lviSubItemCH = new ListViewItem.ListViewSubItem();
            lviSubItemCH.Text = mv3EventString.uiExt;
            lvItem.SubItems.Add(lviSubItemCH);

            ListViewItem.ListViewSubItem lviSubItemtype = new ListViewItem.ListViewSubItem();
            lviSubItemtype.Text = mv3EventString.uiEventType;
            lvItem.SubItems.Add(lviSubItemtype);

            ListViewItem.ListViewSubItem lviSubItemSTime = new ListViewItem.ListViewSubItem();
            lviSubItemSTime.Text = mv3EventString.StartTime;
            lvItem.SubItems.Add(lviSubItemSTime);

            ListViewItem.ListViewSubItem lviSubItemETime = new ListViewItem.ListViewSubItem();
            lviSubItemETime.Text = mv3EventString.EndTime;
            lvItem.SubItems.Add(lviSubItemETime);

            return lvItem;
        }

        //set metadate for segment use
        public int setMV3metesearch()
        {
            meta_search.gps_lon1_ew = SelectedPoint1.lon_section;
            meta_search.gps_lon1 = SelectedPoint1.lon_value;
            meta_search.gps_lat1_sn = SelectedPoint1.lat_section;
            meta_search.gps_lat1 = SelectedPoint1.lat_value;
            meta_search.gps_lon2_ew = SelectedPoint2.lon_section;
            meta_search.gps_lon2 = SelectedPoint2.lon_value;
            meta_search.gps_lat2_sn = SelectedPoint2.lat_section;
            meta_search.gps_lat2 = SelectedPoint2.lat_value;
            meta_search.a_index =(byte) 255;//temp default
            meta_search.v_index = (ushort)65535;//temp default
            return 0;
        }

        //GPS list
        private ListViewItem GetGPSListViewItem(string no)
        {
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = no;

            ListViewItem.ListViewSubItem lviSubItemTime = new ListViewItem.ListViewSubItem();
            lviSubItemTime.Text = mv3EventString.StartTime;
            lvItem.SubItems.Add(lviSubItemTime);

            ListViewItem.ListViewSubItem lviSubItemtype = new ListViewItem.ListViewSubItem();
            lviSubItemtype.Text = mv3EventString.uiblock_start;
            lvItem.SubItems.Add(lviSubItemtype);

            ListViewItem.ListViewSubItem lviSubItemFragID = new ListViewItem.ListViewSubItem();
            lviSubItemFragID.Text = mv3EventString.uiFragID;
            lvItem.SubItems.Add(lviSubItemFragID);

            ListViewItem.ListViewSubItem lviSubItemLat_SN = new ListViewItem.ListViewSubItem();
            lviSubItemLat_SN.Text = mv3EventString.lat_sn;
            lvItem.SubItems.Add(lviSubItemLat_SN);

            ListViewItem.ListViewSubItem lviSubItemLat = new ListViewItem.ListViewSubItem();
            lviSubItemLat.Text = mv3EventString.lat;
            lvItem.SubItems.Add(lviSubItemLat);

            ListViewItem.ListViewSubItem lviSubItemLon_EW = new ListViewItem.ListViewSubItem();
            lviSubItemLon_EW.Text = mv3EventString.lon_ew;
            lvItem.SubItems.Add(lviSubItemLon_EW);

            ListViewItem.ListViewSubItem lviSubItemLon = new ListViewItem.ListViewSubItem();
            lviSubItemLon.Text = mv3EventString.lon;
            lvItem.SubItems.Add(lviSubItemLon);
            return lvItem;
        }

        /** 
         *********************************************************************
         * @fn<SetGPSTwoPointLocation>
         * @brief<This function will call ui thread to enable start button >
         * 
         * @param[in]
         * <GPS_POINT _SelectedPoint1: GPS points>
         * <GPS_POINT _SelectedPoint2: GPS points>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int 0>
         *********************************************************************
         */
        public int SetGPSTwoPointLocation(GPS_POINT _SelectedPoint1, GPS_POINT _SelectedPoint2)
        {
            meta_search.gps_lon1_ew = _SelectedPoint1.lon_section;
            meta_search.gps_lon1 = _SelectedPoint1.lon_value;
            meta_search.gps_lat1_sn = _SelectedPoint1.lat_section;
            meta_search.gps_lat1 = _SelectedPoint1.lat_value;
            meta_search.gps_lon2_ew = _SelectedPoint2.lon_section;
            meta_search.gps_lon2 = _SelectedPoint2.lon_value;
            meta_search.gps_lat2_sn = _SelectedPoint2.lat_section;
            meta_search.gps_lat2 = _SelectedPoint2.lat_value;

            meta_search.radius = by_radius;
            return 0;
        }

        /** 
         *********************************************************************
         * @fn<SetGPSLocation>
         * @brief<This function will call ui thread to enable start button >
         * 
         * @param[in]
         * <GPS_POINT _SelectedPoint1: GPS points>
         * <GPS_POINT _SelectedPoint2: GPS points>
         * @param[out]
         *    none
         * @retval
         *    none
         * @return <int 0>
         *********************************************************************
         */
        public int SetGPSLocation(GPS_POINT _SelectedPoint1, GPS_POINT _SelectedPoint2, ushort u16_a_index, ushort u16_v_index)
        {
            meta_search.gps_lon1_ew = _SelectedPoint1.lon_section;
            meta_search.gps_lon1 = _SelectedPoint1.lon_value;
            meta_search.gps_lat1_sn = _SelectedPoint1.lat_section;
            meta_search.gps_lat1 = _SelectedPoint1.lat_value;
            meta_search.gps_lon2_ew = _SelectedPoint2.lon_section;
            meta_search.gps_lon2 = _SelectedPoint2.lon_value;
            meta_search.gps_lat2_sn = _SelectedPoint2.lat_section;
            meta_search.gps_lat2 = _SelectedPoint2.lat_value;

            meta_search.a_index = (byte)u16_a_index;
            meta_search.v_index = u16_v_index;

            return 0;
        }
        public void getSearchData()
        {
            //assign condition and get search data
            int result = 0;
            IntPtr iResultType;
            DateTime STime = new DateTime();

            switch (Search_type)
            {
                case EVENT_SEARCH:  //event search

                    nConditions += (uint)SearchConditions.SEARCH_COND_EVENT;

                    if (int_alarm != 0)//alarm
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_ALARM;
                    }

                    if (int_vloss != 0)//videoloss
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_VLOSS;
                    }

                    if (int_poweron != 0)//power on
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_POWER_ON;
                    }

                    if (int_gs_impact != 0)//G sensor impact
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_GS_IMPACT;
                    }

                    if (int_gs_accel != 0)//G sensor accel
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_GS_ACCEL;
                    }

                    if (int_SystemFault != 0)
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_SYSTEM_FAULT;
                    }

                    if (int_J1939 != 0)
                    { 
                        nConditions += (uint)SearchConditions.SEARCH_COND_J1939_TYPE;
                    }

                    if (videomaskvalue == 0)//videomaskvalue default 1
                    {
                        videomaskvalue = 1;
                    }
                    //assign start time, end time, Condition, meta_search structure and alarmmask

                    //Soya 20110727


                    result = SdkShellSearchEventList(ptr, (uint)videomaskvalue, int_starttime, int_endtime, (uint)nConditions, meta_search);//change by Edward
                    if (result < 0)
                    {
                        MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                        setCloseForm();
                        return;
                    }
                    nConditions = 0;
                    videomaskvalue = 0;
                    //alarmmaskvalue = 0;
                    int_total = SdkShellGetSearchEventCount(ptr);

                    //get total event
                    if (int_total > 0)
                    {
                        int iStartIndex = 0;
                        int iEndIndex = 0;
                        int iAmount_per_round = 100;
                        int itemCount = 0;
                        int itemSize = Marshal.SizeOf(typeof(EVENT_T_MV3));
                        int index = 0;
                        while ((m_bStopflag == false) && (int_total > 0))
                        {

                            itemCount = int_total > iAmount_per_round ? iAmount_per_round : int_total;
                            iResultType = IntPtr.Zero;
                            IntPtr iResult = Marshal.AllocHGlobal(itemSize * itemCount);
                            iEndIndex = iStartIndex + itemCount - 1;
                            int lReturnedAmount = 0;
                            result = SdkShellGetSearchEventItem(ptr, iStartIndex, iEndIndex, out lReturnedAmount, ref iResultType, iResult);


                            for (int i = 0; i < lReturnedAmount; i++)
                            {
                                EVENT_T_MV3 mv3Event = new EVENT_T_MV3();
                                IntPtr ItemPtr = new IntPtr(iResult.ToInt32() + itemSize * i);
                                mv3Event = (EVENT_T_MV3)Marshal.PtrToStructure(ItemPtr, typeof(EVENT_T_MV3));

                                //get data to list
                                EVENT_T_MV3toString(mv3Event);
                                ListViewItem lvItem;
                                lvItem = GetEnventSearchListViewItem((index + 1).ToString());

                                object[] inputarg = new object[2];
                                inputarg[0] = lvItem;
                                inputarg[1] = SearchlistView;

                                SearchlistView.BeginInvoke(new AsyncListViewCallBack(ListViewCallBack), inputarg);
                                discover_count++;
                                index++;
                            }

                            Marshal.FreeHGlobal(iResult);
                            int_total -= lReturnedAmount;
                            iStartIndex += lReturnedAmount;

                        }
                        setStartbtnopen();
                        MessageBox.Show("search complete");
                    }
                    else
                    {
                        setStartbtnopen();
                        MessageBox.Show("No data");
                    }

                    break;

                case GPS_SEARCH:  //GPS search

                    if (videomaskvalue == 0)
                    {
                        videomaskvalue = 1;
                    }
                    //if (MTModalType == ModalType.MV_HDD)
                    //{
                    //    meta_search.mode = 1;   //GPS Border Type 0:Circle 1:Rectangle
                    //    meta_search.range = 2;  //Search Mode 0:Inside 1:Outside
                    //    //meta_search.gps_inout = 3;
                    //    //meta_search.gps_lat1_sn = 1;
                    //    //meta_search.gps_lat2_sn = 1;
                    //    //meta_search.gps_lon1_ew = 0;
                    //    //meta_search.gps_lon2_ew = 0;
                    //}
                    //else if (MTModalType == ModalType.MV_DVR)
                    //{
                    //    meta_search.mode = 1;   //GPS Border Type 0:Circle 1:Rectangle
                    //    meta_search.range = 2;  //Search Mode 0:Inside 1:Outside
                    //}
                    result = SdkShellSearchEventList(ptr, (uint)videomaskvalue, int_starttime, int_endtime, (uint)nConditions, meta_search);
                    if (result < 0)
                    {
                        MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                        setCloseForm();
                        return;
                    }
                    int_total = SdkShellGetSearchEventCount(ptr);
                    if (int_total > 0)
                    {
                        int iStartIndex = 0;
                        int iEndIndex = 0;
                        int iAmount_per_round = 100;
                        int itemCount = 0;
                        int itemSize = Marshal.SizeOf(typeof(EVENT_T_MV3));
                        int index = 0;
                        while ((m_bStopflag == false) && (int_total > 0))
                        {
                            itemCount = int_total > iAmount_per_round ? iAmount_per_round : int_total;
                            iResultType = IntPtr.Zero;
                            IntPtr iResult = Marshal.AllocHGlobal(itemSize * itemCount);
                            iEndIndex = iStartIndex + itemCount - 1;
                            int lReturnedAmount = 0;
                            result = SdkShellGetSearchEventItem(ptr, iStartIndex, iEndIndex, out lReturnedAmount, ref iResultType, iResult);
                            for (int i = 0; i < lReturnedAmount; i++)
                            {
                                EVENT_T_MV3 mv3Event = new EVENT_T_MV3();
                                IntPtr ItemPtr = new IntPtr(iResult.ToInt32() + itemSize * i);
                                mv3Event = (EVENT_T_MV3)Marshal.PtrToStructure(ItemPtr, typeof(EVENT_T_MV3));

                                //get data to list
                                EVENT_T_MV3toString(mv3Event);
                                ListViewItem lvItem;
                                lvItem = GetGPSListViewItem((index + 1).ToString());

                                object[] inputarg = new object[2];
                                inputarg[0] = lvItem;
                                inputarg[1] = SearchlistView;

                                SearchlistView.BeginInvoke(new AsyncListViewCallBack(ListViewCallBack), inputarg);
                                discover_count++;
                                index++;
                            }
                            Marshal.FreeHGlobal(iResult);
                            int_total -= lReturnedAmount;
                            iStartIndex += lReturnedAmount;
                        }
                        setStartbtnopen();
                        MessageBox.Show("search complete");
                    }
                    else
                    {
                        setStartbtnopen();
                        MessageBox.Show("No data");
                    }

                    break;

                case G_SENSOR_SEARCH:   //G sensor search

                    nConditions += (uint)SearchConditions.GSENSOR_MAP;
                    if (videomaskvalue == 0)
                    {
                        videomaskvalue = 1;
                    }

                    //HDD Gsensor mata data
                    meta_search.g_x_val = by_g_value1;
                    meta_search.g_y_val = by_g_value2;
                    meta_search.g_z_val = by_g_value3;
                    meta_search.g_sensor = 7;//search X, Y ,Z axis

                    //DVR Gsensor mata data
                    meta_search.g_value1 = by_g_value1;
                    meta_search.g_value2 = by_g_value2;
                    meta_search.range = us_range;

                    //assign start time, end time, Condition and meta_search structure
                    result = SdkShellSearchEventList(ptr, (uint)videomaskvalue, int_starttime, int_endtime, (uint)nConditions, meta_search);
                    if (result < 0)
                    {
                        MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                        setCloseForm();
                        return;
                    }
                    int_total = SdkShellGetSearchEventCount(ptr);
                    //get total event
                    if (int_total > 0)
                    {
                        int iStartIndex = 0;
                        int iEndIndex = 0;
                        int iAmount_per_round = 100;
                        int itemCount = 0;
                        int itemSize = Marshal.SizeOf(typeof(EVENT_T_P2));
                        int index = 0;
                        while ((m_bStopflag == false) && (int_total > 0))
                        {
                            itemCount = int_total > iAmount_per_round ? iAmount_per_round : int_total;
                            iResultType = IntPtr.Zero;
                            IntPtr iResult = Marshal.AllocHGlobal(itemSize * itemCount);
                            iEndIndex = iStartIndex + itemCount - 1;
                            int lReturnedAmount = 0;
                            result = SdkShellGetSearchEventItem(ptr, iStartIndex, iEndIndex, out lReturnedAmount, ref iResultType, iResult);
                            for (int i = 0; i < lReturnedAmount; i++)
                            {
                                EVENT_T_P2 p2Event = new EVENT_T_P2();
                                IntPtr ItemPtr = new IntPtr(iResult.ToInt32() + itemSize * i);
                                p2Event = (EVENT_T_P2)Marshal.PtrToStructure(ItemPtr, typeof(EVENT_T_P2));

                                STime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)p2Event.nStartTime);
                                ListViewItem lvItem;
                                lvItem = GetGSensorListViewItem((index + 1).ToString(), STime.ToString("yyyy/M/d HH:mm:ss tt"), "");

                                object[] inputarg = new object[2];
                                inputarg[0] = lvItem;
                                inputarg[1] = SearchlistView;

                                SearchlistView.BeginInvoke(new AsyncListViewCallBack(ListViewCallBack), inputarg);
                                discover_count++;
                                index++;
                            }
                            Marshal.FreeHGlobal(iResult);
                            int_total -= lReturnedAmount;
                            iStartIndex += lReturnedAmount;
                        }
                        setStartbtnopen();
                        MessageBox.Show("search complete");
                    }
                    else
                    {
                        setStartbtnopen();
                        MessageBox.Show("No data");
                    }

                    break;

                case SEGMENT_SEARCH:    //Segment search

                    nConditions += (uint)SearchConditions.SEARCH_COND_EVENT;

                    if (int_alarm != 0)//alarm
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_ALARM;
                    }
                    if (int_vloss != 0)//videoloss
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_VLOSS;
                    }
                    if (int_SystemFault != 0)
                    {
                        nConditions += (uint)SearchConditions.SEARCH_COND_SYSTEM_FAULT;
                    }
                    //if (int_poweron != 0)//power on
                    //{
                    //nConditions += (uint)SearchConditions.POWER_ON;
                    //}
                    nConditions += (uint)SearchConditions.SEARCH_COND_SEGMENT;

                    if (videomaskvalue == 0)//videomaskvalue default 1
                    {
                        videomaskvalue = 1;
                    }

                    setMV3metesearch(); //assign meta_search

                    //assign start time, end time, Condition, meta_search structure and alarmmask
                    
                    result = SdkShellSearchEventList(ptr, (uint)videomaskvalue, int_starttime, int_endtime, (uint)nConditions, meta_search);
                    if(result < 0)
                    {
                         MessageBox.Show(Enum.Parse(typeof(ErrorMessage), result.ToString()).ToString());
                         setCloseForm();
                         return;
                    }
                    nConditions = 0;
                    videomaskvalue = 0;
                    //alarmmaskvalue = 0;
                    int_total = SdkShellGetSearchEventCount(ptr);

                    //get total event
                    if (int_total > 0)
                    {
                        int iStartIndex = 0;
                        int iEndIndex = 0;
                        int iAmount_per_round = 100;
                        int itemCount = 0;
                        int itemSize = Marshal.SizeOf(typeof(EVENT_T_MV3));
                        int index = 0;
                        while ((m_bStopflag == false) && (int_total > 0))
                        {

                            itemCount = int_total > iAmount_per_round ? iAmount_per_round : int_total;
                            iResultType = IntPtr.Zero;
                            IntPtr iResult = Marshal.AllocHGlobal(itemSize * itemCount);
                            iEndIndex = iStartIndex + itemCount - 1;
                            int lReturnedAmount = 0;
                            result = SdkShellGetSearchEventItem(ptr, iStartIndex, iEndIndex, out lReturnedAmount, ref iResultType, iResult);


                            for (int i = 0; i < lReturnedAmount; i++)
                            {
                                EVENT_T_MV3 mv3Event = new EVENT_T_MV3();

                                IntPtr ItemPtr = new IntPtr(iResult.ToInt32() + itemSize * i);
                                mv3Event = (EVENT_T_MV3)Marshal.PtrToStructure(ItemPtr, typeof(EVENT_T_MV3));

                                //get data to list
                                EVENT_T_MV3toString(mv3Event);
                                ListViewItem lvItem;
                                //lvItem = GetSegmentListViewItem((index + 1).ToString());
                                lvItem = GetEnventSearchListViewItem((index + 1).ToString());

                                object[] inputarg = new object[2];
                                inputarg[0] = lvItem;
                                inputarg[1] = SearchlistView;

                                SearchlistView.BeginInvoke(new AsyncListViewCallBack(ListViewCallBack), inputarg);
                                discover_count++;
                                index++;
                            }

                            Marshal.FreeHGlobal(iResult);
                            int_total -= lReturnedAmount;
                            iStartIndex += lReturnedAmount;

                        }
                        setStartbtnopen();
                        MessageBox.Show("search complete");
                    }
                    else
                    {
                        setStartbtnopen();
                        MessageBox.Show("No data");
                    }

                    break;

                default:

                    MessageBox.Show("search fail");
                    break;
            }

        }
    }
}
