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
public class DialogueManager : MonoBehaviour
{
    #region 单例模式
    //实现单例模式
    public static DialogueManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    //对话面板对象
    public GameObject panel_dialogue;

    //对话文字内容以及说话人
    public Text txt_dialogue, txt_name;

    //对话出现的位置
    private Transform pos;

    //存储一次对话的所有内容
    [TextArea(1,3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt_dialogue.text = dialogueLines[currentLine];
    }

    //鼠标点击切换下一句
    void Update()
    {
        ClickNext();
    }

    //面板的显示
    public void ShowDialogue(string[] info)
    {
        //如果说当前已经在对话阶段，可以直接返回
        if (panel_dialogue.activeInHierarchy) return;

        //将当前NPC对话内容赋值给数组
        dialogueLines = info;
        currentLine = 0;
        //设置当前显示的内容
        txt_dialogue.text = dialogueLines[currentLine];
        //设置对话的位置
        SetPosition(pos.position);
        //将对话设为可见
        panel_dialogue.SetActive(true);
    }

    //鼠标点击下一句
    private void ClickNext()
    {
        //当点击鼠标左键，在面板激活的情况下，在文字显示完成的情况下
        if (Input.GetMouseButtonUp(0) && panel_dialogue.activeInHierarchy)
        {
            
            //切换下一句
            currentLine++;
            //判断数组是否越界
            if (currentLine >= dialogueLines.Length)
                panel_dialogue.SetActive(false);
            else
                txt_dialogue.text = dialogueLines[currentLine];

        }
    }

    //设置对话出现的位置
    public void SetPosition(Vector2 pos)
    {
        this.pos.position = pos;
    }
}
