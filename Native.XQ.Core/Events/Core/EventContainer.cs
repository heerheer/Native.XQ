using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK;
using Native.XQ.SDK.Interfaces;
using Unity;

namespace Native.XQ.Core.Events.Core
{
    public class EventContainer
    {
        public static Unity.UnityContainer unityContainer = new Unity.UnityContainer();

        public static void Init()
        {

            XQMain.Register(unityContainer);

            XQDLL.Api_OutPutLog($"事件依赖注入...{unityContainer.Registrations.Count()}");

            if(unityContainer.IsRegistered<IXQGroupMessage>())
                XQEvent.Event_GroupMsgHandler += unityContainer.Resolve<IXQGroupMessage>().GroupMessage;

            if(unityContainer.IsRegistered<IXQPrivateMessage>())
                XQEvent.Event_PrivateMsgHandler  += unityContainer.Resolve<IXQPrivateMessage>().PrivateMessage;

            if(unityContainer.IsRegistered<IXQAppEnable>())
                XQEvent.Event_AppEnableHandler  += unityContainer.Resolve<IXQAppEnable>().AppEnable;

            if(unityContainer.IsRegistered<IXQAppDisable>())
                XQEvent.Event_AppDisableHandler  += unityContainer.Resolve<IXQAppDisable>().AppDisable;

            if (unityContainer.IsRegistered<IXQAddGroup>())
                XQEvent.Event_AddGroupHandler += unityContainer.Resolve<IXQAddGroup>().AddGroup;

            if (unityContainer.IsRegistered<IXQAddFriend>())
                XQEvent.Event_AddFriendHandler += unityContainer.Resolve<IXQAddFriend>().AddFriend;

            if (unityContainer.IsRegistered<IXQCallMenu>())
                XQEvent.Event_CallMenu += unityContainer.Resolve<IXQCallMenu>().CallMenu;;
        }

    }
}
