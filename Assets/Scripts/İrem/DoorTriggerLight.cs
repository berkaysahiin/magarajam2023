using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerLight : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask doorLayer; 
    [SerializeField] private GameObject GameObject;
    [SerializeField] private GameObject Spotlight;
    [SerializeField] private GameObject Spotlight_2;
    [SerializeField] private GameObject Spotlight_3;
   
    
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
         Destroy(hit.collider.gameObject);

        //Spotlightin içindeki interact scripti disabled
    }
}
}

