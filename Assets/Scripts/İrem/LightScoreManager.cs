using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScoreManager : MonoBehaviour
{
    
    private const int MAX_LIGHTS_ENABLED = 3;

    public static LightScoreManager Instance { get; private set; }

    [SerializeField] private int lightsEnabled = 0;
    [SerializeField] private GameObject Box131;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseLightsEnabled()
    {
        lightsEnabled++;
    }

    public void CheckMaxLightsEnabled()
    {
        if(lightsEnabled == MAX_LIGHTS_ENABLED)
        {
             Destroy(Box131);

        }

    }
    //public void NextScene()
     //trigger yazılacak yeni sahneye 
}
