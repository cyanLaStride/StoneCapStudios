using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleShooting : MonoBehaviour
{
    [SerializeField]
    private IceParticles icp;
    [SerializeField]
    private Icicle ic;
    [SerializeField]
    public bool isRight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            icp.isRight = isRight;
            ic.isAttacked = false;
        }
    }
}
