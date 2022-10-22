using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapX : MonoBehaviour
{
    public Animator Mapx;
    public int Xnum;
    void Start()
    {
        //Xnum = PlayerController.instance.XNum;
        if (Xnum >= 1)
        {
            Mapx.SetBool(01, true);
        }
        if (Xnum >= 2)
        {
            Mapx.SetBool(02, true);
        }
        if (Xnum >= 3)
        {
            Mapx.SetBool(03, true);
        }
        if (Xnum >= 4)
        {
            Mapx.SetBool(04, true);
        }
        if (Xnum >= 5)
        {
            Mapx.SetBool(05, true);
        }
        if (Xnum >= 6)
        {
            Mapx.SetBool(06, true);
        }
    }

}
