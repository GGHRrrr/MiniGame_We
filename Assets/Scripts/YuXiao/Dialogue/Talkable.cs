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
    public Transform pos;

    //�ɽ��������Ƿ���Ҫ��Ұ�������
    public bool needF;
    //�Ƿ񲥷����
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

    #region �������߼�
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
