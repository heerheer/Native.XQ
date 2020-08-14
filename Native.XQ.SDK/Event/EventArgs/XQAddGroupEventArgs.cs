using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Event.EventArgs
{
    public class XQAddGroupEventArgs : XQEventArgs
    {
        public string Seq { get; set; }
        public string FromQQ { get; set; }
        public string FromGroup { get; set; }

        public XQAddGroupEventArgs(XQAPI api,string robotqq,int eventtype,string qq,string group,string seq) : base(api,robotqq,eventtype)
        {
            FromQQ = qq;
            FromGroup = group;
            Seq = seq;
        }

        public void Pass()
        {
            XQAPI.HanldeGroupEvent(this.RobotQQ, this.EventType, FromQQ, FromGroup, Seq, Enums.ResponseType.PASS);
        }
        public void Refuse()
        {
            XQAPI.HanldeGroupEvent(this.RobotQQ, this.EventType, FromQQ, FromGroup, Seq, Enums.ResponseType.REFUSE);
        }
        public void Ignore()
        {
            XQAPI.HanldeGroupEvent(this.RobotQQ, this.EventType, FromQQ, FromGroup, Seq, Enums.ResponseType.IGNORE);
        }
    }
}
