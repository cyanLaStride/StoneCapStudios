using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalAxolotl : MonoBehaviour
{
    // Start is called before the first frame update
    // player speed
    [SerializeField]
    private PlayerController playerController;
    private float characterSpeed;
    private bool stunPlayer;

    // timer
    private float timer;
    [SerializeField]
    private int duration;

    void Start()
    {
        stunPlayer = false;
        characterSpeed = playerController.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (stunPlayer)
        {
            playerController.movementSpeed = characterSpeed * 0;
            timer += Time.deltaTime;
            if (timer > duration)
            {
                stunPlayer = false;
            }
        }
        else if (!stunPlayer)
        {
            playerController.movementSpeed = characterSpeed;
        }
    }
}
