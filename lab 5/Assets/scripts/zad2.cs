using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    public float doorsSpeed = 1f;
    public bool opening;
    public bool closing;
    public  float openPosition;
    public float closedPosition;

    // Start is called before the first frame update
    void Start()
    {
        opening = false;
        closing = false;
        closedPosition = transform.position.x;
        openPosition = transform.position.x+1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (opening && transform.position.x <= openPosition)
        {
            Vector3 move = transform.right * (doorsSpeed * Time.deltaTime);
            transform.Translate(move);
            
        }

        if (closing && transform.position.x >= closedPosition)
        {
            Vector3 move = transform.right * (doorsSpeed * Time.deltaTime);
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player near the doors");
            doorsSpeed = Mathf.Abs(doorsSpeed);


            opening = true;
            closing = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is out of doors");
            doorsSpeed = -doorsSpeed;
            closing = true;
            opening = false;
        }

    }
}
