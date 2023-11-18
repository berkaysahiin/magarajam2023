using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : ISkill
{
    public bool CurrentlyUsing { get; set; }
    public void Apply(GameObject obj)
    {
        var interactable = obj.GetComponent<Interactable>();
        obj.transform.localScale += interactable.ScaleVector;
        obj.GetComponent<Interactable>().Resizing = true;
        Debug.Log("Resizing " + obj.name);
    }
   
    public bool CheckApply(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;
        if (!obj.TryGetComponent(out Interactable interactable) ||
            !interactable.Resizable ||
            obj.transform.localScale.x > interactable.MaxSize.x ||
            obj.transform.localScale.y > interactable.MaxSize.y ||
            obj.transform.localScale.z > interactable.MaxSize.z) return false;


        return true;
    }

    public bool CheckRevert(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;

        if (!obj.TryGetComponent(out Interactable interactable)
            || !interactable.Resizable
            || obj.transform.localScale.x < interactable.MinSize.x 
            || obj.transform.localScale.y < interactable.MinSize.y 
            || obj.transform.localScale.z < interactable.MinSize.z) 
            return false;

        return true;
    }

    public void Revert(GameObject obj)
    {
        var interactable = obj.GetComponent<Interactable>();
        obj.transform.localScale -= interactable.ScaleVector;
        obj.GetComponent<Interactable>().Resizing = false;
        Debug.Log("Reverted Resize " + obj.name);
    }
}
