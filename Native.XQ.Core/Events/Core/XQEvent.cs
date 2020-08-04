using System;
using System.IO;
using System.Runtime.InteropServices;
using Native.XQ.SDK.Enums;
using Native.XQ.SDK.Event;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;
using Native.XQ.SDK;
using Unity;
using Newtonsoft.Json;

namespace Native.XQ.Core.Events.Core
{
    public static class XQEvent
    {
        public static event EventHandler<XQAppGroupMsgEventArgs> Event_GroupMsgHandler;

        static XQEvent()
        {
            //CosturaUtility.Initialize();
        }

        //public static int XQ_Event(string robotQQ,int EventType,int ExtraType, string From, IntPtr FromQQ, IntPtr targetQQ, IntPtr content, IntPtr index, IntPtr id, IntPtr udpmsg, IntPtr unix,int p)

        [DllExport(ExportName = "XQ_Event", CallingConvention = CallingConvention.StdCall)]
        public static int XQ_Event(string robotQQ, int EventType, int ExtraType, string From, string FromQQ, string targetQQ, string content, string index, string id, string udpmsg, string unix, int p)
        {
            XQApi.Api_OutPutLog($"来自:{From}的消息,Type{EventType}被我捉到啦!");
            if (EventType == (int)XQEventType.Group)
            {
                if (Event_GroupMsgHandler != null)
                {
                    XQAppGroupMsgEventArgs args = new XQAppGroupMsgEventArgs(robotQQ,(int)EventType,(int)ExtraType,From,content);
                    Event_GroupMsgHandler(typeof(XQEvent), args);
                }
                

                if (From == "894727248")
                {
                    if (content == "测试XQ框架")
                    {
                        //XQApi.Api_OutPutLog($"恶臭测试");
                        XQApi.Native_SendGroupMsg(robotQQ, From, "恶臭测试-Native.XQ.Net");
                    }
                    if (content.StartsWith("复读机"))
                    {
                        XQApi.Native_SendGroupMsg(robotQQ, From, $"{content.Substring(3).Trim()}\n-Native.XQ.Net");
                    }
                }
            }
            if (EventType == (int)XQEventType.Friend)
            {
                XQApi.Api_OutPutLog($"h测试的状态{XQApi.Api_IsEnable()}");
                var botqq = Marshal.StringToHGlobalAnsi(robotQQ);
                var group = Marshal.StringToHGlobalAnsi(From);
                var target = Marshal.StringToHGlobalAnsi(FromQQ);
                var msg = Marshal.StringToHGlobalAnsi("恶臭测试-Native.XQ.Net");

                XQApi.Api_SendMsgIntPtr(botqq, 1, group, target, msg, 0);

                //XQApi.Api_SendMsg(Marshal.PtrToStringAnsi(robotQQ), EventType,"",Marshal.PtrToStringAnsi(From),Marshal.StringToHGlobalAnsi(strMsg), 0);
            }
            return 1;
        }

        [DllExport(ExportName = "XQ_Create", CallingConvention = CallingConvention.StdCall)]
        public static string XQ_Create(string frameworkVersion)
        {
            var AppName = "h测试";
            var AppVersion = "1.1.0";
            var AppAuthor = "赫尔";
            var AppDescription = "测试用XQ插件";
            int SDKVersion = 1;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Config"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Config");
            }
            XQMain.AppDirectory = Directory.GetCurrentDirectory() + "\\Config\\" + AppName;
            if (!Directory.Exists(XQMain.AppDirectory))
            {
                Directory.CreateDirectory(XQMain.AppDirectory);
            }
            if (File.Exists(XQMain.AppDirectory + "log.ini"))
            {
                File.WriteAllText(XQMain.AppDirectory + "log.ini", AppInfo(AppName, AppVersion, SDKVersion, AppAuthor, AppDescription));
            }

            EventContainer.Init();

            return AppInfo(AppName, AppVersion, SDKVersion, AppAuthor, AppDescription);
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

        public static string AppInfo(string appName, string appVersion, int sdkVersion, string appAuthor, string appDescription)
        {
            return JsonConvert.SerializeObject(new XQAppInfo()
            {
                name = appName,
                pver = appVersion,
                author = appAuthor,
                sver = sdkVersion,
                desc = appDescription
            });
        }

        public static void Register()
        {
            
        }
    }

    public class XQAppInfo
    {
        public string name { get; set; }
        public string pver { get; set; }
        public string author { get; set; }
        public string desc { get; set; }
        public int sver { get; set; }
    }
}