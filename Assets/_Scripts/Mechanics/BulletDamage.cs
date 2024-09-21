using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private List<GameObject> ignore; // Specify the user to avoid them

    private void OnColliderEnter(Collision hit)
    {
        GameObject target = hit.gameObject;

        // Check if the target is the user to ignore
        foreach (GameObject obj in ignore)
        {
            if (target.CompareTag(obj.tag))
            {
                return;
            }
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
