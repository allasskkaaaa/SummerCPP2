using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 5; 
    

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("NPC") || hit.CompareTag("Player") || hit.CompareTag("Enemy"))
        {
            GameObject target = hit.gameObject;

            HealthManager healthManager = target.GetComponent<HealthManager>();

            if (healthManager == null)
            {
                Debug.Log("Object doesn't have a health manager.");
            } else
            {
                healthManager.TakeDamage(damage);
            }
        }
        
    }
}
