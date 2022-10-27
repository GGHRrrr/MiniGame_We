using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YiYi : MonoBehaviour
{
    private Inventory inventory;
    private Player pla;
    [SerializeField] private UI_Inventory uiInventory;
    private void Start()
    {
        pla = GameObject.Find("Player/Human").GetComponent<Player>();
        inventory = pla.Inventory;
        uiInventory.SetInventory(inventory);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.gameObject.SetActive(false);
        }
    }
}
