using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    玩家状态管理器，继承单例模式，管理玩家的状态
 */
public enum E_Player_State
{ 
    //普通行走模式（仅存在水平移动）
    Common,
    //禁用基础按键模式（用于对话，背包状态下）
    Interaction,
    //yiyi的独立移动模式(控制yiyi上下左右)
    Yiyi,
    //玩家跑酷模式(在Common基础上开启跳跃，荡的功能)
    Runcool
}


public class PlayerManager : BaseManager<PlayerManager>
{
    //玩家状态变量
    public E_Player_State state;

    public PlayerManager()
    {
        //默认将状态设置为普通行走模式
        state = E_Player_State.Common;
    }

    //切换状态函数
    public void SwitchState(string stateStr)
    {
        switch (stateStr)
        {
            case "Common":
                state = E_Player_State.Common;
                break;
            case "Interaction":
                state = E_Player_State.Interaction;
                break;
            case "Yiyi":
                state = E_Player_State.Yiyi;
                break;
            case "Runcool":
                state = E_Player_State.Runcool;
                break;
        }
    }
}
