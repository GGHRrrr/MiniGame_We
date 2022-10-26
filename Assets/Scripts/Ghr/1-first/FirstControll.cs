using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstControll : MonoBehaviour
{
    #region 物体
    public GameObject e;
    public GameObject touying;
    public GameObject mimaxiang;
    //相机
    public GameObject cam;
    //人物
    public GameObject yiyi;
    //场景
    public GameObject workEnv;
    public GameObject workInsideEnv;
    public GameObject workInsidUnder;
    public GameObject outPostRoom;
    public GameObject mapPanel;
    //后处理
    private GameObject post;

    //音效组件
    private AudioSource audio;
    //开门音效文件
    private AudioClip cantOpenDoor;
    //影像音效文件
    private AudioClip openTouying;
    //开门音效文件
    private AudioClip openDoor;
    //对话框
    public GameObject dialogueFrame;
    public GameObject daPanel;

    public GameObject black;

    #endregion
    #region 判断条件
    
     public static bool isPlayerEnterWork = false;
     public static bool isNowEnter = false;
     public  bool isHaveShenfen = false;
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
     bool isEnterTouying = false;
     bool isEnterMima = false;
    //判断首次交互
    private bool isFirst = true;
    int touyingCount = 0;
    #endregion
    private void Awake()
    {
        EventManager.Instance().AddEventListener(EventTypeEnum.USEITEM_SHENGZI.ToString(), UseShengzi);
    }
    private void Start()
    {
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        post = GameObject.Find("Post").gameObject;
        MusicManager.Instance().PlayBGM("城市BGM");
        cantOpenDoor = Resources.Load<AudioClip>("Audio/Sound/门锁住打不开");
        openTouying = Resources.Load<AudioClip>("Audio/Sound/投影中留言");
        openDoor = Resources.Load<AudioClip>("Audio/Sound/开门声");
        
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),2);
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Aric",1));
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Hank",1));
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Hank",2));
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
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                post.SetActive(true);
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
                post.SetActive(false);
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
                if (!audio.isPlaying)
                    audio.PlayOneShot(openDoor, 0.8f);
                //cam.transform.position = new Vector3(44, cam.transform.position.y, cam.transform.position.z);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(46, 0);
                cam.GetComponent<CameraFollow>().minPos = new Vector2(45.6f, 0);
                cam.transform.position = new Vector3(45.6f, cam.transform.position.y, cam.transform.position.z);
                gameObject.transform.localPosition = new Vector3(179f, transform.localPosition.y, transform.localPosition.z);
                outPostRoom.SetActive(true);
                workEnv.SetActive(false);
            }
            
        }
        //进入投影
        if(isEnterTouying & !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!touying.activeInHierarchy)
                    touying.gameObject.SetActive(true);
                if (!daPanel.activeInHierarchy)
                    daPanel.SetActive(true);
                if (touyingCount < 8)
                    touyingCount++;
                switch (touyingCount)
                {
                    case 1:
                        if (!audio.isPlaying)
                            audio.PlayOneShot(openTouying, 0.8f);
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "今天是我最后一次在这里站岗了";
                        break;
                    case 2:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "人们已经离开了这座城市，而我也将随最后一批人员进行转移";
                        break;
                    case 3:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "具体转移的原因上级没有明确说明，但我只需要完成自己的本职工作就好";
                        break;
                    case 4:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "前往新的城市，我也将彻底与过去的自己告别,身份卡也不再需要";
                        break;
                    case 5:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "我将它放在了密码盒中，如果遇上有需要的人就拿走吧";
                        break;
                    case 6:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "密码是1025，我的编号";
                        break;
                    case 7:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "再见，故乡";
                        break;
                    case 8:
                        daPanel.transform.GetChild(1).GetComponent<Text>().text = "我的编号是1025，可不要忘了";
                        break;
                }
            }
        }
        if (isEnterMima & !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!mimaxiang.activeInHierarchy)
                {
                    mimaxiang.SetActive(true);
                    gameObject.GetComponent<PlayerMove>().moveSpeed = 0;
                }
                else
                {
                    mimaxiang.SetActive(false);
                    gameObject.GetComponent<PlayerMove>().moveSpeed = 7;
                }
                
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
                gameObject.transform.localPosition = new Vector3(200f, transform.localPosition.y, transform.localPosition.z);
            }
        }
        
        //进入下一关
        if (isNextLevel && !gameObject.GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Anim3(black));
            }
        }
        #endregion
    }

    IEnumerator Anim3(GameObject panel)//写一个渐变函数
    {
        mapPanel.SetActive(true);
        mapPanel.GetComponent<MapControll>().ShowMapAni(1);
        Image img = panel.GetComponent<Image>();
        yield return new WaitForSeconds(2f);
        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //完全黑幕了改变物体状态
        //切换场景
        //当前关卡编号
        int num = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(num + 1);
        yield return new WaitForSeconds(0.5f);

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "breakWindow":
                ShowPlayerE(true);
                isEnterWindow = true;
                break;
            case "workDoor":
                ShowPlayerE(true);
                isEnterDoor = true;
                break;
            case "insideLeft":
                isInsideLeft = true;
                ShowPlayerE(true);
                break;
            case "insideRight":
                isInsideRight=true;
                ShowPlayerE(true);
                break;
            case"under_left":
                isUnderLeft = true;
                ShowPlayerE(true);
                break;
            case "holetrigger":
                isEnterHole = true;
                //触发对话
                string[] dialogues = { "Human:也许我需要另寻他法。" };
                DialoguePanel.Instance.ShowDialogue(dialogues);
                break;
            case "outPostDoor":
                ShowPlayerE(true);
                isEnterOutPostDoor = true;
                break;
            case "outpostleft":
                ShowPlayerE(true);
                isExitOutPost = true;
                break;
            case "endDia":
                //到达地图末尾，关闭主角的移动，进行对话，对话完毕开启移动
                isEndDia = true;
                break;
            case "NextLevel":
                ShowPlayerE(true);
                isNextLevel = true;
                break;

            case "ca":
                ShowPlayerE(true);
                isEnterTouying = true;
                e.gameObject.SetActive(true);
                break;
            case "mima":
                ShowPlayerE(true);
                isEnterMima = true;
                ShowPlayerE(true);
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
            case "ca":
                isEnterTouying = false;
                touying.gameObject.SetActive(false);
                daPanel.SetActive(false);
                daPanel.transform.GetChild(1).GetComponent<Text>().text = "";
                e.gameObject.SetActive(false);
                break;
            case "mima":
                isEnterMima = false;
                ShowPlayerE(false);
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
                if (isHaveShenfen==false)
                {
                    if (isFirst)
                    {
                        string[] dialogues = { "无身份卡者禁止通行。" };
                        DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                        isFirst = false;
                    }
                    else
                    {
                        //多次交互，无身份卡
                        string[] dialogues = { "警告！无身份卡者禁止通行！" };
                        DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                    }
                    //哨兵切换动作
                    collision.collider.GetComponent<Animator>().SetTrigger("Nopass");
                }
                else
                {
                    //已存在身份卡
                    string[] dialogues = { "身份识别通过，允许通行。" };
                    DialoguePanel.Instance.ShowDialogue(dialogues, collision.collider.transform);
                    collision.collider.transform.position = new Vector3(collision.collider.transform.position.x, collision.collider.transform.position.y + 0.5f, collision.collider.transform.position.z);
                    collision.collider.GetComponent<BoxCollider2D>().enabled = false;
                    //哨兵切换动作
                    collision.collider.GetComponent<Animator>().SetTrigger("Pass");
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
