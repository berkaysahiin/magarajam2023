using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameTeapot : MonoBehaviour
{
    [SerializeField] private GameObject teapot;
    [SerializeField] private GameObject interactiveTeapot;

    public Transform Teapot;
    public Transform InteractiveTeapot;

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


        if (AreTransformsEqual(Teapot, InteractiveTeapot))
        {
            // Dınk diye ses
            audioSource.clip = DingIrem;
            audioSource.Play();
            StatueScoreManager.Instance.IncreaseStatueEnabled();
            StatueScoreManager.Instance.CheckMaxStatueEnabled();
            // Objelerin scriptini sil
            interactiveTeapot.GetComponent<Interactable>().enabled = false;
        }




}
    bool AreTransformsEqual(Transform t1, Transform t2)
    {
        return t1.position == t2.position && t1.rotation == t2.rotation && t1.localScale == t2.localScale;
    }
}
