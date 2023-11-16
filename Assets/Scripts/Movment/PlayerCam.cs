using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private float up;
    [SerializeField] private float down;

    [SerializeField] private Transform orientation;

    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        MouseControl();
    }
    void MouseControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mousey = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, up, down);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        orientation.Rotate(Vector3.up * mouseX);
    }
}
