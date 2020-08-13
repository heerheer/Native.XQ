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

        public XQAppGroupMsgEventArgs(string robotQQ,int eventtype,int extratype ,string fromGroup ,string fromQQ, string msg, string index, string id,XQAPI api):base(api)
        {
            RobotQQ = robotQQ;
            EventType = eventtype;
            ExtraType = extratype;
            FromQQ = new XQQQ(fromQQ,XQAPI);
            FromGroup = new XQGroup(fromGroup,XQAPI);
            Message = new XQMessage() { Text=msg,MsdId=id,MsgIndex=index};
        }

        /// <summary>
        /// 来自群
        /// </summary>
        public XQGroup FromGroup { get; set; }
        /// <summary>
        /// 来自QQ
        /// </summary>
        public XQQQ FromQQ { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public XQMessage Message { get; set; }

        

    }
}
