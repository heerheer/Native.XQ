using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Event.EventArgs
{
    public class XQAddFriendEventArgs : XQEventArgs
    {

        public string FromQQ { get; set; }
        public XQAddFriendEventArgs(XQAPI xQAPI, string robotQQ, int eventType,string qq) : base(xQAPI, robotQQ, eventType)
        {
            FromQQ = qq;
        }
    }
}
