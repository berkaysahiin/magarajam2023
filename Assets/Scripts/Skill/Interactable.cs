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
    
    public bool CollisionRemovable { get { return _collisionRemovable; } }
    public bool Resizable { get { return _resizable; } }
    public bool Freezable { get { return _freezable; } }
    public bool Switchable { get { return _switchable; } }


    public bool Resizing { get; set; }
    public bool CollisionRemoved { get; set; }
    public bool Freezed { get; set; }
}

