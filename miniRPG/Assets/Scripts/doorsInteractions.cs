using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsInteractions : MonoBehaviour
{
    private bool action = false;
    private bool isOpen = false;

    void Update()
    {
        if (action && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            Debug.Log("Player clicked the doors");
            this.GetComponent<Animation>().Play("DoorsOpening");
            isOpen = true;
        }

        else if (action && Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            this.GetComponent<Animation>().Play("DoorsClosing");
            isOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player near the doors");
            action = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        action = false;
    }
}
