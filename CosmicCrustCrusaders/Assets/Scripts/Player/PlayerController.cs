using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;

    [SerializeField]
    public float movementSpeed = 10f;
    [SerializeField]
    public float jumpSpeed = 30f;

    public bool isGrounded;

    [SerializeField]
    public Camera cam;

    private SpriteRenderer ren;

    [SerializeField]
    public BoxCollider2D feet;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        // left and right
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-movementSpeed, rb2d.velocity.y);
            ren.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(movementSpeed, rb2d.velocity.y);
            ren.flipX = false;
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
        /* obselete camera movement
        if (this.transform.position.x/24 < 1)
        {
            cam.transform.position = new Vector3(0, 0.5f, -10);
        } else
        {
            cam.transform.position = new Vector3(48, 0.5f, -10);
        }*/

        // this camera movement will cause issues when x < 0; will fix if it comes up
        cam.transform.position = new Vector3((((int)this.transform.position.x + 24) / 48)*48, 0.5f, -10);

    }

    /* jump stuff -- MOVED TO FEET
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
    }*/
}
