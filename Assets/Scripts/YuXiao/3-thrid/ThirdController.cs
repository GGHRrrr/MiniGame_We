using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdController : MonoBehaviour
{

    private Animator anim;
    public GameObject e;
    //书本UI
    public GameObject book;
    //yiyi对象
    public Transform yiyi;

    //黑幕面板
    public GameObject black;
    //火堆
    public GameObject unfinishedFire;
    public GameObject finishedFire;
    public GameObject PowerfulFire;
    public GameObject CommonFire;

    //对话框
    public GameObject dialoguePanel;

    #region 状态变量
    private bool isBook;
    //是否已经点亮了火堆
    private bool isFire = false;
    //是否达成通关条件
    private bool isSuccess = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //播放BGM
        MusicManager.Instance().PlayBGM("荒原bgm");
        //挡风沙行走
        anim = GetComponent<Animator>();
        anim.SetBool("HardWalk", true);
        gameObject.GetComponent<PlayerMove>().moveSpeed = 4;
    }

    void Update()
    {
        if (isBook && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                book.SetActive(true);
            }
        }

        //结束对话时进入下一幕
        if (!dialoguePanel.activeInHierarchy && isFire)
        {
            StartCoroutine(Anim2(black));
            isFire = false;
        }

        if (!dialoguePanel.activeInHierarchy && isSuccess)
        {
            StartCoroutine(Anim3(black));
            isSuccess = false;
        }
    }

    #region 触发器相关
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "SwitchAnim":
                anim.SetBool("HardWalk", false);
                gameObject.GetComponent<PlayerMove>().moveSpeed = 7;
                break;
            case "交互用书":
                ShowPlayerE(true);
                isBook = true;
                print("触碰到交互用书");
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "SwitchAnim":
                anim.SetBool("HardWalk", true);
                gameObject.GetComponent<PlayerMove>().moveSpeed = 4;
                break;
            case "交互用书":
                ShowPlayerE(false);
                isBook = false;
                break;
        }
    }
    #endregion

    #region 碰撞器相关
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "未搭建的火把":
                //点火
                StartCoroutine(Anim1(black));
                break;
        }
    }
    #endregion

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

    IEnumerator Anim1(GameObject panel)//写一个渐变函数
    {
        Image img = panel.GetComponent<Image>();

        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //完全黑幕了改变物体状态
        //改变火和柴的状态
        finishedFire.SetActive(true);
        unfinishedFire.SetActive(false);
        PowerfulFire.SetActive(true);
        //修改主角动作和位置
        transform.localPosition = new Vector3(124, transform.position.y, transform.position.z);
        yiyi.localPosition = new Vector3(144, 6, yiyi.position.z);
        yiyi.localScale = new Vector3(-yiyi.localScale.x, yiyi.localScale.y, yiyi.localScale.z);
        GetComponent<Animator>().SetBool("sittiing", true);
        //关闭跟随
        GetComponent<PlayerMove>().enabled = false;

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }

        //触发对话
        string[] info =
        {
            "Human:在抵达下一座城市之前，好好休息一下把。",
            "Human:从我遇到你的那天起，我就没见你休息过，你不会感觉到疲倦吗？",
            "Yiyi:不会，但如果你命令我进入休眠状态，我也可以短暂的休息一段时间。",
            "Human:真相真的就在那座城市吗？",
            "Human:这一路上走走停停，像是一场旅行，而这场旅行的终点，就暂定为前方的那座城市吧。",
            "Yiyi:旅游不在乎终点，而是在意途中的人和事还有那些美好的记忆和景色。",
            "Human:这是从哪学的文邹邹的话......",
            "Human:不过你说的没错，旅途并不在乎终点，而终点，只是下一场旅行的起点罢了。",
            "Human:yiyi,你休眠吧！休整完该踏上最后一段路了。",
            "Yiyi:接收到休眠指令，待机中......"


        };

        DialoguePanel.Instance.ShowDialogue(info);
        isFire = true;
        
    }

    IEnumerator Anim2(GameObject panel)//写一个渐变函数
    {
        Image img = panel.GetComponent<Image>();

        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //完全黑幕了改变物体状态
        //修改主角动作和位置
        transform.localPosition = new Vector3(168, transform.position.y, transform.position.z);
        //GetComponent<Animator>().SetBool("sittiing", true);

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }

        //触发对话
        string[] info =
        {
            "Human:.....",
            "Human:该打起精神了。",
            
            "Human:隐隐不安啊。",
            "Human:接下来只能希望一切顺利了。",
            "Human::......夕阳真美啊。"
        };

        DialoguePanel.Instance.ShowDialogue(info);
        isSuccess = true;
    }

    IEnumerator Anim3(GameObject panel)//写一个渐变函数
    {
        Image img = panel.GetComponent<Image>();

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

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
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
