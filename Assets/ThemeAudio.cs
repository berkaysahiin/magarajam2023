using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeAudio : MonoBehaviour
{
    AudioSource audioSource;

    AudioClip clip;

    bool startedLoop = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
        audioSource.Play();
    }

    private void Update()
    {
        if(audioSource.isPlaying == false && startedLoop == false)
        {
            startedLoop = true;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
