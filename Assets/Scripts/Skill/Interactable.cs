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
    public float MinSize = 0.8f;
    public float MaxSize = 10;


    private Outline outline;

    private void Start()
    {
        outline = this.gameObject.AddComponent<Outline>();
        outline.OutlineWidth = 4;
        outline.OutlineColor = Color.blue;
        outline.enabled = false;
    }

    private void OnMouseOver()
    {
        if (outline == null) { return ; }
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        if (outline == null) { return ; }
        outline.enabled = false;
    }
}

