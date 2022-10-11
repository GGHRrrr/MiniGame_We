using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(DistanceJoint2D))]
public class RunCool : MonoBehaviour
{
    //��ģ���Ƿ���(���Խ׶Σ������޸ķ���Ȩ��)
    public bool isOpen;

    //�����ܿ�״̬���л�Ϊ����ģʽ
    public bool IsOpen
    {
        get { return isOpen; }
        set
        {
            isOpen = value;
            GetComponent<SwitchRole>().IsFollow = true;
            
        }
    }
    //��Ծ��
    public float jumpForce;

    //���
    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint;
    private Rigidbody2D rigidbody;


    //�Ƿ��ڹ���״̬
    bool isHook;
    //�Ƿ��ڵ���״̬
    bool canJump;

    //����ǧ�����ĵ�
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
        //�����ƶ�����ģ���¼�
        EventManager.Instance().AddEventListener("Key", CheckKeyDown);
    }

    //�л���ģ���״̬����
    public void SwitchOpen(bool isOpen1)
    {
        isOpen = isOpen1;
    }


    //����������
    void CheckKeyDown(object key)
    {
        if (isOpen)
        {
            if ((KeyCode)key == KeyCode.W && canJump)
            {
                Jump();
            }
            //if (canSwing)
            Debug.Log("����");

            UseHook(key);
        }
        
    }

    //��Ծ�߼�
    private void Jump()
    {
        rigidbody.velocity = new Vector2(0, jumpForce);
        //����Ծ����Ϊfalse
        canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }


    //����ģ��
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


    //�ų���������
    void Hook(Vector2 pivotPos)
    {
        if (isHook && Vector3.Distance(lineRenderer.GetPosition(0), pivotPos) > 0.1f)
        {
            a += Time.deltaTime * 10;
            lineRenderer.SetPosition(0, Vector3.Lerp(transform.position, pivotPos, a));
        }
        else if (isHook && Vector3.Distance(lineRenderer.GetPosition(0), pivotPos) < 0.1f)
        {
            //Debug.Log("С��0.1");
            a = 0;
            distanceJoint.connectedAnchor = pivotPos;
            distanceJoint.enabled = true;
        }
    }
}
