using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.XQ.SDK.Models
{
    /// <summary>
    /// 收到的消息Message
    /// </summary>
    public class XQMessage
    {
        public XQMessage()
        {
        }

        public XQMessage(string text, string msgIndex, string msdId, XQGroup fromGroup)
        {
            Text = text;
            MsgIndex = msgIndex;
            MsdId = msdId;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 消息序列
        /// </summary>
        public string MsgIndex { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsdId { get; set; }

        /// <summary>
        /// 撤回此消息
        /// </summary>
        /// <param name="robotQQ">操作QQ</param>
        /// <param name="groupid">群号</param>
        public void Withdraw(string robotQQ,string groupid)
        {
            XQDLL.Api_WithdrawMsg(robotQQ, groupid, MsgIndex, MsdId);
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="group">XQGroup实体</param>
        public void Withdraw(string robotQQ, XQGroup group)
        {
            XQDLL.Api_WithdrawMsg(robotQQ, group.Id, MsgIndex, MsdId);
        }

        /// <summary>
        /// 将消息内GUID表示的图片下载到指定路径下 并返回保存的路径
        /// </summary>
        /// <param name="robotQQ">机器人QQ</param>
        /// <param name="dir"></param>
        /// <param name="type">群2 好友1</param>
        /// <returns></returns>
        public IEnumerator<string> SaveImages(string robotQQ,string dir,int type,XQGroup group)
        {
            var matches = Regex.Matches(Text, @"\[pic=(.*?)\]");
            foreach (Match item in matches)
            {
                var url = XQDLL.Api_GetPicLink(robotQQ,type,group.Id,item.Value) ;
                new WebClient().DownloadFile(url, Path.Combine(dir, $"{item.Groups[0].Value}"));
                yield return Path.Combine(dir, $"{item.Groups[0].Value}");

            }

        }
    }
}
