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


    // Update is called once per frame
    void Update()
    {
        if (isEntered && Input.GetKeyDown(KeyCode.F))
        {
            DialogueManager.Instance.ShowDialogue(lines);
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
