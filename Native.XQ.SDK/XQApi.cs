using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.XQ.SDK.Core;
using Native.XQ.SDK.Enums;

namespace Native.XQ.SDK
{
    public class XQAPI
    {
        public XQAppInfo AppInfo { get; set; }


        public string AppDirectory
        {
            get
            {
                return Directory.GetCurrentDirectory() + "\\Config\\" + AppInfo.name + "\\";
            }
        }

        #region 日志相关

        public void Log(string msg)
        {
            XQDLL.Api_OutPutLog(msg);
        }

        public void Info(params object[] contents)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Info]");
            foreach (var item in contents)
            {
                if (item == null)
                {
                    sb.Append("");
                }
                else
                {
                    sb.Append(item);
                }
            }
            XQDLL.Api_OutPutLog(sb.ToString());

        }

        #endregion



        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robotqq">机器人QQ</param>
        /// <param name="group">对象QQ群</param>
        /// <param name="msg">消息内容</param>
        public void SendGroupMessage(string robotqq, string group, string msg)
        {
                    XQDLL.Api_SendMsgEX(robotqq, 2, group, "", msg, 0, false);
        }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="robotqq">机器人QQ</param>
        /// <param name="qq">对象QQ</param>
        /// <param name="msg">消息内容</param>
        public void SendPrivateMessage(string robotqq, string qq, string msg)
        {

                XQDLL.Api_SendMsgEX(robotqq, 1, "", qq, msg, 0, false);
        }

        /// <summary>
        /// 踢出群员
        /// </summary>
        /// <param name="robotQQ">响应机器人QQ</param>
        /// <param name="targetQQ">目标qq</param>
        /// <param name="blacklist">是否加入黑名单</param>
        public void KickGroupMember(string robotQQ, string group, string targetQQ, bool blacklist = false)
        {
            XQDLL.Api_KickGroupMBR(robotQQ, group, targetQQ, blacklist);
        }


        public void HanldeGroupEvent(string robotQQ, int type, string qq, string group, string seq, ResponseType rtype, string msg = "")
        {
            XQDLL.Api_HandleGroupEvent(robotQQ,type,qq,group,seq,(int)rtype,msg);
        }
    }
}