using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondControl : MonoBehaviour
{
    public GameObject e;
    public Transform point1;
    public Transform point2;
    public GameObject black;
    //调酒相关
    public GameObject flower;
    public GameObject suger;
    public GameObject wine;
    public GameObject wineBack;
    public GameObject cup;
    public GameObject qte;
    public GameObject finishedWine;

    #region 状态变量
    private bool isFlowerShop;
    //一枝花对话
    private bool isFlower;
    private bool isFirstFlower = true;
    private bool isTransport;
    private bool isEnterRest;
    //厨师对话
    private bool isCooker;
    private bool firstCooker = true;
    private bool firstFinish = true;
    //调酒
    private bool isBartender;
    //出门
    private bool isExit;
    //碰到糖罐子
    private bool isSuger;
    //收集物数目
    private int count = 0;
    public bool isRight = false;
    #endregion

    #region 游戏对象
    public GameObject Transport;
    //场景
    public GameObject Restaround;
    public GameObject Village;
    //NPC
    public Transform waiter;
    public Transform cooker;
    //Yiyi
    private Transform Yiyi;
    //相机
    private Camera cam;
    #endregion

    void Start()
    {
        cam = Camera.main;
        Yiyi = transform.parent.Find("yiyi").transform;
        //播放BGM
        MusicManager.Instance().PlayBGM("乡镇BGM");
        
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_LOG.ToString(),3);
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Aric",2));
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Alice",1));
        EventManager.Instance().EventTrigger(EventTypeEnum.INTER_MESSAGE.ToString(),
            new KeyValuePair<string,int>("Hank",3));
    }

    
    void Update()
    {
        //触碰到花店
        if (isFlowerShop && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                string[] info =
                {
                    "Human:人们走后，花房的花儿竟如此自由的盛放。",
                    "Yiyi:不受约束的美总是令人向往。"
                };
                //触发对话
                DialoguePanel.Instance.ShowDialogue(info);
            }
        }

        //触碰到伸出的花
        if (isFlower && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                string[] info =
                {
                   "Human:真美啊。",
                };
                //触发对话
                DialoguePanel.Instance.ShowDialogue(info);
                flower.SetActive(true);
                count++;
            }
        }

        //触碰到交通机器人
        if (isTransport && !GetComponent<SwitchRole>().isYiYi)
        {
            if (!qte.GetComponent<UIqte>().isFinish)
            {
                //没有车票
                string[] info =
                {
                    "如需乘坐，请出示车票。"
                };
                //触发对话
                DialoguePanel.Instance.ShowDialogue(info,Transport.transform);
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                //有车票
                string[] info =
                {
                    "感谢本次乘坐，下一站：荒原边境。"
                };
                
                //触发对话
                DialoguePanel.Instance.ShowDialogue(info, Transport.transform);
                //TODO:坐车！过场
                StartCoroutine(guochang());
                //transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            }
            
        }

        //触发了进入餐厅
        if (isEnterRest && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //进入餐厅
                Restaround.SetActive(true);
                Village.SetActive(false);
                transform.position = point2.position;
                Yiyi.position = point2.position + 3 * Vector3.right;
                //摄像机阈值
                cam.GetComponent<CameraFollow>().minPos = new Vector2(9.4f ,0);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(35.3f, 0);

                //触发对话
                string[] info =
                {
                    "欢迎光临本店，如需用餐请选取空闲位置坐下等待服务。",
                    "Human:菜单可以过目一下吗？",
                    "请用。",
                    "Human:终焉之花，听起来好有意境。",
                    "鸡尾酒类现调酒饮品请咨询酒保。"
                };
                DialoguePanel.Instance.ShowDialogue(info, waiter);
            }
        }

        //与厨师交互
        if (isCooker && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (firstCooker)
                {
                    //第一次与厨师交互
                    string[] info =
                    {
                        "Human:你好，请来一杯终焉之花。",
                        "抱歉，该酒所需的原料已经用完了。",
                        "我已经很多年没有制作过它了，但即便如此，它依旧是本店的招牌。",
                        "如果你能制作出这杯酒，我可以送你一张车票。",
                        "这是许多年前一位客人留下的，似乎是想让我转赠给前来赴约的顾客。",
                        "如果你能制作出这样的三明治，我可以送你一张车票。"
                    };
                    DialoguePanel.Instance.ShowDialogue(info, cooker);
                    firstCooker = false;
                    wine.SetActive(true);
                    count++;
                }
                else
                {
                    //不是首次交互
                    if (!qte.GetComponent<UIqte>().isFinish)
                    {
                        //未制作出三明治
                        string[] info =
                        {
                            "如果你能制作出这样的三明治，我可以送你一张车票。"
                        };
                        DialoguePanel.Instance.ShowDialogue(info, cooker);
                    }
                    else
                    {
                        if (firstFinish)
                        {
                            //已制作出三明治，首次交互
                            string[] info =
                            {
                                "Human:终焉之花制作完成了。",
                                "它可真美。",
                                "只可惜我从未，也无法品尝它的味道。",
                                "这是车票，带上它吧。",
                                "一路顺风，我的客人。"
                            };
                            DialoguePanel.Instance.ShowDialogue(info, cooker);
                            firstFinish = false;
                            finishedWine.SetActive(false);
                            //TODO:获得车票
                        }
                        else
                        {
                            string[] info =
                            {
                                "一路顺风，我的客人。"
                            };
                            DialoguePanel.Instance.ShowDialogue(info, cooker);
                        }
                        
                    }
                }
            }
        }

        //收集糖
        if (isSuger && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                suger.SetActive(true);
                count++;
            }            
        }

        //TODO:调酒逻辑
        if (isBartender && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //进入调酒UI页面
                if (count >= 3)
                {
                    wineBack.SetActive(true);
                    cup.SetActive(true);
                }
                else
                {
                    string[] info =
                    {
                        "Human:调酒需要花，酒和糖，目前材料不够。"
                    };
                    DialoguePanel.Instance.ShowDialogue(info);
                }
                
            }
        }

        //出门逻辑(分为有车票和无车票)
        if (isExit && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //出餐厅
                Restaround.SetActive(false);
                Village.SetActive(true);
                transform.position = point1.position;
                Yiyi.position = point1.position + 3 * Vector3.left;
                //摄像机阈值
                cam.GetComponent<CameraFollow>().minPos = new Vector2(3, 0);
                cam.GetComponent<CameraFollow>().maxPos = new Vector2(41, 0);

                //如果有车票(触发对话)
                //TODO:修改条件
                if (qte.GetComponent<UIqte>().isFinish)
                {
                    string[] info =
                    {
                        "Human:原来“他”没有去赴约么......",
                        "Human:那为什么，在信息中，他却说他和“他”刚一起吃完饭呢？",
                        "Yiyi:从理性的角度分析，他们并非同一个人。",
                        "Human:也许真是如此吧。"
                    };
                    DialoguePanel.Instance.ShowDialogue(info);
                }
            }
        }
    }

    #region 触发器相关
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "FlowerShop":
                //展示E图标
                ShowPlayerE(true);
                //修改状态变量
                isFlowerShop = true;
                print("触碰到花店");
                break;
            case "Flower":
                ShowPlayerE(true);
                isFlower = true;
                print("触碰到伸出的花");
                break;
            case "EnterRest":
                ShowPlayerE(true);
                isEnterRest = true;
                print("碰到餐厅门槛");
                break;
            case "Cooker":
                ShowPlayerE(true);
                isCooker = true;
                print("碰到厨师");
                break;
            case "Exit":
                ShowPlayerE(true);
                isExit = true;
                print("碰到出口，按E离开");
                break;
            case "雪克壶":
                ShowPlayerE(true);
                isBartender = true;
                print("碰到雪克壶，按E进行调酒");
                break;
            case "糖罐子":
                ShowPlayerE(true);
                isSuger = true;
                print("碰到糖罐子");
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "FlowerShop":
                //展示E图标
                ShowPlayerE(false);
                //修改状态变量
                isFlowerShop = false;
                break;
            case "Flower":
                ShowPlayerE(false);
                isFlower = false;
                break;
            case "EnterRest":
                ShowPlayerE(false);
                isEnterRest = false;
                break;
            case "Cooker":
                ShowPlayerE(false);
                isCooker = false;
                break;
            case "Exit":
                ShowPlayerE(false);
                isExit = false;
                break;
            case "雪克壶":
                ShowPlayerE(false);
                isBartender = false;
                break;
            case "糖罐子":
                ShowPlayerE(false);
                isSuger = false;
                break;
        }
    }
    #endregion

    #region 碰撞体相关
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "Transport":
                isTransport = true;
                //collision.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                //collision.transform.localPosition = new Vector2(collision.transform.localPosition.x, collision.transform.localPosition.y + 0.5f);
                print("触碰到交通机器人");
                break;
            case "Right":
                isRight = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "Transport":
                isTransport = false;
                break;
            case "Right":
                isRight = false;
                break;
        }
    }
    #endregion

    IEnumerator guochang()
    {
        yield return new WaitForSeconds(3f);
        black.gameObject.SetActive(true);
        StartCoroutine(Fade(black, false));
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(4);
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
                yield return new WaitForSeconds(0.1f);
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
