using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective3 : MonoBehaviour
{

    public GameObject spider1;
    public GameObject spider2;
    public GameObject spider3;

    public int count = 0;

    private int spider1Stat;
    private int spider2Stat;
    private int spider3Stat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            Quest001_progress.QuestProgress = 6;
            count = 4;
        }

        if (spider1.GetComponent<SpiderStatus>().isDead && spider1Stat <2)
        {
            spider1Stat = 1;
        }
        if (spider2.GetComponent<SpiderStatus>().isDead && spider2Stat < 2)
        {
            spider2Stat = 1;
        }
        if (spider3.GetComponent<SpiderStatus>().isDead && spider3Stat < 2)
        {
            spider3Stat = 1;
        }


        if (spider1Stat == 1)
        {
            count++;
            spider1Stat = 2;
        }
        if (spider2Stat == 1)
        {
            count++;
            spider2Stat = 2;
        }
        if (spider3Stat == 1)
        {
            count++;
            spider3Stat = 2;
        }
    }
}
