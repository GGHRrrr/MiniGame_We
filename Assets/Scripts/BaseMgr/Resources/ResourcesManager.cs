using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourcesManager : BaseManager<ResourcesManager>
{
    //ͬ��������Դ
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);

        //���������һ��GameObject���ͣ�����ʵ����
        if (res is GameObject)
        {
            return GameObject.Instantiate(res);
        }
        return res;
    }


    //�첽������Դ
    public void LoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        //�����첽����Э��
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
