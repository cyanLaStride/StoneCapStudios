using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BarkBeast : MonoBehaviour
{
    /* rip code
    // camera position
    [SerializeField]
    private Camera cameraPos;
    private Vector3 originalPos;

    // random number max and min
    [SerializeField]
    private float randomRangeMax;
    [SerializeField] 
    private float randomRangeMin;
    [SerializeField]
    private int timeBetweenShake;

    // shake
    [SerializeField]
    private int shakeAmount;
    private bool shake;
    */
    // all componenet
    [SerializeField]
    private PlayerController player;
    public GameObject flipCheck;
    public LayerMask ground;
    public Animator animator;
    public Rigidbody2D rb;

    // checking
    [SerializeField]
    private bool isRight;
    public bool isGrounded;
    public float circleRadius;
    public bool isIdle;
    public bool isStun;
    public bool isSlowed;

    // speed
    [SerializeField]
    private float speedDecreasePercentage;
    private float characterSpeed;

    // field for basic
    [SerializeField]
    private float speed;
    [SerializeField]
    private float runningRange;
    [SerializeField]
    private float attackRange;
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
        //originalPos = cameraPos.transform.position;
        rb = GetComponent<Rigidbody2D>();
        //spriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isIdle = true;
        isSlowed = false;
        characterSpeed = player.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // checking for distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= runningRange && !isStun)
        {
            isIdle = false;
            idleTimer = 0.0f;
            animator.SetBool("BWalking", true);
            if (distance <= attackRange && !isSlowed)
            {
                player.movementSpeed = characterSpeed * (1 / speedDecreasePercentage);
                animator.SetTrigger("BAttack");
                isSlowed = true;
            }
        }
        else if (distance >= runningRange && isSlowed)
        {
            isSlowed = false;
            idleTimer += Time.deltaTime;
            player.movementSpeed = characterSpeed;
            if (idleTime <= idleTimer)
            {
                isIdle = true;
                animator.SetBool("BWalking", false);
                idleTimer = 0.0f;
            }
        }
        if (!isIdle && !isStun)
        {
            rb.velocity = Vector2.right * speed * 100 * Time.fixedDeltaTime;
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
            player.movementSpeed = characterSpeed;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                isStun = false;
                animator.enabled = true;
            }
        }
        /*
        if (shake)
        {
            for (int i = 0; i < shakeAmount; i++)
            {
                Debug.Log("boop");
                cameraPos.transform.position += new Vector3(Random.Range(-randomRangeMin, randomRangeMax), Random.Range(-randomRangeMin, randomRangeMax), 0);
            }
        }
        */
    }

    // change direction
    private void flip()
    {
        isRight = !isRight;
        transform.Rotate(new Vector3(0, 180, 0));
        speed = -speed;
    }

    // when entering bark range?
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player") && !isStun)
        //{
        //    animator.SetTrigger("BAttack");
        //    player.movementSpeed = characterSpeed * (1 / speedDecreasePercentage);
        //}
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //cameraPos.transform.position = originalPos;
            //shake = false;
            player.movementSpeed = characterSpeed;
        }
    }
    */

    // making the radius of circle visible
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(flipCheck.transform.position, circleRadius);
    }
}
