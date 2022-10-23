using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    //��ʾ��������״̬
    private bool isShow;

    public bool IsShow 
    {
        get { return isShow; }
        set
        {
            isShow = value;
            if (isShow)
            {
                //��ʾ
                txt_Tip.text = "A D���ƶ�\nTab���л��ƶ���ʽ\n�ո��л��Ի�\nE������\n������½ǿ�ʹ�õ���\n(��F���ظ����)";
            }
            else
            {
                //����
                txt_Tip.text = "(��F��ʾ������ʾ���)";
            }
        }
    }
    //�ı����
    public Text txt_Tip;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            IsShow = true;
        else
            IsShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsShow = IsShow ? false : true;
        }
    }
}
