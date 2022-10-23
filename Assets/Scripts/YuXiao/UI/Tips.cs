using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    //提示面板的显隐状态
    private bool isShow;

    public bool IsShow 
    {
        get { return isShow; }
        set
        {
            isShow = value;
            if (isShow)
            {
                //显示
                txt_Tip.text = "A D：移动\nTab：切换移动方式\n空格：切换对话\nE：交互\n点击左下角可使用道具\n(按F隐藏该面板)";
            }
            else
            {
                //隐藏
                txt_Tip.text = "(按F显示操作提示面板)";
            }
        }
    }
    //文本组件
    public Text txt_Tip;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            IsShow = true;
        else
            IsShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsShow = IsShow ? false : true;
        }
    }
}
