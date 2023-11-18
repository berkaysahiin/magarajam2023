using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.playOnAwake = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.PlayOneShot(m_AudioSource.clip);
            }
        }
    }
}
