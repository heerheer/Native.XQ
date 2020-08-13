using System.IO;
using System.Threading.Tasks;
using Native.XQ.SDK.Core;

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

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robotqq">机器人QQ</param>
        /// <param name="group">对象QQ群</param>
        /// <param name="msg">消息内容</param>
        public void SendGroupMessage(string robotqq, string group, string msg)
        {
            Task.Factory.StartNew(
                () =>
                {
                    XQDLL.Api_SendMsgEX(robotqq, 2, group, "", msg, 0, false);
                });
        }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="robotqq">机器人QQ</param>
        /// <param name="qq">对象QQ</param>
        /// <param name="msg">消息内容</param>
        public void SendPrivateMessage(string robotqq, string qq, string msg)
        {
            Task.Factory.StartNew(
                () =>
                {
        XQDLL.Api_SendMsgEX(robotqq, 1, "", qq, msg, 0, false);
                });
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
    }
}