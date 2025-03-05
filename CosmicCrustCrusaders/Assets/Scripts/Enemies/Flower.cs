using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // to import image to the flower stem, go to art -> jungle -> find flower stem material, change the shader to standard and pull the image inside the Albedo, after change back to sprite default
    private float FBDistance; // flower to base
    private float FPDistance; // flower to player

    [SerializeField]
    private Flowerhead flowerhead;
    //[SerializeField]
    //private FlowerStem stem;

    // Start is called before the first frame update
    void Start()
    {
        //FlowerStem newLine = Instantiate(stem);
        //newLine.targetFlower(transform.position, flowerhead.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
