using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    private State currentState = State.None;
    public void ChangeStateTo(State state)
    {
        currentState = state;
    }
}
public enum State
{
    None,
    Idle,
    Skill_RemoveCollision,
    Skill_Freeze,
    Skill_Resize,
    Skill_Switch,
    Skill_Rotate,
}

