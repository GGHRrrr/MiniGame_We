using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhoneItemDialog : PhoneUIBase
{
    [SerializeField] public Button phoneButton;
    [SerializeField] public GameObject NewIcon;

    public void Init()
    {
        phoneButton.onClick.AddListener(OnClickEvent);
        base.Init();
    }
    
    public override void Show()
    {
        RefreshIcon();
        base.Show();
    }

    public void RefreshIcon()
    {
        if (PhoneLogsDialog.NewLogsNum > 0 || PhoneMessageDialog.UnReadMessagesSub > 0)
        {
            NewIcon.SetActive(true);
        }
        else
        {
            NewIcon.SetActive(false);
        }
    }

    public void OnClickEvent()
    {
        Debug.Log("????????");
    }
    
    public readonly static string PATH = "PhonePrefab/PhoneItemDialog";
}
