using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip BuildPhaseMusic;
    public AudioClip CombatPhaseMusic;
    public AudioClip VictoryMusic;

    AudioSource audioSource;

    public float VictoryMusicLength { get { return VictoryMusic.length; } }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        StartBuildMusic();
    }

    public void StartCombatMusic()
    {
        audioSource.loop = true;
        audioSource.clip = CombatPhaseMusic;
        audioSource.Play();
    }

    public void StartBuildMusic()
    {
        audioSource.loop = true;
        if (audioSource.clip != BuildPhaseMusic)
        {
            audioSource.clip = BuildPhaseMusic;
            audioSource.Play();

        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayVictoryMusic()
    {
        audioSource.loop = false;
        audioSource.clip = VictoryMusic;
        audioSource.Play();
    }
}
