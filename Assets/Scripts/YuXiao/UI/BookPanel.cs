using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPanel : MonoBehaviour
{
    //�˳���ť
    public Button quit;
    //�ʵ���ť
    public Button caidan;
    //�ʵ����
    public GameObject caidanPanel;

    private void Start()
    {
        quit.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        caidan.onClick.AddListener(() =>
        {
            caidanPanel.SetActive(true);
        });
    }
}
