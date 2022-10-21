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
    //动画组件
    [HideInInspector]
    public Animator anim;
    //玩家音效组件
    private AudioSource audio;
    private AudioClip walkAudio;

    //移动速度
    public float moveSpeed;
    //复原速度
    public float recoverSpeed;
    //yiyi机器人游戏对象
    private Transform yiyi;
    //跟随点坐标
    private Transform followPoint;
    //水平与竖直移动分量
    private float moveH, moveV;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        walkAudio = Resources.Load<AudioClip>("Audio/Sound/脚步声城市乡镇");

        yiyi = transform.parent.Find("yiyi");
        followPoint = transform.Find("FollowPoint");

        //开启控制模块开关
        InputManager.Instance().SwitchStates(true);
    }

    
    void FixedUpdate()
    {
        if (PlayerManager.Instance().state == E_Player_State.Common)
        {
            moveH = Input.GetAxisRaw("Horizontal");
            //print(moveH);
            //moveV = Input.GetAxisRaw("Vertical");
            if (!DialoguePanel.Instance.IsDialogue)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                Move();
                Flip();
            }
            else
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("walk", false);
            }  
        }
       
    }

    private void Move()
    {
        rigidbody.velocity = new Vector3(moveH * moveSpeed, rigidbody.velocity.y,0);
        ToFollowPoint(false);
        //切换动画，播放音效
        if (moveH > 0 || moveH < 0)
        {
            anim.SetBool("walk", true);
            if (!audio.isPlaying)
                audio.PlayOneShot(walkAudio, 0.8f);
        }
        else
        {
            anim.SetBool("walk", false);
            if (!audio.isPlaying)
                audio.Stop();
        } 
           
    }

    private void Flip()
    {
        if (moveH > 0)
        {
            //向右
            transform.eulerAngles = new Vector3(0, 0, 0);
            //yiyi转向
            yiyi.transform.localScale = new Vector3(1.6f, yiyi.transform.localScale.y, 1);
        }
        else if (moveH < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            //yiyi转向
            yiyi.transform.localScale = new Vector3(-1.6f, yiyi.transform.localScale.y, 1);
        }
    }

    //yiyi跟随算法：每次操作让yiyi以物理模型的变化速度归未，还原其物理真实性
    //isBack:true：物体从yiyi独立操作转换为跟随状态；false：物体普通跟随状态。目的是区分加速度。
    /*public void ToFollowPoint(bool isBack)
    {
        StartCoroutine(ToFollowPointIEnum(isBack));
    }*/

    public void ToFollowPoint(bool isBack)
    {
        StartCoroutine(ToFollowPointIEnum(isBack));
    }


    IEnumerator ToFollowPointIEnum(bool isBack)
    {

        /*已知信息：yiyi的当前位置,yiyi需要回归的位置
       * 开始复位的初始速度v0
         *不断刷新的两点距离s
          物理模型：机器人从初始点以v0为moveSpeed的初速度向目标点复位，通过a = v²/ 2s求出加速度，其中实时计算终点的距离st，通过 v = √2ast 计算实时速度，当到达目标点时，yiyi恰好停下来
*/


        float s = Vector3.Distance(yiyi.position, followPoint.position);
        //如果是回归状态，则速度可以使用另设的recoverSpeed
        float a = (recoverSpeed * recoverSpeed) / (2 * s);
        //如果是普通跟随状态，则速度与人物速度相同即可保持平滑
        //if (!isBack) 
            //a = (moveSpeed * moveSpeed) / (2 * s);

        while (Vector3.Distance(yiyi.position, followPoint.position) > 1.0f)
        {
            //速度方向
            Vector3 direction = (followPoint.position - yiyi.position).normalized;
            yield return new WaitForFixedUpdate();
            //s = Mathf.Max(Vector3.Distance(yiyi.position, followPoint.position),s);
            s = Vector3.Distance(yiyi.position, followPoint.position);
            float vt = Mathf.Sqrt(2 * a * s);
            yiyi.transform.Translate(vt * direction * Time.fixedDeltaTime * 0.001f);
            //print("距离" + s);
        }
        //yiyi.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
