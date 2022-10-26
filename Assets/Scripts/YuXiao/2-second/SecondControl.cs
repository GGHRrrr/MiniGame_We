using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondControl : MonoBehaviour
{
    public GameObject e;
    public Transform point1;
    public Transform point2;
    public GameObject black;
    //�������
    public GameObject flower;
    public GameObject suger;
    public GameObject wine;
    public GameObject wineBack;
    public GameObject cup;
    public GameObject qte;
    public GameObject finishedWine;

    #region ״̬����
    private bool isFlowerShop;
    //һ֦���Ի�
    private bool isFlower;
    private bool isFirstFlower = true;
    private bool isTransport;
    private bool isEnterRest;
    //��ʦ�Ի�
    private bool isCooker;
    private bool firstCooker = true;
    private bool firstFinish = true;
    //����
    private bool isBartender;
    //����
    private bool isExit;
    //�����ǹ���
    private bool isSuger;
    //�ռ�����Ŀ
    private int count = 0;
    public bool isRight = false;
    #endregion

    #region ��Ϸ����
    public GameObject Transport;
    //����
    public GameObject Restaround;
    public GameObject Village;
    //NPC
    public Transform waiter;
    public Transform cooker;
    //Yiyi
    private Transform Yiyi;
    //���
    private Camera cam;
    #endregion

    void Start()
    {
        cam = Camera.main;
        Yiyi = transform.parent.Find("yiyi").transform;
        //����BGM
        MusicManager.Instance().PlayBGM("����BGM");
        
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),3);
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Aric",2));
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Alice",1));
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Hank",3));
    }

    
    void Update()
    {
        //����������
        if (isFlowerShop && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                string[] info =
                {
                    "Human:�����ߺ󣬻����Ļ�����������ɵ�ʢ�š�",
                    "Yiyi:����Լ��������������������"
                };
                //�����Ի�
                DialoguePanel.Instance.ShowDialogue(info);
            }
        }

        //����������Ļ�
        if (isFlower && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                string[] info =
                {
                   "Human:��������",
                };
                //�����Ի�
                DialoguePanel.Instance.ShowDialogue(info);
                flower.SetActive(true);
                count++;
            }
        }

        //��������ͨ������
        if (isTransport && !GetComponent<SwitchRole>().isYiYi)
        {
            if (!qte.GetComponent<UIqte>().isFinish)
            {
                //û�г�Ʊ
                string[] info =
                {
                    "������������ʾ��Ʊ��"
                };
                //�����Ի�
                DialoguePanel.Instance.ShowDialogue(info,Transport.transform);
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                //�г�Ʊ
                string[] info =
                {
                    "��л���γ�������һվ����ԭ�߾���"
                };
                
                //�����Ի�
                DialoguePanel.Instance.ShowDialogue(info, Transport.transform);
                //TODO:����������
                StartCoroutine(guochang());
                //transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            }
            
        }

        //�����˽������
        if (isEnterRest && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //�������
                Restaround.SetActive(true);
                Village.SetActive(false);
                transform.position = point2.position;
                Yiyi.position = point2.position + 3 * Vector3.right;
                //�������ֵ
                cam.GetComponent<CameraFollow>().minPos = new Vector2(9.4f ,0);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(35.3f, 0);

                //�����Ի�
                string[] info =
                {
                    "��ӭ���ٱ��꣬�����ò���ѡȡ����λ�����µȴ�����",
                    "Human:�˵����Թ�Ŀһ����",
                    "���á�",
                    "Human:����֮���������������⾳��",
                    "��β�����ֵ�����Ʒ����ѯ�Ʊ���"
                };
                DialoguePanel.Instance.ShowDialogue(info, waiter);
            }
        }

        //���ʦ����
        if (isCooker && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (firstCooker)
                {
                    //��һ�����ʦ����
                    string[] info =
                    {
                        "Human:��ã�����һ������֮����",
                        "��Ǹ���þ������ԭ���Ѿ������ˡ�",
                        "���Ѿ��ܶ���û�����������ˣ���������ˣ��������Ǳ�������ơ�",
                        "��������������Ɑ�ƣ��ҿ�������һ�ų�Ʊ��",
                        "���������ǰһλ�������µģ��ƺ���������ת����ǰ����Լ�Ĺ˿͡�",
                        "������������������ļ�β�ƣ��ҿ�������һ�ų�Ʊ��"
                    };
                    DialoguePanel.Instance.ShowDialogue(info, cooker);
                    firstCooker = false;
                    wine.SetActive(true);
                    count++;
                }
                else
                {
                    //�����״ν���
                    if (!qte.GetComponent<UIqte>().isFinish)
                    {
                        //δ������������
                        string[] info =
                        {
                            "������������������ļ�β�ƣ��ҿ�������һ�ų�Ʊ��"
                        };
                        DialoguePanel.Instance.ShowDialogue(info, cooker);
                    }
                    else
                    {
                        if (firstFinish)
                        {
                            //�������������Σ��״ν���
                            string[] info =
                            {
                                "Human:����֮����������ˡ�",
                                "����������",
                                "ֻ��ϧ�Ҵ�δ��Ҳ�޷�Ʒ������ζ����",
                                "���ǳ�Ʊ���������ɡ�",
                                "һ·˳�磬�ҵĿ��ˡ�"
                            };
                            DialoguePanel.Instance.ShowDialogue(info, cooker);
                            firstFinish = false;
                            finishedWine.SetActive(false);
                            //TODO:��ó�Ʊ
                        }
                        else
                        {
                            string[] info =
                            {
                                "һ·˳�磬�ҵĿ��ˡ�"
                            };
                            DialoguePanel.Instance.ShowDialogue(info, cooker);
                        }
                        
                    }
                }
            }
        }

        //�ռ���
        if (isSuger && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                suger.SetActive(true);
                count++;
            }            
        }

        //TODO:�����߼�
        if (isBartender && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //�������UIҳ��
                if (count >= 3)
                {
                    wineBack.SetActive(true);
                    cup.SetActive(true);
                }
                else
                {
                    string[] info =
                    {
                        "Human:������Ҫ�����ƺ��ǣ�Ŀǰ���ϲ�����"
                    };
                    DialoguePanel.Instance.ShowDialogue(info);
                }
                
            }
        }

        //�����߼�(��Ϊ�г�Ʊ���޳�Ʊ)
        if (isExit && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //������
                Restaround.SetActive(false);
                Village.SetActive(true);
                transform.position = point1.position;
                Yiyi.position = point1.position + 3 * Vector3.left;
                //�������ֵ
                cam.GetComponent<CameraFollow>().minPos = new Vector2(3, 0);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(41, 0);

                //����г�Ʊ(�����Ի�)
                //TODO:�޸�����
                if (qte.GetComponent<UIqte>().isFinish)
                {
                    string[] info =
                    {
                        "Human:ԭ��������û��ȥ��Լô......",
                        "Human:��Ϊʲô������Ϣ�У���ȴ˵���͡�������һ����극�أ�",
                        "Yiyi:�����ԵĽǶȷ��������ǲ���ͬһ���ˡ�",
                        "Human:Ҳ��������˰ɡ�"
                    };
                    DialoguePanel.Instance.ShowDialogue(info);
                }
            }
        }
    }

    #region ���������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "FlowerShop":
                //չʾEͼ��
                ShowPlayerE(true);
                //�޸�״̬����
                isFlowerShop = true;
                break;
            case "Flower":
                ShowPlayerE(true);
                isFlower = true;
                break;
            case "EnterRest":
                ShowPlayerE(true);
                isEnterRest = true;
                break;
            case "Cooker":
                ShowPlayerE(true);
                isCooker = true;
                break;
            case "Exit":
                ShowPlayerE(true);
                isExit = true;
                break;
            case "ѩ�˺�":
                ShowPlayerE(true);
                isBartender = true;
                break;
            case "�ǹ���":
                ShowPlayerE(true);
                isSuger = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "FlowerShop":
                //չʾEͼ��
                ShowPlayerE(false);
                //�޸�״̬����
                isFlowerShop = false;
                break;
            case "Flower":
                ShowPlayerE(false);
                isFlower = false;
                break;
            case "EnterRest":
                ShowPlayerE(false);
                isEnterRest = false;
                break;
            case "Cooker":
                ShowPlayerE(false);
                isCooker = false;
                break;
            case "Exit":
                ShowPlayerE(false);
                isExit = false;
                break;
            case "ѩ�˺�":
                ShowPlayerE(false);
                isBartender = false;
                break;
            case "�ǹ���":
                ShowPlayerE(false);
                isSuger = false;
                break;
        }
    }
    #endregion

    #region ��ײ�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "Transport":
                isTransport = true;
                //collision.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                //collision.transform.localPosition = new Vector2(collision.transform.localPosition.x, collision.transform.localPosition.y + 0.5f);
                break;
            case "Right":
                isRight = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "Transport":
                isTransport = false;
                break;
            case "Right":
                isRight = false;
                break;
        }
    }
    #endregion

    IEnumerator guochang()
    {
        yield return new WaitForSeconds(3f);
        black.gameObject.SetActive(true);
        StartCoroutine(Fade(black, false));
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(3);
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
                yield return new WaitForSeconds(0.1f);
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
}
