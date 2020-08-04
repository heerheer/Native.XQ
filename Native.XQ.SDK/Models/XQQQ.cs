using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Models
{
    /// <summary>
    /// 对QQ的实体类
    /// </summary>
    public class XQQQ
    {

        public XQQQ(string qq)
        {
            this.QQId = qq;
        }

        /// <summary>
        /// QQ号
        /// </summary>
        public string QQId { get; set; }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robotQQ">操作QQ</param>
        /// <param name="msg">消息</param>
        public void SendMessage(string robotQQ, string msg)
        {
            XQApi.Native_SendGroupMsg(robotQQ, QQId, msg);
        }
    }
}
