using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Earth()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Jungle()
    {
        SceneManager.LoadSceneAsync(6);
    }

}
