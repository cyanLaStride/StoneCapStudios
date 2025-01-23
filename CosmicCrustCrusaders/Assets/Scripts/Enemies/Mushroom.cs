using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // input sprite, rigidbody, and animation
    public SpriteRenderer spriteR;
    public Rigidbody2D rb;
    public GameObject stopCheck;
    public Animator animator;

    // tigger for mushroom moving left or right
    [SerializeField]
    private bool isLeft;
    [SerializeField]
    private bool isRight;
    private int direction;

    // field for basic
    [SerializeField]
    private float speed;
    private float decreaseSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        stopCheck = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        if (isLeft)
        {
            direction = -1;
        }
        else if (isRight)
        {
            direction = 1;
        }
    }
    private void Update()
    {
        transform.position = transform.position + new Vector3(speed * decreaseSpeed * direction, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
