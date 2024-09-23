using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcType; // The NPC to be spawned
    public AudioClip SFX; // Sound effect to play

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>(); // Initialize sound manager reference
    }

    // Detect collision events
    private void OnCollisionEnter(Collision collision)
    {
        HandleSpawn(collision.gameObject);
    }

    // Detect trigger events
    private void OnTriggerEnter(Collider other)
    {
        HandleSpawn(other.gameObject);
    }

    // Method to handle NPC spawning and sound effect playing
    private void HandleSpawn(GameObject otherObject)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, 10, transform.position.z);

        // Instantiate the NPC at the desired position and rotation
        GameObject spawnedNPC = Instantiate(npcType, spawnPosition, transform.rotation);

        // Play sound effect if sound manager and clip exist
        if (soundManager != null && SFX != null)
        {
            soundManager.playSFX(SFX);
        }

        // Add the newly spawned NPC to the GameManager's NPCList
        GameManager.Instance.NPCList.Add(spawnedNPC);

        // Destroy the object that caused the event and the spawner itself
        Destroy(otherObject);
        Destroy(gameObject);
    }
}
