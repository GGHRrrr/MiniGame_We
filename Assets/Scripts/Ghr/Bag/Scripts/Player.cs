using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    public Inventory Inventory { get { return inventory; } }
    [SerializeField]private  UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = new Inventory(useItem);
        uiInventory.SetInventory(inventory);
    }
    private void Start()
    {
        //ItemWorld.SpawnItemWorld(new Vector3(0, 0), new Item { itemType = Item.ItemType.battery, amount = 1 });
        inventory.AddItem(new Item { itemType=Item.ItemType.yilaguan,amount=1});
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    ItemWorld itemWorld = other.GetComponent<ItemWorld>();
    //    if (itemWorld != null)
    //    {
    //        inventory.AddItem(itemWorld.GetItem());
    //        itemWorld.DestroySelf();
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    /// <summary>
    /// 玩家使用道具产生的影响
    /// </summary>
    /// <param name="item"></param>
    private void useItem(Item item)
    {
        switch(item.itemType)
        {
            case Item.ItemType.yilaguan:
                EventManager.Instance().EventTrigger(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), "");
                Debug.Log("使用易拉罐");
                break;
        }
    }
}
