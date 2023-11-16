using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform orientation;

    private CharacterController controller;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal=Input.GetAxisRaw("Horizontal");
        float vertical =Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;
        controller.SimpleMove(moveDirection.normalized * moveSpeed);

        if (horizontal != 0 || vertical != 0)
        {
            canMove = true;
        }
        else canMove = false;

    }
}
