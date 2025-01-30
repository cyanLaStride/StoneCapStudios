using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : MonoBehaviour
{
    // should i set up these?
    //public bool isUp;
    //public bool isLeft;
    //public bool isRight;
    public bool isStun = false;

    // setting up timer
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;

    // animation
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStun)
        {
            animator.enabled = false;
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
            {
                isStun = false;
                stunTimer = 0;
                animator.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isStun)
        {
            // Check player direction and play animation
            animator.SetTrigger("VAttack");
        }
        else if ((collision.gameObject.CompareTag("Toss")))
        {
            isStun = true;
        }
    }
}
