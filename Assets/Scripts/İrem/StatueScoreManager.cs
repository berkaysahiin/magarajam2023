using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueScoreManager : MonoBehaviour
{
    
    private const int MAX_STATUE_ENABLED = 1;

    public static StatueScoreManager Instance { get; private set; }

    [SerializeField] private int statueEnabled = 0;
    [SerializeField] private GameObject kapı;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseStatueEnabled()
    {
        statueEnabled++;
        Debug.Log("12");
    }

    public void CheckMaxStatueEnabled()
    {
        if(statueEnabled == MAX_STATUE_ENABLED)
        {
             Destroy(kapı);
            Debug.Log("22");


        }

    }
    //public void NextScene()
     //trigger yazılacak yeni sahneye 
}
