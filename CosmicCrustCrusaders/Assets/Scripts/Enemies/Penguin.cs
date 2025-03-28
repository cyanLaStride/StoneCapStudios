using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    // setting
    [SerializeField]
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // checking direction
    [SerializeField]
    private bool isRight;
    private int direction;
    [SerializeField]
    private float force;
    [SerializeField]
    private float delayAttack;
    private float attackTimer;
    private bool attack;

    // stun settings
    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer;
    [SerializeField]
    private Collider2D tossCollider;

    // getting component and setting up
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // setting up face direction
        if (!isRight)
        {
            flip();
        }

        attack = true;
    }

    private void FixedUpdate()
    {
        if (!attack && !isStun)
        {
            attackTimer += Time.fixedDeltaTime;
            if (attackTimer > delayAttack)
            {
                flip();
                attack = true;
                attackTimer = 0;
            }
        }
        else if (isStun)
        {
            animator.enabled = false;
            tossCollider.enabled = false;
            stunTimer += Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (stunTimer >= stunTime)
            {
                tossCollider.enabled = true;
                stunTimer = 0;
                isStun = false;
                animator.enabled = true;
            }
        }
    }

    private void flip()
    {
        isRight = !isRight;
        transform.Rotate(new Vector3(0, 180, 0));
        force = -force;
    }

    // when penguin see the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attack && !isStun)
            {
                rb.velocity = Vector2.right * force;
                attack = false;
                AudioManager.Instance.PlayFireAndIceSFX("Penguin");
            }
        }
        else if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }
}
