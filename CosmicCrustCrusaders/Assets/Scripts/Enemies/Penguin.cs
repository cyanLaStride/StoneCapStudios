using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    // setting
    [SerializeField]
    private bool isRight;
    private int direction;
    [SerializeField]
    private float force;
    private bool isEnter = false; 

    [SerializeField]
    private Rigidbody2D rb;

    // getting component and setting up
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isRight)
        {
            direction = 1;
        }
        else if (!isRight)
        {
            direction = -1;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void FixedUpdate()
    {

    }
    // when penguin see the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.right * force * direction;
        }
    }
}
