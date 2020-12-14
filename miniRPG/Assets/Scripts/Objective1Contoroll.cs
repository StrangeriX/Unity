using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective1Contoroll : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Quest001_progress.QuestProgress = 2;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
