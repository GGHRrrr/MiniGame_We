using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{  
    /// <summary>
    /// 道具的资产
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

    public Sprite yilaguan_Spr;
    public Transform pfItemWorld;
}
