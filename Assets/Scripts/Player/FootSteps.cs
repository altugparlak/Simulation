using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip footSteps;

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        footSteps = SoundEffectsManager.Instance.footStep;
    }

    public void PlayFootStepSound()
    {
        audioSource.PlayOneShot(footSteps);
    }
}
