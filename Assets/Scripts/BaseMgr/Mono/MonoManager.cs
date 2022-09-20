using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//给外部提供添加帧更新事件的方法
//给外部提供开启协程的方法
public class MonoManager : BaseManager<MonoManager>
{
    private MonoController controller;

    public MonoManager()
    {
        //保证了MonoController对象的唯一性
        GameObject obj = new GameObject("MonoController");
        controller = obj.AddComponent<MonoController>();
    }

    //添加帧更新事件的函数
    public void AddUpdateListener(UnityAction fun)
    {
        controller.AddUpdateListener(fun);
    }

    public void RemoveUpdateListener(UnityAction fun)
    {
        controller.RemoveUpdateListener(fun);
    }

    //开启协程
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }

}
