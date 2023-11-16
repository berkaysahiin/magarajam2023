using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransfrom : MonoBehaviour
{
    [SerializeField] GameObject camTransform;
    void Update()
    {
        gameObject.transform.position=camTransform.transform.position;
    }
}
