using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

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

    private void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("VolumeValue", 1f);
        sfxSource.volume = PlayerPrefs.GetFloat("VolumeValue", 1f);
        if(SceneManager.GetActiveScene().name=="MainMenu")
            PlayMusic("menu");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("ses yok");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("ses yok");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ChangeVolume(float value)
    {
        musicSource.volume = value;
        sfxSource.volume = value;
    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName == "MainMenu" && musicSource.clip.name!="menu")
        {
            PlayMusic("menu");
        }
        else if (sceneName != "MainMenu" && !(musicSource.clip.name == "level" || musicSource.clip.name == "level2"))
        {
            if(UnityEngine.Random.Range(0,2)==0)
                PlayMusic("level");
            else
                PlayMusic("level2");
        }
    }
}
