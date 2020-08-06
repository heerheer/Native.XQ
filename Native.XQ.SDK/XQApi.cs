using System;
using System.Runtime.InteropServices;

namespace Native.XQ.SDK
{
    public static class XQApi
    {
        #region 成员
        private const string DllName = "xqapi.dll";//官方API
        private const string NDllName = "Native.XQ.Lib.XQ.dll";//易语言API桥
        #endregion

        #region 消息相关API

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

        /// <summary>
        /// 撤回指定消息
        /// </summary>
        /// <param name="rqq"></param>
        /// <param name="group"></param>
        /// <param name="index"></param>
        /// <param name="id"></param>
        [DllImport(DllName, EntryPoint = "Api_WithdrawMsg")]
        public static extern void Api_WithdrawMsg(string rqq, string group, string index, string id);
        #endregion 


        [DllImport(DllName, EntryPoint = "Api_OutPutLog")]
        public static extern void Api_OutPutLog(string content);


        [DllImport(DllName, EntryPoint = "Api_IsEnable")]
        public static extern bool Api_IsEnable();

        [DllImport(DllName, EntryPoint = "Api_ShutUP")]
        public static extern void Api_ShutUP(string robotQQ,string group,string qq,int seconds);

        [DllImport(DllName, EntryPoint = "Api_KickGroupMBR")]
        public static extern void Api_KickGroupMBR(string robotQQ, string group, string qq, bool balcklist);

        [DllImport(DllName, EntryPoint = "Api_GetGroupList_B")]
        public static extern string Api_GetGroupList_B(string robotQQ);
    }
}