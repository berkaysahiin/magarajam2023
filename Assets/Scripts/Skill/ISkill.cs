using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill {
    bool Check(GameObject obj);
    void Apply(GameObject obj);
    void Revert(GameObject obj);
}
