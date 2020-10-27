using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0f, 0f, 0f);
    
    }

    void FixedUpdate()
    {
        if (rb.position.x <= 0 && rb.position.z <= 0)
        {
            transform.rotation = new Quaternion(0,0,0,0);
            rb.velocity = new Vector3(10,0,0);
        }
        if (rb.position.x >= 10 && rb.position.z <= 0)
        {
            transform.Rotate(0, 90, 0);
            rb.velocity = new Vector3(0, 0, 10);
        }

        if (rb.position.z >= 10 && rb.position.x >= 10)
        {
            transform.Rotate(0, 90, 0);
            rb.velocity = new Vector3(-10,0,0);
        }

        if (rb.position.x <= 0 && rb.position.z >= 10)
        {
            transform.Rotate(0, 90, 0);
            rb.velocity = new Vector3(0,0,-10);
        }
    }
}