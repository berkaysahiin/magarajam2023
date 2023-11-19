using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerLight : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask doorLayer;
    [SerializeField] private AudioSource audioSource; // Add this line

    private void Update()
    {
        ThrowRaycastFromLight();
    }

    private void ThrowRaycastFromLight()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, doorLayer))
        {
            LightScoreManager.Instance.IncreaseLightsEnabled();
            LightScoreManager.Instance.CheckMaxLightsEnabled();
            Debug.Log("dınkdınk");

            // Play the audio clip
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            // Spotlightin içindeki interact scripti disabled
        }
    }
}
