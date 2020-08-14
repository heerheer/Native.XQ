using System;
using System.Runtime.InteropServices;
using System.Threading;
using Native.XQ.Sdk.Core;

namespace Native.XQ.SDK
{
    public static class XQDLL
    {
        #region 成员
        private const string DllName = "xqapi.dll";//官方APIDll
        #endregion


        static XQDLL()
        {
            
        }

        #region 消息相关API

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="group"></param>
        /// <param name="msg"></param>
        [DllImport(DllName, EntryPoint = "Api_SendMsgEX")]
        public static extern void Api_SendMsgEX(string robot, int type, string targetgroup, string targetqq, string content, int bubble, bool anyn);


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

        [DllImport(DllName, EntryPoint = "Api_GetGroupMemberList")]
        public static extern string Api_GetGroupMemberList(string robotQQ, string groupId);
        [DllImport(DllName, EntryPoint = "Api_GetGroupMemberList_B")]
        public static extern string Api_GetGroupMemberList_B(string robotQQ, string groupId);

        [DllImport(DllName, EntryPoint = "Api_HandleGroupEvent")]
        public static extern string Api_HandleGroupEvent(string robotQQ, int type,string targetqq ,string group,string seq,int ResponeType,string msg);
    }
}