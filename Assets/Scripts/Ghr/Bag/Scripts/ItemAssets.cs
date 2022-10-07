using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{  
    /// <summary>
    /// ���ߵ��ʲ�
    /// </summary>
    private  static ItemAssets _instance;
    public static ItemAssets Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {  
        _instance = this;
    }

    public Sprite batter_Spr;
    public Sprite sword_Spr;
    public Transform pfItemWorld;
}
