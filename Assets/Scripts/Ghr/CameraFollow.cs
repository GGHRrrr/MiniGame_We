using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;//玩家位置
    public float smoothSpeed;//平滑值
    public Vector2 minPos,maxPos;//最大最小位置

    private void Start()
    {
        playerTarget = GameObject.Find("Player").transform;
    }
    /// <summary>
    /// 进行相机跟随
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
