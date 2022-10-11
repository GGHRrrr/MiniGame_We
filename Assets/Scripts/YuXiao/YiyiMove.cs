using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 挂载位置：yiyi机器人上
 * 作用：负责yiyi机器人的移动逻辑
 
 */
[RequireComponent(typeof(Rigidbody))]
public class YiyiMove : MonoBehaviour
{
    private Rigidbody rigidbody;

    //是否开启独立移动模块
    [HideInInspector]
    public bool isOpen;

    //yiyi移动速度
    public float moveSpeed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        isOpen = false;
        //引入移动输入模块事件
        EventManager.Instance().AddEventListener("Key", CheckKey);
        //添加键盘某键抬起事件
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


    //切换移动独立模块
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
                transform.GetComponent<SpriteRenderer>().flipX = true;
                rigidbody.velocity = moveSpeed * Vector3.left;
            }
            else if (keyCode == KeyCode.D)
            {
                transform.GetComponent<SpriteRenderer>().flipX = false;
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
