using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool _collisionRemovable;
    [SerializeField] private bool _resizable;
    [SerializeField] private bool _freezable;
    [SerializeField] private bool _switchable;
    [SerializeField] private bool _rotatable;
    
    public bool CollisionRemovable { get { return _collisionRemovable; } }
    public bool Resizable { get { return _resizable; } }
    public bool Freezable { get { return _freezable; } }
    public bool Switchable { get { return _switchable; } }
    public bool Rotatable { get { return _rotatable; } }


    public bool Resizing { get; set; }
    public bool Rotating { get; set; }
    public bool CollisionRemoved { get; set; }
    public bool Freezed { get; set; }
    
    public Vector3 ScaleVector = new(0.01f,0.01f,0.01f);
    public Vector3 RotateVector = new(0.1f,0.1f,0.1f);
    public Vector3 RevertRotateVector = new(0.1f,0.1f,0.1f);
    public Vector3 MinSize = Vector3.zero;
    public Vector3 MaxSize = Vector3.zero;

    SkillController skillController;

    Outline outline;
    Dictionary<string, bool> skillToBoolInteractable;
    Dictionary<string, Color> skillToColor = new() {
        {"None", Color.clear },
        {"Resize", Color.cyan },
        {"Switch", Color.red },
        {"RemoveCollision", Color.green },
        {"Freeze", Color.blue },
        {"Rotate", Color.magenta },
    };

    private void Awake()
    {
        skillController = FindObjectOfType<SkillController>();
    }

    private void Start()
    {
        outline = this.gameObject.AddComponent<Outline>();
        outline.OutlineWidth = 10;
        outline.enabled = false;

        skillToBoolInteractable = new()
        {
            { "None", false },
            { "RemoveCollision", CollisionRemovable },
            { "Switch", Switchable },
            { "Resize", Resizable },
            { "Freeze", Freezable },
            { "Rotate", Rotatable },
        };
    }

    private void Update()
    {
        outline.OutlineColor = skillToColor[skillController.CurrentSkill.ToString()];
    }

    private void OnMouseOver()
    {
        if (outline == null) { return ; }
        if (skillToBoolInteractable[skillController.CurrentSkill.ToString()])
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }

    private void OnMouseExit()
    {
        if (outline == null) { return ; }
        outline.enabled = false;
    }
}

