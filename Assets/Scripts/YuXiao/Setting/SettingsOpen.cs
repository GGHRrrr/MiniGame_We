using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOpen : MonoBehaviour
{
    //���ð�ť
    public Button settings;
    //�������
    public GameObject settingsPanel;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        settings.onClick.AddListener(() =>
        {
            //��ʾ�������
            settingsPanel.SetActive(true);
        });
    }
}
