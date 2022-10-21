using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject outPostRoom;
    //后处理
    private GameObject post;

    //音效组件
    private AudioSource audio;
    //开门音效文件
    private AudioClip cantOpenDoor;
    //对话框
    public GameObject dialogueFrame;
    

    #endregion
    #region 判断条件
    public static bool isPlayerEnterWork = false;
    public static bool isNowEnter = false;
     bool isEnterDoor=false;
     bool isEnterWindow = false;
     bool isInsideLeft = false;
     bool isInsideRight = false;
     bool isUnderLeft = false;
     bool isNextLevel = false;
     bool isEnterHole = false;
     bool isEnterOutPostDoor = false;
     bool isExitOutPost = false;
    bool isEndDia = false;
    //判断首次交互
    private bool isFirst = true;
    #endregion
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.USEITEM_SHENGZI.ToString(), UseShengzi);
    }
    private void Start()
    {
        post = GameObject.Find("Post").gameObject;
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        cantOpenDoor = Resources.Load<AudioClip>("Audio/Sound/门锁住打不开");
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
                    //播放音效
                    if (!audio.isPlaying)
                    {
                        audio.PlayOneShot(cantOpenDoor,0.8f);
                    }
                        
                }
            } 
        }
        if(isEnterWindow&&!isPlayerEnterWork)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                string[] dialogues = { "Human:YiYi,你先进去，将正门打开。", "Yiyi:收到！" };
                DialoguePanel.Instance.ShowDialogue(dialogues);
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
                //触发对话
                string[] dialogues =
                {
                    "Human:这下捅了Yiyi窝了。",
                    "Yiyi:SPY-007量产侦察机器人，人类值得信赖的好伙伴。",
                    "Human:如果你突然关机混了进去，我肯定会把你和它们搞混的吧。"
                };
                DialoguePanel.Instance.ShowDialogue(dialogues);
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
        //进入哨站
        if(isEnterOutPostDoor&!gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            //49. 2.5
            //44.5/47   44
            if(Input.GetKeyDown(KeyCode.E))
            {
                //cam.transform.position = new Vector3(44, cam.transform.position.y, cam.transform.position.z);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(46, 0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(45.6f, 0);
                cam.transform.position = new Vector3(45.6f, cam.transform.position.y, cam.transform.position.z);
                gameObject.transform.localPosition = new Vector3(203f, transform.localPosition.y, transform.localPosition.z);
                outPostRoom.SetActive(true);
                workEnv.SetActive(false);
            }
            
        }
        //离开哨站
        if (isExitOutPost && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                outPostRoom.SetActive(false);
                workEnv.SetActive(true);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(49f, 0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(2.5f, 0);
                gameObject.transform.localPosition = new Vector3(230f, transform.localPosition.y, transform.localPosition.z);
            }
        }

        //触发关卡结束对话
        if (isEndDia && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            isEndDia = false;
            //移动位置，防止重复触发对话
            transform.position = new Vector3(transform.position.x + 1, transform.position.y,transform.position.z);
            
            print("已关闭移动");
            string[] dialogues =
            {
                "Human:人们都已经撤离了这座城市，是时候该踏上新的行程了。",
                "Yiyi:下一处地点是稀望镇，但经过推算，那里依旧不存在人类生存的可能。",
                "Human:也许吧。但那里是我们通往下一城市的必经之处，也许我们会有新的收获。",
                "Human:看，就在那里。"
            };
            DialoguePanel.Instance.ShowDialogue(dialogues);
            
        }
        

        //进入下一关
        if (isNextLevel && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                int count = SceneManager.GetActiveScene().buildIndex ;
                if (count < 2)
                    SceneManager.LoadSceneAsync(count + 1);
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
                isEnterWindow = true;
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
            case "holetrigger":
                isEnterHole = true;
                Debug.Log("碰到坑了");
                //触发对话
                string[] dialogues = { "Human:也许我需要另寻他法。" };
                DialoguePanel.Instance.ShowDialogue(dialogues);
                break;
            case "outPostDoor":
                ShowPlayerE(true);
                isEnterOutPostDoor = true;
                Debug.Log("碰到哨站了，准备进入");
                break;
            case "outpostleft":
                ShowPlayerE(true);
                isExitOutPost = true;
                Debug.Log("准备离开哨站");
                break;
            case "endDia":
                //到达地图末尾，关闭主角的移动，进行对话，对话完毕开启移动
                isEndDia = true;
                Debug.Log("到达地图末尾");
                break;
            case "NextLevel":
                ShowPlayerE(true);
                Debug.Log("碰到下一关的门了，准备进入下一关");
                isNextLevel = true;
                break;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "breakWindow":
                ShowPlayerE(false);
                isEnterWindow=false;
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
            case "NextLevel":
                ShowPlayerE(false);
                isNextLevel = false;
                break;
            case "holetrigger":
                isEnterHole = false;
                ShowPlayerE(false);
                break;
            case "outPostDoor":
                isEnterOutPostDoor = false;
                ShowPlayerE(false);
                break;
            case "outpostleft":
                ShowPlayerE(false);
                isExitOutPost = false;
                break;
            case "endDia":
                //到达地图末尾，关闭主角的移动，进行对话，对话完毕开启移动
                isEndDia = false;
                break;
        }
    }

    //与机器人碰撞交互
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "guardRobot":
                //判断是否为首次交互且判断是否存在身份卡(后续背包添加)
                //TODO:不存在身份卡,条件后面改
                if (false)
                {
                    if (isFirst)
                    {
                        print("首次交互，无身份卡");
                        string[] dialogues = { "无身份卡者禁止通行。" };
                        DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                        isFirst = false;
                    }
                    else
                    {
                        //多次交互，无身份卡
                        print("多次交互，无身份卡");
                        string[] dialogues = { "警告！无身份卡者禁止通行！" };
                        DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                    }
                }
                else
                {
                    //已存在身份卡
                    string[] dialogues = { "身份识别通过，允许通行。" };
                    DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                    collision.collider.transform.position = new Vector3(collision.collider.transform.position.x, collision.collider.transform.position.y + 0.5f, collision.collider.transform.position.z);
                    collision.collider.GetComponent<BoxCollider2D>().enabled = false;
                }
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
    void UseShengzi(object info)
    {
        if(isEnterHole)
        {
            var shengzi = GameObject.Find("Envrionments/WorkImage").transform.GetChild(1).gameObject;
            shengzi.SetActive(true);
        }
    }
}
