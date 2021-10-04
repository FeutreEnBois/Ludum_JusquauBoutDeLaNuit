using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicPlay : MonoBehaviour
{
    public GameObject ObjectMusic;
    private AudioSource audioSource;
    private float musicVolume = 0.5f;
    public Slider volumeSlider;  

    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("Music");
        audioSource = ObjectMusic.GetComponent<AudioSource>();
        audioSource.Play();
       /// volumeSlider = GameObject.FindGameObjectsWithTag("SliderSound").GetComponent<Slider>().value;
        musicVolume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
