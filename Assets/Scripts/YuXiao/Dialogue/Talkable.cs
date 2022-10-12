using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    挂载到可交互物体上
 */
public class Talkable : MonoBehaviour
{
    //是否到触碰范围
    [SerializeField] private bool isEntered;
    [TextArea(1, 3)]
    public string[] lines;
    public Transform pos;

    //可交互物体是否需要玩家按键触发
    public bool needF;
    //是否播放完成
    private bool isFinish = false;


    // Update is called once per frame
    void Update()
    {
        if (needF)
        {
            if (isEntered && Input.GetKeyDown(KeyCode.F))
            {
                DialoguePanel.Instance.ShowDialogue(lines, pos);
            }
        }
        else
        {
            if (isEntered && !isFinish)
            {
                DialoguePanel.Instance.ShowDialogue(lines, pos);
                isFinish = true;
            }
        }
        
    }

    #region 触发器逻辑
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isEntered = false;
        }
    }
    #endregion
}
