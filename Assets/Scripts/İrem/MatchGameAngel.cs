using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameAngel : MonoBehaviour
{
    [SerializeField] private GameObject angel;
    [SerializeField] private GameObject interactiveAngel;

    public Transform Angel;
    public Transform InteractiveAngel;

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

    private void StatueMatch()
    {
        if (AreTransformsEqualWithTolerance(Angel, InteractiveAngel, 0.4f))
        {
            // Dınk diye ses
            audioSource.clip = DingIrem;
            audioSource.Play();
            StatueScoreManager.Instance.IncreaseStatueEnabled();
            StatueScoreManager.Instance.CheckMaxStatueEnabled();
            // Objelerin scriptini sil
            Debug.Log("başarılı");
            interactiveAngel.GetComponent<Interactable>().enabled = false;
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
