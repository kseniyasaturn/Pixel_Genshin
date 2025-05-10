using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource effectAudioSource;
   
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip backgroundMusic;

    private float shootVolume = 1.0f;
    private float jumpVolume = 1.0f;
    private float musicVolume = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);      
    }
    private void Start()
    {
        LoadVolumeSettings();
        PlayBackgroundMusic();
    }
    private void LoadVolumeSettings()
    {
        shootVolume = PlayerPrefs.GetFloat("ShootVolume", 1.0f);
        jumpVolume = PlayerPrefs.GetFloat("JumpVolume", 1.0f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
    }

    public void PlayShootSound()
    {
        if(shootSound != null)
        {
            effectAudioSource.PlayOneShot(shootSound, shootVolume);
        } 
    }

    public  void PlayJumpSound()
    {
        if(jumpSound != null)
        {
            effectAudioSource.PlayOneShot(jumpSound, jumpVolume);
        }
    }

    public void PlayButtonClickSound()
    {
        if(buttonClickSound != null)
        {
            effectAudioSource.PlayOneShot(buttonClickSound);
        }
    }

    public void OnButtonClicked()
    {
        instance.PlayButtonClickSound();
    }

    private void PlayBackgroundMusic()
    {
        if(backgroundMusic != null)
        {
            musicAudioSource.clip = backgroundMusic;
            musicAudioSource.loop = true;
            musicAudioSource.volume = musicVolume;
            musicAudioSource.Play();
        }
    }
    public void SetShootVolume( float volume)
    {
        shootVolume = volume;
        PlayerPrefs.SetFloat("ShootVolume", volume);
    }
    public void SetJumpVolume( float volume)
    {
        jumpVolume = volume;
        PlayerPrefs.SetFloat("JumpVolume", volume);
    }
    public void SetMusicVolume( float volume)
    {
        musicVolume = volume;
        musicAudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
