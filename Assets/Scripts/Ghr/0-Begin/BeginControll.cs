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
    GameObject player;//��ɫ
    GameObject yiYI;//������
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_YIYI.ToString(), TalkWith_YiYi);
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_PLAYER.ToString(), TalkWith_Player);
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
    /// ��ʼ������������������д�л���
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayOpenningAni()
    {
        //��������ƶ������ƶ����Խű�����
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
            mainCamera.gameObject.GetComponent<CameraFollow>().enabled = true;
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
        yield return new WaitForSecondsRealtime(1f);
        yiYI.GetComponent<Animator>().enabled = true;
        Animator yiyiAni = yiYI.GetComponent<Animator>();
        AnimatorStateInfo stateinfo = yiyiAni.GetCurrentAnimatorStateInfo(0);
        if (stateinfo.IsName("Pick_yiyi") && (stateinfo.normalizedTime > 1.0f))
        {   //yiyi����δ������ʱ���ùر�animator����
            yiYI.GetComponent<Animator>().enabled = false;
            //�л����󣬼��������߼���yiyi�����ֱ���
            yiYI.transform.localPosition = new Vector2(-20.8f, 41.8f);//��ʱ��������ֱ�ӻ�ȥ
            //��ȥ֮���ƶ��ظ�,��ʱ�ò��Խű�����
            player.GetComponent<MoveTest>().enabled = true;
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
}
