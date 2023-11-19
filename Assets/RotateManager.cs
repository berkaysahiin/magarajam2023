using UnityEngine;

public class RotateManager : MonoBehaviour
{
    RortateControl[] childRotates;
    GameObject player;
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

            Invoke(nameof(EndSequence), 10);
        }
    }

    private void EndSequence()
    {
        SceneManagerScript.Instance.LoadNextScene();
    }
    

}
