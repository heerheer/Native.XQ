﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Event.EventArgs;

namespace Native.XQ.SDK.Interfaces
{
    /// <summary>
    /// 插件被关闭
    /// </summary>
    public interface IXQAppDisable
    {
        /// <summary>
        /// 主入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AppDisable(object sender, XQEventArgs e);
    }
}
