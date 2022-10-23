using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneElementBtn : MonoBehaviour
{
    [SerializeField] public Button UserBtn;
    [SerializeField] public TextMeshProUGUI Title;
    [SerializeField] public TextMeshProUGUI Time;
    [SerializeField] public GameObject OnClickImage;
    [SerializeField] public GameObject UnReadLog;
    [SerializeField] public GameObject UnReadMessage;
    [SerializeField] public TextMeshProUGUI UnReadMessagesNum;
    public string Id;

    public void Init(PhoneMessageWindow data)
    {
        Title.text = data.name;
        Time.text = data.messageBlocks[0].messages[0].messagesContext;
        this.Id = data.name;
    }

    public void Init(PhoneLogs data)
    {
        Title.text = data.title;
        Time.text = data.date;
        this.Id = data.title;
    }

    public void OnClickLog()
    {
        OnClickImage.SetActive(true);
        if (UnReadLog.activeSelf)
        {
            UnReadLog.SetActive(false);
            PhoneLogsDialog.NewLogsNum--;
        }
    }

    public void OnClickMessage()
    {
        OnClickImage.SetActive(true);
        if (UnReadMessage.activeSelf)
        {
            UnReadMessage.SetActive(false);
        }
    }
}
