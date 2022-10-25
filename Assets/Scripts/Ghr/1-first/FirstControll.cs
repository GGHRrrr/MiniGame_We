using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstControll : MonoBehaviour
{
    #region ����
    public GameObject e;
    public GameObject touying;
    public GameObject mimaxiang;
    //���
    public GameObject cam;
    //����
    public GameObject yiyi;
    //����
    public GameObject workEnv;
    public GameObject workInsideEnv;
    public GameObject workInsidUnder;
    public GameObject outPostRoom;
    public GameObject mapPanel;
    //����
    private GameObject post;

    //��Ч���
    private AudioSource audio;
    //������Ч�ļ�
    private AudioClip cantOpenDoor;
    //�Ի���
    public GameObject dialogueFrame;
    public GameObject daPanel;

    public GameObject black;

    #endregion
    #region �ж�����
    
     public static bool isPlayerEnterWork = false;
     public static bool isNowEnter = false;
     public  bool isHaveShenfen = false;
     bool isEnterDoor=false;
     bool isEnterWindow = false;
     bool isInsideLeft = false;
     bool isInsideRight = false;
     bool isUnderLeft = false;
     bool isNextLevel = false;
     bool isEnterHole = false;
     bool isEnterOutPostDoor = false;
     bool isExitOutPost = false;
     bool isEndDia = false;
     bool isEnterTouying = false;
     bool isEnterMima = false;
    //�ж��״ν���
    private bool isFirst = true;
    int touyingCount = 0;
    #endregion
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.USEITEM_SHENGZI.ToString(), UseShengzi);
    }
    private void Start()
    {
        post = GameObject.Find("Post").gameObject;
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        cantOpenDoor = Resources.Load<AudioClip>("Audio/Sound/����ס�򲻿�");
        
    }
    private void Update()
    {
        #region ��ҽ����¼�
        if (isEnterDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(YiYiControll.isTotalunLocked&&isNowEnter==false)
                {
                    Debug.Log("���빤��");
                    isNowEnter = true;
                    cam.GetComponent<CameraFollow>().maxPos = new Vector2(15f, 0);
                    workEnv.SetActive(false);
                    workInsideEnv.SetActive(true);
                    gameObject.transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
                    yiyi.transform.localPosition = new Vector3(-9f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
                    yiyi.transform.GetChild(0).gameObject.SetActive(true);
                    isPlayerEnterWork = true;
                    post.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("����ڴ��ţ���������");
                    //������Ч
                    if (!audio.isPlaying)
                    {
                        audio.PlayOneShot(cantOpenDoor,0.8f);
                    }
                        
                }
            } 
        }
        if(isEnterWindow&&!isPlayerEnterWork)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                string[] dialogues = { "Human:YiYi,���Ƚ�ȥ�������Ŵ򿪡�", "Yiyi:�յ���" };
                DialoguePanel.Instance.ShowDialogue(dialogues);
                Debug.Log("����ڴ������������");
            }
        }
        //�뿪����
        if(isInsideLeft&& !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cam.GetComponent<CameraFollow>().maxPos=new Vector2(49f,0);
                transform.localPosition = new Vector3(60f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(60f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
                workEnv.SetActive(true);
                workInsideEnv.SetActive(false);
                isNowEnter = false;
                post.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        //�������һ��
        if(isInsideRight && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                post.SetActive(true);
                //�����Ի�
                string[] dialogues =
                {
                    "Human:����ͱ��Yiyi���ˡ�",
                    "Yiyi:SPY-007�����������ˣ�����ֵ�������ĺû�顣",
                    "Human:�����ͻȻ�ػ����˽�ȥ���ҿ϶����������Ǹ��İɡ�"
                };
                DialoguePanel.Instance.ShowDialogue(dialogues);
                workInsidUnder.gameObject.SetActive(true);
                workInsideEnv.SetActive(false);
                transform.localPosition = new Vector3(-10f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(-13f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
            }
        }
        //����һ�㵽����
        if(isUnderLeft&& !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                post.SetActive(false);
                workInsidUnder.SetActive(false);
                workInsideEnv.SetActive(true);
                gameObject.transform.localPosition = new Vector3(130f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(130f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
            }
        }
        //������վ
        if(isEnterOutPostDoor&!gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            //49. 2.5
            //44.5/47   44
            if(Input.GetKeyDown(KeyCode.E))
            {
                //cam.transform.position = new Vector3(44, cam.transform.position.y, cam.transform.position.z);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(46, 0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(45.6f, 0);
                cam.transform.position = new Vector3(45.6f, cam.transform.position.y, cam.transform.position.z);
                gameObject.transform.localPosition = new Vector3(203f, transform.localPosition.y, transform.localPosition.z);
                outPostRoom.SetActive(true);
                workEnv.SetActive(false);
            }
            
        }
        //����ͶӰ
        if(isEnterTouying & !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!touying.activeInHierarchy)
                    touying.gameObject.SetActive(true);
                if (!daPanel.activeInHierarchy)
                    daPanel.SetActive(true);
                if (touyingCount < 8)
                    touyingCount++;
                Debug.Log(touyingCount);
                switch (touyingCount)
                {
                    case 1:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "�����������һ��������վ����";
                        break;
                    case 2:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "�����Ѿ��뿪���������У�����Ҳ�������һ����Ա����ת��";
                        break;
                    case 3:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "����ת�Ƶ�ԭ���ϼ�û����ȷ˵��������ֻ��Ҫ����Լ��ı�ְ�����ͺ�";
                        break;
                    case 4:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "ǰ���µĳ��У���Ҳ���������ȥ���Լ����,��ݿ�Ҳ������Ҫ";
                        break;
                    case 5:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "�ҽ���������������У������������Ҫ���˾����߰�";
                        break;
                    case 6:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "������1025���ҵı��";
                        break;
                    case 7:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "�ټ�������";
                        break;
                    case 8:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "�ҵı����1025���ɲ�Ҫ����";
                        break;
                }
            }
        }
        if (isEnterMima & !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!mimaxiang.activeInHierarchy)
                {
                    mimaxiang.SetActive(true);
                    gameObject.GetComponent<PlayerMove>().moveSpeed = 0;
                }
                else
                {
                    mimaxiang.SetActive(false);
                    gameObject.GetComponent<PlayerMove>().moveSpeed = 7;
                }
                
            }
        }
            //�뿪��վ
            if (isExitOutPost && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                outPostRoom.SetActive(false);
                workEnv.SetActive(true);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(49f, 0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(2.5f, 0);
                gameObject.transform.localPosition = new Vector3(230f, transform.localPosition.y, transform.localPosition.z);
            }
        }
        
        //������һ��
        if (isNextLevel && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Anim3(black));
            }
        }
        #endregion
    }

    IEnumerator Anim3(GameObject panel)//дһ�����亯��
    {
        mapPanel.SetActive(true);
        mapPanel.GetComponent<MapControll>().ShowMapAni(1);
        Image img = panel.GetComponent<Image>();
        yield return new WaitForSeconds(2f);
        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //��ȫ��Ļ�˸ı�����״̬
        //�л�����
        //��ǰ�ؿ����
        int num = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(num + 1);
        yield return new WaitForSeconds(0.5f);

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "breakWindow":
                ShowPlayerE(true);
                isEnterWindow = true;
                Debug.Log("���������ˣ�");
                break;
            case "workDoor":
                Debug.Log("�������ˣ�");
                ShowPlayerE(true);
                isEnterDoor = true;
                break;
            case "insideLeft":
                isInsideLeft = true;
                ShowPlayerE(true);
                Debug.Log("������ߵ����ˣ�׼����ȥ��");
                break;
            case "insideRight":
                isInsideRight=true;
                ShowPlayerE(true);
                Debug.Log("������ߵ����ˣ�׼��������һ��");
                break;
            case"under_left":
                isUnderLeft = true;
                ShowPlayerE(true);
                Debug.Log("��������һ������ˣ�׼����һ��");
                break;
            case "holetrigger":
                isEnterHole = true;
                Debug.Log("��������");
                //�����Ի�
                string[] dialogues = { "Human:Ҳ������Ҫ��Ѱ������" };
                DialoguePanel.Instance.ShowDialogue(dialogues);
                break;
            case "outPostDoor":
                ShowPlayerE(true);
                isEnterOutPostDoor = true;
                Debug.Log("������վ�ˣ�׼������");
                break;
            case "outpostleft":
                ShowPlayerE(true);
                isExitOutPost = true;
                Debug.Log("׼���뿪��վ");
                break;
            case "endDia":
                //�����ͼĩβ���ر����ǵ��ƶ������жԻ����Ի���Ͽ����ƶ�
                isEndDia = true;
                Debug.Log("�����ͼĩβ");
                break;
            case "NextLevel":
                ShowPlayerE(true);
                Debug.Log("������һ�ص����ˣ�׼��������һ��");
                isNextLevel = true;
                break;

            case "ca":
                ShowPlayerE(true);
                isEnterTouying = true;
                e.gameObject.SetActive(true);
                break;
            case "mima":
                ShowPlayerE(true);
                isEnterMima = true;
                ShowPlayerE(true);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                ShowPlayerE(false);
                isEnterWindow=false;
                break;
            case "workDoor":
                isEnterDoor = false;
                ShowPlayerE(false);
                break;
            case "insideLeft":
                isInsideLeft = false;
                ShowPlayerE(false);
                break;
            case "insideRight":
                isInsideRight = false;
                ShowPlayerE(false);
                break;
            case "under_left":
                isUnderLeft = false;
                ShowPlayerE(false);
                break;
            case "NextLevel":
                ShowPlayerE(false);
                isNextLevel = false;
                break;
            case "holetrigger":
                isEnterHole = false;
                ShowPlayerE(false);
                break;
            case "outPostDoor":
                isEnterOutPostDoor = false;
                ShowPlayerE(false);
                break;
            case "outpostleft":
                ShowPlayerE(false);
                isExitOutPost = false;
                break;
            case "endDia":
                //�����ͼĩβ���ر����ǵ��ƶ������жԻ����Ի���Ͽ����ƶ�
                isEndDia = false;
                break;
            case "ca":
                isEnterTouying = false;
                touying.gameObject.SetActive(false);
                daPanel.SetActive(false);
                daPanel.transform.GetChild(1).GetComponent<Text>().text = "";
                e.gameObject.SetActive(false);
                break;
            case "mima":
                isEnterMima = false;
                ShowPlayerE(false);
                break;
        }
    }

    //���������ײ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "guardRobot":
                //�ж��Ƿ�Ϊ�״ν������ж��Ƿ������ݿ�(�����������)
                //TODO:��������ݿ�,���������
                if (isHaveShenfen==false)
                {
                    if (isFirst)
                    {
                        print("�״ν���������ݿ�");
                        string[] dialogues = { "����ݿ��߽�ֹͨ�С�" };
                        DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                        isFirst = false;
                    }
                    else
                    {
                        //��ν���������ݿ�
                        print("��ν���������ݿ�");
                        string[] dialogues = { "���棡����ݿ��߽�ֹͨ�У�" };
                        DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                    }
                    //�ڱ��л�����
                    collision.collider.GetComponent<Animator>().SetTrigger("Nopass");
                }
                else
                {
                    //�Ѵ�����ݿ�
                    string[] dialogues = { "���ʶ��ͨ��������ͨ�С�" };
                    DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                    collision.collider.transform.position = new Vector3(collision.collider.transform.position.x, collision.collider.transform.position.y + 0.5f, collision.collider.transform.position.z);
                    collision.collider.GetComponent<BoxCollider2D>().enabled = false;
                    //�ڱ��л�����
                    collision.collider.GetComponent<Animator>().SetTrigger("Pass");
                }
                break;
                
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
    void UseShengzi(object info)
    {
        if(isEnterHole)
        {
            var shengzi = GameObject.Find("Envrionments/WorkImage").transform.GetChild(1).gameObject;
            shengzi.SetActive(true);
        }
    }
}
