using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public List<Transform> ScoreSpawnPoints;
    public List<GameObject> scoreObjects;

    public List<Transform> EnemySpawnPoints;
    public List<GameObject> EnemyObjects;

    public bool hasSpawned;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned && other.CompareTag("Player"))
        {
            // Spawn score objects
            if (ScoreSpawnPoints.Count > 0 && scoreObjects.Count > 0)
            {
                foreach (Transform spawnPoint in ScoreSpawnPoints)
                {
                    GameObject randomObject = scoreObjects[Random.Range(0, scoreObjects.Count)];
                    Instantiate(randomObject, spawnPoint.position, spawnPoint.rotation);
                    Debug.Log($"Spawned {randomObject.name} at {spawnPoint.position}");
                }
            }

            // Spawn enemy objects
            if (EnemySpawnPoints.Count > 0 && EnemyObjects.Count > 0)
            {
                foreach (Transform spawnPoint in EnemySpawnPoints)
                {
                    GameObject randomEnemy = EnemyObjects[Random.Range(0, EnemyObjects.Count)];
                    Instantiate(randomEnemy, spawnPoint.position, spawnPoint.rotation);
                    Debug.Log($"Spawned {randomEnemy.name} at {spawnPoint.position}");
                }
            }

            hasSpawned = true;
        }
    }

}
