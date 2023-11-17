using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI skinModeText;

    SkillController skillController;
    Interactable[] interactables; 

    Dictionary<string, Color> skillToColor = new() {
        {"None", Color.clear },
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

    private void Start()
    {
        
    }

    private void Update()
    {
        for(int i = 0; i < interactables.Length; i++)
        {
            interactables[i].outline.OutlineColor = skillToColor[skillController.CurrentSkill.ToString()];
        }

        skinModeText.text = skillController.CurrentSkill.ToString() + " " + "Mode";
    }
}
