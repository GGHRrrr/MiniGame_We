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
        
    }
}
