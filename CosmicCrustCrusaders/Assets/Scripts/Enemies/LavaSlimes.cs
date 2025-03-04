using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSlimes : MonoBehaviour
{
    // player and checking
    //private bool checkSameLevel;

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speed;
    private bool isRage;
    [SerializeField]
    private int speedMultiplier;
    //private int direction;
    public GameObject flipCheck;
    public LayerMask ground;
    private bool isRight;
    public float circleRadius;
    public bool isGrounded;

    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //checkSameLevel = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isRage && !isStun)
        {
            animator.SetBool("Rage",true);
            rb.velocity = Vector2.right * speed * speedMultiplier * Time.fixedDeltaTime;
            isGrounded = Physics2D.OverlapCircle(flipCheck.transform.position, circleRadius, ground);
        }
        else if (!isRage && !isStun)
        {
            animator.SetBool("Rage", false);
            rb.velocity = Vector2.right * speed * Time.fixedDeltaTime;
            isGrounded = Physics2D.OverlapCircle(flipCheck.transform.position, circleRadius, ground);
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
        if (isGrounded && isRight && !isStun)
        {
            flip();
        }
        else if (isGrounded && !isRight && !isStun)
        {
            flip();
        }
        if (player.transform.position.y - 1 >= transform.position.y - 0.3 && player.transform.position.y - 1 <= transform.position.y + 0.3)
        {
            isRage = true;
        }
        else if (player.transform.position.y - 1 < transform.position.y - 0.4 || player.transform.position.y - 1 > transform.position.y + 0.4)
        {
            isRage = false;
        }

        
        //Debug.Log(isRage);
    }
    private void flip()
    {
        isRight = !isRight;
        transform.Rotate(new Vector3(0, 180, 0));
        speed = -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true; 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(flipCheck.transform.position, circleRadius);
    }
}
