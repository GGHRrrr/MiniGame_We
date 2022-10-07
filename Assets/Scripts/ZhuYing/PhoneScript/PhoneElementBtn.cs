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
    private string name;

    public void Init(PhoneMessageWindow data)
    {
        Title.text = data.name;
        Time.text = data.updateTime;
        this.name = data.name;
    }

    public void Init(PhoneLogs data)
    {
        Title.text = data.title;
        Time.text = data.date;
        this.name = data.title;
    }
}
