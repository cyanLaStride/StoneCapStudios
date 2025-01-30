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

    [SerializeField]
    private AudioSource MusicLevel;
    [SerializeField]
    private AudioSource SFXclick;
    [SerializeField]
    private AudioSource SFXcomplete;
    private bool s1 = true;
    private bool s2 = true;
    private bool s3 = true;
    private bool s4 = true;
    private bool s5 = true;

    // upgrades
    public bool upgFlashlightUnlock = false;
    public bool upgGrapplingHookUnlock = false;
    public bool upgPropellorUnlock = false;
    public bool upgBuddyBoostersUnlock = false;

    // Start is called before the first frame update
    void Start()
    {
        //gameGo = true;
        //scoreScreen0.SetActive(false);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("manager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Coins = GameObject.Find("Coins").GetComponent<TMP_Text>();
        timerText = GameObject.Find("Timer").GetComponent<TMP_Text>();

        Coins.text = "Coins: " + CoinCount;
        timer += Time.deltaTime;
        if (gameGo)
        {
            timerText.text = "Timer: " + (int)timer;
        }

        if (!gameGo)
        {
            if (timer > endTime + 1 && s1)
            {
                s1 = false;
                scoreScreen1.GetComponent<TMP_Text>().text = "\r\n\r\nCoins: " + CoinCount;
                scoreScreen1.SetActive(true);
                SFXclick.Play();
            }
            if (timer > endTime + 2 && s2)
            {
                s2 = false;
                scoreScreen2.GetComponent<TMP_Text>().text = "\r\n\r\n\r\nTime: " + (int)endTime;
                scoreScreen2.SetActive(true);
                SFXclick.Play();
            }
            if (timer > endTime + 3 && s3)
            {
                s3 = false;
                scoreScreen3.GetComponent<TMP_Text>().text = "\r\n\r\n\r\n\r\nDeaths: " + player.GetComponent<pHealth>().deathCount;
                scoreScreen3.SetActive(true);
                SFXclick.Play();
            }
            if (timer > endTime + 4 && s4)
            {
                s4 = false;
                scoreScreen4.GetComponent<TMP_Text>().text = "\r\n\r\n\r\n\r\n\r\n\r\nScore: " + (((int)(((100 + (CoinCount * 10)) - (((int)endTime) - 30)) * Mathf.Pow(0.75f, (float)player.GetComponent<pHealth>().deathCount))));
                scoreScreen4.SetActive(true);
                SFXclick.Play();
            }
            if (timer > endTime + 5 && s5)
            {
                s5 = false;
                scoreScreen5.SetActive(true);
                SFXcomplete.Play();
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
        MusicLevel.gameObject.SetActive(false);
        SFXclick.Play();
    }

    public void LevelStart(PlayerController player)
    {
        gameGo = true;
        player.upgFlashlight = upgFlashlightUnlock;
        player.upgGrapplingHook = upgGrapplingHookUnlock;
        player.upgPropellor = upgPropellorUnlock;
        player.upgBuddyBoosters = upgBuddyBoostersUnlock;
    }
}
