using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sounds[] musicSounds, sfxSounds, FootStepsSounds, BarkSounds, DoorSounds, UISounds, altMusicSounds;
    public AudioSource musicSource, sfxSource, FootStepsSource, BarkSource, DoorSource, UISource, altMusicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //musica del menu
    }
    public void PlayMusic(string name, float start = 0.0f)
    {
        Sounds s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.time = start;
            musicSource.Play();
        }
    }
    public void PlaySfx(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip); //hay varios metodos para controlar audio
            //ver la documentacion de unity
        }
    }
    public void PlayFootSteps(string name)
    {
        Sounds s = Array.Find(FootStepsSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            FootStepsSource.PlayOneShot(s.clip);
        }
    }

    public void PlayBark(string name)
    {
        Sounds s = Array.Find(BarkSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            BarkSource.PlayOneShot(s.clip);
        }
    }
    public void PlayDoor(string name)
    {
        Sounds s = Array.Find(DoorSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            DoorSource.PlayOneShot(s.clip);
        }
    }
    public void PlayUI(string name)
    {
        Sounds s = Array.Find(UISounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            UISource.PlayOneShot(s.clip); //hay varios metodos para controlar audio
            //ver la documentacion de unity
        }
    }
    public void PlayAltMusic(string name, float start = 0.0f)
    {
        Sounds s = Array.Find(altMusicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            altMusicSource.clip = s.clip;
            altMusicSource.time = start;
            altMusicSource.Play();
        }
    }
}
