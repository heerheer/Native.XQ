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
    public class Event_AddFriend : IXQAddFriend
    {
        public void AddFriend(object sender, XQAddFriendEventArgs e)
        {
            e.XQAPI.Log("来了来了");
            e.Pass();//直接通过

            Task.Factory.StartNew(async()=> {
                await Task.Delay(5000);
            e.FromQQ.SendMessage(e.RobotQQ,"测试成功！你可以选择删除好友。");
            
            });

        }

    }
}
