using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 1;         // Amount of damage to apply
    public float damageInterval = 1f; // Time in seconds between each damage tick

    private Coroutine damageCoroutine;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player")) // Ensure the player is the one triggering the damage
        {
            damageCoroutine = StartCoroutine(DealDamageOverTime(hit));
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player") && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    private IEnumerator DealDamageOverTime(Collider player)
    {
        while (true)
        {
            GameManager.Instance.health -= damage;
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
