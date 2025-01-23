using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerV2 : MonoBehaviour
{
    // set up
    public Animator animator;
    public bool isIdle;
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
            animator.SetBool("FlowerIdle", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check player direction and play animation
            animator.SetBool("FlowerAttack", true);
            animator.SetBool("FlowerIdle", false);
            isIdle = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check player direction and play animation
            animator.SetBool("FlowerAttack", false);
            isIdle = true;
        }
    }
}
