using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Quest001_progress : MonoBehaviour
{

    public GameObject QuestHolder;
    private int expHolder = 20;
    public static int QuestProgress;

    public PlayerStats playerStats;

    public void AcceptQuest()
    {
        StartCoroutine(StartQuest());
        QuestProgress = 1;
    }

    private void Update()
    {
        if (QuestProgress == 2)
        {
            Debug.Log(QuestProgress);
            StartCoroutine(Objective1());
            QuestProgress = 3;
        }

        if (QuestProgress == 4)
        {
            StartCoroutine(Objective2());
            QuestProgress = 5;
        }

        if (QuestProgress == 6)
        {
            StartCoroutine(Objective3());
            playerStats.GetExp(expHolder);
            QuestProgress = 7;
        }
    }


    IEnumerator StartQuest()
    {
        QuestHolder.GetComponent<Animation>().Play("QuestAppeare");
        yield return null;
    }

    IEnumerator Objective1()
    {
        QuestHolder.GetComponent<Animation>().Play("Objective1");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Objective2()
    {
        QuestHolder.GetComponent<Animation>().Play("Objective2");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Objective3()
    {
        QuestHolder.GetComponent<Animation>().Play("Objective3");
        yield return new WaitForSeconds(1f);
    }
}
