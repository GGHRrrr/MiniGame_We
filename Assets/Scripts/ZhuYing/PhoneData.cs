using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneData
{
    public List<PhoneMessageWindow> users = new List<PhoneMessageWindow>();     //用户列表
    public List<PhoneLogs> logs = new List<PhoneLogs>();
    public Dictionary<string, PhoneMessageWindow> userDic = new Dictionary<string, PhoneMessageWindow>();
    public Dictionary<int, PhoneLogs> logDic = new Dictionary<int, PhoneLogs>();
}

public class PhoneMessageWindow
{
    public string name;                 //对方用户名
    public List<PhoneMessageBlock> messageBlocks = new List<PhoneMessageBlock>(); //消息列表
    public Dictionary<int, PhoneMessageBlock> messageBlocksDic = new Dictionary<int, PhoneMessageBlock>();
}

public class PhoneMessageBlock
{
    public List<PhoneMessage> messages = new List<PhoneMessage>();
    public int InterID;
    public bool hasIntered = false;
}

public class PhoneMessage
{
    public string messagesContext;         //消息内容
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
    public int interID;
    public bool hasIntered = false;

}