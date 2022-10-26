using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneData
{
    public List<PhoneMessageWindow> users = new List<PhoneMessageWindow>();     //�û��б�
    public List<PhoneLogs> logs = new List<PhoneLogs>();
    public Dictionary<string, PhoneMessageWindow> userDic = new Dictionary<string, PhoneMessageWindow>();
    public Dictionary<int, PhoneLogs> logDic = new Dictionary<int, PhoneLogs>();
}

public class PhoneMessageWindow
{
    public string name;                 //�Է��û���
    public List<PhoneMessageBlock> messageBlocks = new List<PhoneMessageBlock>(); //��Ϣ�б�
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
    public string messagesContext;         //��Ϣ����
    public MessageType messageType; //��Ϣ����
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