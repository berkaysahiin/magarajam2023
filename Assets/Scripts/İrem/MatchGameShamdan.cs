using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameShamdan : MonoBehaviour
{
    [SerializeField] private GameObject shamdan;
    [SerializeField] private GameObject interactiveShamdan;

    public Transform Shamdan;
    public Transform InteractiveShamdan;

    private AudioSource audioSource;
    [SerializeField] private AudioClip DingIrem;

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        StatueMatch();
    }
private void StatueMatch(){


        if (AreTransformsEqual(Shamdan, InteractiveShamdan))
        {
            // Dınk diye ses
            audioSource.clip = DingIrem;
            audioSource.Play();
            StatueScoreManager.Instance.IncreaseStatueEnabled();
            StatueScoreManager.Instance.CheckMaxStatueEnabled();
            // Objelerin scriptini sil
            interactiveShamdan.GetComponent<Interactable>().enabled = false;
        }




}
    bool AreTransformsEqual(Transform t1, Transform t2)
    {
        return t1.position == t2.position && t1.rotation == t2.rotation && t1.localScale == t2.localScale;
    }
}
