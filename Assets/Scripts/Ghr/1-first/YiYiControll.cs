using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class YiYiControll : MonoBehaviour
{  
    //��ʼ���������ֵ2.5 49 
    //���빤�����������ֵ2.5 15
    public GameObject workEnv;
    public GameObject workEnv_Inside;
    public GameObject player;
    public GameObject handle;
    public GameObject box;
    public GameObject cir;
    private GameObject cam;
    private bool isEnterWork = false;
    private bool isEnterWindow = false;
    private bool isEnterHandle = false;
    private bool isEnterBox=false;
    private Vector2 nowPos;
    private Vector2 palyerNowPos;
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.KeyDown_Tab.ToString(), OnKey_TabDownEvnet);
    }
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        palyerNowPos = player.transform.localPosition;
    }
    private void Update()
    {

        #region yiyi�����¼�
        if (isEnterWindow)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("yiyi�ڴ����𣬽���ֿ�");
                isEnterWork = true;
                workEnv.SetActive(false);
                workEnv_Inside.SetActive(true);
                gameObject.transform.localPosition = new Vector3(23, transform.position.y,transform.position.z);
                player.transform.GetChild(0).gameObject.SetActive(false);
                cam.transform.position = new Vector3(14f, cam.transform.position.y, cam.transform.position.z);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(15,0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(2.5f, 0);
                player.GetComponent<SwitchRole>().IsFollow = false;
            }
        }//���봰��
        if(isEnterHandle)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (handle.GetComponent<SpriteRenderer>().enabled == true)
                {
                    handle.transform.GetChild(0).gameObject.SetActive(true);
                    handle.GetComponent<SpriteRenderer>().enabled = false;
                    Debug.Log("�򿪿�����");
                }
                else
                {
                    handle.transform.GetChild(0).gameObject.SetActive(false);
                    handle.GetComponent<SpriteRenderer>().enabled = true;
                    Debug.Log("�رտ����� ");
                }
            }
           
        }//����ֽ���
        if (isEnterBox)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("�򿪵�·����");
                if(cir.gameObject.activeSelf==false)
                {
                    box.GetComponent<BoxCollider2D>().enabled = false;
                    cir.gameObject.SetActive(true);
                    gameObject.GetComponent<YiyiMove>().moveSpeed = 0;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                
            }
        }
        else
        {
            if(cir.gameObject.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    box.GetComponent<BoxCollider2D>().enabled = true;
                    cir.gameObject.SetActive(false);
                    gameObject.GetComponent<YiyiMove>().moveSpeed = 10;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }    
            }
        }
        #endregion
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EventManager.Instance().EventTrigger(EventTypeEnum.KeyDown_Tab.ToString(), "");
           // if (workEnv_Inside.gameObject.activeInHierarchy)
           //{
                
           //     if (player.GetComponent<SwitchRole>().IsFollow == false)
           //     {
           //         workEnv.gameObject.SetActive(true);
           //         workEnv_Inside.gameObject.SetActive(false);
           //         gameObject.GetComponent<SpriteRenderer>().enabled=false;
           //         player.transform.GetChild(0).gameObject.SetActive(true);
           //         nowPos = transform.localPosition;
           //     }
           // }
           //if(!workEnv_Inside.gameObject.activeInHierarchy&&isEnterWork&& player.GetComponent<SwitchRole>().IsFollow)
           // {
           //     workEnv.gameObject.SetActive(false);
           //     workEnv_Inside.gameObject.SetActive(true);
           //     gameObject.GetComponent<SpriteRenderer>().enabled = true;
           //     player.transform.GetChild(0).gameObject.SetActive(false);
           //     transform.localPosition = nowPos;
           // }
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                Debug.Log("yiyi���������ˣ�");
                isEnterWindow = true;
                break;
            case "handle(up)":
                isEnterHandle = true;
                break;
            case "box":
                isEnterBox = true;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            switch (collision.name)
            {
                case "breakWindow":
                isEnterWindow = false;
                break;
            case "handle(up)":
                isEnterHandle = false;
                break;
            case "box":
                isEnterBox = false;
                break;
        }
    }
    private void OnKey_TabDownEvnet(object info)
    {
        if (workEnv_Inside.gameObject.activeInHierarchy&& isEnterWork)
        {
            if(player.GetComponent<SwitchRole>().isYiYi)
            //if (player.GetComponent<SwitchRole>().IsFollow == false)
            {
                player.transform.localPosition = palyerNowPos;
                workEnv.gameObject.SetActive(true);
                workEnv_Inside.gameObject.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                player.transform.GetChild(0).gameObject.SetActive(true);

                nowPos = transform.localPosition;
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(49, 0);
            }
        }
        if (!workEnv_Inside.gameObject.activeInHierarchy && isEnterWork &&!player.GetComponent<SwitchRole>().isYiYi)//player.GetComponent<SwitchRole>().IsFollow)
        {
            palyerNowPos = player.transform.localPosition;
            cam.transform.position = new Vector3(14f, cam.transform.position.y, cam.transform.position.z);
            workEnv.gameObject.SetActive(false);
            workEnv_Inside.gameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            player.transform.GetChild(0).gameObject.SetActive(false);
            player.transform.position = new Vector2(nowPos.x,player.transform.localPosition.y);
            transform.localPosition = nowPos;
            cam.GetComponent<CameraFollow>().maxPos = new Vector2(15, 0);
        }
    }
}
