using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsManager : SingletonMonobehaviour<SoundEffectsManager>
{
    [SerializeField] private Transform player;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] public AudioClip footStep;
    [SerializeField] public AudioClip pick_Up;
    [SerializeField] public AudioClip rustle;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }


}
