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
    
    public void Init()
    {
        phoneButton.onClick.AddListener(OnClickEvent);
        base.Init();
    }

    public void OnClickEvent()
    {
        Debug.Log("????????");
    }
    
    public readonly static string PATH = "PhonePrefab/PhoneItemDialog";
}
