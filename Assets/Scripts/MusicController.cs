using System;
using System.Collections;
using System.Collections.Generic;
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
        audioSource.clip = BuildPhaseMusic;
        audioSource.Play();
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
