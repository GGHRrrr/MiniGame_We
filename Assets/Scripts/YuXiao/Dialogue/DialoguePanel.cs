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
    //�Ի��������
    private CanvasFollow cf;

    //�Ի����������Լ�˵����
    public Text txt_dialogue;

    //�Ի����ֵ�λ��
    public Transform Human,Yiyi;
    //�Ի������Ƿ��й̶�λ��
    private Transform fixedPos;

    //�洢һ�ζԻ�����������
    [TextArea(1,3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine = 0;

    //�����������ֵĿ�����ʱ����
    private bool isScrolling;
    [SerializeField]private float textInterval;

    private void Start()
    {
        cf = GetComponent<CanvasFollow>();
    }

    //������л���һ��
    void Update()
    {
        ClickNext();
    }

    //������ʾ
    public void ShowDialogue(string[] info , Transform fixedPos)
    {
        //���˵��ǰ�Ѿ��ڶԻ��׶Σ�����ֱ�ӷ���
        if (panel_dialogue.activeInHierarchy) return;

        this.fixedPos = fixedPos;

        //����ǰNPC�Ի����ݸ�ֵ������
        dialogueLines = info;
        currentLine = 0;
        //���öԻ���λ��(�õ��Ի�����)
        dialogueLines[currentLine] = SetPosition(dialogueLines[currentLine],this.fixedPos);
        //���õ�ǰ��ʾ������
        StartCoroutine(ScrollingText());
        
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
                cf.enabled = true;
            }
            else
            {
                //���öԻ�λ��(�õ��Ի�����)
                dialogueLines[currentLine] = SetPosition(dialogueLines[currentLine],fixedPos);
                //txt_dialogue.text = dialogueLines[currentLine];
                cf.enabled = true;
                //����Э��
                StartCoroutine(ScrollingText());
            }
               

        }
    }

    //���öԻ����ֵ�λ��
    //�߼�������ͨ����ǰ�Ի����ݷֱ���˭˵�ģ����õ���Ӧ˵���˵ĶԻ�λ�ü��ɣ������ü�����
    public string SetPosition(string info, Transform fixedPos)
    {
        //����ֵ
        string res = "";
        //�Ի���������Ļ�ȡ
        cf.enabled = true;

        //�������������˵��
        if (info.StartsWith("Human:"))
        {
            //����˵�Ļ�
            cf.followTarget = Human;
            //�ü��Ի�
            res = info.Replace("Human:", "");
        }
        else if (info.StartsWith("Yiyi:"))
        {
            //Yiyi˵�Ļ�
            cf.followTarget = Yiyi;
            //�ü��Ի�
            res = info.Replace("Yiyi:", "");
        }
        else
        {
            //���ø������
            cf.enabled = false;
            //��������˵�Ļ�
            transform.position = fixedPos.position;
            //print(fixedPos.position);
            res = info;
        }

        return res;
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

    //������ʾһ��Ի�����
    public void ShowTriggerDialogue(string dialogueInfo)
    {
        string info = SetPosition(dialogueInfo, fixedPos);
        StartCoroutine(ScrollingOne(info));
    }

    //����һ��Э�̿������ֹ���
    private IEnumerator ScrollingOne(string dialogueInfo)
    {
        isScrolling = true;
        txt_dialogue.text = "";

        foreach (char letter in dialogueInfo.ToCharArray())
        {
            txt_dialogue.text += letter;
            yield return new WaitForSeconds(textInterval);
        }
        //�����Ժ�رտ���
        isScrolling = false;
    }
}
