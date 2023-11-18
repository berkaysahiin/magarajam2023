using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI skinModeText;
    SkillController skillController;

    private void Awake()
    {
        skillController = FindAnyObjectByType<SkillController>();
    }

    private void Update()
    {
        skinModeText.text = skillController.CurrentSkill.ToString() + " " + "Mode";
    }
}
