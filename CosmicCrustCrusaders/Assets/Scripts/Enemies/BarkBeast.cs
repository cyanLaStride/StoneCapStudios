using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BarkBeast : MonoBehaviour
{
    // camera position
    [SerializeField]
    private Transform cameraPos;
    private Vector3 originalPos;

    // random number max and min
    [SerializeField]
    private float randomRangeMax;
    [SerializeField] 
    private float randomRangeMin;

    // shake
    [SerializeField]
    private int shakeAmount;
    private bool shake;

    // player 
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float speedDecreasePercentage;
    private float characterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = cameraPos.position;
        characterSpeed = playerController.movementSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shake)
        {
            playerController.movementSpeed = characterSpeed * (1/speedDecreasePercentage);

            for (int i = 0; i < shakeAmount; i++)
            {
                cameraPos.position += new Vector3(Random.Range(-randomRangeMin, randomRangeMax), Random.Range(-randomRangeMin, randomRangeMax), 0);
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shake = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraPos.position = originalPos;
            shake = false;
            playerController.movementSpeed = characterSpeed;
        }
    }
    
}
