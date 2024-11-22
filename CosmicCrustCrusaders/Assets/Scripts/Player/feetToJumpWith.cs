using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feetToJumpWith : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    // jump stuff
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            player.isGrounded = true;
            player.anim.SetBool("land", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            player.isGrounded = false;
            player.anim.SetBool("land", false);
        }
    }
}
