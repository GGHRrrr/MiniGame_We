using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneData
{
    public List<PhoneWindow> users;     //�û��б�
}

public class PhoneWindow
{
    public string name;                 //�Է��û���
    public List<PhoneMessage> messages; //��Ϣ�б�
}

public class PhoneMessage
{
    public int id;          //ID
    public bool isReceive;  //���ջ��Ƿ���
    public string message;  //��Ϣ����
    public int time;        //��Ϣʱ��
}