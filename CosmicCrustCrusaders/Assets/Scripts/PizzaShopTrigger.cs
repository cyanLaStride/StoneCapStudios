using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PizzaShopTrigger : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField]
    private GameObject scoreScreen0;
    [SerializeField]
    private GameObject scoreScreen1;
    [SerializeField]
    private GameObject scoreScreen2;
    [SerializeField]
    private GameObject scoreScreen3;
    [SerializeField]
    private GameObject scoreScreen4;
    [SerializeField]
    private GameObject scoreScreen5;

    [SerializeField]
    private AudioSource SFXclick;
    [SerializeField]
    private AudioSource SFXcomplete;

    private bool s1 = true;
    private bool s2 = true;
    private bool s3 = true;
    private bool s4 = true;
    private bool s5 = true;

    public string levelName = string.Empty;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        s1 = true;
        s2 = true;
        s3 = true;
        s4 = true;
        s5 = true;
    }
    private void Update()
    {
        if (!gameManager.gameGo)
        {
            if (gameManager.timer > gameManager.endTime + 1 && s1)
            {
                s1 = false;
                scoreScreen1.GetComponent<TMP_Text>().text = "\r\n\r\nCoins Collected: " + (gameManager.CoinCount-gameManager.coinsAtStart);
                scoreScreen1.SetActive(true);
                SFXclick.Play();
            }
            if (gameManager.timer > gameManager.endTime + 2 && s2)
            {
                s2 = false;
                scoreScreen2.GetComponent<TMP_Text>().text = "\r\n\r\n\r\nTime: " + (int)gameManager.endTime;
                scoreScreen2.SetActive(true);
                SFXclick.Play();
            }
            if (gameManager.timer > gameManager.endTime + 3 && s3)
            {
                s3 = false;
                scoreScreen3.GetComponent<TMP_Text>().text = "\r\n\r\n\r\n\r\nDeaths: " + gameManager.player.GetComponent<pHealth>().deathCount;
                scoreScreen3.SetActive(true);
                SFXclick.Play();
            }
            if (gameManager.timer > gameManager.endTime + 4 && s4)
            {
                s4 = false;
                scoreScreen4.GetComponent<TMP_Text>().text = "\r\n\r\n\r\n\r\n\r\n\r\nScore: " + (((int)(((100 + (gameManager.CoinCount * 10)) - (((int)gameManager.endTime) - 30)) * Mathf.Pow(0.75f, (float)gameManager.player.GetComponent<pHealth>().deathCount))));
                scoreScreen4.SetActive(true);
                SFXclick.Play();
            }
            if (gameManager.timer > gameManager.endTime + 5 && s5)
            {
                s5 = false;
                scoreScreen5.SetActive(true);
                SFXcomplete.Play();
            }
            if (Input.GetKey(KeyCode.Space) && scoreScreen5.activeInHierarchy)
            {
                if (levelName == "Earth"){
                    gameManager.upgFlashlightUnlock = true;
                    SceneManager.LoadSceneAsync("Dialogue Upgrade Shop");
                } else if (levelName == "Jungle")
                {
                    SceneManager.LoadSceneAsync("Pizza Shop");
                }
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.gameGo)
        {
            gameManager.EndLevel();
            scoreScreen0.SetActive(true);
            scoreScreen1.SetActive(false);
            scoreScreen2.SetActive(false);
            scoreScreen3.SetActive(false);
            scoreScreen4.SetActive(false);
            scoreScreen5.SetActive(false);
            
            SFXclick.Play();
        }
    }
}
