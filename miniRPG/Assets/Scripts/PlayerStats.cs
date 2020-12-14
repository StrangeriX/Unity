using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject lvlup;

    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public int maxEXP;
    public int currentExp;
    public ExpBar expBar;

    public static int lvl = 1;


    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = 85 +(lvl*15);
        healthBar.maxHealt(maxHealth);

        maxEXP = 20 * lvl;
        currentExp = 0;
        expBar.MaxExp(maxEXP);

        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GetExp(5);
        }

        if (currentExp == maxEXP)
        {
            lvl++;
            lvlup.GetComponent<Animation>().Play("LevelUp");
            currentExp = 0;
            maxEXP = 20 * lvl;
            expBar.MaxExp(maxEXP);
            expBar.SetExp(0);

            maxHealth = 85 + (lvl * 15);
            currentHealth = 85 + (lvl * 15);
            healthBar.maxHealt(currentHealth);

        }

    }

    public void GetExp(int exp)
    {
        currentExp += exp;
        expBar.SetExp(currentExp);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
