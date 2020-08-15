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
        #region 事件
        public static event EventHandler<XQAppGroupMsgEventArgs> Event_GroupMsgHandler;

        public static event EventHandler<XQAppPrivateMsgEventArgs> Event_PrivateMsgHandler;

        public static event EventHandler<XQAddGroupEventArgs> Event_AddGroupHandler;

        public static event EventHandler<XQAddFriendEventArgs> Event_AddFriendHandler;

        public static event EventHandler<XQBanSpeakEventArgs> Event_BanSpeak;

        public static event EventHandler<XQUnBanSpeakEventArgs> Event_UnBanSpeak;

        public static event EventHandler<XQEventArgs> Event_AppDisableHandler;

        public static event EventHandler<XQEventArgs> Event_AppEnableHandler;

        public static event EventHandler<XQEventArgs> Event_CallMenu;

        #endregion

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
        public static int XQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            if (eventType == (int)XQEventType.Group)
            {
                if (Event_GroupMsgHandler != null)//群聊消息
                {
                    XQAppGroupMsgEventArgs args = new XQAppGroupMsgEventArgs(robotQQ, (int)eventType, (int)extraType, from, fromQQ, content, index, msgid,xqapi);
                    Event_GroupMsgHandler(typeof(XQEvent), args);
                    return (args.Handler ? 2 : 1);
                    //阻塞返回2，继续返回1
                }
            }
            if (eventType == (int)XQEventType.Friend)//好友消息
            {
                if (Event_PrivateMsgHandler != null)
                {
                    XQAppPrivateMsgEventArgs args = new XQAppPrivateMsgEventArgs(robotQQ, (int)eventType, (int)extraType, from, content, index, msgid,xqapi);
                    Event_PrivateMsgHandler(typeof(XQEvent), args);
                    return (args.Handler ? 2 : 1);
                    //阻塞返回2，继续返回1
                }
            }

            if (eventType == (int)XQEventType.PluginEnable)//插件启动
            {
                if (Event_AppEnableHandler != null)
                {
                    var args = new XQEventArgs(xqapi);
                    Event_AppDisableHandler(typeof(XQEvent), args);
                }
            }

            if (eventType == (int)XQEventType.AddGroup || eventType == (int)XQEventType.InvitedToGroup)//群申请/邀请事件AddGroup
            {
                if (Event_AddGroupHandler != null)
                {
                    var args = new XQAddGroupEventArgs(xqapi,robotQQ,eventType,fromQQ,from,udpmsg);
                    Event_AddGroupHandler(typeof(XQEvent), args);
                }
            }
            if (eventType == (int)XQEventType.AddFriend )//加好友事件
            {
                if (Event_AddFriendHandler != null)
                {
                    var args = new XQAddFriendEventArgs(xqapi, robotQQ, eventType, fromQQ);
                    Event_AddFriendHandler(typeof(XQEvent), args);
                }
            }

            if (eventType == (int)XQEventType.BanSpeak)//被禁言
            {
                if (Event_BanSpeak != null)
                {
                    var args = new XQBanSpeakEventArgs(xqapi, robotQQ, eventType, fromQQ, targetQQ, from);
                    Event_BanSpeak(typeof(XQEvent), args);
                }
            }

            if (eventType == (int)XQEventType.AddFriend)//被解除禁言
            {
                if (Event_UnBanSpeak != null)
                {
                    var args = new XQUnBanSpeakEventArgs(xqapi, robotQQ, eventType, fromQQ,targetQQ,from);
                    Event_UnBanSpeak(typeof(XQEvent), args);
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
                var args = new XQEventArgs(xqapi);
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
            if (Event_CallMenu != null)
            {
                var args = new XQEventArgs(xqapi);
                Event_CallMenu(typeof(XQEvent), args);
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