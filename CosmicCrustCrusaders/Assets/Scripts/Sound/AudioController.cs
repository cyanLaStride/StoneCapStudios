using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioMixer AudioMixer;

    public void SetVolume(float sliderValue)
    {
        AudioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 1);
    }
}
