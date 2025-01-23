using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BarkBeast : MonoBehaviour
{
    // camera position
    [SerializeField]
    private Camera cameraPos;
    private Vector3 originalPos;

    // random number max and min
    [SerializeField]
    private float randomRangeMax;
    [SerializeField] 
    private float randomRangeMin;
    [SerializeField]
    private int timeBetweenShake;

    // shake
    [SerializeField]
    private int shakeAmount;
    private bool shake;

    // player speed
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float speedDecreasePercentage;
    private float characterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = cameraPos.transform.position;
        characterSpeed = playerController.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            
            playerController.movementSpeed = characterSpeed * (1 / speedDecreasePercentage);

            for (int i = 0; i < shakeAmount; i++)
            {
                Debug.Log("boop");
                cameraPos.transform.position += new Vector3(Random.Range(-randomRangeMin, randomRangeMax), Random.Range(-randomRangeMin, randomRangeMax), 0);
            }
        }
    }

    // when entering bark range?
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shake = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("???????????");
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraPos.transform.position = originalPos;
            shake = false;
            playerController.movementSpeed = characterSpeed;
        }
    }
}
