using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    RortateControl[] childRotates;
    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;
    [SerializeField] private GameObject player;
    bool endgame;
    void Start()
    {
        childRotates = GetComponentsInChildren<RortateControl>();
        Invoke("LevelStart", 3);
    }

    void Update()
    {
        bool childsFinished = true;

        foreach (var child in childRotates)
        {
            if (child.Finished == false)
            {
                childsFinished = false;
            }
        }
        if (childsFinished&&endgame)
        {
            Invoke("endinggame", 3);
        }
    }
    void LevelStart()
    {
        player.transform.position = new Vector3(-0.474f, -1.384f, 0.39f);
        light1.SetActive(true);
        light2.SetActive(true);
        light3.SetActive(true);
    }
    void endinggame()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        player.transform.position = new Vector3(-19.27f, 6.167f, 66.907f);
    }
}
