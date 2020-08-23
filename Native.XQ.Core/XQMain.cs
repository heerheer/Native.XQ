using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.Core.Events;
using Native.XQ.SDK.Core;
using Native.XQ.SDK.Interfaces;
using Unity;

namespace Native.XQ.Core
{
    /// <summary>
    /// 最重要的Jie哥类
    /// </summary>
    public class XQMain
    {
        public static string AppDirectory { get; set; }

        public static string CSSDKVersion { get; set; } = "20200823";


        /// <summary>
        /// 请在这里修改信息
        /// </summary>
        /// <returns></returns>
        public static XQAppInfo AppInfo()
        {
            return new XQAppInfo()
            {
                name = "ExampleAPP",//请同步更改Core的程序集名为 %name%.XQ
                pver = "1.0.0",//应用版本
                author = "ExampleAuthor",//应用作者
                desc = "A Example App",//插件描述
                sver = 1//SDK版本，请勿随意修改

            };
        }

       
        /// <summary>
        /// 进行依赖注入
        /// </summary>
        /// <param name="unityContainer"></param>
        public static void Register(IUnityContainer unityContainer)
        {
            //注入方式为 unityContainer.RegisterType<接口, 继承接口的类>();
            unityContainer.RegisterType<IXQGroupMessage, Event_GroupMessage>();
            unityContainer.RegisterType<IXQPrivateMessage, Event_PrivateMessage>();
        }
    }

}
