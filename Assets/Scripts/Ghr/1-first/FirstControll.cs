using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstControll : MonoBehaviour
{
    #region ����
    //���
    public GameObject cam;
    //����
    public GameObject yiyi;
    //����
    public GameObject workEnv;
    public GameObject workInsideEnv;
    public GameObject workInsidUnder;
    //����
    private GameObject post;

    #endregion
    #region �ж�����

    public static bool isPlayerEnterWork = false;
    public static bool isNowEnter = false;
    private bool isEnterDoor=false;
    private bool isEnterWindow = false;
    private bool isInsideLeft = false;
    private bool isInsideRight = false;
    private bool isUnderLeft = false;
    #endregion
    private void Awake()
    {
        
    }
    private void Start()
    {
        post = GameObject.Find("Post").gameObject;
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
                }
            } 
        }
        if(isEnterWindow)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
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
            if(Input.GetKeyDown(KeyCode.E))
            {
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
                workInsidUnder.SetActive(false);
                workInsideEnv.SetActive(true);
                gameObject.transform.localPosition = new Vector3(130f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(130f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
            }
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "breakWindow":
                Debug.Log("���������ˣ�");
                
                break;
            case "workDoor":
                Debug.Log("�������ˣ�");
                isEnterDoor = true;
                break;
            case "insideLeft":
                isInsideLeft = true;
                Debug.Log("������ߵ����ˣ�׼����ȥ��");
                break;
            case "insideRight":
                isInsideRight=true;
                Debug.Log("������ߵ����ˣ�׼��������һ��");
                break;

                case"under_left":
                isUnderLeft = true;
                Debug.Log("��������һ������ˣ�׼����һ��");
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                break;
            case "workDoor":
                isEnterDoor = false;
                break;
            case "insideLeft":
                isInsideLeft = false;
                break;
            case "insideRight":
                isInsideRight = false;
                break;
            case "under_left":
                isUnderLeft = false;
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
}
