using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YiYi : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = new Inventory(useItemYiYi);
        uiInventory.SetInventory(inventory);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    private void useItemYiYi(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.yilaguan:
                EventManager.Instance().EventTrigger(EventTypeEnum.USEITEMS_YILAGUAN.ToString(), "");
                Debug.Log("使用易拉罐");
                break;
        }
    }
}
