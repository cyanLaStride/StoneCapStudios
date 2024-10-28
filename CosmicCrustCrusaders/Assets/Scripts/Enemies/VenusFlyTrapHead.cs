using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrapHead : MonoBehaviour
{
    [SerializeField]
    private int range;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < range; i++)
        {
            //transform.position.y = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
