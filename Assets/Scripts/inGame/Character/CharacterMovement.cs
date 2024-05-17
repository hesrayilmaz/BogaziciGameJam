using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{  
    [SerializeField][Header("Stats")]private float speed;
    private Rigidbody2D rgb2d;
    private bool isLadder;
    private float currentGravity;

    private void Start() {
        rgb2d=GetComponent<Rigidbody2D>();
        currentGravity=GetComponent<Rigidbody2D>().gravityScale;
    }

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        rgb2d.velocity=new Vector2(horizontal*speed,rgb2d.velocity.y);

        if (isLadder)
        {
           rgb2d.gravityScale=0f;
           rgb2d.velocity=new Vector2(rgb2d.velocity.x,speed*vertical);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Ladder")
        {
           isLadder=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
       if(other.gameObject.tag=="Ladder")
        {
           isLadder=false;
           rgb2d.gravityScale=currentGravity;
        }
    }
}
