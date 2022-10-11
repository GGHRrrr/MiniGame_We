using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAtCamera : MonoBehaviour
{
    Transform m_Camera;

    void Start()
    {
        // ��ȡ�������main camera
        m_Camera = Camera.main.transform;
    }

    // ��LateUpdate, ��ÿһ֡��������Canvas����
    void LateUpdate()
    {
        if (m_Camera == null)
        {
            return;
        }
        // ��ɫ�����UI�������෴�ģ����ֱ����LookAt()����Ҫ��ÿ��UIԪ����ת������
        // Ϊ�˼򵥣������������������ʵ������һ��������ת�����Լ����Ϊ������������
        transform.rotation = Quaternion.LookRotation(transform.position - m_Camera.position);
    }
}
