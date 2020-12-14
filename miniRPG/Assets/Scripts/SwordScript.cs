using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public static bool canAttack = true;
    public static bool dealDamage;
    public SpiderStatus spider;

    public int damage;

    private void Start()
    {
        damage = 5 * (PlayerStats.lvl +1);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            gameObject.GetComponent<Animation>().Play("SwordAttack");
            if (dealDamage)
            {
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator SwordSwing()
    {
        
        yield return new WaitForSeconds(2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dealDamage = true;
            spider = other.GetComponent<SpiderStatus>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dealDamage = false;
        spider = null;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.25f);
        spider.TakeDamage(damage);
        Debug.Log("attack");

        yield return new WaitForSeconds(0.30f);
        dealDamage = true;
    }
}
