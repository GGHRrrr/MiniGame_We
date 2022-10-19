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
       yilaguan,
       shengzi,
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
            case ItemType.yilaguan:
                return ItemAssets.Instance.yilaguan_Spr;
                case ItemType.shengzi:
                return ItemAssets.Instance.shengzi_Spr;
        }
    }
}
