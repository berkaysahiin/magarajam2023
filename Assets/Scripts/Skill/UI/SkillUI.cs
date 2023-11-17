using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    [SerializeField] SkillController skillController;
    [SerializeField] Interactable[] interactables; 

    Dictionary<string, Color> skillToColor = new() {
        {"Resize", Color.cyan },
        {"Switch", Color.red },
        {"RemoveCollision", Color.green },
        {"Freeze", Color.blue },
        {"Rotate", Color.grey },
    };


    private void Awake()
    {
        interactables = FindObjectsOfType<Interactable>();
        skillController = FindAnyObjectByType<SkillController>();
    }

    private void Update()
    {
        for(int i = 0; i < interactables.Length; i++)
        {
            interactables[i].outline.OutlineColor = skillToColor[skillController.CurrentSkill.ToString()];
        }
    }
}
