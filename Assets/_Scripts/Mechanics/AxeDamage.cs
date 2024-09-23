using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private List<GameObject> ignore; // Specify the user to avoid them
    [SerializeField] private List<string> damageableTags = new List<string> { "NPC", "Player", "Enemy" }; // Tags of objects that can be damaged

    private void OnTriggerEnter(Collider hit)
    {
        GameObject target = hit.gameObject;

        // Check if the target is in the ignore list
        if (ignore.Contains(target))
        {
            return;
        }

        // Check if the target's tag is in the damageableTags list
        if (damageableTags.Contains(target.tag))
        {
            HealthManager healthManager = target.GetComponent<HealthManager>();

            if (healthManager == null)
            {
                Debug.Log("Object doesn't have a HealthManager.");
            }
            else
            {
                healthManager.TakeDamage(damage);
                Debug.Log($"{target.name} took {damage} damage!");
            }
        }
    }
}
