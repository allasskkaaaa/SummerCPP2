using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Transform[] spawnPoints;
    private List<GameObject> spawnedObjects = new List<GameObject>(); //Tracks objects spawned in the area
    public void spawnObjects()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Randomly select an object from the array
            int randomIndex = Random.Range(0, gameObjects.Length);
            GameObject randomObject = gameObjects[randomIndex];

            // Instantiate the randomly selected object at the spawn point
            GameObject objectSpawned = Instantiate(randomObject, spawnPoint.position, spawnPoint.rotation);
            spawnedObjects.Add(objectSpawned); // Track the spawned object
        }
    }

    public void despawnObjects()
    {
        foreach (GameObject objectSpawned in spawnedObjects)
        {
            if (objectSpawned != null)
            {
                Destroy(objectSpawned);
            }
        }
    }
}

