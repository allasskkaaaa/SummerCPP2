using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;         // Amount of damage to apply
    public float damageInterval = 1f; // Time in seconds between each damage tick
    public List<GameObject> targets = new List<GameObject>(); // List of potential targets

    private Coroutine damageCoroutine;

    private void OnTriggerStay(Collider hit)
    {
        if (targets.Contains(hit.gameObject)) // Check if the hit object is in the target list
        {
            Debug.Log("Target detected");
            // Start coroutine if it's not already running
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DealDamageOverTime());
            }
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (targets.Contains(hit.gameObject)) // Check if the hit object is in the target list
        {
            // Stop coroutine if it’s running
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    private IEnumerator DealDamageOverTime()
    {
        // While the coroutine is running, apply damage to each target in the list
        while (true)
        {
            foreach (GameObject target in targets)
            {
                if (target.CompareTag("Player"))
                {
                    GameManager.Instance.health -= damage; // Adjust this line if health is managed differently
                } else
                {
                    Destroy(target);
                }
            }

            yield return new WaitForSeconds(damageInterval);
        }
    }
}
