using System;
using System.Text.RegularExpressions;
using Native.XQ.SDK;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;

namespace Native.XQ.Core.Events
{
    public class Event_GroupMessage : IXQGroupMessage
    {
        public void GroupMessage(object sender, XQAppGroupMsgEventArgs e)
        {

                //if (e.Message.Content == "测试群消息事件")
                //{
                //    e.FromGroup.SendMessage(e.RobotQQ, "测试成功\n-Native.XQ.Net");
                //}
                //if (e.Message.Content.StartsWith("测试禁言"))
                //{
                //    XQApi.Api_OutPutLog("禁言测试:at"+ e.Message.Content.Substring(4).Trim('[','@',']'));
                //    //e.FromGroup.SendMessage(e.RobotQQ, "测试成功\n-Native.XQ.Net");
                //    long qq;
                //    if (long.TryParse(e.Message.Content.Substring(4).TrimStart('[', '@').TrimEnd(']'), out qq))//用来判断是否是qq号
                //    {
                //        e.FromGroup.ShutUpMember(e.RobotQQ, qq.ToString(), 60);
                //    }
                //    else
                //    {
                //    }
                //}

        }

    }
}