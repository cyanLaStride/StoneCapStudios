using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
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

    // checking direction and getting gameobject
    static public bool isRight;
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private GameObject iceParticles;
    public SpriteRenderer iceRenderer;

    // control stun
    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;
    [SerializeField]
    private float delayAttack;
    public bool isAttacked;

    // getting collider
    [SerializeField]
    private Collider2D tossCollider;

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
        // freeze player timer
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
        // checking player is left or right from enemeis
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
        // when enemies got stun
        if (isStun)
        {
            animator.enabled = false;
            stunTimer += Time.deltaTime;
            tossCollider.enabled = false;
            player.movementSpeed = characterSpeed;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                isStun = false;
                tossCollider.enabled = true;
                animator.enabled = true;
            }
        }
        else if (!isAttacked && !isStun)
        {
            animator.SetTrigger("IcicleAttack");
            GameObject icicleShoot = Instantiate(iceParticles, spawnLocation.position, spawnLocation.rotation);
            AudioManager.Instance.PlayFireAndIceSFX("Icicle");
            isAttacked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }
}
