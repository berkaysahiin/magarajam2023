using UnityEngine;

public class OpeningSpeech : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_AudioSource.isPlaying == false)
        {
            Debug.Log("is playing false");
            SceneManagerScript.Instance.LoadNextScene();
        }
    }
}
