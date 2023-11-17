using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill {
    bool CheckApply(GameObject obj);
    bool CheckRevert(GameObject obj);
    void Apply(GameObject obj);
    void Revert(GameObject obj);
}
