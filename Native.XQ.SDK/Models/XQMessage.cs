﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Models
{
    /// <summary>
    /// 收到的消息Message
    /// </summary>
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

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 消息序列
        /// </summary>
        public string MsgIndex { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsdId { get; set; }

        /// <summary>
        /// 撤回此消息
        /// </summary>
        /// <param name="robotQQ">操作QQ</param>
        /// <param name="groupid">群号</param>
        public void Withdraw(string robotQQ,string groupid)
        {
            XQApi.Api_WithdrawMsg(robotQQ, groupid, MsgIndex, MsdId);
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="group">XQGroup实体</param>
        public void Withdraw(string robotQQ, XQGroup group)
        {
            XQApi.Api_WithdrawMsg(robotQQ, group.GroupId, MsgIndex, MsdId);
        }
    }
}
