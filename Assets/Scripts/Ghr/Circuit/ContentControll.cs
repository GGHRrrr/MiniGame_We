using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentControll : MonoBehaviour
{
    public static ContentControll instance;
    public List<ItemsControll> itemsList= new List<ItemsControll>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        init();
        for (int i = 0; i < transform.childCount; i++)
        {
            itemsList.Add(transform.GetChild(i).GetComponent<ItemsControll>());
        }
    }
    //首先进行初始化
    void init()
    {
        itemsList.Clear();
    }
    /// <summary>
    /// 检查子物体是否全部为正确状态
    /// </summary>
    public void CheckItems()
    {
        bool isAllTrue=false;
        for(int i=0;i<itemsList.Count;i++)
        {
            var item = itemsList[i];
            if (item.isTrue != true)
                break;
            if(item.isTrue==true&&i==itemsList.Count-1)
                isAllTrue=true;
        }
        if (isAllTrue)
        {
            Debug.Log("全部解锁进行下一步操作");
        }
    }
}
