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
    bool onStay;

    //damage the player when staying with enemies
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (onStay)
        {
            // change this after player is ready, this is just an example
            if (collision.gameObject.CompareTag("Player"))
            {
                //playerHp.health -= damage;
                // next line of code used in actual game, the one above just for testing for now, doesn't require drag and drop everytime
                // other.gameObject.GetComponent<playerHealth>().health -= damage;

                // hey this is daniel sorry for working in your code
                // this is so that the player takes knockback and is invulnerable for a second
                playerHp.Knockback(damage, this.transform.position);
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
                //playerHp.health -= damage;
                // next line of code used in actual game, the one above just for testing for now, doesn't require drag and drop everytime
                // other.gameObject.GetComponent<playerHealth>().health -= damage;

                // same as above
                playerHp.Knockback(damage, this.transform.position);
            }
        }
    }

}
