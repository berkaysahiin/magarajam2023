using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("References")]
    public Vector3 restPosition;
    public Transform camera;
    public PlayerMove player;

    [Header("Settings")]
    public float bobSpeed = 4.8f;
    public float IdlebobSpeed = 2f;
    public float bobAmount = 0.05f;

    private float timer = Mathf.PI / 2;

    private void Update()
    {
        WalkBOB();
    }

    private void WalkBOB()
    {
        if (player.canMove)
        {
            timer += bobSpeed * Time.deltaTime;

            Vector3 newPosition = new Vector3(Mathf.Cos(timer) * bobAmount,
                restPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), restPosition.z);
            camera.localPosition = newPosition;
        }
        else
        {
            timer += IdlebobSpeed * Time.deltaTime;

            Vector3 newPosition = new Vector3(Mathf.Cos(timer) * bobAmount,
                restPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), restPosition.z);
            camera.localPosition = newPosition;
        }

        if (timer > Mathf.PI * 2)
        {
            timer = 0;
        }

    }
}
