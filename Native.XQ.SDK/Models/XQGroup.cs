using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Models
{
    public class XQGroup:BaseModel
    {
        public XQGroup(string groupid,XQAPI api) : base(api)
        {
            Id = groupid;
        }
        public string Id { get; set; }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robotQQ">收到消息的机器人</param>
        /// <param name="msg"></param>
        public void SendMessage(string robotQQ,string msg)
        {
            XQAPI.SendGroupMessage(robotQQ, this.Id, msg);
        }

        /// <summary>
        /// 踢出群员
        /// </summary>
        /// <param name="robotQQ">响应机器人QQ</param>
        /// <param name="targetQQ">目标qq</param>
        /// <param name="blacklist">是否加入黑名单</param>
        public void KickMember(string robotQQ, string targetQQ, bool blacklist = false)
        {
            XQAPI.KickGroupMember(robotQQ, Id, targetQQ,blacklist);
        }

        /// <summary>
        /// 禁言某个群员
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="targetQQ"></param>
        /// <param name="seconds"></param>
        public void ShutUpMember(string robotQQ, string targetQQ,int seconds)
        {
            XQDLL.Api_ShutUP(robotQQ, Id, targetQQ, seconds);
        }
    }
}
