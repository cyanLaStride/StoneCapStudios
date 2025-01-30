using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    private bool isColliding;

    [SerializeField]
    private AudioSource SFXcoin;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isColliding) return;
        isColliding = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.CoinCount += 1;
            SFXcoin.Play();
            Destroy(gameObject);
        }
    }
}
