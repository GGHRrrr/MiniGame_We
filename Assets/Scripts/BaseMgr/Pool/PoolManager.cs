using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//������
public class PoolData
{
    //�����ж�����صĸ��ڵ�
    public GameObject fatherNode;
    //���������
    public List<GameObject> poolList;

    //���캯��
    public PoolData(GameObject obj,GameObject poolObj)
    {
        //��List����һ��������ʹ���Ϊpool���Ӷ���
        fatherNode = new GameObject(obj.name);
        fatherNode.transform.parent = poolObj.transform;
        poolList = new List<GameObject>() { obj };
        AddObj(obj);
    }

    public void AddObj(GameObject obj)
    {
        //ʧ��
        obj.SetActive(false);

        poolList.Add(obj);
        //���ø�����
        obj.transform.parent = fatherNode.transform;
    }

    public GameObject GetObj()
    {
        GameObject obj = null;
        //ȡ����һ��
        obj = poolList[0];
        poolList.RemoveAt(0);
        //���������
        obj.SetActive(true);
        //�Ͽ����ӹ�ϵ
        obj.transform.parent = null;

        return obj;
    }
}


public class PoolManager : BaseManager<PoolManager>
{
    //�ֵ�ʵ�ֻ��������
    public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

    //���ڵ����
    private GameObject poolObj;

    //�ӻ������������
    public void GetObj(string name,UnityAction<GameObject> callback)
    {
        //�ж�Ӧ������List�������������ж���
        if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
        {
            //�˴�����ö���ʵ��
            callback(poolDic[name].GetObj());
        }
        else
        {
            //obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //����������ָ��������ֱ���һ��
            //obj.name = name;

            //ͨ���첽���ش�������
            ResourcesManager.Instance().LoadAsync<GameObject>(name, (o) =>
            {
                o.name = name;
                callback(o);
            });
        }
    }

    //�򻺴�����������
    public void AddObj(string name,GameObject obj)
    {
        if (poolObj == null)
        {
            poolObj = new GameObject("Pool");
        }

        //����Ѿ����ڶ�Ӧ����
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].AddObj(obj);
        }
        else
        {
            poolDic.Add(name, new PoolData(obj,poolObj));
        }
    }

    //�����л�����ʱ����ջ����
    public void Clear()
    {
        poolDic.Clear();
        poolObj = null;
    }
}
