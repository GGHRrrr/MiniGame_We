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
        Vector3 objSreenPos = camera.WorldToScreenPoint(transform.position);//������λ��ת��Ϊ��Ļ����
        Vector3 mousScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objSreenPos.z);//��ȡ���λ��
        Vector3 offet = transform.position - camera.ScreenToWorldPoint(mousScreenPos);//����λ�����ɫλ��������ƫ����
        offset_obj = offet ;
    }
    private void OnMouseDrag()
    {
        Vector3 objSreenPos = camera.WorldToScreenPoint(transform.position);//������λ��ת��Ϊ��Ļ����
        //�ı�����λ�ƣ�ƫ����+��ǰ������������
        transform.position = offset_obj + camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objSreenPos.z));
        
    }
}
