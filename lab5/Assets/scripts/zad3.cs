using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public List<Vector3> points = new List<Vector3>();
    public List<Vector3> reversPoint = new List<Vector3>();
    private Transform oldParent;
    public bool isRunningTo;
    public bool isRunningBack;
    public float speed = 1f;
    public bool isMoving;

    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        isRunningBack = false;
        isRunningTo = false;
        isMoving = false;

        transform.position = new Vector3(0f,0f,0f);
        points.Add(new Vector3(0,0,0));
        points.Add(new Vector3(0,0,2));
        points.Add(new Vector3(2,0,2));
        reversPoint = points;
        reversPoint.Reverse();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;


        if (isRunningTo)
        {
                 
        }

    }

    private Vector3 nextStep(List<Vector3> list)
    {
        Vector3 goTo = new Vector3();
        foreach (var point in list)
        {
            goTo = point;
        }

        return goTo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is on last elevator");



            isRunningTo = true;
            isMoving = true;
        }

        
    }
}
