using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerV2 : MonoBehaviour
{
    // set up
    public Animator animator;
    public bool isIdle;
    public bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer;
    [SerializeField]
    private Collider2D tossCollider;

    // Start is called before the first frame update

    void Start()
    {
        // getting components
        animator = GetComponent<Animator>();
        //flowerAduioClip = GetComponent<AudioSource>();

        // setting up start
        isIdle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle && !isStun)
        {
            //flowerAduioClip.Play();
            animator.SetBool("FlowerIdle", true);
        }
        // when enemies is stun
        if (isStun)
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
    }

    // when the flower touch the player or the toss
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isStun)
        {
            AudioManager.Instance.PlayJungleSFX("DanglingFlower");
            // Check player direction and play animation
            animator.SetBool("FlowerAttack", true);
            animator.SetBool("FlowerIdle", false);
            isIdle = false;
        }
        else if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isStun)
        {
            // Check player direction and play animation
            animator.SetBool("FlowerAttack", false);
            isIdle = true;
        }
    }
}
