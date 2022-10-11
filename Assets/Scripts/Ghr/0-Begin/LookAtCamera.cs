using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAtCamera : MonoBehaviour
{
    Transform m_Camera;

    void Start()
    {
        // 获取场景里的main camera
        m_Camera = Camera.main.transform;
    }

    // 用LateUpdate, 在每一帧的最后调整Canvas朝向
    void LateUpdate()
    {
        if (m_Camera == null)
        {
            return;
        }
        // 角色朝向和UI朝向是相反的，如果直接用LookAt()还需要把每个UI元素旋转过来。
        // 为了简单，用了下面这个方法。实际上是一个反向旋转，可以简单理解为“负负得正”
        transform.rotation = Quaternion.LookRotation(transform.position - m_Camera.position);
    }
}
