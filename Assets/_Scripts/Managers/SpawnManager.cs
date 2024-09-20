using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    private List<GameObject> spawnedEnemies = new List<GameObject>(); //Tracks objects spawned in the area
    public void spawnObjects()
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
    }
}

