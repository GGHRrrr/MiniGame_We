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
    [SerializeField] public GameObject NewMessages;
    [SerializeField] public TextMeshProUGUI UnReadNum;

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

        if (PhoneMessageDialog.UnReadMessagesSub > 0 || PhoneMessageDialog.ToSendMessages > 0)
        {
            NewMessages.SetActive(true);
            unReadNum.gameObject.SetActive(true);
            unReadNum.text = PhoneMessageDialog.UnReadMessagesSub.ToString();
            if(PhoneMessageDialog.ToSendMessages > 0)
                unReadNum.text = "!";
        }
        else
        {
            NewMessages.SetActive(false);
            unReadNum.gameObject.SetActive(false);
        }
    }
}
