using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{

    //public GameObject pauseMenu;
    public bool isPaused;
    [SerializeField]
    private TMP_Text DeathCount;
    [SerializeField]
    private pHealth pH;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        GetComponent<Canvas>().enabled = true; 
        Time.timeScale = 0f;
        DeathCount.text = "Deaths: " + pH.deathCount;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Click");
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }
}
