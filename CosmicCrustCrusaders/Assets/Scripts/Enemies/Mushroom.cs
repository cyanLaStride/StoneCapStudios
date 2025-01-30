using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // input sprite, rigidbody, and animation
    //public SpriteRenderer spriteR;
    public Rigidbody2D rb;
    public GameObject flipCheck;
    public LayerMask ground;
    public Animator animator;
    public GameObject player;

    // tigger for mushroom moving left or right
    [SerializeField]
    private bool isRight;
    public bool isGrounded;
    public float circleRadius;
    public bool isIdle;
    public bool isStun;

    // field for basic
    [SerializeField]
    private float speed;
    [SerializeField]
    private float runningRange;
    private float distance;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;
    [SerializeField]
    private float idleTime;
    private float idleTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isIdle = true;
    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < runningRange)
        {
            isIdle = false;
            idleTimer = 0.0f;
            animator.SetBool("RRunning",true);
        }
        else if(distance > runningRange)
        {
            idleTimer += Time.deltaTime;
            if (idleTime <= idleTimer)
            {
                isIdle = true;
                animator.SetBool("RRunning",false);
                idleTimer = 0.0f;
            }
        }
        // if rushroom is not idle
        if (!isIdle && !isStun)
        {
            rb.velocity = Vector2.right * speed * 1000 * Time.deltaTime;
            isGrounded = Physics2D.OverlapCircle(flipCheck.transform.position, circleRadius, ground);
            if (isGrounded && isRight)
            {
                flip();
            }
            else if (isGrounded && !isRight)
            {
                flip();
            }
        }
        else if (isStun)
        {
            animator.enabled = false;
            stunTimer += Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                isStun = false;
                animator.enabled = true;
            }
        }
    }

    // when player hit rushroom
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("RAttack");
        }
        else if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }

    // changing direction
    private void flip()
    {
        isRight = !isRight;
        transform.Rotate(new Vector3(0, 180, 0));
        speed = -speed;
    }

    // making the radius of circle visible
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(flipCheck.transform.position, circleRadius);
    }
}
