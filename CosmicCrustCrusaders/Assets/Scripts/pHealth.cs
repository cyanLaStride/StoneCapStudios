using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pHealth : MonoBehaviour
{
    // Setting up Variable
    [SerializeField]
    public float health;
    // Max health for Images health percentage
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        /* adding this after set up respawn point
        if (health <= 0)
        {
            respawn
        }
        */
    }
}
