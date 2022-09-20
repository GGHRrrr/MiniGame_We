using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//事件中心单例模式对象
public class EventManager : BaseManager<EventManager>
{
    //key = 事件的名字，value = 监听这个事件对应的委托函数
    private Dictionary<string , UnityAction<object>> events = new Dictionary<string,UnityAction<object>>();


    //添加事件监听
    public void AddEventListener(string name,UnityAction<object> action)
    {
        //有无对应事件监听
        if (events.ContainsKey(name))
        {
            events[name] += action;
        }
        else
        {
            events.Add(name, action);
        }
    }

    //在游戏对象销毁时调用
    public void RemoveEventListener(string name,UnityAction<object> action)
    {
        if (events.ContainsKey(name))
        {
            events[name] -= action;
        }
    }

    //清空事件中心，用于场景切换
    public void Clear()
    {
        events.Clear();
    }

    //事件触发
    public void EventTrigger(string name,object info)
    {
        //有无对应事件监听
        if (events.ContainsKey(name))
        {
            events[name]?.Invoke(info);
        }
    }
}
