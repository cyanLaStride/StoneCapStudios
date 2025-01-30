using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;

    [SerializeField]
    public float movementSpeed = 10f;
    [SerializeField]
    public float jumpSpeed = 20f;
    [SerializeField]
    public float slow = 1f;
   
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

    [SerializeField]
    private GameManager gameManager;

    // upgrades
    public bool upgFlashlight = false;
    public bool upgGrapplingHook = false;
    public bool upgPropellor = false;
    public bool upgBuddyBoosters = false;

    public bool upgPropellorUse = false;

    public bool upgBoost = false;
    private float upgBoostSpeed = 2f;
    public bool isInteracting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        SFXrun.gameObject.SetActive(false);
        gameManager.LevelStart(this);
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        // left and right

        // If player is interacting with an NPC, lock movement
        if (isInteracting)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); // Ensure the player stays still
            anim.SetBool("run", false); // Optionally disable running animation
            SFXrun.gameObject.SetActive(false); // Disable running sound
            return; // Skip the rest of the movement logic
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (upgBoost)
            {
                rb2d.AddForce(new Vector2(-upgBoostSpeed * slow, 0));
            } else
            {
                rb2d.velocity = new Vector2(-movementSpeed * slow, rb2d.velocity.y);
            }
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
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (upgBoost)
            {
                rb2d.AddForce(new Vector2(upgBoostSpeed * slow, 0));
            }
            else
            {
                rb2d.velocity = new Vector2(movementSpeed * slow, rb2d.velocity.y);
            }
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
            if (!upgBoost)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            
            anim.SetBool("run", false);
            SFXrun.gameObject.SetActive(false);
        }
        // jump
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * slow);
                anim.SetTrigger("jump");
                SFXjump.Play();
            }
        }
        // crouch
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("crouch", true);
            //this.transform.localScale = new Vector3(1, 0.5f, 1);
            
            if (isGrounded)
            {
                CapsuleCollider2D[] capcolliders = GetComponents<CapsuleCollider2D>();
                capcolliders[0].size = new Vector2(1.9f, 1.9f);
                capcolliders[1].size = new Vector2(1.9f, 1.9f);
                slow = 0.5f;
            }
        } else
        {
            anim.SetBool("crouch", false);
            //this.transform.localScale = new Vector3(1, 1, 1);
            CapsuleCollider2D[] capcolliders = GetComponents<CapsuleCollider2D>();
            capcolliders[0].size = new Vector2(1.9f, 3.9f);
            capcolliders[1].size = new Vector2(1.9f, 3.9f);
            slow = 1f;
        }

        // toss
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tossTowards = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            tossTowards.z = 0;
            Rigidbody2D tossNew = Instantiate(tossPrefab, transform.position, Quaternion.identity);
            tossNew.velocity = (tossTowards - transform.position).normalized * tossSpeed + new Vector3(rb2d.velocity.x, rb2d.velocity.y);
            Physics2D.IgnoreCollision(tossNew.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            SFXthrow.Play();
        }

        // upgrades
        if (upgFlashlight)
        {

        }
        if (upgGrapplingHook)
        {

        }
        if (upgPropellor)
        {
            if (!upgPropellorUse && isGrounded)
            {
                upgPropellorUse = true;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            {
                if (upgPropellorUse && !isGrounded)
                {
                    upgPropellorUse = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                    anim.SetTrigger("jump");
                    SFXjump.Play();
                }
            }
        }
        if (upgBuddyBoosters)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                upgBoost = true;
            } else
            {
                upgBoost = false;
            }
            // rest in movement
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))  // Assuming NPCs are tagged with "NPC"
        {
            isInteracting = true;
            // Optionally, trigger NPC dialogue, animations, etc.
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            isInteracting = false;
            // Optionally close the NPC dialogue, etc.
        }
    }
    public void LockMovement(bool isLocked)
    {
        isInteracting = isLocked;
        rb2d.velocity = Vector2.zero; // Stops the player's movement
        anim.SetBool("run", false); // Stops running animation
    }

}
