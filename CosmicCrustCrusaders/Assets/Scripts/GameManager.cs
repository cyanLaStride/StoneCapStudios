using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Coins;
    public int CoinCount;

    // timer
    [SerializeField]
    private TMP_Text timerText;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Coins.text = "Coins: " + CoinCount;
        timer += Time.deltaTime;
        timerText.text = "Timer: " + (int)timer;
    }
}
