using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSlimes : MonoBehaviour
{
    // player and checking
    private bool checkSameLevel;

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        checkSameLevel = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y - 0.3 >= transform.position.y - 0.3 && player.transform.position.y - 0.3 <= transform.position.y + 0.3)
        {
            checkSameLevel = true;
        }
        else if (player.transform.position.y -0.3 < transform.position.y - 0.4 || player.transform.position.y - 0.3 > transform.position.y + 0.4)
        {
            checkSameLevel = false;
        }
        //Debug.Log(checkSameLevel);
        if (checkSameLevel)
        {
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
        else if (!checkSameLevel)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
