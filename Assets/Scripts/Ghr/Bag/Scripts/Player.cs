using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]private  UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = new Inventory(useItem);
        uiInventory.SetInventory(inventory); 
    }
    private void Start()
    {
        //ItemWorld.SpawnItemWorld(new Vector3(0, 0), new Item { itemType = Item.ItemType.battery, amount = 1 });
    }
    private void OnTriggerEnter(Collider other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    /// <summary>
    /// ���ʹ�õ��߲�����Ӱ��
    /// </summary>
    /// <param name="item"></param>
    private void useItem(Item item)
    {
        switch(item.itemType)
        {
            case Item.ItemType.battery:
                Debug.Log("ʹ�õ��");
                break;
            case Item.ItemType.sword:
                Debug.Log("ʹ������");
                break;
        }
    }
}
