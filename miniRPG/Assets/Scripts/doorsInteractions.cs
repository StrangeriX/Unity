using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorsInteractions : MonoBehaviour
{
    private bool action = false;
    private bool isOpen = false;

    public GameObject ActionButton;
    public GameObject ActionText;

    void Update()
    {
        if (!isOpen && action)
        {
            ActionText.GetComponent<Text>().text = "Open doors";
        }
        else if (isOpen && action)
        {
            ActionText.GetComponent<Text>().text = "Close doors";
        }


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
            
            ActionButton.SetActive(true);
            
            ActionText.SetActive(true);

            Debug.Log("Player near the doors");
            action = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        action = false;

        ActionButton.SetActive(false);
        ActionText.SetActive(false);
    }


}
