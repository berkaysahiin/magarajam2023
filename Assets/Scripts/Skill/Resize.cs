using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : ISkill
{
    public Vector3 ScaleVector = new(0.01f,0.01f,0.01f);
    public float MinSize = 0.8f;
    public float MaxSize = 4;


    public void Apply(GameObject obj)
    {
        obj.transform.localScale += ScaleVector;
        obj.GetComponent<Interactable>().Resizing = true;
        Debug.Log("Resizing " + obj.name);
    }
   
    public bool CheckApply(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;
        if (obj.transform.localScale.magnitude >= MaxSize) return false;
        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.Resizable) return false;

        return true;
    }

    public bool CheckRevert(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;
        if (obj.transform.localScale.magnitude <= MinSize) return false;

        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.Resizable) return false;

        return true;
    }

    public void Revert(GameObject obj)
    {
        obj.transform.localScale -= ScaleVector;
        obj.GetComponent<Interactable>().Resizing = false;
        Debug.Log("Reverted Resize " + obj.name);
    }
}
