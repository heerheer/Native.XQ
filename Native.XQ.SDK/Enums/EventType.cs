namespace Native.XQ.SDK.Enums
{
    public enum XQEventType
    {
        None = -1,
        OnlineTmp = 0,
        /// <summary>
        /// 好友私聊消息
        /// </summary>
        Friend = 1,
        /// <summary>
        /// 群消息
        /// </summary>
        Group = 2,
        /// <summary>
        /// 来自群的临时消息
        /// </summary>
        GroupTmp = 4,
        /// <summary>
        /// 来自好友验证的对话消息
        /// </summary>
        AddFriendReply = 7,

        /// <summary>
        /// 收到财付通转账
        /// </summary>
        Money = 6,

        /// <summary>
        /// 某人请求加为好友
        /// </summary>
        AddFriend = 101,

        /// <summary>
        /// 某人申请入群
        /// </summary>
        AddGroup = 213,
        /// <summary>
        /// 机器人被邀请入群
        /// </summary>
        InvitedToGroup = 214,
        /// <summary>
        /// 被拒绝入群
        /// </summary>
        BeRefusedGroup=221,

        /// <summary>
        /// 某人离开了群聊
        /// </summary>
        LeaveGroup = 201,

        /// <summary>
        /// 插件被启用
        /// </summary>
        PluginEnable = 12001,
        PluginClicked = 12003,

            
    }
}