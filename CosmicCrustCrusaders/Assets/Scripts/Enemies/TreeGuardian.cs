using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGuardian : MonoBehaviour
{
    // add spikes
    [SerializeField]
    private GameObject spike;
    [SerializeField]
    private Transform spawnLocation;
    private Vector3 newSpawn;
    [SerializeField]
    private int spawnAmount;
    [SerializeField]
    private int spawnDistance;
    private int direction;
    private bool isRight;
    private bool isSpawn;

    // Start is called before the first frame update
    void Start()
    {
        isRight = false;
        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            direction = 1;
        }
        else if (!isRight)
        {
            direction = -1;
        }
    }
    private void SpawnSpike(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            newSpawn = new Vector3(spawnLocation.position.x + (direction * spawnDistance * i), spawnLocation.position.y, spawnLocation.position.z);
            GameObject sapwnSpike = Instantiate(spike, newSpawn, spawnLocation.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isSpawn)
        {
            SpawnSpike(spawnAmount);
            isSpawn = true;
        }
    }
}
