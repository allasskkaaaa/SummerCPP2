using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 5;
    public GameObject user; // Specify the user to avoid them

    private void OnTriggerEnter(Collider hit)
    {
        GameObject target = hit.gameObject;

        // Check if the target is the user to ignore
        if (target == user)
        {
            return; // Exit the method if the target is the user
        }

        if (target.CompareTag("NPC") || target.CompareTag("Player") || target.CompareTag("Enemy"))
        {
            HealthManager healthManager = target.GetComponent<HealthManager>();

            if (healthManager == null)
            {
                Debug.Log("Object doesn't have a health manager.");
            }
            else
            {
                healthManager.TakeDamage(damage);
            }
        }
    }
}
