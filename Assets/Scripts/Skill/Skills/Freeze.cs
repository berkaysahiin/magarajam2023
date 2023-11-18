using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : ISkill
{
    public bool CurrentlyUsing { get; set; }

    public void Apply(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        obj.GetComponent<Interactable>().Freezed = true;
        Debug.Log("Freezed " + obj.name);
    }

    public bool CheckApply(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;

        if (!obj.TryGetComponent(out Rigidbody _)) return false;
        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.Freezable || interactable.Freezed) return false;

        return true;
    }

    public bool CheckRevert(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;

        if (!obj.TryGetComponent(out Rigidbody _)) return false;
        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.Freezable || !interactable.Freezed) return false;

        return true;
    }

    public void Revert(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        obj.GetComponent<Interactable>().Freezed = false;
        Debug.Log("Reverted Freeze " + obj.name);
    }
}
