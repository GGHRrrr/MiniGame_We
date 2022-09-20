using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�¼����ĵ���ģʽ����
public class EventManager : BaseManager<EventManager>
{
    //key = �¼������֣�value = ��������¼���Ӧ��ί�к���
    private Dictionary<string , UnityAction<object>> events = new Dictionary<string,UnityAction<object>>();


    //����¼�����
    public void AddEventListener(string name,UnityAction<object> action)
    {
        //���޶�Ӧ�¼�����
        if (events.ContainsKey(name))
        {
            events[name] += action;
        }
        else
        {
            events.Add(name, action);
        }
    }

    //����Ϸ��������ʱ����
    public void RemoveEventListener(string name,UnityAction<object> action)
    {
        if (events.ContainsKey(name))
        {
            events[name] -= action;
        }
    }

    //����¼����ģ����ڳ����л�
    public void Clear()
    {
        events.Clear();
    }

    //�¼�����
    public void EventTrigger(string name,object info)
    {
        //���޶�Ӧ�¼�����
        if (events.ContainsKey(name))
        {
            events[name]?.Invoke(info);
        }
    }
}
