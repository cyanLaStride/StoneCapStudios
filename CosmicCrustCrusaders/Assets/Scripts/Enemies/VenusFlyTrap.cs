using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : MonoBehaviour
{
    public bool isUp;
    public bool isLeft;
    public bool isRight;
    public bool isAttack;
    public bool isIdle;

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
        if (isIdle)
        {
            animator.SetBool("VIdle",true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check player direction and play animation
            animator.SetBool("VAttack", true);
            animator.SetBool("VIdle", false);
            isIdle = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check player direction and play animation
            animator.SetBool("VAttack", false);
            isIdle = true;
        }
    }
}
