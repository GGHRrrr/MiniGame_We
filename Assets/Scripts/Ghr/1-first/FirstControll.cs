using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstControll : MonoBehaviour
{
    #region 物体
    public GameObject e;
    //相机
    public GameObject cam;
    //人物
    public GameObject yiyi;
    //场景
    public GameObject workEnv;
    public GameObject workInsideEnv;
    public GameObject workInsidUnder;
    //后处理
    private GameObject post;

    #endregion
    #region 判断条件

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
                    gameObject.transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
                    yiyi.transform.localPosition = new Vector3(-9f, yiyi.transform.localPosition.y, yiyi.transform.localPosition.z);
                    yiyi.transform.GetChild(0).gameObject.SetActive(true);
                    isPlayerEnterWork = true;
                    post.transform.GetChild(0).gameObject.SetActive(true);
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
        //离开工厂
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
        //进入地下一层
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
        //地下一层到工厂
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
                ShowPlayerE(true);
                Debug.Log("碰到窗户了！");
                break;
            case "workDoor":
                Debug.Log("碰到门了！");
                ShowPlayerE(true);
                isEnterDoor = true;
                break;
            case "insideLeft":
                isInsideLeft = true;
                ShowPlayerE(true);
                Debug.Log("碰到外边的门了！准备出去了");
                break;
            case "insideRight":
                isInsideRight=true;
                ShowPlayerE(true);
                Debug.Log("碰到里边的门了，准备进入下一层");
                break;
                case"under_left":
                isUnderLeft = true;
                ShowPlayerE(true);
                Debug.Log("碰到地下一层的门了，准备下一层");
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                ShowPlayerE(false);
                break;
            case "workDoor":
                isEnterDoor = false;
                ShowPlayerE(false);
                break;
            case "insideLeft":
                isInsideLeft = false;
                ShowPlayerE(false);
                break;
            case "insideRight":
                isInsideRight = false;
                ShowPlayerE(false);
                break;
            case "under_left":
                isUnderLeft = false;
                ShowPlayerE(false);
                break;
        }
    }
    IEnumerator Fade(GameObject gameObj, bool isFade)//写一个渐变函数
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
