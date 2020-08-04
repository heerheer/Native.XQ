using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Models;

namespace Native.XQ.SDK.Event.EventArgs
{
    public class XQAppPrivateMsgEventArgs : XQEventArgs
    {
        public XQAppPrivateMsgEventArgs()
        {
        }

        public XQAppPrivateMsgEventArgs(string robotQQ,int eventtype,int extratype ,string fromqq, string msg,string index,string id)
        {
            RobotQQ = robotQQ;
            EventType = eventtype;
            ExtraType = extratype;
            FromQQ = new XQQQ(fromqq);
            Message = new XQMessage() { Content = msg, MsdId = id, MsgIndex = index };
        }

        /// <summary>
        /// 来自群
        /// </summary>
        public XQQQ FromQQ { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public XQMessage Message { get; set; }

    }
}
