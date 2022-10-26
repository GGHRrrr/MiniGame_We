using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Inventory : MonoBehaviour
{
/// <summary>
///ui??? 
/// </summary>
    private Inventory inventory;
    private Transform itemContainer;//ui????
    private Transform items;//????
    private void Awake()
    {
        itemContainer = transform.Find("BagPanel").transform;
        items = itemContainer.Find("Items").transform;
    }
    /// <summary>
    /// ??????§Ö???????ui?????
    /// </summary>
    /// <param name="_inventory"></param>
    public void SetInventory(Inventory _inventory)
    {
        inventory = _inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshUIInventory();
    }

    /// <summary>
    /// ???UI
    /// </summary>
    public void RefreshUIInventory()
    {   
        foreach(Transform child in itemContainer)
        {
            if (child == items) continue;
            Destroy(child.gameObject);
        }

        foreach(Item item in inventory.GetListItems())
        {
            RectTransform itemRectTransfor = Instantiate(items, itemContainer).GetComponent<RectTransform>();
            itemRectTransfor.gameObject.SetActive(true);
            itemRectTransfor.Find("Image").GetComponent<Button>().onClick.AddListener(() =>
            {
                inventory.RemoveItem(item);//???????
                inventory.UseItem(item);//????????
            }
            );
            itemRectTransfor.Find("Image").GetComponent<Image>().sprite = item.GetSprite();
            itemRectTransfor.Find("count").GetComponent<Text>().text = item.amount.ToString();
        }
    }
   
}
