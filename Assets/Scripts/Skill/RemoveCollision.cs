using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollision : MonoBehaviour, ISkill
{
    public void Apply(GameObject obj)
    {
        if (Check(obj))
        {
            obj.GetComponent<Collider>().enabled = false;
        }
    }

    public bool Check(GameObject obj)
    {
        if (obj == null) return false;
        if (obj.transform == null) return false;
        if (obj.isStatic) return false;
        if (!obj.activeInHierarchy) return false;
        if (!obj.TryGetComponent(out Collider _)) return false;

        return true;
    }

    public void Revert(GameObject obj)
    {
        if (Check(obj))
        {
            obj.GetComponent<Collider>().enabled = true;
        }
    }
}
