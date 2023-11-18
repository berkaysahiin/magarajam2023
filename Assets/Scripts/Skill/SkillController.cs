using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public ISkill CurrentSkill => currentSkill;


    private CharacterStateMachine characterStateMachine;
    private ISkill currentSkill = null;

    [SerializeField]
    private bool CanResize, CanFreeze, CanSwitch, CanRemoveCollision, CanRotate;

    private Dictionary<string, ISkill> inputToSkill = new() {
        {"Alpha1", new Resize() },
        {"Alpha2", new Switch() },
        {"Alpha3", new RemoveCollision() },
        {"Alpha4", new Freeze() },
        {"Alpha5", new Rotate() },
    };

    private Dictionary<string, State> skillToState = new() {
        {"Resize", State.Skill_Resize },
        {"Switch", State.Skill_Switch },
        {"RemoveCollision", State.Skill_RemoveCollision },
        {"Freeze", State.Skill_Freeze },
        {"Rotate", State.Skill_Rotate },
    };

    private Dictionary<string, bool> skillToBool;

    private void Awake()
    {
        characterStateMachine = GetComponent<CharacterStateMachine>();

        skillToBool = new Dictionary<string, bool>
        {
            {"None", false},
            {"Resize", CanResize},
            {"Freeze", CanFreeze },
            {"Switch", CanSwitch },
            {"RemoveCollision", CanRemoveCollision },
            {"Rotate", CanRotate }
        };
    }

    private void Start()
    {
        currentSkill = new None();
    }

    void Update()
    {
        GetSkillMode();

        switch (currentSkill)
        {
            case Resize:
                MouseHoldSkill();
                break;
            case Rotate:
                MouseHoldSkill();
                break;
            default:
                MouseClickSkill();
                break;
        }

    }
    
    private void MouseHoldSkill()
    {
        if (Input.GetMouseButton(0))
        {
            var obj = GetInteractable();

            if (obj == null) return;

            if (currentSkill.CheckApply(obj) && skillToBool[currentSkill.ToString()])
            {
                var currentSkillBool = currentSkill.ToString();
                characterStateMachine.SetBool(currentSkillBool, true);
                Debug.Log("Bool is true " + currentSkillBool);

                currentSkill.Apply(obj);
                currentSkill.CurrentlyUsing = true;
            }

        }
        else if (Input.GetMouseButton(1))
        {
            var obj = GetInteractable();

            if (obj == null) return;

            if (currentSkill.CheckRevert(obj) && skillToBool[currentSkill.ToString()])
            {
                var currentSkillBool = currentSkill.ToString();
                characterStateMachine.SetBool(currentSkillBool, true);
                Debug.Log("Bool is true " + currentSkillBool);
                currentSkill.Revert(obj);
                currentSkill.CurrentlyUsing = true;
            }
        }
        else
        {
                var currentSkillBool = currentSkill.ToString();
                characterStateMachine.SetBool(currentSkillBool, false);
                Debug.Log("Bool is false " + currentSkillBool);
                currentSkill.CurrentlyUsing = false;
        }

    }

    private void MouseClickSkill()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var obj = GetInteractable();
            if (obj == null) return;

            if (currentSkill.CheckApply(obj) && skillToBool[currentSkill.ToString()])
            {
                var currentSkillTrigger = currentSkill.ToString();
                currentSkill.Apply(obj);
                characterStateMachine.Trigger(currentSkillTrigger);
                currentSkill.CurrentlyUsing = true;
                Debug.Log("Triggered " + currentSkillTrigger);
                                
            }

        }
        else if (Input.GetMouseButtonDown(1))
        {
            var obj = GetInteractable();
            if (obj == null) return;
            
            if (currentSkill.CheckRevert(obj) && skillToBool[currentSkill.ToString()])
            {
                currentSkill.Revert(obj);
                var currentSkillTrigger = "R" + currentSkill.ToString();
                characterStateMachine.Trigger(currentSkillTrigger);
                currentSkill.CurrentlyUsing = true;
                Debug.Log("Triggered " + currentSkillTrigger);
            }

        }
        else
        {
                currentSkill.CurrentlyUsing = false;
        }
    }
   
    private GameObject GetInteractable()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var obj = hit.collider.gameObject;
            if (obj.TryGetComponent(out Interactable _))
            {
                return obj;
            }
            
        }

        return null;
    }


    void GetSkillMode()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    if (inputToSkill.TryGetValue(keyCode.ToString(), out var value))
                    {
                        if (skillToBool[value.ToString()] && !currentSkill.CurrentlyUsing)
                            currentSkill = value;
                    }
                }
            }
        }
    }
}
