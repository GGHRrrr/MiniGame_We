using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondControl : MonoBehaviour
{
    public GameObject e;

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
    private bool isExit;
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
                if (isFirstFlower)
                {
                    string[] info =
                    {
                        "Human:��������",
                    };
                    //�����Ի�
                    DialoguePanel.Instance.ShowDialogue(info);
                    isFirstFlower = false;
                }
                else
                {
                    //��ζԻ�
                    //TODO:���������뱳��

                }
                
            }
        }

        //��������ͨ������
        if (isTransport && !GetComponent<SwitchRole>().isYiYi)
        {
            if (true)
            {
                //û�г�Ʊ
                string[] info =
                {
                    "������������ʾ��Ʊ��"
                };
                //�����Ի�
                DialoguePanel.Instance.ShowDialogue(info,Transport.transform);
                transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
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
                transform.position = new Vector3(40, transform.position.y, transform.position.z);
                Yiyi.position = new Vector3(43, Yiyi.position.y, Yiyi.position.z);
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
                        "������������������������Σ��ҿ�������һ�ų�Ʊ��"
                    };
                    DialoguePanel.Instance.ShowDialogue(info, cooker);
                    firstCooker = false;
                }
                else
                {
                    //�����״ν���
                    if (true)
                    {
                        //δ������������
                        string[] info =
                        {
                            "������������������������Σ��ҿ�������һ�ų�Ʊ��"
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
                            //TODO:����������
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

        //�����߼�(��Ϊ�г�Ʊ���޳�Ʊ)
        if (isExit && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //������
                Restaround.SetActive(false);
                Village.SetActive(true);
                transform.localPosition = new Vector3(118, transform.position.y, transform.position.z);
                Yiyi.localPosition = new Vector3(115, Yiyi.position.y, Yiyi.position.z);
                //�������ֵ
                cam.GetComponent<CameraFollow>().minPos = new Vector2(3, 0);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(41, 0);

                //����г�Ʊ(�����Ի�)
                //TODO:�޸�����
                if (true)
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
                print("����������");
                break;
            case "Flower":
                ShowPlayerE(true);
                isFlower = true;
                print("����������Ļ�");
                break;
            case "EnterRest":
                ShowPlayerE(true);
                isEnterRest = true;
                print("���������ż�");
                break;
            case "Cooker":
                ShowPlayerE(true);
                isCooker = true;
                print("������ʦ");
                break;
            case "Exit":
                ShowPlayerE(true);
                isExit = true;
                print("�������ڣ���E�뿪");
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
                print("��������ͨ������");
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
        }
    }
    #endregion

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
}
