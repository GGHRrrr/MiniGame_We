using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 挂载位置：玩家组件上
    作用：此脚本用来控制角色的基础移动操作
 */
public class PlayerMove : MonoBehaviour
{
    //刚体组件
    private Rigidbody2D rigidbody;
    //移动速度
    public float moveSpeed;
    //复原速度
    public float recoverSpeed;
    //yiyi机器人游戏对象
    private Transform yiyi;
    //跟随点坐标
    private Transform followPoint;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        yiyi = transform.parent.Find("yiyi");
        followPoint = transform.Find("FollowPoint");

        //开启控制模块开关
        InputManager.Instance().SwitchStates(true);
        //添加键盘某键按下事件
        EventManager.Instance().AddEventListener("KeyDown", CheckKeyDown);
        //添加键盘某键抬起事件
        EventManager.Instance().AddEventListener("KeyUp", CheckKeyUp);
        //添加键盘某键按住事件
        EventManager.Instance().AddEventListener("Key", CheckKey);
    }

    private void CheckKey(object key)
    {
        if (!yiyi.GetComponent<YiyiMove>().isOpen)
        {
            KeyCode keyCode = (KeyCode)key;
            
            switch (keyCode)
            {
                case KeyCode.A:
                    //机器人跟随算法
                    ToFollowPoint(false);
                    //改变方向
                    if (transform.localScale.x == 1)
                        transform.localScale = new Vector3(-1, 1, 1);
                    rigidbody.velocity = new Vector3(-moveSpeed, rigidbody.velocity.y);

                    break;
                case KeyCode.D:
                    ToFollowPoint(false);
                    //改变方向
                    if (transform.localScale.x == -1)
                        transform.localScale = new Vector3(1, 1, 1);
                    rigidbody.velocity = new Vector3(moveSpeed, rigidbody.velocity.y);
                    break;
            }
        }
    }

    //yiyi跟随算法：每次操作让yiyi以物理模型的变化速度归未，还原其物理真实性
    //isBack:true：物体从yiyi独立操作转换为跟随状态；false：物体普通跟随状态。目的是区分加速度。
    public void ToFollowPoint(bool isBack)
    {
        StartCoroutine(ToFollowPointIEnum(isBack));
    }

    IEnumerator ToFollowPointIEnum(bool isBack)
    {
        /*
         * 已知信息：yiyi的当前位置,yiyi需要回归的位置
         * 开始复位的初始速度v0
         * 不断刷新的两点距离s
          物理模型：机器人从初始点以v0为moveSpeed的初速度向目标点复位，通过a = v²/2s求出加速度，其中实时计算终点的距离st，通过 v = √2ast 计算实时速度，当到达目标点时，yiyi恰好停下来
         */
        
        float s = 0;
        //如果是回归状态，则速度可以使用另设的recoverSpeed
        float a = (recoverSpeed * recoverSpeed) / (2 * Vector3.Distance(yiyi.position, followPoint.position));
        //如果是普通跟随状态，则速度与人物速度相同即可保持平滑
        if (!isBack) a = (moveSpeed * moveSpeed) / (2 * Vector3.Distance(yiyi.position, followPoint.position));

        while (Vector3.Distance(yiyi.position, followPoint.position) > 0.8f)
        {
            //速度方向
            Vector3 direction = (followPoint.position - yiyi.position).normalized;
            yield return new WaitForSeconds(0.05f);
            //s = Mathf.Max(Vector3.Distance(yiyi.position, followPoint.position),s);
            s = Vector3.Distance(yiyi.position, followPoint.position);
            float vt = Mathf.Sqrt(2 * a * s);
            yiyi.GetComponent<Rigidbody>().velocity = direction * vt ;
            Debug.Log("距离"+ s);

        }
        yiyi.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


    private void CheckKeyDown(object key)
    {
        
    }

    private void CheckKeyUp(object key)
    {

    }

   
}
