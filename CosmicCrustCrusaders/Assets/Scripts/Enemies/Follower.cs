using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    // setting up values
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private int targetDistance;

    // checking distance
    private float distance;
    [SerializeField]
    private float playSoundDistance;

    // stun setting
    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;
    [SerializeField]
    private Collider2D tossCollider;

    // audio timer
    private float soundTimer;
    [SerializeField]
    private float triggerSoundTime;
    private bool isSoundPlayed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isSoundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // checking for distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < targetDistance && !isStun)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (isStun)
        {
            animator.enabled = false;
            tossCollider.enabled = false;
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
            {
                tossCollider.enabled = true;
                isStun = false;
                stunTimer = 0;
                animator.enabled = true;
            }
        }
        // play audio
        if (distance <= playSoundDistance && !isSoundPlayed)
        {
            AudioManager.Instance.PlayFireAndIceSFX("FireMoth");
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
        // flipping spirte based on player position
        if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    // playing animation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("MAttack");
        }
        else if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }
    // audio circle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playSoundDistance);
    }
}
