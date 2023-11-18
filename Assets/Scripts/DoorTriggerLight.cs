using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerLight : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask doorLayer; 
    public GameObject GameObject;

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
            
                   Debug.Log("Ray hit");
                    Destroy(hit.collider.gameObject);
               
        
    
}
        }
          }

