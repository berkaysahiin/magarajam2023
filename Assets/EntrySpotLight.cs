using UnityEngine;

[RequireComponent(typeof(Light))]
public class EntrySpotLight : MonoBehaviour
{
    [SerializeField] float lightIntensity;
    [SerializeField] float afterSeconds;

    Light _light;

    void Awake()
    {
        _light = GetComponent<Light>();
        _light.enabled = false;
    }

    private void Start()
    {
        Invoke(nameof(OpenLight), afterSeconds);
    }

    private void OpenLight()
    {
        _light.enabled = true;
        _light.intensity = lightIntensity;
        GetComponent<AudioSource>().Play();
    }
}
