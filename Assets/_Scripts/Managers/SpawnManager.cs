using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int levelToSpawn = 1;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Tracks objects spawned in the area
    private bool enemiesSpawned = false; // Ensure enemies are spawned only once per level

    private void Update()
    {
        if (GameManager.Instance.level == levelToSpawn && !enemiesSpawned)
        {
            spawnEnemies();
            enemiesSpawned = true; // Prevent multiple spawns
        }
        else if (GameManager.Instance.level != levelToSpawn && enemiesSpawned)
        {
            despawnEnemies();
            enemiesSpawned = false; // Reset when the player leaves the level
        }
    }

    public void spawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Randomly select an object from the array
            int randomIndex = Random.Range(0, enemies.Length);
            GameObject randomObject = enemies[randomIndex];

            // Instantiate the randomly selected object at the spawn point
            GameObject objectSpawned = Instantiate(randomObject, spawnPoint.position, spawnPoint.rotation);
            spawnedEnemies.Add(objectSpawned); // Track the spawned object
        }
    }

    public void despawnEnemies()
    {
        foreach (GameObject objectSpawned in spawnedEnemies)
        {
            if (objectSpawned != null)
            {
                Destroy(objectSpawned);
            }
        }
        spawnedEnemies.Clear(); // Clear the list after despawning
    }
}
