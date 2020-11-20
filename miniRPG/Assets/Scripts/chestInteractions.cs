using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestInteractions : MonoBehaviour
{
    private bool action = false;
    private bool isOpen = false;

    public GameObject ActionButton;
    public GameObject ActionText;



    void Update()
    {

        if (action && !isOpen)
        {
            ActionText.GetComponent<Text>().text = "Open chest";
        }
        else if (action && isOpen)
        {
            ActionText.GetComponent<Text>().text = "Take Sword";
        }

        if (Quest001.swordIsTaken)
        {
            ActionText.SetActive(false);
            ActionButton.SetActive(false);
        }


        if (action && Input.GetButtonDown("Action") && !isOpen)
        {
            this.GetComponent<Animation>().Play("ChestOpening");
            isOpen = true;
            //this.GetComponent<BoxCollider>().enabled = false;
            Quest001.canTake = true;
            
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            action = true;
            ActionText.SetActive(true);
            ActionButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        action = false;

        ActionText.SetActive(false);
        ActionButton.SetActive(false);
    }

}
