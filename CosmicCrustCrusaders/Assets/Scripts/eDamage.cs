using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eDamage : MonoBehaviour
{
    // Set up player health
    public pHealth playerHp;
    // Field to change the damage in editor
    [SerializeField]
    float damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // change this after player is ready, this is just an example
        playerHp.health -= damage;
    }


}
