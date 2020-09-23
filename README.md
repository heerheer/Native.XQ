# Native.XQ (暂停大型维护，等待先驱SDK升级)
> Jie2GG，永远的神

**新版先驱+新版SDK 请使用XQ.Net https://gitee.com/heerkaisair/XQ.Net**

为XQRobot编写的c#开发SDK

官方交流群 1056156417 赫尔的老窝了，别墅小岛呜呜呜

Native.XQ 是为了方便 .Net 平台开发者高效开发 先驱应用 的开发框架

封装先驱 提供的接口，提供了安全高效的Api，同时抽象了事件中的基础数据类型，并且提供了完整的托管异常处理，提供了优秀的开发环境。

## 重要
0818版本后，所有使用本SDK编译插件的用户都需要开启**不检测插件启用** 请开发者注意
若先驱还未提供 **不检测插件启用** 功能，请下载使用**HLib**作为消息发送API的前置插件 [先驱社区](https://discuss.xianqubot.com/d/27)

### 关于HLib
请前往社区查看 [先驱社区](https://discuss.xianqubot.com/d/27)

## 更新记录
**20200827** 
优化生成，现在output只会生成一个文件了！
增加了两个列表API

20200815 更新禁言 撤回 API和事件 修复Enable事件。

## 计划
- [X] Native.XQ.Tool.Ini 增加对INI文件的封装操作 
- [ ] Native.XQ.Tool.Sqlite 增加对SQLITE3的快速操作
- [ ] Native.XQ 增加更多事件
- [X] Native.XQ.SDK 增加获取群列表方法
- [X] Native.XQ.SDK 增加群成员列表方法
