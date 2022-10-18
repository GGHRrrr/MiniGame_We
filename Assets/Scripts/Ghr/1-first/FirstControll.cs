using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstControll : MonoBehaviour
{
    public GameObject cam;
    public GameObject yiyi;
    public GameObject workEnv;
    public GameObject workInsideEnv;
    public GameObject InsideRight;
    public static bool isPlayerEnterWork = false;
    public static bool isNowEnter = false;
    private bool isEnterDoor=false;
    private bool isEnterWindow = false;
    private bool isInsideRight = false;
    private void Awake()
    {
        
    }
    private void Update()
    {

        #region 玩家交互事件
        if (isEnterDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(YiYiControll.isTotalunLocked&&isNowEnter==false)
                {
                    Debug.Log("进入工厂");
                    isNowEnter = true;
                    cam.GetComponent<CameraFollow>().maxPos = new Vector2(15f, 0);
                    workEnv.SetActive(false);
                    workInsideEnv.SetActive(true);
                    gameObject.transform.localPosition = new Vector3(130f, transform.localPosition.y, transform.localPosition.z);
                    yiyi.transform.localPosition = new Vector3(130f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
                    yiyi.transform.GetChild(0).gameObject.SetActive(true);
                    isPlayerEnterWork = true;
                }
                else
                {
                    Debug.Log("玩家在大门，播放音乐");
                }
            } 
        }
        if(isEnterWindow)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                Debug.Log("玩家在窗户吗，输出文字");
            }
        }
        if(isInsideRight&&!gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.localPosition = new Vector3(60f, transform.localPosition.y, transform.localPosition.z);
                yiyi.transform.localPosition = new Vector3(60f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
                workEnv.SetActive(true);
                workInsideEnv.SetActive(false);
                isNowEnter = false;
            }
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "breakWindow":
                Debug.Log("碰到窗户了！");
                
                break;
            case "workDoor":
                Debug.Log("碰到门了！");
                isEnterDoor = true;
                break;
            case "insideRight":
                isInsideRight = true;
                Debug.Log("碰到里面的门了！准备出去了");
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                Debug.Log("待在窗户！");
                break;
            case "workDoor":
                isEnterDoor = false;
                break;
            case "insideRight":
                isInsideRight = false;
                break;
        }
    }
}
