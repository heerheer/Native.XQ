using System;
using System.Runtime.InteropServices;

namespace Native.XQ.Core
{
    internal static class XQApi
    {
        private const string DllName = "xqapi.dll";
        private const string NDllName = "Native.XQ.Lib.XQ.dll";

        [DllImport(NDllName, EntryPoint = "Native_SendGroupMsg")]
        public static extern void Native_SendGroupMsg(string robot, string group, string msg);

        [DllImport(NDllName, EntryPoint = "Native_SendPrivateMsg")]
        public static extern void Native_SendPrivateMsg(string robot, string qq, string msg);

        [DllImport(DllName, EntryPoint = "Api_SendMsg")]
        public static extern void Api_SendMsg(string rqq, int msgtype, string group, string qq, string msg, int bubbleid = 0);

        [DllImport(DllName, EntryPoint = "Api_OutPutLog")]
        public static extern void Api_OutPutLog(string content);

        [DllImport(DllName, EntryPoint = "Api_WithdrawMsg")]
        public static extern void Api_WithdrawMsg(string rqq, string group, string index, string id);

        [DllImport(DllName, EntryPoint = "Api_SendMsgEX", CharSet = CharSet.Ansi)]
        public static extern void Api_SendMsg(string rqq, int msgtype, string group, string qq, IntPtr msg, int bubbleid, bool hide = false);

        [DllImport(DllName, EntryPoint = "Api_SendMsgEX")]
        public static extern void Api_SendMsgIntPtr(IntPtr rqq, int msgtype, IntPtr group, IntPtr qq, IntPtr msg, int bubbleid, bool hide = false);

        [DllImport(DllName, EntryPoint = "Api_IsEnable")]
        public static extern bool Api_IsEnable();

        [DllImport(DllName, EntryPoint = "Api_SendMsgEX", SetLastError = true, CallingConvention = CallingConvention.ThisCall)]
        public static extern void Api_SendMsgStr(string rqq, int msgtype, string group, string qq, string msg, int bubbleid, bool hide = false);

        [DllImport("msgsender.dll", EntryPoint = "Api_SendGroupMsg")]
        public static extern void Api_SendGroupMsg(string a, string b, string c);
    }
}