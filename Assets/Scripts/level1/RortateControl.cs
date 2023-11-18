using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RortateControl : MonoBehaviour
{
    public bool Finished;
    [SerializeField] private GameObject lights;
    [SerializeField] Vector3 targetRotation = Vector3.zero;
    [SerializeField] float tolAngle = 30f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Finished) return;

        // check the angle between this object's rotation and the target rotation. if abs angle is smaller ben tolAngle debug.log true
        float angle = Vector3.Angle(transform.eulerAngles, targetRotation);

        // Check if the absolute angle is smaller than the tolerance angle
        if (Mathf.Abs(angle) < tolAngle)
        {
            // Debug log that the angle is smaller than the tolerance angle
            Debug.Log("Angle is smaller than tolerance angle");
            Finished = true;
        }
        else
            Finished = false;

        lights.SetActive(Finished);
    }
}
