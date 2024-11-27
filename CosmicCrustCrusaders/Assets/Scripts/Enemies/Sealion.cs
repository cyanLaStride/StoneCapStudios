using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sealion : MonoBehaviour
{
    // Start is called before the first frame update
    // player speed
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float speedDecreasePercentage;
    private float characterSpeed;

    void Start()
    {
        characterSpeed = playerController.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.movementSpeed = characterSpeed * (1 / speedDecreasePercentage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.movementSpeed = characterSpeed;
        }
    }
}
