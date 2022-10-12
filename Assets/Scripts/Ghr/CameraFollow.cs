using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;//���λ��
    private Transform yiyiTarget;//yiyiλ��
    public float smoothSpeed;//ƽ��ֵ
    public Vector2 minPos,maxPos;//�����Сλ��
    private SwitchRole switchRole;
    private void Start()
    {
        playerTarget = GameObject.Find("Player/Human").transform;
        yiyiTarget= GameObject.Find("Player/yiyi").transform;
        switchRole=playerTarget.GetComponent<SwitchRole>();
    }
    /// <summary>
    /// �����������
    /// </summary>
    private void FixedUpdate()
    {
        if (playerTarget != null&&switchRole.IsFollow)
        {
            if(playerTarget.transform.position.x!=transform.position.x)
            {
                Vector3 pos;
                pos = new Vector2(playerTarget.position.x, transform.position.y);
                pos.x = Mathf.Clamp(pos.x,minPos.x, maxPos.x);
                transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
            }
        }
        if(yiyiTarget!=null&&switchRole.IsFollow==false)
        {
            if (yiyiTarget.transform.position.x != transform.position.x)
            {
                Vector3 pos;
                pos = new Vector2(yiyiTarget.position.x, transform.position.y);
                pos.x = Mathf.Clamp(pos.x, minPos.x, maxPos.x);
                transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
            }
        }
    }
        
}
