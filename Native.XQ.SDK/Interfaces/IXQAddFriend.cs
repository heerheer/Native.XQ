using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Event.EventArgs;

namespace Native.XQ.SDK.Interfaces
{
    /// <summary>
    /// 好友添加相关事件
    /// </summary>
    public interface IXQAddFriend
    {
        void AddFriend(object sender, XQAddFriendEventArgs e);
    }
}
