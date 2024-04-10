using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip BuildPhaseMusic;
    public AudioClip CombatPhaseMusic;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartCombatMusic()
    {
        audioSource.clip = CombatPhaseMusic;
        audioSource.Play();
    }

    public void StartBuildMusic()
    {
        Debug.Log(audioSource);
        audioSource.clip = BuildPhaseMusic;
        audioSource.Play();
    }
}
