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
public class DialoguePanel : MonoBehaviour
{
    #region ����ģʽ
    //ʵ�ֵ���ģʽ
    public static DialoguePanel Instance;

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
    public Text txt_dialogue;

    //�Ի����ֵ�λ��
    //public Transform pos;

    //�洢һ�ζԻ�����������
    [TextArea(1,3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine = 0;

    //�����������ֵĿ�����ʱ����
    private bool isScrolling;
    [SerializeField]private float textInterval;

    // Start is called before the first frame update
    void Start()
    {
        print(currentLine);
        //txt_dialogue.text = dialogueLines[currentLine];
    }

    //������л���һ��
    void Update()
    {
        ClickNext();
    }

    //������ʾ
    public void ShowDialogue(string[] info,Transform pos)
    {
        //���˵��ǰ�Ѿ��ڶԻ��׶Σ�����ֱ�ӷ���
        if (panel_dialogue.activeInHierarchy) return;

        //����ǰNPC�Ի����ݸ�ֵ������
        dialogueLines = info;
        currentLine = 0;
        //���õ�ǰ��ʾ������
        StartCoroutine(ScrollingText());
        //���öԻ���λ��
        SetPosition(pos.position);
        //���Ի���Ϊ�ɼ�
        panel_dialogue.SetActive(true);
    }

    //�������һ��
    private void ClickNext()
    {
        //�����������(�ո�)������弤�������£���������ʾ��ɵ������
        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) 
            && panel_dialogue.activeInHierarchy 
            && !isScrolling)
        {
            
            //�л���һ��
            currentLine++;
            //�ж������Ƿ�Խ��
            if (currentLine >= dialogueLines.Length)
            {
                panel_dialogue.SetActive(false);
            }
                
            else
                //txt_dialogue.text = dialogueLines[currentLine];
                //����Э��
                StartCoroutine(ScrollingText());

        }
    }

    //���öԻ����ֵ�λ��
    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }

    //����һ��Э�̿������ֹ���
    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        txt_dialogue.text = "";

        foreach(char letter in dialogueLines[currentLine].ToCharArray())
        {
            txt_dialogue.text += letter;
            yield return new WaitForSeconds(textInterval);
        }
        //�����Ժ�رտ���
        isScrolling = false;
    }
}
