using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;

    [SerializeField]
    public float movementSpeed = 10f;
    [SerializeField]
    public float jumpSpeed = 18f;

    public bool isGrounded;

    [SerializeField]
    public Camera cam;

    private SpriteRenderer ren;

    [SerializeField]
    public BoxCollider2D feet;

    [SerializeField]
    private Rigidbody2D tossPrefab;
    [SerializeField]
    private float tossSpeed;

    public Animator anim;

    [SerializeField]
    private AudioSource SFXthrow;
    [SerializeField]
    private AudioSource SFXrun;
    [SerializeField]
    private AudioSource SFXjump;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        SFXrun.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        // left and right
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-movementSpeed, rb2d.velocity.y);
            anim.SetBool("run", true);
            ren.flipX = true;
            if (isGrounded)
            {
                SFXrun.gameObject.SetActive(true);
            } else
            {
                SFXrun.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(movementSpeed, rb2d.velocity.y);
            anim.SetBool("run", true);
            ren.flipX = false;
            if (isGrounded)
            {
                SFXrun.gameObject.SetActive(true);
            } else
            {
                SFXrun.gameObject.SetActive(false);
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            anim.SetBool("run", false);
            SFXrun.gameObject.SetActive(false);
        }
        // jump
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                anim.SetTrigger("jump");
                SFXjump.Play();
            }
        }
        // crouch
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl))
        {
            this.transform.localScale = new Vector3(1, 0.5f, 1);
            if (isGrounded)
            {
                movementSpeed = 5f;
                jumpSpeed = 9f;
            }
        } else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            movementSpeed = 10f;
            jumpSpeed = 18f;
        }

        // toss
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tossTowards = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            tossTowards.z = 0;
            Rigidbody2D tossNew = Instantiate(tossPrefab, transform.position, Quaternion.identity);
            tossNew.velocity = (tossTowards - transform.position).normalized * tossSpeed;
            Physics2D.IgnoreCollision(tossNew.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            SFXthrow.Play();
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
        cam.transform.position = new Vector3((((int)this.transform.position.x + 24) / 48) * 48,((((int)this.transform.position.y - 13) / 27) * 27) + 0.5f, -10);
        
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
