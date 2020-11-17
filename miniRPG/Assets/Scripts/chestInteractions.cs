using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestInteractions : MonoBehaviour
{
    private bool action = false;
    private bool isOpen = false;

    void Update()
    {
        if (action && Input.GetButtonDown("Action") && !isOpen)
        {
            this.GetComponent<Animation>().Play("ChestOpening");
            isOpen = true;
        }
        else if (action && Input.GetButtonDown("Action") && isOpen)
        {
            this.GetComponent<Animation>().Play("ChestClosing");
            isOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("yes");
            action = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        action = false;
    }
}
