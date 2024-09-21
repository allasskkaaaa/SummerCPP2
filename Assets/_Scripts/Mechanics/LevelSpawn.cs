using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public List<Transform> ScoreSpawnPoints;
    public List<GameObject> scoreObjects;

    public List<Transform> EnemySpawnPoints;
    public List<GameObject> EnemyObjects;

    public List<GameObject> spawnedObjects;
    public List<GameObject> spawnedEnemies;

    public bool hasSpawned;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned)
        {
            foreach (Transform spawnPoint in ScoreSpawnPoints)
            {
                // Pick a random object from the spawnObjects list
                GameObject randomObject = scoreObjects[Random.Range(0, scoreObjects.Count)];

                // Instantiate the random object at the spawn point
                Instantiate(randomObject, spawnPoint.position, spawnPoint.rotation);

                spawnedObjects.Add(randomObject);
            }

            foreach (Transform spawnPoint in EnemySpawnPoints)
            {

                GameObject randomEnemy = EnemyObjects[Random.Range(0, EnemyObjects.Count)];
                Instantiate(randomEnemy, spawnPoint.position, spawnPoint.rotation);

                spawnedEnemies.Add(randomEnemy);
            }

            hasSpawned = true;
        }
    }
}
