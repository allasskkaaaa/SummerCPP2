using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    public int level = 0; // Indicates the level

    private SpawnManager spawnManager; // Reference to the SpawnManager
    private bool hasSpawned = false;   // Track if objects have been spawned

    private void Start()
    {
        // Assuming the SpawnManager is on the same GameObject or assign it manually in the Inspector
        spawnManager = GetComponent<SpawnManager>();
        if (spawnManager == null)
        {
            Debug.LogError("SpawnManager is not assigned to LevelUpdate.");
        }
    }

    private void Update()
    {
        // Check if the level in GameManager matches this level
        if (GameManager.Instance.level == level && !hasSpawned)
        {
            Debug.Log("Spawning objects for level " + level);
            spawnManager.spawnEnemies();
            hasSpawned = true; // Mark as spawned to prevent repeated spawning
        }
        else if (GameManager.Instance.level != level && hasSpawned)
        {
            Debug.Log("Despawning objects for level " + level);
            spawnManager.despawnEnemies();
            hasSpawned = false; // Reset so it can spawn again if the level is revisited
        }
    }
}
