using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    // setting spawn point
    public Transform respawn;

    // starting at spawn point
    private void Start()
    {
        transform.position = respawn.position;
    }

    // setting up respawn point (only 1 respawn point right now, won't work)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            respawn = collision.gameObject.transform;
        }
    }

    // setting up respawn method
    public void Respawn()
    {
        transform.position = respawn.position;
    }
}
