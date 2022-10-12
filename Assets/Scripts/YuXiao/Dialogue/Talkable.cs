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


    // Update is called once per frame
    void Update()
    {
        if (isEntered && Input.GetKeyDown(KeyCode.F))
        {
            DialogueManager.Instance.ShowDialogue(lines);
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
