using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_DragTest : MonoBehaviour
{  
    //[SerializeField]
    private Camera camera;
    private Vector3 offset_obj;
    private void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void OnMouseDown()
    {
        Vector3 objSreenPos = camera.WorldToScreenPoint(transform.position);//将对象位置转换为屏幕坐标
        Vector3 mousScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objSreenPos.z);//获取鼠标位置
        Vector3 offet = transform.position - camera.ScreenToWorldPoint(mousScreenPos);//物体位置与角色位置相减获得偏移量
        offset_obj = offet ;
    }
    private void OnMouseDrag()
    {
        Vector3 objSreenPos = camera.WorldToScreenPoint(transform.position);//将对象位置转换为屏幕坐标
        //改变物体位移，偏移量+当前鼠标的世界坐标
        transform.position = offset_obj + camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objSreenPos.z));
        
    }
}
