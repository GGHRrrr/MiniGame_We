using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Scene scene;
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
        inventory.AddItem(new Item { itemType=Item.ItemType.yilaguan,amount=10});
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3:
                inventory.AddItem(new Item { itemType = Item.ItemType.shengzi, amount = 1 });
                inventory.AddItem(new Item { itemType = Item.ItemType.shenfenpai, amount = 1 });
                break;
            case 4:
                inventory.AddItem(new Item { itemType = Item.ItemType.shengzi, amount = 1 });
                inventory.AddItem(new Item { itemType = Item.ItemType.shenfenpai, amount = 1 });
                break;
            case 5:
                inventory.AddItem(new Item { itemType = Item.ItemType.shengzi, amount = 1 });
                inventory.AddItem(new Item { itemType = Item.ItemType.shenfenpai, amount = 1 });
                break;
        }
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
    /// ?????????????????
    /// </summary>
    /// <param name="item"></param>
    private void useItem(Item item)
    {
        switch(item.itemType)
        {
            case Item.ItemType.yilaguan:
                    EventManager.Instance().EventTrigger(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), "");
                if (item.amount <= 1)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.yilaguan, amount = 1 });
                }
                    Debug.Log("?????????,?????????????");
                break;
            case Item.ItemType.shengzi:
                EventManager.Instance().EventTrigger(EventTypeEnum.USEITEM_SHENGZI.ToString(), "");
                inventory.AddItem(new Item { itemType = Item.ItemType.shengzi, amount = 1 });
                break;
            case Item.ItemType.shenfenpai:
                inventory.AddItem(new Item { itemType = Item.ItemType.shenfenpai, amount = 1 });
                break;
        }
    }
}
