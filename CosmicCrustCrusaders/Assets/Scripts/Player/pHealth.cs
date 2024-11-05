using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pHealth : MonoBehaviour
{
    // Setting up Variable
    [SerializeField]
    public float health;
    // Max health for Images health percentage
    public float maxHealth;
    // Canvas Health Bar
    public Image healthBar;
    public spawnPoint respawn;
    public int deathCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        respawn = GetComponent<spawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {    
        // when player health reach 0, respawn
        if (health <= 0)
        {
            respawn.Respawn();
            health = maxHealth;
            deathCount += 1;
        }

        
        // Image health bar fill amount
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f);
    }
}
