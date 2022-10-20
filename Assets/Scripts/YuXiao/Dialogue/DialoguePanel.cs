using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*
    对话面板类：
        1.控制面板的显隐
        2.实现对话的切换
        3.实现对话遵循一定事件间隔弹出
 */
public class DialoguePanel : MonoBehaviour
{
    #region 单例模式
    //实现单例模式
    public static DialoguePanel Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }

    #endregion
    //布尔变量，监听玩家的对话行为
    public bool IsDialogue
    {
        get
        {
            if (panel_dialogue.activeInHierarchy)
            {
                return true;
            }
            return false;
        }
    }

    //对话面板对象
    public GameObject panel_dialogue;
    //对话跟随组件
    private CanvasFollow cf;

    //对话文字内容以及说话人
    public Text txt_dialogue;

    //对话出现的位置
    public Transform Human,Yiyi;
    //对话出现是否有固定位置
    private Transform fixedPos;

    //存储一次对话的所有内容
    [TextArea(1,3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine = 0;

    //滚动出现文字的开关与时间间隔
    private bool isScrolling;
    [SerializeField]private float textInterval;

    private void Start()
    {
        cf = GetComponent<CanvasFollow>();
    }

    //鼠标点击切换下一句
    void Update()
    {
        ClickNext();
    }

    //面板的显示
    public void ShowDialogue(string[] info , Transform fixedPos = null)
    {
        //如果说当前已经在对话阶段，可以直接返回
        if (panel_dialogue.activeInHierarchy) return;

        this.fixedPos = fixedPos;

        //将当前NPC对话内容赋值给数组
        dialogueLines = info;
        currentLine = 0;
        //设置对话的位置(拿到对话内容)
        dialogueLines[currentLine] = SetPosition(dialogueLines[currentLine],this.fixedPos);
        //设置当前显示的内容
        StartCoroutine(ScrollingText());
        
        //将对话设为可见
        panel_dialogue.SetActive(true);
    }

    //鼠标点击下一句
    private void ClickNext()
    {
        //当点击鼠标左键(空格)，在面板激活的情况下，在文字显示完成的情况下
        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) 
            && panel_dialogue.activeInHierarchy )
        {
            if (isScrolling)
            {
                //如果文字正在滚动，按一下显现全部文字
                StopAllCoroutines();
                //dialogueLines[currentLine] = SetPosition(dialogueLines[currentLine], fixedPos);
                txt_dialogue.text = dialogueLines[currentLine];
                
                isScrolling = !isScrolling;
            }
            else
            {
                //如果文字播放完成
                //切换下一句
                currentLine++;

                //判断数组是否越界
                if (currentLine >= dialogueLines.Length)
                {
                    panel_dialogue.SetActive(false);
                    cf.enabled = true;
                }
                else
                {
                    //设置对话位置(拿到对话内容)
                    dialogueLines[currentLine] = SetPosition(dialogueLines[currentLine], fixedPos);
                    //txt_dialogue.text = dialogueLines[currentLine];
                    cf.enabled = true;
                    //开启协程
                    StartCoroutine(ScrollingText());
                }
            }
        }
    }

    //设置对话出现的位置
    //逻辑分析：通过当前对话内容分辨是谁说的，设置到对应说话人的对话位置即可，并做裁剪操作
    public string SetPosition(string info, Transform fixedPos)
    {
        //返回值
        string res = "";
        //对话跟随组件的获取
        cf.enabled = true;

        //如果是主角人类说的
        if (info.StartsWith("Human:"))
        {
            //主角说的话
            cf.followTarget = Human;
            //裁剪对话
            res = info.Replace("Human:", "");
        }
        else if (info.StartsWith("Yiyi:"))
        {
            //Yiyi说的话
            cf.followTarget = Yiyi;
            //裁剪对话
            res = info.Replace("Yiyi:", "");
        }
        else
        {
            //禁用跟随组件
            cf.enabled = false;
            //交互物体说的话
            transform.position = fixedPos.position;
            //print(fixedPos.position);
            res = info;
        }

        return res;
    }

    //开启一个协程控制文字滚动
    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        txt_dialogue.text = "";

        foreach(char letter in dialogueLines[currentLine].ToCharArray())
        {
            txt_dialogue.text += letter;
            yield return new WaitForSeconds(textInterval);
        }
        //结束以后关闭开关
        isScrolling = false;
    }

    //单独显示一句对话内容
    public void ShowTriggerDialogue(string dialogueInfo)
    {
        panel_dialogue.gameObject.SetActive(true);
        string info = SetPosition(dialogueInfo, fixedPos);
        StartCoroutine(ScrollingOne(info));
    }

    //开启一个协程控制文字滚动
    private IEnumerator ScrollingOne(string dialogueInfo)
    {
        isScrolling = true;
        txt_dialogue.text = "";

        foreach (char letter in dialogueInfo.ToCharArray())
        {
            txt_dialogue.text += letter;
            yield return new WaitForSeconds(textInterval);
        }
        //结束以后关闭开关
        isScrolling = false;
    }
}
