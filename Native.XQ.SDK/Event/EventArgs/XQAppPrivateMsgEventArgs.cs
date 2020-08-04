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

        public XQAppPrivateMsgEventArgs(string robotQQ,int eventtype,int extratype ,string fromqq, string content)
        {
            RobotQQ = robotQQ;
            EventType = eventtype;
            ExtraType = extratype;
            FromQQ = new XQQQ() { QQId=fromqq};
            Content = content;
        }

        /// <summary>
        /// 来自群
        /// </summary>
        public XQQQ FromQQ { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Content { get; set; }

    }
}
