using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Levels()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
