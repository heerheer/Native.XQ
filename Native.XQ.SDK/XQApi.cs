using System;
using System.Runtime.InteropServices;

namespace Native.XQ.SDK
{
    public static class XQApi
    {
        private const string DllName = "xqapi.dll";
        private const string NDllName = "Native.XQ.Lib.XQ.dll";

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="group"></param>
        /// <param name="msg"></param>
        [DllImport(NDllName, EntryPoint = "Native_SendGroupMsg")]
        public static extern void Native_SendGroupMsg(string robot, string group, string msg);

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="qq"></param>
        /// <param name="msg"></param>
        [DllImport(NDllName, EntryPoint = "Native_SendPrivateMsg")]
        public static extern void Native_SendPrivateMsg(string robot, string qq, string msg);

        [DllImport(DllName, EntryPoint = "Api_OutPutLog")]
        public static extern void Api_OutPutLog(string content);

        [DllImport(DllName, EntryPoint = "Api_WithdrawMsg")]
        public static extern void Api_WithdrawMsg(string rqq, string group, string index, string id);

        [DllImport(DllName, EntryPoint = "Api_IsEnable")]
        public static extern bool Api_IsEnable();

        [DllImport(DllName, EntryPoint = "Api_SendMsgEX", SetLastError = true, CallingConvention = CallingConvention.ThisCall)]
        public static extern void Api_SendMsgStr(string rqq, int msgtype, string group, string qq, string msg, int bubbleid, bool hide = false);

        [DllImport("msgsender.dll", EntryPoint = "Api_SendGroupMsg")]
        public static extern void Api_SendGroupMsg(string a, string b, string c);
    }
}