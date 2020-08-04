using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Models;

namespace Native.XQ.SDK.Event.EventArgs
{
    public class XQAppGroupMsgEventArgs : XQEventArgs
    {
        public XQAppGroupMsgEventArgs()
        {
        }

        public XQAppGroupMsgEventArgs(string robotQQ,int eventtype,int extratype ,string fromGroup , string msg, string index, string id)
        {
            RobotQQ = robotQQ;
            EventType = eventtype;
            ExtraType = extratype;
            FromGroup = new XQGroup(fromGroup);
            Message = new XQMessage() { Content=msg,MsdId=id,MsgIndex=index};
        }

        /// <summary>
        /// 来自群
        /// </summary>
        public XQGroup FromGroup { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public XQMessage Message { get; set; }

    }
}
