using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest001_accept : MonoBehaviour
{
    public GameObject Quest;
    public GameObject QuestProgress;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        
    }


    public void Accept()
    {
        Quest.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Quest001_progress.QuestProgress = 1;
    }
}
