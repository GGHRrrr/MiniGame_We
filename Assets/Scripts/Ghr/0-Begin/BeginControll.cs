using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class BeginControll : MonoBehaviour
{
    //过场动画
    private 
    Camera minCamera;//特写摄像机
    Camera mainCamera;//主摄像机
    GameObject openingAniPoint;//开场动画
    GameObject player;//角色
    GameObject yiYI;//机器人
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_YIYI.ToString(), TalkWith_YiYi);
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_PLAYER.ToString(), TalkWith_Player);
        EventManager.Instance().AddEventListener(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), UseYilaguan_Garbage);
    }
    private void Start()
    {
        minCamera = GameObject.Find("MinCamera").GetComponent<Camera>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        openingAniPoint = GameObject.Find("Opening_Animation");
        player = GameObject.Find("Player");
        yiYI = player.transform.GetChild(1).gameObject;
        StartCoroutine(PlayOpenningAni());
    }

    /// <summary>
    /// 开始过场动画，易拉罐特写切换等
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayOpenningAni()
    {
        //禁用玩家移动先用移动测试脚本代替
        player.GetComponent<MoveTest>().enabled = false;
        yield return new WaitForSecondsRealtime(2f) ;
        Animator opAni = openingAniPoint.transform.GetChild(0).GetComponent<Animator>();
        AnimatorStateInfo stateinfo = opAni.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("yilaguanAni") && (stateinfo.normalizedTime > 1.0f))
        {
            minCamera.GetComponent<Animator>().SetBool("isBegin", true);
            yield return new WaitForSecondsRealtime(2f);
            minCamera.gameObject.SetActive(false);
            mainCamera.enabled = true;
            StartCoroutine(PlayYiYiAni());
        }
        else
        {
            StartCoroutine(PlayOpenningAni());
        }
    }
    /// <summary>
    /// YIYI开场捡易拉罐动画
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayYiYiAni()
    {
        yield return null;
        yiYI.GetComponent<Animator>().enabled = true;
        Animator yiyiAni = yiYI.GetComponent<Animator>();
        AnimatorStateInfo stateinfo = yiyiAni.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Pick_yiyi") && (stateinfo.normalizedTime > 1.0f))
        {   //yiyi动画未作，暂时先用关闭animator处理
            yiYI.GetComponent<Animator>().enabled = false;
            //切换对象，捡易拉罐逻辑，yiyi颜文字表情
            yiYI.transform.localPosition = new Vector2(-20.8f, 41.8f);//暂时捡到易拉罐直接回去
            mainCamera.gameObject.GetComponent<CameraFollow>().enabled = true;
            //回去之后移动回复,暂时用测试脚本代替
            player.GetComponent<MoveTest>().enabled = true;
        }
        else
        {
            StartCoroutine(PlayYiYiAni());
        }
    }
    /// <summary>
    /// yiyi对话事件
    /// </summary>
    /// <param name="info"></param>
     void TalkWith_YiYi(object info)
    {
        Debug.Log("yiyi说话");
    }
    /// <summary>
    /// 玩家对话事件
    /// </summary>
    /// <param name="info"></param>
    void TalkWith_Player(object info)
    {
        Debug.Log("玩家说话");
    }
    /// <summary>
    /// 玩家碰撞事件
    /// </summary>
    /// <param name="collision"></param>
     bool isTouchGar = false;//是否触碰过
     GameObject garbage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch (collision.gameObject.name)
        {
            case "Environments_Garbage":
                Debug.Log("我碰到垃圾桶了");
                if (isTouchGar == false)
                {
                    //未触碰过则触发对话;
                    isTouchGar = !isTouchGar;
                }
                //else
                //{
                //    garbage= collision.gameObject;
                //}
                break;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isTouchGar == true)
            garbage = collision.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.name)
        {
                case "Environments_Fanmaiji":
                Debug.Log("我碰到贩卖机了");//可以做老虎机玩法,有时间再说
                break;
        }
    }
    #region 触碰垃圾桶
    void UseYilaguan_Garbage(object info)
    {   if(isTouchGar)
        {
            garbage.transform.localPosition = new Vector2(garbage.transform.localPosition.x, garbage.transform.localPosition.y + 0.5f);
            garbage.GetComponent<Collider2D>().enabled = false;
            EventManager.Instance().RemoveEventListener(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), UseYilaguan_Garbage);
        }
    }
    #endregion
}
