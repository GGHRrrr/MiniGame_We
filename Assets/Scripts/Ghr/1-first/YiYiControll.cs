using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class YiYiControll : MonoBehaviour
{  
    //初始相机跟随数值2.5 49 
    //进入工厂相机跟随数值2.5 15
    public GameObject workEnv;
    public GameObject workEnv_Inside;
    public GameObject player;
    public GameObject handle;
    public GameObject box;
    public GameObject cir;
    private GameObject cam;
    private bool isEnterWindow = false;
    private bool isEnterHandle = false;
    private bool isEnterBox=false;
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
    }
    private void Update()
    {

        #region yiyi交互事件
        if (isEnterWindow)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("yiyi在窗户吗，进入仓库");
                workEnv.SetActive(false);
                workEnv_Inside.SetActive(true);
                gameObject.transform.localPosition = new Vector3(23, transform.position.y,transform.position.z);
                player.transform.GetChild(0).gameObject.SetActive(false);
                cam.transform.position = new Vector3(14f, cam.transform.position.y, cam.transform.position.z);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(15,0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(2.5f, 0);
            }
        }//进入窗户
        if(isEnterHandle)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (handle.GetComponent<SpriteRenderer>().enabled == true)
                {
                    handle.transform.GetChild(0).gameObject.SetActive(true);
                    handle.GetComponent<SpriteRenderer>().enabled = false;
                    Debug.Log("打开开关了");
                }
                else
                {
                    handle.transform.GetChild(0).gameObject.SetActive(false);
                    handle.GetComponent<SpriteRenderer>().enabled = true;
                    Debug.Log("关闭开关了 ");
                }
            }
           
        }//与把手交互
        if (isEnterBox)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("打开电路解谜");
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                Debug.Log("yiyi碰到窗户了！");
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
}
