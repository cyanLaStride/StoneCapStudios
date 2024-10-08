using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Frog : MonoBehaviour
{
    // input sprite, rigidbody, and animation
    public SpriteRenderer spriteR;
    public Rigidbody2D rb;
    // public Animator animator; //later for animation
    // setting up "enum" when animation is testing !!! remember

    // checking frog action
    private bool isGround = false;
    private bool isFacingR = false;
    private bool isFacingL = true;
    private bool isStun; // upgrades
    private bool isIdle = true;
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
    private float frogIdleTime = 2f;
    private int jumpDirection;


    // Start is called before the first frame update
    void Start()
    {
        isStun = false;
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
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
            if (currentTimer >= frogIdleTime)
            {
                currentTimer = 0;
                frogJump();
            }
        }
        if (isStun)
        {
            rb.velocity = new Vector2 (0, 0);
        }
    }

    // method handle frog jumping 
    private void frogJump()
    {
        isJump = true; // jumping animation
        isIdle = false;
        if (isFacingR)
        {
            jumpDirection = 1;
        }
        else if (isFacingL)
        {
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
        }
        else if (collision.gameObject.tag == "FrogTurnRight")
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }
    // on triggerEnter2D if needed or another method

}
