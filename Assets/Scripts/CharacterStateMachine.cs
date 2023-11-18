using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    private State currentState = State.None;

    private Animator animator;

    public void ChangeStateTo(State state)
    {
        currentState = state;
    }
    
    public void Trigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    public void SetBool(string bl, bool value)
    {
        animator.SetBool(bl, value);
    }


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        
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

