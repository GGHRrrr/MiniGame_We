using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 挂载位置：玩家角色
    作用：此脚本用来控制 机器人yiyi的跟随效果实现，以及切换功能实现。
 */
public class SwitchRole : MonoBehaviour
{
    //记录是yiyi是否跟随状态
    private bool isFollow;
    //yiyi组件
    private Transform yiyi;
    //yiyi在默认状态下的相对位置
    private Vector3 pos;

    //切换状态时需要做的事
    public bool IsFollow
    {
        get { return isFollow; }
        set
        {
            isFollow = value;
            if (isFollow)
            {
                //当切换回默认状态时，yiyi作为主角的子物体随之移动与转向
                transform.GetComponent<PlayerMove>().ToFollowPoint(true);
                yiyi.GetComponent<YiyiMove>().SwitchMove(false);
            }
            else
            {
                //当切换为yiyi状态时，可独立控制yiyi进行移动与飞行
                
                pos = yiyi.position;
                yiyi.GetComponent<YiyiMove>().SwitchMove(true);
            }
        }
    }

    private void Start()
    {
        yiyi = transform.parent.Find("yiyi");//拿到yiyi游戏对象
        pos = yiyi.localPosition;
        isFollow = true;
        //添加切换状态事件
        EventManager.Instance().AddEventListener("KeyDown", SwitchRoleFunc);

    }

    private void SwitchRoleFunc(object key)
    {
        KeyCode keyCode = (KeyCode)key;
        if (keyCode == KeyCode.Tab)
        {
            IsFollow = !IsFollow;
        }
    }
}
