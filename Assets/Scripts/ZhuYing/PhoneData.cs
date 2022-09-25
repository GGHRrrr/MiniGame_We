using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneData
{
    public List<PhoneWindow> users;     //用户列表
}

public class PhoneWindow
{
    public string name;                 //对方用户名
    public List<PhoneMessage> messages; //消息列表
}

public class PhoneMessage
{
    public int id;          //ID
    public bool isReceive;  //接收还是发送
    public string message;  //消息内容
    public int time;        //消息时间
}