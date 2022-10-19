using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{  
    /// <summary>
    /// 道具生成点，进行道具的赋值
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
    /// 判断道具类型，进行赋值
    /// </summary>
    void SwitchItem()
    {
        switch(itemType)
        {
            case Item.ItemType.yilaguan:
                item= new Item { itemType = Item.ItemType.yilaguan, amount = currAmount };
                itemWorld.SetItem(item);
                break;
            case Item.ItemType.shengzi:
                item= new Item { itemType = Item.ItemType.shengzi,amount = currAmount };
                itemWorld.SetItem(item);
                break;
        }
    }
}
