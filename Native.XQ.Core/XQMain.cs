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
    /// <summary>
    /// 返回的AppInfo
    /// </summary>
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
                name = "ExampleAPP",//请同步更改Core的程序集名为 %name%.XQ
                pver = "1.0.0",//应用版本
                author = "ExampleAuthor",//应用作者
                desc = "A Example App",//插件描述
                sver = 1//SDK版本，请勿随意修改

            };
        }
    }
    /// <summary>
    /// 最重要的Jie哥类
    /// </summary>
    public class XQMain
    {
        public static string AppDirectory { get; set; }

        public static void Register(IUnityContainer unityContainer)
        {
            //Jie2GG,永远的神
            unityContainer.RegisterType<IXQGroupMessage, Event_GroupMessage>();
            unityContainer.RegisterType<IXQPrivateMessage, Event_PrivateMessage>();
        }
    }

}
