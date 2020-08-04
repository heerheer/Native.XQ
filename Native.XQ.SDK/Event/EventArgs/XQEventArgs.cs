using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Event.EventArgs
{
    public abstract class XQEventArgs
    {

        /// <summary>
        /// 收到事件的QQ
        /// </summary>
        public string RobotQQ { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        public int EventType { get; set; }

        /// <summary>
        /// 子类型
        /// </summary>
        public int ExtraType { get; set; }

        /// <summary>
        /// 是否处理并阻塞
        /// </summary>
        public bool Handler { get; set; } = false;//默认不阻塞

    }
}
