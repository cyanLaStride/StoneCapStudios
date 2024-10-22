using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // input sprite, rigidbody, and animation
    public SpriteRenderer spriteR;
    public Rigidbody2D rb;
    public GameObject stopCheck;

    // tigger for mushroom moving left or right
    [SerializeField]
    private bool isLeft;
    [SerializeField]
    private bool isRight;
    private int direction = 1;

    // field for basic
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        stopCheck = GetComponent<GameObject>();
        if (isLeft)
        {
            direction = -1;
        }
        else if (isRight)
        {
            direction = 1;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    } 
}
