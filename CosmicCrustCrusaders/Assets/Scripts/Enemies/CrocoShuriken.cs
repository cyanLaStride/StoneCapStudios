using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoShuriken : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy (gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<pHealth>().health -= damage;
            Destroy (gameObject);
        }
    }
}
