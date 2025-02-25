using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSlimes : MonoBehaviour
{
    // player and checking
    //private bool checkSameLevel;

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        //checkSameLevel = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.y - 0.3 >= transform.position.y - 0.3 && player.transform.position.y - 0.3 <= transform.position.y + 0.3)
        {
            //checkSameLevel = true;
            transform.localScale = new Vector2(1.5f, 1.5f);
            rb.velocity = Vector2.right * speed * 100 * direction * Time.fixedDeltaTime;

        }
        else if (player.transform.position.y -0.3 < transform.position.y - 0.4 || player.transform.position.y - 0.3 > transform.position.y + 0.4)
        {
            //checkSameLevel = false;
            transform.localScale = new Vector2(1f, 1f);

        }
        //Debug.Log(checkSameLevel);
        if (player.transform.position.x > transform.position.x)
        {
            direction = 1;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            direction = -1;
        }
    }
}
