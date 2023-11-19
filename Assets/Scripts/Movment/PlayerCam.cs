using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sens;

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
        Debug.Log($"Sensivity {Settings.Instance.Sensivity}, sens: {sens}");
        MouseControl(Settings.Instance.Sensivity * sens);
    }
    void MouseControl(float sensivity)
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensivity;
        float mousey = Input.GetAxis("Mouse Y") * Time.deltaTime * sensivity;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, up, down);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        orientation.Rotate(Vector3.up * mouseX);
    }
}
