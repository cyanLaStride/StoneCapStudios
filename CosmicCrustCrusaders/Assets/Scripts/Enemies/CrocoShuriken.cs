using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoShuriken : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float damage;
    [SerializeField]
    private float flySpeed;
    [SerializeField]
    private float flyHeight;

    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.velocity = new Vector2(flySpeed, flyHeight);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy (this);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<pHealth>().health -= damage;
        }
    }
}
