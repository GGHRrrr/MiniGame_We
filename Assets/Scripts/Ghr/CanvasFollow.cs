using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollow : MonoBehaviour
{
    public Transform followTarget;
    public float smoothSpeed;

    private void Start()
    {
        followTarget = GameObject.Find("Player/Human/DialoguePlayer").transform;
        print(followTarget);
    }

    void Update()
    {
        if (followTarget.transform.position.x != transform.position.x)
        {
            Vector3 pos;
            pos = new Vector3(followTarget.position.x, transform.position.y,10);
            transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
        }
    }
}
