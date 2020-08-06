using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;
using Native.XQ.SDK.Models;

namespace Native.XQ.Core.Events
{
    public class Event_PrivateMessage : IXQPrivateMessage
    {
        public void PrivateMessage(object sender, XQAppPrivateMsgEventArgs e)
        {
            if (e.Message.Content.ToLower().Equals("Jie2GG".ToLower()))
            {
                e.FromQQ.SendMessage(e.RobotQQ, "永远滴神");
                
            }
            if (e.Message.Content == "LetMeSeeGroups")
            {
                e.FromQQ.SendMessage(e.RobotQQ, string.Join(",", new XQRobot() { RobotQQ = e.RobotQQ }.GetGroupList().Select(s => s.GroupId)));
            }
        }
    }
}
