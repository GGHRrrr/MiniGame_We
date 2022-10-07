using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 建立的背包仓库类型
/// </summary>
public class Inventory 
{
    private List<Item> itemList;//存储背包的列表
    public event EventHandler OnItemListChanged;//定义的事件,在列表更新时更新ui界面
    private Action<Item> useItemAction;//使用道具的委托函数
    /// <summary>
    /// 构造函数，将玩家使用事件与背包关联
    /// </summary>
    /// <param name="useItemAction"></param>
    public  Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();
        Debug.Log("Inventory");
    }/// <summary>
    /// 向仓库中添加道具
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        bool isHave = false;//判断仓库中是否已经拥有
        foreach(Item items in itemList)
        {
            if (item.itemType == items.itemType)
            {
                isHave = true;
                items.amount += item.amount;//已经拥有则数量加一
            }
        }
        if(isHave==true)
        {
            //item.amount++;
            Debug.Log(item.amount);
        }
        else
        {
            itemList.Add(item);//没有在仓库则直接添加
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);//刷新ui
    }
    public List<Item> GetListItems()//返回仓库列表的接口
    {
        return itemList;
    }
    public  void RemoveItem(Item item)//移除道具
    {
        Item itemInInventory = null;//设置一个仓库的变量进行赋值
        foreach (Item items in itemList)
        {
            if (item.itemType == items.itemType)//如果道具类型相同，道具消耗
            {
                items.amount --;
                itemInInventory = items;
            }
        }
        if (itemInInventory != null&&itemInInventory.amount>0)
        {
            Debug.Log(itemInInventory.itemType + "背包中剩余" + itemInInventory.amount);
            //如果道具数量大于0不做处理
        }
        else
        {
            itemList.Remove(itemInInventory);//否则移除队列
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);//刷新函数
    }
    public void UseItem(Item item)
    {
        useItemAction(item);
    }

}
