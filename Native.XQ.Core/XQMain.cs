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

    public class XQAppInfo
    {
        public string name { get; set; }
        public string pver { get; set; }
        public string author { get; set; }
        public string desc { get; set; }
        public int sver { get; set; }


        //请在这里改变应用的信息
        public static XQAppInfo AppInfo()
        {
            return new XQAppInfo()
            {
                name = "ExampleAPP",
                pver = "1.0.0",//应用版本
                author = "",//应用作者
                desc = "",//插件描述
                sver = 1//SDK版本，请勿随意修改

            };
        }
    }
    public class XQMain
    {
        public static string AppDirectory { get; set; }

        public static void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IXQGroupMessage, Event_GroupMessage>();
        }
    }

}
