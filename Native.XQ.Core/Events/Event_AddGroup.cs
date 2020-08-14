using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Enums;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;

namespace Native.XQ.Core.Events
{
    public class Event_AddGroup : IXQAddGroup
    {

        public void AddGroup(object sender, XQAddGroupEventArgs e)
        {
            if (e.EventType == (int)XQEventType.InvitedToGroup)
            {
                e.XQAPI.Info("机器人被", e.FromGroup, "邀请");
                e.Pass();

            }
        }
    }
}
