using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f; // Zýplama kuvveti
    [SerializeField] private Transform orientation;

    private CharacterController controller;
    private Vector3 playerVelocity;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
        ApplyGravity();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        if (moveDirection != Vector3.zero)
        {
            controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    bool IsGrounded()
    {
        float rayDistance = controller.height * 0.5f + 0.1f;
        Vector3 rayOrigin = transform.position + controller.center; 

        if (Physics.Raycast(rayOrigin, Vector3.down, rayDistance))
        {
            return true;
        }

        return false;
    }

    void Jump()
    {
        playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
    }
}
