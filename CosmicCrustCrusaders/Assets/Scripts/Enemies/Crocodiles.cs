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
    //[SerializeField]
    //private float shootAmout;
    [SerializeField]
    private float shootDelayTime;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float shootTime;
    private float shootTimer = 0.0f;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;
    [SerializeField]
    private Collider2D tossCollider;


    public bool isRight;
    public bool isStun;

    // music for now
    //[SerializeField]
    //private AudioSource ninjaAttackClip;
    //[SerializeField]
    //private AudioSource ninjaIdleClip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //InvokeRepeating("shoot", shootDelayTime, shootTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStun)
        {
            shootTimer += Time.deltaTime;
            //ninjaIdleClip.Play();
            if (shootTimer >= shootTime)
            {
                shoot();
                // throwing sound but affect whole map, will fix it later
                //AudioManager.Instance.PlayJungleSFX("NinjaThrow");
                shootTimer = 0.0f;
            }
        }
        else if (isStun)
        {
            shootTimer = 0.0f;
            tossCollider.enabled = false;
            animator.enabled = false;
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
            {
                isStun = false;
                tossCollider.enabled = true;
                stunTimer = 0;
                animator.enabled = true;
            }
        }
    }

    // shooting method
    private void shoot()
    {
        animator.SetTrigger("CrocoAttack");
        //ninjaAttackClip.Play();
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }
}
