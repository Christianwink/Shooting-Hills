using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void MuteMusic( string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 0;
    } 

    public void RestoreMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 0.4f;
    }

    public void MuteMenu1()
    {
        MuteMusic("Tela1");
        MuteMusic("tela2");
    }
    public void RestoreMenu1()
    {
        RestoreMusic("Tela1");
        RestoreMusic("tela2");
    }

    public void PlayClick()
    {
        Play("Click");
    }

    public void PlayMenu1()
    {
        Debug.Log("menu1");
        Play("Tela1");
    }
    public void PlayMenu2()
    {
        Debug.Log("Mneu2");
        Play("tela2");
    }
    public void StopMenu1()
    {
        Debug.Log("menu1");
        Stop("Tela1");
    }
    public void StopMenu2()
    {
        Debug.Log("Mneu2");
        Stop("tela2");
    }
}
