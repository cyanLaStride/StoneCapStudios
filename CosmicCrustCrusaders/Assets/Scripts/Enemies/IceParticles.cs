using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceParticles : MonoBehaviour
{
    // Update is called once per frame

    public Icicle ic;

    public bool isRight;
    private int direction;
    [SerializeField]
    private float speed;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    

    private void Start()
    {
        // setting speed
        speed = speed * 0.001f;
        isRight = ic.isRight;

        spriteRenderer = GetComponent<SpriteRenderer>();

        // checking direction
        if (ic.isRight)
        {
            direction = 1;
            spriteRenderer.flipX = true;
        }
        else if (!ic.isRight)
        {
            direction = -1;
            spriteRenderer.flipX = false;
        }
    }
    void Update()
    {

        // move attack
        transform.position += new Vector3(speed * direction, 0.0f, 0.0f);
    }

    // set limit
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Icicle.freezePlayer = true;
        }
        //else if (collision.gameObject.CompareTag("ground"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
