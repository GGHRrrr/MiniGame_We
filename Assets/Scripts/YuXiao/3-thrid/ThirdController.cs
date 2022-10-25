using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdController : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rigidbody;
    public GameObject e;
    public Transform endDia;
    //�鱾UI
    public GameObject book;
    //yiyi����
    public Transform yiyi;

    //��Ļ���
    public GameObject black;
    //���
    public GameObject unfinishedFire;
    public GameObject finishedFire;
    public GameObject PowerfulFire;
    public GameObject CommonFire;

    //�Ի���
    public GameObject dialoguePanel;

    #region ״̬����
    private bool isBook;
    //�Ƿ��Ѿ������˻��
    private bool isFire = false;
    //�Ƿ����Զ���������
    private bool isWalk = false;
    //�Ƿ���ͨ������
    private bool isSuccess = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        //����BGM
        MusicManager.Instance().PlayBGM("��ԭbgm");
        //����ɳ����
        anim = GetComponent<Animator>();
        anim.SetBool("HardWalk", true);
        gameObject.GetComponent<PlayerMove>().moveSpeed = 4;
    }

    void Update()
    {
        if (isBook && !GetComponent<SwitchRole>().isYiYi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                book.SetActive(true);
            }
        }

        //�����Ի�ʱ������һĻ
        if (!dialoguePanel.activeInHierarchy && isFire)
        {
            StartCoroutine(Anim2(black));
            
            isFire = false;
        }

        if (isWalk) transform.Translate(new Vector2(3 * Time.deltaTime, 0));

        if (!dialoguePanel.activeInHierarchy && isSuccess)
        {
            StartCoroutine(Anim3(black));
            isSuccess = false;
        }
    }

    #region ���������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "SwitchAnim":
                anim.SetBool("HardWalk", false);
                gameObject.GetComponent<PlayerMove>().moveSpeed = 7;
                break;
            case "��������":
                ShowPlayerE(true);
                isBook = true;
                print("��������������");
                break;
            case "endDia":
                isSuccess = true;
                isWalk = false;
                GetComponent<Animator>().SetBool("walk", false);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "SwitchAnim":
                anim.SetBool("HardWalk", true);
                gameObject.GetComponent<PlayerMove>().moveSpeed = 4;
                break;
            case "��������":
                ShowPlayerE(false);
                isBook = false;
                break;
        }
    }
    #endregion

    #region ��ײ�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.name)
        {
            case "δ��Ļ��":
                //���
                StartCoroutine(Anim1(black));
                break;
        }
    }
    #endregion

    IEnumerator Fade(GameObject gameObj, bool isFade)//дһ�����亯��
    {
        SpriteRenderer spriteRenderer = gameObj.GetComponent<SpriteRenderer>();
        if (isFade)
        {
            while (spriteRenderer.color.a > 0)
            {
                yield return new WaitForSeconds(0.05f);
                spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - 0.05f);
            }
        }
        else
        {
            while (spriteRenderer.color.a < 1)
            {
                yield return new WaitForSeconds(0.05f);
                spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a + 0.05f);
            }
        }
    }

    IEnumerator Anim1(GameObject panel)//дһ�����亯��
    {
        Image img = panel.GetComponent<Image>();

        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //��ȫ��Ļ�˸ı�����״̬
        //�ı��Ͳ��״̬
        finishedFire.SetActive(true);
        unfinishedFire.SetActive(false);
        PowerfulFire.SetActive(true);
        //�޸����Ƕ�����λ��
        transform.localPosition = new Vector3(124, transform.position.y, transform.position.z);
        yiyi.localPosition = new Vector3(144, 6, yiyi.position.z);
        yiyi.localScale = new Vector3(-yiyi.localScale.x, yiyi.localScale.y, yiyi.localScale.z);
        GetComponent<Animator>().SetBool("sittiing", true);
        //�رո���
        GetComponent<PlayerMove>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }

        //�����Ի�
        string[] info =
        {
            "Human:�ڵִ���һ������֮ǰ���ú���Ϣһ�°ѡ�",
            "Human:������������������Ҿ�û������Ϣ�����㲻��о���ƣ����",
            "Yiyi:���ᣬ������������ҽ�������״̬����Ҳ���Զ��ݵ���Ϣһ��ʱ�䡣",
            "Human:������ľ�������������",
            "Human:��һ·������ͣͣ������һ�����У����ⳡ���е��յ㣬���ݶ�Ϊǰ�����������аɡ�",
            "Yiyi:���β��ں��յ㣬��������;�е��˺��»�����Щ���õļ���;�ɫ��",
            "Human:���Ǵ���ѧ�������޵Ļ�......",
            "Human:������˵��û����;�����ں��յ㣬���յ㣬ֻ����һ�����е������ˡ�",
            "Human:yiyi,�����߰ɣ��������̤�����һ��·�ˡ�",
            "Yiyi:���յ�����ָ�������......"


        };

        DialoguePanel.Instance.ShowDialogue(info);
        isFire = true;
        
    }

    IEnumerator Anim2(GameObject panel)//дһ�����亯��
    {
        Image img = panel.GetComponent<Image>();

        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //��ȫ��Ļ�˸ı�����״̬
        GetComponent<Animator>().SetBool("sittiing", false);
        
        //GetComponent<Animator>().SetBool("sittiing", true);
        yield return new WaitForSeconds(0.5f);

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }

        GetComponent<Animator>().SetBool("walk", true);
        isWalk = true;
        //�����Ի�
        /*string[] info =
        {
            "Human:.....",
            "Human:�ô������ˡ�",
            
            "Human:������������",
            "Human:������ֻ��ϣ��һ��˳���ˡ�",
            "Human::......Ϧ����������"
        };

        DialoguePanel.Instance.ShowDialogue(info);*/

    }

    IEnumerator Anim3(GameObject panel)//дһ�����亯��
    {
        Image img = panel.GetComponent<Image>();

        while (img.color.a < 1)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a + 0.05f);
        }
        //��ȫ��Ļ�˸ı�����״̬
        //�л�����
        //��ǰ�ؿ����
        int num = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(num + 1);
        yield return new WaitForSeconds(0.5f);

        while (img.color.a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            img.color = new Color(0, 0, 0, img.color.a - 0.05f);
        }
    }

    void ShowPlayerE(bool isEnter)
    {
        if (!gameObject.GetComponent<SwitchRole>().isYiYi && isEnter)
        {
            e.gameObject.SetActive(true);
            StartCoroutine(Fade(e, true));
        }
        if (!gameObject.GetComponent<SwitchRole>().isYiYi && !isEnter)
        {
            e.gameObject.SetActive(false);
            e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}
