using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class None : ISkill
{
    public void Apply(GameObject obj)
    {
    }

    public bool CheckApply(GameObject obj)
    {
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
