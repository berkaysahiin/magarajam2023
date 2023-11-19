using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RortateControl : MonoBehaviour
{
    public bool Finished;
    [SerializeField] Vector3 targetRotation = Vector3.zero;
    [SerializeField] float minRotationOffset = 10f;

    private Light _light;

    private void Awake()
    {
        _light = GetComponentInChildren<Light>();
    }

    void Update()
    {
        float currentRotationY = Clamp0360(transform.eulerAngles.y);
        float targetRotationY = Clamp0360(targetRotation.y);

        var diff = math.abs(targetRotationY - currentRotationY);

        Debug.Log($"{gameObject.name} -> CurrentRotationY : {currentRotationY}, TargetRotationY : {targetRotationY}, diff: {diff}");

        if (diff < minRotationOffset) Finished = true;


        if (Finished)
        {
            _light.color = Color.green;
        }
        else
            _light.color = Color.red;

    }

    public float Clamp0360(float eulerAngles)
    {
        float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
        if (result < 0)
        {
            result += 360f;
        }
        return result;
    }

}
