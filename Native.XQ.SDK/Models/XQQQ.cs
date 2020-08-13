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
    public class XQQQ:BaseModel
    {

        public XQQQ(string qq,XQAPI api):base(api)
        {
            
            this.Id = qq;
            
        }

        /// <summary>
        /// QQ号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="robotQQ">操作QQ</param>
        /// <param name="msg">消息</param>
        public void SendMessage(string robotQQ, string msg)
        {
            XQAPI.SendPrivateMessage(robotQQ,this.Id, msg);
        }

    }
}
