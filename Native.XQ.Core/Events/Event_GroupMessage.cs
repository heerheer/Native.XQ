using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;

namespace Native.XQ.Core.Events
{
    public class Event_GroupMessage : IXQGroupMessage
    {
        public void GroupMessage(object sender,XQAppGroupMsgEventArgs e)
        {
            if(e.Message.Content == "测试群消息事件")
            {
                e.FromGroup.SendMessage(e.RobotQQ,"测试成功\n-Native.XQ.Net");

            }
        }
    }
}
