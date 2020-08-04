using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Models
{
    public class XQGroup
    {
        public XQGroup(string groupid)
        {
            GroupId = groupid;
        }
        public string GroupId { get; set; }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robotQQ">收到消息的机器人</param>
        /// <param name="msg"></param>
        public void SendMessage(string robotQQ,string msg)
        {
            XQApi.Native_SendGroupMsg(robotQQ, GroupId, msg);
        }
    }
}
