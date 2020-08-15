using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Models;

namespace Native.XQ.SDK.Event.EventArgs
{
    public class XQBanSpeakEventArgs : XQEventArgs
    {
        /// <summary>
        /// 主动禁言的QQ
        /// </summary>
        public XQQQ FromQQ { get; set; }

        /// <summary>
        /// 被禁言的QQ
        /// </summary>
        public XQQQ TargetQQ { get; set; }

        /// <summary>
        /// 来自群
        /// </summary>
        public XQGroup FromGroup { get; set; }

        public XQBanSpeakEventArgs(XQAPI xqapi, string robotQQ, int eventType, string fromqq, string targetqq, string fromgroup) : base(xqapi, robotQQ, eventType)
        {
            FromQQ = new XQQQ(fromqq, xqapi);
            FromGroup = new XQGroup(fromgroup, xqapi);
            TargetQQ = new XQQQ(fromqq, xqapi);
        }
    }
}
