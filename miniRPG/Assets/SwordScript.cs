using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public static bool canAttack;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            StartCoroutine(SwordSwing());
        }
    }

    IEnumerator SwordSwing()
    {
        gameObject.GetComponent<Animation>().Play("SwordAttack");
        yield return new WaitForSeconds(.025f);
    }
}
