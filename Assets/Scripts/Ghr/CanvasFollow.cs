using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollow : MonoBehaviour
{
    private Transform playerTarget;
    public float smoothSpeed;
    private void Start()
    {
        playerTarget = GameObject.Find("Player/Human").transform;
    }
    void Update()
    {
        if (playerTarget.transform.position.x != transform.position.x)
        {
            Vector3 pos;
            pos = new Vector3(playerTarget.position.x, transform.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
        }
    }
}
