using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToBasement : MonoBehaviour
{
    public bool near;

    private void Start()
    {
        near = false;
    }

    private void Update()
    {
        if (near && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player is going to basement");
        }
    }

    public Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player near basement hatch");
            near = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        near = false;
    }
}
