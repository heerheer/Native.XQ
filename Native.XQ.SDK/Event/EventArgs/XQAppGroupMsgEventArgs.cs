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

        public XQAppGroupMsgEventArgs(string robotQQ,int eventtype,int extratype ,string fromGroup, string content)
        {
            RobotQQ = robotQQ;
            EventType = eventtype;
            ExtraType = extratype;
            FromGroup = new XQGroup() { GroupId=fromGroup};
            Content = content;
        }

        /// <summary>
        /// 来自群
        /// </summary>
        public XQGroup FromGroup { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Content { get; set; }

    }
}
