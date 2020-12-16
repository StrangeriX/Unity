using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    float speed = 0.5f;

    Vector3 moveTo;
    public  GameObject pointA;
    public  GameObject pointB;

    // Start is called before the first frame update
    void Start()
    {
        
        
        moveTo = pointA.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, moveTo, speed*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if(transform.position.x >= pointA.transform.position.x-0.5f)
        {
            moveTo = pointB.transform.position;
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if(transform.position.x <= pointB.transform.position.x+0.5f)
        {
            moveTo = pointA.transform.position;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
            
    }
}
