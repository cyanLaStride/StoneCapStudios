using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSlimes : MonoBehaviour
{
    // inspector setting
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    // basic setting
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
    // stun setting
    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;

    private float distance;
    [SerializeField]
    private float playSoundDistance;
    private float soundTimer;
    [SerializeField]
    private float triggerSoundTime;
    private bool isSoundPlayed;

    [SerializeField]
    private Collider2D tossCollider;

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
        // checking player
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= playSoundDistance && !isSoundPlayed)
        {
            AudioManager.Instance.PlayFireAndIceSFX("Slime");
            isSoundPlayed = true;
        }
        else if (isSoundPlayed)
        {
            soundTimer += Time.deltaTime;
            if (soundTimer >= triggerSoundTime)
            {
                isSoundPlayed = false;
                soundTimer = 0.0f;
            }
        }
        // movement
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
            tossCollider.enabled = false;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                isStun = false;
                tossCollider.enabled = true;
                animator.enabled = true;
            }
        }
        // flipping sprite when hitting wall
        if (isGrounded && isRight && !isStun)
        {
            flip();
        }
        else if (isGrounded && !isRight && !isStun)
        {
            flip();
        }
        // checking for same level
        if (player.transform.position.y - 1 >= transform.position.y - 0.5 && player.transform.position.y - 1 <= transform.position.y + 0.5)
        {
            isRage = true;
        }
        else if (player.transform.position.y - 1 < transform.position.y - 0.6 || player.transform.position.y - 1 > transform.position.y + 0.6)
        {
            isRage = false;
        }
    }
    // flip method
    private void flip()
    {
        isRight = !isRight;
        transform.Rotate(new Vector3(0, 180, 0));
        speed = -speed;
    }
    // checking getting hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true; 
        }
    }
    // aduio circle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(flipCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere (transform.position, playSoundDistance);
    }
}
