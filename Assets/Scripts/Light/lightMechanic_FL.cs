using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMechanic_FL : MonoBehaviour
{
    [Header("Lights")]
    [SerializeField] private Light lightOBJ;
    [SerializeField] private float transitionDuration = 0.1f;
    [SerializeField] private float intensity;
    [SerializeField] private bool autoOplen;

    [Header("Lights")]
    [SerializeField] private AudioSource audioSource;

    byte delay;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        lightOBJ = this.gameObject.GetComponent<Light>();
        if (autoOplen)
        {
            delay = 2;
            StartCoroutine(DelayedSmoothIntensityChange());
            delay = 0;
        }
    }

    IEnumerator DelayedSmoothIntensityChange()
    {
        yield return new WaitForSeconds(delay);

        float time = 0.0f;
        audioSource.Play();
        while (time < transitionDuration)
        {
            time += Time.deltaTime;

            float inty = Mathf.Lerp(0f, intensity, time / transitionDuration);
            lightOBJ.intensity = inty;

            yield return null;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(DelayedSmoothIntensityChange());
        }
    }
}
