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
    //是否有固定位置的设定
    public Transform fixedPos;

    //可交互物体是否需要玩家按键触发
    public bool needF;
    //是否播放完成
    private bool isFinish = false;

    private void Update()
    {
        if (needF)
        {
            if (isEntered && Input.GetKeyDown(KeyCode.F))
            {
                print("案件成功");
                DialoguePanel.Instance.ShowDialogue(lines, fixedPos);
            }
        }
        else
        {
            if (isEntered && !isFinish)
            {
                DialoguePanel.Instance.ShowDialogue(lines, fixedPos);
                isFinish = true;
            }
        }
    }

    #region 触发器逻辑
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (needF)
        {
            if (isEntered && Input.GetKeyDown(KeyCode.F))
            {
                DialoguePanel.Instance.ShowDialogue(lines, fixedPos);
            }
        }
        else
        {
            if (isEntered && !isFinish)
            {
                DialoguePanel.Instance.ShowDialogue(lines, fixedPos);
                isFinish = true;
            }
        }
    }*/

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