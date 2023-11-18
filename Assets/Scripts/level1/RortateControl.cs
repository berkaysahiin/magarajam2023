using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RortateControl : MonoBehaviour
{
    [SerializeField] private List<Transform> puzleOBJ = new();
    [SerializeField] private List<Vector3> winList = new();
    [SerializeField] private float tolareAngel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < puzleOBJ.Count; i++)
        {

        }
    }
}
