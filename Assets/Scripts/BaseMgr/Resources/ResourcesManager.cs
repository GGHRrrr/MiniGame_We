using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourcesManager : BaseManager<ResourcesManager>
{
    //同步加载资源
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);

        //如果对象是一个GameObject类型，将其实例化
        if (res is GameObject)
        {
            return GameObject.Instantiate(res);
        }
        return res;
    }


    //异步加载资源
    public void LoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        //开启异步加载协程
        MonoManager.Instance().StartCoroutine(ReallyLoadAsync(name,callback));
    }

    private IEnumerator ReallyLoadAsync<T>(string name,UnityAction<T> callback) where T : Object
    {
        ResourceRequest r  = Resources.LoadAsync<T>(name);
        yield return r;

        if (r.asset is GameObject)
        {
            callback(GameObject.Instantiate(r.asset) as T);
        }


        else
            callback(r.asset as T);
    }
}
