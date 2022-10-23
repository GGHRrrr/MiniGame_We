using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOpen : MonoBehaviour
{
    //设置按钮
    public Button settings;
    //设置面板
    public GameObject settingsPanel;

    private void Start()
    {
        settings.onClick.AddListener(() =>
        {
            print("设置被按下");
            //显示设置面板
            settingsPanel.SetActive(true);
        });
    }
}
