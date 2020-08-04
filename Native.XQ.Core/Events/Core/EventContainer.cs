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
            CosturaUtility.Initialize();

            XQMain.Register(unityContainer);

            XQApi.Api_OutPutLog($"事件依赖注入...{unityContainer.Registrations.Count()}");

            XQEvent.Event_GroupMsgHandler += unityContainer.Resolve<IXQGroupMessage>().GroupMessage;
            XQEvent.Event_PrivateMsgHandler  += unityContainer.Resolve<IXQPrivateMessage>().PrivateMessage;
        }

    }
}
