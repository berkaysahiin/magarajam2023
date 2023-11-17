using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollision : ISkill
{
    public void Apply(GameObject obj)
    {
        obj.GetComponent<Collider>().excludeLayers += LayerMask.GetMask("Default");
        obj.GetComponent<Interactable>().CollisionRemoved = true;
        Debug.Log("Collision removed " + obj.name);
    }

    public bool CheckApply(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;

        if (!obj.TryGetComponent(out Collider _)) return false;
        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.CollisionRemovable || interactable.CollisionRemoved) return false;

        return true;
    }

    public bool CheckRevert(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;

        if (!obj.TryGetComponent(out Collider _)) return false;
        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.CollisionRemovable || !interactable.CollisionRemoved) return false;

        return true;
    }

    public void Revert(GameObject obj)
    {
        obj.GetComponent<Collider>().excludeLayers -= LayerMask.GetMask("Default");
        obj.GetComponent<Interactable>().CollisionRemoved = false;
        Debug.Log("Collision added back " + obj.name);
    }
}
