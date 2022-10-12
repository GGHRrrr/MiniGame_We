using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*
    �Ի�����ࣺ
        1.������������
        2.ʵ�ֶԻ����л�
        3.ʵ�ֶԻ���ѭһ���¼��������
 */
public class DialogueManager : MonoBehaviour
{
    #region ����ģʽ
    //ʵ�ֵ���ģʽ
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

    //�Ի�������
    public GameObject panel_dialogue;

    //�Ի����������Լ�˵����
    public Text txt_dialogue, txt_name;

    //�Ի����ֵ�λ��
    private Transform pos;

    //�洢һ�ζԻ�����������
    [TextArea(1,3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt_dialogue.text = dialogueLines[currentLine];
    }

    //������л���һ��
    void Update()
    {
        ClickNext();
    }

    //������ʾ
    public void ShowDialogue(string[] info)
    {
        //���˵��ǰ�Ѿ��ڶԻ��׶Σ�����ֱ�ӷ���
        if (panel_dialogue.activeInHierarchy) return;

        //����ǰNPC�Ի����ݸ�ֵ������
        dialogueLines = info;
        currentLine = 0;
        //���õ�ǰ��ʾ������
        txt_dialogue.text = dialogueLines[currentLine];
        //���öԻ���λ��
        SetPosition(pos.position);
        //���Ի���Ϊ�ɼ�
        panel_dialogue.SetActive(true);
    }

    //�������һ��
    private void ClickNext()
    {
        //�����������������弤�������£���������ʾ��ɵ������
        if (Input.GetMouseButtonUp(0) && panel_dialogue.activeInHierarchy)
        {
            
            //�л���һ��
            currentLine++;
            //�ж������Ƿ�Խ��
            if (currentLine >= dialogueLines.Length)
                panel_dialogue.SetActive(false);
            else
                txt_dialogue.text = dialogueLines[currentLine];

        }
    }

    //���öԻ����ֵ�λ��
    public void SetPosition(Vector2 pos)
    {
        this.pos.position = pos;
    }
}
