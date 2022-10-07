using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    private Rigidbody2D rigi;
    private Animator anim;
    public float moveSpeed;
    private float moveH, moveV;
    private void Start()
    {
        rigi =gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        Move();
        Flip();
    }

    private void Move()
    {
        rigi.velocity = new Vector2(moveH * moveSpeed, transform.position.y);
        if(rigi.velocity.x>0|| rigi.velocity.x<0) anim.SetBool("IsMove", true);
        else
            anim.SetBool("IsMove", false);

    }
    void Flip()
    {
        if(moveH>0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            //anim.SetBool("IsMove", true);
        }
        else if(moveH<0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            //anim.SetBool("IsMove", true);
        }
        //else
        //{
        //    anim.SetBool("IsMove", false);
        //}

    }
}
