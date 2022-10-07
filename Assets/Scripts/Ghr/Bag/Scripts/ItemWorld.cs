using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{

    /// <summary>
    /// 动态生成道具的函数
    /// </summary>
    /// <param name="positon"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public static ItemWorld SpawnItemWorld(Vector3 positon,Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, positon, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
    private Item item;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetItem(Item _item)
    {
        item = _item;
        spriteRenderer.sprite = item.GetSprite();
    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
