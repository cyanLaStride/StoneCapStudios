using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementGolem : MonoBehaviour
{
    // setting up
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GolemRock gl;

    // timer to change golem form
    [SerializeField]
    private float changeStateTime;
    private float timer;

    // checking for player
    [SerializeField]
    private PlayerController player;
    private float distance;
    [SerializeField]
    private float playSoundDistance;
    private float soundTimer;
    [SerializeField]
    private float triggerSoundTime;
    private bool isSoundPlayed;
    private float originalSpeed;
    [SerializeField]
    private float speedmultiplier;

    // controlling collider and stun
    [SerializeField]
    private Collider2D tossCollider;
    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;

    // slowed timer
    public bool isSlowed;
    private float slowedTimer;
    private float slowedTime;
    private float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        originalSpeed =  gl.speed;
        playerSpeed = player.movementSpeed;
    }

    // Update is called once per 
    private void FixedUpdate()
    {
        // audio play distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= playSoundDistance && !isSoundPlayed)
        {
            AudioManager.Instance.PlayFireAndIceSFX("Golem");
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
        // changing form 
        if (!isStun)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= changeStateTime && timer <= changeStateTime + 0.1f)
            {
                animator.SetTrigger("FGolem");
                gl.speed = originalSpeed * speedmultiplier;
            }
            else if (timer >= changeStateTime * 2 && timer <= changeStateTime * 2 + 0.1f)
            {
                gl.speed = originalSpeed;
                animator.SetTrigger("IGolem");
            }
            else if (timer >= changeStateTime * 2 + 0.5f)
            {
                timer = 0;
            }
            if (isSlowed)
            {
                player.movementSpeed = playerSpeed * 0.5f;
                slowedTimer += Time.fixedDeltaTime;
                if (slowedTimer >= slowedTime)
                {
                    isSlowed = false;
                    player.movementSpeed = playerSpeed;
                    slowedTimer = 0.0f;
                }
            }
        }
        // when stun
        else if (isStun)
        {
            gl.speed = 0;
            animator.enabled = false;
            tossCollider.enabled = false;
            player.movementSpeed = playerSpeed;
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                tossCollider.enabled = true;
                gl.speed = originalSpeed;
                isStun = false;
                animator.enabled = true;
            }
        }
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
        Gizmos.DrawWireSphere(transform.position, playSoundDistance);
    }
}
