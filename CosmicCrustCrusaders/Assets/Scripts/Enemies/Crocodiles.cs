using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodiles : MonoBehaviour
{
    public GameObject shuriken;
    [SerializeField]
    private Transform shootingLocation;
    [SerializeField]
    private float shurikenSpeed;
    [SerializeField]
    private float shootAmout;
    [SerializeField]
    private float shootDelayTime;
    [SerializeField]
    private float fireRate;
    private float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shootAmout; i++)
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject crocodileShoot = Instantiate(shuriken, shootingLocation.position, shootingLocation.rotation);
        crocodileShoot.gameObject.GetComponent<Rigidbody2D>().AddForce(crocodileShoot.transform.right * shurikenSpeed);
    }
}
