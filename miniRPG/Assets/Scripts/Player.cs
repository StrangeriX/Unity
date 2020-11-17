using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    
    public int currentExp;
    public ExpBar expBar;


    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxHealt(maxHealth);

        currentExp = 0;
        Debug.Log(expBar.slider.maxValue);
        expBar.MaxExp(10);
        
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
    }

    private void GetExp(int exp)
    {
        currentExp += exp;
        expBar.SetExp(currentExp);
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
