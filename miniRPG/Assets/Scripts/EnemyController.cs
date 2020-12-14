using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.MeshOperations;

public class EnemyController : MonoBehaviour
{



    public Transform target;
    private NavMeshAgent agent;
    public GameObject Spider;


    public PlayerStats playerstats;


    public bool canDamage;
    public float lookRadius = 10f;
    public float distance;

    public int status;
    // Start is called before the first frame update
    void Start()
    {
        canDamage = true;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
         distance = Vector3.Distance(target.position, transform.position);

         if (distance <= lookRadius)
        {
            status = 1;
            if (distance <= agent.stoppingDistance)
            {
                status = 2;
            }
        }
        else if (distance >= lookRadius)
        {
            status = 0;
        }



        if (status == 0)
        {
            agent.isStopped = true;
            Spider.GetComponent<Animation>().Play("idle");
        }
        if (status == 1)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            Spider.GetComponent<Animation>().Play(("walk"));
        }

        if (status == 2)
        {
            FaceTarget();
            Spider.GetComponent<Animation>().Play("attack");
            

        }

        if (Spider.GetComponent<Animation>().IsPlaying("attack") && canDamage)
        {
            canDamage = false;
            StartCoroutine(Attack());
        }
        
    }


    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        playerstats.TakeDamage(5);
        Debug.Log("attack");
        
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation((new Vector3(direction.x,0,direction.z)));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime *5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
