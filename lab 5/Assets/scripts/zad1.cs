using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    public float elevatorSpeed = 1f;
    private Vector3 start = new Vector3(0f, 0, 4f);
    private Vector3 destination = new Vector3(0f,0,-4f);
    public bool isRunning = false;
    public bool isOnStart = true;


    void Start()
    {
       // transform.position = start;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z <= destination.z)
        {
            elevatorSpeed = Mathf.Abs(elevatorSpeed);
        }
        
        if (isRunning)
        {
            Vector3 move = transform.forward * (elevatorSpeed * Time.deltaTime);
            transform.Translate(move);
        }
        if (isRunning && !isOnStart && transform.position.z >= start.z)
        {
            transform.position= new Vector3(0f,0f,4f);
            isRunning = false;
            isOnStart = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player enter the elevator");
        }

        if (transform.position.z >= start.z)
        {
            elevatorSpeed = -elevatorSpeed;
        }

        isOnStart = false;
        isRunning = true;
    }
}
