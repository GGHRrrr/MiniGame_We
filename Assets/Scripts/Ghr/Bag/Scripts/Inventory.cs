using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// �����ı����ֿ�����
/// </summary>
public class Inventory 
{
    private List<Item> itemList;//�洢�������б�
    public event EventHandler OnItemListChanged;//������¼�,���б����ʱ����ui����
    private Action<Item> useItemAction;//ʹ�õ��ߵ�ί�к���
    /// <summary>
    /// ���캯���������ʹ���¼��뱳������
    /// </summary>
    /// <param name="useItemAction"></param>
    public  Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();
    }/// <summary>
    /// ��ֿ�����ӵ���
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        bool isHave = false;//�жϲֿ����Ƿ��Ѿ�ӵ��
        foreach(Item items in itemList)
        {
            if (item.itemType == items.itemType)
            {
                isHave = true;
                items.amount += item.amount;//�Ѿ�ӵ����������һ
            }
        }
        if(isHave==true)
        {
            //item.amount++;
        }
        else
        {
            itemList.Add(item);//û���ڲֿ���ֱ�����
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);//ˢ��ui
    }
    public List<Item> GetListItems()//���زֿ��б�Ľӿ�
    {
        return itemList;
    }
    public  void RemoveItem(Item item)//�Ƴ�����
    {
        Item itemInInventory = null;//����һ���ֿ�ı������и�ֵ
        foreach (Item items in itemList)
        {
            if (item.itemType == items.itemType)//�������������ͬ����������
            {
                items.amount --;
                itemInInventory = items;
            }
        }
        if (itemInInventory != null&&itemInInventory.amount>0)
        {
            //���������������0��������
        }
        else
        {
            itemList.Remove(itemInInventory);//�����Ƴ�����
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);//ˢ�º���
    }
    public void UseItem(Item item)
    {
        useItemAction(item);
    }

}
