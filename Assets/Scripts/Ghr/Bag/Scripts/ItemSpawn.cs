using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{  
    /// <summary>
    /// �������ɵ㣬���е��ߵĸ�ֵ
    /// </summary>
    public Item.ItemType itemType;
    public ItemWorld itemWorld;
    public int currAmount;
    public Item item;
    private void Start()
    {
        SwitchItem();
    }
    /// <summary>
    /// �жϵ������ͣ����и�ֵ
    /// </summary>
    void SwitchItem()
    {
        switch(itemType)
        {
            case Item.ItemType.battery:
                item= new Item { itemType = Item.ItemType.battery, amount = currAmount };
                itemWorld.SetItem(item);
                break;
            case Item.ItemType.sword:
                 item = new Item { itemType = Item.ItemType.sword, amount = currAmount };
                itemWorld.SetItem(item);
                break;
        }
    }
}
