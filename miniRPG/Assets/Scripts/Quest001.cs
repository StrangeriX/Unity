using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest001 : MonoBehaviour
{
    public static bool canTake;
    public GameObject FakeSword;
    public GameObject sword;
    private bool takeSword;
    public static bool swordIsTaken;


    public GameObject ChestInteraction;

    private void Start()
    {
        swordIsTaken = false;
        FakeSword.GetComponent<BoxCollider>().enabled = false;
        canTake = false;
        takeSword = false;
    }

    void Update()
    {
        if (canTake)
        {
            FakeSword.GetComponent<BoxCollider>().enabled = true;
        }

        if (takeSword && Input.GetButtonDown("Action"))
        {
            TakeSword();
            SwordScript.canAttack = true;
            swordIsTaken = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player can take the sword");
            takeSword = true;
        }
    }

    void TakeSword()
    {
        FakeSword.SetActive(false);
        sword.SetActive(true);
        Quest001_progress.QuestProgress = 4;
    }

}
