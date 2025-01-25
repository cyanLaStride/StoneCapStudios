using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // input sprite, rigidbody, and animation
    public SpriteRenderer spriteR;
    public Rigidbody2D rb;
    public GameObject flipCheck;
    public LayerMask ground;
    public Animator animator;

    // tigger for mushroom moving left or right
    [SerializeField]
    private bool isRight;
    public bool isGrounded;
    public float circleRadius;

    // field for basic
    [SerializeField]
    private float speed;
    private float decreaseSpeed = 0.001f;
    [SerializeField]
    private float runningRange;
    [SerializeField]
    private float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        flipCheck = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Debug.Log(Physics2D.OverlapCircle(flipCheck.transform.position, circleRadius, ground));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isRight = !isRight;
            transform.Rotate(new Vector3(0, 180, 0));
            speed = -speed;
        }
    }

    private void flip()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(flipCheck.transform.position, circleRadius);
    }
}
