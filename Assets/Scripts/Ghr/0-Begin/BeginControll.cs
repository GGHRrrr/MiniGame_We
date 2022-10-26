using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BeginControll : MonoBehaviour
{
    //��Ч
    private AudioSource audio;
    private AudioClip moveGarbage;

    //��������
    private 
    Camera minCamera;//��д�����
    Camera mainCamera;//�������
    GameObject openingAniPoint;//��������
    GameObject playerPar;//��ɫ������
    GameObject player;//��ɫ
    GameObject yiYI;//������
    

    public GameObject e;
    public GameObject black;
    public GameObject diaPanel;
    public GameObject mapPanel;
    private bool isNextLevel = false;

    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_YIYI.ToString(), TalkWith_YiYi);
        EventManager.Instance().AddEventListener(EventTypeEnum.TALKWITH_PLAYER.ToString(), TalkWith_Player);
        EventManager.Instance().AddEventListener(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), UseYilaguan_Garbage);
    }
    private void Start()
    {
        //��Ч
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        moveGarbage = Resources.Load<AudioClip>("Audio/Sound/移动垃圾桶");

        minCamera = GameObject.Find("MinCamera").GetComponent<Camera>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        openingAniPoint = GameObject.Find("Opening_Animation");
        playerPar = GameObject.Find("Player");
        player= playerPar.transform.GetChild(0).gameObject;
        yiYI = playerPar.transform.GetChild(1).gameObject;
        StartCoroutine(PlayOpenningAni());
        //播放BGM
        MusicManager.Instance().PlayBGM("城市BGM");

    }

    private void Update()
    {
        //������һ��
        if (isNextLevel && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Anim3(black));
            }
        }
    }

    IEnumerator Anim3(GameObject panel)//写一个渐变函数
    {
        mapPanel.SetActive(true);
        mapPanel.GetComponent<MapControll>().ShowMapAni(0);
        Image img = panel.GetComponent<Image>();
        yield return new WaitForSeconds(2f);
        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //完全黑幕了改变物体状态
        //切换场景
        //当前关卡编号
        int num = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(num + 1);
        LoadMessagesAndLogs(num + 1);
        yield return new WaitForSeconds(0.5f);

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }
    }

    private void LoadMessagesAndLogs(int num)
    {
        switch (num)
        {
            case 1:
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),1);
                break;
            case 2:
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),2);
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Aric",1));
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Hank",1));
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Hank",2));
                break;
            case 3:
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),3);
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Aric",2));
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Alice",1));
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Hank",3));
                break;
            case 4:
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),4);
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Aric",3));
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Alice",2));
                EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
                    new KeyValuePair<string,int>("Hank",4));
                break;
        }
    }

    /// <summary>
    /// ��ʼ������������������д�л���
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayOpenningAni()
    {
        //��������ƶ�
        player.GetComponent<PlayerMove>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        diaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "YiYi,快去把易拉罐捡回来！";
        diaPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(2f) ;
        diaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
        diaPanel.SetActive(false);
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
            yield return new WaitForSeconds(0.5f);
                diaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "按TAB切换角色";
            diaPanel.SetActive(true);
            yield return new WaitForSeconds(1f);
            diaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
            diaPanel.SetActive(false);
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
            case "NextLevel":
                ShowPlayerE(true);
                Debug.Log("������һ�ص����ˣ�׼��������һ��");
                isNextLevel = true;
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTouchGar == true)
            garbage = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "NextLevel":
                ShowPlayerE(false);
                isNextLevel = false;
                break;
        }
    }
    #region ��������Ͱ
    void UseYilaguan_Garbage(object info)
    {
        Debug.Log("ִ������1");
        if (isTouchGar)
        {
            Debug.Log("ִ������");
            //�ƶ�����Ͱ��Ч
            if (!audio.isPlaying)
                audio.PlayOneShot(moveGarbage, 0.8f);
            string[] a = new string[1];
            a[0] = "垃圾···收集完成，需要···处理垃圾";
            garbage.GetComponent<Talkable>().lines = a;
            DialoguePanel.Instance.ShowDialogue(garbage.GetComponent<Talkable>().lines, garbage.transform.GetChild(0).transform);
            garbage.transform.localPosition = new Vector2(garbage.transform.localPosition.x, garbage.transform.localPosition.y + 0.5f);
            garbage.transform.GetChild(1).GetComponent<Collider2D>().enabled = false;
            EventManager.Instance().RemoveEventListener(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), UseYilaguan_Garbage);
        }
    }
    #endregion

    #region ��ʾ��ҽ���
    void ShowPlayerE(bool isEnter)
    {
        if (!gameObject.GetComponent<SwitchRole>().isYiYi && isEnter)
        {
            e.gameObject.SetActive(true);
            StartCoroutine(Fade(e, true));
        }
        if (!gameObject.GetComponent<SwitchRole>().isYiYi && !isEnter)
        {
            e.gameObject.SetActive(false);
            e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    IEnumerator Fade(GameObject gameObj, bool isFade)//дһ�����亯��
    {
        SpriteRenderer spriteRenderer = gameObj.GetComponent<SpriteRenderer>();
        if (isFade)
        {
            while (spriteRenderer.color.a > 0)
            {
                yield return new WaitForSeconds(0.05f);
                spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - 0.05f);
            }
        }
        else
        {
            while (spriteRenderer.color.a < 1)
            {
                yield return new WaitForSeconds(0.05f);
                spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a + 0.05f);
            }
        }
    }

    #endregion
}
