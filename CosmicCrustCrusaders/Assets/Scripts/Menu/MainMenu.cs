using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;
    void Start()
    {
        myVideoPlayer.loopPointReached += EndVideo;
    }

    void EndVideo(VideoPlayer player)
    {
        SceneManager.LoadSceneAsync(3);

    }
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

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(3);
    }

}
