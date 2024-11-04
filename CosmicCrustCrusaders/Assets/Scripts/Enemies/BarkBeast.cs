using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkBeast : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPos;
    private Transform originalPos;

    [SerializeField]
    private float randomRangeMax;
    [SerializeField] 
    private float randomRangeMin;

    // Start is called before the first frame update
    void Start()
    {
        originalPos.position = cameraPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraPos.position += new Vector3(Random.Range(-randomRangeMin, randomRangeMax), Random.Range(-randomRangeMin, randomRangeMax), 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraPos = originalPos;
        }
    }
}
