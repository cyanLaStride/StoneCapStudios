using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class VenusFlyTrapHead : MonoBehaviour
{
    [SerializeField]
    private int range;
    [SerializeField]
    private float speed;
    private float distance;

    [SerializeField]
    private Transform baseDis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, baseDis.position);
        if (distance < range)
        {
            transform.position += new Vector3(0, speed * 0.001f, 0);
        }
        else if (distance > range)
        {
            Destroy(gameObject);
        }
    }
}
