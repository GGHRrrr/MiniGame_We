using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ����λ�ã���ҽ�ɫ
    ���ã��˽ű��������� ������yiyi�ĸ���Ч��ʵ�֣��Լ��л�����ʵ�֡�
 */
public class SwitchRole : MonoBehaviour
{
    //��¼��yiyi�Ƿ����״̬
    private bool isFollow;
    //yiyi���
    private Transform yiyi;
    //yiyi��Ĭ��״̬�µ����λ��
    private Vector3 pos;
    //yiyi��ѡ��ʱ��ͼ��
    public Transform Selected;

    //�л�״̬ʱ��Ҫ������
    public bool IsFollow
    {
        get { return isFollow; }
        set
        {
            isFollow = value;
            if (isFollow)
            {
                Selected.gameObject.SetActive(false);
                //���л���Ĭ��״̬ʱ��yiyi��Ϊ���ǵ���������֮�ƶ���ת��
                transform.GetComponent<PlayerMove>().ToFollowPoint(true);
                yiyi.GetComponent<YiyiMove>().SwitchMove(false);
                PlayerManager.Instance().SwitchState("Common");
            }
            else
            {
                //���л�Ϊyiyi״̬ʱ���ɶ�������yiyi�����ƶ������
                pos = yiyi.position;
                Selected.gameObject.SetActive(true);
                yiyi.GetComponent<YiyiMove>().SwitchMove(true);
                PlayerManager.Instance().SwitchState("Yiyi");
            }
        }
    }

    private void Start()
    {
        yiyi = transform.parent.Find("yiyi");//�õ�yiyi��Ϸ����
        pos = yiyi.localPosition;
        isFollow = true;
        //����л�״̬�¼�
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
