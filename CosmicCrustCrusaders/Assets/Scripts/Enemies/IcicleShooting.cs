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

    [SerializeField]
    private float timeBetweenAttack;
    private float timer;
    private bool isAttack;

    private void FixedUpdate()
    {
        if (isAttack)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= timeBetweenAttack)
            {
                isAttack = false;
                timer = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isAttack)
        {
            icp.isRight = isRight;
            ic.isAttacked = false;
            isAttack = true;
        }
    }
}
