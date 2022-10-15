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
    private GameObject cam;
    private bool isEnterWindow = false;
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            switch (collision.name)
            {
                case "breakWindow":
                isEnterWindow = false;
                break;
            }
    }
}
