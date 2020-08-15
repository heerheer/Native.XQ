using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Models;

namespace Native.XQ.SDK.Event.EventArgs
{
    public class XQAddFriendEventArgs : XQEventArgs
    {

        public XQQQ FromQQ { get; set; }

        public XQAddFriendEventArgs(XQAPI xQAPI, string robotQQ, int eventType,string qq) : base(xQAPI, robotQQ, eventType)
        {
            FromQQ = new XQQQ(qq,XQAPI);
        }

        public void Pass()
        {
            XQAPI.HanldeFriendEvent(this.RobotQQ, FromQQ.Id, Enums.ResponseType.PASS);
        }
        public void Refuse()
        {
            XQAPI.HanldeFriendEvent(this.RobotQQ, FromQQ.Id, Enums.ResponseType.REFUSE);

        }
        public void Ignore()
        {
            XQAPI.HanldeFriendEvent(this.RobotQQ, FromQQ.Id, Enums.ResponseType.IGNORE);

        }
    }
}
