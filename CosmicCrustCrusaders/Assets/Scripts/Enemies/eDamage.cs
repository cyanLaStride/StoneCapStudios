using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eDamage : MonoBehaviour
{
    // Set up player health, needed to drag and drop everytime, after use the code 
    public pHealth playerHp;
    // Field to change the damage in editor
    [SerializeField]
    float damage;
    // Clickable box for enemies damage type
    [SerializeField]
    bool onEnter;
    [SerializeField]
    bool onTrigger;

    
    [SerializeField]
    private float nextAttackDelaySec;
    private float nextAttackDelayTimer;
    private bool attack;

    
    private void FixedUpdate()
    {
        if (!attack)
        {
            nextAttackDelayTimer += Time.fixedDeltaTime;
            if(nextAttackDelayTimer > nextAttackDelaySec)
            {
                attack = true;
                nextAttackDelayTimer = 0;
            }    
        }
    }

    // damage the player when entering the enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onEnter)
        {
            // change this after player is ready, this is just an example
            if (collision.gameObject.CompareTag("Player"))
            {
                playerHp = collision.gameObject.GetComponent<pHealth>();
                playerHp.Knockback(damage, this.transform.position);
            }
        }
    }

    // on trigger enter
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onTrigger)
        {
            if (collision.gameObject.CompareTag("Player") && attack )
            {
                playerHp = collision.gameObject.GetComponent<pHealth>();
                playerHp.Knockback(damage, this.transform.position);
                attack = false;
            }
        }
    }
}
