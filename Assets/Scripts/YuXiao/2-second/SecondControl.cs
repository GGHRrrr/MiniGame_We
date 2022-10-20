using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondControl : MonoBehaviour
{
    public GameObject e;

    #region ״̬����
    private bool isFlowerShop;
    private bool isFlower;
    private bool isFirstFlower = true;
    private bool isTransport;
    #endregion

    #region ��Ϸ����
    public GameObject Transport;
    #endregion

    void Start()
    {
        
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
                        "Human:�������һ�Ѽ�������һ���������ߡ�"
                    };
                    //�����Ի�
                    DialoguePanel.Instance.ShowDialogue(info);
                    isFirstFlower = false;
                }
                else
                {
                    if (false)
                    {
                        //TODO:�޼���ʱ���߼�
                        string[] info =
                        {
                            "Human:�������һ�Ѽ�������һ���������ߡ�"
                        };
                        DialoguePanel.Instance.ShowDialogue(info);
                    }
                    else
                    {
                        //TODO:�м���ʱ���߼�
                    }

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
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + Vector3.left;
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
