using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //跳跃力
    public float jumpForce;

    //组件
    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint;
    private Rigidbody2D rigidbody;


    //是否处于钩锁状态
    bool isHook;
    //是否处于地面状态
    bool canJump;

    //荡秋千的轴心点
    public Transform pivot;
  
    float a = 0;
    
    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        lineRenderer.enabled = false;
        distanceJoint.enabled = false;

        isOpen = false;
        //canSwing = false;
        //isOpen = true;
        //引入移动输入模块事件
        EventManager.Instance().AddEventListener("Key", CheckKeyDown);
    }

    //切换该模块的状态开启
    public void SwitchOpen(bool isOpen1)
    {
        isOpen = isOpen1;
    }


    //检测键盘输入
    void CheckKeyDown(object key)
    {
        if (isOpen)
        {
            if ((KeyCode)key == KeyCode.W && canJump)
            {
                Jump();
            }
            //if (canSwing)
            Debug.Log("哈哈");

            UseHook(key);
        }
        
    }

    //跳跃逻辑
    private void Jump()
    {
        rigidbody.velocity = new Vector2(0, jumpForce);
        //将跳跃设置为false
        canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }


    //钩锁模块
    void UseHook(object key)
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.F))
        {
            lineRenderer.enabled = true;
            isHook = true;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            lineRenderer.enabled = false;
            distanceJoint.enabled = false;
            isHook = false;
        }
        lineRenderer.SetPosition(1, transform.position);
        Hook(pivot.position);
    }


    //放出钩锁操作
    void Hook(Vector2 pivotPos)
    {
        if (isHook && Vector3.Distance(lineRenderer.GetPosition(0), pivotPos) > 0.1f)
        {
            a += Time.deltaTime * 10;
            lineRenderer.SetPosition(0, Vector3.Lerp(transform.position, pivotPos, a));
        }
        else if (isHook && Vector3.Distance(lineRenderer.GetPosition(0), pivotPos) < 0.1f)
        {
            //Debug.Log("小于0.1");
            a = 0;
            distanceJoint.connectedAnchor = pivotPos;
            distanceJoint.enabled = true;
        }
    }
}
