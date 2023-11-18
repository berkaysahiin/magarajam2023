using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    RortateControl[] childRotates;
    [SerializeField] private Light _light;

    void Start()
    {
        childRotates = GetComponentsInChildren<RortateControl>();
    }

    void Update()
    {
        bool childsFinished = true;

        foreach (var child in childRotates)
        {
            if (child.Finished == false)
            {
                childsFinished = false;
            }
        }

        _light.enabled = childsFinished;
    }
}
