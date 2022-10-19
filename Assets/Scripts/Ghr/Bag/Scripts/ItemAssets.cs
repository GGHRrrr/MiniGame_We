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

    public Sprite yilaguan_Spr;
    public Sprite shengzi_Spr;
    public Transform pfItemWorld;
}
