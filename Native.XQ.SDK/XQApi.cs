using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Native.XQ.SDK.Core;
using Native.XQ.SDK.Enums;
using Native.XQ.SDK.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Native.XQ.SDK
{
    public class XQAPI
    {
        public XQAppInfo AppInfo { get; set; }

        public string AppDirectory
        {
            get
            {
                return Directory.GetCurrentDirectory() + "\\Config\\" + AppInfo.name + "\\";
            }
        }

        #region 框架

        /// <summary>
        /// 取框架所有QQ号
        /// </summary>
        public IEnumerable<XQQQ> GetQQList()
        {
            var str = XQDLL.Api_GetQQList();

            return str.Split(Environment.NewLine.ToCharArray()).ToList().FindAll(s => s != "").Select(s => new XQQQ(s, this));
        }

        #endregion

        #region 日志相关

        /// <summary>
        /// 输出一条日志
        /// </summary>
        /// <param name="msg"></param>
        public void Log(string msg)
        {
            XQDLL.Api_OutPutLog(msg);
        }

        /// <summary>
        /// [Info]日志
        /// </summary>
        /// <param name="contents"></param>
        public void Info(params object[] contents)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Info]");
            foreach (var item in contents)
            {
                if (item == null)
                {
                    sb.Append("");
                }
                else
                {
                    sb.Append(item);
                }
            }
            Log(sb.ToString());
        }

        /// <summary>
        /// [Error]日志
        /// </summary>
        /// <param name="contents"></param>
        public void Error(params object[] contents)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Error]");
            foreach (var item in contents)
            {
                if (item == null)
                {
                    sb.Append("");
                }
                else
                {
                    sb.Append(item);
                }
            }
            Log(sb.ToString());
        }

        #endregion 日志相关

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robotqq">机器人QQ</param>
        /// <param name="group">对象QQ群</param>
        /// <param name="msg">消息内容</param>
        public void SendGroupMessage(string robotqq, string group, string msg)
        {
            if (XQDLL.Api_IsEnable() == false)
            {
                if (HLib.HLibExist())
                {
                    HLib.SendMsgEx(robotqq, 2, group, "", msg, 0, false);
                    return;
                }
            }
            XQDLL.Api_SendMsgEX(robotqq, 2, group, "", msg, 0, false);
        }

        /// <summary>
        /// 禁言群内成员
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="id"></param>
        /// <param name="targetQQ"></param>
        /// <param name="seconds"></param>
        public void ShutUpMember(string robotQQ, string group, string targetQQ, int seconds)
        {
            XQDLL.Api_ShutUP(robotQQ, group, targetQQ, seconds);
        }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="robotqq">机器人QQ</param>
        /// <param name="qq">对象QQ</param>
        /// <param name="msg">消息内容</param>
        public void SendPrivateMessage(string robotqq, string qq, string msg)
        {
            if (XQDLL.Api_IsEnable() == false)
            {
                if (HLib.HLibExist())
                {
                    HLib.SendMsgEx(robotqq, 1, "", qq, msg, 0, false);
                    return;
                }
            }
            XQDLL.Api_SendMsgEX(robotqq, 1, "", qq, msg, 0, false);
        }

        /// <summary>
        /// 踢出群员
        /// </summary>
        /// <param name="robotQQ">响应机器人QQ</param>
        /// <param name="targetQQ">目标qq</param>
        /// <param name="blacklist">是否加入黑名单</param>
        public void KickGroupMember(string robotQQ, string group, string targetQQ, bool blacklist = false)
        {
            XQDLL.Api_KickGroupMBR(robotQQ, group, targetQQ, blacklist);
        }

        /// <summary>
        /// 处理群申请
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="type"></param>
        /// <param name="qq"></param>
        /// <param name="group"></param>
        /// <param name="seq"></param>
        /// <param name="rtype"></param>
        /// <param name="msg"></param>
        public void HanldeGroupEvent(string robotQQ, int type, string qq, string group, string seq, ResponseType rtype, string msg = "")
        {
            XQDLL.Api_HandleGroupEvent(robotQQ, type, qq, group, seq, (int)rtype, msg);
        }

        /// <summary>
        /// 处理好友申请
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="qq"></param>
        /// <param name="rtype"></param>
        /// <param name="msg"></param>
        public void HanldeFriendEvent(string robotQQ, string qq, ResponseType rtype, string msg = "")
        {
            XQDLL.Api_HandleFriendEvent(robotQQ, qq, (int)rtype, msg);
        }

        /// <summary>
        /// 获取群成员列表(XQGroup)
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public IEnumerable<XQGroup> GetGroupList_B(string robotQQ)
        {
            var str = XQDLL.Api_GetGroupList_B(robotQQ);
            if (str == "" || str == null)
            {
                return null;
            }
            return str.Split(Environment.NewLine.ToCharArray()).ToList().FindAll(s => s != "").Select(s => new XQGroup(s, this));
        }

        /// <summary>
        /// 依据本地路径生成图片码
        /// </summary>
        /// <param name="path"></param>
        /// <param name="relativeToAppDir">如果为真，那么就会变成 dir + path 即填写的路径只是在Appdir下面的路径</param>
        /// <returns></returns>
        public string Code_Image(string path, bool relativeToAppDir)
        {
            var imgpath = path;
            if (relativeToAppDir)
                imgpath = Path.Combine(this.AppDirectory, path);
            return $"[pic={imgpath}]";
        }


        /// <summary>
        /// 获取群名
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static string GetGroupName(string robotQQ,string groupId)
        {
            return XQDLL.Api_GetGroupName(robotQQ, groupId);
        }

        /// <summary>
        /// 获取群名
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static string GetQQNick(string robotQQ, string qq)
        {
            return XQDLL.Api_GetNick(robotQQ, qq);
        }

        /// <summary>
        /// 取对象QQ等级 成功返回等级  失败返回-1
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static int GetQQLevel(string robotQQ,string qq)
        {
            return XQDLL.Api_GetObjLevel(robotQQ, qq);
        }

        /// <summary>
        /// 取Q龄 成功返回Q龄 失败返回-1
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static int GetQQAge(string robotQQ, string qq)
        {
            return XQDLL.Api_GetQQAge(robotQQ, qq);
        }


        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public static IEnumerator<FriendInfo> GetFriendList(string robotQQ)
        {
            var str =  XQDLL.Api_GetFriendList(robotQQ);

            JObject json = JsonConvert.DeserializeObject<JObject>(str);
            if (json["errcode"].ToString() == "0" && json["ec"].ToString() == "0")
            {
                var resultj = json["result"];
                resultj = resultj["0"];
                foreach (var item in resultj["mems"])
                {
                    yield return new FriendInfo(item["name"].ToString(), long.Parse(item["uin"].ToString()));
                }
            }
        }

        /// <summary>
        /// 获取群成员列表(GroupInfo)
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public static IEnumerator<GroupInfo> GetGroupList(string robotQQ)
        {
            var str = XQDLL.Api_GetGroupList(robotQQ);
            JObject json = JsonConvert.DeserializeObject<JObject>(str);
            if (json["errcode"].ToString() == "0" && json["ec"].ToString() == "0")
            {
                var resultj = json["join"];
                foreach (var item in resultj)
                {
                    yield return new GroupInfo(item["gc"].ToString()) { Name=item["gn"].ToString() ,Owner= item["owner"].ToString() };
                }
            }

        }

        /// <summary>
        /// 获取指定群的群成员列表
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static IEnumerator<MemberInfo> GetGroupMemberInfo(string robotQQ,string group)
        {
            var str = XQDLL.Api_GetGroupMemberList_C(robotQQ,group);
            JObject json = JsonConvert.DeserializeObject<JObject>(str);
            if (json.ContainsKey("list"))
            {
                foreach (var item in json["list"])
                {
                    yield return new MemberInfo(group, robotQQ) { Id=item["QQ"].ToString(),Level=int.Parse( item["lv"].ToString()) };
                }
            }
        }
    }
}