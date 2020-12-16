using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float speed = 2f;
    public float distance;

    private bool movingRight = true;
    Vector2 lookAt = Vector2.right;

    public Transform groundDetection;
    public Transform sightDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        RaycastHit2D sightInfo = Physics2D.Raycast(sightDetection.position, lookAt, 10f);

        Debug.Log(lookAt);

        if (groundInfo.collider == false)
        {
            Debug.Log("turn");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                lookAt = Vector2.left;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                lookAt = Vector2.right;
            }
        }

        if (sightInfo == true)
        {
            speed = 5f;
        }
        else
        {
            speed = 2f;
        }
    }
}