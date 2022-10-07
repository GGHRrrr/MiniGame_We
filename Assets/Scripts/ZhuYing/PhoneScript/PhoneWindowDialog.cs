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

    public readonly static string PATH = "PhonePrefab/PhoneWindowDialog";
}
