using System;
using System.IO;
using System.Runtime.InteropServices;
using Native.XQ.SDK;
using Native.XQ.SDK.Enums;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;
using Newtonsoft.Json;
using Unity;

namespace Native.XQ.Core.Events.Core
{
    public static class XQEvent
    {
        public static event EventHandler<XQAppGroupMsgEventArgs> Event_GroupMsgHandler;

        public static event EventHandler<XQAppPrivateMsgEventArgs> Event_PrivateMsgHandler;

        public static event EventHandler Event_AppDisableHandler;

        public static event EventHandler Event_AppEnableHandler;

        public static XQAPI xqapi;

        static XQEvent()
        {
            //CosturaUtility.Initialize();
        }

        //public static int XQ_Event(string robotQQ,int EventType,int ExtraType, string From, IntPtr FromQQ, IntPtr targetQQ, IntPtr content, IntPtr index, IntPtr id, IntPtr udpmsg, IntPtr unix,int p)

        /// <summary>
        /// Event导出函数
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="EventType"></param>
        /// <param name="ExtraType"></param>
        /// <param name="From"></param>
        /// <param name="FromQQ"></param>
        /// <param name="targetQQ"></param>
        /// <param name="content"></param>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <param name="udpmsg"></param>
        /// <param name="unix"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        [DllExport(ExportName = "XQ_Event", CallingConvention = CallingConvention.StdCall)]
        public static int XQ_Event(string robotQQ, int EventType, int ExtraType, string From, string FromQQ, string targetQQ, string content, string index, string id, string udpmsg, string unix, int p)
        {
            if (EventType == (int)XQEventType.Group)
            {
                if (Event_GroupMsgHandler != null)//群聊消息
                {
                    XQAppGroupMsgEventArgs args = new XQAppGroupMsgEventArgs(robotQQ, (int)EventType, (int)ExtraType, From, FromQQ, content, index, id);
                    args.XQAPI = xqapi;
                    Event_GroupMsgHandler(typeof(XQEvent), args);
                    return (args.Handler ? 2 : 1);
                    //阻塞返回2，继续返回1
                }
            }
            if (EventType == (int)XQEventType.Friend)//好友消息
            {
                if (Event_PrivateMsgHandler != null)
                {
                    XQAppPrivateMsgEventArgs args = new XQAppPrivateMsgEventArgs(robotQQ, (int)EventType, (int)ExtraType, From, content, index, id);
                    args.XQAPI = xqapi;
                    Event_PrivateMsgHandler(typeof(XQEvent), args);
                    return (args.Handler ? 2 : 1);
                    //阻塞返回2，继续返回1
                }
            }
            if (EventType == (int)XQEventType.PluginEnable)//插件启动
            {
                if (Event_AppDisableHandler != null)
                {
                    var args = new EventArgs();
                    Event_AppDisableHandler(typeof(XQEvent), args);
                }
            }
            return 1;
        }

        /// <summary>
        /// XQ_Create 导出函数
        /// </summary>
        /// <param name="frameworkVersion"></param>
        /// <returns></returns>
        [DllExport(ExportName = "XQ_Create", CallingConvention = CallingConvention.StdCall)]
        public static string XQ_Create(string frameworkVersion)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Config"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Config");
            }
            XQMain.AppDirectory = Directory.GetCurrentDirectory() + "\\Config\\" + XQMain.AppInfo().name + "\\";
            if (!Directory.Exists(XQMain.AppDirectory))
            {
                Directory.CreateDirectory(XQMain.AppDirectory);
            }
            //初始化事件容器
            EventContainer.Init();

            if (EventContainer.unityContainer.IsRegistered<IXQAppEnable>())
            {
                if (Event_AppDisableHandler != null)
                {
                    var args = new EventArgs();
                    Event_AppDisableHandler(typeof(XQEvent), args);
                }
            }

            //初始化基本XQAPI
            xqapi = new XQAPI();
            xqapi.AppInfo = XQMain.AppInfo();

            //返回AppInfo Json
            return AppInfo();
        }

        /// <summary>
        /// 插件销毁
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "XQ_DestroyPlugin", CallingConvention = CallingConvention.StdCall)]
        public static int XQ_DestroyPlugin()
        {
            if (Event_AppDisableHandler != null)
            {
                var args = new EventArgs();
                Event_AppDisableHandler(typeof(XQEvent), args);
            }
            return 0;
        }

        /// <summary>
        /// 打开设置界面函数
        /// </summary>
        /// <returns></returns>
        [DllExport(ExportName = "XQ_SetUp", CallingConvention = CallingConvention.StdCall)]
        public static int XQ_SetUp()
        {
            if (Event_AppEnableHandler != null)
            {
                var args = new EventArgs();
                Event_AppEnableHandler(typeof(XQEvent), args);
            }
            return 0;
        }

        /// <summary>
        /// 得到AppInfo的json并返回
        /// </summary>
        /// <returns></returns>
        public static string AppInfo()
        {
            return JsonConvert.SerializeObject(XQMain.AppInfo());
        }
    }
}