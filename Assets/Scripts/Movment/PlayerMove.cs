using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    float defualt;
    [SerializeField] private float jumpForce = 8f; // Zýplama kuvveti
    [SerializeField] private Transform orientation;
    [SerializeField] private GameObject cam;
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] bool isCrouhch;
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        defualt = moveSpeed;
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
        if(Input.GetKey(KeyCode.LeftShift) && IsGrounded())
        {
            crouch(1.1f);
        }
        else
        {
            crouch(1.8f);
        }

        Debug.Log(IsGrounded());
    }

    void PlayerMovement()
    {
        if (!IsGrounded())
        {
            moveSpeed = Mathf.Lerp(moveSpeed, defualt / 2.0f, 2f * Time.deltaTime);
        }
        else if (!isCrouhch)
        {
            moveSpeed = defualt;
        }
        else 
        {
            moveSpeed = defualt / 2;
        }
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
        Vector3 rayOrigin = orientation.position + controller.center; 

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

    void crouch(float number)
    {
        Vector3 newPosition = cam.transform.position;
        newPosition.y = Mathf.Lerp(newPosition.y, number, 2f * Time.deltaTime);
        cam.transform.position = newPosition;
        isCrouhch = (newPosition.y <= 1.2f);
    }
}
