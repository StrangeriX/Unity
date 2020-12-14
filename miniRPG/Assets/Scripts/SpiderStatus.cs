using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStatus : MonoBehaviour
{
    public int SpiderHP = 50;
    public int expHolder = 10;
    public bool isDead = false;

    public PlayerStats playerStats;

    public GameObject spider;

    public EnemyController controller;

    private void Start()
    {
       controller = this.GetComponent<EnemyController>();
    }

    void Update()
    {
        if (SpiderHP <= 0 && !isDead)
        {
            isDead = true;
            controller.enabled = false;
            spider.GetComponent<Animation>().Play("die");
            playerStats.GetExp(expHolder);
        }
    }

    public void TakeDamage(int damage)
    {
        SpiderHP -= damage;
    }

}
