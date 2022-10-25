using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdController : MonoBehaviour
{

    private Animator anim;
    public GameObject e;
    //�鱾UI
    public GameObject book;

    #region ״̬����
    private bool isBook;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
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
