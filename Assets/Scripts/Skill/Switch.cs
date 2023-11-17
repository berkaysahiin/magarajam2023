using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Switch : ISkill
{
    private GameObject obj1 = null;
    public void Apply(GameObject obj)
    {
        if (obj1 == null)
        {
            obj1 = obj;
            return;
        }

        if (obj.GetInstanceID() == obj1.GetInstanceID()) return;

        var vec1 = obj.transform.position; 
        var vec2 = obj1.transform.position;

        obj.SetActive(false);
        obj1.SetActive(false);

        obj.transform.position = Vector3.Lerp(vec1, vec2, 1);
        obj1.transform.position = Vector3.Lerp(vec2, vec1, 1);

        obj.SetActive(true);
        obj1.SetActive(true);

        obj1 = null;
    }

    public bool CheckApply(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;
        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.Switchable) return false;

        return true;
    }

    public bool CheckRevert(GameObject obj)
    {
        return true;
    }

    public void Revert(GameObject obj)
    {
    }
}
