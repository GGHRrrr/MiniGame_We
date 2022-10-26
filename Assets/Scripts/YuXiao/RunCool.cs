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

    //���
    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint;


    //�Ƿ��ڹ���״̬
    bool isHook;

    //����ǧ�����ĵ�
    public Transform pivot;
    //�������ӵ�λ��
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
        //�����ƶ�����ģ���¼�
        //EventManager.Instance().AddEventListener("KeyDown", CheckKeyDown);
    }

    private void Update()
    {
        if (isOpen)
        {
            UseHook();
        }
    }

    //�л���ģ���״̬����
    public void SwitchOpen(bool isOpen1)
    {
        isOpen = isOpen1;
    }

    //����ģ��
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


    //�ų���������
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
