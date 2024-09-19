using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOvertime : MonoBehaviour
{
    public int damage = 5;
    public float dmgInterval = 1f;

    private bool isDamaging = false;  // To prevent multiple coroutines from starting

    private void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("NPC") || hit.CompareTag("Player") || hit.CompareTag("Enemy"))
        {
            GameObject target = hit.gameObject;
            HealthManager healthManager = target.GetComponent<HealthManager>();

            if (healthManager == null)
            {
                Debug.Log("Object doesn't have a health manager.");
            }
            else
            {
                if (!isDamaging)
                {
                    StartCoroutine(ApplyDamageOverTime(healthManager));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stops damage when exiting the trigger
        if (other.CompareTag("NPC") || other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            isDamaging = false;  // Stop coroutine
        }
    }

    IEnumerator ApplyDamageOverTime(HealthManager healthManager)
    {
        isDamaging = true;  // Ensure only one coroutine is active
        while (isDamaging)  // Loop while the object is within the trigger
        {
            healthManager.TakeDamage(damage);
            yield return new WaitForSeconds(dmgInterval);  // Wait for the interval before applying damage again
        }
    }
}
