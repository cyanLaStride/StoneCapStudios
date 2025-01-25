using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodiles : MonoBehaviour
{
    // setting up basic
    public Animator animator;
    public GameObject shuriken;
    [SerializeField]
    private Transform shootingLocation;

    // shooting setting
    [SerializeField]
    private float shurikenSpeed;
    [SerializeField]
    private float shootAmout;
    [SerializeField]
    private float shootDelayTime;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float shootTime;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("shoot", shootDelayTime, shootTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // shooting method
    private void shoot()
    {
        animator.SetTrigger("CrocoAttack");
        
        GameObject crocodileShoot = Instantiate(shuriken, shootingLocation.position, shootingLocation.rotation);
        if (isRight)
        {
            crocodileShoot.gameObject.GetComponent<Rigidbody2D>().AddForce(crocodileShoot.transform.right * shurikenSpeed);
        }
       else if (!isRight)
        {
            crocodileShoot.gameObject.GetComponent<Rigidbody2D>().AddForce(crocodileShoot.transform.right * -1 * shurikenSpeed);
        }
    }
}
