using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class PhoneUIBase : MonoBehaviour
{
    public virtual void Init()
    {
        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        if(gameObject.activeSelf) 
            gameObject.SetActive(false);
    }
}
