using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject objectSpawned;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        spawnObject();
    }

    // Update is called once per frame
    void spawnObject()
    {
        
        if (spawnPoints.Length < 0)
        {
            Debug.Log("No spawn points assigned");
            return;
        }
        else
        {
            Debug.Log("Object Spawned");
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(objectSpawned, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
    }
}
