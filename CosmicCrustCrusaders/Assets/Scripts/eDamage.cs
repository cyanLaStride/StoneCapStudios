using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eDamage : MonoBehaviour
{
    // Set up player health, needed to drag everytime, after use the code 
    public pHealth playerHp;
    // Field to change the damage in editor
    [SerializeField]
    float damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // change this after player is ready, this is just an example
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHp.health -= damage;
            // next line of code used in actual game, the one above just for testing for now
            // other.gameObject.GetComponent<playerHealth>().health -= damage;
        }
    }


}
