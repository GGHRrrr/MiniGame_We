using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoController : MonoBehaviour
{
    public event UnityAction updateEvent;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (updateEvent != null)
        {
            updateEvent();
        }
    }

    //添加帧更新事件的函数
    public void AddUpdateListener(UnityAction fun)
    {
        updateEvent += fun;
    }

    public void RemoveUpdateListener(UnityAction fun)
    {
        updateEvent -= fun;
    }
}

