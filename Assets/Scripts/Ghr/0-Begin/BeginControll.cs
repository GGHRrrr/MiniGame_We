using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class BeginControll : MonoBehaviour
{
    //��������
    private 
    Camera minCamera;//��д�����
    Camera mainCamera;//�������
    GameObject openingAniPoint;//��������
    GameObject player;//��ɫ
    GameObject yiYI;
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
        yiYI = player.transform.GetChild(0).gameObject;
        StartCoroutine(PlayOpenningAni());
    }

    /// <summary>
    /// ��ʼ������������������д�л���
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayOpenningAni()
    {
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
        }
        else
        {
            StartCoroutine(PlayOpenningAni());
        }
    }
     void TalkWith_YiYi(object info)
    {
        Debug.Log("yiyi˵��");
    }
    void TalkWith_Player(object info)
    {
        Debug.Log("���˵��");
    }
}
