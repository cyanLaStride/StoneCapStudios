using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    Light2D myLight; 

    
    
    void Start()
    {
        myLight = GetComponent<Light2D>();
        myLight.intensity = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            myLight.intensity = 3;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            myLight.intensity = 0;
        }
    }
}
