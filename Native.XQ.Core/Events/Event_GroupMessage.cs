using System.Threading.Tasks;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;

namespace Native.XQ.Core.Events
{
    public class Event_GroupMessage : IXQGroupMessage
    {
        public static bool isOn = false;

        public void GroupMessage(object sender, XQAppGroupMsgEventArgs e)
        {
            if (e.Message.Text == "苏醒吧，冰箱的主人！")
            {
                e.FromGroup.SendMessage(e.RobotQQ, "咕噜咕噜...");
                isOn = true;
            }

            if (e.Message.Text == "苏醒吧，冰霜的主人!")
            {
                if (isOn)
                {
                    e.FromGroup.ShutUpMember(e.RobotQQ, e.FromQQ.Id, 60);
                    e.FromGroup.SendMessage(e.RobotQQ, "...力量，请借我一用！");
                    Task.Factory.StartNew(async () =>
                    {
                        await Task.Delay(2000);
                        e.FromGroup.SendMessage(e.RobotQQ, "显现吧，白银之月！");
                        e.FromGroup.ShutUpAll(e.RobotQQ);
                        await Task.Delay(3000);
                        e.FromGroup.SendMessage(e.RobotQQ, "极寒风暴！");
                        e.FromGroup.UnShutUpAll(e.RobotQQ);
                        isOn = false;
                    });
                }
            }
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