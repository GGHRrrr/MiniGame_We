using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(DistanceJoint2D))]
public class RunCool : MonoBehaviour
{
    //该模块是否开启(测试阶段，后面修改访问权限)
    public bool isOpen;

    //开启跑酷状态后将切换为跟随模式
    public bool IsOpen
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            GetComponent<SwitchRole>().IsFollow = true;

        }
    }

    //组件
    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint;


    //是否处于钩锁状态
    bool isHook;

    //荡秋千的轴心点
    public Transform pivot;
    //手拿绳子的位置
    public Transform hookTrans;
  
    float a = 0;
    
    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();
        lineRenderer.enabled = false;
        distanceJoint.enabled = false;

        isOpen = false;
        //canSwing = false;
        //isOpen = true;
        //引入移动输入模块事件
        //EventManager.Instance().AddEventListener("KeyDown", CheckKeyDown);
    }

    private void Update()
    {
        if (isOpen)
        {
            UseHook();
        }
    }

    //切换该模块的状态开启
    public void SwitchOpen(bool isOpen1)
    {
        isOpen = isOpen1;
    }

    //钩锁模块
    private void UseHook()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lineRenderer.enabled = true;
            isHook = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            lineRenderer.enabled = false;
            distanceJoint.enabled = false;
            isHook = false;
        }
        lineRenderer.SetPosition(1, hookTrans.position);
        Hook(pivot.position);
    }


    //放出钩锁操作
    private void Hook(Vector2 pivotPos)
    {
        if (isHook && Vector3.Distance(lineRenderer.GetPosition(0), pivotPos) > 0.1f)
        {
            a += Time.deltaTime * 10;
            lineRenderer.SetPosition(0, Vector3.Lerp(transform.position, pivotPos, a));
        }
        else if (isHook && Vector3.Distance(lineRenderer.GetPosition(0), pivotPos) < 0.1f)
        {
            a = 0;
            distanceJoint.connectedAnchor = pivotPos;
            distanceJoint.enabled = true;
        }
    }
}
