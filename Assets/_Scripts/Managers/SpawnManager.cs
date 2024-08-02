using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject[] objectSpawned;
    public Transform[] spawnPoints;
    private int randomObjectIndex;
    private int randomSpawnIndex;
    // Start is called before the first frame update
    void Start()
    {
        spawnObject();
    }

    void spawnObject()
    {
        

        if (objectSpawned.Length < 0)
        {
            Debug.Log("No objects to spawn assigned");
            return;
        }

        if (spawnPoints.Length < 0)
        {
            Debug.Log("No spawn points assigned");
            return;
        }
        else
        {
            Debug.Log("Object Spawned");
        }

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            randomObjectIndex = Random.Range(0, objectSpawned.Length);
            randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(objectSpawned[randomObjectIndex], spawnPoints[randomSpawnIndex].position, spawnPoints[randomSpawnIndex].rotation);
        }
        
    }
}
