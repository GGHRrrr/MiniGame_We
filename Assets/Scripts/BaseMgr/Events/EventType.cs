using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventTypeEnum
{
    TALKWITH_YIYI,//yiyi对话
    TALKWITH_PLAYER,//玩家对话
    USEITEMS_YILAGUAN,//使用易拉罐
    USEITEM_SHENGZI,//使用绳子
    KeyDown_Tab,      //Tab按键
    Unlock_Circuit, //电路全部解锁
    Anima_Fade,//渐变动画
    INTER_LOG,//更新日志
    INTER_MESSAGE//更新消息
}
