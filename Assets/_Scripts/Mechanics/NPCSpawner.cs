using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcType;
    
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, 10, transform.position.z);
        Instantiate(npcType, spawnPosition, transform.rotation);
        Destroy(collision.gameObject);
        
    }
}
