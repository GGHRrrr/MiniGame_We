using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ���ص��ɽ���������
 */
public class Talkable : MonoBehaviour
{
    //�Ƿ񵽴�����Χ
    [SerializeField] private bool isEntered;
    [TextArea(1, 3)]
    public string[] lines;
    //�Ƿ��й̶�λ�õ��趨
    public Transform fixedPos;

    //�ɽ��������Ƿ���Ҫ��Ұ�������
    public bool needF;
    //�Ƿ񲥷����
    private bool isFinish = false;

    private void Update()
    {
        if (needF)
        {
            if (isEntered && Input.GetKeyDown(KeyCode.F))
            {
                print("�����ɹ�");
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

    #region �������߼�
    private void OnTriggerStay2D(Collider2D collision)
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
    }

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