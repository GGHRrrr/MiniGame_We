using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����������
/// </summary>
public class Item 
{
/// <summary>
/// ���ߵ���ʽ
/// </summary>
    public enum ItemType
    {
        battery,
        sword
    }
    /// <summary>
    /// ���ߵĵ����ͣ����������ԵĶ���
    /// </summary>
    public ItemType itemType;
    public int amount;
    /// <summary>
    /// ͨ�������õ��õ��ߵ�ͼƬ
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.battery:
                return ItemAssets.Instance.batter_Spr;
            case ItemType.sword:
                return ItemAssets.Instance.sword_Spr;
        }
    }
}
