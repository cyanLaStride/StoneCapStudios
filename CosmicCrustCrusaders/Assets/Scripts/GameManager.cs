using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameGo = true;

    [SerializeField]
    private TMP_Text Coins;
    public int CoinCount;

    // timer
    [SerializeField]
    private TMP_Text timerText;
    private float timer;
    private float endTime;

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

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameGo = true;
        scoreScreen0.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Coins.text = "Coins: " + CoinCount;
        timer += Time.deltaTime;
        if (gameGo)
        {
            timerText.text = "Timer: " + (int)timer;
        }

        if (!gameGo)
        {
            if (timer > endTime + 1)
            {
                scoreScreen1.GetComponent<TMP_Text>().text = "\r\n\r\nCoins: " + CoinCount;
                scoreScreen1.SetActive(true);
            }
            if (timer > endTime + 2)
            {
                scoreScreen2.GetComponent<TMP_Text>().text = "\r\n\r\n\r\nTime: " + (int)endTime;
                scoreScreen2.SetActive(true);
            }
            if (timer > endTime + 3)
            {
                scoreScreen3.GetComponent<TMP_Text>().text = "\r\n\r\n\r\n\r\nDeaths: " + player.GetComponent<pHealth>().deathCount;
                scoreScreen3.SetActive(true);
            }
            if (timer > endTime + 4)
            {
                scoreScreen4.GetComponent<TMP_Text>().text = "\r\n\r\n\r\n\r\n\r\n\r\nScore: " + (((int)(((100 + (CoinCount * 10)) - (((int)endTime) - 30)) * Mathf.Pow(0.75f, (float)player.GetComponent<pHealth>().deathCount))));
                scoreScreen4.SetActive(true);
            }
            if (timer > endTime + 5)
            {
                scoreScreen5.SetActive(true);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadSceneAsync(7);
            }
        }
    }

    public void EndLevel()
    {
        gameGo = false;
        endTime = timer;
        scoreScreen0.SetActive(true);
        scoreScreen1.SetActive(false);
        scoreScreen2.SetActive(false);
        scoreScreen3.SetActive(false);
        scoreScreen4.SetActive(false);
        scoreScreen5.SetActive(false);

    }
}
