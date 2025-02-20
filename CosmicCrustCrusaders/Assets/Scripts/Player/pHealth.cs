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

    [SerializeField]
    private float InvulnerablityTime = 0.75f;
    private float invulnTimer = 0;

    [SerializeField]
    PlayerController player;

    //[SerializeField]
    //private AudioSource SFXhurt;

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
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        
        // Image health bar fill amount
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f);

        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
        }
    }

    // hey sorry this is daniel, this is a function to apply knockback and make the player invulnerable for a second, this is just for the demo so feel free to change it afterwards
    public void Knockback(float dam, Vector3 damPos)
    {
        if(invulnTimer <= 0)
        {
            health -= dam;
            if (health > 0)
            {
                invulnTimer = InvulnerablityTime;
                gameObject.GetComponent<Rigidbody2D>().velocity = (transform.position - damPos).normalized * dam * 10;
                player.anim.SetTrigger("hurt");
                //SFXhurt.Play();
                AudioManager.Instance.PlayPlayerSFX("GettingHit");
            }
        }
        
    }
}
