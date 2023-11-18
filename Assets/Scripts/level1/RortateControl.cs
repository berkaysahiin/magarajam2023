using Unity.VisualScripting;
using UnityEngine;

public class RortateControl : MonoBehaviour
{
    public bool Finished;
    [SerializeField] Vector3 targetRotation = Vector3.zero;
    [SerializeField] float tolAngle = 10f;

    private Light _light;

    private void Awake()
    {
        _light = GetComponentInChildren<Light>();
    }

    void Update()
    {
        float angle = Vector3.Angle(transform.eulerAngles, targetRotation);

        if (Mathf.Abs(angle) < tolAngle)
        {
            Finished = true;
        }
        else
        {
            Finished = false;
        }

        _light.enabled = Finished;
    }
}
