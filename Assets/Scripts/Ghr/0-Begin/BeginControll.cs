using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class BeginControll : MonoBehaviour
{
    //��������
    private 
    Camera minCamera;//��д�����
    Camera mainCamera;//�������
    GameObject openingAniPoint;//��������
    GameObject playerPar;//��ɫ������
    GameObject player;//��ɫ
    GameObject yiYI;//������
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
        playerPar = GameObject.Find("Player");
        player= playerPar.transform.GetChild(0).gameObject;
        yiYI = playerPar.transform.GetChild(1).gameObject;
        StartCoroutine(PlayOpenningAni());
    }

    /// <summary>
    /// ��ʼ������������������д�л���
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayOpenningAni()
    {
        //��������ƶ�
        player.GetComponent<PlayerMove>().enabled = false;
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
    /// YIYI�����������޶���
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayYiYiAni()
    {
        yield return null;
        player.GetComponent<SwitchRole>().IsFollow = false;
        yiYI.GetComponent<Animator>().enabled = true;
        Animator yiyiAni = yiYI.GetComponent<Animator>();
        AnimatorStateInfo stateinfo = yiyiAni.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Pick") && (stateinfo.normalizedTime > 1.0f))
        {
            yiYI.transform.GetChild(0).GetComponent<Animator>().Play("Idle");
            yiYI.GetComponent<Animator>().enabled = false;
            //yiYI.GetComponent<Animator>().Play("viviidle");
            //�л����󣬼��������߼���yiyi�����ֱ���
            mainCamera.gameObject.GetComponent<CameraFollow>().enabled = true;
            //��ȥ֮���ƶ��ظ�,��ʱ�ò��Խű�����
            player.GetComponent<PlayerMove>().enabled = true;
        }
        else
        {
            StartCoroutine(PlayYiYiAni());
        }
    }
    /// <summary>
    /// yiyi�Ի��¼�
    /// </summary>
    /// <param name="info"></param>
     void TalkWith_YiYi(object info)
    {
        Debug.Log("yiyi˵��");
    }
    /// <summary>
    /// ��ҶԻ��¼�
    /// </summary>
    /// <param name="info"></param>
    void TalkWith_Player(object info)
    {
        Debug.Log("���˵��");
    }
    /// <summary>
    /// �����ײ�¼�
    /// </summary>
    /// <param name="collision"></param>
     bool isTouchGar = false;//�Ƿ�����
     GameObject garbage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch (collision.gameObject.name)
        {
            case "Environments_Garbage":
                Debug.Log("����������Ͱ��");
                //if (isTouchGar == false)
                //{
                //    //δ�������򴥷��Ի�;
                //    isTouchGar = !isTouchGar;
                //}
                //else
                //{
                //    garbage= collision.gameObject;
                //}
                break;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (isTouchGar == true)
            //garbage = collision.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.name)
        {
            case "Environments_Garbage":
                Debug.Log("����������Ͱ��");
                if (isTouchGar == false)
                {
                    //δ�������򴥷��Ի�;
                    isTouchGar = !isTouchGar;
                }
                //else
                //{
                //    garbage= collision.gameObject;
                //}
                break;
            case "Environments_Fanmaiji":
                Debug.Log("��������������");//�������ϻ����淨,��ʱ����˵
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTouchGar == true)
            garbage = collision.gameObject;
    }
    #region ��������Ͱ
    void UseYilaguan_Garbage(object info)
    {
        Debug.Log("ִ������1");
        if (isTouchGar)
        {
            Debug.Log("ִ������");
            garbage.transform.localPosition = new Vector2(garbage.transform.localPosition.x, garbage.transform.localPosition.y + 0.5f);
            garbage.transform.GetChild(1).GetComponent<Collider2D>().enabled = false;
            EventManager.Instance().RemoveEventListener(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), UseYilaguan_Garbage);
        }
    }
    #endregion
}
