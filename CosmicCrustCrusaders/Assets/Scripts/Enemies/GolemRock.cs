using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemRock : MonoBehaviour
{
    // basic setting
    [SerializeField]
    private Transform rotateAroundThis;
    [SerializeField]
    public float speed;
    [SerializeField]
    private bool isRotationRight;

    [SerializeField]
    private ElementGolem el;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isRotationRight)
        {
            this.transform.RotateAround(rotateAroundThis.position, Vector3.forward, speed * Time.fixedDeltaTime);
        }
        else if (!isRotationRight)
        {
            this.transform.RotateAround(rotateAroundThis.position, Vector3.forward, speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            el.isSlowed = true;
        }
    }
}
