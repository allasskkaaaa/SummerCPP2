using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int health = 20;
    private HealthManager healthManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthManager = other.GetComponent<HealthManager>();

            healthManager.AddHealth(health);
            Destroy(gameObject);
        }
    }
}
