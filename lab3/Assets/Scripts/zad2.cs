using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class zad2 : MonoBehaviour
{

   
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0f,0f,0f);

    }

    void FixedUpdate()
    {
        if (rb.position.x >= 0)
        {
            rb.velocity = new Vector3(-10, 0, 0);

        }
        else if (rb.position.x <= -10)
        {
            rb.velocity = new Vector3(10, 0, 0);
        }
    }
}
