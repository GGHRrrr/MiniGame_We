using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneLogsPanel : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Date;
    [SerializeField] public TextMeshProUGUI Title;
    [SerializeField] public TextMeshProUGUI Logs;

    public void Init(PhoneLogs data)
    {
        Date.text = data.date;
        Title.text = data.title;
        Logs.text = data.log;
    }
}
