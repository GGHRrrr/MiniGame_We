using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneData
{
    public List<PhoneMessageWindow> users;     //用户列表
    public List<PhoneLogs> logs;
}

public class PhoneMessageWindow
{
    public string name;                 //对方用户名
    public string updateTime;           //更新时间
    public List<PhoneMessage> messages; //消息列表
}

public class PhoneMessage
{
    public string messages;         //消息内容
    public MessageType messageType; //消息类型
}
public enum MessageType
{
    Time,
    Received,
    Send
}

public class PhoneLogs
{
    public string date;
    public string title;
    public string log;
}