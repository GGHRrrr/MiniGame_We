using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneWindowDialog : PhoneUIBase
{
    [SerializeField] public Button outBtn;
    [SerializeField] public Button messageBtn;
    [SerializeField] public Button logsBtn;
    [SerializeField] public TextMeshProUGUI unReadNum;
    [SerializeField] public GameObject NewLogs;

    public readonly static string PATH = "PhonePrefab/PhoneWindowDialog";

    public override void Show()
    {
        RefreshIcon();
        base.Show();
    }
    
    public void RefreshIcon()
    {
        if (PhoneLogsDialog.NewLogsNum > 0)
        {
            NewLogs.SetActive(true);
        }
        else
        {
            NewLogs.SetActive(false);
        }
    }
}
