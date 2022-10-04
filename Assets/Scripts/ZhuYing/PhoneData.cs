using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneData
{
    public List<PhoneMessageWindow> users;     //�û��б�
    public List<PhoneLogs> logs;
}

public class PhoneMessageWindow
{
    public string name;                 //�Է��û���
    public string updateTime;           //����ʱ��
    public List<PhoneMessage> messages; //��Ϣ�б�
}

public class PhoneMessage
{
    public string messages;         //��Ϣ����
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
}