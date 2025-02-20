using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // lol forgot to add this

public class AudioManager : MonoBehaviour
{
    // create a instance to call from any method
    public static AudioManager Instance;

    // all related to player such as coin pick up, respawn goes into player sfx
    public Sound[] PlayerSFX, JungleSFX, FireAndIceSFX;
    public Sound[] music;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // call this method to controll background music
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.name == name);
        if (s == null)
        {
            Debug.Log("You enter the wrong name");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    // call this method to control player sfx
    public void PlayPlayerSFX(string name)
    {
        Sound s = Array.Find(PlayerSFX, x => x.name == name);
        if (s == null)
        {
            Debug.Log("You enter the wrong name");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    // call this method to control jungle enemies/other sfx
    public void PlayJungleSFX(string name)
    {
        Sound s = Array.Find(JungleSFX, x => x.name == name);
        if (s == null)
        {
            Debug.Log("You enter the wrong name");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    // call this method to control fire and ice enemies sfx
    public void PlayFireAndIceSFX(string name)
    {
        Sound s = Array.Find(FireAndIceSFX, x => x.name == name);
        if (s == null)
        {
            Debug.Log("You enter the wrong name");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
