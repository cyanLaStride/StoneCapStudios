using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : MonoBehaviour
{
    public bool isUp;
    public bool isLeft;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check player direction and play animation
        }
    }
}
