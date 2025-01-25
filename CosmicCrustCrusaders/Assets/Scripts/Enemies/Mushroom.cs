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

    // field for basic
    [SerializeField]
    private float speed;
    private float decreaseSpeed = 0.001f;
    [SerializeField]
    private float runningRange;
    private float distance;

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
            animator.SetBool("RRunning",true);
        }
        // if rushroom is not idle
        if (!isIdle)
        {
            rb.velocity = Vector2.right * speed * Time.deltaTime;
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
    }

    // when player hit rushroom
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("RAttack");
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
