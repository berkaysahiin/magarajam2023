using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    [SerializeField] Slider sensivity;
    [SerializeField] Slider sound;
    [SerializeField] GameObject container;

    public float Sensivity => sensivity.value;
    public float Sound => sound.value;


    private static Settings instance;

    private void Update()
    {
        Debug.Log(Sensivity);
        Debug.Log(Sound);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            var active = container.activeInHierarchy;

            if (active) // deactivate
            {
                Cursor.lockState = CursorLockMode.Locked;
                container.SetActive(false);
            }
            else // activate
            {
                Cursor.lockState = CursorLockMode.None;
                container.SetActive(true);

            }
        }
    }

    // Public accessor for the instance
    public static Settings Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Settings");
                instance = go.AddComponent<Settings>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
    public void Continue()
    {
        Debug.Log("2112313213213213");
    }

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Add your settings variables or methods here...
}

