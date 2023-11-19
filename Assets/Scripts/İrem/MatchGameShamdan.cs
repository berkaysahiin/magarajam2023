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


       if (AreTransformsEqualWithTolerance(Shamdan, InteractiveShamdan, 1f))
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
    bool AreTransformsEqualWithTolerance(Transform t1, Transform t2, float tolerance)
    {
        bool positionEqual = Vector3.Distance(t1.position, t2.position) <= tolerance;
        bool rotationEqual = Quaternion.Angle(t1.rotation, t2.rotation) <= tolerance;
        bool scaleEqual = Vector3.Distance(t1.localScale, t2.localScale) <= tolerance;

        return positionEqual && rotationEqual && scaleEqual;
    }
}
