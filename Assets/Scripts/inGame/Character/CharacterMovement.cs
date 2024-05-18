using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{  
    [SerializeField][Header("Stats")]private float speed;
    [SerializeField]private short facingRight=1;
    private Animator anim;
    private Rigidbody2D rgb2d;
    [HideInInspector]public bool stop;
    private bool isLadder;
    private float currentGravity;
   
    private void Start() {
        rgb2d=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        currentGravity=GetComponent<Rigidbody2D>().gravityScale;
    }
    void FixedUpdate()
    {
        if(stop==false)
        Move();
        else
        rgb2d.velocity=Vector2.zero;

        Anime();
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
            anim.SetFloat("climbing",vertical);
        }

        if (horizontal>0&&facingRight==-1||horizontal<0&&facingRight==1)
        {
            Flip();
        }
    }
    void Anime()
    { 
         anim.SetFloat("speed",Math.Abs(rgb2d.velocity.x));
         anim.SetBool("isClimbing",isLadder);
    }
    void Flip()
    {
        facingRight*=-1;
        transform.localScale=new Vector2(transform.localScale.x*-1,transform.localScale.y);
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
