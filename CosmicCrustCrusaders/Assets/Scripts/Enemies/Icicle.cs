using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    // Start is called before the first frame update
    // cool particle effect later
    // freeze character?

    // player speed
    [SerializeField]
    private PlayerController player;
    private float characterSpeed;
    static public bool freezePlayer;

    [SerializeField]
    private Animator animator;
    // timer
    private float timer;
    [SerializeField]
    private int freezeDuration;

    static public bool isRight;
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private GameObject iceParticles;
    public SpriteRenderer iceRenderer;

    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;
    [SerializeField]
    private float delayAttack;
    private float attackTimer = 0.0f;
    public bool isAttacked;

    void Start()
    {
        freezePlayer = false;
        isAttacked = true;
        characterSpeed = player.movementSpeed;
        timer = 0;

        animator = GetComponent<Animator>();
        iceRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (freezePlayer)
        {
            if (timer <= freezeDuration)
            {
                player.movementSpeed = 0;
                timer += Time.deltaTime;
            }
            else if (timer > freezeDuration)
            {
                freezePlayer = false;
            }
        }
        else if (!freezePlayer)
        {
            player.movementSpeed = characterSpeed;
            timer = 0;
        }
        if (player.transform.position.x > transform.position.x)
        {
            isRight = true;
            iceRenderer.flipX = true;

            spawnLocation.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.x);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            isRight = false;
            iceRenderer.flipX = false;
            spawnLocation.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.x);
        }
        if (!isStun && isAttacked)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= delayAttack)
            {
                isAttacked = false;
                attackTimer = 0;
            }
        }
        else if (isStun)
        {
            animator.enabled = false;
            stunTimer += Time.deltaTime;
            player.movementSpeed = characterSpeed;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                isStun = false;
                animator.enabled = true;
            }
        }
        else if (!isAttacked && !isStun)
        {
            animator.SetTrigger("IcicleAttack");
            GameObject icicleShoot = Instantiate(iceParticles, spawnLocation.position, spawnLocation.rotation);
            isAttacked = true;
            Debug.Log("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isAttacked && !isStun)
            {
                animator.SetTrigger("IcicleAttack");
                GameObject icicleShoot = Instantiate(iceParticles, spawnLocation.position, spawnLocation.rotation);
                isAttacked = true;
                Debug.Log("Hit");
            }
        }
        */
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }
}
