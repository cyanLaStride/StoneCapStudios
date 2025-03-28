using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BarkBeast : MonoBehaviour
{
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
    [SerializeField]
    private bool isStationery;

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

    [SerializeField]
    private Collider2D tossCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            AudioManager.Instance.PlayJungleSFX("BarkBeast");
            //barkAudioClip.Play();
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
        if (!isIdle && !isStun && !isStationery)
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
            tossCollider.enabled = false;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                isStun = false;
                tossCollider.enabled = true;
                animator.enabled = true;
            }
        }
        else if (isStationery)
        {
            animator.SetBool("BWalking", false);
        }
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
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }

    // making the radius of circle visible
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(flipCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
