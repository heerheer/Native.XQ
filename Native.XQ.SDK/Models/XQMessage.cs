using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Models
{
    public class XQMessage
    {
        public XQMessage()
        {
        }

        public XQMessage(string content, string msgIndex, string msdId, XQGroup fromGroup)
        {
            Content = content;
            MsgIndex = msgIndex;
            MsdId = msdId;
        }

        public string Content { get; set; }

        public string MsgIndex { get; set; }

        public string MsdId { get; set; }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="groupid"></param>
        public void Withdraw(string robotQQ,string groupid)
        {
            XQApi.Api_WithdrawMsg(robotQQ, groupid, MsgIndex, MsdId);
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="group"></param>
        public void Withdraw(string robotQQ, XQGroup group)
        {
            XQApi.Api_WithdrawMsg(robotQQ, group.GroupId, MsgIndex, MsdId);
        }
    }
}
