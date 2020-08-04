using System;
using System.IO;
using System.Runtime.InteropServices;
using Native.XQ.SDK.Enums;
using Native.XQ.SDK.Event.EventArgs;
using Newtonsoft.Json;

namespace Native.XQ.Core.Events.Core
{
    public static class XQEvent
    {
        public static event EventHandler<XQAppGroupMsgEventArgs> Event_GroupMsgHandler;

        public static event EventHandler<XQAppPrivateMsgEventArgs> Event_PrivateMsgHandler;

        static XQEvent()
        {
            //CosturaUtility.Initialize();
        }

        //public static int XQ_Event(string robotQQ,int EventType,int ExtraType, string From, IntPtr FromQQ, IntPtr targetQQ, IntPtr content, IntPtr index, IntPtr id, IntPtr udpmsg, IntPtr unix,int p)

        [DllExport(ExportName = "XQ_Event", CallingConvention = CallingConvention.StdCall)]
        public static int XQ_Event(string robotQQ, int EventType, int ExtraType, string From, string FromQQ, string targetQQ, string content, string index, string id, string udpmsg, string unix, int p)
        {
            //XQApi.Api_OutPutLog($"来自:{From}的消息,Type{EventType}被我捉到啦!");
            if (EventType == (int)XQEventType.Group)
            {
                if (Event_GroupMsgHandler != null)
                {
                    XQAppGroupMsgEventArgs args = new XQAppGroupMsgEventArgs(robotQQ, (int)EventType, (int)ExtraType, From, content);
                    Event_GroupMsgHandler(typeof(XQEvent), args);
                }
            }
            if (EventType == (int)XQEventType.Friend)
            {
                XQAppPrivateMsgEventArgs args = new XQAppPrivateMsgEventArgs(robotQQ, (int)EventType, (int)ExtraType, From, content);
                Event_PrivateMsgHandler(typeof(XQEvent), args);
            }
            return 1;
        }

        [DllExport(ExportName = "XQ_Create", CallingConvention = CallingConvention.StdCall)]
        public static string XQ_Create(string frameworkVersion)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Config"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Config");
            }
            XQMain.AppDirectory = Directory.GetCurrentDirectory() + "\\Config\\" + XQAppInfo.AppInfo().name;
            if (!Directory.Exists(XQMain.AppDirectory))
            {
                Directory.CreateDirectory(XQMain.AppDirectory);
            }

            EventContainer.Init();

            return AppInfo();
        }

        [DllExport(ExportName = "XQ_DestroyPlugin", CallingConvention = CallingConvention.StdCall)]
        public static int XQ_DestroyPlugin()
        {
            return 0;
        }

        [DllExport(ExportName = "XQ_SetUp", CallingConvention = CallingConvention.StdCall)]
        public static int XQ_SetUp()
        {
            return 0;
        }

        public static string AppInfo()
        {
            return JsonConvert.SerializeObject(XQAppInfo.AppInfo());
        }

        public static void Register()
        {
        }
    }


}