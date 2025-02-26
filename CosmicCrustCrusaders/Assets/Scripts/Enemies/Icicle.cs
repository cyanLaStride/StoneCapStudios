using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    // Start is called before the first frame update
    // cool particle effect later
    // freeze character?

    // player speed
    [SerializeField]
    private PlayerController player;
    private float characterSpeed;
    private bool freezePlayer;

    // timer
    private float timer;
    [SerializeField]
    private int freezeDuration;

    public bool isRight;
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private GameObject iceParticles;
    public SpriteRenderer iceRenderer;

    void Start()
    {
        freezePlayer = false;
        characterSpeed = player.movementSpeed;
        timer = 0;

        iceRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (freezePlayer)
        {
            if (timer <= freezeDuration)
            {
                player.movementSpeed = 0;
                timer += Time.deltaTime;
            }
            else if (timer > freezeDuration)
            {
                freezePlayer = false;
            }
        }
        else if (!freezePlayer)
        {
            player.movementSpeed = characterSpeed;
            timer = 0;
        }
        if (player.transform.position.x > transform.position.x)
        {
            isRight = true;
            iceRenderer.flipX = true;

        }
        else if (player.transform.position.x < transform.position.x)
        {
            isRight = false;
            iceRenderer.flipX = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject icicleShoot = Instantiate(iceParticles, spawnLocation.position, spawnLocation.rotation);
        }
    }
}
