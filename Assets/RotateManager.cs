using UnityEngine;

public class RotateManager : MonoBehaviour
{
    RortateControl[] childRotates;
    GameObject player;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    void Start()
    {
        childRotates = GetComponentsInChildren<RortateControl>();
        player = FindObjectOfType<SkillController>().gameObject;
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

        
        if (childsFinished)
        {
            for (int i = 0; i < childRotates.Length; i++)
            {
                childRotates[i].gameObject.transform.LookAt(player.transform);
            }

            if (audioSource.isPlaying == false) { audioSource.Play(); }
            Invoke(nameof(EndSequence),  audioSource.clip.length);
        }
    }

    private void EndSequence()
    {
        SceneManagerScript.Instance.LoadNextScene();
    }
    

}
