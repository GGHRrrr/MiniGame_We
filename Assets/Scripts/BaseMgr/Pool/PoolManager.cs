using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//抽屉类
public class PoolData
{
    //抽屉中对象挂载的父节点
    public GameObject fatherNode;
    //对象的容器
    public List<GameObject> poolList;

    //构造函数
    public PoolData(GameObject obj,GameObject poolObj)
    {
        //给List创建一个父对象，使其成为pool的子对象
        fatherNode = new GameObject(obj.name);
        fatherNode.transform.parent = poolObj.transform;
        poolList = new List<GameObject>() { obj };
        AddObj(obj);
    }

    public void AddObj(GameObject obj)
    {
        //失活
        obj.SetActive(false);

        poolList.Add(obj);
        //设置父对象
        obj.transform.parent = fatherNode.transform;
    }

    public GameObject GetObj()
    {
        GameObject obj = null;
        //取出第一个
        obj = poolList[0];
        poolList.RemoveAt(0);
        //激活该物体
        obj.SetActive(true);
        //断开父子关系
        obj.transform.parent = null;

        return obj;
    }
}


public class PoolManager : BaseManager<PoolManager>
{
    //字典实现缓存池容器
    public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

    //根节点对象
    private GameObject poolObj;

    //从缓存池中拿物体
    public void GetObj(string name,UnityAction<GameObject> callback)
    {
        //有对应的容器List，并且容器里有东西
        if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
        {
            //此处亦可用队列实现
            callback(poolDic[name].GetObj());
        }
        else
        {
            //obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //将对象的名字跟池子名字保持一致
            //obj.name = name;

            //通过异步加载创建对象
            ResourcesManager.Instance().LoadAsync<GameObject>(name, (o) =>
            {
                o.name = name;
                callback(o);
            });
        }
    }

    //向缓存池中添加物体
    public void AddObj(string name,GameObject obj)
    {
        if (poolObj == null)
        {
            poolObj = new GameObject("Pool");
        }

        //如果已经存在对应容器
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].AddObj(obj);
        }
        else
        {
            poolDic.Add(name, new PoolData(obj,poolObj));
        }
    }

    //用于切换场景时的清空缓存池
    public void Clear()
    {
        poolDic.Clear();
        poolObj = null;
    }
}
