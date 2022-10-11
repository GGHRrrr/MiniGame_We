using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;//���λ��
    public float smoothSpeed;//ƽ��ֵ
    public Vector2 minPos,maxPos;//�����Сλ��

    private void Start()
    {
        playerTarget = GameObject.Find("Player/Human").transform;
    }
    /// <summary>
    /// �����������
    /// </summary>
    private void FixedUpdate()
    {
        if (playerTarget != null)
        {
            if(playerTarget.transform.position.x!=transform.position.x)
            {
                Vector3 pos;
                pos = new Vector2(playerTarget.position.x, transform.position.y);
                pos.x = Mathf.Clamp(pos.x,minPos.x, maxPos.x);
                transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
            }
        }
    }
        
}
