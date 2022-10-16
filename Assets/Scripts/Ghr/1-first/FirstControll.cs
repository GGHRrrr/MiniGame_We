using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstControll : MonoBehaviour
{
    public GameObject cam;
    public GameObject yiyi;
    public GameObject workEnv;
    public GameObject workInsideEnv;
    private bool isEnterDoor=false;
    private bool isEnterWindow = false;
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
                Debug.Log("玩家在大门，播放音乐");
            } 
        }
        if(isEnterWindow)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                Debug.Log("玩家在窗户吗，输出文字");
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
        }
    }
}
