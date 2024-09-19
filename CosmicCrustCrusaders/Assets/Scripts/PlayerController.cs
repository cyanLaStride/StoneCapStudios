using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;

    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float jumpSpeed = 30f;

    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        // left and right
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-movementSpeed, rb2d.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(movementSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        // jump
        if (Input.GetKey(KeyCode.W))
        {
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
        }

    }

    // jump stuff
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
