using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeAudio : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
        audioSource.Play();
    }

    private void Update()
    {
    }
}
