using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ����λ�ã�yiyi��������
 * ���ã�����yiyi�����˵��ƶ��߼�
 
 */
[RequireComponent(typeof(Rigidbody2D))]
public class YiyiMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    //�Ƿ��������ƶ�ģ��
    [HideInInspector]
    public bool isOpen;

    //yiyi�ƶ��ٶ�
    public float moveSpeed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        isOpen = false;
        //�����ƶ�����ģ���¼�
        EventManager.Instance().AddEventListener("Key", CheckKey);
        //��Ӽ���ĳ��̧���¼�
        EventManager.Instance().AddEventListener("KeyUp", CheckKeyUp);
    }

    private void CheckKeyUp(object key)
    {

        
        if (isOpen)
        {
            KeyCode keyCode = (KeyCode)key;
            if (keyCode == KeyCode.A)
            {
                rigidbody.velocity = Vector3.zero;
            }
            else if (keyCode == KeyCode.D)
            {
                rigidbody.velocity = Vector3.zero;
            }

            if (keyCode == KeyCode.W)
            {
                rigidbody.velocity = Vector3.zero;
            }
            else if (keyCode == KeyCode.S)
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
    }


    //�л��ƶ�����ģ��
    public void SwitchMove(bool isOpen1)
    {
        isOpen = isOpen1;
    }
    

    private void CheckKey(object key)
    {
        if (isOpen)
        {
            KeyCode keyCode = (KeyCode)key;
            if (keyCode == KeyCode.A)
            {
                transform.localScale = new Vector3(-1.6f, 1.6f, 1);
                rigidbody.velocity = moveSpeed * Vector3.left;
            }
            else if (keyCode == KeyCode.D)
            {
                transform.localScale = new Vector3(1.6f, 1.6f, 1);
                rigidbody.velocity = moveSpeed * Vector3.right;
            }

            if (keyCode == KeyCode.W)
            {
                rigidbody.velocity = moveSpeed * Vector3.up;
            }
            else if (keyCode == KeyCode.S)
            {
                rigidbody.velocity = moveSpeed * Vector3.down;
            }
        }
    }
}
