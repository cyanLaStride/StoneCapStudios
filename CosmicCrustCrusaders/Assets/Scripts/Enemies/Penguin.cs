using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    [SerializeField]
    private bool isRight;
    private int direction;
    [SerializeField]
    private float force;

    [SerializeField]
    private Rigidbody2D rb;
    // Start is called before the first frame update
    // I don't get it
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isRight)
        {
            direction = 1;
        }
        else if (!isRight)
        {
            direction = -1;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.AddForce(transform.right * direction * force);   
    }
}
