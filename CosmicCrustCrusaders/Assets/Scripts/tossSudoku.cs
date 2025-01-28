using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tossSudoku : MonoBehaviour
{
    [SerializeField]
    private float timer;
    void Start()
    {

    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Destroy(gameObject);
        }
    }
}
