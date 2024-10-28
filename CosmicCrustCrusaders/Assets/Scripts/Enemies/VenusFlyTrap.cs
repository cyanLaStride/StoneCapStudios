using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusFlyTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    public bool isSpawn;
    // Start is called before the first frame update
    void Start()
    {
        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isSpawn)
            {
                GameObject flyTrap = Instantiate(obj, spawnPoint.position,spawnPoint.rotation);
                isSpawn = true;
            }
        }
    }
}
