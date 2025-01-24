using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Frog : MonoBehaviour
{
    // input sprite, rigidbody, and animation
    public SpriteRenderer spriteR;
    public Rigidbody2D rb;
    public Animator animator;
    // public Animator animator; //later for animation
    // setting up "enum" when animation is testing !!! remember

    // checking frog action
    private bool isGround = false;
    private bool isFacingR = false;
    private bool isFacingL = true;
    private bool isIdle;
    private bool isJump; // animation

    // setting up frog setting
    private float jumpTimer;
    [SerializeField]
    private float frogJumpSpeedX;
    [SerializeField]
    private float frogJumpFroceY;
    // private float frogLastXPos;
    private float frogCurrentPos;
    private float currentTimer = 0;
    public float frogIdleTime;
    private int jumpDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // fixed update specifically dealing with rigidbody (gravity stuff) and timer
    private void FixedUpdate()
    {
        if (isIdle)
        {
            currentTimer += Time.deltaTime;
            animator.SetBool("Fidle", true);
            if (currentTimer >= frogIdleTime)
            {
                currentTimer = 0;
                frogJump();
            }
        }
        else if (isJump)
        {
            animator.SetBool("Fjump", true);
        }
    }

    // method handle frog jumping 
    private void frogJump()
    {
        //isJump = true; // jumping animation
        //isIdle = false;
        animator.SetTrigger("FJump");
        if (isFacingR)
        {
            spriteR.flipX = true;
            jumpDirection = 1;
        }
        else if (isFacingL)
        {
            spriteR.flipX = false;
            jumpDirection = -1;
        }

        rb.velocity = new Vector2(frogJumpSpeedX * jumpDirection, frogJumpFroceY);
        
    }

    // jump stuff from Daniel
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
            isIdle = true;
            isJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }
    // on triggerEnter2D if needed or another method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FrogTurnRight")
        {
            isFacingR = true;
            isFacingL = false;
        }
        else if (collision.gameObject.tag == "FrogTurnLeft")
        {
            isFacingL = true;
            isFacingR = false;
        }
    }
}
