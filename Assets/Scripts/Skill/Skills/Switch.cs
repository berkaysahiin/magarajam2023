using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
            var obj1Outline = obj1.GetComponent <Outline>();
            obj1Outline.OutlineColor = Color.white;
            obj1Outline.enabled = true;
            return;
        }


        if (obj.GetInstanceID() == obj1.GetInstanceID()) return;

        var posObj = obj.transform.position; 
        var posObj1 = obj1.transform.position;

        obj.SetActive(false);
        obj1.SetActive(false);

        var dest = new Vector3 (posObj.x, posObj1.y, posObj.z);  
        var dest1 = new Vector3 (posObj1.x, posObj.y, posObj1.z);  

        obj.transform.position = Vector3.Lerp(posObj, dest1, 1);
        obj1.transform.position = Vector3.Lerp(posObj1, dest, 1);

        obj.SetActive(true);
        obj1.SetActive(true);

        var obj1OutlineAfter = obj1.GetComponent <Outline>();
        obj1OutlineAfter.OutlineColor = Color.white;
        obj1OutlineAfter.enabled = false;

        obj1 = null;
    }

    public bool CheckApply(GameObject obj)
    {
        if (obj == null) return false;
        if (!obj.activeInHierarchy) return false;
        if (!obj.TryGetComponent(out Interactable interactable) || !interactable.Switchable) return false;

        return true;
    }

    public bool CheckRevert(GameObject obj) => true;
    public void Revert(GameObject obj) {}
}
