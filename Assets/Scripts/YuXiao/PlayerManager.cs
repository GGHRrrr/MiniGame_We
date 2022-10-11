using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    ���״̬���������̳е���ģʽ��������ҵ�״̬
 */
public enum E_Player_State
{ 
    //��ͨ����ģʽ��������ˮƽ�ƶ���
    Common,
    //���û�������ģʽ�����ڶԻ�������״̬�£�
    Interaction,
    //yiyi�Ķ����ƶ�ģʽ(����yiyi��������)
    Yiyi,
    //����ܿ�ģʽ(��Common�����Ͽ�����Ծ�����Ĺ���)
    Runcool
}


public class PlayerManager : BaseManager<PlayerManager>
{
    //���״̬����
    public E_Player_State state;

    public PlayerManager()
    {
        //Ĭ�Ͻ�״̬����Ϊ��ͨ����ģʽ
        state = E_Player_State.Common;
    }

    //�л�״̬����
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
