using Unity.Mathematics;
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
        if (math.abs(targetRotation.y - transform.rotation.y) < tolAngle)
            Finished = true;
        else
            Finished = false;


        if (Finished)
        {
            _light.color = Color.green;
        }
        else
            _light.color = Color.red;

    }
}
