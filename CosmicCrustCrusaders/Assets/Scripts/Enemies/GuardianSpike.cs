using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSpike : MonoBehaviour
{
    private float timer = 2;
    private float elapsedTime;
    private float maxTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime <= timer)
        {
            transform.position += new Vector3(0, 0.001f, 0);
        }
        else if (elapsedTime <= maxTime && elapsedTime >= timer)
        {
            transform.position -= new Vector3(0, 0.001f, 0);
        }
        else if (elapsedTime > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
