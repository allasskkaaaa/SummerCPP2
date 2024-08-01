using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject[] objectSpawned;
    public Transform[] spawnPoints;
    private int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        spawnObject();
    }

    // Update is called once per frame
    void spawnObject()
    {
        randomIndex = Random.Range(0, objectSpawned.Length);

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
            Instantiate(objectSpawned[randomIndex], spawnPoints[i].position, spawnPoints[i].rotation);
        }
        
    }
}
