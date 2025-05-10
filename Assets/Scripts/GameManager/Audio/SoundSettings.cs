using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider shootSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        shootSlider.value = PlayerPrefs.GetFloat("ShootVolume", 1.0f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        shootSlider.onValueChanged.AddListener(SetShootVolume);  
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }
    public void SetShootVolume(float volume)
    {
        AudioManager.instance.SetShootVolume(volume);
    }
    public void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}
