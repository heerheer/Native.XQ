using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.Core.Events;
using Native.XQ.SDK.Interfaces;
using Unity;

namespace Native.XQ.Core
{
    public class XQMain
    {
        public static string AppDirectory { get; set; }

        public static void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IXQGroupMessage, Event_GroupMessage>();
        }
    }
}
