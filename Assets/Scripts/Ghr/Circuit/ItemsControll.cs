using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 方向类型，上下左右
/// </summary>
public enum DirectionType
{
    up,
    down,
    left,
    right
}
public class ItemsControll : MonoBehaviour
{
    public DirectionType myDir=DirectionType.up;//目前的方向类型
    public DirectionType trueDir;//正确的方向
    public bool isTrue=false;//是否正确
    private void Start()
    {
        Debug.Log(gameObject.name);
    }
    /// <summary>
    /// 当鼠标点击时进行判断
    /// </summary>
    private void OnMouseDown()
    {
        switch (myDir)
        {
            case DirectionType.up:
                myDir = DirectionType.right;
                gameObject.transform.Rotate(new Vector3(0, 0, -90f));//设置方向，并进行旋转
                if (myDir == trueDir)
                    isTrue = true;
                else
                    isTrue = false;//判断是否为正确方向，是则为true否则为false
                Debug.Log("目前" + myDir + " " + isTrue);
                ContentControll.instance.CheckItems();//调用检查脚本，遍历子物体进行判断
                break;
            case DirectionType.right:
                myDir = DirectionType.down;
                gameObject.transform.Rotate(new Vector3(0, 0, -90f));
                if (myDir == trueDir)
                    isTrue = true;
                else
                    isTrue = false;
                Debug.Log("目前" + myDir + " " + isTrue);
                ContentControll.instance.CheckItems();
                break;
            case DirectionType.down:
                myDir = DirectionType.left;
                gameObject.transform.Rotate(new Vector3(0, 0, -90f));
                if (myDir == trueDir)
                    isTrue = true;
                else
                    isTrue = false;
                Debug.Log("目前" + myDir + " " + isTrue);
                ContentControll.instance.CheckItems();
                break;
            case DirectionType.left:
                myDir = DirectionType.up;
                gameObject.transform.Rotate(new Vector3(0, 0, -90f));
                if (myDir == trueDir)
                    isTrue = true;
                else
                    isTrue = false;
                Debug.Log("目前" + myDir + " " + isTrue);
                ContentControll.instance.CheckItems();
                break;
           

        }
    }
}
