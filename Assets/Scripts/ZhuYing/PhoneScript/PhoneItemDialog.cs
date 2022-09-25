using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhoneItemDialog : MonoBehaviour
{
    [SerializeField] public Button phoneButton;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        phoneButton.onClick.AddListener(OnClickEvent);
    }

    public void OnClickEvent()
    {
        Debug.Log("°´Å¥±»µã»÷");
    }
}
