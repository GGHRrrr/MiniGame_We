using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Inventory : MonoBehaviour
{
/// <summary>
///ui仓库 
/// </summary>
    private Inventory inventory;
    private Transform itemContainer;//ui容器
    private Transform items;//道具
    private void Awake()
    {
        itemContainer = transform.Find("BagPanel").transform;
        items = itemContainer.Find("Items").transform;
    }
    /// <summary>
    /// 将仓库中的数据在ui中刷新
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
    /// 刷新UI
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
                inventory.RemoveItem(item);//道具移除
                inventory.UseItem(item);//道具的使用
            }
            );
            itemRectTransfor.Find("Image").GetComponent<Image>().sprite = item.GetSprite();
            Debug.Log("string" + item.amount.ToString());
            itemRectTransfor.Find("count").GetComponent<Text>().text = item.amount.ToString();
        }
    }
   
}
