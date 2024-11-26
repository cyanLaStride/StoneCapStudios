using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerhead : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int targetDistance;
    [SerializeField]
    private Transform flowerBase;
    [SerializeField]
    private int radius;

    private float distance;
    private float toBaseDistance;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        toBaseDistance = Vector2.Distance(flowerBase.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (toBaseDistance < radius)
        {
            if (distance < targetDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else if (distance > toBaseDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, flowerBase.transform.position, speed * Time.deltaTime);
            }
        }
        else if(toBaseDistance >= radius)
        {
                transform.position = Vector2.MoveTowards(this.transform.position, flowerBase.transform.position, speed * Time.deltaTime);
        }
    }
}
