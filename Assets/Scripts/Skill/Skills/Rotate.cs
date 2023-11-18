using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : ISkill
{
    public bool CurrentlyUsing { get; set; }

    public void Apply(GameObject obj)
    {
        var interactable =  obj.GetComponent<Interactable>();
        obj.transform.Rotate(interactable.RotateVector);
        interactable.Rotating = true;
        Debug.Log("Rotating Object");
    }

    public bool CheckApply(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;
        if (!obj.TryGetComponent(out Interactable interactable) ||
            !interactable.Rotatable) return false;

        return true;

    }

    public bool CheckRevert(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;
        if (!obj.TryGetComponent(out Interactable interactable) ||
            !interactable.Rotatable) return false;

        return true;

    }

    public void Revert(GameObject obj)
    {
        var interactable =  obj.GetComponent<Interactable>();
        obj.transform.Rotate(interactable.RevertRotateVector);
        interactable.Rotating = true;

    }
}
