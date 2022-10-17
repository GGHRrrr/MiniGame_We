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
    public  bool isTotalunLocked=false;//解密全部解锁
    public  bool isEnterWork = false;
    private bool isEnterWindow = false;
    private bool isEnterHandle = false;
    private bool isEnterBox=false;
    private Vector2 nowPos;
    private Vector2 palyerNowPos;
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.KeyDown_Tab.ToString(), OnKey_TabDownEvnet);
        EventManager.Instance().AddEventListener(EventTypeEnum.Unlock_Circuit.ToString(), UnlockCircuit);
    }
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        palyerNowPos = player.transform.localPosition;
    }
    private void Update()
    {
        #region yiyi交互事件
        if (isEnterWindow)
        {
            if (Input.GetKeyDown(KeyCode.E)&&player.GetComponent<SwitchRole>().isYiYi)
            {
                Debug.Log("yiyi在窗户吗，进入仓库");
                isEnterWork = true;
                workEnv.SetActive(false);
                workEnv_Inside.SetActive(true);
                player.GetComponent<SwitchRole>().enabled = false;
                player.GetComponent<PlayerMove>().enabled = false;
                gameObject.transform.localPosition = new Vector3(23, transform.position.y,transform.position.z);
                player.transform.GetChild(0).gameObject.SetActive(false);
                cam.transform.position = new Vector3(14f, cam.transform.position.y, cam.transform.position.z);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(15,0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(2.5f, 0);
                //player.GetComponent<SwitchRole>().IsFollow = false;
            }
        }//进入窗户
        //打开关闭把手
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
           
        }
        //与电路箱交互,打开关闭电路箱
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
        //在场景内部，按压tab机器人和玩家分离操作
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EventManager.Instance().EventTrigger(EventTypeEnum.KeyDown_Tab.ToString(), "");
        }
        
        
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
    /// <summary>
    /// 在工厂内部按压tab事件，分离操作
    //控制相机跟随，玩家与yiyi位置.目前直接转换isFollow=false会有莫名的问题，暂且转化时先把玩家隐藏，位置赋值到yiyi的位置，减缓跟随的效果；
    /// </summary>
    /// <param name="info"></param>
    private void OnKey_TabDownEvnet(object info)
    {
        //切换至工厂外。
        if (workEnv_Inside.gameObject.activeInHierarchy && isEnterWork)
        {
            if(player.GetComponent<SwitchRole>().isYiYi)
            //if (player.GetComponent<SwitchRole>().IsFollow == false)
            {
                player.GetComponent<SwitchRole>().enabled = true;
                player.GetComponent<PlayerMove>().enabled = true;
                player.transform.localPosition = palyerNowPos;
                nowPos = transform.localPosition;
                workEnv.gameObject.SetActive(true);
                workEnv_Inside.gameObject.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                player.transform.GetChild(0).gameObject.SetActive(true);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(49, 0);
            }
        }
        //切换至工厂内.
        if (!workEnv_Inside.gameObject.activeInHierarchy && isEnterWork && !player.GetComponent<SwitchRole>().isYiYi)//player.GetComponent<SwitchRole>().IsFollow)
        {
            player.GetComponent<SwitchRole>().enabled = false;
            player.GetComponent<PlayerMove>().enabled = false;
            palyerNowPos = player.transform.localPosition;
            cam.transform.position = new Vector3(14f, cam.transform.position.y, cam.transform.position.z);
            workEnv.gameObject.SetActive(false);
            workEnv_Inside.gameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            player.transform.GetChild(0).gameObject.SetActive(false);
            player.transform.localPosition = new Vector3(nowPos.x, player.transform.localPosition.y,player.transform.localPosition.z);
            transform.localPosition = nowPos;
            cam.GetComponent<CameraFollow>().maxPos = new Vector2(15, 0);
        }
    }
    private void UnlockCircuit(object info)
    {
      cir.gameObject.SetActive(false);
        isTotalunLocked = true;
        StartCoroutine(CricuitAni());
    }
    //电路解密完做一个渐隐效果，可以考虑用Dotween,目前用携程来做
    IEnumerator CricuitAni()
    {
        workEnv.gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        player.transform.localPosition = new Vector3(6f, player.transform.localPosition.y, player.transform.localPosition.z);
        player.transform.GetChild(0).gameObject.SetActive(true);
        SpriteRenderer workEnv_Inside_Spr = workEnv_Inside.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        while (workEnv_Inside_Spr.color.a>=0.05)
        {
            yield return new WaitForSeconds(0.05f);
            workEnv_Inside_Spr.color = new Color(1, 1, 1, workEnv_Inside_Spr.color.a - 0.05f);
        }
        workEnv_Inside.gameObject.SetActive(false);
        workEnv_Inside_Spr.color = new Color(1, 1, 1, 1);
        PlayerManager.Instance().state = E_Player_State.Common;
        player.GetComponent<SwitchRole>().enabled = true;
        player.GetComponent<SwitchRole>().IsFollow = true;
        player.GetComponent<PlayerMove>().enabled = true;
        cam.GetComponent<CameraFollow>().maxPos = new Vector2(49, 0);
        StartCoroutine(Fade(workEnv.transform.GetChild(0).gameObject, false));
        gameObject.GetComponent<YiyiMove>().moveSpeed = 10;
    }

    IEnumerator Fade(GameObject gameObj,bool isFade)//写一个渐变函数
    {
        SpriteRenderer spriteRenderer = gameObj.GetComponent<SpriteRenderer>();
        if(isFade)
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
