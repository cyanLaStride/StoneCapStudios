using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceParticles : MonoBehaviour
{
    // Update is called once per frame

    [SerializeField]
    private Icicle ic;

    public bool isRight;
    private int direction;
    [SerializeField]
    private float speed;
    

    private void Start()
    {
        // setting speed
        speed = speed * 0.001f;

    }
    void Update()
    {
        isRight = ic.isRight;
        // checking direction
        if (isRight)
        {
            direction = 1;
        }
        else if (!isRight)
        {
            direction = -1;
        }

        // move attack
        transform.position += new Vector3(speed * direction, 0.0f, 0.0f);
    }

    // set limit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
