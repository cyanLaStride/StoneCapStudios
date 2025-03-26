using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerhead : MonoBehaviour
{
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
    [SerializeField]
    private Transform flowerBase;
    [SerializeField]
    private int radius;

    private float distance;
    private float toBaseDistance;
    [SerializeField]
    private float playSoundDistance;

    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;
    [SerializeField]
    private Collider2D tossCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        toBaseDistance = Vector2.Distance(flowerBase.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (toBaseDistance < radius && !isStun)
        {
            if (distance < targetDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
            }
            else if (distance > toBaseDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, flowerBase.transform.position, speed * Time.fixedDeltaTime);
            }
        }
        else if(toBaseDistance >= radius && !isStun)
        {
                transform.position = Vector2.MoveTowards(this.transform.position, flowerBase.transform.position, speed * Time.fixedDeltaTime);
        }
        else if (isStun)
        {
            animator.enabled = false;
            tossCollider.enabled = false;
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                tossCollider.enabled = true;
                isStun = false;
                animator.enabled = true;
            }
        }
        if (distance <= playSoundDistance)
        {
            AudioManager.Instance.PlayFireAndIceSFX("SnowAngel");
        }
        if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("SnowAttack");
        }
        else if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playSoundDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetDistance);
    }
}
