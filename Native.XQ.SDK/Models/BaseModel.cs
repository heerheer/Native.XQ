using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Models
{
    public abstract class BaseModel
    {
        /// <summary>
        /// 自带的XQAPI对象
        /// </summary>
        public XQAPI XQAPI { get; private  set; }

        public BaseModel(XQAPI api)
        {
            XQAPI = api;
        }
    }
}
